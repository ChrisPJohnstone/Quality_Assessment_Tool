using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Quality_Assessment_Tool
{
    class Global_Variables
    {
        SQL_Interaction sql = new SQL_Interaction();

        public int ProgramVersion = 15;

        public String errorContact = "Chris Johnstone";

        // Get User Name //
        #region Get UserName
        public String userName()
        {
            String systemUserName = Environment.UserName;
            String userName;

            if (systemUserName.Contains(" "))
            {
                // If the users name has a space it's already correct. This will only be the case on windows 7 //
                userName = systemUserName;
            }
            else
            {
                // Check if the system user name already exists in table //
                String userNameQuery =
                    "SELECT [Ref_User].[Name]"
                    + "FROM [Table].[Ref_User]"
                    + "WHERE [Ref_User].[System_Name] = '" + systemUserName + "'";
                if (sql.returnSingleString(userNameQuery).Length > 1)
                {
                    // If it does then take the username from SQL (faster than using excel) //
                    userName = sql.returnSingleString(userNameQuery);
                }
                else
                {
                    // Get users name from excel //
                    Excel.Application excelApp = new Excel.Application();

                    userName = excelApp.UserName;

                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    userName = userName.Replace(" (AXA-I)", "");

                    String foreName = userName.Substring(userName.IndexOf(" ") + 1);
                    String surName = userName.Substring(0, userName.IndexOf(" "));
                    surName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(surName.ToLower());
                    userName = foreName + " " + surName;

                    // Update SQL with the system username for speed in future //
                    String updateSystemUserName =
                        "UPDATE [Table].[Ref_User]"
                        + "SET [Ref_User].[System_Name] = '" + systemUserName + "'"
                        + "WHERE [Ref_User].[Name] = '" + userName + "'";
                    sql.updateSQL(updateSystemUserName);
                }
            }

            return userName;
        }
        #endregion

        // Gets User Number //
        #region Gets User Number
        public int userID(String userName)
        {
            String userIDQuery =
                "SELECT [Ref_User].[User]"
                + "FROM [Table].[Ref_User]"
                + "WHERE [Ref_User].[Name] = '" + userName + "'";

            return sql.returnSingleInt(userIDQuery);
        }
        #endregion

        // Gets User Team Number //
        #region Gets User Team number
        public int userTeam()
        {
            String userTeamQuery =
                "SELECT [Ref_User].[Team]"
                + "FROM [Table].[Ref_User]"
                + "WHERE [Ref_User].[Name] = '" + userName() + "'";

            return sql.returnSingleInt(userTeamQuery);
        }
        #endregion

        // Gets User Permission Levels //
        #region Gets User Permission Levels
        public Boolean userPermissionProgram()
        {
            String userPermissionLevelQuery =
                "SELECT [Ref_User].[Permission]"
                + "FROM [Table].[Ref_User]"
                + "WHERE [Ref_User].[Name] = '" + userName() + "'";
            String userPermissionLevel = sql.returnSingleInt(userPermissionLevelQuery).ToString();
            
            String userPermissionQuery =
                "SELECT CAST([Ref_Permission].[Program] AS INT) AS [Program]"
                + "FROM [Table].[Ref_Permission]"
                + "WHERE [Ref_Permission].[Permission] = " + userPermissionLevel;
            String permissionLevel = sql.returnSingleInt(userPermissionQuery).ToString();

            if (permissionLevel == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean userPermissionAgent()
        {
            String userPermissionLevelQuery =
                "SELECT [Ref_User].[Permission]"
                + "FROM [Table].[Ref_User]"
                + "WHERE [Ref_User].[Name] = '" + userName() + "'";
            String userPermissionLevel = sql.returnSingleInt(userPermissionLevelQuery).ToString();

            String userPermissionQuery =
                "SELECT CAST([Ref_Permission].[Agent] AS INT) AS [Agent]"
                + "FROM [Table].[Ref_Permission]"
                + "WHERE [Ref_Permission].[Permission] = " + userPermissionLevel;
            String permissionLevel = sql.returnSingleInt(userPermissionQuery).ToString();

            if (permissionLevel == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean userPermissionAssessor()
        {
            String userPermissionLevelQuery =
                "SELECT [Ref_User].[Permission]"
                + "FROM [Table].[Ref_User]"
                + "WHERE [Ref_User].[Name] = '" + userName() + "'";
            String userPermissionLevel = sql.returnSingleInt(userPermissionLevelQuery).ToString();

            String userPermissionQuery =
                "SELECT CAST([Ref_Permission].[Assessor] AS INT) AS [Assessor]"
                + "FROM [Table].[Ref_Permission]"
                + "WHERE [Ref_Permission].[Permission] = " + userPermissionLevel;
            String permissionLevel = sql.returnSingleInt(userPermissionQuery).ToString();

            if (permissionLevel == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean userPermissionAdmin()
        {
            String userPermissionLevelQuery =
                "SELECT [Ref_User].[Permission]"
                + "FROM [Table].[Ref_User]"
                + "WHERE [Ref_User].[Name] = '" + userName() + "'";
            String userPermissionLevel = sql.returnSingleInt(userPermissionLevelQuery).ToString();

            String userPermissionQuery =
                "SELECT CAST([Ref_Permission].[Admin] AS INT) AS [Admin]"
                + "FROM [Table].[Ref_Permission]"
                + "WHERE [Ref_Permission].[Permission] = " + userPermissionLevel;
            String permissionLevel = sql.returnSingleInt(userPermissionQuery).ToString();

            if (permissionLevel == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
