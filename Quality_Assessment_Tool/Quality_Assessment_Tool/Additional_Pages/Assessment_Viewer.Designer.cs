namespace Quality_Assessment_Tool
{
    partial class Assessment_Sign_Off
    {
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
        private void InitializeComponent()
        {
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.AssessmentAreaComboBox = new Quality_Assessment_Tool.MultiSelectComboBox();
            this.AssessmentAreaLabel = new System.Windows.Forms.Label();
            this.AssessmentEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AssessmentEndDateLabel = new System.Windows.Forms.Label();
            this.AssessmentStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AssessmentStartDateLabel = new System.Windows.Forms.Label();
            this.SignOffAssessment = new System.Windows.Forms.Button();
            this.AssessmentForComboBox = new System.Windows.Forms.ComboBox();
            this.AssessmentForLabel = new System.Windows.Forms.Label();
            this.AssessmentTable = new System.Windows.Forms.DataGridView();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssessmentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Navy;
            this.HeaderPanel.Controls.Add(this.AssessmentAreaComboBox);
            this.HeaderPanel.Controls.Add(this.AssessmentAreaLabel);
            this.HeaderPanel.Controls.Add(this.AssessmentEndDatePicker);
            this.HeaderPanel.Controls.Add(this.AssessmentEndDateLabel);
            this.HeaderPanel.Controls.Add(this.AssessmentStartDatePicker);
            this.HeaderPanel.Controls.Add(this.AssessmentStartDateLabel);
            this.HeaderPanel.Controls.Add(this.SignOffAssessment);
            this.HeaderPanel.Controls.Add(this.AssessmentForComboBox);
            this.HeaderPanel.Controls.Add(this.AssessmentForLabel);
            this.HeaderPanel.Location = new System.Drawing.Point(-3, -2);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(990, 82);
            this.HeaderPanel.TabIndex = 3;
            // 
            // AssessmentAreaComboBox
            // 
            this.AssessmentAreaComboBox.CheckOnClick = true;
            this.AssessmentAreaComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.AssessmentAreaComboBox.DropDownHeight = 1;
            this.AssessmentAreaComboBox.DropDownWidth = 300;
            this.AssessmentAreaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentAreaComboBox.FormattingEnabled = true;
            this.AssessmentAreaComboBox.IntegralHeight = false;
            this.AssessmentAreaComboBox.Location = new System.Drawing.Point(15, 44);
            this.AssessmentAreaComboBox.Name = "AssessmentAreaComboBox";
            this.AssessmentAreaComboBox.Size = new System.Drawing.Size(180, 24);
            this.AssessmentAreaComboBox.TabIndex = 32;
            this.AssessmentAreaComboBox.ValueSeparator = ", ";
            this.AssessmentAreaComboBox.DropDownClosed += new System.EventHandler(this.AssessmentAreaComboBox_DropDownClosed);
            // 
            // AssessmentAreaLabel
            // 
            this.AssessmentAreaLabel.BackColor = System.Drawing.Color.White;
            this.AssessmentAreaLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentAreaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentAreaLabel.Location = new System.Drawing.Point(15, 10);
            this.AssessmentAreaLabel.Name = "AssessmentAreaLabel";
            this.AssessmentAreaLabel.Size = new System.Drawing.Size(180, 24);
            this.AssessmentAreaLabel.TabIndex = 31;
            this.AssessmentAreaLabel.Text = "Assessment Area";
            this.AssessmentAreaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssessmentEndDatePicker
            // 
            this.AssessmentEndDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentEndDatePicker.CustomFormat = "dd MMMM yyyy";
            this.AssessmentEndDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentEndDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AssessmentEndDatePicker.Location = new System.Drawing.Point(573, 44);
            this.AssessmentEndDatePicker.MaxDate = new System.DateTime(2022, 2, 2, 0, 0, 0, 0);
            this.AssessmentEndDatePicker.Name = "AssessmentEndDatePicker";
            this.AssessmentEndDatePicker.Size = new System.Drawing.Size(180, 23);
            this.AssessmentEndDatePicker.TabIndex = 30;
            this.AssessmentEndDatePicker.Value = new System.DateTime(2022, 2, 2, 0, 0, 0, 0);
            this.AssessmentEndDatePicker.ValueChanged += new System.EventHandler(this.AssessmentEndDatePicker_ValueChanged);
            // 
            // AssessmentEndDateLabel
            // 
            this.AssessmentEndDateLabel.BackColor = System.Drawing.Color.White;
            this.AssessmentEndDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentEndDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentEndDateLabel.Location = new System.Drawing.Point(573, 10);
            this.AssessmentEndDateLabel.Name = "AssessmentEndDateLabel";
            this.AssessmentEndDateLabel.Size = new System.Drawing.Size(180, 24);
            this.AssessmentEndDateLabel.TabIndex = 29;
            this.AssessmentEndDateLabel.Text = "End Date";
            this.AssessmentEndDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssessmentStartDatePicker
            // 
            this.AssessmentStartDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentStartDatePicker.CustomFormat = "dd MMMM yyyy";
            this.AssessmentStartDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentStartDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AssessmentStartDatePicker.Location = new System.Drawing.Point(387, 44);
            this.AssessmentStartDatePicker.MaxDate = new System.DateTime(2022, 2, 2, 0, 0, 0, 0);
            this.AssessmentStartDatePicker.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.AssessmentStartDatePicker.Name = "AssessmentStartDatePicker";
            this.AssessmentStartDatePicker.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AssessmentStartDatePicker.Size = new System.Drawing.Size(180, 23);
            this.AssessmentStartDatePicker.TabIndex = 28;
            this.AssessmentStartDatePicker.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.AssessmentStartDatePicker.ValueChanged += new System.EventHandler(this.AssessmentStartDatePicker_ValueChanged);
            // 
            // AssessmentStartDateLabel
            // 
            this.AssessmentStartDateLabel.BackColor = System.Drawing.Color.White;
            this.AssessmentStartDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentStartDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentStartDateLabel.Location = new System.Drawing.Point(387, 10);
            this.AssessmentStartDateLabel.Name = "AssessmentStartDateLabel";
            this.AssessmentStartDateLabel.Size = new System.Drawing.Size(180, 24);
            this.AssessmentStartDateLabel.TabIndex = 27;
            this.AssessmentStartDateLabel.Text = "Start Date";
            this.AssessmentStartDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignOffAssessment
            // 
            this.SignOffAssessment.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.SignOffAssessment.Location = new System.Drawing.Point(775, 10);
            this.SignOffAssessment.Name = "SignOffAssessment";
            this.SignOffAssessment.Size = new System.Drawing.Size(200, 58);
            this.SignOffAssessment.TabIndex = 22;
            this.SignOffAssessment.Text = "Sign Off";
            this.SignOffAssessment.UseVisualStyleBackColor = true;
            this.SignOffAssessment.Click += new System.EventHandler(this.SignOffAssessment_Click);
            // 
            // AssessmentForComboBox
            // 
            this.AssessmentForComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssessmentForComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentForComboBox.FormattingEnabled = true;
            this.AssessmentForComboBox.Location = new System.Drawing.Point(201, 44);
            this.AssessmentForComboBox.Name = "AssessmentForComboBox";
            this.AssessmentForComboBox.Size = new System.Drawing.Size(180, 24);
            this.AssessmentForComboBox.TabIndex = 21;
            this.AssessmentForComboBox.SelectedValueChanged += new System.EventHandler(this.AssessmentForComboBox_SelectedValueChanged);
            // 
            // AssessmentForLabel
            // 
            this.AssessmentForLabel.BackColor = System.Drawing.Color.White;
            this.AssessmentForLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AssessmentForLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AssessmentForLabel.Location = new System.Drawing.Point(201, 10);
            this.AssessmentForLabel.Name = "AssessmentForLabel";
            this.AssessmentForLabel.Size = new System.Drawing.Size(180, 24);
            this.AssessmentForLabel.TabIndex = 20;
            this.AssessmentForLabel.Text = "Assessment For";
            this.AssessmentForLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AssessmentTable
            // 
            this.AssessmentTable.AllowUserToAddRows = false;
            this.AssessmentTable.AllowUserToDeleteRows = false;
            this.AssessmentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssessmentTable.Location = new System.Drawing.Point(12, 90);
            this.AssessmentTable.Name = "AssessmentTable";
            this.AssessmentTable.ReadOnly = true;
            this.AssessmentTable.RowHeadersVisible = false;
            this.AssessmentTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AssessmentTable.Size = new System.Drawing.Size(960, 360);
            this.AssessmentTable.TabIndex = 4;
            this.AssessmentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AssessmentTable_CellClick);
            // 
            // Assessment_Sign_Off
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.AssessmentTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Assessment_Sign_Off";
            this.Text = "Agent_Sign_Off";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssessmentTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.ComboBox AssessmentForComboBox;
        private System.Windows.Forms.Label AssessmentForLabel;
        private System.Windows.Forms.DataGridView AssessmentTable;
        private System.Windows.Forms.Button SignOffAssessment;
        private System.Windows.Forms.DateTimePicker AssessmentEndDatePicker;
        private System.Windows.Forms.Label AssessmentEndDateLabel;
        private System.Windows.Forms.DateTimePicker AssessmentStartDatePicker;
        private System.Windows.Forms.Label AssessmentStartDateLabel;
        private System.Windows.Forms.Label AssessmentAreaLabel;
        private MultiSelectComboBox AssessmentAreaComboBox;
    }
}