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

namespace MicroAccounts.Forms
{
    public partial class ItemCategoryMaster : Form
    {
        MicroAccountsEntities1 _entities;
        public ItemCategoryMaster()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void clear()
        {
            txtCategoryName.Text = "";
            txtPrefix.Text = "";
            panel3.Hide();
            btnCreate.Text = "Create";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == string.Empty && txtPrefix.Text == string.Empty)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCategoryName, "Enter all details.");
                txtPrefix.Focus();
                panel3.Visible = true;
                lblError.Text = "Enter all details.";
            }
            else if (txtCategoryName.Text == string.Empty)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCategoryName, "Enter Category Name.");
                txtCategoryName.Focus();
                panel3.Visible = true;
                lblError.Text = "Enter Category Name.";
            }
            else if (txtPrefix.Text == string.Empty)
            {

                errorProvider1.Clear();
                errorProvider1.SetError(txtPrefix, "Enter item Prefix.");
                txtPrefix.Focus();
                panel3.Visible = true;
                lblError.Text = "Enter item Prefix.";
            }
            else
            {
                if (btnCreate.Text == "Create")
                {
                    //Insert Code

                    _entities = new MicroAccountsEntities1();

                    tbl_CategoryMaster cm = new tbl_CategoryMaster();
                    cm.cName = txtCategoryName.Text.Trim().ToString();
                    cm.prefix = txtPrefix.Text.Trim().ToString();
                    cm.createdDate = DateTime.Now;
                    cm.updatedDate = DateTime.Now;
                    _entities.tbl_CategoryMaster.Add(cm);
                    _entities.SaveChanges();

                    MessageBox.Show("Record Successfull Saved");

                }
                else
                {
                    //Update Code

                    _entities = new MicroAccountsEntities1();
                    var catId = Convert.ToInt32(lblHiddenId.Text);
                    var data = _entities.tbl_CategoryMaster.Where(x => x.cId == catId).FirstOrDefault();

                    data.cName = txtCategoryName.Text.ToString();
                    data.prefix = txtPrefix.Text.ToString();
                    data.updatedDate = DateTime.Now;

                    _entities.SaveChanges();

                    MessageBox.Show("Record Updated Successfully");

                }
                clear();
                dataGridBind();
            }

        }

        private void dtCategoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dtCategoryList.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        //Delete Code
                        _entities = new MicroAccountsEntities1();

                        var cellId = Convert.ToInt32(dtCategoryList.CurrentRow.Cells[0].Value);
                        var selectedData = _entities.tbl_CategoryMaster.Where(x => x.cId == cellId).FirstOrDefault();

                        _entities.tbl_CategoryMaster.Remove(selectedData);

                        _entities.SaveChanges();
                        MessageBox.Show("Record deleted ");
                        dataGridBind();

                    }
                    else
                    {
                        //No delete
                    }

                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        void dataGridBind()
        {
            dtCategoryList.AutoGenerateColumns = false;
            int rowNo = 1;
            _entities = new MicroAccountsEntities1();

            List<CategoryMasterVM> modelList = new List<CategoryMasterVM>();

            var categoryData = _entities.tbl_CategoryMaster.ToList();

            foreach (var item in categoryData)
            {
                CategoryMasterVM model = new CategoryMasterVM();
                model.rowNo = rowNo;
                model.cId = item.cId;
                model.cName = item.cName;
                model.prefix = item.prefix;

                model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");

                if (item.updatedDate == null)
                    model.updatedDate = "--";
                else
                    model.updatedDate = Convert.ToDateTime(item.updatedDate).ToString("dd-MM-yyyy  hh:mm tt");


                modelList.Add(model);

                rowNo++;
            }

            dtCategoryList.DataSource = modelList;

            lblTotalRows.Text = modelList.Count.ToString();
        }

        private void ItemCategoryMaster_Load(object sender, EventArgs e)
        {
            txtCategoryName.Focus();
            dataGridBind();
        }

        private void dtCategoryList_DoubleClick(object sender, EventArgs e)
        {
            if (dtCategoryList.CurrentRow.Index != -1)
            {
                _entities = new MicroAccountsEntities1();

                var gID = Convert.ToInt32(dtCategoryList.CurrentRow.Cells[0].Value);

                var data = _entities.tbl_CategoryMaster.Where(x => x.cId == gID).FirstOrDefault();
                txtCategoryName.Text = lblhiddenCategoryName.Text = data.cName;
                txtPrefix.Text = data.prefix;
                lblHiddenId.Text = data.cId.ToString();

                btnCreate.Text = "Update";

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void txtCategoryName_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtCategoryName.Height;
            SidePanel2.Top = txtCategoryName.Top;
        }

        private void txtPrefix_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtPrefix.Height;
            SidePanel2.Top = txtPrefix.Top;
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrefix.Focus();
            }
        }

        private void txtPrefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void txtCategoryName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dtCategoryList.AutoGenerateColumns = false;
                int rowNo = 1;
                _entities = new MicroAccountsEntities1();

                List<CategoryMasterVM> modelList = new List<CategoryMasterVM>();
                List<tbl_CategoryMaster> categoryData;

                if (txtCategoryName.Text == "")
                {
                    categoryData = _entities.tbl_CategoryMaster.ToList();
                }
                else
                {
                    categoryData = _entities.tbl_CategoryMaster.Where(x=>x.cName.Contains(txtCategoryName.Text)).ToList();
                }

                if (categoryData.Count != 0)
                {

                    foreach (var item in categoryData)
                    {
                        CategoryMasterVM model = new CategoryMasterVM();
                        model.rowNo = rowNo;
                        model.cId = item.cId;
                        model.cName = item.cName;
                        model.prefix = item.prefix;

                        model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
                        model.updatedDate = Convert.ToDateTime(item.updatedDate).ToString("dd-MM-yyyy  hh:mm tt");

                        modelList.Add(model);

                        rowNo++;
                    }

                    dtCategoryList.DataSource = modelList;
                    lblTotalRows.Text = modelList.Count.ToString();
                }
            }
            catch(Exception x)
            {

            }
        }

        private void txtCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBoxValidation val = new TextBoxValidation();

            val.textOnly(sender, e);
        }
    }
}
