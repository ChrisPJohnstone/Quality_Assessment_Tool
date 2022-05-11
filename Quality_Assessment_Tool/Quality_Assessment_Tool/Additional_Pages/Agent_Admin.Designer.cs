namespace Quality_Assessment_Tool
{
    partial class Agent_Admin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.AreaSelectComboBox = new System.Windows.Forms.ComboBox();
            this.AreaSelectLabel = new System.Windows.Forms.Label();
            this.SignOffAssessment = new System.Windows.Forms.Button();
            this.ChangesByComboBox = new System.Windows.Forms.ComboBox();
            this.ChangesByLabel = new System.Windows.Forms.Label();
            this.AdminTable = new System.Windows.Forms.DataGridView();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdminTable)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Navy;
            this.HeaderPanel.Controls.Add(this.AreaSelectComboBox);
            this.HeaderPanel.Controls.Add(this.AreaSelectLabel);
            this.HeaderPanel.Controls.Add(this.SignOffAssessment);
            this.HeaderPanel.Controls.Add(this.ChangesByComboBox);
            this.HeaderPanel.Controls.Add(this.ChangesByLabel);
            this.HeaderPanel.Location = new System.Drawing.Point(-3, -2);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(987, 82);
            this.HeaderPanel.TabIndex = 4;
            // 
            // AreaSelectComboBox
            // 
            this.AreaSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AreaSelectComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AreaSelectComboBox.FormattingEnabled = true;
            this.AreaSelectComboBox.Location = new System.Drawing.Point(196, 44);
            this.AreaSelectComboBox.Name = "AreaSelectComboBox";
            this.AreaSelectComboBox.Size = new System.Drawing.Size(180, 24);
            this.AreaSelectComboBox.TabIndex = 24;
            this.AreaSelectComboBox.SelectedValueChanged += new System.EventHandler(this.AreaSelectComboBox_SelectedValueChanged);
            // 
            // AreaSelectLabel
            // 
            this.AreaSelectLabel.BackColor = System.Drawing.Color.White;
            this.AreaSelectLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AreaSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AreaSelectLabel.Location = new System.Drawing.Point(196, 10);
            this.AreaSelectLabel.Name = "AreaSelectLabel";
            this.AreaSelectLabel.Size = new System.Drawing.Size(180, 24);
            this.AreaSelectLabel.TabIndex = 23;
            this.AreaSelectLabel.Text = "Area";
            this.AreaSelectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SignOffAssessment
            // 
            this.SignOffAssessment.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SignOffAssessment.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.SignOffAssessment.Location = new System.Drawing.Point(733, 10);
            this.SignOffAssessment.Name = "SignOffAssessment";
            this.SignOffAssessment.Size = new System.Drawing.Size(242, 58);
            this.SignOffAssessment.TabIndex = 22;
            this.SignOffAssessment.Text = "Sign Off";
            this.SignOffAssessment.UseVisualStyleBackColor = true;
            // 
            // ChangesByComboBox
            // 
            this.ChangesByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChangesByComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangesByComboBox.FormattingEnabled = true;
            this.ChangesByComboBox.Location = new System.Drawing.Point(10, 44);
            this.ChangesByComboBox.Name = "ChangesByComboBox";
            this.ChangesByComboBox.Size = new System.Drawing.Size(180, 24);
            this.ChangesByComboBox.TabIndex = 21;
            // 
            // ChangesByLabel
            // 
            this.ChangesByLabel.BackColor = System.Drawing.Color.White;
            this.ChangesByLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChangesByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ChangesByLabel.Location = new System.Drawing.Point(10, 10);
            this.ChangesByLabel.Name = "ChangesByLabel";
            this.ChangesByLabel.Size = new System.Drawing.Size(180, 24);
            this.ChangesByLabel.TabIndex = 20;
            this.ChangesByLabel.Text = "Changes By";
            this.ChangesByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AdminTable
            // 
            this.AdminTable.AllowUserToAddRows = false;
            this.AdminTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdminTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AdminTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AdminTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.AdminTable.Location = new System.Drawing.Point(11, 90);
            this.AdminTable.Name = "AdminTable";
            this.AdminTable.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AdminTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AdminTable.RowHeadersVisible = false;
            this.AdminTable.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AdminTable.Size = new System.Drawing.Size(961, 360);
            this.AdminTable.TabIndex = 5;
            this.AdminTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdminTable_CellValueChanged);
            // 
            // Agent_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.AdminTable);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agent_Admin";
            this.Text = "Agent_Admin";
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdminTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button SignOffAssessment;
        private System.Windows.Forms.ComboBox ChangesByComboBox;
        private System.Windows.Forms.Label ChangesByLabel;
        private System.Windows.Forms.DataGridView AdminTable;
        private System.Windows.Forms.ComboBox AreaSelectComboBox;
        private System.Windows.Forms.Label AreaSelectLabel;
    }
}