using BJMicroAccounts.Data;
using MicroAccounts;
using MicroAccounts.AccountsModuleClasses;
using MicroAccounts.ViewModel;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BJMicroAccounts.Reports
{
    public partial class ReportSales : Form
    {
        MicroAccountsEntities1 _entities;
        private int passedId;
        public ReportSales(int id)
        {
            InitializeComponent();
            passedId = id;
        }

        private void ReportSales_Load(object sender, EventArgs e)
        {
            addSalesMaster();
            addSalesDetails();
            this.reportViewer1.RefreshReport();
        }

        private void addSalesMaster()
        {
            _entities = new MicroAccountsEntities1();

            var data = _entities.tbl_SalesMaster.Where(x => x.sId == passedId).ToList();

            List<SalesMasterVM> listVm = new List<SalesMasterVM>();
            List<LedgerDetailsVM> LedgerlistVm = new List<LedgerDetailsVM>();

            foreach (var item in data)
            {
                SalesMasterVM vm = new SalesMasterVM();

                vm.date = Convert.ToDateTime(item.date).Date.ToString("dd-MM-yyyy");
                vm.ledgerName = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName.Trim();
                vm.ledgerId = item.ledgerId;
                vm.sId = item.sId;
                vm.billNo = item.billNo;
                vm.remarks = item.remarks;

                vm.totalMaking = item.totalMaking;
                vm.totalKarat = item.totalKarat;
                vm.totalWeight = item.totalWeight;
                vm.unit = item.unit;

                AmtFormatting amtFormat = new AmtFormatting();

                vm.totalAmt = item.totalAmt;

                ConvertNoToWord toWord = new ConvertNoToWord();
                vm.amtinWord = toWord.ConvertNumbertoWords(Convert.ToInt32(item.totalAmt));
                listVm.Add(vm);

                LedgerDetailsVM ll = new LedgerDetailsVM();
                ll.contact = _entities.tbl_LedgerDetails.Where(x => x.ledgerId == item.ledgerId).FirstOrDefault().contact;
                ll.address = _entities.tbl_LedgerDetails.Where(x => x.ledgerId == item.ledgerId).FirstOrDefault().address.Trim();

                LedgerlistVm.Add(ll);
            }

            ReportDataSource datasource = new ReportDataSource("DataSet1", listVm);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);

            datasource = new ReportDataSource("DataSet3", LedgerlistVm);
             
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
        }

        private void addSalesDetails()
        {
            _entities = new MicroAccountsEntities1();
            var data1 = _entities.tbl_SalesDetails.Where(x => x.salesId == passedId).ToList();

            List<SalesDetailsVM> DetailslistVm = new List<SalesDetailsVM>();

            foreach (var item in data1)
            {
                SalesDetailsVM vm = new SalesDetailsVM();

                vm.salesId = item.salesId;
                vm.making = item.making;
                vm.karrat = item.karat;
                vm.ItemCode = _entities.tbl_ItemMaster.Where(x => x.id == item.productId).FirstOrDefault().itemCode;
                vm.weight = item.weight;
                vm.unit = item.unit;
                vm.rate = item.rate;
                vm.kRate = item.kRate;
                DetailslistVm.Add(vm);
            }


            ReportDataSource datasource1 = new ReportDataSource("DataSet2", DetailslistVm);

            this.reportViewer1.LocalReport.DataSources.Add(datasource1);

        }


    }
}
