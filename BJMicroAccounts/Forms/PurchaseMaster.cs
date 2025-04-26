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
using BJMicroAccounts.Utils;

namespace MicroAccounts.Forms
{
    public partial class PurchaseMaster : Form
    {
        MicroAccountsEntities1 _entities;
        AmtFormatting amtFormat = new AmtFormatting();
        int id = 1;
        int datagridId = 1;
        bool datagridEdit = false;   //Used When Double click on datagrid to edit 
        decimal ttlMelting = 0, ttlWeight = 0, ttlRate = 0, ttlMaking = 0, ttlPurchaseMelting = 0, ttlFine = 0;

        int passedPid = 0;

        public PurchaseMaster(int pId)
        {
            InitializeComponent();
            this.passedPid = pId;
        }

        private void clear()
        {
            dgPurchaseItem.Rows.Clear();
            txtRefNo.Text = "";
            txtLedgerName.Text = "";
            dateTimePicker1.Text = DateTime.Now.Date.ToString();
            txtTotalMelting.Text = "0.00";
            txtTotalPurchMelting.Text = "0.00";
            txtTotalFine.Text = "0.00";
            txtTotalAmt.Text = "0.00";
            txtTotalWeight.Text = "0.00";
            txtTotalMaking.Text = "0.00";
            txtAmtInWords.Text = "";
            txtRemark.Text = "";
            id = 1;
            datagridId = 1;
            datagridEdit = false;
            ttlMelting = ttlWeight = ttlRate = 0;
            panel3.Visible = false;
        }

        private void clearDetails()
        {
            txtItemCode.Text = "";
            txtQty.Text = "0";
            cmbKarat.SelectedIndex = 0;
            txtKRate.Text = "0.00";
            txtPurMelting.Text = "0.00";
            txtFine.Text = "0.00";
            txtWeight.Text = "0.00";
            txtAmt.Text = "0.00";
            cmbUnit.SelectedIndex = 0;
            txtMelting.Text = "0.00";
            txtMaking.Text = "0.00";
            txtAmt.Text = "0.00";
        }

        private void materialSingleLineTextField6_Click(object sender, EventArgs e)
        {

        }

        private void ledgerNameAutoComplete()
        {
            _entities = new MicroAccountsEntities1();

            var gId = _entities.tbl_AccGroup.Where(x => x.groupName == "Sundry Creditors").FirstOrDefault().groupId;

            var ledgerNameAutoComplete = _entities.tbl_AccLedger.Where(x => x.groupId == gId);
            txtLedgerName.AutoCompleteCustomSource.Clear();
            foreach (var item in ledgerNameAutoComplete)
            {
                txtLedgerName.AutoCompleteCustomSource.Add(item.ledgerName.ToString());
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
        private void showAvailableData()
        {
            clear();
            clearDetails();

            btnCreate.Text = "Update";
            _entities = new MicroAccountsEntities1();

            var data = _entities.tbl_PurchaseMaster.Where(x => x.pId == passedPid).FirstOrDefault();

            txtRefNo.Text = data.refNo;
            dateTimePicker1.Text = data.date.ToString();
            txtLedgerName.Text = _entities.tbl_AccLedger.Where(x => x.Id == data.ledgerId).FirstOrDefault().ledgerName;

            txtTotalMelting.Text = data.totalMelting.ToString();
            txtTotalMaking.Text = data.totalMaking.ToString();
            txtTotalAmt.Text = amtFormat.comma(data.totalAmt).ToString();
            txtTotalWeight.Text = data.totalWeight.ToString();
            txtTotalFine.Text = data.totalFine.ToString();
            txtTotalPurchMelting.Text = data.totalPurchaseMelting.ToString();


            ttlWeight = Convert.ToDecimal(txtTotalWeight.Text) * 1000;
            ttlMelting = Convert.ToDecimal(txtTotalMelting.Text);
            ttlRate = Convert.ToDecimal(txtTotalAmt.Text);
            ttlMaking = Convert.ToDecimal(txtTotalMaking.Text);
            ttlFine = Convert.ToDecimal(txtTotalFine.Text);
            ttlPurchaseMelting = Convert.ToDecimal(txtTotalPurchMelting.Text);


            txtAmtInWords.Text = "";
            ConvertNoToWord convertToWord = new ConvertNoToWord();
            //int totalRate = Convert.ToInt32(txtTotalRate.Text);
            txtAmtInWords.Text = convertToWord.ConvertNumbertoWords(Convert.ToInt32(data.totalAmt)).ToLower();

            _entities = new MicroAccountsEntities1();

            var purchaseDetailsData = _entities.tbl_PurchaseDetail.Where(x => x.purchaseID == passedPid).ToList();

            id = 1;
            foreach (var item in purchaseDetailsData)
            {
                var itemCode = _entities.tbl_ItemMaster.Where(x => x.id == item.productID).FirstOrDefault().itemCode;

                dgPurchaseItem.Rows.Add(
                    id.ToString(),
                    itemCode,
                    item.qty,
                   item.weight,
                    item.unit,
                    item.karat,
                    item.kRate,
                    item.melting,
                    item.purchaseMelting,
                    item.fine,
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
        private void PurchaseMaster_Load(object sender, EventArgs e)
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

                if (passedPid != 0)
                {
                    showAvailableData();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void txtRate_Leave(object sender, EventArgs e)
        {
            //try
            //{

            //    btnCreate.Enabled = true;
            //    lblBtnError.Visible = false;

            //    if (string.IsNullOrWhiteSpace(txtItemCode.Text))
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtItemCode, "Enter item Code.");
            //        txtItemCode.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter item code.";
            //    }
            //    else if (txtQty.Text == string.IsNullOrWhiteSpace())
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtQty, "Enter Qty.");
            //        txtQty.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter Qty.";
            //    }
            //    else if (txtWeight.Text == string.Empty)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtWeight, "Enter item weight.");
            //        txtWeight.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter item weight.";
            //    }
            //    else if (txtKRate.Text == string.Empty)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtKRate, "Enter karat rate.");
            //        txtKRate.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter karat rate.";
            //    }

            //    else if (txtMelting.Text == string.Empty)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtMelting, "Enter melting.");
            //        txtMelting.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter melting.";
            //    }
            //    else if (txtPurMelting.Text == string.Empty)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtPurMelting, "Enter Purchase melting.");
            //        txtPurMelting.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter Purchase melting.";
            //    }
            //    else if (txtFine.Text == string.Empty)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtFine, "Enter fine.");
            //        txtFine.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter fine.";
            //    }

            //    else if (txtAmt.Text == string.Empty)
            //    {
            //        errorProvider1.Clear();
            //        errorProvider1.SetError(txtAmt, "Enter rate.");
            //        txtAmt.Focus();
            //        panel3.Visible = true;
            //        lblError.Text = "Enter rate.";
            //    }

            //    else
            //    {
            //        errorProvider1.Clear();

            //        if (txtItemCode.Text != string.Empty && txtQty.Text != string.Empty && txtWeight.Text != string.Empty && txtKRate.Text != string.Empty && txtMelting.Text != string.Empty && txtPurMelting.Text != string.Empty && txtFine.Text != string.Empty && txtAmt.Text != string.Empty)
            //        {
            //            if (datagridEdit)
            //            {
            //                //  MessageBox.Show( dgPurchaseItem.Rows[datagridId].Cells);
            //                dgPurchaseItem.Rows[datagridId].Cells[1].Value = txtItemCode.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[2].Value = txtQty.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[3].Value = txtWeight.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[4].Value = cmbUnit.Text;

            //                if (cmbKarat.SelectedIndex == 0)
            //                {
            //                    dgPurchaseItem.Rows[datagridId].Cells[5].Value = 0;
            //                }
            //                else
            //                {
            //                    dgPurchaseItem.Rows[datagridId].Cells[5].Value = cmbKarat.Text;
            //                }

            //                dgPurchaseItem.Rows[datagridId].Cells[6].Value = txtKRate.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[7].Value = txtMelting.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[8].Value = txtPurMelting.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[9].Value = txtFine.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[10].Value = txtMaking.Text;
            //                dgPurchaseItem.Rows[datagridId].Cells[11].Value = txtAmt.Text;

            //                this.datagridEdit = false;

            //                var dgQty = Convert.ToDecimal(dgPurchaseItem.Rows[datagridId].Cells[2].Value);
            //                var dgWeight = Convert.ToDecimal(dgPurchaseItem.Rows[datagridId].Cells[3].Value);
            //                var dgMelting = Convert.ToDecimal(dgPurchaseItem.Rows[datagridId].Cells[7].Value);
            //                var dgPurchaseMelting = Convert.ToDecimal(dgPurchaseItem.Rows[datagridId].Cells[8].Value);
            //                var dgFine = Convert.ToDecimal(dgPurchaseItem.Rows[datagridId].Cells[9].Value);
            //                var dgmaking = Convert.ToDecimal(dgPurchaseItem.Rows[datagridId].Cells[10].Value);
            //                var dgrate = Convert.ToDecimal(dgPurchaseItem.Rows[datagridId].Cells[11].Value);


            //            }
            //            else
            //            {
            //                var kartType = "";

            //                if (cmbKarat.SelectedIndex == 0)
            //                {
            //                    kartType = "0";
            //                }
            //                else
            //                {
            //                    kartType = cmbKarat.Text;
            //                }

            //                dgPurchaseItem.Rows.Add(id.ToString(), txtItemCode.Text, txtQty.Text, txtWeight.Text, cmbUnit.Text,kartType,txtKRate.Text, txtMelting.Text,txtPurMelting.Text,txtFine.Text, txtMaking.Text, txtAmt.Text);
            //                id = id + 1;
            //            }

            //            ttlMaking += Convert.ToDecimal(txtMaking.Text);
            //            ttlMelting += Convert.ToDecimal(txtMelting.Text);
            //            ttlPurchaseMelting += Convert.ToDecimal(txtPurMelting.Text);
            //            ttlFine += Convert.ToDecimal(txtFine.Text);

            //            if (cmbUnit.Text == "Kg")
            //            {
            //                decimal grams = Convert.ToDecimal(txtWeight.Text) * 1000;
            //                ttlWeight = ttlWeight + grams;
            //            }
            //            else
            //            {
            //                ttlWeight = ttlWeight + Convert.ToDecimal(txtWeight.Text);
            //            }

            //            ttlRate = ttlRate + Convert.ToDecimal(txtAmt.Text);
            //        }

            //        txtTotalMaking.Text = ttlMaking.ToString();
            //        txtTotalMelting.Text = ttlMelting.ToString();
            //        txtTotalPurchMelting.Text = ttlPurchaseMelting.ToString();
            //        txtTotalFine.Text = ttlFine.ToString();

            //        double kg = Convert.ToDouble(ttlWeight) / 1000;
            //        if (kg > 0)
            //        {
            //            txtTotalWeight.Text = kg.ToString();
            //            lblUnit.Text = "Kg";
            //        }
            //        else
            //        {
            //            txtTotalWeight.Text = ttlWeight.ToString();
            //            lblUnit.Text = "Gram";
            //        }
            //        txtTotalAmt.Text = amtFormat.comma(ttlRate).ToString();

            //        clearDetails();
            //        txtItemCode.Focus();
            //        errorProvider1.Clear();

            //        txtAmtInWords.Text = "";
            //        ConvertNoToWord convertToWord = new ConvertNoToWord();
            //        var rats = Convert.ToDecimal(txtTotalAmt.Text.Trim().ToString());
            //        txtAmtInWords.Text = convertToWord.ConvertNumbertoWords(Convert.ToInt32(rats)).ToLower();
            //    }
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show("Something went wrong. Contact your system administrator");
            //}

            try
            {
                btnCreate.Enabled = true;
                lblBtnError.Visible = false;

                if (!FormValidationHelper.ValidateRequiredField(txtItemCode, errorProvider1, lblError, panel3, "Enter item code.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtQty, errorProvider1, lblError, panel3, "Enter Qty.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtWeight, errorProvider1, lblError, panel3, "Enter item weight.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtKRate, errorProvider1, lblError, panel3, "Enter karat rate.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtMelting, errorProvider1, lblError, panel3, "Enter melting.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtPurMelting, errorProvider1, lblError, panel3, "Enter purchase melting.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtFine, errorProvider1, lblError, panel3, "Enter fine.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtAmt, errorProvider1, lblError, panel3, "Enter rate.")) return;

                string karat = cmbKarat.SelectedIndex == 0 ? "0" : cmbKarat.Text;
                decimal qty = SafeDecimal(txtQty.Text);
                decimal weight = SafeDecimal(txtWeight.Text);
                decimal melting = SafeDecimal(txtMelting.Text);
                decimal purMelting = SafeDecimal(txtPurMelting.Text);
                decimal fine = SafeDecimal(txtFine.Text);
                decimal making = SafeDecimal(txtMaking.Text);
                decimal rate = SafeDecimal(txtAmt.Text);

                if (rate <= 0) return;

                if (datagridEdit)
                {
                    var row = dgPurchaseItem.Rows[datagridId];

                    row.SetValues(id.ToString(), txtItemCode.Text, qty, weight, cmbUnit.Text, karat,
                                  SafeDecimal(txtKRate.Text), melting, purMelting, fine, making, rate);

                    datagridEdit = false;
                }
                else
                {
                    dgPurchaseItem.Rows.Add(id.ToString(), txtItemCode.Text, qty, weight, cmbUnit.Text, karat,
                                            SafeDecimal(txtKRate.Text), melting, purMelting, fine, making, rate);
                    id++;
                }

                ttlMaking += making;
                ttlMelting += melting;
                ttlPurchaseMelting += purMelting;
                ttlFine += fine;
                ttlRate += rate;

                if (cmbUnit.Text.Equals("Kg", StringComparison.OrdinalIgnoreCase))
                    ttlWeight += weight * 1000;
                else
                    ttlWeight += weight;

                UpdateTotals();
                clearDetails();
                txtItemCode.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ShowError(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            control.Focus();
            panel3.Visible = true;
            lblError.Text = message;
            return false;
        }
        private decimal SafeDecimal(string input)
        {
            return decimal.TryParse(input, out var result) ? result : 0;
        }
        private void UpdateTotals()
        {
            // Format and assign all totals in a consistent manner
            txtTotalMaking.Text = ttlMaking.ToString("0.###");
            txtTotalMelting.Text = ttlMelting.ToString("0.###");
            txtTotalPurchMelting.Text = ttlPurchaseMelting.ToString("0.###");
            txtTotalFine.Text = ttlFine.ToString("0.###");

            // Weight display logic
            if (ttlWeight > 1000)
            {
                // Convert to Kg
                var totalKg = ttlWeight / 1000;
                txtTotalWeight.Text = totalKg.ToString("0.###");
                lblUnit.Text = "Kg";
            }
            else
            {
                // Keep in grams
                txtTotalWeight.Text = ttlWeight.ToString("0.###");
                lblUnit.Text = "Gram";
            }

            txtTotalAmt.Text = amtFormat.comma(ttlRate).ToString();

            ConvertNoToWord converter = new ConvertNoToWord();
            txtAmtInWords.Text = converter.ConvertNumbertoWords(Convert.ToInt32(ttlRate)).ToLower();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            clearDetails();
        }

        private void dgPurchaseItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnCreate.Enabled = false;
                lblBtnError.Visible = true;

                if (dgPurchaseItem.Columns[e.ColumnIndex].Name == "Delete")
                {
                    DialogResult myResult;
                    myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        // int id = Convert.ToInt32(dgPurchaseItem.CurrentRow.Index);

                        foreach (DataGridViewCell oneCell in dgPurchaseItem.SelectedCells)
                        {

                            //var dgQty = Convert.ToDecimal(dgPurchaseItem.Rows[oneCell.RowIndex].Cells[2].Value);
                            var dgWeight = Convert.ToDecimal(dgPurchaseItem.Rows[oneCell.RowIndex].Cells[3].Value);
                            var dgMelting = Convert.ToDecimal(dgPurchaseItem.Rows[oneCell.RowIndex].Cells[7].Value);
                            var dgPurchaseMelting = Convert.ToDecimal(dgPurchaseItem.Rows[oneCell.RowIndex].Cells[8].Value);
                            var dgFine = Convert.ToDecimal(dgPurchaseItem.Rows[oneCell.RowIndex].Cells[9].Value);
                            var dgMaking = Convert.ToDecimal(dgPurchaseItem.Rows[oneCell.RowIndex].Cells[10].Value);
                            var dgRate = Convert.ToDecimal(dgPurchaseItem.Rows[oneCell.RowIndex].Cells[11].Value);


                            ttlWeight = ttlWeight - dgWeight;
                            ttlMaking = ttlMaking - dgMaking;
                            ttlMelting = ttlMelting - dgMelting;
                            ttlPurchaseMelting = ttlPurchaseMelting - dgPurchaseMelting;
                            ttlFine = ttlFine - dgFine;
                            ttlRate = ttlRate - dgRate;

                            txtTotalMaking.Text = ttlMaking.ToString();
                            txtTotalMelting.Text = ttlMelting.ToString();
                            txtTotalPurchMelting.Text = ttlPurchaseMelting.ToString();
                            txtTotalFine.Text = ttlFine.ToString();
                            txtTotalAmt.Text = ttlRate.ToString();

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
                                dgPurchaseItem.Rows.RemoveAt(oneCell.RowIndex);

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

        private void dgPurchaseItem_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgPurchaseItem.CurrentRow.Index != -1 && dgPurchaseItem.CurrentRow.Cells[1].Value != null)
                {


                    //var Rowid = Convert.ToInt32(dgPurchaseItem.CurrentRow.Cells[0].Value);
                    txtItemCode.Text = dgPurchaseItem.CurrentRow.Cells[1].Value.ToString();
                    txtQty.Text = dgPurchaseItem.CurrentRow.Cells[2].Value.ToString();
                    txtWeight.Text = dgPurchaseItem.CurrentRow.Cells[3].Value.ToString();
                    cmbUnit.Text = dgPurchaseItem.CurrentRow.Cells[4].Value.ToString();

                    if (dgPurchaseItem.CurrentRow.Cells[5].Value.ToString() == "0")
                    {
                        cmbKarat.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbKarat.Text = dgPurchaseItem.CurrentRow.Cells[5].Value.ToString();
                    }
                    txtKRate.Text = dgPurchaseItem.CurrentRow.Cells[6].Value.ToString();
                    txtMelting.Text = dgPurchaseItem.CurrentRow.Cells[7].Value.ToString();
                    txtPurMelting.Text = dgPurchaseItem.CurrentRow.Cells[8].Value.ToString();
                    txtFine.Text = dgPurchaseItem.CurrentRow.Cells[9].Value.ToString();
                    txtMaking.Text = dgPurchaseItem.CurrentRow.Cells[10].Value.ToString();
                    txtAmt.Text = dgPurchaseItem.CurrentRow.Cells[11].Value.ToString();
                    //id = 1;
                    //ttlRate = Convert.ToDecimal(txtTotalRate.Text);
                    //ttlWeight = Convert.ToDecimal(txtTotalWeight.Text);
                    //ttlMelting = Convert.ToDecimal(txtTotalMelting.Text);

                    ttlWeight = ttlWeight - Convert.ToDecimal(txtWeight.Text);
                    ttlMelting = ttlMelting - Convert.ToDecimal(txtMelting.Text);
                    ttlMaking = ttlMaking - Convert.ToDecimal(txtMaking.Text);
                    ttlPurchaseMelting = ttlPurchaseMelting - Convert.ToDecimal(txtPurMelting.Text);
                    ttlFine = Convert.ToDecimal(txtFine.Text);
                    ttlRate = ttlRate - Convert.ToDecimal(txtAmt.Text);

                    //MessageBox.Show(ttlWeight + "-" + ttlMelting + "-" + ttlRate);

                    int id = Convert.ToInt32(dgPurchaseItem.CurrentRow.Index);

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

                    decimal drLedgerId = Convert.ToDecimal(checkLedgername.Id);

                    CrDrDifference crdrDiff = new CrDrDifference();

                    string valueAmt = crdrDiff.DifferenceCrDr(Convert.ToInt32(drLedgerId), 0);

                    lblBalance.Text = valueAmt;
                }
            }
            catch (Exception x)
            {

            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxValidation val = new TextBoxValidation();
            val.onlyNumber(sender, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (passedPid == 0)
                {
                    panel3.Show();
                    lblError.Text = "No suck bill exists. Select valid bill.";
                }
                else
                {
                    ReportPurchase rpt = new ReportPurchase(passedPid);
                    rpt.ShowDialog();
                }
            }
            catch (Exception x)
            {

            }
        }
        int count = 0;
        private void txtRefNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (passedPid == 0 && count == 0)
                {
                    _entities = new MicroAccountsEntities1();

                    var id = _entities.tbl_PurchaseMaster.Where(x => x.refNo == txtRefNo.Text.Trim().ToString()).FirstOrDefault();

                    if (id != null)
                    {
                        passedPid = Convert.ToInt32(id.pId);
                        showAvailableData();
                        MessageBox.Show("Record of this Bill No./Ref No. already exists. Enter another ref. No. ");
                        txtRefNo.Focus();
                        count++;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception x)
            {

            }
        }

        private void txtRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dateTimePicker1.Focus();
            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLedgerName.Focus();
            }
        }

        private void txtLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemCode.Focus();
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

        private void txtMelting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPurMelting.Focus();
            }
        }

        private void txtMaking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmt.Focus();
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
                txtTotalMelting.Focus();
            }
        }

        private void txtTotalMelting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalPurchMelting.Focus();
            }
        }

        private void txtTotalMaking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalAmt.Focus();
            }
        }

        private void txtTotalRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void cmbKarat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtKRate.Focus();
            }
        }

        private void txtKRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMelting.Focus();
            }
        }

        private void txtPurMelting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFine.Focus();
            }
        }

        private void txtFine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmt.Focus();
            }
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbKarat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _entities = new MicroAccountsEntities1();
                var dateToday = DateTime.Now.Date;


                // Fetch today's rate once
                var todayRate = _entities.DailyRates.FirstOrDefault(x => x.date == dateToday);

                if (todayRate == null)
                {
                    MessageBox.Show("Today's rate is not available. Please update the daily rates.");
                    return;
                }

                var amtFormat = new AmtFormatting();
                string formattedRate = string.Empty;

                switch (cmbKarat.SelectedIndex)
                {
                    case 0:
                        formattedRate = amtFormat.comma(todayRate.eighteenC);
                        break;
                    case 1:
                        formattedRate = amtFormat.comma(todayRate.twentyTwoC);
                        break;
                    case 2:
                        formattedRate = amtFormat.comma(todayRate.twentyThreeC);
                        break;
                    case 3:
                        formattedRate = amtFormat.comma(todayRate.fineGold);
                        break;
                    case 4:
                        formattedRate = amtFormat.comma(todayRate.hallmark);
                        break;
                    default:
                        MessageBox.Show("Please select a valid karat type.");
                        return;
                }

            }
            catch (Exception x)
            {
                // Log the exception if needed
                MessageBox.Show("An error occurred while fetching today's karat rate.");
            }
        }

        private void txtLedgerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemCode_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalPurchMelting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalFine.Focus();
            }
        }

        private void txtTotalFine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTotalAmt.Focus();
            }
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
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidationHelper.ValidateRequiredField(txtRefNo, errorProvider1, lblError, panel3, "Enter reference number.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtLedgerName, errorProvider1, lblError, panel3, "Enter party name.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtTotalWeight, errorProvider1, lblError, panel3, "Enter total weight.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtTotalMelting, errorProvider1, lblError, panel3, "Enter total melting.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtTotalPurchMelting, errorProvider1, lblError, panel3, "Enter total purchase melting.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtTotalFine, errorProvider1, lblError, panel3, "Enter total fine.")) return;
                if (!FormValidationHelper.ValidateRequiredField(txtTotalAmt, errorProvider1, lblError, panel3, "Enter total rate.")) return;

                _entities = new MicroAccountsEntities1();

                if (btnCreate.Text == "Create")
                {
                    //Save Code

                    tbl_PurchaseMaster purchaseData = new tbl_PurchaseMaster();
                    purchaseData.refNo = txtRefNo.Text.Trim().ToString();
                    purchaseData.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text.Trim().ToString()).FirstOrDefault().Id;

                    DateTime date = DateTime.ParseExact(dateTimePicker1.Text, "dd-MM-yyyy", null);

                    purchaseData.date = Convert.ToDateTime(date);
                    purchaseData.totalWeight = Convert.ToDecimal(txtTotalWeight.Text);
                    purchaseData.unit = lblUnit.Text;
                    purchaseData.totalMelting = Convert.ToDecimal(txtTotalMelting.Text);
                    purchaseData.totalMaking = Convert.ToDecimal(txtTotalMaking.Text);
                    purchaseData.totalPurchaseMelting = Convert.ToDecimal(txtTotalPurchMelting.Text);
                    purchaseData.totalFine = Convert.ToDecimal(txtTotalFine.Text);
                    purchaseData.totalAmt = Convert.ToDecimal(txtTotalAmt.Text);
                    purchaseData.remarks = txtRemark.Text.ToString();
                    purchaseData.createdDate = DateTime.Now;
                    purchaseData.updateDate = DateTime.Now;

                    _entities.tbl_PurchaseMaster.Add(purchaseData);
                    _entities.SaveChanges();

                    //add data to purchase detials
                    addPurchaseDetailsData();

                    //Add data to transaction table
                    TransactionEntryClass tcs = new TransactionEntryClass();
                    tcs.addRecord("Purchase", Convert.ToDecimal(txtTotalAmt.Text), txtLedgerName.Text, "Purchase Account");

                    MessageBox.Show("Record Successfull Saved");

                }
                else
                {
                    //Update Code

                    _entities = new MicroAccountsEntities1();

                    var purchaseDataUpdate = _entities.tbl_PurchaseMaster.Where(x => x.pId == passedPid).FirstOrDefault();

                    purchaseDataUpdate.refNo = txtRefNo.Text.Trim().ToString();
                    purchaseDataUpdate.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == txtLedgerName.Text.Trim().ToString()).FirstOrDefault().Id;

                    DateTime date = DateTime.ParseExact(dateTimePicker1.Text, "dd-MM-yyyy", null);

                    purchaseDataUpdate.date = Convert.ToDateTime(date);

                    purchaseDataUpdate.totalWeight = Convert.ToDecimal(txtTotalWeight.Text);
                    purchaseDataUpdate.unit = lblUnit.Text;
                    purchaseDataUpdate.totalMelting = Convert.ToDecimal(txtTotalMelting.Text);
                    purchaseDataUpdate.totalMaking = Convert.ToDecimal(txtTotalMaking.Text);
                    purchaseDataUpdate.totalPurchaseMelting = Convert.ToDecimal(txtTotalPurchMelting.Text);
                    purchaseDataUpdate.totalFine = Convert.ToDecimal(txtTotalFine.Text);
                    purchaseDataUpdate.totalAmt = Convert.ToDecimal(txtTotalAmt.Text);
                    purchaseDataUpdate.remarks = txtRemark.Text.ToString();
                    purchaseDataUpdate.updateDate = DateTime.Now;

                    _entities.SaveChanges();

                    var purchaseDetailsUpdate = _entities.tbl_PurchaseDetail.Where(x => x.purchaseID == passedPid).ToList();

                    foreach (var item in purchaseDetailsUpdate)
                    {
                        _entities.tbl_PurchaseDetail.Remove(item);
                        _entities.SaveChanges();
                    }

                    addPurchaseDetailsData();  //grid data entry in purchse details

                    //Update transaction

                    TransactionEntryClass tcs = new TransactionEntryClass();
                    tcs.updateRecord(passedPid, "Purchase", Convert.ToDecimal(txtTotalAmt.Text), txtLedgerName.Text, "Purchase Account");


                    MessageBox.Show("Record Successfull Updated");
                }
                clear();
                clearDetails();
                count = 0;
                passedPid = 0;
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        void addPurchaseDetailsData()
        {
            foreach (DataGridViewRow dr in dgPurchaseItem.Rows)
            {
                if (Convert.ToString(dr.Cells[0].Value) != string.Empty)
                {
                    _entities = new MicroAccountsEntities1();

                    tbl_PurchaseDetail purchaseDetails = new tbl_PurchaseDetail();

                    purchaseDetails.purchaseID = _entities.tbl_PurchaseMaster.Where(x => x.refNo == txtRefNo.Text).FirstOrDefault().pId;
                    var gridItemCode = dr.Cells[1].Value.ToString();
                    purchaseDetails.productID = _entities.tbl_ItemMaster.Where(x => x.itemCode == gridItemCode).FirstOrDefault().id;
                    purchaseDetails.qty = Convert.ToDecimal(dr.Cells[2].Value.ToString());
                    purchaseDetails.weight = Convert.ToDecimal(dr.Cells[3].Value.ToString());
                    purchaseDetails.unit = dr.Cells[4].Value.ToString();
                    purchaseDetails.karat = Convert.ToDecimal(dr.Cells[5].Value.ToString());
                    purchaseDetails.kRate = Convert.ToDecimal(dr.Cells[6].Value.ToString());
                    purchaseDetails.melting = Convert.ToDecimal(dr.Cells[7].Value.ToString());
                    purchaseDetails.purchaseMelting = Convert.ToDecimal(dr.Cells[8].Value.ToString());
                    purchaseDetails.fine = Convert.ToDecimal(dr.Cells[9].Value.ToString());
                    purchaseDetails.making = Convert.ToDecimal(dr.Cells[10].Value.ToString());
                    purchaseDetails.rate = Convert.ToDecimal(dr.Cells[11].Value.ToString());
                    purchaseDetails.createdDate = DateTime.Now;

                    _entities.tbl_PurchaseDetail.Add(purchaseDetails);
                    _entities.SaveChanges();

                    //Update Qty in stock

                    var itemQty = _entities.tbl_StockItemDetails.Where(x => x.itemId == purchaseDetails.productID).FirstOrDefault();

                    itemQty.qty = itemQty.qty + purchaseDetails.qty;
                    itemQty.upadtedDate = DateTime.Now;

                    _entities.SaveChanges();
                }
            }
        }
    }

}