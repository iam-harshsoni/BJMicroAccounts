using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BJMicroAccounts.Data;
using System.Text.RegularExpressions;
using MicroAccounts.ViewModel;
using MicroAccounts.App_Code;

namespace MicroAccounts.UserControls
{
    public partial class NewUserRegistration : UserControl
    {
        MicroAccountsEntities1 _entities;
        public NewUserRegistration()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtEmail.Height;
            SidePanel2.Top = txtEmail.Top;
        }

        private void txtF_name_Leave(object sender, EventArgs e)
        {

        }

        private void txtF_name_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtF_name.Height;
            SidePanel2.Top = txtF_name.Top;
        }

        private void txtL_name_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtL_name.Height;
            SidePanel2.Top = txtL_name.Top;
        }

        private void txtMobileNo_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtMobileNo.Height;
            SidePanel2.Top = txtMobileNo.Top;
        }

        private void txtNewPass_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtNewPass.Height;
            SidePanel2.Top = txtNewPass.Top;
        }

        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtConfirmPass.Height;
            SidePanel2.Top = txtConfirmPass.Top;
        }

        public void ClearTextBox()
        {
            txtF_name.Text = "";
            txtL_name.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtUserName.Text = "";
            txtNewPass.Text = "";
            txtConfirmPass.Text = "";
            panel3.Visible = false;
            btnRegister.Text = "Register";
            errorProvider1.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                bool check = ValidateEmail();
                EncryptionDecription enc;

                if (txtEmail.Text == string.Empty && txtF_name.Text == string.Empty && txtL_name.Text == string.Empty && txtUserName.Text == string.Empty && txtMobileNo.Text == string.Empty && txtNewPass.Text == string.Empty && txtConfirmPass.Text == string.Empty)
                {
                    panel3.Visible = true;
                    lblError.Text = "Enter all details.";
                    txtEmail.Focus();
                }

                else if (!check)
                {
                    panel3.Visible = true;
                    lblError.Text = txtEmail.Text + " is Invalid Email Address";
                    txtEmail.Focus();
                }
                else if (txtEmail.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtEmail, "Enter Email Address");
                    txtEmail.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter Email Address.";
                }
                else if (txtF_name.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtF_name, "Enter First Name");
                    txtF_name.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter First Name.";
                }
                else if (txtL_name.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtL_name, "Enter Last Name");
                    txtL_name.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter Last Name.";
                }
                else if (txtUserName.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtUserName, "Enter User Name");
                    txtMobileNo.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter User Name.";
                }

                else if (txtMobileNo.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtMobileNo, "Enter Mobile Number");
                    txtMobileNo.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter Mobile Number.";
                }

                else if (txtNewPass.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtNewPass, "Enter Password");
                    txtNewPass.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter Password.";
                }
                else if (txtConfirmPass.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtConfirmPass, "Re-enter Password");
                    txtConfirmPass.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Re-enter Password.";
                }
                else if (txtConfirmPass.Text != txtNewPass.Text)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtConfirmPass, "Re-enter Password");
                    txtConfirmPass.Clear();
                    txtConfirmPass.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Password and Confirm Password does not match.";
                }

                else
                {
                    if (btnRegister.Text == "Register")
                    {
                        _entities = new MicroAccountsEntities1();

                        tbl_UserProfile userProfile = new tbl_UserProfile();

                        userProfile.email = txtEmail.Text.Trim().ToString();
                        userProfile.firstName = txtF_name.Text.Trim().ToString();
                        userProfile.lastName = txtL_name.Text.Trim().ToString();
                        userProfile.mobile = Convert.ToInt64(txtMobileNo.Text.Trim().ToString());
                        userProfile.createdDate = DateTime.Now;
                        userProfile.updateDate = DateTime.Now;

                        _entities.tbl_UserProfile.Add(userProfile);
                        _entities.SaveChanges();

                        _entities = new MicroAccountsEntities1();
                        tbl_UserLogiln userlogin = new tbl_UserLogiln();
                        userlogin.loginId = txtUserName.Text.Trim().ToString();

                        //encryption of password by calling method of the class called EncryptionDecryption
                        enc = new EncryptionDecription();

                      //  var encPass = enc.Encrypt(txtNewPass.Text.Trim().ToString(), "sblw-3hn8-sqoy19");

                       // var encPass = enc.Encrypt(txtNewPass.Text.Trim().ToString());

                        userlogin.password = txtNewPass.Text.Trim().ToString();
                        userlogin.userId = _entities.tbl_UserProfile.Where(x => x.firstName == txtF_name.Text && x.email == txtEmail.Text).FirstOrDefault().userId;
                        userlogin.createdDate = DateTime.Now;
                        userlogin.updateDate = DateTime.Now;

                        _entities.tbl_UserLogiln.Add(userlogin);
                        _entities.SaveChanges();

                        DataGridSource();
                        MessageBox.Show("Register SuccessFull!");
                    }
                    else
                    {
                        _entities = new MicroAccountsEntities1();
                        enc = new EncryptionDecription();

                        var uId = Convert.ToInt32(hiddenUID.Text);
                        var dataToUpdate = _entities.tbl_UserProfile.Where(x => x.userId == uId).FirstOrDefault();

                        dataToUpdate.firstName = txtF_name.Text.Trim().ToString();
                        dataToUpdate.lastName = txtL_name.Text.Trim().ToString();
                        dataToUpdate.email = txtEmail.Text.Trim().ToString();
                        dataToUpdate.mobile = Convert.ToDecimal(txtMobileNo.Text.Trim());
                        dataToUpdate.updateDate = DateTime.Now;

                        foreach (var item in dataToUpdate.tbl_UserLogiln)
                        {
                            item.loginId = txtUserName.Text.Trim().ToString();
                            //  item.password = enc.Encrypt(txtNewPass.Text.ToString(), "sblw-3hn8-sqoy19");
                            item.password = enc.Encrypt(txtNewPass.Text.ToString());
                            item.updateDate = DateTime.Now;

                            _entities.SaveChanges();
                        }

                        _entities.SaveChanges();
                        DataGridSource();
                        MessageBox.Show("Updated SuccessFull!");
                    }

                    ClearTextBox();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NewUserRegistration_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtEmail;
            txtEmail.Focus();
            //DataGridSource();
        }

        public void DataGridSource()
        {
            int rowNo = 1;

            dgRegisteredUser.AutoGenerateColumns = false;
            _entities = new MicroAccountsEntities1();

            List<UserProfileVM> modelList = new List<UserProfileVM>();

            var dataList = _entities.tbl_UserProfile.ToList();

            foreach (var item in dataList)
            {
                UserProfileVM model = new UserProfileVM();
                model.rowNo = rowNo;
                model.firstName = item.firstName;
                model.lastName = item.lastName;
                model.mobile = item.mobile;
                model.email = item.email;
                model.userId = item.userId;
                model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
               
                if (item.updateDate == null)
                    model.updateDate = "--";
                else
                    model.updateDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");


                modelList.Add(model);
                rowNo++;
            }

            dgRegisteredUser.DataSource = modelList;
            lblTotalRows.Text = modelList.Count.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                if (dgRegisteredUser.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        _entities = new MicroAccountsEntities1();

                        var cellId = Convert.ToInt32(dgRegisteredUser.CurrentRow.Cells["SrNo"].Value);
                        var selectedData1 = _entities.tbl_UserProfile.Where(x => x.userId == cellId).FirstOrDefault();
                        var selectedData2 = _entities.tbl_UserLogiln.Where(x => x.userId == cellId).FirstOrDefault();

                        if (selectedData1 != null)
                        {
                            _entities.tbl_UserProfile.Remove(selectedData1);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Record cannot be deleted.");
                        }
                        if (selectedData2 != null)
                        {
                            _entities.tbl_UserLogiln.Remove(selectedData2);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Record cannot be deleted.");
                        }

                        _entities.SaveChanges();
                        MessageBox.Show("Record deleted ");
                        DataGridSource();
                    }
                    else
                    {
                        //No delete
                    }

                }
            }
            catch(Exception x)
            {
                MessageBox.Show("Record Cannot be deleted. Reference of this record is present in other entries");
            }
        }

        private void dgRegisteredUser_DoubleClick(object sender, EventArgs e)
        {
            if (dgRegisteredUser.CurrentRow.Index != -1)
            {
                _entities = new MicroAccountsEntities1();
                EncryptionDecription enc = new EncryptionDecription();

                var uID = Convert.ToInt32(dgRegisteredUser.CurrentRow.Cells["SrNo"].Value);

                var userJoinData = (from a in _entities.tbl_UserProfile
                                    join b in _entities.tbl_UserLogiln on a.userId equals b.userId
                                    where a.userId == uID
                                    select new { a, b }).FirstOrDefault();

                txtEmail.Text = userJoinData.a.email;
                txtF_name.Text = userJoinData.a.firstName;
                txtL_name.Text = userJoinData.a.lastName;
                txtMobileNo.Text = userJoinData.a.mobile.ToString();
                //txtNewPass.Text = enc.Decrypt(userJoinData.b.password, "sblw-3hn8-sqoy19").ToString();
                //txtNewPass.Text = enc.Decrypt(userJoinData.b.password).ToString();
                txtNewPass.Text = userJoinData.b.password.Trim().ToString();
                txtUserName.Text = userJoinData.b.loginId.ToString();
                hiddenUID.Text = userJoinData.a.userId.ToString();

                btnRegister.Text = "Update";

            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtF_name.Focus();
            }
        }

        private void txtF_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtL_name.Focus();
            }
        }

        private void txtL_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserName.Focus();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMobileNo.Focus();
            }
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNewPass.Focus();
            }
        }


        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmPass.Focus();
            }
        }

        private void txtConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister.Focus();
            }
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtUserName.Height;
            SidePanel2.Top = txtUserName.Top;
        }

        private bool ValidateEmail()
        {
            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
                return false;    //Fail
            else
                return true;   //Success 
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

        }

        private void dgRegisteredUser_Click(object sender, EventArgs e)
        {

        }

        private void txtF_name_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBoxValidation val = new TextBoxValidation();

            val.textOnly(sender, e);
        }

        private void txtMobileNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            TextBoxValidation val = new TextBoxValidation();

            val.onlyNumber(sender, e);
        }
    }
}
