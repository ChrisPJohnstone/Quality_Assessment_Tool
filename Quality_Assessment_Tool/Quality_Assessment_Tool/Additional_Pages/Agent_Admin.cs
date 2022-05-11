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
    public partial class Agent_Admin : Form
    {
        Global_Variables globalVariables = new Global_Variables();
        SQL_Interaction sql = new SQL_Interaction();
        General_Functions generalFunctions = new General_Functions();

        // Code When Page Launched //
        #region Code When Page Launched
        public Agent_Admin()
        {
            InitializeComponent();

            populateChangesBy();

            populateAreaSelect();
        }
        #endregion

        // Populate "Changes By" //
        #region Populate "Changes By"
        private void populateChangesBy()
        {
            String changesByQuery =
                "SELECT DISTINCT"
                + " [Ref_User].[User] AS [ID]"
                + " , [Ref_User].[Name]"
                + "FROM [Table].[Ref_User]"
                + "INNER JOIN [Table].[Ref_Permission]"
                + " ON [Ref_User].[Permission] = [Ref_Permission].[Permission]"
                + "WHERE [Ref_Permission].[Admin] = 1";
            generalFunctions.fillComboBox(ChangesByComboBox, changesByQuery);
            ChangesByComboBox.SelectedValue = globalVariables.userID(globalVariables.userName()).ToString();
        }
        #endregion

        // Populate "Area Select" //
        #region Populate "Area Select"
        private void populateAreaSelect()
        {
            BindingSource areaList = new BindingSource();
            areaList.DataSource = new List<String> { "", "User", "Team", "Permission" };
            AreaSelectComboBox.DataSource = areaList;
        }
        #endregion

        // Code When "Area Select" Changed //
        #region Code When "Area Select" Changed
        private void AreaSelectComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            AdminTable.Columns.Clear();

            if (AreaSelectComboBox.SelectedValue.ToString() == "User")
            {
                loadRefUser();
            }
        }
        #endregion

        // Code When Admin Table Has a Cell Value Changed //
        #region Code When Admin Table Has a Cell Value Changed
        private bool EnableChangeEvent = true;

        private void AdminTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (EnableChangeEvent)
            {
                String test = AdminTable.Columns[e.ColumnIndex].Name.ToString();
                MessageBox.Show(test);
            }
        }
        #endregion

        // Code For Ref_User //
        #region Code For Ref_User
        private void loadRefUser()
        {
            EnableChangeEvent = false;

            DataColumn userIDColumn = new DataColumn();
            userIDColumn.DataType = typeof(String);
            userIDColumn.ColumnName = "User ID";
            userIDColumn.Caption = "User ID";
            userIDColumn.ReadOnly = true;

            DataColumn userNameColumn = new DataColumn();
            userNameColumn.DataType = typeof(String);
            userNameColumn.ColumnName = "User Name";
            userNameColumn.Caption = "User Name";
            userNameColumn.ReadOnly = false;

            DataColumn teamIDColumn = new DataColumn();
            teamIDColumn.DataType = typeof(String);
            teamIDColumn.ColumnName = "Team ID";
            teamIDColumn.Caption = "Team ID";
            teamIDColumn.ReadOnly = true;

            DataColumn activeColumn = new DataColumn();
            activeColumn.DataType = typeof(bool);
            activeColumn.ColumnName = "Active";
            activeColumn.Caption = "Active";
            activeColumn.ReadOnly = false;

            DataColumn permissionIDColumn = new DataColumn();
            permissionIDColumn.DataType = typeof(String);
            permissionIDColumn.ColumnName = "Permission ID";
            permissionIDColumn.Caption = "Permission ID";
            permissionIDColumn.ReadOnly = true;

            DataColumn programPermissionColumn = new DataColumn();
            programPermissionColumn.DataType = typeof(bool);
            programPermissionColumn.ColumnName = "Program Permission";
            programPermissionColumn.Caption = "Program Permission";
            programPermissionColumn.ReadOnly = true;

            DataColumn agentPermissionColumn = new DataColumn();
            agentPermissionColumn.DataType = typeof(bool);
            agentPermissionColumn.ColumnName = "Agent Permission";
            agentPermissionColumn.Caption = "Agent Permission";
            agentPermissionColumn.ReadOnly = true;

            DataColumn assessorPermissionColumn = new DataColumn();
            assessorPermissionColumn.DataType = typeof(bool);
            assessorPermissionColumn.ColumnName = "Assessor Permission";
            assessorPermissionColumn.Caption = "Assessor Permission";
            assessorPermissionColumn.ReadOnly = true;

            DataColumn adminPermissionColumn = new DataColumn();
            adminPermissionColumn.DataType = typeof(bool);
            adminPermissionColumn.ColumnName = "Admin Permission";
            adminPermissionColumn.Caption = "Admin Permission";
            adminPermissionColumn.ReadOnly = true;

            DataTable adminTable = new DataTable("Admin");
            adminTable.Columns.Add(userIDColumn);
            adminTable.Columns.Add(userNameColumn);
            adminTable.Columns.Add(teamIDColumn);
            adminTable.Columns.Add(activeColumn);
            adminTable.Columns.Add(permissionIDColumn);
            adminTable.Columns.Add(programPermissionColumn);
            adminTable.Columns.Add(agentPermissionColumn);
            adminTable.Columns.Add(assessorPermissionColumn);
            adminTable.Columns.Add(adminPermissionColumn);

            String refUserQuery =
                "SELECT"
                + " [Ref_User].[User] AS [User_ID]"
                + " , [Ref_User].[Name] AS [User_Name]"
                + " , [Ref_User].[Team] AS [Team_ID]"
                + " , [Ref_User].[Active]"
                + " , [Ref_Permission].[Permission] AS [Permission_ID]"
                + " , [Ref_Permission].[Program]"
                + " , [Ref_Permission].[Agent]"
                + " , [Ref_Permission].[Assessor]"
                + " , [Ref_Permission].[Admin]"
                + "FROM [Table].[Ref_User]"
                + "INNER JOIN [Table].[Ref_Permission]"
                + " ON [Ref_User].[Permission] = [Ref_Permission].[Permission]"
                + "ORDER BY [Ref_User].[Name] ASC";
            foreach (DataTable table in sql.returnDataSet(refUserQuery).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    adminTable.Rows.Add(
                        row["User_ID"].ToString()
                        , row["User_Name"].ToString()
                        , row["Team_ID"].ToString()
                        , row["Active"].ToString()
                        , row["Permission_ID"].ToString()
                        , row["Program"].ToString()
                        , row["Agent"].ToString()
                        , row["Assessor"].ToString()
                        , row["Admin"].ToString()
                    );
                }
            }

            AdminTable.DataSource = adminTable;
            AdminTable.AllowUserToResizeRows = false;
            AdminTable.AllowUserToResizeColumns = true;
            AdminTable.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular);
            AdminTable.ReadOnly = false;
            AdminTable.Columns["User ID"].Visible = false;
            AdminTable.Columns["User Name"].Width = 125;
            AdminTable.Columns["Team ID"].Visible = false;
            AdminTable.Columns["Permission ID"].Visible = false;
            AdminTable.Columns["Program Permission"].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            AdminTable.Columns["Program Permission"].Width = 125;
            AdminTable.Columns["Agent Permission"].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            AdminTable.Columns["Assessor Permission"].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;
            AdminTable.Columns["Assessor Permission"].Width = 125;
            AdminTable.Columns["Admin Permission"].DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro;

            DataGridViewComboBoxColumn teamNameColumn = new DataGridViewComboBoxColumn();
            String teamNameQuery =
                "SELECT"
                + " [Ref_Team].[Team] AS [ID]"
                + " , [Ref_Team].[Name]"
                + "FROM [Table].[Ref_Team]"
                + "ORDER BY [Ref_Team].[Name] ASC";
            teamNameColumn.Name = "Team Name";
            teamNameColumn.ReadOnly = false;
            generalFunctions.fillComboBoxColumn(teamNameColumn, teamNameQuery, "Team Name");
            AdminTable.Columns.Insert(3, teamNameColumn);
            AdminTable.Columns["Team Name"].Width = 125;

            DataGridViewComboBoxColumn permissionNameColumn = new DataGridViewComboBoxColumn();
            String permissionNameQuery =
                "SELECT"
                + " [Ref_Permission].[Permission] AS [ID]"
                + " , [Ref_Permission].[Name]"
                + "FROM [Table].[Ref_Permission]"
                + "ORDER BY [Ref_Permission].[Name] ASC";
            permissionNameColumn.Name = "Permission Group";
            permissionNameColumn.ReadOnly = false;
            generalFunctions.fillComboBoxColumn(permissionNameColumn, permissionNameQuery, "Permission Group");
            AdminTable.Columns.Insert(4, permissionNameColumn);
            AdminTable.Columns["Permission Group"].Width = 125;

            foreach (DataGridViewColumn column in AdminTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            foreach (DataGridViewRow row in AdminTable.Rows)
            {
                row.Cells["Team Name"].Value = row.Cells["Team ID"].Value.ToString();
                row.Cells["Permission Group"].Value = row.Cells["Permission ID"].Value.ToString();
            }

            EnableChangeEvent = true;
        }
        #endregion
    }
}
