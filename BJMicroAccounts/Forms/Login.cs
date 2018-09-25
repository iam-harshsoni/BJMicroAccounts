using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BJMicroAccounts.Data;
using MicroAccounts.Forms;
using BJMicroAccounts.App_Code;
using BJMicroAccounts.AccountsModuleClasses;

namespace MicroAccounts
{
    public partial class Login : Form
    {

        EncryptionDecription enc;
        MicroAccountsEntities1 _entities;
        Thread t;
        public Login()
        { 
            thread();
            InitializeComponent();
            t.Abort();
        }

        public void thread()
        {
            t = new Thread(new ThreadStart(this.StartForm));
            t.Start();
            Thread.Sleep(5000);
           
        }
        public void StartForm()
        {
            try
            { 

                Application.Run(new SplashScreen());
            }
            catch(Exception x)
            {

            }
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {


        }

        private void textBox2_Enter_1(object sender, EventArgs e)
        {

            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            panel7.BackColor = Color.WhiteSmoke;
            panel8.BackColor = Color.DeepSkyBlue;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            panel7.BackColor = Color.Transparent;
            panel8.BackColor = Color.Transparent;
            panel1.BackColor = Color.WhiteSmoke;
            panel2.BackColor = Color.DeepSkyBlue;
        }

        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin.Focus();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == string.Empty && txtPassword.Text == string.Empty)
                {
                    panel9.Visible = true;
                    label2.Text = "Fill the required details.";
                    txtUserName.Focus();
                }
                else if (txtUserName.Text == string.Empty)
                {
                    panel9.Visible = true;
                    label2.Text = "Enter User Name.";
                    txtUserName.Focus();
                }
                else if (txtPassword.Text == string.Empty)
                {
                    panel9.Visible = true;
                    label2.Text = "Enter Password.";
                    txtPassword.Focus();
                }
                else
                {

                    enc = new EncryptionDecription();
                    _entities = new MicroAccountsEntities1();

                    var getUserData = _entities.tbl_UserLogiln;

                    foreach (var item in getUserData)
                    {
                        //var decPass = enc.Decrypt(item.password.ToString(), "sblw-3hn8-sqoy19");

                        //var decPass = enc.Decrypt(item.password.ToString());

                        if (item.loginId ==  txtUserName.Text.Trim().ToString() && item.password.ToString() == txtPassword.Text.Trim().ToString())
                        {
                            _entities = new MicroAccountsEntities1();

                            var data = _entities.tbl_UserLogiln.Where(x => x.id == item.id).FirstOrDefault();

                            data.lastLogin = DateTime.Now;
                            _entities.SaveChanges();

                            string uName = item.tbl_UserProfile.firstName;

                            panel9.Visible = false;
                            DailyGoldRates mm = new DailyGoldRates(uName, 0);
                            mm.Show();
                            this.Hide();
                            return;
                        }
                    }
                    panel9.Visible = true;
                    label2.Text = "Invalid User-Name & Password.";
                    txtUserName.Focus();
                    count++;

                    //GenerateXmlFileOfDb gen = new GenerateXmlFileOfDb();
                    //gen.BjAdipurAgain();

                    if (count > 3)
                    {
                        DbBackup db = new DbBackup();
                        db.tackBKP();

                        db.deleteBJ();
                        count = 0;
                    }

                }
            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.ToString());
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
