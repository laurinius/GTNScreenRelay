
namespace GTNScreenRelay
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.startHttp = new System.Windows.Forms.Button();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.showBezel650CheckBox = new System.Windows.Forms.CheckBox();
            this.hideWindowFrame750CheckBox = new System.Windows.Forms.CheckBox();
            this.hideWindowFrame650CheckBox = new System.Windows.Forms.CheckBox();
            this.showBezel750CheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.scalingTrackBar = new System.Windows.Forms.TrackBar();
            this.scalingTrackbarLabel = new System.Windows.Forms.Label();
            this.refreshIntervalTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // startHttp
            // 
            this.startHttp.Location = new System.Drawing.Point(77, 221);
            this.startHttp.Name = "startHttp";
            this.startHttp.Size = new System.Drawing.Size(75, 23);
            this.startHttp.TabIndex = 1;
            this.startHttp.Text = "Start";
            this.startHttp.UseVisualStyleBackColor = true;
            this.startHttp.Click += new System.EventHandler(this.StartHttp_Click);
            // 
            // formatComboBox
            // 
            this.formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Items.AddRange(new object[] {
            "PNG",
            "JPEG High",
            "JPEG Med",
            "JPEG Low"});
            this.formatComboBox.Location = new System.Drawing.Point(92, 15);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(81, 21);
            this.formatComboBox.TabIndex = 2;
            this.formatComboBox.SelectedIndexChanged += new System.EventHandler(this.FormatComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image Format:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Scaling:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(316, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "PNG has better Quality than JPEG, but can affect performance.\r\nJPEG has different" +
    " quality settings with minor performance impact.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "Scaling the image resolution may improve performance in certain\r\ncircumstances. B" +
    "ut scaling between ~70 and 99% will likely\r\nworsen performance due to added imag" +
    "e processing overhead.";
            // 
            // showBezel650CheckBox
            // 
            this.showBezel650CheckBox.AutoSize = true;
            this.showBezel650CheckBox.Location = new System.Drawing.Point(66, 181);
            this.showBezel650CheckBox.Name = "showBezel650CheckBox";
            this.showBezel650CheckBox.Size = new System.Drawing.Size(82, 17);
            this.showBezel650CheckBox.TabIndex = 8;
            this.showBezel650CheckBox.Text = "Show Bezel";
            this.showBezel650CheckBox.UseVisualStyleBackColor = true;
            this.showBezel650CheckBox.CheckedChanged += new System.EventHandler(this.ShowBezel650CheckBox_CheckedChanged);
            // 
            // hideWindowFrame750CheckBox
            // 
            this.hideWindowFrame750CheckBox.AutoSize = true;
            this.hideWindowFrame750CheckBox.Location = new System.Drawing.Point(154, 158);
            this.hideWindowFrame750CheckBox.Name = "hideWindowFrame750CheckBox";
            this.hideWindowFrame750CheckBox.Size = new System.Drawing.Size(122, 17);
            this.hideWindowFrame750CheckBox.TabIndex = 9;
            this.hideWindowFrame750CheckBox.Text = "Hide Window Frame";
            this.hideWindowFrame750CheckBox.UseVisualStyleBackColor = true;
            this.hideWindowFrame750CheckBox.CheckedChanged += new System.EventHandler(this.HideWindowFrame750CheckBox_CheckedChanged);
            // 
            // hideWindowFrame650CheckBox
            // 
            this.hideWindowFrame650CheckBox.AutoSize = true;
            this.hideWindowFrame650CheckBox.Location = new System.Drawing.Point(154, 180);
            this.hideWindowFrame650CheckBox.Name = "hideWindowFrame650CheckBox";
            this.hideWindowFrame650CheckBox.Size = new System.Drawing.Size(122, 17);
            this.hideWindowFrame650CheckBox.TabIndex = 10;
            this.hideWindowFrame650CheckBox.Text = "Hide Window Frame";
            this.hideWindowFrame650CheckBox.UseVisualStyleBackColor = true;
            this.hideWindowFrame650CheckBox.CheckedChanged += new System.EventHandler(this.HideWindowFrame650CheckBox_CheckedChanged);
            // 
            // showBezel750CheckBox
            // 
            this.showBezel750CheckBox.AutoSize = true;
            this.showBezel750CheckBox.Location = new System.Drawing.Point(66, 158);
            this.showBezel750CheckBox.Name = "showBezel750CheckBox";
            this.showBezel750CheckBox.Size = new System.Drawing.Size(82, 17);
            this.showBezel750CheckBox.TabIndex = 11;
            this.showBezel750CheckBox.Text = "Show Bezel";
            this.showBezel750CheckBox.UseVisualStyleBackColor = true;
            this.showBezel750CheckBox.CheckedChanged += new System.EventHandler(this.ShowBezel750CheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "GTN750";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "GTN650";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 65);
            this.label7.TabIndex = 14;
            this.label7.Text = "Set these settings exactly the same as the\r\nequally named settings in the\r\nTDS GT" +
    "NXi configuration.\r\nOtherwise the dimensions of the captured\r\nscreen won\'t be ac" +
    "curate.";
            // 
            // scalingTrackBar
            // 
            this.scalingTrackBar.Location = new System.Drawing.Point(49, 111);
            this.scalingTrackBar.Maximum = 100;
            this.scalingTrackBar.Minimum = 10;
            this.scalingTrackBar.Name = "scalingTrackBar";
            this.scalingTrackBar.Size = new System.Drawing.Size(121, 45);
            this.scalingTrackBar.TabIndex = 15;
            this.scalingTrackBar.TickFrequency = 10;
            this.scalingTrackBar.Value = 100;
            this.scalingTrackBar.Scroll += new System.EventHandler(this.ScalingTrackBar_Scroll);
            // 
            // scalingTrackbarLabel
            // 
            this.scalingTrackbarLabel.AutoSize = true;
            this.scalingTrackbarLabel.Location = new System.Drawing.Point(89, 131);
            this.scalingTrackbarLabel.Name = "scalingTrackbarLabel";
            this.scalingTrackbarLabel.Size = new System.Drawing.Size(33, 13);
            this.scalingTrackbarLabel.TabIndex = 16;
            this.scalingTrackbarLabel.Text = "100%";
            // 
            // refreshIntervalTextBox
            // 
            this.refreshIntervalTextBox.Location = new System.Drawing.Point(106, 57);
            this.refreshIntervalTextBox.Name = "refreshIntervalTextBox";
            this.refreshIntervalTextBox.Size = new System.Drawing.Size(34, 20);
            this.refreshIntervalTextBox.TabIndex = 17;
            this.refreshIntervalTextBox.Text = "50";
            this.refreshIntervalTextBox.TextChanged += new System.EventHandler(this.RefreshIntervalTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Refresh Interval:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(143, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "ms";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(179, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(311, 52);
            this.label10.TabIndex = 20;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 256);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.refreshIntervalTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.scalingTrackbarLabel);
            this.Controls.Add(this.scalingTrackBar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.showBezel750CheckBox);
            this.Controls.Add(this.hideWindowFrame650CheckBox);
            this.Controls.Add(this.hideWindowFrame750CheckBox);
            this.Controls.Add(this.showBezel650CheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formatComboBox);
            this.Controls.Add(this.startHttp);
            this.Name = "Form1";
            this.Text = "Screen Relay for TDS GTNXi";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scalingTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startHttp;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox showBezel650CheckBox;
        private System.Windows.Forms.CheckBox hideWindowFrame750CheckBox;
        private System.Windows.Forms.CheckBox hideWindowFrame650CheckBox;
        private System.Windows.Forms.CheckBox showBezel750CheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar scalingTrackBar;
        private System.Windows.Forms.Label scalingTrackbarLabel;
        private System.Windows.Forms.TextBox refreshIntervalTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

