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
    class General_Functions
    {
        Global_Variables globalVariables = new Global_Variables();
        SQL_Interaction sql = new SQL_Interaction();

        // Fill Combo Box from SQL Query //
        #region Fill Combo Box from SQL Query
        public void fillComboBox(ComboBox comboBox, String query)
        {
            Dictionary<string, string> comboSource = new Dictionary<string,string>();
            comboSource.Add("0", "");
            
            foreach (DataTable table in sql.returnDataSet(query).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    comboSource.Add(row["ID"].ToString(), row["Name"].ToString());
                }
            }
            comboBox.DataSource = new BindingSource(comboSource, null);
            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Value";
        }
        #endregion

        // Fill Multi Select Combo Box from SQL Query //
        #region Fill Multi Select Combo Box from SQL Query
        public void fillMultiSelectComboBox(MultiSelectComboBox comboBox, String query)
        {
            foreach (DataTable table in sql.returnDataSet(query).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    MultiSelectComboBoxItem item = new MultiSelectComboBoxItem(row["ID"].ToString(), row["Name"].ToString());
                    comboBox.Items.Add(item);
                }
            }

            comboBox.ValueMember = "Key";
            comboBox.DisplayMember = "Name";
        }
        #endregion

        // Fill Combo Box Column from SQL Query //
        #region Fill Combo Box Column from SQL Query
        public void fillComboBoxColumn(DataGridViewComboBoxColumn comboBoxColumn, String query, String header)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("0", "");

            foreach (DataTable table in sql.returnDataSet(query).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    comboSource.Add(row["ID"].ToString(), row["Name"].ToString());
                }
            }
            comboBoxColumn.DataSource = new BindingSource(comboSource, null);
            comboBoxColumn.ValueMember = "Key";
            comboBoxColumn.DisplayMember = "Value";
            comboBoxColumn.HeaderText = header;
        }
        #endregion

        // Fill List Box from SQL Query //
        #region Fill List Box from SQL Query
        public void fillListBox(ListBox listBox, String query)
        {
            Dictionary<string, string> listSource = new Dictionary<string, string>();

            foreach (DataTable table in sql.returnDataSet(query).Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    listSource.Add(row["ID"].ToString(), row["Name"].ToString());
                }
            }

            listBox.DataSource = new BindingSource(listSource, null);
            listBox.ValueMember = "Key";
            listBox.DisplayMember = "Value";
        }
        #endregion

        // Open String in Notepad //
        #region Open String in Notepad
        public void openStringInNotepad(String outputFile, String outputString)
        {
            System.IO.File.WriteAllText(outputFile, outputString);
            System.Diagnostics.Process.Start(outputFile);
        }
        #endregion
    }
}
