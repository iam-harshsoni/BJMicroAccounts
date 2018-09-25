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
using MicroAccounts.App_Code;
using BJMicroAccounts.Reports;

namespace BJMicroAccounts.UserControls
{
    public partial class TrailBalance : UserControl
    {
        MicroAccountsEntities1 acc;
        Acc_list acc_list;
        StringBuilder html = new StringBuilder();
        closing_balance cl_balance;
        toCurrency toCurr = new toCurrency();
        Label lb  = new Label();
        Font FNT = new Font("Century Gothic", 10.0f, FontStyle.Bold);
        int top = 40;
        List<DummyList> dmList = new List<DummyList>();
        string space;
        public TrailBalance()
        {
            InitializeComponent();
        }

        private void TrailBalance_Load(object sender, EventArgs e)
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

                panel2.Top = top + 10;

               
                if (dr == cr)
                {
                    Label lb2 = new Label();
                    this.Controls.Add(lb2);
                    lb2.Text = "Total";
                    //lb.Top = assetsLabelTop + 50;
                    lb2.Top = top + 25;
                    lb2.Left = 42;
                    lb2.Font = FNT;
                    lb2.ForeColor = Color.Green;
                    lb2.Size = new Size(150, 19);

                    Label lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = toCurr.toCurrenc("D", dr);
                    //lb.Top = assetsLabelTop + 50;
                    lb.Top = top + 25;
                    lb.Left = 483;
                    lb.Font = FNT;
                    lb.ForeColor = Color.Green;
                    lb.Size = new Size(150, 19);

                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = toCurr.toCurrenc("C", cr);
                    //lb.Top = assetsLabelTop + 50;
                    lb.Top = top + 25;
                    lb.Left = 651;
                    lb.Font = FNT;
                    lb.ForeColor = Color.Green;
                    lb.Size = new Size(150, 19);
                }
                else
                {
                    Label lb1 = new Label();
                    this.Controls.Add(lb1);
                    lb1.Text = "Total";
                    //lb.Top = assetsLabelTop + 50;
                    lb1.Top = top + 25;
                    lb1.Left = 42;
                    lb1.Font = FNT;
                    lb1.ForeColor = Color.Red;
                    lb1.Size = new Size(150, 19);

                    Label lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = toCurr.toCurrenc("D", dr);
                    //lb.Top = assetsLabelTop + 50;
                    lb.Top = top + 25;
                    lb.Left = 483;
                    lb.Font = FNT;
                    lb.ForeColor = Color.Red;
                    lb.Size = new Size(150, 19);

                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = toCurr.toCurrenc("C", cr);
                    //lb.Top = assetsLabelTop + 50;
                    lb.Top = top + 25;
                    lb.Left = 651;
                    lb.Font = FNT;
                    lb.ForeColor = Color.Red;
                    lb.Size = new Size(150, 19);
                    
                }
                 
 
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
            DummyList dm = new DummyList();
            //StringBuilder html = new StringBuilder();
            if (account != null)
            {

                if (account.id != 0)
                {
                    //if (account.g_parent_id == 0)
                    //{
                    //    //    html.Append("<tr class='table table-bordered table-striped'>");
                    //    html.Append("<tr style='color:brown;background-color:#F3F3F3'>");
                    //}
                    //else
                    //{
                    //    // html.Append("<tr class='tr-group'>");
                    //    html.Append("<tr>");
                    //}

                    ////html.Append("<td class='td-group'>");
                    //html.Append("<td>");
                    //html.Append(print_space(count));


                    //html.Append("<b >" + account.name + "</b>");


                    //html.Append("</td>");

                    //html.Append("<td><b>Group<b></td>");

                    //html.Append("<td><b>"); html.Append(toCurr.toCurrenc(account.op_total_dc, account.op_total)); html.Append("</b></td>");
                    //html.Append("<td><b>"); html.Append(toCurr.toCurrenc("D", account.dr_total)); html.Append("</b></td>");
                    //html.Append("<td><b>"); html.Append(toCurr.toCurrenc("C", account.cr_total)); html.Append("</b></td>");

                    //if (account.cl_total_dc == "D")
                    //{
                    //    html.Append("<td><b>"); html.Append(toCurr.toCurrenc("D", account.cl_total)); html.Append("</b></td>");

                    //}
                    //else
                    //{
                    //    html.Append("<td><b>"); html.Append(toCurr.toCurrenc("C", account.cl_total)); html.Append("</b></td>");

                    //}

                    //html.Append("</tr>");
                }
                if (account.children_ledgers.Count() > 0)
                {

                    count++;

                    // Store keys in a List
                    List<int> list = new List<int>(account.children_ledgers.Keys);
                    // Loop through list
                    foreach (int k in list)
                    {
                        //html.Append(account.children_ledgers[k].name);

                    

                        Label lb = new Label();
                        this.Controls.Add(lb);
                        lb.Text = account.children_ledgers[k].name;
                        //lb.Top = assetsLabelTop + 50;
                        lb.Top = top;
                        lb.Left = 42;
                        lb.Font = FNT;
                        lb.Size = new Size(200, 19);

                        lb = new Label();
                        this.Controls.Add(lb);
                        lb.Text = toCurr.toCurrenc(account.children_ledgers[k].op_total_dc, account.children_ledgers[k].op_total);
                        //lb.Top = assetsLabelTop + 50;
                        lb.Top = top;
                        lb.Left = 292;
                        lb.Font = FNT;
                        lb.Size = new Size(150, 19);

                        lb = new Label();
                        this.Controls.Add(lb);
                        lb.Text = toCurr.toCurrenc("D", account.children_ledgers[k].dr_total);
                        //lb.Top = assetsLabelTop + 50;
                        lb.Top = top;
                        lb.Left = 483;
                        lb.Font = FNT;
                        lb.Size = new Size(150, 19);


                        lb = new Label();
                        this.Controls.Add(lb);
                        lb.Text = toCurr.toCurrenc("C", account.children_ledgers[k].dr_total);
                        //lb.Top = assetsLabelTop + 50;
                        lb.Top = top;
                        lb.Left = 651;
                        lb.Font = FNT;
                        lb.Size = new Size(150, 19);


                        //html.Append("<a href=''>" + account.children_ledgers[k].name + " </a>  ");
                        //html.Append("</td>");

                        //html.Append("<td>Ledger</td>");

                        //html.Append("<td>");
                        //html.Append(toCurr.toCurrenc(account.children_ledgers[k].op_total_dc, account.children_ledgers[k].op_total));
                        //html.Append("</td>");

                        //html.Append("<td>");
                        //html.Append(toCurr.toCurrenc("D", account.children_ledgers[k].dr_total));
                        //html.Append("</td>");

                        //html.Append("<td>");
                        //html.Append(toCurr.toCurrenc("C", account.children_ledgers[k].cr_total));
                        //html.Append("</td>");

                        if (account.children_ledgers[k].cl_total_dc == "D")
                        {
                            lb = new Label();
                            this.Controls.Add(lb);
                            lb.Text = toCurr.toCurrenc("D", account.children_ledgers[k].dr_total);
                            //lb.Top = assetsLabelTop + 50;
                            lb.Top = top;
                            lb.Left = 806;
                            lb.Font = FNT;
                            lb.Size = new Size(150, 19);

                        }
                        else
                        {
                            lb = new Label();
                            this.Controls.Add(lb);
                            lb.Text = toCurr.toCurrenc("C", account.children_ledgers[k].dr_total);
                            //lb.Top = assetsLabelTop + 50;
                            lb.Top = top;
                            lb.Left = 806;
                            lb.Font = FNT;
                            lb.Size = new Size(150, 19);

                        }

                        //html.Append("</tr>");
                        top = top + 25;

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

        public string print_space(int count = -1)
        {
            //StringBuilder html = new StringBuilder();
            space = "";
            int i;
            for (i = 1; i <= count; i++)
            {
                space += "    ";

            }
            return space;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportTrialBal rpt = new ReportTrialBal();
            rpt.ShowDialog();
        }
    }
}
