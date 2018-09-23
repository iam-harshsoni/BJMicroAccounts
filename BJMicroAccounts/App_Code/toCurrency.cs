using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for toCurrency
/// </summary>
public class toCurrency
{
    public string toCurrenc(string dc, decimal amt)
    {
        if (amt == 0)
        {
            return "0.00";

        }
        if (dc == "D")
        {
            if (amt > 0)
            {
                return "Dr" + " " + Convert.ToDecimal(amt).ToString("#,##0.00");
            }
            else
            {
                return "Cr" + " " + Convert.ToDecimal(amt * -1).ToString("#,##0.00");
            }
        }

        else if (dc == "C")
        {
            if (amt > 0)
            {
                return "Cr" + " " + Convert.ToDecimal(amt).ToString("#,##0.00");
            }
            else
            {
                return "Dr" + " " + Convert.ToDecimal(amt * -1).ToString("#,##0.00");
            }
        }
        else if(dc=="X")
        /* Dr for positive and Cr for negative value */
        {
            if (amt > 0)
            {
                return "Dr" + " " + Convert.ToDecimal(amt).ToString("#,##0.00");
            }
            else
            {
                return "Cr" + " " + Convert.ToDecimal(amt * -1).ToString("#,##0.00");
            }
        }
        else
        {
            return Convert.ToDecimal(amt).ToString("#,##0.00");
        }
    }
}