namespace Quality_Assessment_Tool
{
    partial class Assessment_Form
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
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.QuestionExportButton = new System.Windows.Forms.Button();
            this.AssessorComboBox = new System.Windows.Forms.ComboBox();
            this.AssessorLabel = new System.Windows.Forms.Label();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.NotesTextBox = new System.Windows.Forms.TextBox();
            this.NotesLabel = new System.Windows.Forms.Label();
            this.OutcomeDisplay = new System.Windows.Forms.Label();
            this.OutcomeLabel = new System.Windows.Forms.Label();
            this.ScorePercentDisplay = new System.Windows.Forms.Label();
            this.ScorePercentLabel = new System.Windows.Forms.Label();
            this.MaxScoreDisplay = new System.Windows.Forms.Label();
            this.MaxScoreLabel = new System.Windows.Forms.Label();
            this.ScoreDisplay = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.HeaderPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Navy;
            this.HeaderPanel.Controls.Add(this.QuestionExportButton);
            this.HeaderPanel.Controls.Add(this.AssessorComboBox);
            this.HeaderPanel.Controls.Add(this.AssessorLabel);
            this.HeaderPanel.Location = new System.Drawing.Point(-3, -2);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(955, 79);
            this.HeaderPanel.TabIndex = 2;
            // 
            // QuestionExportButton
            // 
            this.QuestionExportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.QuestionExportButton.Location = new System.Drawing.Point(617, 10);
            this.QuestionExportButton.Name = "QuestionExportButton";
            this.QuestionExportButton.Size = new System.Drawing.Size(325, 58);
            this.QuestionExportButton.TabIndex = 22;
            this.QuestionExportButton.Text = "Export Questions";
            this.QuestionExportButton.UseVisualStyleBackColor = true;
            this.QuestionExportButton.Click += new System.EventHandler(this.QuestionExportButton_Click);
            // 
            // AssessorComboBox
            // 
            this.AssessorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssessorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessorComboBox.FormattingEnabled = true;
            this.AssessorComboBox.Location = new System.Drawing.Point(10, 44);
            this.AssessorComboBox.Name = "AssessorComboBox";
            this.AssessorComboBox.Size = new System.Drawing.Size(180, 24);
            this.AssessorComboBox.TabIndex = 21;
            // 
            // AssessorLabel
            // 
            this.AssessorLabel.BackColor = System.Drawing.Color.White;
            this.AssessorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessorLabel.Location = new System.Drawing.Point(10, 10);
            this.AssessorLabel.Name = "AssessorLabel";
            this.AssessorLabel.Size = new System.Drawing.Size(180, 24);
            this.AssessorLabel.TabIndex = 20;
            this.AssessorLabel.Text = "Assessor";
            this.AssessorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RightPanel
            // 
            this.RightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RightPanel.Controls.Add(this.NotesTextBox);
            this.RightPanel.Controls.Add(this.NotesLabel);
            this.RightPanel.Controls.Add(this.OutcomeDisplay);
            this.RightPanel.Controls.Add(this.OutcomeLabel);
            this.RightPanel.Controls.Add(this.ScorePercentDisplay);
            this.RightPanel.Controls.Add(this.ScorePercentLabel);
            this.RightPanel.Controls.Add(this.MaxScoreDisplay);
            this.RightPanel.Controls.Add(this.MaxScoreLabel);
            this.RightPanel.Controls.Add(this.ScoreDisplay);
            this.RightPanel.Controls.Add(this.ScoreLabel);
            this.RightPanel.Location = new System.Drawing.Point(752, 75);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(200, 661);
            this.RightPanel.TabIndex = 4;
            // 
            // NotesTextBox
            // 
            this.NotesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NotesTextBox.Location = new System.Drawing.Point(10, 420);
            this.NotesTextBox.Multiline = true;
            this.NotesTextBox.Name = "NotesTextBox";
            this.NotesTextBox.Size = new System.Drawing.Size(180, 224);
            this.NotesTextBox.TabIndex = 21;
            // 
            // NotesLabel
            // 
            this.NotesLabel.BackColor = System.Drawing.Color.White;
            this.NotesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NotesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NotesLabel.Location = new System.Drawing.Point(10, 386);
            this.NotesLabel.Name = "NotesLabel";
            this.NotesLabel.Size = new System.Drawing.Size(180, 24);
            this.NotesLabel.TabIndex = 20;
            this.NotesLabel.Text = "Interaction Notes";
            this.NotesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutcomeDisplay
            // 
            this.OutcomeDisplay.BackColor = System.Drawing.Color.White;
            this.OutcomeDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutcomeDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.OutcomeDisplay.Location = new System.Drawing.Point(10, 326);
            this.OutcomeDisplay.Name = "OutcomeDisplay";
            this.OutcomeDisplay.Size = new System.Drawing.Size(180, 50);
            this.OutcomeDisplay.TabIndex = 19;
            this.OutcomeDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutcomeLabel
            // 
            this.OutcomeLabel.BackColor = System.Drawing.Color.White;
            this.OutcomeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.OutcomeLabel.Location = new System.Drawing.Point(10, 292);
            this.OutcomeLabel.Name = "OutcomeLabel";
            this.OutcomeLabel.Size = new System.Drawing.Size(180, 24);
            this.OutcomeLabel.TabIndex = 18;
            this.OutcomeLabel.Text = "Outcome";
            this.OutcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScorePercentDisplay
            // 
            this.ScorePercentDisplay.BackColor = System.Drawing.Color.White;
            this.ScorePercentDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScorePercentDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.ScorePercentDisplay.Location = new System.Drawing.Point(10, 232);
            this.ScorePercentDisplay.Name = "ScorePercentDisplay";
            this.ScorePercentDisplay.Size = new System.Drawing.Size(180, 50);
            this.ScorePercentDisplay.TabIndex = 17;
            this.ScorePercentDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScorePercentLabel
            // 
            this.ScorePercentLabel.BackColor = System.Drawing.Color.White;
            this.ScorePercentLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScorePercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ScorePercentLabel.Location = new System.Drawing.Point(10, 198);
            this.ScorePercentLabel.Name = "ScorePercentLabel";
            this.ScorePercentLabel.Size = new System.Drawing.Size(180, 24);
            this.ScorePercentLabel.TabIndex = 16;
            this.ScorePercentLabel.Text = "Score (Percentage)";
            this.ScorePercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaxScoreDisplay
            // 
            this.MaxScoreDisplay.BackColor = System.Drawing.Color.White;
            this.MaxScoreDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaxScoreDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.MaxScoreDisplay.Location = new System.Drawing.Point(10, 138);
            this.MaxScoreDisplay.Name = "MaxScoreDisplay";
            this.MaxScoreDisplay.Size = new System.Drawing.Size(180, 50);
            this.MaxScoreDisplay.TabIndex = 15;
            this.MaxScoreDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaxScoreLabel
            // 
            this.MaxScoreLabel.BackColor = System.Drawing.Color.White;
            this.MaxScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MaxScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MaxScoreLabel.Location = new System.Drawing.Point(10, 104);
            this.MaxScoreLabel.Name = "MaxScoreLabel";
            this.MaxScoreLabel.Size = new System.Drawing.Size(180, 24);
            this.MaxScoreLabel.TabIndex = 14;
            this.MaxScoreLabel.Text = "Potential Score";
            this.MaxScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreDisplay
            // 
            this.ScoreDisplay.BackColor = System.Drawing.Color.White;
            this.ScoreDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScoreDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.ScoreDisplay.Location = new System.Drawing.Point(10, 44);
            this.ScoreDisplay.Name = "ScoreDisplay";
            this.ScoreDisplay.Size = new System.Drawing.Size(180, 50);
            this.ScoreDisplay.TabIndex = 13;
            this.ScoreDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.BackColor = System.Drawing.Color.White;
            this.ScoreLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ScoreLabel.Location = new System.Drawing.Point(10, 10);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(180, 24);
            this.ScoreLabel.TabIndex = 12;
            this.ScoreLabel.Text = "Score (Value)";
            this.ScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Location = new System.Drawing.Point(12, 83);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(734, 636);
            this.mainTabControl.TabIndex = 5;
            // 
            // Assessment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(950, 728);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.RightPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Assessment_Form";
            this.Text = "Assessment_Form";
            this.HeaderPanel.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label ScorePercentDisplay;
        private System.Windows.Forms.Label ScorePercentLabel;
        private System.Windows.Forms.Label MaxScoreDisplay;
        private System.Windows.Forms.Label MaxScoreLabel;
        private System.Windows.Forms.Label ScoreDisplay;
        private System.Windows.Forms.Label OutcomeDisplay;
        private System.Windows.Forms.Label OutcomeLabel;
        private System.Windows.Forms.Label AssessorLabel;
        private System.Windows.Forms.ComboBox AssessorComboBox;
        private System.Windows.Forms.TextBox NotesTextBox;
        private System.Windows.Forms.Label NotesLabel;
        private System.Windows.Forms.Button QuestionExportButton;
    }
}