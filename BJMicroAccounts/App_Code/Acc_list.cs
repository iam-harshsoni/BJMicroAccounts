using BJMicroAccounts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Acc_list
/// </summary>
public class Acc_list
{

    public Acc_list[] cm = new Acc_list[10];

    MicroAccountsEntities1 acc;
    closing_balance cl_balance;
    public int id = 0, g_idd = 0;
    public string name = "";

    public int a_id = 0;

    public int g_parent_id = 0;
    public int g_affects_gross = 0;
    public int l_group_id = 0;
    public int? l_type = 0;
    public int l_reconciliation = 0;
    public string l_notes = "";
    int af_gross = 0;

    public decimal op_total = 0, dr_total = 0, cr_total = 0, cl_total = 0;
    public string op_total_dc = "D", cl_total_dc = "D";

    public Acc_list[] children_groups = new Acc_list[10];
    //public Acc_list[] children_ledgers = new Acc_list[10];
    int counter = 0;

    public bool only_opening = false;
    public string start_date = null, end_date = null;
    public int affects_gross = -1;

    public object group = null, ledger = null;
    string grp_id = null;
    public Acc_list()
    {
        return;
    }

    public void comm()
    {
        for (int i = 0; i <= cm.Length - 1; i++)
        {
            cm[i] = new Acc_list();
            cm[i].name = i.ToString();
            cm[i].ledger = (i + 1).ToString();
        }
    }

    public void start(int acc_id)
    {

        if (acc_id == 0)
        {

            this.id = Convert.ToInt32(null);
            this.name = "None";
        }

        else
        {
            acc = new MicroAccountsEntities1();
            var group = (from c in acc.tbl_AccGroup
                         where c.id == acc_id
                         select c).FirstOrDefault();
            //var group = (from c in acc.Groups
            //             where c.account_id == account_id
            //             select c).FirstOrDefault();

            if (group != null)
            {
                this.g_idd = Convert.ToInt32(group.groupId);
                this.id = Convert.ToInt32(group.id);
                this.name = group.groupName;
                this.g_parent_id = Convert.ToInt32(group.parentId);
                this.g_affects_gross = Convert.ToInt32(group.affects_gross);
                // this.a_id = Convert.ToInt32(group.account_id);

            }
            //else
            //{

            //    this.a_id = account_id;
            //   // this.a_id = account_id;
            //}
        }

        this.op_total = 0;
        this.op_total_dc = "D";
        this.dr_total = 0;
        this.cr_total = 0;
        this.cl_total = 0;
        this.cl_total_dc = "D";


        if (this.affects_gross == 1)
        {


        }
        else if (this.affects_gross == 0)
        {
            this.add_sub_ledgers();

        }
        else
        {
            this.add_sub_ledgers();
        }
        this.add_sub_groups();

    }
    List<tbl_AccGroup> child_group_q;

    public void add_sub_groups()
    {

        acc = new MicroAccountsEntities1();


        if (this.id == 0)
        {
            if (this.affects_gross == 0)
            {
                child_group_q = (from c in acc.tbl_AccGroup
                                 where c.parentId == 0 && c.affects_gross == 0
                                 select c).ToList();


            }
            if (this.affects_gross == 1)
            {

                child_group_q = (from c in acc.tbl_AccGroup
                                 where c.parentId == 0 && c.affects_gross == 1
                                 select c).ToList();

            }

            this.affects_gross = -1;
            child_group_q = (from c in acc.tbl_AccGroup
                             where c.parentId == 0
                             select c).ToList();

        }
        else
        {
            if (this.affects_gross == 0)
            {
                child_group_q = (from c in acc.tbl_AccGroup
                                 where c.parentId == this.id && c.affects_gross == 0
                                 select c).ToList();

            }
            else if (this.affects_gross == 1)
            {

                child_group_q = (from c in acc.tbl_AccGroup
                                 where c.parentId == this.id && c.affects_gross == 1
                                 select c).ToList();

            }
            else
            {
                this.affects_gross = -1;
                child_group_q = (from c in acc.tbl_AccGroup
                                 where c.parentId == this.id
                                 select c).ToList();
            }
        }

        counter = 0;
        // this.children_groups = new Acc_list[child_group_q.Count];
        foreach (tbl_AccGroup grp in child_group_q)
        {

            children_groups[counter] = new Acc_list();
            /* Create new AccountList object */
            //    children_groups[counter] = new Acc_list();
            /* Initial setup */

            this.children_groups[counter].group = acc.tbl_AccGroup;
            this.children_groups[counter].ledger = acc.tbl_AccLedger;
            this.children_groups[counter].only_opening = this.only_opening;
            this.children_groups[counter].start_date = this.start_date;
            this.children_groups[counter].end_date = this.end_date;
            this.children_groups[counter].affects_gross = -1; /* No longer needed in sub groups */

            this.children_groups[counter].start(Convert.ToInt32(grp.id));


            /* Calculating opening balance total for all the child groups*/
            string[] temp = Calculate_withdc(this.op_total, this.op_total_dc, Convert.ToDecimal(this.children_groups[counter].op_total), (this.children_groups[counter].op_total_dc).ToString());
            this.op_total = Convert.ToDecimal(temp[0]);
            this.op_total_dc = temp[1];


            /* Calculating closing balance total for all the child groups */
            string[] temp2 = Calculate_withdc(this.cl_total, this.cl_total_dc, Convert.ToDecimal(this.children_groups[counter].cl_total), (this.children_groups[counter].cl_total_dc).ToString());

            this.cl_total = Convert.ToDecimal(temp2[0]);
            this.cl_total_dc = temp2[1];

            /* Calculate Dr and Cr total */
            this.dr_total = this.dr_total + this.children_groups[counter].dr_total;
            this.cr_total = this.cr_total + this.children_groups[counter].cr_total;

            counter++;
        }

    }
    /**
 * Find and add subledgers as array items
 */
    public Dictionary<int, Acc_list> children_ledgers = new Dictionary<int, Acc_list>();
    Acc_list[] c = new Acc_list[10];

    public void add_sub_ledgers()
    {
        acc = new MicroAccountsEntities1();

        var child_ledger_q = (from c in acc.tbl_AccLedger
                              where c.groupId == this.g_idd
                              select c).ToList();

        counter = 0;

        foreach (tbl_AccLedger ledg in child_ledger_q)
        {

            c[counter] = new Acc_list();
            c[counter].id = Convert.ToInt32(ledg.Id);
            c[counter].name = ledg.ledgerName;

            c[counter].l_group_id = Convert.ToInt32(ledg.groupId);
            c[counter].l_type = ledg.type;
            c[counter].l_notes = ledg.notes;

            //this.children_ledgers[counter] = new Acc_list();


            children_ledgers.Add(counter, c[counter]);

            //this.children_ledgers[counter].id = Convert.ToInt32(ledg.Id);
            //this.children_ledgers[counter].name = ledg.name;

            //this.children_ledgers[counter].l_group_id = Convert.ToInt32(ledg.group_id);
            //this.children_ledgers[counter].l_type = ledg.type;
            //this.children_ledgers[counter].l_reconciliation = ledg.reconciliation;
            //this.children_ledgers[counter].l_notes = ledg.notes;

            /* If start date is specified dont use the opening balance since its not applicable  */
            if (start_date == null || start_date == "")
            {
                this.c[counter].op_total = Convert.ToDecimal(ledg.opBalance);
                this.c[counter].op_total_dc = ledg.opBalanceDC;

            }
            else
            {
                c[counter].op_total = Convert.ToDecimal(0.00);
                c[counter].op_total_dc = ledg.opBalanceDC;
            }
            /* Calculating current group opening balance total */

            string[] temp3 = Calculate_withdc(this.op_total, this.op_total_dc, Convert.ToDecimal(c[counter].op_total), (c[counter].op_total_dc).ToString());

            this.op_total = Convert.ToDecimal(temp3[0]);
            this.op_total_dc = temp3[1];

            if (only_opening == true)
            {
                c[counter].dr_total = 0;
                c[counter].cr_total = 0;

                c[counter].cl_total = c[counter].op_total;
                c[counter].cl_total_dc = c[counter].op_total_dc;

            }
            else
            {
                cl_balance = new closing_balance();
                string[] cl = cl_balance.closing_balances(Convert.ToInt32(ledg.Id), start_date, end_date);


                c[counter].dr_total = Convert.ToDecimal(cl[2]);
                c[counter].cr_total = Convert.ToDecimal(cl[3]);

                c[counter].cl_total = Convert.ToDecimal(cl[1]);
                c[counter].cl_total_dc = cl[0];

            }
            /* Calculating closing balance total for all the child groups*/
            string[] temp4 = Calculate_withdc(cl_total, cl_total_dc, Convert.ToDecimal(c[counter].cl_total), (c[counter].cl_total_dc).ToString());

            cl_total = Convert.ToDecimal(temp4[0]);
            cl_total_dc = temp4[1];


            /* Calculate Dr and Cr total   */
            this.dr_total = this.dr_total + c[counter].dr_total;
            this.cr_total = this.cr_total + c[counter].cr_total;

            //   children_ledgers.Add(children_ledgers[counter]);
            counter++;
        }
    }
    public string[] Calculate_withdc(decimal param1, string param1_dc, decimal param2, string param2_dc)
    {

        decimal result = 0;
        string result_dc = "D";

        if (param1_dc == "D" && param2_dc == "D")
        {

            result = param1 + param2;
            result_dc = "D";
        }

        else if (param1_dc == "C" && param2_dc == "C")
        {
            result = param1 + param2;
            result_dc = "C";
        }
        else
        {
            if (param1 > param2)
            {
                result = param1 - param2;
                result_dc = param1_dc;
            }
            else
            {
                result = param2 - param1;
                result_dc = param2_dc;
            }
        }

        string[] array = new string[] { result.ToString(), result_dc };

        return array;
    }
}