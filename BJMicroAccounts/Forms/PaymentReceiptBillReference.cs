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
using MicroAccounts.AccountsModuleClasses;

namespace MicroAccounts.Forms
{
    public partial class PaymentReceiptBillReference : Form
    {
        private int passedVoucherType = 0, passedLedgerId = 0, datagridId = 0;

        private long passedVoucherNo = 0;

        private List<long?> idPassedToCmbArray = new List<long?>();

        private decimal? paymentDetailsTotalAmt = 0;                                        //if any entry of bill is there in payment detail than calculate total amt paid for difference in amt
        private decimal? passedAmt, totalAmtPaymentDetails = 0;                     //totalamtpaydetails is variable to check while edit if there is any data present in the paymentdetail table.

        private bool deleteDataGridRow = false, comestoUpdate = false;

        MicroAccountsEntities1 _entities;

        public PaymentReceiptBillReference(int type, int ledgerId, decimal amt, long passedVoucherNo)   //voucher type   1:payment  2:Receipt
        {
            InitializeComponent();

            this.passedVoucherType = type;
            this.passedLedgerId = ledgerId;
            this.passedAmt = amt;

            this.passedVoucherNo = passedVoucherNo;
        }

        private void cmbBInd(List<long?> val)
        {

            _entities = new MicroAccountsEntities1();

            // var idss = _entities.tbl_PurchaseMaster.Where(x => x.ledgerId == passedLedgerId).FirstOrDefault().pId;
            // var checkBillNo=_entities.tbl_PaymentDetails.Where(x=>x.purchaseId==)

            if (passedVoucherType == 1)
            {
                #region for purchase(Payment)
                List<tbl_PurchaseMaster> data;

                if (val.Contains(0) || val.Count == 0)
                {
                    data = new List<tbl_PurchaseMaster>();
                    data = _entities.tbl_PurchaseMaster.Where(x => x.ledgerId == passedLedgerId).ToList();
                }
                else
                {
                    data = new List<tbl_PurchaseMaster>();
                    data = _entities.tbl_PurchaseMaster.Where(x => x.ledgerId == passedLedgerId && !val.Contains(x.pId)).ToList();
                }

                List<PurchaseMasterVM> modelLst = new List<PurchaseMasterVM>();

                PurchaseMasterVM model = new PurchaseMasterVM();
                model.combineRefNo = "--Select--";
                modelLst.Add(model);

                foreach (var item in data)
                {

                    var dataPaymentDetails = _entities.tbl_EntryDetails.Where(x => x.purchaseSalesIds == item.pId).ToList();

                    foreach (var items in dataPaymentDetails)
                    {
                        paymentDetailsTotalAmt += items.amtPaid;
                    }

                    if ((item.totalAmt - paymentDetailsTotalAmt) >= 0)
                    {
                        model = new PurchaseMasterVM();

                        model.pId = item.pId;
                        model.combineRefNo = "Ref. No: " + item.refNo + "      |      Amount: " + (item.totalAmt - paymentDetailsTotalAmt);
                        modelLst.Add(model);
                    }
                    paymentDetailsTotalAmt = 0;
                }

                cmbBillRef.DataSource = modelLst;
                cmbBillRef.DisplayMember = "combineRefNo";
                cmbBillRef.ValueMember = "pId";
                #endregion 
            }
            else
            {
                #region for Sales(Receipt)

                List<tbl_SalesMaster> data;

                if (val.Contains(0) || val.Count == 0)
                {
                    data = new List<tbl_SalesMaster>();
                    data = _entities.tbl_SalesMaster.Where(x => x.ledgerId == passedLedgerId).ToList();
                }
                else
                {
                    data = new List<tbl_SalesMaster>();
                    data = _entities.tbl_SalesMaster.Where(x => x.ledgerId == passedLedgerId && !val.Contains(x.sId)).ToList();
                }

                List<PurchaseMasterVM> modelLst = new List<PurchaseMasterVM>();

                PurchaseMasterVM model = new PurchaseMasterVM();
                model.combineRefNo = "--Select--";
                modelLst.Add(model);

                foreach (var item in data)
                {

                    var dataPaymentDetails = _entities.tbl_EntryDetails.Where(x => x.purchaseSalesIds == item.sId).ToList();

                    foreach (var items in dataPaymentDetails)
                    {
                        paymentDetailsTotalAmt += items.amtPaid;
                    }

                    if ((item.totalAmt - paymentDetailsTotalAmt) >= 0)
                    {
                        model = new PurchaseMasterVM();

                        model.pId = item.sId;
                        model.combineRefNo = "Ref. No: " + item.billNo + "      |      Amount: " + (item.totalAmt - paymentDetailsTotalAmt);
                        modelLst.Add(model);
                    }
                    paymentDetailsTotalAmt = 0;
                }

                cmbBillRef.DataSource = modelLst;
                cmbBillRef.DisplayMember = "combineRefNo";
                cmbBillRef.ValueMember = "pId";

                #endregion
            }
        }

        private void PaymentReceieptBillReference_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRefType.SelectedIndex == 1)
            {
                cmbBillRef.Enabled = true;
            }
            else
            {
                cmbBillRef.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in dgBillRef.Rows)
                {
                    if (Convert.ToString(dr.Cells[0].Value) != string.Empty)
                    {
                        _entities = new MicroAccountsEntities1();

                        tbl_EntryDetails pd = new tbl_EntryDetails();

                        // var vNo = _entities.tbl_Payment.OrderByDescending(x => x.voucherRefNo).FirstOrDefault().voucherRefNo;

                        int pId = Convert.ToInt32(dr.Cells[0].Value);

                        pd.voucherRefNo = passedVoucherNo;
                        pd.purchaseSalesIds = pId;
                        pd.amtPaid = Convert.ToDecimal(dr.Cells[4].Value);
                        pd.createdDate = DateTime.Now;
                        pd.updatedDate = DateTime.Now;

                        _entities.tbl_EntryDetails.Add(pd);
                        _entities.SaveChanges();

                        this.Close();

                        comestoUpdate = false;
                    }
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void PaymentReceiptBillReference_Load(object sender, EventArgs e)
        {
            try
            {
                // if (passedVoucherType == 1)
                {
                    //payment mate 
                    _entities = new MicroAccountsEntities1();
                    var isDataPresent = _entities.tbl_EntryDetails.Where(x => x.voucherRefNo == this.passedVoucherNo).FirstOrDefault();

                    if (isDataPresent == null)
                    {

                        cmbBillRef.SelectedIndex = -1;


                        cmbBInd(idPassedToCmbArray);
                    }
                    else
                    {
                        AmtFormatting amtFormat = new AmtFormatting();

                        comestoUpdate = true;
                        cmbRefType.SelectedIndex = 1;

                        idPassedToCmbArray = new List<long?>();
                        idPassedToCmbArray.Add(0);

                        cmbBInd(idPassedToCmbArray);  //calling combobox method

                        btnCreate.Text = "Update";
                        _entities = new MicroAccountsEntities1();

                        var data = _entities.tbl_EntryDetails.Where(x => x.voucherRefNo == this.passedVoucherNo).ToList();

                        int id = 1;
                        idPassedToCmbArray = new List<long?>();
                        foreach (var item in data)
                        {
                            idPassedToCmbArray.Add(item.purchaseSalesIds);
                            // paymentDetailsTotalAmt += item.amtPaid;

                            var billNo = _entities.tbl_PurchaseMaster.Where(x => x.pId == item.purchaseSalesIds).FirstOrDefault();

                            dgBillRef.Rows.Add(
                              item.purchaseSalesIds,
                              "#",
                                billNo.refNo,
                               billNo.date,
                               amtFormat.comma(item.amtPaid),
                                item.pDetailsId
                                );

                            id = id + 1;
                        }
                        datagridId = data.Count;
                        lblRows.Text = datagridId.ToString() + " Rows";
                         
                    }


                }
                //else
                {
                    //receipt mate
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void cmbRefType_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbRefType.Height;
            SidePanel2.Top = cmbRefType.Top;

        }

        private void cmbBillRef_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbBillRef.Height;
            SidePanel2.Top = cmbBillRef.Top;

        }

        private void cmbRefType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRefType.Focus();
            }
        }

        private void cmbBillRef_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbBillRef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void dgBillRef_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgBillRef.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        int id = Convert.ToInt32(dgBillRef.CurrentRow.Cells[5].Value);

                        var checkAvailData = _entities.tbl_EntryDetails.Where(x => x.pDetailsId == id).ToList();

                        if (checkAvailData != null)
                        {
                            foreach (var item in checkAvailData)
                            {
                                _entities.tbl_EntryDetails.Remove(item);
                                _entities.SaveChanges();
                            }

                        }

                        foreach (DataGridViewCell oneCell in dgBillRef.SelectedCells)
                        {
                            passedAmt = Convert.ToDecimal(dgBillRef.Rows[oneCell.RowIndex].Cells[4].Value);

                            idPassedToCmbArray.Remove(Convert.ToInt32(dgBillRef.Rows[oneCell.RowIndex].Cells[0].Value));

                            cmbBInd(idPassedToCmbArray);

                            if (oneCell.Selected)
                                dgBillRef.Rows.RemoveAt(oneCell.RowIndex);

                            deleteDataGridRow = true;
                            datagridId--;
                            lblRows.Text = datagridId.ToString() + " Rows";  //Number of rows showing label
                        }

                    }
                }
            }
            catch (Exception c)
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbBillRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBillRef.SelectedIndex > 0)
            {
                deleteDataGridRow = false;
                dataBind();

            }
        }

        private void dataBind()
        {
            try
            {
                //  if (dgBillRef.Rows.Count > 0)
                {
                    int count = 0;
                    var id = Convert.ToInt32(cmbBillRef.SelectedValue);
                    //int checkDatagridId = Convert.ToInt32(dgBillRef.Rows[datagridId].Cells[0].Value);

                    foreach (DataGridViewRow dr in dgBillRef.Rows)
                    {
                        if (Convert.ToInt32(dr.Cells[0].Value) == id)
                        {
                            count = 1;
                        }
                    }

                    if (count != 1 && !deleteDataGridRow)
                    {
                        if (passedAmt > 0)
                        {
                            if (datagridId == 0)
                            {
                                idPassedToCmbArray = new List<long?>();
                            }

                            _entities = new MicroAccountsEntities1();
                            if (passedVoucherType == 1)
                            {
                                #region for Purchase(Payment)

                                var data = _entities.tbl_PurchaseMaster.Where(x => x.pId == id).FirstOrDefault();
                                PurchaseMasterVM pvm = new PurchaseMasterVM();

                                pvm.IdForGrid = data.pId;
                                pvm.refNoBillNoForGrid = data.refNo;

                                var checkPayDetailsData = _entities.tbl_EntryDetails.Where(x => x.purchaseSalesIds == id).ToList();

                                if (checkPayDetailsData != null)
                                {
                                    foreach (var item in checkPayDetailsData)
                                    {
                                        totalAmtPaymentDetails += item.amtPaid;
                                    }

                                    totalAmtPaymentDetails = data.totalAmt - totalAmtPaymentDetails;
                                }
                                else
                                {
                                    totalAmtPaymentDetails = data.totalAmt;

                                }
                                pvm.totalAmt = totalAmtPaymentDetails;

                                dgBillRef.Rows.Add(pvm);

                                dgBillRef.Rows[datagridId].Cells[0].Value = data.pId;
                                dgBillRef.Rows[datagridId].Cells[1].Value = "#";
                                dgBillRef.Rows[datagridId].Cells[2].Value = data.refNo;
                                dgBillRef.Rows[datagridId].Cells[3].Value = data.date;

                                if (totalAmtPaymentDetails > passedAmt)
                                {
                                    dgBillRef.Rows[datagridId].Cells[4].Value = passedAmt;
                                }

                                else if (totalAmtPaymentDetails < passedAmt)
                                {
                                    dgBillRef.Rows[datagridId].Cells[4].Value = totalAmtPaymentDetails;


                                    idPassedToCmbArray.Add(data.pId);
                                    cmbBInd(idPassedToCmbArray);
                                }
                                else if (totalAmtPaymentDetails == passedAmt)
                                {
                                    dgBillRef.Rows[datagridId].Cells[4].Value = passedAmt;

                                    idPassedToCmbArray.Add(data.pId);
                                    cmbBInd(idPassedToCmbArray);
                                }

                                passedAmt = passedAmt - Convert.ToDecimal(dgBillRef.Rows[datagridId].Cells[4].Value);

                                datagridId++;

                                lblRows.Text = datagridId.ToString() + " Rows";  //Number of rows showing label

                                count = 0;

                                #endregion
                            }
                            else if (passedVoucherType == 2)
                            {
                                #region for Sales(Receipt)

                                var data = _entities.tbl_SalesMaster.Where(x => x.sId == id).FirstOrDefault();
                                SalesMasterVM pvm = new SalesMasterVM();

                                pvm.IdForGrid = data.sId;
                                pvm.refNoBillNoForGrid = data.billNo;

                                var checkPayDetailsData = _entities.tbl_EntryDetails.Where(x => x.purchaseSalesIds == id).ToList();

                                if (checkPayDetailsData != null)
                                {
                                    foreach (var item in checkPayDetailsData)
                                    {
                                        totalAmtPaymentDetails += item.amtPaid;
                                    }

                                    totalAmtPaymentDetails = data.totalAmt - totalAmtPaymentDetails;
                                }
                                else
                                {
                                    totalAmtPaymentDetails = data.totalAmt;

                                }
                                pvm.totalAmt = totalAmtPaymentDetails;

                                dgBillRef.Rows.Add(pvm);

                                dgBillRef.Rows[datagridId].Cells[0].Value = data.sId;
                                dgBillRef.Rows[datagridId].Cells[1].Value = "#";
                                dgBillRef.Rows[datagridId].Cells[2].Value = data.billNo;
                                dgBillRef.Rows[datagridId].Cells[3].Value = data.date;

                                if (totalAmtPaymentDetails > passedAmt)
                                {
                                    dgBillRef.Rows[datagridId].Cells[4].Value = passedAmt;
                                }

                                else if (totalAmtPaymentDetails < passedAmt)
                                {
                                    dgBillRef.Rows[datagridId].Cells[4].Value = totalAmtPaymentDetails;


                                    idPassedToCmbArray.Add(data.sId);
                                    cmbBInd(idPassedToCmbArray);
                                }
                                else if (totalAmtPaymentDetails == passedAmt)
                                {
                                    dgBillRef.Rows[datagridId].Cells[4].Value = passedAmt;

                                    idPassedToCmbArray.Add(data.sId);
                                    cmbBInd(idPassedToCmbArray);
                                }

                                passedAmt = passedAmt - Convert.ToDecimal(dgBillRef.Rows[datagridId].Cells[4].Value);

                                datagridId++;

                                lblRows.Text = datagridId.ToString() + " Rows";  //Number of rows showing label

                                count = 0;

                                #endregion
                            }
                        }
                        //else
                        //{
                        //    MessageBox.Show("Something went wrong. Cannot add this row.");
                        //}
                    }
                    //else
                    //{
                    //    MessageBox.Show("Cannot add same row.");
                    //}
                }
            }
            catch (Exception x)
            {

            }
        }
    }
}
