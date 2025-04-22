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
        AmtFormatting amtFormat = new AmtFormatting();

        public PurchaseDetails()
        {
            InitializeComponent();
        }

        private void ledgerNameAutoComplete()
        {
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
                HandleError("Error in ledgerNameAutoComplete()", ex);
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
                    model.date = item.date?.ToString("dd-MM-yyyy");
                    model.totalWeight = (item.totalWeight.ToString() + " " + item.unit.ToString()).ToString();
                    // model.totalWeight = item.totalWeight;
                    model.totalAmt = decimal.Parse(item.totalAmt.ToString());
                    model.totalAmtFormatted= amtFormat.comma(model.totalAmt);
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
            catch (Exception ex)
            {
                HandleError("Error in dataGridBind()", ex);
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
            catch (Exception ex)
            {
                HandleError("Error in dgPurchaseDetails_DoubleClick()", ex);
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
                                HandleError("Something went wrong:", ex);
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
                dgPurchaseDetails.AutoGenerateColumns = false;

                _entities = new MicroAccountsEntities1();

                string searchText = txtSearch.Text.Trim();
                const string dateFormat = "dd-MM-yyyy  hh:mm tt";

                var data = _entities.tbl_PurchaseMaster
                    .Where(p => p.refNo.Contains(searchText) || p.tbl_AccLedger.ledgerName.Contains(searchText))
                    .OrderByDescending(p => p.pId)
                    .AsEnumerable();

                var modelList = data.Select((item, index) => new PurchaseMasterVM
                {
                    rowNo = index + 1,
                    pId = item.pId,
                    refNo = item.refNo,
                    ledgerName = item.tbl_AccLedger?.ledgerName ?? "N/A",
                    date = item.date?.ToString("dd-MM-yyyy"),
                    totalWeight = $"{item.totalWeight} {item.unit}",
                    totalAmt = Convert.ToDecimal(amtFormat.comma(item.totalAmt)), // or use item.totalAmt.ToString("N2")
                    totalMelting = item.totalMelting,
                    createdDate = item.createdDate?.ToString(dateFormat),
                    updateDate = item.updateDate?.ToString(dateFormat)
                }).ToList();

                dgPurchaseDetails.DataSource = modelList;
                lblTotalRows.Text = modelList.Count.ToString();
            }
            catch (Exception ex)
            {
                HandleError("Something went wrong:", ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dgPurchaseDetails.AutoGenerateColumns = false;

                _entities = new MicroAccountsEntities1();

                DateTime fromDate = DateTime.ParseExact(dateTimePicker1.Text, "dd-MM-yyyy", null);
                DateTime toDate = DateTime.ParseExact(dateTimePicker2.Text, "dd-MM-yyyy", null);

                if (fromDate > toDate)
                {
                    MessageBox.Show("Invalid date entered. Select valid dates");
                    return;
                }

                string searchText = txtSearch.Text.Trim();

                var query = _entities.tbl_PurchaseMaster
                    .Where(x => x.date >= fromDate && x.date <= toDate);

                if (!string.IsNullOrEmpty(searchText))
                {
                    query = query.Where(x => x.tbl_AccLedger.ledgerName.Contains(searchText));
                }

                var rawData = query
                    .OrderByDescending(x => x.pId)
                    .ToList(); // now it's in memory, not SQL anymore

                int rowNo = 1;

                var purchaseMasterList = rawData.Select(item => new PurchaseMasterVM
                {
                    rowNo = rowNo++,  // auto-increment
                    pId = item.pId,
                    refNo = item.refNo,
                    ledgerName = item.tbl_AccLedger.ledgerName,
                    date = item.date?.ToString("dd-MM-yyyy"),
                    totalWeight = $"{item.totalWeight} {item.unit}",
                    totalAmt = item.totalAmt,
                    totalMelting = item.totalMelting,
                    createdDate = Convert.ToDateTime(item.createdDate).ToString("dd-MM-yyyy  hh:mm tt"),
                    updateDate = Convert.ToDateTime(item.updateDate).ToString("dd-MM-yyyy  hh:mm tt")
                }).ToList();

                dgPurchaseDetails.DataSource = purchaseMasterList;
                lblTotalRows.Text = purchaseMasterList.Count.ToString();

            }
            catch (Exception ex)
            {
                HandleError("Something went wrong:", ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            dateTimePicker1.Text = DateTime.Now.Date.ToString();
            dateTimePicker2.Text = DateTime.Now.Date.ToString();
            txtSearch.Text = "";
            dataGridBind();
        }

        private void HandleError(string context, Exception ex)
        {
            MessageBox.Show($"{context}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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