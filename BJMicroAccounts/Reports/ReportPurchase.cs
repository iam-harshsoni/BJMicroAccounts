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
using Microsoft.Reporting.WinForms;
using MicroAccounts.AccountsModuleClasses;
using MicroAccounts; 

namespace BJMicroAccounts.Reports
{
    public partial class ReportPurchase : Form
    {
        MicroAccountsEntities1 _entities;
        private int passedId;
        public ReportPurchase(int id)
        {
            InitializeComponent();
            passedId = id;
        }

        private void ReportPurchase_Load(object sender, EventArgs e)
        {
            addPurchaseMaster();
            addPurchaseDetails();
            this.reportViewer1.RefreshReport();

        }

        private void addPurchaseMaster()
        {
            _entities = new MicroAccountsEntities1();



            var data = _entities.tbl_PurchaseMaster.Where(x => x.pId == passedId).ToList();

            List<PurchaseMasterVM> listVm = new List<PurchaseMasterVM>();
            List<LedgerDetailsVM> LedgerlistVm = new List<LedgerDetailsVM>();
            foreach (var item in data)
            {
                PurchaseMasterVM vm = new PurchaseMasterVM();

                vm.date =Convert.ToDateTime( item.date).Date.ToString("dd-MM-yyyy");
                vm.ledgerName = _entities.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName;
                vm.ledgerId = item.ledgerId;
                vm.pId = item.pId;
                vm.refNo = item.refNo;
                vm.remarks = item.remarks;
                vm.totalFine = item.totalFine;

                vm.totalMaking = item.totalMaking;
                vm.totalMelting = item.totalMelting;
                //vm.totalWeight = item.totalWeight;
                vm.totalWeight = (item.totalWeight.ToString() + " " + item.unit.ToString()).ToString();
                vm.unit = item.unit;

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

        private void addPurchaseDetails()
        {
            _entities = new MicroAccountsEntities1();
            var data1 = _entities.tbl_PurchaseDetail.Where(x => x.purchaseID == passedId).ToList();

            List<PurchaseDetailsVM> DetailslistVm = new List<PurchaseDetailsVM>();

            foreach (var item in data1)
            {
                PurchaseDetailsVM vm = new PurchaseDetailsVM();

                vm.purchaseID = item.purchaseID;
                vm.making = item.making;
                vm.melting = item.melting;
                vm.ItemCode = _entities.tbl_ItemMaster.Where(x => x.id == item.productID).FirstOrDefault().itemCode;
                vm.weight = item.weight;
                vm.unit = item.unit;
                vm.rate = item.rate;
                vm.karat = item.karat;
                vm.kRate = item.kRate;
                vm.purchaseMelting = item.purchaseMelting;
                

                DetailslistVm.Add(vm);
            }


            ReportDataSource datasource1 = new ReportDataSource("DataSet2", DetailslistVm);


            this.reportViewer1.LocalReport.DataSources.Add(datasource1);

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
