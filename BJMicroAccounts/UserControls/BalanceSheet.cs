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
using System.Collections;
using MicroAccounts.AccountsModuleClasses;

namespace MicroAccounts.UserControls
{
    public partial class BalanceSheet : UserControl
    {
        MicroAccountsEntities1 acc;
        List<DummyList> dmList = new List<DummyList>();
        AmtFormatting amtFormat = new AmtFormatting();

        Acc_list liabilities;
        Acc_list assets;
        Acc_list income;
        Acc_list expense;
        Acc_list acc_list;

        string space;
        decimal total_op = 0;
        decimal liabilities_total = 0;
        decimal assets_total = 0;
        decimal income_total = 0;
        decimal expense_total = 0;
        decimal pandl = 0;
        decimal positive_pandl = 0;
        string[] op_diff = new string[] { };
        decimal final_liabilities_total = 0;
        decimal final_assets_total = 0;
        bool is_diff, only_opening = false;
        DateTime e_date;
        DateTime s_date;
        StringBuilder html = new StringBuilder();
        closing_balance cl_balance;
        toCurrency toCurr = new toCurrency();
        string lbl;

        int assetsLabelTop = 0;
        int libLabelTop = 0;

        Label lb;
        Font FNT = new Font("Century Gothic", 10.0f, FontStyle.Bold);

        public BalanceSheet()
        {
            InitializeComponent();
        }


        private Label[] labels;
        private Panel[] panel;
        private void BalanceSheet_Load(object sender, EventArgs e)
        {
            try
            {

                BalanceSheetData();

                if (assetsLabelTop > libLabelTop)
                {
                    panel2.Height = assetsLabelTop+180;
                }
                else
                {
                    panel2.Height = libLabelTop+180;
                }
            }
            catch (Exception x)
            {

            }

        }


        private void BalanceSheetData()
        {
            tbl_AccGroup grp = new tbl_AccGroup();
            tbl_AccLedger ledg = new tbl_AccLedger();

            acc = new MicroAccountsEntities1();

            var acc_group_id = (from c in acc.tbl_AccGroup
                                where c.groupName == "Incomes"
                                select c.id).FirstOrDefault();


            assets = new Acc_list();

            //Income
            income = new Acc_list();

            income.group = grp.ToString();
            income.ledger = ledg.ToString();
            income.only_opening = only_opening;
            // income.start_date = txtStartDate.Text;
            //income.end_date = txtEndDate.Text;
            income.affects_gross = -1;

            income.start(Convert.ToInt32(acc_group_id));

            //Expenses

            acc = new MicroAccountsEntities1();
            acc_group_id = (from c in acc.tbl_AccGroup
                            where c.groupName == "Expenses"
                            select c.id).FirstOrDefault();

            assets = new Acc_list();
            expense = new Acc_list();

            expense.group = grp.ToString();
            expense.ledger = ledg.ToString();
            expense.only_opening = only_opening;
            // expense.start_date = txtStartDate.Text;
            // expense.end_date = txtEndDate.Text;
            expense.affects_gross = -1;
            expense.start(Convert.ToInt32(acc_group_id));

            if (income.cl_total_dc == "C")
            {
                income_total = income.cl_total;
            }
            else
            {
                income_total = Convert.ToDecimal(income.cl_total);
            }
            if (expense.cl_total_dc == "D")
            {
                expense_total = expense.cl_total;
            }
            else
            {
                expense_total = Convert.ToDecimal(expense.cl_total);
            }

            pandl = income_total - expense_total;

            op_diff = new string[] { };
            op_diff = opening_diff();
            if (Convert.ToDecimal(op_diff[1]) == 0)
            {
                is_diff = false;
            }
            else
            {
                is_diff = true;
            }

            //------------------------------------------------------------------------


            ListViewGroup Assets = new ListViewGroup("Assets", HorizontalAlignment.Left);

            acc = new MicroAccountsEntities1();
            acc_group_id = (from c in acc.tbl_AccGroup
                            where c.groupName == "Assets"
                            select c.id).FirstOrDefault();

            assets = new Acc_list();

            assets.group = grp.ToString();
            assets.ledger = ledg.ToString();
            assets.only_opening = only_opening;
            //assets.start_date = txtStartDate.Text;
            // assets.end_date = txtEndDate.Text;
            assets.affects_gross = -1;
            assets.start(Convert.ToInt32(acc_group_id));

            Account_st_short(assets, -1, "D", this, 1);

            //  dataGridView2.DataSource = dmList; 

            labels = new Label[dmList.Count + 1];
            panel = new Panel[dmList.Count + 1];
            int k = 35;
            // create array elements in a loop
            for (int i = 0; i < dmList.Count; i++)
            {
                Font FNT = new Font("Century Gothic", 10.0f, FontStyle.Bold);

                labels[i] = new Label();

                labels[i].Top = k * (i + 1);
                labels[i].Left = 546;
                labels[i].Font = FNT;
                labels[i].Size = new Size(200, 18);

                if (dmList[i].ledger == "1")
                {
                    labels[i].Text = "    " + dmList[i].group.ToString();
                    labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                    labels[i].Text = dmList[i].group.ToString();
                }

                assetsLabelTop = k * (i + 1);

                //Panel

                panel[i] = new Panel();

                panel[i].Top = assetsLabelTop +27;
                panel[i].Left = 551;
                panel[i].BackColor = Color.LightGray;
                panel[i].Size = new Size(350, 1);
            }

            this.Controls.AddRange(labels);
            this.Controls.AddRange(panel);

            labels = new Label[dmList.Count + 1];

            k = 35;
            for (int i = 0; i < dmList.Count; i++)
            {
                Font FNT = new Font("Century Gothic", 10.0f, FontStyle.Bold);

                labels[i] = new Label();

                labels[i].Top = k * (i + 1);
                labels[i].Left = 800;
                labels[i].Font = FNT;
                labels[i].Size = new Size(200, 19);

                labels[i].ForeColor = Color.Black;
                labels[i].Text = dmList[i].amt.ToString();

            }

            this.Controls.AddRange(labels);


            dmList = new List<DummyList>();

            ListViewGroup LiabilitiesandOwnersEquity = new ListViewGroup("Liabilities and Owners Equity", HorizontalAlignment.Left);

            acc = new MicroAccountsEntities1();
            acc_group_id = (from c in acc.tbl_AccGroup
                            where c.groupName == "Liabilities and Owners Equity"
                            select c.id).FirstOrDefault();

            liabilities = new Acc_list();

            liabilities.group = grp.ToString();
            liabilities.ledger = ledg.ToString();
            liabilities.only_opening = only_opening;
            //liabilities.start_date = txtStartDate.Text;
            //liabilities.end_date = txtEndDate.Text;
            liabilities.affects_gross = -1;
            liabilities.start(Convert.ToInt32(acc_group_id));

            Account_st_short(liabilities, -1, "C", this, 2);

            k = 35;
            labels = new Label[dmList.Count + 1];
            panel = new Panel[dmList.Count + 1];
            // create array elements in a loop
            for (int i = 0; i < dmList.Count; i++)
            {
                Font FNT = new Font("Century Gothic", 10.0f, FontStyle.Bold);

                labels[i] = new Label();

                labels[i].Top = k * (i + 1);
                labels[i].Left = 43;
                labels[i].Font = FNT;

                if (dmList[i].ledger == "1")
                {
                    labels[i].Text = "    " + dmList[i].group.ToString();
                    labels[i].ForeColor = Color.Blue;
                    labels[i].Size = new Size(200, 19);
                }
                else
                {
                    labels[i].ForeColor = Color.Black;
                    labels[i].Text = dmList[i].group.ToString();
                    labels[i].Size = new Size(200, 19);
                }

                libLabelTop = k * (i + 1);

                panel[i] = new Panel();

                panel[i].Top = libLabelTop + 27;
                panel[i].Left =45;
                panel[i].BackColor = Color.LightGray;
                panel[i].Size = new Size(350, 1);
            }
            this.Controls.AddRange(labels);
            this.Controls.AddRange(panel);

            k = 35;
            labels = new Label[dmList.Count + 1];
            for (int i = 0; i < dmList.Count; i++)
            {
                FNT = new Font("Century Gothic", 10.0f, FontStyle.Bold);

                labels[i] = new Label();

                labels[i].Top = k * (i + 1);
                labels[i].Left = 293;
                labels[i].Font = FNT;
                labels[i].Size = new Size(200, 19);

                labels[i].ForeColor = Color.Black;
                labels[i].Text = dmList[i].amt.ToString();

            }
            this.Controls.AddRange(labels);

            if (liabilities.cl_total_dc == "C")
            {
                liabilities_total = liabilities.cl_total;
            }
            else
            {
                liabilities_total = Convert.ToDecimal(liabilities.cl_total * -1);
            }

            if (assets.cl_total_dc == "D")
            {
                assets_total = assets.cl_total;
            }
            else
            {
                assets_total = Convert.ToDecimal(assets.cl_total * -1);
            }

            /**** Final balancesheet total ****/

            final_liabilities_total = liabilities_total;
            final_assets_total = assets_total;

            /* If net profit add to liabilities, if net loss add to assets */

            if (pandl >= 0)
            {
                final_liabilities_total = final_liabilities_total + pandl;
            }
            else
            {
                positive_pandl = pandl * -1;
                final_assets_total = final_assets_total + positive_pandl;
            }

            /**
         * If difference in opening balance is Dr then subtract from
         * assets else subtract from liabilities
         */

            if (is_diff)
            {
                if (op_diff[0] == "D")
                {
                    final_assets_total = Convert.ToDecimal(final_assets_total + Convert.ToDecimal(op_diff[1]));

                }

                else
                {
                    final_liabilities_total = Convert.ToDecimal(final_liabilities_total + Convert.ToDecimal(op_diff[1]));
                }

            }


            panel4.Visible = true;
            panel4.Top = assetsLabelTop + 35;


            /* Difference in opening balance */

            /* Total */

            dmList = new List<DummyList>();

            DummyList dm = new DummyList();
            if (assets_total >= 0)
            {
                Label lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total Assets";
                lb.Top = assetsLabelTop + 50;
                lb.Left = 549;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("D", assets_total);
                lb.Top = assetsLabelTop + 50;
                lb.Left = 800;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);
            }
            else
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total Assets";
                lb.Top = assetsLabelTop + 50;
                lb.Left = 549;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);
                lb.ForeColor = Color.Red;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "(Expecting positive Dr Balance)";
                lb.Top = assetsLabelTop + 65;
                lb.Left = 549;
                Font FNTs = new Font("Century Gothic", 8.0f, FontStyle.Bold);
                lb.Font = FNTs;
                lb.Size = new Size(250, 19);
                lb.ForeColor = Color.Red;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("D", assets_total);
                lb.Top = assetsLabelTop + 50;
                lb.Left = 800;
                lb.Font = FNT;
                lb.ForeColor = Color.Red;

                lb.Size = new Size(200, 19);

            }
            dmList.Add(dm);
            dm = new DummyList();

            html.Append("<tr style='font-weight:bold'>");

            if (pandl >= 0)
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "";
                lb.Top = assetsLabelTop + 100;
                lb.Left = 549;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "";
                lb.Top = assetsLabelTop + 100;
                lb.Left = 800;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);

            }
            else
            {

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Profit & Loss Account (Net Loss)";
                lb.Top = assetsLabelTop + 100;
                lb.Left = 549;
                lb.Font = FNT;
                lb.Size = new Size(250, 19);

                positive_pandl = pandl * -1;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("D", positive_pandl);
                lb.Top = assetsLabelTop + 100;
                lb.Left = 800;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);
            }



            if (is_diff)
            {
                /* If diff in opening balance is Dr */
                if (op_diff[0] == "D")
                {
                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = "Diff in O/P Balance";
                    lb.Top = assetsLabelTop + 130;
                    lb.Left = 549;
                    lb.Font = FNT;
                    lb.Size = new Size(200, 19);

                    positive_pandl = pandl * -1;

                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = toCurr.toCurrenc("D", Convert.ToDecimal(op_diff[1]));
                    lb.Top = assetsLabelTop + 130;
                    lb.Left = 800;
                    lb.Font = FNT;
                    lb.Size = new Size(200, 19);

                }
                else
                {
                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = "";
                    lb.Top = assetsLabelTop + 130;
                    lb.Left = 549;
                    lb.Font = FNT;
                    lb.Size = new Size(200, 19);

                    positive_pandl = pandl * -1;

                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = "";
                    lb.Top = assetsLabelTop + 130;
                    lb.Left = 800;
                    lb.Font = FNT;
                    lb.Size = new Size(200, 19);
                }

            }

            if (final_liabilities_total == final_assets_total)
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total";
                lb.Top = assetsLabelTop + 150;
                lb.Left = 549;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);

                positive_pandl = pandl * -1;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("D", Convert.ToDecimal(final_assets_total));
                lb.Top = assetsLabelTop + 150;
                lb.Left = 800;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);
            }
            else
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total";
                lb.Top = assetsLabelTop + 150;
                lb.Left = 549;
                lb.Font = FNT;
                lb.ForeColor = Color.Red;
                positive_pandl = pandl * -1;
                lb.Size = new Size(200, 19);

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("D", Convert.ToDecimal(final_assets_total));
                lb.Top = assetsLabelTop + 150;
                lb.Left = 800;
                lb.Font = FNT;
                lb.ForeColor = Color.Red;
                lb.Size = new Size(200, 19);
            }


            //Liablities bottom total

            panel6.Visible = true;
            panel6.Top = libLabelTop + 35;

            if (liabilities_total >= 0)
            {

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total Liability and Owners Equity";
                lb.Size = new Size(200, 19);
                lb.Top = libLabelTop + 50;
                lb.Left = 42;
                lb.Font = FNT;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = (toCurr.toCurrenc("C", liabilities_total));
                lb.Top = libLabelTop + 55;
                lb.Left = 293;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);


            }
            else
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total Liability and Owners Equity";
                lb.Top = libLabelTop + 50;
                lb.Left = 42;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);
                lb.ForeColor = Color.Red;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = (toCurr.toCurrenc("C", liabilities_total));
                lb.Top = libLabelTop + 55;
                lb.Left = 293;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);
                lb.ForeColor = Color.Red;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "(Expecting positive Cr Balance)";
                lb.Top = libLabelTop + 70;
                lb.Left = 42;
               Font FNTss = new Font("Century Gothic", 8.0f, FontStyle.Bold);
                lb.Font = FNTss;
                lb.Size = new Size(250, 19);
                lb.ForeColor = Color.Red;
            }

            if (pandl >= 0)
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Profit & Loss Account (Net Loss)";
                lb.Top = libLabelTop + 100;
                lb.Left = 42; 
                lb.Font = FNT;
                lb.Size = new Size(250, 19);

                positive_pandl = pandl * -1;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("C", pandl);
                lb.Top = libLabelTop + 100;
                lb.Left = 293; 
                lb.Font = FNT;
                lb.Size = new Size(250, 19);

            }
            else
            {

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = " ";
                lb.Top = libLabelTop + 100;
                lb.Left = 42;
                lb.Font = FNT;
                lb.Size = new Size(250, 19);
                  
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "  ";
                lb.Top = libLabelTop + 100;
                lb.Left = 293;
                lb.Font = FNT;
                lb.Size = new Size(250, 19);
            }

            if (is_diff)
            {
                html.Append("<tr style='font-weight:bold;color:red'>");
                /* If diff in opening balance is Cr */
                if (op_diff[0] == "C")
                {
                     lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = "Diff in O/P Balance";
                    lb.Top = libLabelTop + 130;
                    lb.Left = 42;
                    lb.Font = FNT;
                    lb.Size = new Size(250, 19);
                    lb.ForeColor = Color.Red;

                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = toCurr.toCurrenc("C", Convert.ToDecimal(op_diff[1]));
                    lb.Top = libLabelTop + 130;
                    lb.Left = 293;
                    lb.Font = FNT;
                    lb.Size = new Size(250, 19);
                    lb.ForeColor = Color.Red;

                }
                else
                {

                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = " ";
                    lb.Top = libLabelTop + 130;
                    lb.Left = 42;
                    lb.Font = FNT;
                    lb.Size = new Size(250, 19);

                    lb = new Label();
                    this.Controls.Add(lb);
                    lb.Text = "  ";
                    lb.Top = libLabelTop + 130;
                    lb.Left = 293;
                    lb.Font = FNT;
                    lb.Size = new Size(250, 19);
                }
              
            }
      

             
            if (final_liabilities_total == final_assets_total)
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total";
                lb.Top = libLabelTop + 150;
                lb.Left = 42;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);

                positive_pandl = pandl * -1;

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("c", Convert.ToDecimal(final_assets_total));
                lb.Top = libLabelTop + 150;
                lb.Left = 293;
                lb.Font = FNT;
                lb.Size = new Size(200, 19);
            }
            else
            {
                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = "Total";
                lb.Top = libLabelTop + 150;
                lb.Left = 42;
                lb.Font = FNT;
                lb.ForeColor = Color.Red;
                positive_pandl = pandl * -1;
                lb.Size = new Size(200, 19);

                lb = new Label();
                this.Controls.Add(lb);
                lb.Text = toCurr.toCurrenc("c", Convert.ToDecimal(final_assets_total));
                lb.Top = libLabelTop + 150;
                lb.Left = 293;
                lb.Font = FNT;
                lb.ForeColor = Color.Red;
                lb.Size = new Size(200, 19);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Account_st_short(Acc_list account, int c = 0, string dc_type = "", object ths = null, int lisstType = 0)
        {
            int count = c;
            acc_list = new Acc_list();
            ListViewGroup grp;

            DummyList dm = new DummyList();

            if (account != null)
            {
                if (account.id > 4)
                {
                    // grp = new ListViewGroup(account.name, HorizontalAlignment.Left);

                    //if(lisstType==1)
                    // {
                    //     listBox1.Items.Add(account.name);
                    // }
                    //else if(lisstType==2)
                    // {
                    //     listBox2.Items.Add(account.name);
                    // }

                    //Font FNT = new Font("Century Gothic", 11.0f, FontStyle.Bold);
                    //this.Font = FNT;
                    //this.ForeColor = Color.Black;

                    dm = new DummyList();
                    dm.group = account.name;
                    // dm.amt = toCurr.toCurrenc(account.cl_total_dc, Convert.ToDecimal(account.cl_total)) ;
                    dm.amt = "";
                    dmList.Add(dm);

                }
                foreach (Acc_list acc in account.children_groups)
                {
                    count++;
                    Account_st_short(acc, count, dc_type, this, lisstType);
                    count--;
                }

                if (account.children_ledgers.Count() > 0)
                {
                    count++;

                    List<int> list = new List<int>(account.children_ledgers.Keys);
                    // Loop through list
                    foreach (int k in list)
                    {

                        // listView1.Items.Add(new ListViewItem(account.children_ledgers[k].name, account.name));
                        //listBox1.Items.Add(account.children_ledgers[k].name + " --  " + toCurr.toCurrenc(account.children_ledgers[k].cl_total_dc, account.children_ledgers[k].cl_total));
                        ////html.Append(toCurr.toCurrenc(account.children_ledgers[k].cl_total_dc, account.children_ledgers[k].cl_total));
                        ////  listView1.Groups.Add(grp);

                        //if (lisstType == 1)
                        //{
                        //    listBox1.Items.Add(account.children_ledgers[k].name + " --  " + toCurr.toCurrenc(account.children_ledgers[k].cl_total_dc, account.children_ledgers[k].cl_total));

                        //}
                        //else if (lisstType == 2)
                        //{
                        //    listBox2.Items.Add(account.children_ledgers[k].name + " --  " + toCurr.toCurrenc(account.children_ledgers[k].cl_total_dc, account.children_ledgers[k].cl_total));

                        //}

                        //Font FNTs = new Font("Century Gothic",11.0f);
                        //this.Font = FNTs;
                        //this.ForeColor = Color.Blue;

                        dm = new DummyList();
                        dm.group = "(" + account.children_ledgers[k].name + ")";
                        dm.amt = toCurr.toCurrenc(account.children_ledgers[k].cl_total_dc, account.children_ledgers[k].cl_total);
                        dm.ledger = "1";
                        dmList.Add(dm);
                    }
                    count--;
                }
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
        public string[] opening_diff()
        {

            acc = new MicroAccountsEntities1();
            var ledger = from c in acc.tbl_AccLedger
                         select c;

            foreach (tbl_AccLedger ledg in ledger)
            {
                if (ledg.opBalanceDC == "D")
                {
                    total_op = Convert.ToInt32(total_op + ledg.opBalance);
                }
                else
                {
                    total_op = Convert.ToInt32(total_op - ledg.opBalance);
                }
            }

            if (total_op >= 0)
            {
                string[] op_array = new string[] { "C", Convert.ToDecimal(total_op).ToString() };
                return op_array;

            }
            else
            {
                string[] op_array = new string[] { "D", Convert.ToDecimal(total_op * -1).ToString() };
                return op_array;
            }
        }
    }
}
