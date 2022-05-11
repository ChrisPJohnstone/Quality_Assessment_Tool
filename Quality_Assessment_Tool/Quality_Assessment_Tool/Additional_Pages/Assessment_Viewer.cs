using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quality_Assessment_Tool
{
    public partial class Assessment_Sign_Off : Form
    {
        Global_Variables globalVariables = new Global_Variables();
        SQL_Interaction sql = new SQL_Interaction();
        General_Functions generalFunctions = new General_Functions();
        
        // Code When Page Launched //
        #region Code When Page Launched
        private String calledFromGlobal;

        public Assessment_Sign_Off(String calledFrom)
        {
            InitializeComponent();

            calledFromGlobal = calledFrom;

            populateAssessmentArea();

            if (!(globalVariables.userPermissionAssessor()) || calledFromGlobal == "Agent")
            {
                AssessmentStartDateLabel.Visible = false;
                AssessmentStartDatePicker.Visible = false;
                AssessmentEndDateLabel.Visible = false;
                AssessmentEndDatePicker.Visible = false;
            }
        }
        #endregion

        // Create & Populate "Assessment Area" //
        #region Populate "Assessment Area"
        private void populateAssessmentArea()
        {
            String assessmentAreaQuery =
                "SELECT DISTINCT"
                + " ROW_NUMBER() OVER(ORDER BY"
                + "     CASE"
                + "         WHEN [Ref_Assessment_Area].[Name] = 'Direct Call' THEN 1"
                + "         WHEN [Ref_Assessment_Area].[Name] = 'Direct Email' THEN 2"
                + "         WHEN [Ref_Assessment_Area].[Name] = 'Connect Call' THEN 3"
                + "         ELSE 50"
                + "     END ASC"
                + "     , CASE"
                + "         WHEN [Ref_Question_Set].[Name] = 'Customer Experience' THEN 1"
                + "         WHEN [Ref_Question_Set].[Name] LIKE '%Compliance%' THEN 2"
                + "         ELSE 50"
                + "     END ASC"
                + "     , [Ref_Question_Set].[Name] ASC"
                + " ) AS [ID]"
                + " , [Ref_Assessment_Area].[Name] + ' ' + [Ref_Question_Set].[Name] AS [Name]"
                + "FROM [Table].[Ref_Assessment_Area]"
                + "INNER JOIN [Table].[Ref_Question_Set]"
                + " ON [Ref_Assessment_Area].[Assessment_Area] = [Ref_Question_Set].[Assessment_Area]"
                + "WHERE"
                + " [Ref_Assessment_Area].[Active] = 1"
                + " AND [Ref_Question_Set].[Active] = 1"
                + "ORDER BY [ID] ASC";
            generalFunctions.fillMultiSelectComboBox(AssessmentAreaComboBox, assessmentAreaQuery);
        }
        #endregion

        // Populate "Assessment For" //
        #region Populate "Assessment For"
        private void populateAssessmentFor(String currentlySelected)
        {
            String assessmentForQuery =
                "SELECT DISTINCT"
                + " [Ref_User].[User] AS [ID]"
                + " , [Ref_User].[Name]"
                + "FROM [Table].[Ref_User]"
                + "INNER JOIN [Table].[Assessment]"
                + " ON [Ref_User].[User] = [Assessment].[Interaction_By]"
                + "INNER JOIN [Table].[Ref_Assessment_Area]"
                + " ON [Assessment].[Assessment_Area] = [Ref_Assessment_Area].[Assessment_Area]"
                + "INNER JOIN [Table].[Ref_Question_Set]"
                + " ON [Assessment].[Question_Set] = [Ref_Question_Set].[Question_Set]"
                + "INNER JOIN [Table].[Ref_Assessment_Type]"
                + " ON [Assessment].[Assessment_Type] = [Ref_Assessment_Type].[Assessment_Type]"
                + "WHERE"
                + " [Assessment].[Interaction_By] IS NOT NULL"
                + " AND [Ref_Assessment_Area].[Name] + ' ' + [Ref_Question_Set].[Name] IN ('" + AssessmentAreaComboBox.Text.ToString().Replace(", ", "', '") + "')";

            if (calledFromGlobal == "Agent")
            {
                assessmentForQuery = assessmentForQuery + " AND ISNULL([Ref_Assessment_Type].[Name], 'NULL') NOT LIKE '%Bench%'";
                assessmentForQuery = assessmentForQuery
                    + " AND CASE"
                    + "     WHEN [Ref_User].[User] = " + globalVariables.userID(globalVariables.userName()).ToString() + " THEN 1"
                    + "     WHEN [Ref_User].[User] = " + currentlySelected +  "THEN 1"
                    + "     WHEN ISNULL([Assessment].[Signed_Off], 0) = 0 THEN 1"
                    + "     ELSE 0"
                    + " END = 1";
            }

            assessmentForQuery = assessmentForQuery
                + "UNION "
                + "SELECT"
                + " [Ref_User].[User] AS [ID]"
                + " , [Ref_User].[Name]"
                + "FROM [Table].[Ref_User]"
                + "WHERE [Ref_User].[User] IN (" + currentlySelected + ", " + globalVariables.userID(globalVariables.userName()).ToString() + ")"
                + "ORDER BY [Ref_User].[Name] ASC";

            generalFunctions.fillComboBox(AssessmentForComboBox, assessmentForQuery);
            if (currentlySelected == "0")
            {
                AssessmentForComboBox.SelectedValue = globalVariables.userID(globalVariables.userName()).ToString();
            }
            else
            {
                AssessmentForComboBox.SelectedValue = currentlySelected;
            }

            if (!(globalVariables.userPermissionAssessor()))
            {
                AssessmentForComboBox.Enabled = false;
            }
        }
        #endregion

        // Code When Any Parameter Changes //
        #region Code When Any Parameter Changes
        private void AssessmentAreaComboBox_DropDownClosed(object sender, EventArgs e)
        {
            String passThroughUser;
            if (AssessmentForComboBox.SelectedItem == null)
            {
                passThroughUser = "0";
            }
            else
            {
                passThroughUser = ((KeyValuePair<string, string>)AssessmentForComboBox.SelectedItem).Key;
            }

            populateAssessmentFor(passThroughUser);
        }

        private void AssessmentForComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // Set min/max values to default values before setting them to "actual" value to avoid issues when switching between agents //
            AssessmentStartDatePicker.MinDate = DateTime.Parse("2022-01-01");
            AssessmentStartDatePicker.MaxDate = DateTime.Today.AddDays(1);
            AssessmentEndDatePicker.MinDate = DateTime.Parse("2022-01-01");
            AssessmentEndDatePicker.MaxDate = DateTime.Today.AddDays(1);

            String assessmentEarliestDateQuery =
                "SELECT ISNULL(MIN([Assessment].[Assessment_Date]), '2022-01-01') AS [Min_Date]"
                + "FROM [Table].[Assessment]"
                + "INNER JOIN [Table].[Ref_Assessment_Area]"
                + " ON [Assessment].[Assessment_Area] = [Ref_Assessment_Area].[Assessment_Area]"
                + "INNER JOIN [Table].[Ref_Question_Set]"
                + " ON [Assessment].[Question_Set] = [Ref_Question_Set].[Question_Set]"
                + "WHERE"
                + " [Assessment].[Interaction_By] = " + ((KeyValuePair<string, string>)AssessmentForComboBox.SelectedItem).Key
                + " AND [Ref_Assessment_Area].[Name] + ' ' + [Ref_Question_Set].[Name] IN ('" + AssessmentAreaComboBox.Text.ToString().Replace(", ", "', '") + "')";
            DateTime startDate = DateTime.Parse(sql.returnSingleString(assessmentEarliestDateQuery));
            AssessmentStartDatePicker.MinDate = startDate;
            AssessmentEndDatePicker.MinDate = startDate;
            AssessmentStartDatePicker.Value = startDate;

            String assessmentLatestDateQuery =
                "SELECT ISNULL(MAX([Assessment].[Assessment_Date]), GETDATE()) AS [Max_Date]"
                + "FROM [Table].[Assessment]"
                + "INNER JOIN [Table].[Ref_Assessment_Area]"
                + " ON [Assessment].[Assessment_Area] = [Ref_Assessment_Area].[Assessment_Area]"
                + "INNER JOIN [Table].[Ref_Question_Set]"
                + " ON [Assessment].[Question_Set] = [Ref_Question_Set].[Question_Set]"
                + "WHERE"
                + " [Assessment].[Interaction_By] = " + ((KeyValuePair<string, string>)AssessmentForComboBox.SelectedItem).Key
                + " AND [Ref_Assessment_Area].[Name] + ' ' + [Ref_Question_Set].[Name] IN ('" + AssessmentAreaComboBox.Text.ToString().Replace(", ", "', '") + "')";
            DateTime endDate = DateTime.Parse(sql.returnSingleString(assessmentLatestDateQuery));
            AssessmentStartDatePicker.MaxDate = endDate;
            AssessmentEndDatePicker.MaxDate = endDate;
            AssessmentEndDatePicker.Value = endDate;

            populateTable();
        }

        private void AssessmentStartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (AssessmentStartDatePicker.Value > AssessmentEndDatePicker.Value)
            {
                AssessmentEndDatePicker.Value = AssessmentStartDatePicker.Value;
            }

            populateTable();
        }

        private void AssessmentEndDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (AssessmentEndDatePicker.Value < AssessmentStartDatePicker.Value)
            {
                AssessmentStartDatePicker.Value = AssessmentEndDatePicker.Value;
            }

            populateTable();
        }
        #endregion

        // Code For Populating Table //
        #region Code For Populating Table
        private void populateTable()
        {
            DataColumn assessmentColumn = new DataColumn();
            assessmentColumn.DataType = typeof(String);
            assessmentColumn.ColumnName = "Assessment";
            assessmentColumn.Caption = "Assessment";
            assessmentColumn.ReadOnly = true;

            DataColumn areaColumn = new DataColumn();
            areaColumn.DataType = typeof(String);
            areaColumn.ColumnName = "Area";
            areaColumn.Caption = "Area";
            areaColumn.ReadOnly = true;

            DataColumn refColumn = new DataColumn();
            refColumn.DataType = typeof(String);
            refColumn.ColumnName = "Reference";
            refColumn.Caption = "Reference";
            refColumn.ReadOnly = true;

            DataColumn dateColumn = new DataColumn();
            dateColumn.DataType = typeof(String);
            dateColumn.ColumnName = "Date";
            dateColumn.Caption = "Date";
            dateColumn.ReadOnly = true;

            DataColumn timeColumn = new DataColumn();
            timeColumn.DataType = typeof(String);
            timeColumn.ColumnName = "Time";
            timeColumn.Caption = "Time";
            timeColumn.ReadOnly = true;

            DataColumn outcomeColumn = new DataColumn();
            outcomeColumn.DataType = typeof(String);
            outcomeColumn.ColumnName = "Outcome";
            outcomeColumn.Caption = "Outcome";
            outcomeColumn.ReadOnly = true;

            DataColumn assessmentByColumn = new DataColumn();
            assessmentByColumn.DataType = typeof(String);
            assessmentByColumn.ColumnName = "Assessment By";
            assessmentByColumn.Caption = "Assessment By";
            assessmentByColumn.ReadOnly = true;

            DataColumn viewColumn = new DataColumn();
            viewColumn.DataType = typeof(String);
            viewColumn.ColumnName = "View Assessment";
            viewColumn.Caption = "View Assessment";
            viewColumn.ReadOnly = true;

            DataColumn signOffColumn = new DataColumn();
            signOffColumn.DataType = typeof(bool);
            signOffColumn.ColumnName = "Sign Off";
            signOffColumn.Caption = "Sign Off";
            signOffColumn.ReadOnly = false;

            DataTable assessmentTable = new DataTable("Assessments");
            assessmentTable.Columns.Add(assessmentColumn);
            assessmentTable.Columns.Add(areaColumn);
            assessmentTable.Columns.Add(refColumn);
            assessmentTable.Columns.Add(dateColumn);
            assessmentTable.Columns.Add(timeColumn);
            assessmentTable.Columns.Add(outcomeColumn);
            assessmentTable.Columns.Add(assessmentByColumn);
            assessmentTable.Columns.Add(viewColumn);
            assessmentTable.Columns.Add(signOffColumn);

            String assessmentQuery =
                "SELECT"
                + " [Assessment].[Assessment]"
                + " , [Ref_Assessment_Area].[Name] + ' ' + [Ref_Question_Set].[Name] AS [Area]"
                + " , [Assessment].[Interaction_Reference]"
                + " , FORMAT([Assessment].[Interaction_Date], 'dd/MM/yyyy') AS [Interaction_Date]"
                + " , [Assessment].[Interaction_Time]"
                + " , [Assessment].[Outcome]"
                + " , [Ref_Assessment_By].[Name] AS [Assessment_By]"
                + "FROM [Table].[Assessment]"
                + "INNER JOIN [Table].[Ref_Assessment_Area]"
                + " ON [Assessment].[Assessment_Area] = [Ref_Assessment_Area].[Assessment_Area]"
                + "INNER JOIN [Table].[Ref_Question_Set]"
                + " ON [Assessment].[Question_Set] = [Ref_Question_Set].[Question_Set]"
                + "INNER JOIN [Table].[Ref_Assessment_Type]"
                + " ON [Assessment].[Assessment_Type] = [Ref_Assessment_Type].[Assessment_Type]"
                + "INNER JOIN [Table].[Ref_User] AS [Ref_Assessment_By]"
                + " ON [Assessment].[Assessment_By] = [Ref_Assessment_By].[User]"
                + "WHERE"
                + " [Assessment].[Interaction_By] = " + ((KeyValuePair<string, string>)AssessmentForComboBox.SelectedItem).Key
                + " AND [Assessment].[Assessment_Date] >= '" + AssessmentStartDatePicker.Value.ToString("yyyy-MMMM-dd") + "'"
                + " AND [Assessment].[Assessment_Date] <= '" + AssessmentEndDatePicker.Value.ToString("yyyy-MMMM-dd") + "'"
                + " AND [Ref_Assessment_Area].[Name] + ' ' + [Ref_Question_Set].[Name] IN ('" + AssessmentAreaComboBox.Text.ToString().Replace(", ", "', '") + "')";

            if (calledFromGlobal == "Agent")
            {
                assessmentQuery = assessmentQuery + " AND [Ref_Assessment_Type].[Name] NOT LIKE '%Bench%'";
                assessmentQuery = assessmentQuery + " AND [Assessment].[Signed_Off] = 0";
            }

            foreach (DataTable table in sql.returnDataSet(assessmentQuery).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    assessmentTable.Rows.Add(
                        row["Assessment"].ToString()
                        , row["Area"].ToString()
                        , row["Interaction_Reference"].ToString()
                        , row["Interaction_Date"].ToString()
                        , row["Interaction_Time"].ToString()
                        , row["Outcome"].ToString()
                        , row["Assessment_By"].ToString()
                        , "View Assessment"
                        , false
                    );
                }
            }

            AssessmentTable.DataSource = assessmentTable;
            AssessmentTable.ReadOnly = false;
            AssessmentTable.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            AssessmentTable.Columns["Assessment"].Visible = false;
            AssessmentTable.Columns["Area"].Width = 190;
            AssessmentTable.Columns["Reference"].Width = 137;
            AssessmentTable.Columns["Outcome"].Width = 120;
            AssessmentTable.Columns["Assessment By"].Width = 110;
            AssessmentTable.Columns["View Assessment"].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);

            foreach (DataGridViewColumn column in AssessmentTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        #endregion

        // Code for when table clicked //
        #region Code for when view column clicked
        private void AssessmentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AssessmentTable.CurrentCell.ColumnIndex == AssessmentTable.Columns["View Assessment"].Index)
            {
                String assessmentNumber = AssessmentTable.Rows[AssessmentTable.CurrentCell.RowIndex].Cells[0].Value.ToString();

                Assessment_Form form = new Assessment_Form("Review", int.Parse(assessmentNumber), 0, 0, 0);
                form.MdiParent = this.MdiParent;
                form.Owner = this;
                form.Show();
            }
        }
        #endregion

        // Sign off Assessent //
        #region Sign off Assessment
        private void SignOffAssessment_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AssessmentTable.Rows)
            {
                if (row.Cells["Sign Off"].Value.ToString() == "True")
                {
                    String signOffQuery =
                            "UPDATE [Table].[Assessment]"
                            + "SET"
                            + "[Assessment].[Signed_Off] = '1'"
                            + " , [Assessment].[Signed_Off_By] = " + globalVariables.userID(globalVariables.userName())
                            + " , [Assessment].[Signed_Off_Date] = CAST(GETDATE() AS DATE)"
                            + " , [Assessment].[Signed_Off_Time] = CAST(GETDATE() AS TIME(0))"
                            + "WHERE [Assessment].[Assessment] = '" + row.Cells["Assessment"].Value.ToString() + "'";
                    sql.updateSQL(signOffQuery);
                }
            }

            String assessmentFor = AssessmentForComboBox.SelectedValue.ToString();
            AssessmentForComboBox.SelectedValue = "0";
            AssessmentForComboBox.SelectedValue = assessmentFor;
        }
        #endregion
    }
}
