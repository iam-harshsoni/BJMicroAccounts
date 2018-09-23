using BJMicroAccounts.Data;
using MicroAccounts.App_Code;
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
    public partial class ReportTrialBal : Form
    {
        MicroAccountsEntities1 acc;
        Acc_list acc_list;
        StringBuilder html = new StringBuilder();
        closing_balance cl_balance;
        toCurrency toCurr = new toCurrency();
        Label lb = new Label();
        Font FNT = new Font("Century Gothic", 10.0f, FontStyle.Bold);
        int top = 40;
        List<DummyList> dmList = new List<DummyList>();
        string space;
        DummyList dm = new DummyList();
        public ReportTrialBal()
        {
            InitializeComponent();
        }

        private void ReportTrialBal_Load(object sender, EventArgs e)
        {
            trailBal();
            this.reportViewer1.RefreshReport();
        }

        private void trailBal()
        {
            try
            {
                tbl_AccGroup grp = new tbl_AccGroup();
                tbl_AccLedger ledg = new tbl_AccLedger();

                acc_list = new Acc_list();
                acc_list.group = grp.ToString();
                acc_list.ledger = ledg.ToString();
                acc_list.only_opening = false;
                acc_list.start_date = null;
                acc_list.end_date = null;
                acc_list.affects_gross = -1;
                acc_list.start(0);

                decimal dr = acc_list.dr_total;
                decimal cr = acc_list.cr_total;

                print_account_chart(acc_list, -1, this);

                ReportDataSource datasource = new ReportDataSource("DataSet1", dmList);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(datasource);

                dmList = new List<DummyList>();
                dm = new DummyList();
              
                dm.date = DateTime.Now.Date.ToString("dd-MM-yyyy");
                
                dm.TotaldrAmt= toCurr.toCurrenc("D", dr);
                dm.TotalcrAmt= toCurr.toCurrenc("D", dr);

                dmList.Add(dm);

                ReportDataSource datasource1 = new ReportDataSource("DataSet2", dmList); 
                this.reportViewer1.LocalReport.DataSources.Add(datasource1);

            }
            catch (Exception x)
            {

            }
        }

        public void print_account_chart(Acc_list account, int c = 0, object ths = null)
        {
            MicroAccountsEntities1 accs = new MicroAccountsEntities1();

            int count = c;

            acc_list = new Acc_list();
          

            if (account != null)
            {

                if (account.id != 0)
                {
                }
                if (account.children_ledgers.Count() > 0)
                {

                    count++;
                     
                    // Store keys in a List
                    List<int> list = new List<int>(account.children_ledgers.Keys);
                  
                    // Loop through list
                    foreach (int k in list)
                    {
                        dm = new DummyList();
                        dm.ledger = account.children_ledgers[k].name;
                        dm.opBal = toCurr.toCurrenc(account.children_ledgers[k].op_total_dc, account.children_ledgers[k].op_total);
                        dm.drAmt = toCurr.toCurrenc("D", account.children_ledgers[k].dr_total);
                        dm.crAmt = toCurr.toCurrenc("C", account.children_ledgers[k].dr_total);

                        if (account.children_ledgers[k].cl_total_dc == "D")
                        {
                            dm.clBal = toCurr.toCurrenc("D", account.children_ledgers[k].dr_total);
                        }
                        else
                        {
                            dm.clBal = toCurr.toCurrenc("C", account.children_ledgers[k].dr_total);
                        }

                        dmList.Add(dm);
                    }

                    count--;

                }

                foreach (Acc_list acc in account.children_groups)
                {
                    count++;
                    print_account_chart(acc, count, this);
                    count--;


                }

                

                //PlaceHolder3.Controls.Add(new Literal { Text = html.ToString() });
            }

        }

    }
}
