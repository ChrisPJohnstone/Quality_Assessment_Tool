using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quality_Assessment_Tool
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Global_Variables globalVariables = new Global_Variables();
            SQL_Interaction sql = new SQL_Interaction();

            Boolean proceedWithLaunch = true;

            // Log Access Attempt //
            #region Log Access Attempt
            String updateQuery =
                "INSERT INTO [Table].[Access_Log] ("
                + " [Import_Date]"
                + " , [Import_Time]"
                + " , [Added_By]"
                + " , [Accessor]"
                + " , [Accessor_Username]"
                + " , [Program_Version]"
                + ") VALUES ("
                + " GETDATE()"
                + " , GETDATE()"
                + " , SYSTEM_USER"
                + " , '" + globalVariables.userName().Replace("'", "''") + "'"
                + " , '" + Environment.UserName + "'"
                + " , " + globalVariables.ProgramVersion
                + ")";
            sql.updateSQL(updateQuery);
            #endregion

            // Check if Program Open //
            #region Check if Program Open
            if (proceedWithLaunch)
            {
                if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
                {
                    String programOpenMessage =
                        "You already have this program open" + Environment.NewLine
                        + "Application closing";
                    MessageBox.Show(programOpenMessage);

                    proceedWithLaunch = false;
                    Application.Exit();
                }
            }
            #endregion

            // Check User Permission //
            #region Check User Permission
            if (proceedWithLaunch)
            {
                Boolean permission = globalVariables.userPermissionProgram();

                if (!(permission))
                {
                    String noAccessMessage =
                        "You do not have access to this program, contact your team leader" + Environment.NewLine
                        + "Application closing";
                    MessageBox.Show(noAccessMessage);

                    proceedWithLaunch = false;
                    Application.Exit();
                }
            }
            #endregion

            // Check Program Version //
            #region Check Program Version
            if (proceedWithLaunch)
            {
                String activeProgramVersionQuery =
                    "SELECT [Ref_Program_Version].[Program_Version]"
                    + "FROM [Table].[Ref_Program_Version]"
                    + "WHERE [Ref_Program_Version].[Active] = 1";

                int activeProgramVersion = sql.returnSingleInt(activeProgramVersionQuery);

                if (activeProgramVersion != globalVariables.ProgramVersion)
                {
                    String wrongVersionMessage =
                        "You are trying to access version " + globalVariables.ProgramVersion + Environment.NewLine
                        + "The active version is " + activeProgramVersion + Environment.NewLine
                        + "Please contact your team leader for correct version" + Environment.NewLine
                        + "Application closing";
                    MessageBox.Show(wrongVersionMessage);

                    proceedWithLaunch = false;
                    Application.Exit();
                }
            }
            #endregion

            // Launches App //
            if (proceedWithLaunch)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Navigation_Pane());
            }
        }
    }
}
