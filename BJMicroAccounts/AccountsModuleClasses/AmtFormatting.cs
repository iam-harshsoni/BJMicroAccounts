using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.AccountsModuleClasses
{
   public class AmtFormatting
    {
        public String comma(decimal? amount)
        {
            string result = "";
            string amt = "";
            string amt_paisa = "";

            amt = amount.ToString();
            int aaa = amount.ToString().IndexOf(".", 0);
            amt_paisa = amount.ToString().Substring(aaa + 1);

            if (amt == amt_paisa)
            {
                amt_paisa = "";
            }
            else
            {
                amt = amount.ToString().Substring(0, amount.ToString().IndexOf(".", 0));
                amt = (amt.Replace(",", "")).ToString();
            }
            switch (amt.Length)
            {
                case 9:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 2) + "," + amt.Substring(6, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 2) + "," + amt.Substring(6, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                case 8:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 2) + "," + amt.Substring(5, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 2) + "," + amt.Substring(5, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                case 7:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 2) + "," +
                                 amt.Substring(4, 3) + "." + amt_paisa;
                    }
                    break;
                case 6:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 2) + "," +
                                 amt.Substring(3, 3) + "." + amt_paisa;
                    }
                    break;
                case 5:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 2) + "," + amt.Substring(2, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                case 4:
                    if (amt_paisa == "")
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 3);
                    }
                    else
                    {
                        result = amt.Substring(0, 1) + "," + amt.Substring(1, 3) + "." +
                                 amt_paisa;
                    }
                    break;
                default:
                    if (amt_paisa == "")
                    {
                        result = amt;
                    }
                    else
                    {
                        result = amt + "." + amt_paisa;
                    }
                    break;
            }
            return result;
        }
    }
}
