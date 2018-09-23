using BJMicroAccounts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for closing_balance
/// </summary>
public class closing_balance
{

    MicroAccountsEntities1 acc;
    decimal dr_total;
    decimal cr_total;
    decimal dr_total_final;
    decimal cr_total_final;
    decimal dr_total_dc;
    decimal cr_total_dc;
    decimal op_total = 0;
    string op_total_dc;
    decimal cl = 0;
    string cl_dc = "";
    decimal total_op = 0;
    public string[] closing_balances(int id, string start_date = null, string end_date = null)
    {

        acc = new MicroAccountsEntities1();
        var dtotal = "";
        var ctotal = "";
        if (id == null)
        {
            throw new ArgumentException("Ledger not specified. Failed to calculate closing balance.");
            // Response.Write("Ledger not specified. Failed to calculate closing balance.");
        }

        var op = (from c in acc.tbl_AccLedger
                  where c.Id == id
                  select c).First();

        op_total = 0;
        op_total_dc = op.opBalanceDC;
        if (start_date == null || start_date == "")
        {
            if (op.opBalance == null)
            {
                op_total = 0;
            }
            else
            {
                /* If start date is not specified then return here */

                op_total =Convert.ToDecimal( op.opBalance);
            }
            //string[] array = new string[] { op_total_dc, Convert.ToDecimal(op_total).ToString() };
            //return array;
        }

        /* Dedit total */

        if (start_date != "")
        {
            //var date = Convert.ToDateTime(start_date);

            //dtotal = (from c_entryItems in acc.tbl_TransactionMaster
            //          where c_entryItems.ledgerId == id && c_entryItems.dc == "D" && c_entryItems.Entry.date >= date
            //          select c_entryItems.amount).Sum().ToString();

            DateTime sDate = Convert.ToDateTime(start_date);

            dtotal = acc.tbl_TransactionMaster.Where(x => x.ledgerId == id && x.tDate >= sDate).Select(x => x.drAmt).Sum().ToString();
        }
        if (end_date != "")
        {
            //var date = Convert.ToDateTime(end_date);
            //dtotal = (from c_entryItems in acc.EntryItems
            //          where c_entryItems.ledgerID == id && c_entryItems.dc == "D" && c_entryItems.Entry.date <= date
            //          select c_entryItems.amount).Sum().ToString();

            DateTime eDate = Convert.ToDateTime(start_date);

            dtotal = acc.tbl_TransactionMaster.Where(x => x.ledgerId == id && x.tDate >= eDate).Select(x => x.drAmt).Sum().ToString();

        }

        dtotal = (from c_entryItems in acc.tbl_TransactionMaster
                  where c_entryItems.ledgerId == id
                  select c_entryItems.drAmt).Sum().ToString();

        if (dtotal == null)
        {
            dr_total = 0;
        }
        else
        {
            if (dtotal == "")
            {
                dtotal = "0.00";
            }
            dr_total = Convert.ToDecimal(dtotal);
        }


        /* Credit total */
        if (start_date != "")
        {
            //var date = Convert.ToDateTime(start_date);

            //ctotal = (from c_entryItems in acc.EntryItems
            //          where c_entryItems.ledgerID == id && c_entryItems.dc == "C" && c_entryItems.Entry.date >= date
            //          select c_entryItems.amount).Sum().ToString();

            DateTime sDate = Convert.ToDateTime(start_date);

            ctotal = acc.tbl_TransactionMaster.Where(x => x.ledgerId == id && x.tDate >= sDate).Select(x => x.crAmt).Sum().ToString();

        }
        if (end_date != "")
        {
            //var date = Convert.ToDateTime(end_date);
            //ctotal = (from c_entryItems in acc.EntryItems
            //          where c_entryItems.ledgerID == id && c_entryItems.dc == "C" && c_entryItems.Entry.date <= date
            //          select c_entryItems.amount).Sum().ToString();
            DateTime sDate = Convert.ToDateTime(start_date);

            ctotal = acc.tbl_TransactionMaster.Where(x => x.ledgerId == id && x.tDate >= sDate).Select(x => x.crAmt).Sum().ToString();


        }
        ctotal = (from c_entryItems in acc.tbl_TransactionMaster
                  where c_entryItems.ledgerId == id
                  select c_entryItems.crAmt).Sum().ToString();

        if (ctotal == null)
        {
            cr_total = 0;
        }
        else
        {
            if (ctotal == "")
            {
                ctotal = "0.00";
                cr_total = Convert.ToDecimal(ctotal);
            }
            else
            {
                cr_total = Convert.ToDecimal(ctotal);
            }
        }
        /* Add opening balance */
        if (op_total_dc == "D")
        {
            dr_total_dc = op_total + dr_total;
            cr_total_dc = cr_total;
        }

        else
        {
            dr_total_dc = dr_total;

            cr_total_dc = op_total + cr_total;
        }
        /* Calculate and update closing balance */

        cl = 0;
        cl_dc = "";
        if (dr_total_dc > cr_total_dc)
        {
            cl = dr_total_dc - cr_total_dc;
            cl_dc = "D";
        }
        else if (dr_total_dc == cr_total_dc)
        {
            cl = 0;
            cl_dc = op_total_dc;
        }
        else
        {
            cl = cr_total_dc - dr_total_dc;
            cl_dc = "C";
        }

        string[] cl_array = new string[] { cl_dc, cl.ToString(), Convert.ToDecimal(dr_total).ToString(), Convert.ToDecimal(cr_total).ToString() };
        return cl_array;

    }
    public string[] opening_diff(int accnt_id)
    {
        acc = new MicroAccountsEntities1();
        var ledger = from c in acc.tbl_AccLedger
                     select c;

        foreach (tbl_AccLedger ledg in ledger)
        {
            if (ledg.opBalanceDC == "D")
            {
                total_op = Convert.ToDecimal(total_op + ledg.opBalance);
            }
            else
            {
                total_op = Convert.ToDecimal(total_op - ledg.opBalance);
            }
        }

        if (total_op >= 0)
        {

            string[] op_array = new string[] { "C", Convert.ToDecimal(total_op).ToString() };
            return op_array;

        }
        else
        {
            string[] op_array = new string[] { "D", Convert.ToDecimal(total_op).ToString() };
            return op_array;
        }
    }
}
