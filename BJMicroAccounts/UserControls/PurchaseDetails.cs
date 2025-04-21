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
using MicroAccounts.AccountsModuleClasses;

namespace MicroAccounts.UserControls
{
    public partial class PurchaseDetails : UserControl
    {
        MicroAccountsEntities1 _entities;



        public PurchaseDetails()
        {
            InitializeComponent();
        }

        private void ledgerNameAutoComplete()
        {
            //    _entities = new MicroAccountsEntities1();

            //    var gId = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Creditors").FirstOrDefault().groupId;

            //    var ledgerNameAutoComplete = _entities.tbl_AccLedger.Where(x => x.groupId == gId);
            //    txtSearch.AutoCompleteCustomSource.Clear();
            //    foreach (var item in ledgerNameAutoComplete)
            //    {
            //        txtSearch.AutoCompleteCustomSource.Add(item.ledgerName.ToString());
            //    }
            //}

            try
            {
                using (var entities = new MicroAccountsEntities1())
                {
                    // Query with null check
                    var gid = entities.tbl_AccGroup
                        .Where(x => x.groupName == "Sundry Creditors")
                        .FirstOrDefault()?.groupId;

                    // Check if gid is null
                    if (gid == null)
                    {
                        // Handle the case where no data is found
                        txtSearch.AutoCompleteCustomSource.Clear();
                        MessageBox.Show("No data found for 'Sundry Creditors' in the database.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Proceed with autocomplete if data is found
                    var ledgerNameAutoComplete = entities.tbl_AccLedger
                        .Where(x => x.groupId == gid)
                        .Select(x => x.ledgerName)
                        .ToList();

                    txtSearch.AutoCompleteCustomSource.Clear();
                    foreach (var item in ledgerNameAutoComplete)
                    {
                        txtSearch.AutoCompleteCustomSource.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed (e.g., using a logging framework like log4net)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PurchaseDetails_Load(object sender, EventArgs e)
        {
            ledgerNameAutoComplete();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";

            dataGridBind();
        }

        private void btnPurchaseEntry_Click(object sender, EventArgs e)
        {
            PurchaseMaster pm = new PurchaseMaster(0);
            pm.ShowDialog();
            dataGridBind();
        }
        AmtFormatting amtFormat = new AmtFormatting();
        void dataGridBind()
        {
            try
            {
                int rowNo = 1;
                dgPurchaseDetails.AutoGenerateColumns = false;

                _entities = new MicroAccountsEntities1();

                List<PurchaseMasterVM> modelList = new List<PurchaseMasterVM>();

                var data = _entities.tbl_PurchaseMaster.OrderByDescending(x => x.pId);

                foreach (var item in data)
                {
                    PurchaseMasterVM model = new PurchaseMasterVM();
                    model.rowNo = rowNo;
                    model.pId = item.pId;
                    model.refNo = item.refNo;
                    model.ledgerName = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName;
                    model.date = Convert.ToDateTime(item.date).ToString("dd-MM-yyyy");
                    model.totalWeight = (item.totalWeight.ToString() + " " + item.unit.ToString()).ToString();
                    // model.totalWeight = item.totalWeight;
                    model.totalAmt = Convert.ToDecimal(amtFormat.comma(item.totalAmt));
                    model.totalMelting = item.totalMelting;
                    model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");

                    if (item.updateDate == null)
                        model.updateDate = "--";
                    else
                        model.updateDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");

                    modelList.Add(model);

                    rowNo++;
                }

                dgPurchaseDetails.DataSource = modelList;
                lblTotalRows.Text = modelList.Count.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }
        private void dgPurchaseDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgPurchaseDetails.CurrentRow.Index != -1 && dgPurchaseDetails.CurrentRow.Cells[1].Value != null)
                {
                    var lID = Convert.ToInt32(dgPurchaseDetails.CurrentRow.Cells[0].Value);

                    PurchaseMaster acc = new PurchaseMaster(lID);
                    acc.ShowDialog();
                    dataGridBind();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void dgPurchaseDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (dgPurchaseDetails.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult myResult;
                myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (myResult == DialogResult.OK)
                {

                    using (var _entities = new MicroAccountsEntities1())
                    {
                        using (var transaction = _entities.Database.BeginTransaction())
                        {
                            try
                            {
                                var cellId = Convert.ToInt32(dgPurchaseDetails.CurrentRow.Cells[0].Value);


                                // Delete from Transaction Table
                                var transactionRecords = _entities.tbl_TransactionMaster
                                     .Where(x => x.voucherRefNo == cellId)
                                     .ToList();
                                if (transactionRecords.Any())
                                    _entities.tbl_TransactionMaster.RemoveRange(transactionRecords);

                                // Delete from Purchase Detail
                                var purchaseDetails = _entities.tbl_PurchaseDetail
                                    .Where(x => x.purchaseID == cellId)
                                    .ToList();
                                if (purchaseDetails != null)
                                    _entities.tbl_PurchaseDetail.RemoveRange(purchaseDetails);

                                // Delete from Purchase Master Table
                                var purchaseMaster = _entities.tbl_PurchaseMaster
                                    .FirstOrDefault(x => x.pId == cellId);
                                if (purchaseMaster != null)
                                    _entities.tbl_PurchaseMaster.Remove(purchaseMaster);

                                _entities.SaveChanges();
                                transaction.Commit(); // ✅ All good

                                MessageBox.Show("Record deleted");
                                dataGridBind();

                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback(); // ❌ Something failed, undo changes
                                MessageBox.Show("An error occurred: " + ex.Message);
                            }

                        }
                    }
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int rowNo = 1;
                dgPurchaseDetails.AutoGenerateColumns = false;

                _entities = new MicroAccountsEntities1();
                List<PurchaseMasterVM> modelList = new List<PurchaseMasterVM>();

                var data = _entities.tbl_PurchaseMaster.Where(x => x.refNo.Contains(txtSearch.Text) || x.tbl_AccLedger.ledgerName.Contains(txtSearch.Text)).OrderByDescending(x => x.pId);

                foreach (var item in data)
                {
                    PurchaseMasterVM model = new PurchaseMasterVM();
                    model.rowNo = rowNo;
                    model.pId = item.pId;
                    model.refNo = item.refNo;
                    model.ledgerName = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName;
                    model.date = Convert.ToDateTime(item.date).ToString("dd-MM-yyyy");
                    //model.totalWeight = item.totalWeight;
                    model.totalWeight = (item.totalWeight.ToString() + " " + item.unit.ToString()).ToString();
                    model.totalAmt = Convert.ToDecimal(amtFormat.comma(item.totalAmt));
                    model.totalMelting = item.totalMelting;
                    model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
                    model.updateDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");


                    modelList.Add(model);

                    rowNo++;
                }

                dgPurchaseDetails.DataSource = modelList;
                lblTotalRows.Text = modelList.Count.ToString();

            }
            catch (Exception x)
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int rowNo = 1;
                dgPurchaseDetails.AutoGenerateColumns = false;
                _entities = new MicroAccountsEntities1();

                List<PurchaseMasterVM> purchaseMasterList = new List<PurchaseMasterVM>();
                List<tbl_PurchaseMaster> data = new List<tbl_PurchaseMaster>();

                DateTime fromdate = DateTime.ParseExact(dateTimePicker1.Text, "dd-MM-yyyy", null);
                DateTime todate = DateTime.ParseExact(dateTimePicker2.Text, "dd-MM-yyyy", null);

                if (fromdate > todate)
                {
                    MessageBox.Show("Invalid date entered. Select valid dates");
                    return;
                }
                else
                {
                    if (txtSearch.Text == string.Empty)
                        data = _entities.tbl_PurchaseMaster.Where(x => x.date >= fromdate && x.date <= todate).OrderByDescending(x => x.pId).ToList();
                    else
                        data = _entities.tbl_PurchaseMaster.Where(x => x.date >= fromdate && x.date <= todate && x.tbl_AccLedger.ledgerName.Contains(txtSearch.Text.Trim().ToString())).OrderByDescending(x => x.pId).ToList();

                    foreach (var item in data)
                    {
                        PurchaseMasterVM model = new PurchaseMasterVM();
                        model.rowNo = rowNo;
                        model.pId = item.pId;
                        model.refNo = item.refNo;
                        model.ledgerName = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName;
                        model.date = Convert.ToDateTime(item.date).ToString("dd-MM-yyyy");
                        //model.totalWeight = item.totalWeight;
                        model.totalWeight = (item.totalWeight.ToString() + " " + item.unit.ToString()).ToString();
                        model.totalAmt = item.totalAmt;
                        model.totalMelting = item.totalMelting;
                        model.createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt");
                        model.updateDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt");

                        purchaseMasterList.Add(model);

                        rowNo++;
                    }

                    dgPurchaseDetails.DataSource = purchaseMasterList;
                    lblTotalRows.Text = purchaseMasterList.Count.ToString();
                }
            }
            catch (Exception x)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            dateTimePicker1.Text = DateTime.Now.Date.ToString();
            dateTimePicker2.Text = DateTime.Now.Date.ToString();
            txtSearch.Text = "";
            dataGridBind();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}