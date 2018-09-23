using BJMicroAccounts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroAccounts.AccountsModuleClasses
{
    public class TransactionEntryClass
    {
        MicroAccountsEntities1 _entities;
        public void addRecord(string voucherType, decimal amt, string ledgerNameCR, string ledgerNameDR)
        {
            _entities = new MicroAccountsEntities1();
            tbl_TransactionMaster tm = new tbl_TransactionMaster();

            tm.tDate = DateTime.Now.Date;

            tm.voucherType = voucherType.ToString();

            if (voucherType == "Purchase")
            {
                tm.voucherRefNo = _entities.tbl_PurchaseMaster.OrderByDescending(x => x.pId).FirstOrDefault().pId;
            }

            else if (voucherType == "Sales")
            {
                tm.voucherRefNo = _entities.tbl_SalesMaster.OrderByDescending(x => x.sId).FirstOrDefault().sId;
            }

            else
            {
                tm.voucherType = voucherType.ToString();
                tm.voucherRefNo = _entities.tbl_Entry.OrderByDescending(x => x.voucherRefNo).FirstOrDefault().voucherRefNo;
            }

            if (voucherType == "Payment" || voucherType == "Purchase" || voucherType == "Journal")
            {
                tm.crAmt = Convert.ToDecimal(amt);
                tm.drAmt = 0;
            }
            else
            {
                tm.crAmt = 0;
                tm.drAmt = Convert.ToDecimal(amt);
            }


            tm.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == ledgerNameCR).FirstOrDefault().Id;
            tm.createdDate = DateTime.Now;
            //login id 

            _entities.tbl_TransactionMaster.Add(tm);
            _entities.SaveChanges();

            //Transaction Detials Entries --- DR----
            _entities = new MicroAccountsEntities1();

            tm = new tbl_TransactionMaster();
            tm.tDate = DateTime.Now.Date;
            tm.voucherType = voucherType;

            if (voucherType == "Purchase")
            {
                tm.voucherRefNo = _entities.tbl_PurchaseMaster.OrderByDescending(x => x.pId).FirstOrDefault().pId;
            }

            else if (voucherType == "Sales")
            {
                tm.voucherRefNo = _entities.tbl_SalesMaster.OrderByDescending(x => x.sId).FirstOrDefault().sId;

            }
            else
            {
                tm.voucherRefNo = _entities.tbl_Entry.OrderByDescending(x => x.voucherRefNo).FirstOrDefault().voucherRefNo;
            }

            if (voucherType == "Payment" || voucherType == "Purchase" || voucherType == "Journal")
            {
                tm.crAmt = 0;
                tm.drAmt = Convert.ToDecimal(amt);
            }
            else
            {
                tm.crAmt = Convert.ToDecimal(amt);
                tm.drAmt = 0;
            }

            tm.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == ledgerNameDR).FirstOrDefault().Id;
            tm.createdDate = DateTime.Now;
            //login id 

            _entities.tbl_TransactionMaster.Add(tm);
            _entities.SaveChanges();

        }

        public void updateRecord(long id, string voucherType, decimal amt, string ledgerNameCR, string ledgerNameDR)
        {
            int count = 0;
            _entities = new MicroAccountsEntities1();
            var data = _entities.tbl_TransactionMaster.Where(x => x.voucherRefNo == id).ToList();

            foreach (var tm in data)
            {
                if (count == 0)
                {
                    tm.tDate = DateTime.Now.Date;
                    tm.voucherType = voucherType.ToString();
                    tm.crAmt = Convert.ToDecimal(amt);
                    tm.drAmt = 0;
                    tm.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == ledgerNameCR).FirstOrDefault().Id;
                    tm.createdDate = DateTime.Now;
                    //login id 


                    _entities.SaveChanges();

                }
                //Transaction Detials Entries --- DR----
                if (count == 1)
                {

                    tm.tDate = DateTime.Now.Date;
                    tm.voucherType = voucherType;
                    tm.crAmt = 0;
                    tm.drAmt = Convert.ToDecimal(amt);
                    tm.ledgerId = _entities.tbl_AccLedger.Where(x => x.ledgerName == ledgerNameDR).FirstOrDefault().Id;
                    tm.createdDate = DateTime.Now;
                    //login id 

                    _entities.SaveChanges();

                    count = 0;
                }
                count++;
            }

        }
    }
}
