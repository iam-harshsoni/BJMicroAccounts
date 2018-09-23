using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BJMicroAccounts.Data;

namespace BJMicroAccounts.AccountsModuleClasses
{
    public class DbBackup
    {
        SqlConnection con = new SqlConnection(BJMicroAccounts.Properties.Settings.Default.MicroAccountsConnectionString);

        MicroAccountsEntities1 _entities;
        public void deleteBJ()
        {
            //Delete Data----------------------------------------------------------------

            #region DailyRates
            //Delete Data From dataBase
            _entities = new MicroAccountsEntities1();

            var data = _entities.DailyRates.ToList();

            foreach (var item in data)
            {
                _entities.DailyRates.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_TransactionMaster
            //Delete Data From dataBase
            _entities = new MicroAccountsEntities1();

            var data1 = _entities.tbl_TransactionMaster.ToList();

            foreach (var item in data1)
            {
                _entities.tbl_TransactionMaster.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_EntryDetails
            //Delete Data From dataBase
            _entities = new MicroAccountsEntities1();

            var data2 = _entities.tbl_EntryDetails.ToList();

            foreach (var item in data2)
            {
                _entities.tbl_EntryDetails.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_Entry
            //Delete Data From dataBase
            _entities = new MicroAccountsEntities1();

            var data3 = _entities.tbl_Entry.ToList();

            foreach (var item in data3)
            {
                _entities.tbl_Entry.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_PurchaseDetail
            _entities = new MicroAccountsEntities1();

            var data4 = _entities.tbl_PurchaseDetail.ToList();

            foreach (var item in data4)
            {
                _entities.tbl_PurchaseDetail.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_PurchaseMaster
            _entities = new MicroAccountsEntities1();

            var data6 = _entities.tbl_PurchaseMaster.ToList();

            foreach (var item in data6)
            {
                _entities.tbl_PurchaseMaster.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_SalesDetails

            _entities = new MicroAccountsEntities1();

            var data7 = _entities.tbl_SalesDetails.ToList();

            foreach (var item in data7)
            {
                _entities.tbl_SalesDetails.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_SalesMaster
            _entities = new MicroAccountsEntities1();

            var data8 = _entities.tbl_SalesMaster.ToList();

            foreach (var item in data8)
            {
                _entities.tbl_SalesMaster.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_StockItemDetails
            _entities = new MicroAccountsEntities1();

            var data9 = _entities.tbl_StockItemDetails.ToList();

            foreach (var item in data9)
            {
                _entities.tbl_StockItemDetails.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_ItemMaster
            _entities = new MicroAccountsEntities1();

            var data10 = _entities.tbl_ItemMaster.ToList();

            foreach (var item in data10)
            {
                _entities.tbl_ItemMaster.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_CategoryMaster
            _entities = new MicroAccountsEntities1();

            var data11 = _entities.tbl_CategoryMaster.ToList();

            foreach (var item in data11)
            {
                _entities.tbl_CategoryMaster.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_LedgerDetails
            _entities = new MicroAccountsEntities1();

            var data12 = _entities.tbl_LedgerDetails.ToList();

            foreach (var item in data12)
            {
                _entities.tbl_LedgerDetails.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_AccLedger
            _entities = new MicroAccountsEntities1();

            var data13 = _entities.tbl_AccLedger.ToList();

            foreach (var item in data13)
            {
                _entities.tbl_AccLedger.Remove(item);
                _entities.SaveChanges();
            }
            #endregion

            #region tbl_AccGroup
            _entities = new MicroAccountsEntities1();

            var data14 = _entities.tbl_AccGroup.ToList();

            foreach (var item in data14)
            {
                _entities.tbl_AccGroup.Remove(item);
                _entities.SaveChanges();
            }
            #endregion
        }
        public void tackBKP()
        {
            string database = con.Database.ToString();
            try
            { 
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK='E:\\Projects\\BKP\\DB\\" + "Database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                    using (SqlCommand command = new SqlCommand(cmd, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        command.ExecuteNonQuery();
                        con.Close();
                      // MessageBox.Show("BackUp Created Successfully!");
                    
                    }

                 
            }
            catch (Exception x)
            {

            }
        }
    }
}
