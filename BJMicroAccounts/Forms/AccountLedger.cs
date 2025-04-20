using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BJMicroAccounts.Data;
using MicroAccounts.UserControls;
using MicroAccounts.App_Code;

namespace MicroAccounts
{
    public partial class AccountLedger : Form
    {
        int ledgerId = 0;
        string passedName = "";
        public AccountLedger(int id, string passName)
        {
            InitializeComponent();

            ledgerId = id;
            this.passedName = passName;
        }
        MicroAccountsEntities1 _entities;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLedgerName.Text == string.Empty && txtNotes.Text == string.Empty && txtOpeningBal.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtLedgerName, "Enter all details.");
                    txtLedgerName.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter all details.";
                }
                else if (txtLedgerName.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtLedgerName, "Enter ledger-name");
                    txtLedgerName.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter ledger-name.";
                }
                else if (txtOpeningBal.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtOpeningBal, "Enter opening balance.");
                    txtOpeningBal.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter opening balance.";
                }
                else
                {

                    if (btnCreate.Text == "Create")
                    {
                        _entities = new MicroAccountsEntities1();

                        var gId = Convert.ToInt32(cmbParentGroup.SelectedValue);
                        var checkData = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text.Trim().ToString() && x.groupId == gId).FirstOrDefault();

                        if (checkData != null)
                        {
                            MessageBox.Show("Ledger already Exists. Cannot create ledger with this name");
                            return;
                        }


                        tbl_AccLedger accLedgerData = new tbl_AccLedger();
                        accLedgerData.ledgerName = txtLedgerName.Text.Trim().ToString();
                        accLedgerData.groupId = Convert.ToInt32(cmbParentGroup.SelectedValue);
                        accLedgerData.opBalance = Convert.ToDecimal(txtOpeningBal.Text);

                        if (cmbDRCR.SelectedItem.ToString() == "Dr")
                        {
                            accLedgerData.opBalanceDC = "D";

                        }
                        else
                        {
                            accLedgerData.opBalanceDC = "C";
                        }

                        accLedgerData.notes = txtNotes.Text.Trim().ToString();

                        if (chkBankOrCash.Checked)
                        {
                            accLedgerData.type = 1;
                        }
                        else
                        {
                            accLedgerData.type = 0;
                        }
                        accLedgerData.createdDate = DateTime.Now;
                        _entities.tbl_AccLedger.Add(accLedgerData);
                        _entities.SaveChanges();

                        tbl_LedgerDetails ledgerDetails = new tbl_LedgerDetails();

                        if (txtAddress.Text.Trim() == string.Empty)
                        {
                            ledgerDetails.address = "--";
                        }
                        else
                        {
                            ledgerDetails.address = txtAddress.Text.Trim().ToString();
                        }
                        if (txtContact.Text == string.Empty)
                        {
                            ledgerDetails.contact = 0;
                        }
                        else
                        {
                            ledgerDetails.contact = Convert.ToDecimal(txtOpeningBal.Text);
                        }

                        ledgerDetails.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text && x.groupId == accLedgerData.groupId).FirstOrDefault().Id;
                        ledgerDetails.createdDate = DateTime.Now;
                        ledgerDetails.updateDate = DateTime.Now;

                        _entities.tbl_LedgerDetails.Add(ledgerDetails);
                        _entities.SaveChanges();

                        MessageBox.Show("Record Added Successfully");

                    }
                    else
                    {
                        //Update Code

                        _entities = new MicroAccountsEntities1();

                        var data = _entities.tbl_AccLedger.Where(x => x.Id == ledgerId).FirstOrDefault();

                        data.ledgerName = txtLedgerName.Text.Trim().ToString();
                        data.groupId = Convert.ToInt32(cmbParentGroup.SelectedValue);
                        data.opBalance = Convert.ToDecimal(txtOpeningBal.Text);

                        if (cmbDRCR.SelectedItem.ToString() == "Dr")
                        {
                            data.opBalanceDC = "D";

                        }
                        else
                        {
                            data.opBalanceDC = "C";
                        }

                        data.notes = txtNotes.Text.Trim().ToString();
                        data.updatedDate = DateTime.Now;

                        _entities.SaveChanges();

                        var dataLedgerDetails = _entities.tbl_LedgerDetails.Where(x => x.ledgerId == ledgerId).FirstOrDefault();

                        dataLedgerDetails.address = txtAddress.Text.Trim().ToString();
                        dataLedgerDetails.contact = Convert.ToDecimal(txtContact.Text.Trim());
                        dataLedgerDetails.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text && x.groupId == data.groupId).FirstOrDefault().Id;
                        dataLedgerDetails.updateDate = DateTime.Now;

                        _entities.SaveChanges();

                        MessageBox.Show("Record Updated Successfully");
                        SupplierDetails ss = new SupplierDetails();
                        ss.dataGridBind();
                    }
                    bindComboBox();
                    clearTextBox();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }
        public void clearTextBox()
        {
            txtLedgerName.Text = "";
            txtNotes.Text = "";
            txtOpeningBal.Text = "0.00";
            cmbDRCR.SelectedIndex = 1;
            cmbParentGroup.SelectedValue = 1;
            chkBankOrCash.Checked = false;
            txtContact.Text = "";
            txtAddress.Text = "";

            btnCreate.Text = "Create";

        }
        public void bindComboBox()
        {
            //Combo Box Binding

            _entities = new MicroAccountsEntities1();
            var datas = _entities.tbl_AccGroup;
            cmbParentGroup.DataSource = datas.ToList();
            cmbParentGroup.DisplayMember = "groupName";
            cmbParentGroup.ValueMember = "groupId";
        }

        private void AccountLedger_Load(object sender, EventArgs e)
        {
            clearTextBox();
            bindComboBox();

            _entities = new MicroAccountsEntities1();
            var itemCodeAutoComplete = _entities.tbl_AccGroup;
            cmbParentGroup.AutoCompleteCustomSource.Clear();
            foreach (var item in itemCodeAutoComplete)
            {
                cmbParentGroup.AutoCompleteCustomSource.Add(item.groupName.ToString());
            }

            _entities = new MicroAccountsEntities1();
           var  itemCodeAutoComplete1 = _entities.tbl_AccLedger;
            txtLedgerName.AutoCompleteCustomSource.Clear();
            foreach (var item in itemCodeAutoComplete1)
            {
                txtLedgerName.AutoCompleteCustomSource.Add(item.ledgerName.ToString());
            }

            if(this.passedName!=null)
            {
                txtLedgerName.Text = this.passedName.Trim();
            }
            if (ledgerId > 0)
            {

           
                btnCreate.Text = "Update";
                _entities = new MicroAccountsEntities1();
                var data = _entities.tbl_AccLedger.Where(x => x.Id == ledgerId).FirstOrDefault();

                txtLedgerName.Text = data.ledgerName;
                txtNotes.Text = data.notes.Trim();
                txtOpeningBal.Text = data.opBalance.ToString();

                cmbDRCR.SelectedValue = data.opBalanceDC;
                cmbParentGroup.SelectedValue = data.groupId;

                if (data.type == 1)
                {
                    chkBankOrCash.Checked = true;
                }
                else
                {
                    chkBankOrCash.Checked = false;
                }
                var contat = _entities.tbl_LedgerDetails.Where(x => x.ledgerId == data.Id).FirstOrDefault();
                var addres = _entities.tbl_LedgerDetails.Where(x => x.ledgerId == data.Id).FirstOrDefault();

                if (contat == null)
                    txtContact.Text = "";
                else
                    txtContact.Text = contat.contact.ToString();

                if (addres == null)
                    txtAddress.Text = "";
                else
                    txtAddress.Text = addres.address.Trim().ToString();

                if (txtContact.Text == "")
                    txtContact.Text = "--";

                if (txtAddress.Text == "")
                    txtAddress.Text = "--";
            }
        }

        private void cmbParentGroup_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cmbParentGroup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbParentGroup.Text.ToString() == "Sundry Creditors" || cmbParentGroup.Text.ToString() == "Sundry Debtors")
            {
                addressPanel.Enabled = true;
            }
            else
            {
                addressPanel.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ledgerId > 0)
            {
                SupplierDetails ss = new SupplierDetails();
                ss.dataGridBind();
            }
            this.Close();
        }

        private void cmbParentGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOpeningBal.Focus();
            }
        }

        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbParentGroup.Focus();
            }
        }

        private void txtOpeningBal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkBankOrCash.Focus();
            }
        }

        private void chkBankOrCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNotes.Focus();
            }
        }

        private void txtNotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtContact.Focus();
            }
        }

        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtLedgerName_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtLedgerName.Height;
            SidePanel2.Top = txtLedgerName.Top;

        }

        private void cmbParentGroup_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbParentGroup.Height;
            SidePanel2.Top = cmbParentGroup.Top;
        }

        private void cmbDRCR_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbDRCR.Height;
            SidePanel2.Top = cmbDRCR.Top;

        }

        private void txtOpeningBal_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtOpeningBal.Height;
            SidePanel2.Top = txtOpeningBal.Top;

        }

        private void chkBankOrCash_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = chkBankOrCash.Height;
            SidePanel2.Top = chkBankOrCash.Top;

        }

        private void txtNotes_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtNotes.Height;
            SidePanel2.Top = txtNotes.Top;

        }

        private void txtContact_Enter(object sender, EventArgs e)
        {
            //SidePanel2.Height = txtContact.Height;
            //SidePanel2.Top = txtContact.Top;
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            //SidePanel2.Height = txtAddress.Height;
            //SidePanel2.Top = txtAddress.Top;

        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void txtOpeningBal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxValidation val = new TextBoxValidation();

            val.onlyNumber(sender, e);
        }

        private void txtLedgerName_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBoxValidation val = new TextBoxValidation();

            val.textOnly(sender, e);
        }

        private void AccountLedger_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Closes the form when the ESC key is pressed
            }
        }
    }
}
