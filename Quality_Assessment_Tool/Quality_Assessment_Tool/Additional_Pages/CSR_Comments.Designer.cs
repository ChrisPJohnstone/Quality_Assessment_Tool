namespace Quality_Assessment_Tool
{
    partial class CSR_Comments
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
            this.commentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.CommentDateLabel = new System.Windows.Forms.Label();
            this.CommentForComboBox = new System.Windows.Forms.ComboBox();
            this.CommentForLabel = new System.Windows.Forms.Label();
            this.CommentSubmitButton = new System.Windows.Forms.Button();
            this.AssessorComboBox = new System.Windows.Forms.ComboBox();
            this.AssessorLabel = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Navy;
            this.HeaderPanel.Controls.Add(this.commentDatePicker);
            this.HeaderPanel.Controls.Add(this.CommentDateLabel);
            this.HeaderPanel.Controls.Add(this.CommentForComboBox);
            this.HeaderPanel.Controls.Add(this.CommentForLabel);
            this.HeaderPanel.Controls.Add(this.CommentSubmitButton);
            this.HeaderPanel.Controls.Add(this.AssessorComboBox);
            this.HeaderPanel.Controls.Add(this.AssessorLabel);
            this.HeaderPanel.Location = new System.Drawing.Point(-3, -2);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(735, 79);
            this.HeaderPanel.TabIndex = 3;
            // 
            // commentDatePicker
            // 
            this.commentDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.commentDatePicker.CustomFormat = "MMMM yyyy";
            this.commentDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.commentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.commentDatePicker.Location = new System.Drawing.Point(382, 44);
            this.commentDatePicker.Name = "commentDatePicker";
            this.commentDatePicker.Size = new System.Drawing.Size(180, 23);
            this.commentDatePicker.TabIndex = 26;
            this.commentDatePicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // CommentDateLabel
            // 
            this.CommentDateLabel.BackColor = System.Drawing.Color.White;
            this.CommentDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommentDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CommentDateLabel.Location = new System.Drawing.Point(382, 10);
            this.CommentDateLabel.Name = "CommentDateLabel";
            this.CommentDateLabel.Size = new System.Drawing.Size(180, 24);
            this.CommentDateLabel.TabIndex = 25;
            this.CommentDateLabel.Text = "Comment Date";
            this.CommentDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommentForComboBox
            // 
            this.CommentForComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommentForComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CommentForComboBox.FormattingEnabled = true;
            this.CommentForComboBox.Location = new System.Drawing.Point(196, 44);
            this.CommentForComboBox.Name = "CommentForComboBox";
            this.CommentForComboBox.Size = new System.Drawing.Size(180, 24);
            this.CommentForComboBox.TabIndex = 24;
            this.CommentForComboBox.SelectedValueChanged += new System.EventHandler(this.CommentForComboBox_SelectedValueChanged);
            // 
            // CommentForLabel
            // 
            this.CommentForLabel.BackColor = System.Drawing.Color.White;
            this.CommentForLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CommentForLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CommentForLabel.Location = new System.Drawing.Point(196, 10);
            this.CommentForLabel.Name = "CommentForLabel";
            this.CommentForLabel.Size = new System.Drawing.Size(180, 24);
            this.CommentForLabel.TabIndex = 23;
            this.CommentForLabel.Text = "Comment For";
            this.CommentForLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommentSubmitButton
            // 
            this.CommentSubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.CommentSubmitButton.Location = new System.Drawing.Point(568, 10);
            this.CommentSubmitButton.Name = "CommentSubmitButton";
            this.CommentSubmitButton.Size = new System.Drawing.Size(157, 58);
            this.CommentSubmitButton.TabIndex = 22;
            this.CommentSubmitButton.Text = "Submit\r\nComment";
            this.CommentSubmitButton.UseVisualStyleBackColor = true;
            this.CommentSubmitButton.Click += new System.EventHandler(this.CommentSubmitButton_Click);
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
            this.AssessorComboBox.SelectedValueChanged += new System.EventHandler(this.AssessorComboBox_SelectedValueChanged);
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
            // CommentTextBox
            // 
            this.CommentTextBox.Enabled = false;
            this.CommentTextBox.Location = new System.Drawing.Point(7, 83);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(715, 258);
            this.CommentTextBox.TabIndex = 4;
            // 
            // CSR_Comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(727, 348);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CSR_Comments";
            this.Text = "CSR_Comments";
            this.HeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button CommentSubmitButton;
        private System.Windows.Forms.ComboBox AssessorComboBox;
        private System.Windows.Forms.Label AssessorLabel;
        private System.Windows.Forms.Label CommentDateLabel;
        private System.Windows.Forms.ComboBox CommentForComboBox;
        private System.Windows.Forms.Label CommentForLabel;
        private System.Windows.Forms.DateTimePicker commentDatePicker;
        private System.Windows.Forms.TextBox CommentTextBox;
    }
}