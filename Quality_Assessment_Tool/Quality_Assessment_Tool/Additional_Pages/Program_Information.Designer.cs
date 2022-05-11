namespace Quality_Assessment_Tool
{
    partial class Program_Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Program_Information));
            this.AXALogo = new System.Windows.Forms.Panel();
            this.DetailLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AXALogo
            // 
            this.AXALogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AXALogo.BackgroundImage")));
            this.AXALogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AXALogo.Location = new System.Drawing.Point(0, 0);
            this.AXALogo.Name = "AXALogo";
            this.AXALogo.Size = new System.Drawing.Size(217, 214);
            this.AXALogo.TabIndex = 1;
            // 
            // DetailLabel
            // 
            this.DetailLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DetailLabel.Location = new System.Drawing.Point(223, 9);
            this.DetailLabel.Name = "DetailLabel";
            this.DetailLabel.Size = new System.Drawing.Size(193, 194);
            this.DetailLabel.TabIndex = 2;
            this.DetailLabel.Text = resources.GetString("DetailLabel.Text");
            this.DetailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Program_Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(423, 212);
            this.Controls.Add(this.DetailLabel);
            this.Controls.Add(this.AXALogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Program_Information";
            this.Text = "Program_Information";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AXALogo;
        private System.Windows.Forms.Label DetailLabel;
    }
}