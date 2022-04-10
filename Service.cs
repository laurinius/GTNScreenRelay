using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace GTNScreenRelay
{
    public class Service
    {
        public Service()
        {
            Settings = new ServiceSettings();
            processManager = new ProcessManager();
            captureManager = new CaptureManager();
            jpegEncoder = GetEncoder(ImageFormat.Jpeg);
            jpegQualityHigh = new EncoderParameters(1);
            jpegQualityHigh.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 95L);
            jpegQualityMedium = new EncoderParameters(1);
            jpegQualityMedium.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
            processName = (string)Properties.Settings.Default["GtnProcess"];
            windowName750 = (string)Properties.Settings.Default["GtnWindow750"];
            windowName650 = (string)Properties.Settings.Default["GtnWindow650"];
        }
        public ServiceSettings Settings { get; set; }
        private ImageCodecInfo jpegEncoder;
        private EncoderParameters jpegQualityHigh;
        private EncoderParameters jpegQualityMedium;
        private string processName;
        private string windowName750;
        private string windowName650;

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public enum ImgFormat
        {
            JPEG_HIGH,
            JPEG_MEDIUM,
            JPEG_LOW,
            PNG
        }

        public class ServiceSettings
        {
            private bool bezel650;
            private bool bezel750;
            private bool hideFrame650;
            private bool hideFrame750;

            public double Scaling { get; set; }
            public ImgFormat Format { get; set; }
            public int RefreshInterval { get; set; }
            public bool Bezel650 { get => bezel650; set { bezel650 = value; UpdateMargins(); } }
            public bool Bezel750 { get => bezel750; set { bezel750 = value; UpdateMargins(); } }
            public bool HideFrame650 { get => hideFrame650; set { hideFrame650 = value; UpdateMargins(); } }
            public bool HideFrame750 { get => hideFrame750; set { hideFrame750 = value; UpdateMargins(); } }
            public CaptureManager.Margins Margins650 { get; private set; }
            public CaptureManager.Margins Margins750 { get; private set; }


            public ServiceSettings()
            {
                Margins650 = new CaptureManager.Margins();
                Margins750 = new CaptureManager.Margins();
            }

            public void SetSettings(double scaling, ImgFormat format, int refreshInterval, bool bezel650, bool bezel750, bool frame650, bool frame750)
            {
                Scaling = scaling;
                Format = format;
                RefreshInterval = refreshInterval;
                Bezel650 = bezel650;
                Bezel750 = bezel750;
                HideFrame650 = frame650;
                HideFrame750 = frame750;
            }

            public void UpdateMargins()
            {
                switch (Bezel650)
                {
                    case true when HideFrame650:
                        Margins650.Update(0.146, 0.122, 0.127, 0.059, false);
                        break;
                    case true when !HideFrame650:
                        Margins650.Update(0.144, 0.113, 0.125, 0.055, true);
                        break;
                    case false when HideFrame650:
                        Margins650.Update(0, 0, 0, 0, false);
                        break;
                    case false when !HideFrame650:
                        Margins650.Update(0, 0, 0, 0, true);
                        break;
                }
                switch (Bezel750)
                {
                    case true when HideFrame750:
                        Margins750.Update(0.129, 0.052, 0.143, 0.058, false);
                        break;
                    case true when !HideFrame750:
                        Margins750.Update(0.127, 0.05, 0.141, 0.056, true);
                        break;
                    case false when HideFrame750:
                        Margins750.Update(0, 0, 0, 0, false);
                        break;
                    case false when !HideFrame750:
                        Margins750.Update(0, 0, 0, 0, true);
                        break;
                }
            }
        }

        public enum GtnType
        {
            GTN750,
            GTN650
        }

        private readonly ProcessManager processManager;
        private readonly CaptureManager captureManager;

        public void ProcessRequest(HttpListenerContext context)
        {
            string[] segments = context.Request.Url.Segments;
            if (segments.Length < 2)
            {
                ProcessDefaultRequest(context, GtnType.GTN750);
            }
            else
            {
                switch (segments[1].Trim('/').ToLower())
                {
                    case "settings":
                        ProcessSettingsRequest(context);
                        break;
                    case "gtn650":
                    case "gtn650xi":
                    case "650xi":
                    case "gtnxi650":
                    case "650":
                        ProcessDefaultRequest(context, GtnType.GTN650);
                        break;
                    default:
                        ProcessDefaultRequest(context, GtnType.GTN750);
                        break;
                }
            }
        }

        private IntPtr? gtnHandle650 = null;
        private IntPtr? gtnHandle750 = null;
        private Image GetCapture(GtnType type)
        {
            if (type == GtnType.GTN650)
            {
                if (gtnHandle650 == null)
                {
                    gtnHandle650 = processManager.GetWindowHandle(processName, windowName650);
                }
                if (gtnHandle650 != null)
                {
                    try
                    {
                        return captureManager.CaptureWindow(gtnHandle650.Value, Settings.Margins650);
                    }
                    catch (Exception)
                    {
                        gtnHandle650 = null;
                    }
                }
                return null;
            }
            else
            {
                if (gtnHandle750 == null)
                {
                    gtnHandle750 = processManager.GetWindowHandle(processName, windowName750);
                }
                if (gtnHandle750 != null)
                {
                    try
                    {
                        return captureManager.CaptureWindow(gtnHandle750.Value, Settings.Margins750);
                    }
                    catch (Exception)
                    {
                        gtnHandle750 = null;
                    }
                }
                return null;
            }
        }

        private void ProcessSettingsRequest(HttpListenerContext context)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('{');
            sb.Append("\"refreshInterval\":").Append(Settings.RefreshInterval);
            sb.Append('}');
            JsonResponse(context, sb.ToString(), 200);
        }

        private void ProcessDefaultRequest(HttpListenerContext context, GtnType gtnType)
        {
            Image image = GetCapture(gtnType);
            if (image != null && Settings.Scaling < 1)
            {
                image = ResizeImage(image, (int)(image.Width * Settings.Scaling), (int)(image.Height * Settings.Scaling));
            }
            ImgResponse(context, image, 200);
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                switch (Settings.Format)
                {
                    case ImgFormat.PNG:
                        image.Save(ms, ImageFormat.Png);
                        break;
                    case ImgFormat.JPEG_HIGH:
                        image.Save(ms, jpegEncoder, jpegQualityHigh);
                        break;
                    case ImgFormat.JPEG_MEDIUM:
                        image.Save(ms, jpegEncoder, jpegQualityMedium);
                        break;
                    default:
                        image.Save(ms, ImageFormat.Jpeg);
                        break;
                }
                return ms.ToArray();
            }
        }

        public Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }

            return b;
        }

        private void ImgResponse(HttpListenerContext context, Image img, int status)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = status;
            switch (Settings.Format)
            {
                case ImgFormat.PNG:
                    response.ContentType = "image/png";
                    break;
                default:
                    response.ContentType = "image/jpeg";
                    break;
            }
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
            byte[] buffer = img == null ? new byte[0] : ImageToByteArray(img);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            try
            {
                output.Write(buffer, 0, buffer.Length);
            }
            catch (Exception)
            {

            }
            finally
            {
                try
                {
                    output.Close();
                }
                catch (Exception)
                {
                    // HTTP Connection issue.
                }
            }
        }

        private void JsonResponse(HttpListenerContext context, string json, int statusCode)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = statusCode;
            response.ContentType = "application/json";
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(json);
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            try
            {
                output.Write(buffer, 0, buffer.Length);
            }
            catch (Exception)
            {
                // HTTP Connection issue.
            }
            finally
            {
                try
                {
                    output.Close();
                }
                catch (Exception)
                {
                    // HTTP Connection issue.
                }
            }
        }
    }
}
