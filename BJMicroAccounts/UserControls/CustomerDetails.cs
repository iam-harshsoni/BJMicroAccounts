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
    public partial class CustomerDetails : UserControl
    {
        MicroAccountsEntities1 _entities;
        List<LedgerDetailsVM> ledgerDetailsListVM = new List<LedgerDetailsVM>();
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void dataGridBind()
        {
            try
            {
                int rowNo = 1;

                dgCustomerDetails.AutoGenerateColumns = false;
                _entities = new MicroAccountsEntities1();

                ledgerDetailsListVM = new List<LedgerDetailsVM>();

                var data = _entities.tbl_LedgerDetails.Where(x => x.tbl_AccLedger.tbl_AccGroup.groupName == "Sundry Debtors").ToList();

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

                dgCustomerDetails.DataSource = ledgerDetailsListVM;
                lblTotalRows.Text = ledgerDetailsListVM.Count.ToString();
            }
            catch (Exception x)
            {

            }
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            dataGridBind();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            AccountLedger acc = new AccountLedger(0, "");
            acc.ShowDialog();

        }


        private void dgCustomerDetails_DoubleClick(object sender, EventArgs e)
        {
            if (dgCustomerDetails.CurrentRow.Index != -1)
            {

                var lID = Convert.ToInt32(dgCustomerDetails.CurrentRow.Cells[0].Value);

                AccountLedger acc = new AccountLedger(lID, "");
                acc.ShowDialog();
            }
        }

        private void dgCustomerDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgCustomerDetails.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        _entities = new MicroAccountsEntities1();

                        var cellId = Convert.ToInt32(dgCustomerDetails.CurrentRow.Cells[0].Value);

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtLedgerName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int rowNo = 1;

                dgCustomerDetails.AutoGenerateColumns = false;
                _entities = new MicroAccountsEntities1();

                ledgerDetailsListVM = new List<LedgerDetailsVM>();

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

                dgCustomerDetails.DataSource = ledgerDetailsListVM;
                lblTotalRows.Text = ledgerDetailsListVM.Count.ToString();
            }
            catch (Exception x)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLedgerName.Text = "";
            dataGridBind();
        }
    }
}
