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
using MicroAccounts.ViewModel;
using MicroAccounts.App_Code;

namespace MicroAccounts
{
    public partial class Group : Form
    {
        public Group()
        {
            InitializeComponent();
        }

        MicroAccountsEntities1 _entities;

        private void Group_Load(object sender, EventArgs e)
        {
            DataGridSource();

            _entities = new MicroAccountsEntities1();
            var itemCodeAutoComplete = _entities.tbl_AccGroup;
            cmbParentGroup.AutoCompleteCustomSource.Clear();
            foreach (var item in itemCodeAutoComplete)
            {
                cmbParentGroup.AutoCompleteCustomSource.Add(item.groupName.ToString());
            }

            _entities = new MicroAccountsEntities1();
             itemCodeAutoComplete = _entities.tbl_AccGroup;
            txtGroupName.AutoCompleteCustomSource.Clear();
            foreach (var item in itemCodeAutoComplete)
            {
                txtGroupName.AutoCompleteCustomSource.Add(item.groupName.ToString());
            }

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtGroupName.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtGroupName, "Enter Group Name");
                    txtGroupName.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter Group Name.";
                }
                else
                {
                    if (btnCreate.Text == "Create")
                    {
                        _entities = new MicroAccountsEntities1();

                        var data = _entities.tbl_AccGroup;

                        foreach (var item in data)
                        {
                            if (item.groupName == txtGroupName.Text.Trim())
                            {
                                errorProvider1.Clear();
                                errorProvider1.SetError(txtGroupName, "Group Name already exists!");
                                txtGroupName.Focus();
                                panel3.Visible = true;
                                lblError.Text = "Group Name already exists!";
                                return;
                            }
                        }

                        _entities = new MicroAccountsEntities1();
                        tbl_AccGroup accGroup = new tbl_AccGroup();

                        var max_id = _entities.tbl_AccGroup.OrderByDescending(x=>x.id).FirstOrDefault().id;

                        accGroup.id = max_id + 1;

                        accGroup.groupName = txtGroupName.Text.Trim().ToString();
                        accGroup.parentId = Convert.ToInt32(cmbParentGroup.SelectedValue);
                        accGroup.createdDate = DateTime.Now;
                        accGroup.updateDate = DateTime.Now;

                        long ggId = Convert.ToInt32(cmbParentGroup.SelectedValue);

                        var affGross = _entities.tbl_AccGroup.Where(x => x.groupId == ggId).FirstOrDefault().affects_gross;

                        if (affGross == 1)
                        {
                            accGroup.affects_gross = 1;
                        }

                        else
                        {
                            accGroup.affects_gross = 0;
                        }
                         
                        _entities.tbl_AccGroup.Add(accGroup);
                        _entities.SaveChanges();
                        MessageBox.Show("Record Saved Successfully!");
                    }
                    else
                    {
                        _entities = new MicroAccountsEntities1();

                        var data = _entities.tbl_AccGroup;

                        foreach (var item in data)
                        {
                            if (item.groupName == txtGroupName.Text.Trim() && txtGroupName.Text != lblhiddenGName.Text)
                            {
                                errorProvider1.Clear();
                                errorProvider1.SetError(txtGroupName, "Group Name already exists!");
                                txtGroupName.Focus();
                                panel3.Visible = true;
                                lblError.Text = "Group Name already exists!";
                                return;
                            }
                        }

                        _entities = new MicroAccountsEntities1();
                        var gId = Convert.ToInt32(lblHiddenId.Text);
                        var dataToUpdate = _entities.tbl_AccGroup.Where(x => x.groupId == gId).FirstOrDefault();

                        dataToUpdate.groupName = txtGroupName.Text.Trim().ToString();
                        dataToUpdate.parentId = Convert.ToInt32(cmbParentGroup.SelectedValue);
                        dataToUpdate.updateDate = DateTime.Now;

                        _entities.SaveChanges();
                        MessageBox.Show("Record Updated Successfully!");
                    }
                    DataGridSource();
                    ClearTextBox();

                }
            }
            catch (Exception c)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        public void DataGridSource()
        {
            int rowNo = 1;
            dtGroupList.AutoGenerateColumns = false;
            _entities = new MicroAccountsEntities1();

            List<AccGroupVM> accList = new List<AccGroupVM>();

            var data = _entities.tbl_AccGroup;
            foreach (var item in data)
            {
                AccGroupVM accVM = new AccGroupVM();
                accVM.rowNo = rowNo;
                accVM.groupId = item.groupId;
                accVM.groupName = item.groupName.Trim();

                if (item.parentId > 0)
                    accVM.ParentGroupName = _entities.tbl_AccGroup.Where(x => x.id == item.parentId).FirstOrDefault().groupName;
                if (item.parentId <= 0)
                {
                    accVM.ParentGroupName = "--";
                }
               
                accVM.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");

                if (item.updateDate == null)
                    accVM.updateDate = "--";
                else
                    accVM.updateDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");


                accList.Add(accVM);
                rowNo++;
            }

            dtGroupList.DataSource = accList;

            //Combo Box Binding

            _entities = new MicroAccountsEntities1();
            var datas = _entities.tbl_AccGroup.ToList();

            cmbParentGroup.DataSource = datas.ToList();
            cmbParentGroup.DisplayMember = "groupName";
            cmbParentGroup.ValueMember = "groupId";

            lblTotalRows.Text = accList.Count.ToString();
        }

        public void ClearTextBox()
        {
            btnCreate.Text = "Create";
            txtGroupName.Text = "";
            cmbParentGroup.SelectedIndex = 0;
            panel3.Visible = false;
            errorProvider1.Clear();
        }

        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbParentGroup.Focus();
            }
        }

        private void cmbParentGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {


        }

        private void dtGroupList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtGroupList_DoubleClick(object sender, EventArgs e)
        {
            if (dtGroupList.CurrentRow.Index != -1)
            {
                _entities = new MicroAccountsEntities1();

                var gID = Convert.ToInt32(dtGroupList.CurrentRow.Cells["SrNo"].Value);

                var data = _entities.tbl_AccGroup.Where(x => x.groupId == gID).FirstOrDefault();
                txtGroupName.Text = lblhiddenGName.Text = data.groupName;
                cmbParentGroup.SelectedValue = data.parentId;
                lblHiddenId.Text = data.groupId.ToString();

                btnCreate.Text = "Update";

            }
        }

        private void dtGroupList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGroupList.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult myResult;
                myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (myResult == DialogResult.OK)
                {
                    _entities = new MicroAccountsEntities1();

                    var cellId = Convert.ToInt32(dtGroupList.CurrentRow.Cells["SrNo"].Value);
                    var selectedData = _entities.tbl_AccGroup.Where(x => x.groupId == cellId).FirstOrDefault();

                    _entities.tbl_AccGroup.Remove(selectedData);

                    _entities.SaveChanges();
                    MessageBox.Show("Record deleted ");
                    DataGridSource();
                }
                else
                {

                }
            }
        }

        private void txtGroupName_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtGroupName.Height;
            SidePanel2.Top = txtGroupName.Top;
        }

        private void cmbParentGroup_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbParentGroup.Height;
            SidePanel2.Top = cmbParentGroup.Top;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbParentGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxValidation val = new TextBoxValidation();

            val.textOnly(sender, e);
        }
    }
}
