using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Quality_Assessment_Tool
{
    class SQL_Interaction
    {
        public String SQL_Server = "10.188.81.47, 1433";
        public String SQL_Database = "ABRData";
        private String SQL_Connection_String =
            "Data Source=WSCSQL95; "
            + "Initial Catalog=ABRData; "
            + "User ID=excelconnect; "
            + "Password=excelconnect; ";
            //+ "Trusted_Connection=sspi;";

        // Function to Return Int from SQL Query //
        #region Return Integer
        public int returnSingleInt(String Query)
        {
            SqlConnection Connection = new SqlConnection(SQL_Connection_String);

            try
            {
                Connection.Open();

                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
                DataSet DataSet = new DataSet();
                DataAdapter.Fill(DataSet);

                foreach (DataTable Table in DataSet.Tables)
                {
                    if (Table.Rows.Count == 0) { return 0; }
                }

                int Value = int.Parse(DataSet.Tables[0].Rows[0].ItemArray[0].ToString());

                return Value;
            }
            catch (Exception Exception)
            {
                System.Windows.Forms.MessageBox.Show("Cannot open SQL connection, error: " + Exception.ToString() + " has occured, please contact MI Team");
                return 0;
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion

        // Function to Return String from SQL Query //
        #region Return String
        public String returnSingleString(String Query)
        {
            SqlConnection Connection = new SqlConnection(SQL_Connection_String);

            try
            {
                Connection.Open();

                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
                DataSet DataSet = new DataSet();
                DataAdapter.Fill(DataSet);

                foreach (DataTable Table in DataSet.Tables)
                {
                    if (Table.Rows.Count == 0) { return ""; }
                }

                String Value = DataSet.Tables[0].Rows[0].ItemArray[0].ToString();

                return Value;
            }
            catch (Exception Exception)
            {
                System.Windows.Forms.MessageBox.Show("Cannot open SQL connection, error: " + Exception.ToString() + " has occured, please contact MI Team");
                return "";
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion

        // Function to Return Dataset from SQL Query //
        #region Return Dataset
        public DataSet returnDataSet(String Query)
        {
            SqlConnection Connection = new SqlConnection(SQL_Connection_String);

            try
            {
                Connection.Open();

                SqlCommand Command = new SqlCommand(Query, Connection);
                SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);
                DataSet DataSet = new DataSet();
                DataAdapter.Fill(DataSet);

                foreach (DataTable Table in DataSet.Tables)
                {
                    if (Table.Rows.Count == 0) {return DataSet;}
                }

                return DataSet;
            }
            catch (Exception Exception)
            {
                System.Windows.Forms.MessageBox.Show("Cannot open SQL connection, error: " + Exception.ToString() + " has occured, please contact MI Team");
                DataSet DataSet = new DataSet();
                return DataSet;
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion

        // Function for DML (Insert / Update / Delete) Commands //
        #region Function for DML (Insert / Update / Delete) Commands
        public void updateSQL(String Query)
        {
            SqlConnection Connection = new SqlConnection(SQL_Connection_String);

            try
            {
                Connection.Open();

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Data send has failed. Please check error:\n " + ex.Message + "\n Please let MI know");
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion
    }
}
