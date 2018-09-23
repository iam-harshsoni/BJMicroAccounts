using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJMicroAccounts.Forms
{
    public partial class BackUpDB : Form
    {
        public BackUpDB()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(BJMicroAccounts.Properties.Settings.Default.MicroAccountsConnectionString);

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLoc.Text = dlg.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            try
            {
                if (txtLoc.Text == string.Empty)
                    MessageBox.Show("Please enter backup file location");
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + txtLoc.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                    using(SqlCommand command=new SqlCommand(cmd,con))
                    {
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("BackUp Created Successfully!");
                        btnBackup.Enabled = false;  
                    }

                }
            }
            catch (Exception x)
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
