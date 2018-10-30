using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroAccounts.Forms;
using BJMicroAccounts.Data;
using MicroAccounts.ViewModel;

namespace MicroAccounts.UserControls
{
    public partial class StockInventoryDetails : UserControl
    {
        public StockInventoryDetails()
        {
            InitializeComponent();
        }

        MicroAccountsEntities1 _entities;
        List<ItemMasterVM> modelList, updatedList;
        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void itemNameAutoComplete()
        {
            _entities = new MicroAccountsEntities1();
            var itemCodeAutoComplete = _entities.tbl_ItemMaster;
            txtLedgerName.AutoCompleteCustomSource.Clear();
            foreach (var item in itemCodeAutoComplete)
            {
                txtLedgerName.AutoCompleteCustomSource.Add(item.itemCode.ToString());
            }

        }

        private void StockInventoryDetails_Load(object sender, EventArgs e)
        {
            dataGridBind();
            itemNameAutoComplete();

            cmbKarat.SelectedIndex = 0;

            _entities = new MicroAccountsEntities1();

            var data = _entities.tbl_CategoryMaster.ToList();

            List<CategoryMasterVM> catList = new List<CategoryMasterVM>();
            CategoryMasterVM model = new CategoryMasterVM();

            model.cName = "--Select--";
            model.cId = -1;

            catList.Add(model);
            foreach (var item in data)
            {
                model = new CategoryMasterVM();
                model.cId = item.cId;
                model.cName = item.cName;

                catList.Add(model);
            }

            cmbCategory.DataSource = catList;
            cmbCategory.DisplayMember = "cName";
            cmbCategory.ValueMember = "cId";

        }

        void dataGridBind()
        {
            try
            {

                dgStockDetails.AutoGenerateColumns = false;
                int rowNos = 1;
                _entities = new MicroAccountsEntities1();

                List<ItemMasterVM> modelList = new List<ItemMasterVM>();

                var data = _entities.tbl_ItemMaster.ToList();

                foreach (var item in data)
                {
                    ItemMasterVM model = new ItemMasterVM();

                    model.rowNo = rowNos;
                    model.id = item.id;
                    model.categoryName = _entities.tbl_CategoryMaster.Where(x => x.cId == item.categoryId).FirstOrDefault().cName.ToString();
                    model.itemCode = item.itemCode;
                    model.photo = item.photo;

                    var itemDetail = _entities.tbl_StockItemDetails.Where(x => x.itemId == item.id).FirstOrDefault();

                    model.weight = (itemDetail.weight.ToString() + " " + itemDetail.unit.ToString()).ToString();
                    model.carret = itemDetail.carret;
                    model.qty = Convert.ToInt32(itemDetail.qty);
                    model.melting = itemDetail.melting;
                    model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");

                    if (item.updateDate == null)
                        model.updatedDate = "--";
                    else
                        model.updatedDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");


                    modelList.Add(model);
                    rowNos++;
                }

                dgStockDetails.DataSource = modelList;
                lblTotalRows.Text = modelList.Count.ToString();

                for (int i = 0; i < dgStockDetails.Rows.Count; i++)
                {
                    if (dgStockDetails.Columns[2] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgStockDetails.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }

                }
                dgStockDetails.RowTemplate.Height = 80;

            }
            catch (Exception x)
            {

            }
        }

        private void dgCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgStockDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgStockDetails.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult myResult;
                myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (myResult == DialogResult.OK)
                {
                    _entities = new MicroAccountsEntities1();

                    var cellId = Convert.ToInt32(dgStockDetails.CurrentRow.Cells[0].Value);
                    var selectedData1 = _entities.tbl_StockItemDetails.Where(x => x.itemId == cellId).FirstOrDefault();
                    var selectedData2 = _entities.tbl_ItemMaster.Where(x => x.id == cellId).FirstOrDefault();

                    if (selectedData1 != null)
                    {
                        _entities.tbl_StockItemDetails.Remove(selectedData1);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Record cannot be deleted.");
                    }
                    if (selectedData2 != null)
                    {
                        _entities.tbl_ItemMaster.Remove(selectedData2);
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong. Record cannot be deleted.");
                    }

                   
                    

                    _entities.SaveChanges();
                    MessageBox.Show("Record deleted ");
                    dataGridBind();
                }
                else
                {

                }
            }
        }

        private void dgStockDetails_DoubleClick(object sender, EventArgs e)
        {
            if (dgStockDetails.CurrentRow.Index != -1)
            {
                _entities = new MicroAccountsEntities1();

                var itemID = Convert.ToInt32(dgStockDetails.CurrentRow.Cells[0].Value);

                Item it = new Item(itemID);
                it.ShowDialog();
                dataGridBind();
            }
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            Item it = new Item(0);
            it.ShowDialog();
            dataGridBind();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            ItemCategoryMaster cm = new ItemCategoryMaster();
            cm.ShowDialog();
            dataGridBind();
        }

        private void txtLedgerName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dgStockDetails.AutoGenerateColumns = false;
                int rowNos = 1;
                _entities = new MicroAccountsEntities1();

                List<tbl_ItemMaster> data;

                if (txtLedgerName.Text == "")
                {
                    data = _entities.tbl_ItemMaster.ToList();
                }
                else
                {
                    data = _entities.tbl_ItemMaster.Where(x => x.itemCode.Contains(txtLedgerName.Text.Trim().ToString())).ToList();
                }

                modelList = new List<ItemMasterVM>();
                foreach (var item in data)
                {
                    ItemMasterVM model = new ItemMasterVM();

                    model.rowNo = rowNos;
                    model.id = item.id;
                    model.categoryName = _entities.tbl_CategoryMaster.Where(x => x.cId == item.categoryId).FirstOrDefault().cName.ToString();
                    model.itemCode = item.itemCode;
                    model.photo = item.photo;

                    var itemDetail = _entities.tbl_StockItemDetails.Where(x => x.itemId == item.id).FirstOrDefault();

                    model.weight = (itemDetail.weight.ToString() + " " + itemDetail.unit.ToString()).ToString();
                    model.carret = itemDetail.carret;
                    model.qty = Convert.ToInt32(itemDetail.qty);
                    model.melting = itemDetail.melting;
                    model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
                    model.updatedDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");

                    modelList.Add(model);
                    rowNos++;
                }

                dgStockDetails.DataSource = modelList;
                lblTotalRows.Text = modelList.Count.ToString();

                for (int i = 0; i < dgStockDetails.Rows.Count; i++)
                {
                    if (dgStockDetails.Columns[2] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgStockDetails.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }

                }
                dgStockDetails.RowTemplate.Height = 80;
            }
            catch (Exception x)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dgStockDetails.AutoGenerateColumns = false;
                int rowNos = 1;
                _entities = new MicroAccountsEntities1();

                modelList = new List<ItemMasterVM>();

                List<tbl_ItemMaster> data = new List<tbl_ItemMaster>();

                if (cmbCategory.SelectedIndex == 0 && txtLedgerName.Text == string.Empty && cmbKarat.SelectedIndex == 0)
                {
                    data = _entities.tbl_ItemMaster.ToList();
                }
                else
                {
                    var catId = Convert.ToInt32(cmbCategory.SelectedValue);
                    var carrId = Convert.ToInt32(cmbKarat.Text);
                    data = _entities.tbl_ItemMaster.Where(x => x.categoryId == catId && x.itemCode.Contains(txtLedgerName.Text) && x.tbl_StockItemDetails.FirstOrDefault().carret == carrId).ToList();
                }

                foreach (var item in data)
                {
                    ItemMasterVM model = new ItemMasterVM();

                    model.rowNo = rowNos;
                    model.id = item.id;
                    model.categoryName = _entities.tbl_CategoryMaster.Where(x => x.cId == item.categoryId).FirstOrDefault().cName.ToString();
                    model.itemCode = item.itemCode;
                    model.photo = item.photo;

                    var itemDetail = _entities.tbl_StockItemDetails.Where(x => x.itemId == item.id).FirstOrDefault();

                    model.weight = (itemDetail.weight.ToString() + " " + itemDetail.unit.ToString()).ToString();
                    model.carret = itemDetail.carret;
                    model.qty = Convert.ToInt32(itemDetail.qty);
                    model.melting = itemDetail.melting;
                    model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
                    model.updatedDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");


                    modelList.Add(model);
                    rowNos++;
                }

                dgStockDetails.DataSource = modelList;

                for (int i = 0; i < dgStockDetails.Rows.Count; i++)
                {
                    if (dgStockDetails.Columns[2] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgStockDetails.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }

                }
                dgStockDetails.RowTemplate.Height = 80;
            }
            catch (Exception x)
            {

            }
        }

        private void cmbKarat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgStockDetails.AutoGenerateColumns = false;
                int rowNos = 1;
                _entities = new MicroAccountsEntities1();

                modelList = new List<ItemMasterVM>();

                List<tbl_ItemMaster> data;

                if (cmbKarat.SelectedIndex == 0)
                {
                    data = _entities.tbl_ItemMaster.ToList();
                }
                else
                {
                    var carrId = Convert.ToInt32(cmbKarat.Text);
                    data = _entities.tbl_ItemMaster.Where(x => x.tbl_StockItemDetails.FirstOrDefault().carret == carrId).ToList();
                }

                foreach (var item in data)
                {
                    ItemMasterVM model = new ItemMasterVM();

                    model.rowNo = rowNos;
                    model.id = item.id;
                    model.categoryName = _entities.tbl_CategoryMaster.Where(x => x.cId == item.categoryId).FirstOrDefault().cName.ToString();
                    model.itemCode = item.itemCode;
                    model.photo = item.photo;

                    var itemDetail = _entities.tbl_StockItemDetails.Where(x => x.itemId == item.id).FirstOrDefault();

                    model.weight = (itemDetail.weight.ToString() + " " + itemDetail.unit.ToString()).ToString();
                    model.carret = itemDetail.carret;
                    model.qty = Convert.ToInt32(itemDetail.qty);
                    model.melting = itemDetail.melting;
                    model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
                    model.updatedDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");


                    modelList.Add(model);
                    rowNos++;
                }

                dgStockDetails.DataSource = modelList;

                for (int i = 0; i < dgStockDetails.Rows.Count; i++)
                {
                    if (dgStockDetails.Columns[2] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgStockDetails.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }

                }
                dgStockDetails.RowTemplate.Height = 80;
            }
            catch (Exception x)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLedgerName.Text = "";
            cmbKarat.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            dataGridBind();
        }

        private void txtLedgerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgStockDetails.AutoGenerateColumns = false;
                int rowNos = 1;
                _entities = new MicroAccountsEntities1();

                modelList = new List<ItemMasterVM>();

                List<tbl_ItemMaster> data;

                if (cmbCategory.SelectedIndex == 0)
                {
                    data = _entities.tbl_ItemMaster.ToList();
                }
                else
                {
                    var catId = Convert.ToInt32(cmbCategory.SelectedValue);
                    data = _entities.tbl_ItemMaster.Where(x => x.categoryId == catId).ToList();
                }

                foreach (var item in data)
                {
                    ItemMasterVM model = new ItemMasterVM();

                    model.rowNo = rowNos;
                    model.id = item.id;
                    model.categoryName = _entities.tbl_CategoryMaster.Where(x => x.cId == item.categoryId).FirstOrDefault().cName.ToString();
                    model.itemCode = item.itemCode;
                    model.photo = item.photo;

                    var itemDetail = _entities.tbl_StockItemDetails.Where(x => x.itemId == item.id).FirstOrDefault();

                    model.weight = (itemDetail.weight.ToString() + " " + itemDetail.unit.ToString()).ToString();
                    model.carret = itemDetail.carret;
                    model.qty = Convert.ToInt32(itemDetail.qty);
                    model.melting = itemDetail.melting;
                    model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
                    model.updatedDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");


                    modelList.Add(model);
                    rowNos++;
                }

                dgStockDetails.DataSource = modelList;

                for (int i = 0; i < dgStockDetails.Rows.Count; i++)
                {
                    if (dgStockDetails.Columns[2] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dgStockDetails.Columns[2]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }

                }
                dgStockDetails.RowTemplate.Height = 80;
            }
            catch (Exception x)
            {

            }
        }
    }
}