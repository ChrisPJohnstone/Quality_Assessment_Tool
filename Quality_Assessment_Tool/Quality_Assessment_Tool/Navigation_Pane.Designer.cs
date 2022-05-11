namespace Quality_Assessment_Tool
{
    public partial class Navigation_Pane
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Navigation_Pane));
            this.TopLeftLogo = new System.Windows.Forms.Panel();
            this.Header = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOffQualityChecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchCallMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitCSRCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToQualityReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopRightLogo = new System.Windows.Forms.Panel();
            this.NavigateToScoring = new System.Windows.Forms.Button();
            this.AssessmentAreaComboBox = new System.Windows.Forms.ComboBox();
            this.AssessmentAreaLabel = new System.Windows.Forms.Label();
            this.QuestionSetLabel = new System.Windows.Forms.Label();
            this.QuestionSetComboBox = new System.Windows.Forms.ComboBox();
            this.AssessmentTypeLabel = new System.Windows.Forms.Label();
            this.AssessmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Score = new System.Windows.Forms.TabPage();
            this.Review = new System.Windows.Forms.TabPage();
            this.AssessmentByLabel = new System.Windows.Forms.Label();
            this.AssessmentByComboBox = new System.Windows.Forms.ComboBox();
            this.NavigateToReview = new System.Windows.Forms.Button();
            this.ReferenceTextBox = new System.Windows.Forms.TextBox();
            this.ReferenceLabel = new System.Windows.Forms.Label();
            this.userAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.Score.SuspendLayout();
            this.Review.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopLeftLogo
            // 
            this.TopLeftLogo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TopLeftLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TopLeftLogo.BackgroundImage")));
            this.TopLeftLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TopLeftLogo.Location = new System.Drawing.Point(0, 24);
            this.TopLeftLogo.Name = "TopLeftLogo";
            this.TopLeftLogo.Size = new System.Drawing.Size(105, 105);
            this.TopLeftLogo.TabIndex = 0;
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.White;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Header.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Header.Location = new System.Drawing.Point(99, 24);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(170, 105);
            this.Header.TabIndex = 2;
            this.Header.Text = "Quality Assessment Tool";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripToolStripMenuItem,
            this.managerOptionsToolStripMenuItem,
            this.adminOptionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(366, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // toolStripToolStripMenuItem
            // 
            this.toolStripToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signOffQualityChecksToolStripMenuItem});
            this.toolStripToolStripMenuItem.Name = "toolStripToolStripMenuItem";
            this.toolStripToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.toolStripToolStripMenuItem.Text = "Agent Options";
            // 
            // signOffQualityChecksToolStripMenuItem
            // 
            this.signOffQualityChecksToolStripMenuItem.Name = "signOffQualityChecksToolStripMenuItem";
            this.signOffQualityChecksToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.signOffQualityChecksToolStripMenuItem.Text = "Sign Off Quality Checks";
            this.signOffQualityChecksToolStripMenuItem.Click += new System.EventHandler(this.signOffQualityChecksToolStripMenuItem_Click);
            // 
            // managerOptionsToolStripMenuItem
            // 
            this.managerOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchCallMenuItem,
            this.submitCSRCommentToolStripMenuItem,
            this.goToQualityReportsToolStripMenuItem});
            this.managerOptionsToolStripMenuItem.Name = "managerOptionsToolStripMenuItem";
            this.managerOptionsToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.managerOptionsToolStripMenuItem.Text = "Manager Options";
            // 
            // searchCallMenuItem
            // 
            this.searchCallMenuItem.Name = "searchCallMenuItem";
            this.searchCallMenuItem.Size = new System.Drawing.Size(193, 22);
            this.searchCallMenuItem.Text = "Search Call";
            this.searchCallMenuItem.Click += new System.EventHandler(this.searchCallMenuItem_Click);
            // 
            // submitCSRCommentToolStripMenuItem
            // 
            this.submitCSRCommentToolStripMenuItem.Name = "submitCSRCommentToolStripMenuItem";
            this.submitCSRCommentToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.submitCSRCommentToolStripMenuItem.Text = "Submit CSR Comment";
            this.submitCSRCommentToolStripMenuItem.Click += new System.EventHandler(this.submitCSRCommentToolStripMenuItem_Click);
            // 
            // goToQualityReportsToolStripMenuItem
            // 
            this.goToQualityReportsToolStripMenuItem.Name = "goToQualityReportsToolStripMenuItem";
            this.goToQualityReportsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.goToQualityReportsToolStripMenuItem.Text = "Go To Quality Reports";
            this.goToQualityReportsToolStripMenuItem.Click += new System.EventHandler(this.goToQualityReportsToolStripMenuItem_Click);
            // 
            // adminOptionsToolStripMenuItem
            // 
            this.adminOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userAdminToolStripMenuItem});
            this.adminOptionsToolStripMenuItem.Name = "adminOptionsToolStripMenuItem";
            this.adminOptionsToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.adminOptionsToolStripMenuItem.Text = "Admin Options";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // TopRightLogo
            // 
            this.TopRightLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TopRightLogo.BackgroundImage")));
            this.TopRightLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TopRightLogo.Location = new System.Drawing.Point(263, 24);
            this.TopRightLogo.Name = "TopRightLogo";
            this.TopRightLogo.Size = new System.Drawing.Size(105, 105);
            this.TopRightLogo.TabIndex = 1;
            // 
            // NavigateToScoring
            // 
            this.NavigateToScoring.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.NavigateToScoring.Location = new System.Drawing.Point(3, 96);
            this.NavigateToScoring.Name = "NavigateToScoring";
            this.NavigateToScoring.Size = new System.Drawing.Size(325, 50);
            this.NavigateToScoring.TabIndex = 4;
            this.NavigateToScoring.Text = "Open Scoring";
            this.NavigateToScoring.UseVisualStyleBackColor = true;
            this.NavigateToScoring.Click += new System.EventHandler(this.NavigateToScoring_Click);
            // 
            // AssessmentAreaComboBox
            // 
            this.AssessmentAreaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssessmentAreaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentAreaComboBox.FormattingEnabled = true;
            this.AssessmentAreaComboBox.Location = new System.Drawing.Point(168, 6);
            this.AssessmentAreaComboBox.Name = "AssessmentAreaComboBox";
            this.AssessmentAreaComboBox.Size = new System.Drawing.Size(160, 24);
            this.AssessmentAreaComboBox.TabIndex = 1;
            this.AssessmentAreaComboBox.SelectedValueChanged += new System.EventHandler(this.AssessmentAreaComboBox_SelectedValueChanged);
            // 
            // AssessmentAreaLabel
            // 
            this.AssessmentAreaLabel.BackColor = System.Drawing.Color.White;
            this.AssessmentAreaLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentAreaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentAreaLabel.Location = new System.Drawing.Point(3, 6);
            this.AssessmentAreaLabel.Name = "AssessmentAreaLabel";
            this.AssessmentAreaLabel.Size = new System.Drawing.Size(160, 24);
            this.AssessmentAreaLabel.TabIndex = 8;
            this.AssessmentAreaLabel.Text = "Assessment Area";
            this.AssessmentAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuestionSetLabel
            // 
            this.QuestionSetLabel.BackColor = System.Drawing.Color.White;
            this.QuestionSetLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QuestionSetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.QuestionSetLabel.Location = new System.Drawing.Point(3, 36);
            this.QuestionSetLabel.Name = "QuestionSetLabel";
            this.QuestionSetLabel.Size = new System.Drawing.Size(160, 24);
            this.QuestionSetLabel.TabIndex = 9;
            this.QuestionSetLabel.Text = "Question Set";
            this.QuestionSetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuestionSetComboBox
            // 
            this.QuestionSetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QuestionSetComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.QuestionSetComboBox.FormattingEnabled = true;
            this.QuestionSetComboBox.Location = new System.Drawing.Point(168, 36);
            this.QuestionSetComboBox.Name = "QuestionSetComboBox";
            this.QuestionSetComboBox.Size = new System.Drawing.Size(160, 24);
            this.QuestionSetComboBox.TabIndex = 2;
            this.QuestionSetComboBox.SelectedValueChanged += new System.EventHandler(this.QuestionSetComboBox_SelectedValueChanged);
            // 
            // AssessmentTypeLabel
            // 
            this.AssessmentTypeLabel.BackColor = System.Drawing.Color.White;
            this.AssessmentTypeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentTypeLabel.Location = new System.Drawing.Point(3, 66);
            this.AssessmentTypeLabel.Name = "AssessmentTypeLabel";
            this.AssessmentTypeLabel.Size = new System.Drawing.Size(160, 24);
            this.AssessmentTypeLabel.TabIndex = 10;
            this.AssessmentTypeLabel.Text = "Assessment Type";
            this.AssessmentTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssessmentTypeComboBox
            // 
            this.AssessmentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssessmentTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentTypeComboBox.FormattingEnabled = true;
            this.AssessmentTypeComboBox.Location = new System.Drawing.Point(168, 66);
            this.AssessmentTypeComboBox.Name = "AssessmentTypeComboBox";
            this.AssessmentTypeComboBox.Size = new System.Drawing.Size(160, 24);
            this.AssessmentTypeComboBox.TabIndex = 3;
            this.AssessmentTypeComboBox.SelectedValueChanged += new System.EventHandler(this.AssessmentTypeComboBox_SelectedValueChanged);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Score);
            this.TabControl.Controls.Add(this.Review);
            this.TabControl.Location = new System.Drawing.Point(12, 138);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(342, 179);
            this.TabControl.TabIndex = 12;
            // 
            // Score
            // 
            this.Score.BackColor = System.Drawing.Color.Transparent;
            this.Score.Controls.Add(this.AssessmentAreaComboBox);
            this.Score.Controls.Add(this.NavigateToScoring);
            this.Score.Controls.Add(this.QuestionSetComboBox);
            this.Score.Controls.Add(this.AssessmentTypeLabel);
            this.Score.Controls.Add(this.QuestionSetLabel);
            this.Score.Controls.Add(this.AssessmentAreaLabel);
            this.Score.Controls.Add(this.AssessmentTypeComboBox);
            this.Score.Location = new System.Drawing.Point(4, 22);
            this.Score.Name = "Score";
            this.Score.Padding = new System.Windows.Forms.Padding(3);
            this.Score.Size = new System.Drawing.Size(334, 153);
            this.Score.TabIndex = 0;
            this.Score.Text = "Score";
            // 
            // Review
            // 
            this.Review.BackColor = System.Drawing.Color.Transparent;
            this.Review.Controls.Add(this.AssessmentByLabel);
            this.Review.Controls.Add(this.AssessmentByComboBox);
            this.Review.Controls.Add(this.NavigateToReview);
            this.Review.Controls.Add(this.ReferenceTextBox);
            this.Review.Controls.Add(this.ReferenceLabel);
            this.Review.Location = new System.Drawing.Point(4, 22);
            this.Review.Name = "Review";
            this.Review.Padding = new System.Windows.Forms.Padding(3);
            this.Review.Size = new System.Drawing.Size(334, 153);
            this.Review.TabIndex = 1;
            this.Review.Text = "Review";
            // 
            // AssessmentByLabel
            // 
            this.AssessmentByLabel.BackColor = System.Drawing.Color.White;
            this.AssessmentByLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentByLabel.Location = new System.Drawing.Point(3, 65);
            this.AssessmentByLabel.Name = "AssessmentByLabel";
            this.AssessmentByLabel.Size = new System.Drawing.Size(160, 24);
            this.AssessmentByLabel.TabIndex = 12;
            this.AssessmentByLabel.Text = "Assessment By";
            this.AssessmentByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AssessmentByLabel.Visible = false;
            // 
            // AssessmentByComboBox
            // 
            this.AssessmentByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssessmentByComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentByComboBox.FormattingEnabled = true;
            this.AssessmentByComboBox.Location = new System.Drawing.Point(168, 65);
            this.AssessmentByComboBox.Name = "AssessmentByComboBox";
            this.AssessmentByComboBox.Size = new System.Drawing.Size(160, 24);
            this.AssessmentByComboBox.TabIndex = 6;
            this.AssessmentByComboBox.Visible = false;
            // 
            // NavigateToReview
            // 
            this.NavigateToReview.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.NavigateToReview.Location = new System.Drawing.Point(3, 95);
            this.NavigateToReview.Name = "NavigateToReview";
            this.NavigateToReview.Size = new System.Drawing.Size(325, 50);
            this.NavigateToReview.TabIndex = 7;
            this.NavigateToReview.Text = "Review Assessment";
            this.NavigateToReview.UseVisualStyleBackColor = true;
            this.NavigateToReview.Click += new System.EventHandler(this.NavigateToReview_Click);
            // 
            // ReferenceTextBox
            // 
            this.ReferenceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ReferenceTextBox.Location = new System.Drawing.Point(3, 36);
            this.ReferenceTextBox.Name = "ReferenceTextBox";
            this.ReferenceTextBox.Size = new System.Drawing.Size(325, 23);
            this.ReferenceTextBox.TabIndex = 5;
            this.ReferenceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReferenceTextBox.TextChanged += new System.EventHandler(this.ReferenceTextBox_TextChanged);
            // 
            // ReferenceLabel
            // 
            this.ReferenceLabel.BackColor = System.Drawing.Color.White;
            this.ReferenceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReferenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ReferenceLabel.Location = new System.Drawing.Point(3, 6);
            this.ReferenceLabel.Name = "ReferenceLabel";
            this.ReferenceLabel.Size = new System.Drawing.Size(325, 24);
            this.ReferenceLabel.TabIndex = 11;
            this.ReferenceLabel.Text = "Reference";
            this.ReferenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userAdminToolStripMenuItem
            // 
            this.userAdminToolStripMenuItem.Name = "userAdminToolStripMenuItem";
            this.userAdminToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.userAdminToolStripMenuItem.Text = "User Admin";
            this.userAdminToolStripMenuItem.Click += new System.EventHandler(this.userAdminToolStripMenuItem_Click);
            // 
            // Navigation_Pane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(366, 325);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.TopRightLogo);
            this.Controls.Add(this.TopLeftLogo);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Navigation_Pane";
            this.Text = "Call_Quality_Tool";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.Score.ResumeLayout(false);
            this.Review.ResumeLayout(false);
            this.Review.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopLeftLogo;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOffQualityChecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToQualityReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel TopRightLogo;
        private System.Windows.Forms.Button NavigateToScoring;
        private System.Windows.Forms.ComboBox AssessmentAreaComboBox;
        private System.Windows.Forms.Label AssessmentAreaLabel;
        private System.Windows.Forms.Label QuestionSetLabel;
        private System.Windows.Forms.ComboBox QuestionSetComboBox;
        private System.Windows.Forms.Label AssessmentTypeLabel;
        private System.Windows.Forms.ComboBox AssessmentTypeComboBox;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Score;
        private System.Windows.Forms.TabPage Review;
        private System.Windows.Forms.Button NavigateToReview;
        private System.Windows.Forms.TextBox ReferenceTextBox;
        private System.Windows.Forms.Label ReferenceLabel;
        private System.Windows.Forms.Label AssessmentByLabel;
        private System.Windows.Forms.ComboBox AssessmentByComboBox;
        private System.Windows.Forms.ToolStripMenuItem submitCSRCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchCallMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userAdminToolStripMenuItem;
    }
}

