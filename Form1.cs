using System;
using System.Windows.Forms;

namespace GTNScreenRelay
{
    public partial class Form1 : Form
    {
        private readonly Service service;
        public Form1()
        {
            InitializeComponent();
            service = new Service();
        }

        private Http http;

        private void StartHttp_Click(object sender, EventArgs e)
        {
            if (http == null)
            {
                StartHttp();
            }
            else
            {
                StopHttp();
            }
        }

        private int GetHttpPort()
        {
            return (int)Properties.Settings.Default["HttpPort"]; ;
        }

        private void StartHttp()
        {
            if (http != null)
            {
                return;
            }
            int port = GetHttpPort();
            string url = "http://localhost:" + port + "/";
            http = new Http(url, service.ProcessRequest);
            try
            {
                http.Start();
                startHttp.Text = "Stop";
            }
            catch (Exception)
            {
                http.Stop();
                http = null;
            }

        }

        private void StopHttp()
        {
            if (http == null)
            {
                return;
            }
            http.Stop();
            http = null;
            startHttp.Text = "Start";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int imageFormat = (int)Properties.Settings.Default["ImageFormat"];
            if (imageFormat < 0 || imageFormat > formatComboBox.Items.Count)
            {
                imageFormat = 1;
                Properties.Settings.Default["ImageFormat"] = imageFormat;
            }
            formatComboBox.SelectedIndex = imageFormat;
            int imageScaling = (int)Properties.Settings.Default["ImageScaling"];
            if (imageScaling < scalingTrackBar.Minimum || imageScaling > scalingTrackBar.Maximum)
            {
                imageScaling = 100;
                Properties.Settings.Default["ImageScaling"] = imageScaling;
            }
            scalingTrackBar.Value = imageScaling;
            int refreshInterval = (int)Properties.Settings.Default["RefreshInterval"];
            if (refreshInterval < 0 || refreshInterval > 1000)
            {
                refreshInterval = 50;
                Properties.Settings.Default["RefreshInterval"] = refreshInterval;
            }
            refreshIntervalTextBox.Text = refreshInterval.ToString();
            scalingTrackbarLabel.Text = imageScaling + "%";
            showBezel650CheckBox.Checked = (bool)Properties.Settings.Default["Bezel650"];
            showBezel750CheckBox.Checked = (bool)Properties.Settings.Default["Bezel750"];
            hideWindowFrame650CheckBox.Checked = (bool)Properties.Settings.Default["HideFrame650"];
            hideWindowFrame750CheckBox.Checked = (bool)Properties.Settings.Default["HideFrame750"];
            Properties.Settings.Default.Save();
            service.Settings.SetSettings(
                    (int)Properties.Settings.Default["ImageScaling"] / 100.0,
                    GetFormat(),
                    (int)Properties.Settings.Default["RefreshInterval"],
                    (bool)Properties.Settings.Default["Bezel650"],
                    (bool)Properties.Settings.Default["Bezel750"],
                    (bool)Properties.Settings.Default["HideFrame650"],
                    (bool)Properties.Settings.Default["HideFrame750"]
                );
            StartHttp();
        }

        private void FormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["ImageFormat"] = formatComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
            service.Settings.Format = GetFormat();
        }

        private void ScalingTrackBar_Scroll(object sender, EventArgs e)
        {
            scalingTrackbarLabel.Text = scalingTrackBar.Value + "%";
            Properties.Settings.Default["ImageScaling"] = scalingTrackBar.Value;
            Properties.Settings.Default.Save();
            service.Settings.Scaling = (int)Properties.Settings.Default["ImageScaling"] / 100.0;
        }

        private Service.ImgFormat GetFormat()
        {
            switch ((int)Properties.Settings.Default["ImageFormat"])
            {
                case 0:
                    return Service.ImgFormat.PNG;
                case 1:
                    return Service.ImgFormat.JPEG_HIGH;
                case 2:
                    return Service.ImgFormat.JPEG_MEDIUM;
                default:
                    return Service.ImgFormat.JPEG_LOW;
            }
        }

        private void ShowBezel750CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Bezel750"] = showBezel750CheckBox.Checked;
            Properties.Settings.Default.Save();
            service.Settings.Bezel750 = (bool)Properties.Settings.Default["Bezel750"];
        }

        private void ShowBezel650CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["Bezel650"] = showBezel650CheckBox.Checked;
            Properties.Settings.Default.Save();
            service.Settings.Bezel650 = (bool)Properties.Settings.Default["Bezel650"];
        }

        private void HideWindowFrame750CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["HideFrame750"] = hideWindowFrame750CheckBox.Checked;
            Properties.Settings.Default.Save();
            service.Settings.HideFrame750 = (bool)Properties.Settings.Default["HideFrame750"];
        }

        private void HideWindowFrame650CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["HideFrame650"] = hideWindowFrame650CheckBox.Checked;
            Properties.Settings.Default.Save();
            service.Settings.HideFrame650 = (bool)Properties.Settings.Default["HideFrame650"];
        }

        private void RefreshIntervalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (refreshIntervalTextBox.Text.Length == 0)
            {
                refreshIntervalTextBox.Text = "0";
            }
            if (int.TryParse(refreshIntervalTextBox.Text, out int refreshInterval))
            {
                if (refreshInterval < 0 || refreshInterval > 1000)
                {
                    refreshIntervalTextBox.Text = Properties.Settings.Default["RefreshInterval"].ToString();
                } else
                {
                    Properties.Settings.Default["RefreshInterval"] = refreshInterval;
                    Properties.Settings.Default.Save();
                    service.Settings.RefreshInterval = (int)Properties.Settings.Default["RefreshInterval"];
                }
            } else
            {
                refreshIntervalTextBox.Text = Properties.Settings.Default["RefreshInterval"].ToString();
            }
        }
    }
}
