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
    public partial class Navigation_Pane : Form
    {
        Global_Variables globalVariables = new Global_Variables();
        SQL_Interaction sql = new SQL_Interaction();
        General_Functions generalFunctions = new General_Functions();

        // Code When Page Launched //
        #region Code When Page Launched
        public Navigation_Pane()
        {
            InitializeComponent();

            String assessmentAreaQuery =
                "SELECT"
                + "[Ref_Assessment_Area].[Assessment_Area] AS [ID]"
                + " , [Ref_Assessment_Area].[Name]"
                + "FROM [Table].[Ref_Assessment_Area]"
                + "WHERE [Ref_Assessment_Area].[Active] = 1"
                + "ORDER BY [Ref_Assessment_Area].[Name] ASC";
            generalFunctions.fillComboBox(AssessmentAreaComboBox, assessmentAreaQuery);
        }
        #endregion

        // Code When Assessment Area Drop Down Changes //            
        #region Code When Assessment Area Drop Down Changes
        private int assessmentArea;

        private void AssessmentAreaComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            assessmentArea = int.Parse(((KeyValuePair<string, string>)AssessmentAreaComboBox.SelectedItem).Key);

            String questionSetQuery =
                "SELECT"
                + " [Ref_Question_Set].[Question_Set] AS [ID]"
                + " , [Ref_Question_Set].[Name]"
                + "FROM [Table].[Ref_Question_Set]"
                + "WHERE"
                + " [Ref_Question_Set].[Active] = 1"
                + " AND [Ref_Question_Set].[Assessment_Area] = " + assessmentArea
                + "ORDER BY [Ref_Question_Set].[Name] ASC";
            generalFunctions.fillComboBox(QuestionSetComboBox, questionSetQuery);
        }
        #endregion

        // Code When Question Set Drop Down Changes //
        #region Code When Question Set Drop Down Changes
        private int questionSet;

        private void QuestionSetComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            questionSet = int.Parse(((KeyValuePair<string, string>)QuestionSetComboBox.SelectedItem).Key);

            String assessmentTypeQuery =
                "SELECT"
                + "[Ref_Assessment_Type].[Assessment_Type] AS [ID]"
                + " , [Ref_Assessment_Type].[Name]"
                + "FROM [Table].[Ref_Assessment_Type]"
                + "WHERE"
                + " [Ref_Assessment_Type].[Active] = 1"
                + " AND [Ref_Assessment_Type].[Question_Set] = " + questionSet
                + "ORDER BY [Ref_Assessment_Type].[Name] ASC";
            generalFunctions.fillComboBox(AssessmentTypeComboBox, assessmentTypeQuery);
        }
        #endregion

        // Code When Assessment Type Drop Down Changes //
        #region Code When Assessment Type Drop Down Changes
        private int assessmentType;

        private void AssessmentTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            assessmentType = int.Parse(((KeyValuePair<string, string>)AssessmentTypeComboBox.SelectedItem).Key);
        }
        #endregion

        // Code When Reference Changes //
        #region Code When Reference Changes
        private void ReferenceTextBox_TextChanged(object sender, EventArgs e)
        {
            Label assessmentByLabel = TabControl.TabPages["Review"].Controls["AssessmentByLabel"] as Label;
            assessmentByLabel.Visible = false;

            ComboBox assessmentByComboBox = TabControl.TabPages["Review"].Controls["AssessmentByComboBox"] as ComboBox;
            assessmentByComboBox.Visible = false;
            assessmentByComboBox.DataSource = null;
            assessmentByComboBox.Text = null;
        }
        #endregion

        // Code When Score Button Clicked //
        #region Code When Score Button Clicked
        private void NavigateToScoring_Click(object sender, EventArgs e)
        {
            if (assessmentArea == 0)
            {
                MessageBox.Show("Assessment Area has not been completed");
            }
            else if (questionSet == 0)
            {
                MessageBox.Show("Question Set has not been completed");
            }
            else if (assessmentType == 0)
            {
                MessageBox.Show("Assessment Type has not been completed");
            }
            else if (!globalVariables.userPermissionAssessor() && ((KeyValuePair<string, string>)AssessmentTypeComboBox.SelectedItem).Value != "Self Assessment")
            {
                MessageBox.Show("Insufficient Permissions");
            }
            else
            {
                Assessment_Form form = new Assessment_Form("Score", 0, assessmentArea, questionSet, assessmentType);
                form.MdiParent = this.MdiParent;
                form.Owner = this;
                form.Show();
            }
        }
        #endregion

        // Code When Review Button Clicked //
        #region Code When Review Button Clicked
        private void NavigateToReview_Click(object sender, EventArgs e)
        {
            if (!globalVariables.userPermissionAssessor())
            {
                MessageBox.Show("Insufficient Permissions");
            }
            else
            {
                String assessmentNumber = "0";
                String assessmentCountQuery =
                    "SELECT COUNT(*)"
                    + "FROM [Table].[Assessment]"
                    + "WHERE"
                    + " CASE"
                    + "     WHEN [Assessment].[Interaction_Reference] = '" + TabControl.TabPages["Review"].Controls["ReferenceTextBox"].Text.Replace("'", "''") + "' THEN 1"
                    + "     WHEN"
                    + "         REVERSE(STUFF(REVERSE(LEFT([Assessment].[Interaction_Reference], CHARINDEX('_BENCHMARK_', [Assessment].[Interaction_Reference], 1))), 1, 1, '')) = '" + TabControl.TabPages["Review"].Controls["ReferenceTextBox"].Text + "'"
                    + "         AND [Assessment].[Interaction_Reference] LIKE '%_BENCHMARK_%'"
                    + "     THEN 1"
                    + "     ELSE 0 "
                    + "END = 1";
                String assessmentCount = sql.returnSingleInt(assessmentCountQuery).ToString();

                if (assessmentCount == "1")
                {
                    String assessmentQuery =
                        "SELECT [Assessment].[Assessment]"
                        + "FROM [Table].[Assessment]"
                        + "WHERE"
                        + " CASE"
                        + "     WHEN [Assessment].[Interaction_Reference] = '" + TabControl.TabPages["Review"].Controls["ReferenceTextBox"].Text + "' THEN 1"
                        + "     WHEN"
                        + "         REVERSE(STUFF(REVERSE(LEFT([Assessment].[Interaction_Reference], CHARINDEX('_BENCHMARK_', [Assessment].[Interaction_Reference], 1))), 1, 1, '')) = '" + TabControl.TabPages["Review"].Controls["ReferenceTextBox"].Text + "'"
                        + "         AND [Assessment].[Interaction_Reference] LIKE '%_BENCHMARK_%'"
                        + "     THEN 1"
                        + "     ELSE 0 "
                        + "END = 1";
                    assessmentNumber = sql.returnSingleInt(assessmentQuery).ToString();
                }
                else if (int.Parse(assessmentCount) > 1)
                {
                    Label assessmentByLabel = TabControl.TabPages["Review"].Controls["AssessmentByLabel"] as Label;
                    ComboBox assessmentByComboBox = TabControl.TabPages["Review"].Controls["AssessmentByComboBox"] as ComboBox;

                    if (assessmentByComboBox.SelectedValue == null)
                    {
                        assessmentByLabel.Visible = true;
                        assessmentByComboBox.Visible = true;
                        assessmentByComboBox.Text = "";

                        assessmentNumber = "0";
                        String assessmentByQuery =
                            "SELECT"
                            + " [Assessment].[Assessment_By] AS [ID]"
                            + " , [Ref_User].[Name] AS [Name]"
                            + "FROM [Table].[Assessment]"
                            + "INNER JOIN [Table].[Ref_User]"
                            + " ON [Assessment].[Assessment_By] = [Ref_User].[User]"
                            + "WHERE"
                            + " CASE"
                            + "     WHEN [Assessment].[Interaction_Reference] = '" + TabControl.TabPages["Review"].Controls["ReferenceTextBox"].Text + "' THEN 1"
                            + "     WHEN"
                            + "         REVERSE(STUFF(REVERSE(LEFT([Assessment].[Interaction_Reference], CHARINDEX('_BENCHMARK_', [Assessment].[Interaction_Reference], 1))), 1, 1, '')) = '" + TabControl.TabPages["Review"].Controls["ReferenceTextBox"].Text + "'"
                            + "         AND [Assessment].[Interaction_Reference] LIKE '%_BENCHMARK_%'"
                            + "     THEN 1"
                            + "     ELSE 0 "
                            + "END = 1";
                        generalFunctions.fillComboBox(assessmentByComboBox, assessmentByQuery);
                    }
                    else
                    {
                        String assessmentQuery =
                            "SELECT [Assessment].[Assessment]"
                            + "FROM [Table].[Assessment]"
                            + "WHERE"
                            + " [Assessment].[Interaction_Reference] LIKE '" + TabControl.TabPages["Review"].Controls["ReferenceTextBox"].Text + "%'"
                            + " AND [Assessment].[Assessment_By] = " + ((KeyValuePair<string, string>)assessmentByComboBox.SelectedItem).Key;
                        assessmentNumber = sql.returnSingleInt(assessmentQuery).ToString();
                    }
                }

                if (assessmentNumber == "0")
                {
                    if (assessmentCount == "0")
                    {
                        MessageBox.Show("Reference Not Found");
                    }
                    else
                    {
                        MessageBox.Show("Multiple Assessments Have Been Found For This Reference, Please Select Who's Assessment You Want To See");
                    }
                }
                else
                {
                    Assessment_Form form = new Assessment_Form("Review", int.Parse(assessmentNumber), 0, 0, 0);
                    form.MdiParent = this.MdiParent;
                    form.Owner = this;
                    form.Show();
                }
            }
        }
        #endregion

        // Code When Sign Off Quality Checks Clicked //
        #region Code When Sign Off Quality Checks Clicked
        private void signOffQualityChecksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assessment_Sign_Off form = new Assessment_Sign_Off("Agent");
            form.MdiParent = this.MdiParent;
            form.Owner = this;
            form.Show();
        }
        #endregion

        // Code When Sign Off Quality Checks Clicked //
        #region Code When Sign Off Quality Checks Clicked
        private void searchCallMenuItem_Click(object sender, EventArgs e)
        {
            Assessment_Sign_Off form = new Assessment_Sign_Off("Manager");
            form.MdiParent = this.MdiParent;
            form.Owner = this;
            form.Show();
        }
        #endregion

        // Code When Submit CSR Comment Clicked //
        #region Code When Submit CSR Comment Clicked
        private void submitCSRCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globalVariables.userPermissionAssessor())
            {
                CSR_Comments form = new CSR_Comments();
                form.MdiParent = this.MdiParent;
                form.Owner = this;
                form.Show();
            }
            else
            {
                MessageBox.Show("Insufficient Permissions");
            }
        }
        #endregion

        // Code When "Go To Quality Reports" Clicked //
        #region Code When "Go To Quality Reports" clicked
        private void goToQualityReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://wscsql95/Reports/Pages/Folder.aspx?ItemPath=%2fCall+Quality");
        }
        #endregion

        // Code When "User Admin" Clicked //
        #region Code When "User Admin" Clicked
        private void userAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globalVariables.userPermissionAdmin())
            {
                Agent_Admin form = new Agent_Admin();
                form.MdiParent = this.MdiParent;
                form.Owner = this;
                form.Show();
            }
            else
            {
                MessageBox.Show("Insufficient Permissions");
            }
        }
        #endregion

        // Code when "About" Clicked //
        #region Code when About Clicked
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program_Information form = new Program_Information();
            form.MdiParent = this.MdiParent;
            form.Owner = this;
            form.Show();
        }
        #endregion
    }
}
