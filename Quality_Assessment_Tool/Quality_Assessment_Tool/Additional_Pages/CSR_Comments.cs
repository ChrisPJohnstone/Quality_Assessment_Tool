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
    public partial class CSR_Comments : Form
    {
        Global_Variables globalVariables = new Global_Variables();
        SQL_Interaction sql = new SQL_Interaction();
        General_Functions generalFunctions = new General_Functions();

        // Code When Page Launched //
        #region Code When Page Launched
        public CSR_Comments()
        {
            InitializeComponent();

            // Populate Assessor //
            String assessorQuery =
                "SELECT"
                + " [Ref_User].[User] AS [ID]"
                + " , [Ref_User].[Name]"
                + "FROM [Table].[Ref_User]"
                + "INNER JOIN [Table].[Ref_Permission]"
                + " ON [Ref_User].[Permission] = [Ref_Permission].[Permission]"
                + "WHERE [Ref_Permission].[Assessor] = 1"
                + "ORDER BY [Ref_User].[Name] ASC";
            generalFunctions.fillComboBox(AssessorComboBox, assessorQuery);
            AssessorComboBox.SelectedValue = globalVariables.userID(globalVariables.userName()).ToString();
            if (!globalVariables.userPermissionAdmin())
            {
                AssessorComboBox.Enabled = false;
            }

            // Populate Comment For //
            String commentForQuery =
                "SELECT"
                + " [Ref_User].[User] AS [ID]"
                + " , [Ref_User].[Name]"
                + "FROM [Table].[Ref_User]"
                + "INNER JOIN [Table].[Ref_Permission]"
                + " ON [Ref_User].[Permission] = [Ref_Permission].[Permission]"
                + "WHERE [Ref_Permission].[Agent] = 1"
                + "ORDER BY [Ref_User].[Name] ASC";
            generalFunctions.fillComboBox(CommentForComboBox, commentForQuery);
        }
        #endregion

        // Code When Parameters Changed //
        #region Code When Parameters Changed
        #region Launch events
        private void AssessorComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            parameterChanged();
        }

        private void CommentForComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            parameterChanged();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            parameterChanged();
        }
        #endregion

        private void parameterChanged()
        {
            if (AssessorComboBox.Text == "" || CommentForComboBox.Text == "" || commentDatePicker.Text == "")
            {
                CommentTextBox.Text = "";
                CommentTextBox.Enabled = false;

                CommentSubmitButton.Enabled = false;
            }
            else
            {
                String assessor = ((KeyValuePair<string, string>)AssessorComboBox.SelectedItem).Key.ToString();
                String commentFor = ((KeyValuePair<string, string>)CommentForComboBox.SelectedItem).Key.ToString();
                DateTime commentDate = commentDatePicker.Value;
                DateTime commentMonth = new DateTime(commentDate.Year, commentDate.Month, 1);

                String CommentQuery =
                    "SELECT [CSR_Comments].[Notes]"
                    + "FROM [Table].[CSR_Comments]"
                    + "WHERE"
                    + " [CSR_Comments].[Comment_For] = " + commentFor
                    + " AND [CSR_Comments].[Comment_Date] = '" + commentMonth.ToString("yyyy-MM-dd") + "'";
                String commentNotes = sql.returnSingleString(CommentQuery);
                CommentTextBox.Enabled = true;
                CommentSubmitButton.Enabled = true;

                if (commentNotes == "")
                {
                    CommentTextBox.Text = "";
                }
                else
                {
                    CommentTextBox.Text = commentNotes;
                }
            }
        }
        #endregion

        // Code When Submit Clicked //
        #region Code When Submit Clicked
        private void CommentSubmitButton_Click(object sender, EventArgs e)
        {
            Boolean continueUpdate = true;
            String assessor = ((KeyValuePair<string, string>)AssessorComboBox.SelectedItem).Key.ToString();
            String commentFor = ((KeyValuePair<string, string>)CommentForComboBox.SelectedItem).Key.ToString();
            DateTime commentDate = commentDatePicker.Value;
            DateTime commentMonth = new DateTime(commentDate.Year, commentDate.Month, 1);

            String existingCommentQuery =
                "SELECT [CSR_Comments].[Comment]"
                + "FROM [Table].[CSR_Comments]"
                    + "WHERE"
                    + " [CSR_Comments].[Comment_For] = " + commentFor
                    + " AND [CSR_Comments].[Comment_Date] = '" + commentMonth.ToString("yyyy-MM-dd") + "'";
            String commentNumber = sql.returnSingleInt(existingCommentQuery).ToString();

            if (commentNumber != "0" && continueUpdate)
            {
                String commentExistsMessage = "Update the existing comment to match what you have enterred?";
                DialogResult updateResponse = MessageBox.Show(commentExistsMessage, "Update Existing", MessageBoxButtons.YesNo);

                if (updateResponse == DialogResult.Yes)
                {
                    String deleteQuery =
                        "DELETE FROM [Table].[CSR_Comments]"
                        + "WHERE [CSR_Comments].[Comment] = " + commentNumber;
                    sql.updateSQL(deleteQuery);
                }
                else
                {
                    continueUpdate = false;
                }
            }

            if (continueUpdate)
            {
                String commentOutput = CommentTextBox.Text.ToString();
                commentOutput = commentOutput.Replace("'", "''");

                String updateQuery =
                    "INSERT INTO [Table].[CSR_Comments] ("
                    + " [Import_Date]"
                    + " , [Import_Time]"
                    + " , [Added_By]"
                    + " , [Comment_For]"
                    + " , [Comment_By]"
                    + " , [Comment_Date]"
                    + " , [Notes]"
                    + ") VALUES ("
                    + " GETDATE()"
                    + " , GETDATE()"
                    + " , SYSTEM_USER"
                    + " , '" + commentFor + "'"
                    + " , '" + assessor + "'"
                    + " , '" + commentMonth.ToString("yyyy-MMMM-dd") + "'"
                    + " , '" + commentOutput + "'"
                    + ")";
                sql.updateSQL(updateQuery);
                this.Close();
            }
        }
        #endregion
    }
}
