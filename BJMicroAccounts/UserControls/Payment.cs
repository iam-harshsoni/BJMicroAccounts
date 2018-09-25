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
using MicroAccounts.AccountsModuleClasses;
using MicroAccounts.ViewModel;
using MicroAccounts.Forms;
using MicroAccounts.App_Code;

namespace MicroAccounts.UserControls
{
    public partial class Payment : UserControl
    {
        MicroAccountsEntities1 _entities;
        private long updateVouId = 0;    //Voucher id for update operation   
        private int passedVoucherType = 0;    // voucher type passed from main dashboard 

        private long paymentId = 0;

        /* Creating all this below mention transaction in the same one form only.
         * 
         * type 1:Payment
         * type 2:Receipt
         * type 3:Journal
         * type 4:Contra
         * 
         * */
        public Payment(int voucherType)
        {
            InitializeComponent();
            this.passedVoucherType = voucherType;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            try
            {
                datagridBind();
                bindDrCMB();
                clear();
                cmbLedgerCR.Enabled = false;

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";

                if (passedVoucherType == 1) //Payment
                {
                    lblLedgerDr.Text = "Ledger (Dr)";
                    lblLedgerCR.Text = "Ledger (Cr)";
                    lblDetailsGrid.Text = "Payment Details";
                }
                else if (passedVoucherType == 2)//Receipt
                {
                    lblLedgerDr.Text = "Ledger (Cr)";
                    lblLedgerCR.Text = "Ledger (Dr)";
                    lblDetailsGrid.Text = "Receipt Details";
                }
                else if (passedVoucherType == 3) //Journal
                {
                    lblLedgerDr.Text = "Ledger (Dr)";
                    lblLedgerCR.Text = "Ledger (Cr)";
                    lblNoteForAmt.Visible = false;
                    lblDetailsGrid.Text = "Journal Details";
                }
                else // Contra
                {
                    lblLedgerDr.Text = "Ledger (Cr)";
                    lblLedgerCR.Text = "Ledger (Dr)";
                    lblNoteForAmt.Visible = false;
                    lblDetailsGrid.Text = "Contra Details";
                }
            }
            catch (Exception x)
            {
            }
        }

        void bindCrCMB(string LedgerName)
        {
            if (passedVoucherType == 1 || passedVoucherType == 2) //Payment & Receipt
            {
                #region Payment _Receipt_Cr_CMB_Bind

                _entities = new MicroAccountsEntities1();

                var grpIdCre = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Creditors").FirstOrDefault().groupId;
                var grpIdDeb = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Debtors").FirstOrDefault().groupId;

                var data1 = _entities.tbl_AccLedger.Where(x => x.ledgerName != LedgerName && x.groupId == grpIdCre || x.groupId == grpIdDeb && x.type == 0).OrderBy(x => x.ledgerName).ToList();

                List<AccLedgerVm> modelList = new List<AccLedgerVm>();

                AccLedgerVm select = new AccLedgerVm();   //for adding --select-- at 0'th pos in both cmb
                select.Id = 0;
                select.ledgerNameWithCreditors = "--Select--";
                modelList.Add(select);

                foreach (var item in data1)
                {
                    AccLedgerVm acc = new AccLedgerVm();
                    acc.Id = item.Id;
                    acc.ledgerNameWithCreditors = item.ledgerName;
                    modelList.Add(acc);
                }

                var data2 = _entities.tbl_AccLedger.Where(x => x.ledgerName != LedgerName && x.type == 1).OrderBy(x => x.ledgerName).ToList();

                foreach (var item in data2)
                {
                    AccLedgerVm acc = new AccLedgerVm();
                    acc.Id = item.Id;
                    acc.ledgerNameWithCreditors = item.ledgerName;
                    modelList.Add(acc);
                }

                //  modelList = modelList.OrderBy(x => x.ledgerNameWithCreditors).ToList();

                /*cmb Datasource does not accepts modellist with orderby 
                clause so we have to save modellist with orderby clause 
                in the modellist and the pass the model list to the 
                cmb datasouce.*/

                cmbLedgerCR.DataSource = modelList;
                cmbLedgerCR.DisplayMember = "ledgerNameWithCreditors";
                cmbLedgerCR.ValueMember = "Id";

                cmbLedgerCR.AutoCompleteCustomSource.Clear();

                foreach (var item in modelList.OrderBy(x => x.ledgerNameWithCreditors))
                {
                    cmbLedgerCR.AutoCompleteCustomSource.Add(item.ledgerNameWithCreditors.ToString());
                }

                cmbLedgerCR.Text = "";
                cmbLedgerCR.SelectedIndex = 0;
                #endregion
            }

            else if (passedVoucherType == 3) //Journal
            {
                #region Journal_CR_CMB_Bind
                _entities = new MicroAccountsEntities1();

                var grpIdCre = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Creditors").FirstOrDefault().groupId;
                var grpIdDeb = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Debtors").FirstOrDefault().groupId;

                var data1 = _entities.tbl_AccLedger.Where(x => x.ledgerName != LedgerName && x.groupId == grpIdCre || x.groupId == grpIdDeb && x.type == 0).OrderBy(x => x.ledgerName).ToList();


                List<AccLedgerVm> modelList = new List<AccLedgerVm>();

                AccLedgerVm select = new AccLedgerVm();   //for adding --select-- at 0'th pos in both cmb
                select.Id = 0;
                select.ledgerNameWithCreditors = "--Select--";
                modelList.Add(select);

                foreach (var item in data1)
                {
                    AccLedgerVm acc = new AccLedgerVm();
                    acc.Id = item.Id;
                    acc.ledgerNameWithCreditors = item.ledgerName;
                    modelList.Add(acc);
                }

                //  modelList = modelList.OrderBy(x => x.ledgerNameWithCreditors).ToList();

                /*cmb Datasource does not accepts modellist with orderby 
                clause so we have to save modellist with orderby clause 
                in the modellist and the pass the model list to the 
                cmb datasouce.*/

                cmbLedgerCR.DataSource = modelList;
                cmbLedgerCR.DisplayMember = "ledgerNameWithCreditors";
                cmbLedgerCR.ValueMember = "Id";

                cmbLedgerCR.AutoCompleteCustomSource.Clear();

                foreach (var item in modelList.OrderBy(x => x.ledgerNameWithCreditors))
                {
                    cmbLedgerCR.AutoCompleteCustomSource.Add(item.ledgerNameWithCreditors.ToString());
                }

                cmbLedgerCR.Text = "";
                cmbLedgerCR.SelectedIndex = 0;
                #endregion
            }
            else // Contra
            {
                #region Contra_CR_CMB_Bind

                _entities = new MicroAccountsEntities1();

                var data1 = _entities.tbl_AccLedger.Where(x => x.ledgerName != LedgerName && x.type == 1).OrderBy(x => x.ledgerName).ToList();

                List<AccLedgerVm> modelList = new List<AccLedgerVm>();

                AccLedgerVm select = new AccLedgerVm();   //for adding --select-- at 0'th pos in both cmb
                select.Id = 0;
                select.ledgerNameWithCreditors = "--Select--";
                modelList.Add(select);

                foreach (var item in data1)
                {
                    AccLedgerVm acc = new AccLedgerVm();
                    acc.Id = item.Id;
                    acc.ledgerNameWithCreditors = item.ledgerName;
                    modelList.Add(acc);
                }

                //  modelList = modelList.OrderBy(x => x.ledgerNameWithCreditors).ToList();

                /*cmb Datasource does not accepts modellist with orderby 
                clause so we have to save modellist with orderby clause 
                in the modellist and the pass the model list to the 
                cmb datasouce.*/

                cmbLedgerCR.DataSource = modelList;
                cmbLedgerCR.DisplayMember = "ledgerNameWithCreditors";
                cmbLedgerCR.ValueMember = "Id";

                cmbLedgerCR.AutoCompleteCustomSource.Clear();

                foreach (var item in modelList.OrderBy(x => x.ledgerNameWithCreditors))
                {
                    cmbLedgerCR.AutoCompleteCustomSource.Add(item.ledgerNameWithCreditors.ToString());
                }

                cmbLedgerCR.Text = "";
                cmbLedgerCR.SelectedIndex = 0;

                #endregion
            }

        }

        void bindDrCMB()
        {
            if (passedVoucherType == 1 || passedVoucherType == 2) //Payment & Receipt
            {
                #region Payment_Receipt_CR_CMB_Bind
                _entities = new MicroAccountsEntities1();

                var grpIdCre = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Creditors").FirstOrDefault().groupId;
                var grpIdDeb = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Debtors").FirstOrDefault().groupId;

                var data1 = _entities.tbl_AccLedger.Where(x => x.groupId == grpIdCre || x.groupId == grpIdDeb && x.type == 0).OrderBy(x => x.ledgerName).ToList();

                List<AccLedgerVm> modelList = new List<AccLedgerVm>();

                AccLedgerVm select = new AccLedgerVm();   //for adding --select-- at 0'th pos in both cmb
                select.Id = 0;
                select.ledgerNameWithCreditors = "--Select--";
                modelList.Add(select);

                foreach (var item in data1)
                {
                    AccLedgerVm acc = new AccLedgerVm();
                    acc.Id = item.Id;
                    acc.ledgerNameWithCreditors = item.ledgerName;
                    modelList.Add(acc);
                }

                cmbLedgerDR.DataSource = modelList;
                cmbLedgerDR.DisplayMember = "ledgerNameWithCreditors";
                cmbLedgerDR.ValueMember = "Id";

                cmbLedgerDR.AutoCompleteCustomSource.Clear();

                foreach (var item in modelList.OrderBy(x => x.ledgerNameWithCreditors))
                {
                    cmbLedgerDR.AutoCompleteCustomSource.Add(item.ledgerNameWithCreditors.ToString());
                }

                #endregion
            }

            else if (passedVoucherType == 3) //Journal
            {
                #region Journal_CR_CMB_Bind

                _entities = new MicroAccountsEntities1();

                var grpIdCre = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Creditors").FirstOrDefault().groupId;
                var grpIdDeb = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Debtors").FirstOrDefault().groupId;

                var data1 = _entities.tbl_AccLedger.Where(x => x.groupId == grpIdCre || x.groupId == grpIdDeb && x.type == 0).OrderBy(x => x.ledgerName).ToList();

                List<AccLedgerVm> modelList = new List<AccLedgerVm>();

                AccLedgerVm select = new AccLedgerVm();   //for adding --select-- at 0'th pos in both cmb
                select.Id = 0;
                select.ledgerNameWithCreditors = "--Select--";
                modelList.Add(select);

                foreach (var item in data1)
                {
                    AccLedgerVm acc = new AccLedgerVm();
                    acc.Id = item.Id;
                    acc.ledgerNameWithCreditors = item.ledgerName;
                    modelList.Add(acc);
                }

                cmbLedgerDR.DataSource = modelList;
                cmbLedgerDR.DisplayMember = "ledgerNameWithCreditors";
                cmbLedgerDR.ValueMember = "Id";

                cmbLedgerDR.AutoCompleteCustomSource.Clear();

                foreach (var item in modelList.OrderBy(x => x.ledgerNameWithCreditors))
                {
                    cmbLedgerDR.AutoCompleteCustomSource.Add(item.ledgerNameWithCreditors.ToString());
                }

                #endregion 
            }
            else // Contra
            {
                #region Contra_CR_CMB_Bind

                _entities = new MicroAccountsEntities1();

                var data1 = _entities.tbl_AccLedger.Where(x => x.type == 1).OrderBy(x => x.ledgerName).ToList();

                List<AccLedgerVm> modelList = new List<AccLedgerVm>();

                AccLedgerVm select = new AccLedgerVm();   //for adding --select-- at 0'th pos in both cmb
                select.Id = 0;
                select.ledgerNameWithCreditors = "--Select--";
                modelList.Add(select);

                foreach (var item in data1)
                {
                    AccLedgerVm acc = new AccLedgerVm();
                    acc.Id = item.Id;
                    acc.ledgerNameWithCreditors = item.ledgerName;
                    modelList.Add(acc);
                }

                cmbLedgerDR.DataSource = modelList;
                cmbLedgerDR.DisplayMember = "ledgerNameWithCreditors";
                cmbLedgerDR.ValueMember = "Id";

                cmbLedgerDR.AutoCompleteCustomSource.Clear();

                foreach (var item in modelList.OrderBy(x => x.ledgerNameWithCreditors))
                {
                    cmbLedgerDR.AutoCompleteCustomSource.Add(item.ledgerNameWithCreditors.ToString());
                }


                #endregion
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void clear()
        {
            cmbLedgerDR.Text = "";
            cmbLedgerCR.Text = "";
            cmbLedgerDR.SelectedIndex = 0;
            cmbLedgerCR.SelectedIndex = 0;
            txtAmt.Text = "0.00";
            txtRemark.Text = "";
            lblCrBal.Text = "0.00";
            lblDrBal.Text = "0.00";
            updateVouId = 0;
            btnCreate.Text = "Create";

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        void datagridBind()
        {
            dgPaymentDetails.AutoGenerateColumns = false;

            int rowNo = 1;
            _entities = new MicroAccountsEntities1();

            // if (passedVoucherType == 1)
            {
                #region Payment Details in Grid

                List<EntryVM> modelList = new List<EntryVM>();
                var data = _entities.tbl_Entry.OrderByDescending(x => x.voucherRefNo).Where(x => x.entryType == passedVoucherType).ToList();

                foreach (var item in data)
                {
                    EntryVM model = new EntryVM();
                    model.rowNo = rowNo;
                    model.voucherRefNo = item.voucherRefNo;
                    var drLedger = _entities.tbl_AccLedger.Where(x => x.Id == item.drId).FirstOrDefault().ledgerName.ToString();
                    var crLedger = _entities.tbl_AccLedger.Where(x => x.Id == item.crId).FirstOrDefault().ledgerName.ToString();

                    model.drcrLedger = "Dr. " + drLedger + " / " + "Cr. " + crLedger;
                    model.amt = Convert.ToDecimal(amtFormat.comma(item.amt));
                    model.date = Convert.ToDateTime(item.date).ToString("dd-MM-yyyy");
                    modelList.Add(model);
                    rowNo++;
                }

                dgPaymentDetails.DataSource = modelList;
                lblTotalRows.Text = modelList.Count.ToString();
                #endregion  
            }

            // else if (passedVoucherType == 2)
            {
                #region Receipt Details in Grid

                #endregion
            }

            // else if (passedVoucherType == 3)
            {
                #region Journal Details in Grid

                #endregion
            }

            // else
            {
                #region Contra Details in Grid

                #endregion
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLedgerDR.Text == string.Empty || cmbLedgerDR.SelectedIndex == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cmbLedgerDR, "Enter Dr Ledger");
                    cmbLedgerDR.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter Dr Ledger.";
                }

                else if (cmbLedgerCR.Text == string.Empty || cmbLedgerCR.SelectedIndex == 0)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(cmbLedgerCR, "Enter Cr Ledger");
                    cmbLedgerCR.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter Cr Ledger.";
                }
                else if (txtAmt.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtAmt, "Enter amount");
                    txtAmt.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter amount.";
                }
                else
                {


                    if (btnCreate.Text == "Create")
                    {

                        //Payment Entries 

                        _entities = new MicroAccountsEntities1();


                        tbl_Entry pms = new tbl_Entry();

                        var checkId = _entities.tbl_Entry.OrderByDescending(x => x.voucherRefNo).FirstOrDefault();

                        if (checkId == null)
                        {
                            pms.voucherRefNo = 1;
                        }
                        else
                        {
                            pms.voucherRefNo = (checkId.voucherRefNo) + 1;
                        }

                        //Condition to set the entry type 

                        if (passedVoucherType == 1) //Payment
                        {
                            pms.entryType = 1;
                        }
                        else if (passedVoucherType == 2) //Receipt
                        {
                            pms.entryType = 2;
                        }
                        else if (passedVoucherType == 3) //Journal
                        {
                            pms.entryType = 3;
                        }
                        else //Contra
                        {
                            pms.entryType = 4;
                        }
                        pms.crId = _entities.tbl_AccLedger.Where(x => x.ledgerName == cmbLedgerCR.Text).FirstOrDefault().Id;
                        pms.drId = _entities.tbl_AccLedger.Where(x => x.ledgerName == cmbLedgerDR.Text).FirstOrDefault().Id;
                        pms.date = DateTime.Now.Date;
                        pms.amt = Convert.ToDecimal(txtAmt.Text);
                        pms.stringDate = dateTimePicker1.Text.ToString();
                        pms.createdDate = DateTime.Now;
                        pms.updatedDate = DateTime.Now;

                        _entities.tbl_Entry.Add(pms);
                        _entities.SaveChanges();

                        TransactionEntryClass tcs = new TransactionEntryClass();

                        string transType = "";

                        if (passedVoucherType == 1)
                        {
                            transType = "Payment";
                        }
                        else if (passedVoucherType == 2)
                        {
                            transType = "Receipt";
                        }
                        else if (passedVoucherType == 3)
                        {
                            transType = "Journal";
                        }
                        else if (passedVoucherType == 4)
                        {
                            transType = "Contra";
                        }

                        tcs.addRecord(transType, Convert.ToDecimal(txtAmt.Text), cmbLedgerCR.Text, cmbLedgerDR.Text);

                        MessageBox.Show("Record Successfully Saved");

                    }
                    else
                    {
                        //Update Code

                        _entities = new MicroAccountsEntities1();
                        var data = _entities.tbl_Entry.Where(x => x.voucherRefNo == updateVouId).FirstOrDefault();

                        data.crId = _entities.tbl_AccLedger.Where(x => x.ledgerName == cmbLedgerCR.Text).FirstOrDefault().Id;
                        data.drId = _entities.tbl_AccLedger.Where(x => x.ledgerName == cmbLedgerDR.Text).FirstOrDefault().Id;
                        data.date = DateTime.Now.Date;
                        data.amt = Convert.ToDecimal(txtAmt.Text);
                        data.stringDate = dateTimePicker1.Text.ToString();
                        data.updatedDate = DateTime.Now;

                        _entities.SaveChanges();
                        // pm.updatePaymentRecord(data);

                        TransactionEntryClass tcs = new TransactionEntryClass();

                        string transType = "";

                        if (passedVoucherType == 1)
                        {
                            transType = "Payment";
                        }
                        else if (passedVoucherType == 2)
                        {
                            transType = "Receipt";
                        }
                        else if (passedVoucherType == 3)
                        {
                            transType = "Journal";
                        }
                        else if (passedVoucherType == 4)
                        {
                            transType = "Contra";
                        }


                        tcs.updateRecord(updateVouId, transType, Convert.ToDecimal(txtAmt.Text), cmbLedgerCR.Text, cmbLedgerDR.Text);

                        MessageBox.Show("Record Successfully Updated");
                    }
                    datagridBind();
                    clear();

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void cmbLedgerDR_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLedgerDR.SelectedValue != null && cmbLedgerDR.SelectedIndex > -1 && cmbLedgerDR.Text != "")
                {
                    cmbLedgerCR.Enabled = true;
                    _entities = new MicroAccountsEntities1();

                    bindCrCMB(cmbLedgerDR.Text);

                    decimal drLedgerId = Convert.ToDecimal(cmbLedgerDR.SelectedValue.ToString());

                    CrDrDifference crdrDiff = new CrDrDifference();
                    string valueAmt = crdrDiff.DifferenceCrDr(Convert.ToInt32(drLedgerId), passedVoucherType);

                    lblDrBal.Text = valueAmt;
                }

            }
            catch (Exception x)
            {
                //MessageBox.Show(x.ToString());
            }
        }



        private void cmbLedgerCR_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbLedgerCR.SelectedValue != null && cmbLedgerCR.SelectedIndex > -1 && cmbLedgerCR.Text != "")
                {
                    long crLedgerId = Convert.ToInt32(cmbLedgerCR.SelectedValue.ToString());

                    CrDrDifference crdrDiff = new CrDrDifference();
                    string valueAmt = crdrDiff.DifferenceCrDr(crLedgerId, passedVoucherType);

                    lblCrBal.Text = valueAmt;
                }

            }
            catch (Exception x)
            {
                //   MessageBox.Show(x.ToString());
            }
        }

        private void dgPaymentDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgPaymentDetails.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        _entities = new MicroAccountsEntities1();

                        var cellId = Convert.ToInt32(dgPaymentDetails.CurrentRow.Cells[0].Value);

                        #region delete From TransactionTable

                        var selectedData1 = _entities.tbl_TransactionMaster.Where(x => x.voucherRefNo == cellId).ToList();

                        foreach (var item1 in selectedData1)
                        {
                            _entities.tbl_TransactionMaster.Remove(item1);
                        }
                        #endregion

                        #region delete From Payment Details Table
                        var selectedData2 = _entities.tbl_EntryDetails.Where(x => x.voucherRefNo == cellId).ToList();

                        foreach (var item2 in selectedData2)
                        {
                            _entities.tbl_EntryDetails.Remove(item2);
                        }
                        #endregion

                        #region delete From Payment Master Table
                        var selectedData3 = _entities.tbl_Entry.Where(x => x.voucherRefNo == cellId).FirstOrDefault();

                        _entities.tbl_Entry.Remove(selectedData3);
                        #endregion

                        _entities.SaveChanges();

                        MessageBox.Show("Record deleted ");
                        clear();
                        datagridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Record Cannot be deleted. Reference of this record is present in other entries");

            }
        }
        AmtFormatting amtFormat = new AmtFormatting();
        private void dgPaymentDetails_DoubleClick(object sender, EventArgs e)
        {
            if (dgPaymentDetails.CurrentRow.Index != -1)
            {
                _entities = new MicroAccountsEntities1();

                var gID = Convert.ToInt32(dgPaymentDetails.CurrentRow.Cells[0].Value);

                var data = _entities.tbl_Entry.Where(x => x.voucherRefNo == gID).FirstOrDefault();
                // txtGroupName.Text = lblhiddenGName.Text = data.groupName;

                cmbLedgerDR.SelectedValue = data.drId;
                cmbLedgerCR.SelectedValue = data.crId;

                updateVouId = data.voucherRefNo;

                txtAmt.Text = amtFormat.comma(data.amt).ToString();
                txtRemark.Text = data.remarks;

                btnCreate.Text = "Update";

            }
        }

        private void txtAmt_Leave(object sender, EventArgs e)
        {
            if (txtAmt.Text != "0.00" && cmbLedgerDR.SelectedIndex > 0 && cmbLedgerCR.SelectedIndex > 0 && (passedVoucherType == 1 || passedVoucherType == 2))
            {
                tbl_Entry vNoTable;
                long vNo;
                if (updateVouId == 0)
                {
                    //For Insert operation new voucher number send

                    vNoTable = _entities.tbl_Entry.OrderByDescending(x => x.voucherRefNo).FirstOrDefault();

                    if (vNoTable == null)
                        vNo = 1;
                    else
                    {
                        vNoTable.voucherRefNo = vNoTable.voucherRefNo + 1;
                        vNo = vNoTable.voucherRefNo;
                    }

                    PaymentReceiptBillReference pmb = new Forms.PaymentReceiptBillReference(passedVoucherType, Convert.ToInt32(cmbLedgerDR.SelectedValue), Convert.ToDecimal(txtAmt.Text), vNo);
                    pmb.ShowDialog();
                }
                else
                {
                    //For update operation current stored voucher number send
                    PaymentReceiptBillReference pmb = new Forms.PaymentReceiptBillReference(passedVoucherType, Convert.ToInt32(cmbLedgerDR.SelectedValue), Convert.ToDecimal(txtAmt.Text), updateVouId);
                    pmb.ShowDialog();
                }


            }
        }

        private void txtAmt_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLedgerDR_Leave(object sender, EventArgs e)
        {
            _entities = new MicroAccountsEntities1();

            if (cmbLedgerDR.Text != string.Empty && cmbLedgerDR.SelectedIndex > 0)
            {
                var checkLedgername = _entities.tbl_AccLedger.Where(x => x.ledgerName == cmbLedgerDR.Text.Trim().ToString()).FirstOrDefault();

                if (checkLedgername == null)
                {

                    DialogResult myResult;
                    myResult = MessageBox.Show("No such party exists. Want to create new party?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        AccountLedger ledger = new AccountLedger(0, cmbLedgerDR.Text.Trim().ToString());
                        ledger.ShowDialog();

                        cmbLedgerDR.Focus();
                    }
                    else
                    {
                        cmbLedgerDR.Focus();
                    }
                }
            }
        }

        private void cmbLedgerCR_Leave(object sender, EventArgs e)
        {
            _entities = new MicroAccountsEntities1();

            if (cmbLedgerCR.Text != string.Empty && cmbLedgerCR.SelectedIndex > 0)
            {
                var checkLedgername = _entities.tbl_AccLedger.Where(x => x.ledgerName == cmbLedgerCR.Text.Trim().ToString()).FirstOrDefault();

                if (checkLedgername == null)
                {

                    DialogResult myResult;
                    myResult = MessageBox.Show("No such party exists. Want to create new party?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        AccountLedger ledger = new AccountLedger(0, cmbLedgerCR.Text.Trim().ToString());
                        ledger.ShowDialog();

                        cmbLedgerCR.Focus();
                    }
                    else
                    {
                        cmbLedgerCR.Focus();
                    }
                }
            }

        }

        private void cmbLedgerDR_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbLedgerDR.Height;
            SidePanel2.Top = cmbLedgerDR.Top;
        }

        private void cmbLedgerCR_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbLedgerCR.Height;
            SidePanel2.Top = cmbLedgerCR.Top;
        }

        private void txtAmt_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtAmt.Height;
            SidePanel2.Top = txtAmt.Top;
        }

        private void txtRemark_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtRemark.Height;
            SidePanel2.Top = txtRemark.Top;
        }

        private void cmbLedgerDR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLedgerCR.Focus();
            }
        }

        private void cmbLedgerCR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmt.Focus();
            }
        }

        private void txtAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemark.Focus();
            }
        }

        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void cmbLedgerDR_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBoxValidation val = new TextBoxValidation();

            val.textOnly(sender, e);
        }

        private void txtAmt_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBoxValidation val = new TextBoxValidation();

            val.onlyNumber(sender, e);
        }
    }
}