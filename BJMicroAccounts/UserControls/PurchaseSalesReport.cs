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
using MicroAccounts.AccountsModuleClasses;

namespace MicroAccounts.UserControls
{
    public partial class PurchaseSalesReport : UserControl
    {
        public PurchaseSalesReport()
        {
            InitializeComponent();
        }
        MicroAccountsEntities1 _entities;
        AmtFormatting amtFormat = new AmtFormatting();
        decimal? ttlAmt = 0;
        private void PurchaseSalesReport_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            datagridBind(cmbType.Text);
        }

        private void datagridBind(string type)
        {
            try
            {
                dgPurchaseReport.AutoGenerateColumns = false;
                dgSalesReport.AutoGenerateColumns = false;

                ttlAmt = 0;
                int rowNo = 1;
                _entities = new MicroAccountsEntities1();

                List<PurchaseMasterVM> modelList = new List<PurchaseMasterVM>();
                List<tbl_PurchaseMaster> data = new List<tbl_PurchaseMaster>();

                List<SalesMasterVM> modelListSales = new List<SalesMasterVM>();
                List<tbl_SalesMaster> dataSales = new List<tbl_SalesMaster>();

                if (type == "--All--")
                {
                    #region PurchaseData
                    data = _entities.tbl_PurchaseMaster.ToList();

                    foreach (var item in data)
                    {
                        PurchaseMasterVM model = new PurchaseMasterVM();

                        model.rowNo = rowNo;
                        DateTime dt = Convert.ToDateTime(item.date).Date;

                        model.monthYear = dt.Date.ToString("dd-MM-yyyy");
                        model.totalAmt =Convert.ToDecimal(amtFormat.comma( item.totalAmt));

                        rowNo++;
                        modelList.Add(model);

                        ttlAmt += Convert.ToDecimal(item.totalAmt);
                        lblTotalAmt.Text =amtFormat.comma( ttlAmt).ToString();
                    }

                    dgPurchaseReport.DataSource = modelList;

                    lblTotalRows.Text = modelList.Count.ToString();
                    #endregion

                    #region Salesregion
                    ttlAmt = 0;
                    rowNo = 1;
                    dataSales = new List<tbl_SalesMaster>();
                    dataSales = _entities.tbl_SalesMaster.ToList();

                    foreach (var item in dataSales)
                    {
                        SalesMasterVM model = new SalesMasterVM();

                        model.rowNo = rowNo;
                        DateTime dt = Convert.ToDateTime(item.date).Date;

                        model.monthYear = dt.Date.ToString("dd-MM-yyyy");
                        model.totalAmt =Convert.ToDecimal(amtFormat.comma( item.totalAmt));

                        rowNo++;
                        modelListSales.Add(model);

                        ttlAmt += Convert.ToDecimal(item.totalAmt);
                        lblSalesTotalAmt.Text =amtFormat.comma( ttlAmt).ToString();
                    }

                    dgSalesReport.DataSource = modelListSales;

                    lblSalesRow.Text = modelList.Count.ToString();
                    #endregion
                }
                else if (type == "Month")
                {
                    #region Purchase Data
                    ttlAmt = 0;
                    rowNo = 1;

                    dgPurchaseReport.DataSource = null;
                    dgPurchaseReport.Rows.Clear();

                    _entities = new MicroAccountsEntities1();

                    data = new List<tbl_PurchaseMaster>();
                    data = _entities.tbl_PurchaseMaster.ToList();

                    string dates = "";
                    decimal? amt = 0;
                    int rowId = -1;
                    foreach (var item in data)
                    {
                        var date = Convert.ToDateTime(item.date).Date;
                        string dd = date.ToString("MMM");

                        if (dd != dates)
                        {
                            dgPurchaseReport.Rows.Add("0", rowNo, dd);
                            dates = dd;
                            amt = 0;
                            rowId++;
                        }
                        amt += item.totalAmt;
                        dgPurchaseReport.Rows[rowId].Cells[3].Value =amtFormat.comma( amt);
                        rowNo++;

                        ttlAmt += item.totalAmt;
                        lblTotalAmt.Text =amtFormat.comma( ttlAmt).ToString();
                    }
                    lblTotalRows.Text = rowNo.ToString();
                    #endregion

                    #region Sales Data 

                    ttlAmt = 0;
                    rowNo = 1;

                    dgSalesReport.DataSource = null;
                    dgSalesReport.Rows.Clear();

                    _entities = new MicroAccountsEntities1();

                    dataSales = new List<tbl_SalesMaster>();
                    dataSales = _entities.tbl_SalesMaster.ToList();

                    dates = "";
                    amt = 0;
                    rowId = -1;

                    foreach (var item in dataSales)
                    {
                        var date = Convert.ToDateTime(item.date).Date;
                        string dd = date.ToString("MMM");

                        if (dd != dates)
                        {
                            dgSalesReport.Rows.Add("0", rowNo, dd);
                            dates = dd;
                            amt = 0;
                            rowId++;
                        }
                        amt += item.totalAmt;
                        dgSalesReport.Rows[rowId].Cells[3].Value =amtFormat.comma( amt);
                        rowNo++;

                        ttlAmt += item.totalAmt;
                        lblSalesTotalAmt.Text =amtFormat.comma( ttlAmt).ToString();
                    }
                    lblSalesRow.Text = rowNo.ToString();
                    #endregion
                }
                else
                {
                    #region Purchase Data
                    ttlAmt = 0;
                    rowNo = 1;
                    dgPurchaseReport.DataSource = null;
                    dgPurchaseReport.Rows.Clear();

                    _entities = new MicroAccountsEntities1();

                    data = new List<tbl_PurchaseMaster>();
                    data = _entities.tbl_PurchaseMaster.ToList();

                    string dates = "";
                    decimal? amt = 0;
                    int rowId = -1;
                    foreach (var item in data)
                    {
                        var date = Convert.ToDateTime(item.date).Date;
                        string dd = date.ToString("yyyy");

                        if (dd != dates)
                        {
                            dgPurchaseReport.Rows.Add("0", rowNo, dd);
                            dates = dd;
                            amt = 0;
                            rowId++;
                        }
                        amt += item.totalAmt;
                        dgPurchaseReport.Rows[rowId].Cells[3].Value =amtFormat.comma( amt);
                        rowNo++;

                        ttlAmt += item.totalAmt;
                        lblTotalAmt.Text =amtFormat.comma( ttlAmt).ToString();
                    }
                    lblTotalRows.Text = rowNo.ToString();
                    #endregion

                    #region Sales Data
                    ttlAmt = 0;
                    rowNo = 1;
                    dgSalesReport.DataSource = null;
                    dgSalesReport.Rows.Clear();

                    _entities = new MicroAccountsEntities1();

                    dataSales = new List<tbl_SalesMaster>();
                    dataSales = _entities.tbl_SalesMaster.ToList();

                    dates = "";
                    amt = 0;
                    rowId = -1;
                    foreach (var item in dataSales)
                    {
                        var date = Convert.ToDateTime(item.date).Date;
                        string dd = date.ToString("yyyy");

                        if (dd != dates)
                        {
                            dgSalesReport.Rows.Add("0", rowNo, dd);
                            dates = dd;
                            amt = 0;
                            rowId++;
                        }
                        amt += item.totalAmt;
                        dgSalesReport.Rows[rowId].Cells[3].Value =amtFormat.comma( amt);
                        rowNo++;

                        ttlAmt += item.totalAmt;
                        lblSalesTotalAmt.Text =amtFormat.comma( ttlAmt).ToString();
                    }
                    lblSalesRow.Text = rowNo.ToString();
                    #endregion
                }
            }
            catch (Exception x)
            {

            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            datagridBind(cmbType.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRows_Click(object sender, EventArgs e)
        {

        }
    }
}
