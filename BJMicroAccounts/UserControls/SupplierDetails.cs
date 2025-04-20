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
using MicroAccounts.ViewModel;

namespace MicroAccounts.UserControls
{
    public partial class SupplierDetails : UserControl
    {
        MicroAccountsEntities1 _entities;
        public SupplierDetails()
        {
            InitializeComponent();
        }

        public void dataGridBind()
        {
            int rowNo = 1;
            dgSupplierDetials.AutoGenerateColumns = false;

            _entities = new MicroAccountsEntities1();

            List<LedgerDetailsVM> ledgerDetailsListVM = new List<LedgerDetailsVM>();

            var data = _entities.tbl_LedgerDetails.Where(x => x.tbl_AccLedger.tbl_AccGroup.groupName == "Sundry Creditors").ToList();

            foreach (var item in data)
            {
                LedgerDetailsVM list = new LedgerDetailsVM();
                list.rowNo = rowNo;
                list.id = item.ledgerId;
                list.ledgerName = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName;

                var grpId = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().groupId;
                list.groupName = _entities.tbl_AccGroup.Where(x => x.groupId == grpId).FirstOrDefault().groupName.ToString();

                list.contact = item.contact;
                list.address = item.address;

                var drcr = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().opBalanceDC;

                if (drcr == "D")
                {
                    list.OpBalWithDC = "Dr " + _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().opBalance;
                }
                else
                {
                    list.OpBalWithDC = "Cr " + _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().opBalance;

                }

                ledgerDetailsListVM.Add(list);

                rowNo++;
            }

            dgSupplierDetials.DataSource = ledgerDetailsListVM;
            lblTotalRows.Text = ledgerDetailsListVM.Count.ToString();
        }
        private void ledgerNameAutoComplete()
        {
            //_entities = new MicroAccountsEntities1();

            //var gId = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Creditors").FirstOrDefault().groupId;

            //var ledgerNameAutoComplete = _entities.tbl_AccLedger.Where(x => x.groupId == gId);
            //txtLedgerName.AutoCompleteCustomSource.Clear();
            //foreach (var item in ledgerNameAutoComplete)
            //{
            //    txtLedgerName.AutoCompleteCustomSource.Add(item.ledgerName.ToString());
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
                        txtLedgerName.AutoCompleteCustomSource.Clear();
                        MessageBox.Show("No data found for 'Sundry Creditors' in the database.",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Proceed with autocomplete if data is found
                    var ledgerNameAutoComplete = entities.tbl_AccLedger
                        .Where(x => x.groupId == gid)
                        .Select(x => x.ledgerName)
                        .ToList();

                    txtLedgerName.AutoCompleteCustomSource.Clear();
                    foreach (var item in ledgerNameAutoComplete)
                    {
                        txtLedgerName.AutoCompleteCustomSource.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed (e.g., using a logging framework like log4net)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SupplierDetails_Load(object sender, EventArgs e)
        {
            dataGridBind();
            ledgerNameAutoComplete();
        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {

        }

        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
        }

        private void accGroupBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AccountLedger acc = new AccountLedger(0,"");
            acc.ShowDialog();
            dataGridBind();
        }

        private void dgSupplierDetials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgSupplierDetials.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        _entities = new MicroAccountsEntities1();

                        var cellId = Convert.ToInt32(dgSupplierDetials.CurrentRow.Cells[0].Value);

                        var selectedData1 = _entities.tbl_LedgerDetails.Where(x => x.ledgerId == cellId).FirstOrDefault();
                        var selectedData2 = _entities.tbl_AccLedger.Where(x => x.Id == cellId).FirstOrDefault();

                        if (selectedData1 != null)
                        {
                            _entities.tbl_LedgerDetails.Remove(selectedData1);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Record cannot be deleted.");
                        }
                        if (selectedData2 != null)
                        {
                            _entities.tbl_AccLedger.Remove(selectedData2);
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Record cannot be deleted.");
                        }

                       
                        

                        _entities.SaveChanges();
                        MessageBox.Show("Record deleted ");
                        dataGridBind();
                    }

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Record Cannot be deleted. Reference of this record is present in other entries");
            }
        }

        private void dgSupplierDetials_DoubleClick(object sender, EventArgs e)
        {
            if (dgSupplierDetials.CurrentRow.Index != -1)
            {

                var lID = Convert.ToInt32(dgSupplierDetials.CurrentRow.Cells[0].Value);
                
                AccountLedger acc = new AccountLedger(lID,"");
                acc.ShowDialog();
                dataGridBind();
            }
        }

        private void txtLedgerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLedgerName.Text = "";
            dataGridBind();
        }

        private void txtLedgerName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int rowNo = 1;

                dgSupplierDetials.AutoGenerateColumns = false;
                _entities = new MicroAccountsEntities1();

                List<LedgerDetailsVM> ledgerDetailsListVM = new List<LedgerDetailsVM>();
                
                List<tbl_LedgerDetails> data;

                if (txtLedgerName.Text == "")
                {
                    data = _entities.tbl_LedgerDetails.Where(x => x.tbl_AccLedger.tbl_AccGroup.groupName == "Sundry Debtors").ToList();
                }
                else
                {
                    data = _entities.tbl_LedgerDetails.Where(x => x.tbl_AccLedger.tbl_AccGroup.groupName == "Sundry Debtors" && (x.tbl_AccLedger.ledgerName.Contains(txtLedgerName.Text.Trim().ToString()))).ToList();

                }

                foreach (var item in data)
                {
                    LedgerDetailsVM list = new LedgerDetailsVM();
                    list.rowNo = rowNo;
                    list.id = item.ledgerId;
                    list.ledgerName = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName;

                    var grpId = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().groupId;
                    list.groupName = _entities.tbl_AccGroup.Where(x => x.groupId == grpId).FirstOrDefault().groupName.ToString();

                    list.contact = item.contact;
                    list.address = item.address;

                    var drcr = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().opBalanceDC;

                    if (drcr == "D")
                    {
                        list.OpBalWithDC = "Dr " + _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().opBalance;
                    }
                    else
                    {
                        list.OpBalWithDC = "Cr " + _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().opBalance;

                    }
                    ledgerDetailsListVM.Add(list);
                    rowNo++;
                }

                dgSupplierDetials.DataSource = ledgerDetailsListVM;
                lblTotalRows.Text = ledgerDetailsListVM.Count.ToString();
            }
            catch (Exception x)
            {

            }
        }
    }
}
