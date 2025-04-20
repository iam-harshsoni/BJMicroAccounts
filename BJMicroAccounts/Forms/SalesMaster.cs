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
using MicroAccounts.AccountsModuleClasses;
using MicroAccounts.App_Code;
using BJMicroAccounts.Reports;

namespace MicroAccounts.Forms
{
    public partial class SalesMaster : Form
    {
        MicroAccountsEntities1 _entities;
        AmtFormatting amtFormat = new AmtFormatting();
        int id = 1;
        int datagridId = 1;
        bool datagridEdit = false;   //Used When Double click on datagrid to edit 
        decimal ttlKarat = 0, ttlWeight = 0, ttlRate = 0, ttlMaking = 0;

        int passedSid = 0;
        public SalesMaster(int pSId)
        {
            InitializeComponent();
            this.passedSid = pSId;
        }

        private void clear()
        {
            dgSalesItem.Rows.Clear();
            txtBillNo.Text = "";
            txtLedgerName.Text = "";
            dateTimePicker1.Text = DateTime.Now.Date.ToString();
            //txtKarat.Text = "0.00";

            txtTotalRate.Text = "0.00";
            txtTotalWeight.Text = "0.00";
            txtTotalMaking.Text = "0.00";
            txtAmtInWords.Text = "";
            txtRemark.Text = "";
            id = 1;
            datagridId = 1;
            datagridEdit = false;
            ttlKarat = ttlWeight = ttlRate = 0;
            panel3.Visible = false;

        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            try
            {
                btnCreate.Enabled = true;
                lblBtnError.Visible = false;

                if (txtItemCode.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtItemCode, "Enter item Code.");
                    txtItemCode.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter item code.";
                }
                else if (txtQty.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtQty, "Enter qty.");
                    txtQty.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter qty.";
                }
                else if (txtWeight.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtWeight, "Enter item weight.");
                    txtWeight.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter item weight.";
                }
                //else if (cmbKarat.SelectedIndex == 0 || cmbKarat.Text == string.Empty)
                //{
                //    errorProvider1.Clear();
                //    errorProvider1.SetError(cmbKarat, "Enter karat.");
                //    cmbKarat.Focus();
                //    panel3.Visible = true;
                //    lblError.Text = "Enter karat.";
                //}

                else if (txtKRate.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtKRate, "Enter karat Rate.");
                    txtKRate.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter karat Rate.";
                }

                else if (txtMaking.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtMaking, "Enter making.");
                    txtMaking.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter making.";
                }

                else if (txtRate.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtRate, "Enter rate.");
                    txtRate.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter rate.";
                }

                else
                {
                    errorProvider1.Clear();

                    if (txtItemCode.Text != string.Empty && txtQty.Text != string.Empty && txtWeight.Text != string.Empty && cmbKarat.Text != string.Empty && txtMaking.Text != string.Empty && txtRate.Text != string.Empty)
                    {
                        if (datagridEdit)
                        {
                            //  MessageBox.Show( dgPurchaseItem.Rows[datagridId].Cells);
                            dgSalesItem.Rows[datagridId].Cells[1].Value = txtItemCode.Text;
                            dgSalesItem.Rows[datagridId].Cells[2].Value = txtQty.Text;
                            dgSalesItem.Rows[datagridId].Cells[3].Value = txtWeight.Text;
                            dgSalesItem.Rows[datagridId].Cells[4].Value = cmbUnit.Text;

                            if (cmbKarat.SelectedIndex == 0)
                            {
                                dgSalesItem.Rows[datagridId].Cells[5].Value = 0;
                            }
                            else
                            {
                                dgSalesItem.Rows[datagridId].Cells[5].Value = cmbKarat.Text;
                            }

                            dgSalesItem.Rows[datagridId].Cells[6].Value = txtKRate.Text;
                            dgSalesItem.Rows[datagridId].Cells[7].Value = txtMaking.Text;
                            dgSalesItem.Rows[datagridId].Cells[8].Value = txtRate.Text;

                            this.datagridEdit = false;

                            var dgWeight = Convert.ToDecimal(dgSalesItem.Rows[datagridId].Cells[3].Value);
                            var dgMelting = Convert.ToDecimal(dgSalesItem.Rows[datagridId].Cells[5].Value);
                            var dgmaking = Convert.ToDecimal(dgSalesItem.Rows[datagridId].Cells[7].Value);
                            var dgrate = Convert.ToDecimal(dgSalesItem.Rows[datagridId].Cells[8].Value);

                        }
                        else
                        {
                            var kartType = "";

                            if (cmbKarat.SelectedIndex == 0)
                            {
                                kartType = "0";
                            }
                            else
                            {
                                kartType = cmbKarat.Text;
                            }

                            dgSalesItem.Rows.Add(id.ToString(), txtItemCode.Text, txtQty.Text, txtWeight.Text, cmbUnit.Text, kartType, txtKRate.Text, txtMaking.Text, txtRate.Text);
                            id = id + 1;
                        }

                        ttlMaking += Convert.ToDecimal(txtMaking.Text);
                        //ttlKarat += Convert.ToDecimal(cmbKarat.Text);

                        if (cmbUnit.Text == "Kg")
                        {
                            decimal grams = Convert.ToDecimal(txtWeight.Text) * 1000;
                            ttlWeight = ttlWeight + grams;
                        }
                        else
                        {
                            ttlWeight = ttlWeight + Convert.ToDecimal(txtWeight.Text);
                        }

                        ttlRate = ttlRate + Convert.ToDecimal(txtRate.Text);
                    }

                    txtTotalMaking.Text = ttlMaking.ToString();
                    //txtTotalKarat.Text = ttlKarat.ToString();

                    double kg = Convert.ToDouble(ttlWeight) / 1000;
                    if (kg > 0)
                    {
                        txtTotalWeight.Text = kg.ToString();
                        lblUnit.Text = "Kg";
                    }
                    else
                    {
                        txtTotalWeight.Text = ttlWeight.ToString();
                        lblUnit.Text = "Gram";
                    }
                    txtTotalRate.Text = amtFormat.comma(ttlRate).ToString();


                    clearDetails();
                    txtItemCode.Focus();
                    errorProvider1.Clear();

                    txtAmtInWords.Text = "";
                    ConvertNoToWord convertToWord = new ConvertNoToWord();
                    var rats = Convert.ToDecimal(txtTotalRate.Text.Trim().ToString());
                    txtAmtInWords.Text = convertToWord.ConvertNumbertoWords(Convert.ToInt32(rats)).ToLower();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            clearDetails();
        }

        private void dgSalesItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnCreate.Enabled = false;
                lblBtnError.Visible = true;

                if (dgSalesItem.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        // int id = Convert.ToInt32(dgPurchaseItem.CurrentRow.Index);

                        foreach (DataGridViewCell oneCell in dgSalesItem.SelectedCells)
                        {
                            var dgWeight = Convert.ToDecimal(dgSalesItem.Rows[oneCell.RowIndex].Cells[3].Value);
                            var dgKarat = Convert.ToDecimal(dgSalesItem.Rows[oneCell.RowIndex].Cells[5].Value);
                            var dgMaking = Convert.ToDecimal(dgSalesItem.Rows[oneCell.RowIndex].Cells[7].Value);
                            var dgRate = Convert.ToDecimal(dgSalesItem.Rows[oneCell.RowIndex].Cells[8].Value);


                            ttlWeight = ttlWeight - dgWeight;
                            ttlMaking = ttlMaking - dgMaking;
                            ttlKarat = ttlKarat - dgKarat;
                            ttlRate = ttlRate - dgRate;

                            txtTotalMaking.Text = ttlMaking.ToString();
                            txtTotalKarat.Text = ttlKarat.ToString();
                            txtTotalRate.Text = amtFormat.comma(ttlRate).ToString();
                            double kg = Convert.ToDouble(ttlWeight) / 1000;
                            if (kg > 0)
                            {
                                txtTotalWeight.Text = kg.ToString();
                                lblUnit.Text = "Kg";
                            }
                            else
                            {
                                txtTotalWeight.Text = ttlWeight.ToString();
                                lblUnit.Text = "Gram";
                            }

                            if (oneCell.Selected)
                                dgSalesItem.Rows.RemoveAt(oneCell.RowIndex);

                            txtAmtInWords.Text = "";
                            ConvertNoToWord convertToWord = new ConvertNoToWord();
                            txtAmtInWords.Text = convertToWord.ConvertNumbertoWords(Convert.ToInt32(ttlRate)).ToLower();

                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void dgSalesItem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgSalesItem.CurrentRow.Index != -1 && dgSalesItem.CurrentRow.Cells[1].Value != null)
                {


                    //var Rowid = Convert.ToInt32(dgPurchaseItem.CurrentRow.Cells[0].Value);
                    txtItemCode.Text = dgSalesItem.CurrentRow.Cells[1].Value.ToString();
                    txtQty.Text = dgSalesItem.CurrentRow.Cells[2].Value.ToString();
                    txtWeight.Text = dgSalesItem.CurrentRow.Cells[3].Value.ToString();
                    cmbUnit.Text = dgSalesItem.CurrentRow.Cells[4].Value.ToString();

                    if (dgSalesItem.CurrentRow.Cells[5].Value.ToString() == "0")
                    {
                        cmbKarat.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbKarat.Text = dgSalesItem.CurrentRow.Cells[5].Value.ToString();
                    }

                    txtKRate.Text = dgSalesItem.CurrentRow.Cells[6].Value.ToString();
                    txtMaking.Text = dgSalesItem.CurrentRow.Cells[7].Value.ToString();
                    txtRate.Text = dgSalesItem.CurrentRow.Cells[8].Value.ToString();
                    //id = 1;
                    //ttlRate = Convert.ToDecimal(txtTotalRate.Text);
                    //ttlWeight = Convert.ToDecimal(txtTotalWeight.Text);
                    //ttlMelting = Convert.ToDecimal(txtTotalMelting.Text);

                    ttlWeight = ttlWeight - Convert.ToDecimal(txtWeight.Text);
                    //    ttlKarat = ttlKarat - Convert.ToDecimal(cmbKarat.Text);
                    ttlMaking = ttlMaking - Convert.ToDecimal(txtMaking.Text);
                    ttlRate = ttlRate - Convert.ToDecimal(txtRate.Text);

                    //MessageBox.Show(ttlWeight + "-" + ttlMelting + "-" + ttlRate);

                    int id = Convert.ToInt32(dgSalesItem.CurrentRow.Index);

                    datagridId = id;
                    datagridEdit = true;
                    txtItemCode.Focus();
                    //foreach (DataGridViewCell oneCell in dgPurchaseItem.SelectedCells)
                    //{
                    //    if (oneCell.Selected)
                    //        dgPurchaseItem.Rows.RemoveAt(oneCell.RowIndex);
                    //}

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            _entities = new MicroAccountsEntities1();
            if (txtItemCode.Text != string.Empty)
            {
                var checkItemCode = _entities.tbl_ItemMaster.Where(x => x.itemCode == txtItemCode.Text.Trim().ToString()).FirstOrDefault();

                if (checkItemCode == null)
                {

                    DialogResult myResult;
                    myResult = MessageBox.Show("No such item exists. Want to create new item?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        Item items = new Item(0);
                        items.ShowDialog();
                        itemNameAutoComplete();
                        txtItemCode.Focus();
                    }
                    else
                    {
                        txtItemCode.Focus();
                    }
                }
                else
                {
                    int itemId = Convert.ToInt32(checkItemCode.id);
                    var negQty = _entities.tbl_StockItemDetails.Where(x => x.itemId == itemId).FirstOrDefault();

                    if (negQty != null)
                    {
                        if (negQty.qty < 0)
                        {
                            panel3.Show();
                            lblError.Text = "(-)Negative Stock : " + negQty.qty;

                        }
                        else
                        {
                            panel3.Hide();
                        }
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBillNo.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtBillNo, "Enter bill number.");
                    txtBillNo.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter bill number.";
                }
                else if (txtLedgerName.Text == string.Empty)
                {

                    errorProvider1.Clear();
                    errorProvider1.SetError(txtLedgerName, "Enter party name.");
                    txtLedgerName.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter party name.";
                }
                else if (txtTotalWeight.Text == string.Empty)
                {

                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTotalWeight, "Enter total weight.");
                    txtTotalWeight.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter total weight.";
                }

                else if (txtTotalMaking.Text == string.Empty)
                {

                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTotalMaking, "Enter total making.");
                    txtTotalMaking.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter total making.";
                }
                else if (txtTotalRate.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTotalRate, "Enter total rate.");
                    txtTotalRate.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter total rate.";
                }
                else
                {
                    if (btnCreate.Text == "Create")
                    {
                        //Save Code

                        _entities = new MicroAccountsEntities1();

                        tbl_SalesMaster salesData = new tbl_SalesMaster();
                        salesData.billNo = txtBillNo.Text.Trim().ToString();
                        salesData.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text.Trim().ToString()).FirstOrDefault().Id;

                        DateTime date = DateTime.ParseExact(dateTimePicker1.Text, "dd-MM-yyyy", null);

                        salesData.date = Convert.ToDateTime(date);
                        salesData.totalWeight = Convert.ToDecimal(txtTotalWeight.Text);
                        salesData.unit = lblUnit.Text;
                        salesData.totalKarat = 0;
                        salesData.totalMaking = Convert.ToDecimal(txtTotalMaking.Text);
                        salesData.totalAmt = Convert.ToDecimal(txtTotalRate.Text);
                        salesData.remarks = txtRemark.Text.ToString();
                        salesData.createdDate = DateTime.Now;
                        salesData.updateDate = DateTime.Now;

                        _entities.tbl_SalesMaster.Add(salesData);
                        _entities.SaveChanges();

                        //add data to purchase detials
                        addPurchaseDetailsData();

                        //Add data to transaction table
                        TransactionEntryClass tcs = new TransactionEntryClass();
                        tcs.addRecord("Sales", Convert.ToDecimal(txtTotalRate.Text), txtLedgerName.Text, "Sales Account");

                        MessageBox.Show("Record Successfull Saved");

                    }
                    else
                    {
                        //Update Code

                        _entities = new MicroAccountsEntities1();

                        var salesDataUpdate = _entities.tbl_SalesMaster.Where(x => x.sId == passedSid).FirstOrDefault();

                        salesDataUpdate.billNo = txtBillNo.Text.Trim().ToString();
                        salesDataUpdate.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text.Trim().ToString()).FirstOrDefault().Id;

                        DateTime date = DateTime.ParseExact(dateTimePicker1.Text, "dd-MM-yyyy", null);

                        salesDataUpdate.date = Convert.ToDateTime(date);

                        salesDataUpdate.totalWeight = Convert.ToDecimal(txtTotalWeight.Text);
                        salesDataUpdate.unit = lblUnit.Text;
                        salesDataUpdate.totalKarat = 0;
                        salesDataUpdate.totalMaking = Convert.ToDecimal(txtTotalMaking.Text);
                        salesDataUpdate.totalAmt = Convert.ToDecimal(txtTotalRate.Text);
                        salesDataUpdate.remarks = txtRemark.Text.ToString();
                        salesDataUpdate.updateDate = DateTime.Now;

                        _entities.SaveChanges();

                        var salesDetailsUpdate = _entities.tbl_SalesDetails.Where(x => x.salesId == passedSid).ToList();

                        foreach (var item in salesDetailsUpdate)
                        {
                            _entities.tbl_SalesDetails.Remove(item);
                            _entities.SaveChanges();
                        }
                        addPurchaseDetailsData();  //grid data entry in purchse details

                        //Update transaction

                        TransactionEntryClass tcs = new TransactionEntryClass();
                        tcs.updateRecord(passedSid, "Sales", Convert.ToDecimal(txtTotalRate.Text), txtLedgerName.Text, "Sales Account");

                        MessageBox.Show("Record Successfull Updated");
                    }
                    clear();
                    clearDetails();
                    count = 0;
                    passedSid = 0;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void clearDetails()
        {
            txtItemCode.Text = "";
            txtQty.Text = "0";
            txtWeight.Text = "0.00";
            txtRate.Text = "0.00";
            cmbUnit.SelectedIndex = 0;
            txtKRate.Text = "0.00";
            txtMaking.Text = "0.00";
            txtRate.Text = "0.00";
            cmbKarat.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTotalRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxValidation val = new TextBoxValidation();
            val.onlyNumber(sender, e);
        }

        int count = 0;
        private void txtBillNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (passedSid == 0 && count == 0)
                {
                    _entities = new MicroAccountsEntities1();

                    var id = _entities.tbl_SalesMaster.Where(x => x.billNo == txtBillNo.Text.Trim().ToString()).FirstOrDefault();

                    if (id != null)
                    {
                        passedSid = Convert.ToInt32(id.sId);
                        showAvailData();
                        MessageBox.Show("Record of this Bill No./Ref No. already exists. Enter another ref. No. ");
                        txtBillNo.Focus();

                        count++;
                    }
                }
            }
            catch (Exception x)
            {

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (passedSid == 0)
                {
                    panel3.Show();
                    lblError.Text = "No suck bill exists. Select valid bill.";
                }
                else
                {
                    ReportSales rpt = new ReportSales(passedSid);
                    rpt.ShowDialog();
                }
            }
            catch (Exception x)
            {

            }
        }

        private void txtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemCode.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLedgerName.Focus();
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeight.Focus();
            }
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUnit.Focus();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbKarat.Focus();
            }
        }

        private void cmbKarat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMaking.Focus();
            }
        }

        private void txtMaking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRate.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalWeight.Focus();
            }
        }

        private void txtTotalWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalMaking.Focus();
            }
        }

        private void txtTotalMaking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalRate.Focus();
            }
        }

        private void txtTotalRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void cmbKarat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                _entities = new MicroAccountsEntities1();
                var dateToday = DateTime.Now.Date;

                if (cmbKarat.SelectedIndex == 0)
                {
                    var rate = _entities.DailyRates.Where(x => x.date == dateToday).FirstOrDefault().eighteenC;

                    amtFormat = new AmtFormatting();
                    txtKRate.Text = amtFormat.comma(rate);
                }
                else if (cmbKarat.SelectedIndex == 1)
                {
                    var rate = _entities.DailyRates.Where(x => x.date == dateToday).FirstOrDefault().twentyTwoC;

                    amtFormat = new AmtFormatting();
                    txtKRate.Text = amtFormat.comma(rate);
                }
                else if (cmbKarat.SelectedIndex == 2)
                {
                    var rate = _entities.DailyRates.Where(x => x.date == dateToday).FirstOrDefault().twentyThreeC;

                    amtFormat = new AmtFormatting();
                    txtKRate.Text = amtFormat.comma(rate);
                }
                else if (cmbKarat.SelectedIndex == 3)
                {
                    var rate = _entities.DailyRates.Where(x => x.date == dateToday).FirstOrDefault().fineGold;

                    amtFormat = new AmtFormatting();
                    txtKRate.Text = amtFormat.comma(rate);
                }
                else if (cmbKarat.SelectedIndex == 4)
                {
                    var rate = _entities.DailyRates.Where(x => x.date == dateToday).FirstOrDefault().hallmark;

                    amtFormat = new AmtFormatting();
                    txtKRate.Text = amtFormat.comma(rate);
                }

            }
            catch (Exception x)
            {

            }
        }

        private void txtRate_LocationChanged(object sender, EventArgs e)
        {

        }

        private void txtLedgerName_Leave(object sender, EventArgs e)
        {
            try
            {
                _entities = new MicroAccountsEntities1();

                if (txtLedgerName.Text != string.Empty)
                {
                    var checkLedgername = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text.Trim().ToString()).FirstOrDefault();

                    if (checkLedgername == null)
                    {

                        DialogResult myResult;
                        myResult = MessageBox.Show("No such party exists. Want to create new party?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (myResult == DialogResult.OK)
                        {
                            AccountLedger ledger = new AccountLedger(0, txtLedgerName.Text.Trim().ToString());
                            ledger.ShowDialog();
                            ledgerNameAutoComplete();
                            txtLedgerName.Focus();
                            return;
                        }
                        else
                        {
                            txtLedgerName.Focus();
                            return;
                        }
                    }

                    try
                    {

                        decimal drLedgerId = Convert.ToDecimal(checkLedgername.Id);

                        CrDrDifference crdrDiff = new CrDrDifference();
                        string valueAmt = crdrDiff.DifferenceCrDr(Convert.ToInt32(drLedgerId), 0);

                        lblBalance.Text = valueAmt;
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception x)
            {

            }
        }
        private void ledgerNameAutoComplete()
        {
            //_entities = new MicroAccountsEntities1();

            //var gId = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Debtors").FirstOrDefault().groupId;

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

        private void itemNameAutoComplete()
        {
            _entities = new MicroAccountsEntities1();
            var itemCodeAutoComplete = _entities.tbl_ItemMaster;
            txtItemCode.AutoCompleteCustomSource.Clear();
            foreach (var item in itemCodeAutoComplete)
            {
                txtItemCode.AutoCompleteCustomSource.Add(item.itemCode.ToString());
            }

        }

        private void showAvailData()
        {
            clear();
            clearDetails();

            btnCreate.Text = "Update";
            _entities = new MicroAccountsEntities1();

            var data = _entities.tbl_SalesMaster.Where(x => x.sId == passedSid).FirstOrDefault();

            txtBillNo.Text = data.billNo;
            dateTimePicker1.Text = data.date.ToString();
            txtLedgerName.Text = _entities.tbl_AccLedger.Where(x => x.Id == data.ledgerId).FirstOrDefault().ledgerName;

            txtTotalKarat.Text = data.totalKarat.ToString();
            txtTotalMaking.Text = amtFormat.comma(data.totalMaking).ToString();
            txtTotalRate.Text = amtFormat.comma(data.totalAmt).ToString();
            txtTotalWeight.Text = data.totalWeight.ToString();

            ttlWeight = Convert.ToDecimal(txtTotalWeight.Text) * 1000;
            ttlKarat = Convert.ToDecimal(txtTotalKarat.Text);
            ttlRate = Convert.ToDecimal(txtTotalRate.Text);
            ttlMaking = Convert.ToDecimal(txtTotalMaking.Text);

            txtAmtInWords.Text = "";
            ConvertNoToWord convertToWord = new ConvertNoToWord();
            //int totalRate = Convert.ToInt32(txtTotalRate.Text);
            txtAmtInWords.Text = convertToWord.ConvertNumbertoWords(Convert.ToInt32(data.totalAmt)).ToLower();

            _entities = new MicroAccountsEntities1();

            var salesDetailsData = _entities.tbl_SalesDetails.Where(x => x.salesId == passedSid).ToList();

            id = 1;
            foreach (var item in salesDetailsData)
            {
                var itemCode = _entities.tbl_ItemMaster.Where(x => x.id == item.productId).FirstOrDefault().itemCode;

                dgSalesItem.Rows.Add(
                    id.ToString(),
                    itemCode,
                      item.qty,
                   item.weight,
                    item.unit,
                    item.karat,
                    item.kRate,
                    item.making,
                    item.rate);

                id = id + 1;
            }

            var checkLedgername = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text.Trim().ToString()).FirstOrDefault();

            decimal drLedgerId = Convert.ToDecimal(checkLedgername.Id);

            CrDrDifference crdrDiff = new CrDrDifference();
            string valueAmt = crdrDiff.DifferenceCrDr(Convert.ToInt32(drLedgerId), 0);

            lblBalance.Text = valueAmt;
        }

        private void SalesMaster_Load(object sender, EventArgs e)
        {
            try
            {

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";

                clear();
                clearDetails();

                ledgerNameAutoComplete();
                itemNameAutoComplete();

                //Edit load

                if (passedSid != 0)
                {
                    showAvailData();
                }
                else
                {
                    _entities = new MicroAccountsEntities1();
                    var billNo = _entities.tbl_SalesMaster.OrderByDescending(x => x.billNo).FirstOrDefault();

                    if (billNo == null)
                    {
                        txtBillNo.Text = "1";
                    }
                    else
                    {
                        int billNos = Convert.ToInt32(billNo.billNo) + 1;

                        txtBillNo.Text = billNos.ToString();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        void addPurchaseDetailsData()
        {
            foreach (DataGridViewRow dr in dgSalesItem.Rows)
            {
                if (Convert.ToString(dr.Cells[0].Value) != string.Empty)
                {
                    _entities = new MicroAccountsEntities1();

                    tbl_SalesDetails salesDetails = new tbl_SalesDetails();

                    salesDetails.salesId = _entities.tbl_SalesMaster.Where(x => x.billNo == txtBillNo.Text).FirstOrDefault().sId;
                    var gridItemCode = dr.Cells[1].Value.ToString();
                    salesDetails.productId = _entities.tbl_ItemMaster.Where(x => x.itemCode == gridItemCode).FirstOrDefault().id;
                    salesDetails.qty = Convert.ToDecimal(dr.Cells[2].Value.ToString());
                    salesDetails.weight = Convert.ToDecimal(dr.Cells[3].Value.ToString());
                    salesDetails.unit = dr.Cells[4].Value.ToString();
                    salesDetails.karat = Convert.ToDecimal(dr.Cells[5].Value.ToString());
                    salesDetails.kRate = Convert.ToDecimal(dr.Cells[6].Value.ToString());
                    salesDetails.making = Convert.ToDecimal(dr.Cells[7].Value.ToString());
                    salesDetails.rate = Convert.ToDecimal(dr.Cells[8].Value.ToString());
                    salesDetails.createdDate = DateTime.Now;

                    _entities.tbl_SalesDetails.Add(salesDetails);
                    _entities.SaveChanges();

                    //Update Qty in stock

                    var itemQty = _entities.tbl_StockItemDetails.Where(x => x.itemId == salesDetails.productId).FirstOrDefault();

                    itemQty.qty = itemQty.qty - salesDetails.qty;
                    itemQty.upadtedDate = DateTime.Now;

                    _entities.SaveChanges();
                }
            }
        }
    }
}
