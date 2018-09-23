using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BJMicroAccounts.Data;

namespace BJMicroAccounts.App_Code
{
    public class GenerateXmlFileOfDb
    {
        SqlConnection cnn;
        MicroAccountsEntities1 _entities;
        public void BjAdipur()  //Xml ma data banava mate
        {
            string str = Properties.Settings.Default.MicroAccountsConnectionString;

            cnn = new SqlConnection(str);

            cnn.Open();

            #region DailyRates
            string strSQL = "Select * from DailyRates";
            SqlDataAdapter dt = new SqlDataAdapter(strSQL, cnn);

            DataSet ds = new DataSet();

            dt.Fill(ds, "DailyRates");
            ds.WriteXml(File.OpenWrite(@"Data\DailyRates.xml"));
              
            #endregion

            #region tbl_AccGroup
            strSQL = "Select * from tbl_AccGroup";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_AccGroup");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_AccGroup.xml"));

            #endregion
 
            #region tbl_AccLedger
            strSQL = "Select * from tbl_AccLedger";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_AccLedger");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_AccLedger.xml"));

            cnn.Close();
            #endregion

            #region tbl_CategoryMaster
            strSQL = "Select * from tbl_CategoryMaster";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_CategoryMaster");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_CategoryMaster.xml"));

            cnn.Close();
            #endregion

            #region tbl_Entry
            strSQL = "Select * from tbl_Entry";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_AccLedger");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_Entry.xml"));

            cnn.Close();
            #endregion

            #region tbl_EntryDetails
            strSQL = "Select * from tbl_EntryDetails";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_EntryDetails");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_EntryDetails.xml"));

            cnn.Close();
            #endregion

            #region tbl_ItemMaster
            strSQL = "Select * from tbl_ItemMaster";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_ItemMaster");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_ItemMaster.xml"));

            cnn.Close();
            #endregion

            #region tbl_LedgerDetails
            strSQL = "Select * from tbl_LedgerDetails";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_LedgerDetails");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_LedgerDetails.xml"));

            cnn.Close();
            #endregion

            #region tbl_PurchaseDetail
            strSQL = "Select * from tbl_PurchaseDetail";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_PurchaseDetail");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_PurchaseDetail.xml"));

            cnn.Close();
            #endregion

            #region tbl_PurchaseMaster
            strSQL = "Select * from tbl_PurchaseMaster";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_PurchaseMaster");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_PurchaseMaster.xml"));

            cnn.Close();
            #endregion

            #region tbl_SalesDetails
            strSQL = "Select * from tbl_SalesDetails";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_SalesDetails");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_SalesDetails.xml"));

            cnn.Close();
            #endregion

            #region tbl_SalesMaster
            strSQL = "Select * from tbl_SalesMaster";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_SalesMaster");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_SalesMaster.xml"));

            cnn.Close();
            #endregion

            #region tbl_StockItemDetails
            strSQL = "Select * from tbl_StockItemDetails";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_StockItemDetails");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_StockItemDetails.xml"));

            cnn.Close();
            #endregion

            #region tbl_TransactionMaster
            strSQL = "Select * from tbl_TransactionMaster";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_TransactionMaster");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_TransactionMaster.xml"));

            cnn.Close();
            #endregion

            #region tbl_UserLogiln
            strSQL = "Select * from tbl_UserLogiln";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_UserLogiln");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_UserLogiln.xml"));

            cnn.Close();
            #endregion

            #region tbl_UserProfile
            strSQL = "Select * from tbl_UserProfile";
            dt = new SqlDataAdapter(strSQL, cnn);

            ds = new DataSet();

            dt.Fill(ds, "tbl_UserProfile");
            ds.WriteXml(File.OpenWrite(@"Data\tbl_UserProfile.xml"));

            cnn.Close();
            #endregion

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

            var data13= _entities.tbl_AccLedger.ToList();

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

            //#region tbl_UserLogiln
            //_entities = new MicroAccountsEntities1();

            //var data15 = _entities.tbl_UserLogiln.ToList();

            //foreach (var item in data15)
            //{
            //    _entities.tbl_UserLogiln.Remove(item);
            //    _entities.SaveChanges();
            //}
            //#endregion

            //#region tbl_UserProfile
            //_entities = new MicroAccountsEntities1();

            //var data16 = _entities.tbl_UserLogiln.ToList();

            //foreach (var item in data16)
            //{
            //    _entities.tbl_UserLogiln.Remove(item);
            //    _entities.SaveChanges();
            //}
            //#endregion

        }

        public void BjAdipurAgain()   //Method to add data from xml file to sql server to new database
        {
            string str = Properties.Settings.Default.MicroAccountsConnectionString;

            cnn = new SqlConnection(str);
            // create data base with table with same fileds and run this
            cnn.Open();
             

            #region DailyRates
            DataSet ds = new DataSet();
            ds.ReadXml(@"Data\DailyRates.xml");

            DataTable dtPur = ds.Tables["DailyRates"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "DailyRates";
                bc.ColumnMappings.Add("id", "id");
                bc.ColumnMappings.Add("fineGold", "fineGold");
                bc.ColumnMappings.Add("hallmark", "hallmark");
                bc.ColumnMappings.Add("hallmarkBuyBack", "hallmarkBuyBack");
                bc.ColumnMappings.Add("twentyTwoC", "twentyTwoC");
                bc.ColumnMappings.Add("twentyThreeC", "twentyThreeC");
                bc.ColumnMappings.Add("silver", "silver");
                bc.ColumnMappings.Add("date", "date");
                bc.ColumnMappings.Add("createdDate", "createdDate");
              
                bc.WriteToServer(dtPur);

            }

            #endregion   

            #region tbl_AccGroup
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_AccGroup.xml");

            dtPur = ds.Tables["tbl_AccGroup"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_AccGroup";
                bc.ColumnMappings.Add("groupId", "groupId");
                bc.ColumnMappings.Add("id", "id");
                bc.ColumnMappings.Add("parentId", "parentId");
                bc.ColumnMappings.Add("groupName", "groupName");
                bc.ColumnMappings.Add("affects_gross", "affects_gross");
                //bc.ColumnMappings.Add("createdDate", "createdDate"); 
                //bc.ColumnMappings.Add("updateDate", "updateDate");

                bc.WriteToServer(dtPur);

            }

            #endregion

            #region tbl_AccLedger
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_AccLedger.xml");

            dtPur = ds.Tables["tbl_AccLedger"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_AccLedger";
                bc.ColumnMappings.Add("Id", "Id");
                bc.ColumnMappings.Add("groupId", "groupId");
                bc.ColumnMappings.Add("ledgerName", "ledgerName");
                bc.ColumnMappings.Add("opBalance", "opBalance");
                bc.ColumnMappings.Add("opBalanceDC", "opBalanceDC");
                bc.ColumnMappings.Add("type", "type");
                bc.ColumnMappings.Add("notes", "notes");
                //bc.ColumnMappings.Add("drId", "drId");
                //bc.ColumnMappings.Add("crId", "crId");
                //bc.ColumnMappings.Add("createdDate", "createdDate");
                //bc.ColumnMappings.Add("updatedDate", "updatedDate");

                bc.WriteToServer(dtPur);

            }

            #endregion

            #region tbl_CategoryMaster
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_CategoryMaster.xml");

            dtPur = ds.Tables["tbl_CategoryMaster"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_CategoryMaster";
                bc.ColumnMappings.Add("cId", "cId");
                bc.ColumnMappings.Add("cName", "cName");
                bc.ColumnMappings.Add("prefix", "prefix");
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updatedDate", "updatedDate");
              
                bc.WriteToServer(dtPur);

            }

            #endregion

            #region tbl_Entry
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_Entry.xml");

            dtPur = ds.Tables["tbl_Entry"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_Entry";
                bc.ColumnMappings.Add("voucherRefNo", "voucherRefNo");
                bc.ColumnMappings.Add("entryType", "entryType");
                bc.ColumnMappings.Add("crId", "crId");
                bc.ColumnMappings.Add("drId", "drId");
                bc.ColumnMappings.Add("amt", "amt");
                //bc.ColumnMappings.Add("date", "date");
                //bc.ColumnMappings.Add("stringDate", "stringDate");
                //bc.ColumnMappings.Add("remarks", "remarks");
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updatedDate", "updatedDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_EntryDetails
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_EntryDetails.xml");

            dtPur = ds.Tables["tbl_EntryDetails"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_EntryDetails";
                bc.ColumnMappings.Add("pDetailsId", "pDetailsId");
                bc.ColumnMappings.Add("voucherRefNo", "voucherRefNo");
                bc.ColumnMappings.Add("purchaseSalesIds", "purchaseSalesIds");
                bc.ColumnMappings.Add("amtPaid", "amtPaid"); 
                bc.ColumnMappings.Add("createdDate", "createdDate");
            //    bc.ColumnMappings.Add("updatedDate", "updatedDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_ItemMaster
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_ItemMaster.xml");

            dtPur = ds.Tables["tbl_ItemMaster"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_ItemMaster";
                bc.ColumnMappings.Add("id", "id");
                bc.ColumnMappings.Add("itemCode", "itemCode");
                bc.ColumnMappings.Add("categoryId", "categoryId"); 
                bc.ColumnMappings.Add("createdDate", "createdDate");
               bc.ColumnMappings.Add("updateDate", "updateDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_LedgerDetails
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_LedgerDetails.xml");

            dtPur = ds.Tables["tbl_LedgerDetails"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_LedgerDetails";
                bc.ColumnMappings.Add("id", "id");
                bc.ColumnMappings.Add("ledgerId", "ledgerId");
                bc.ColumnMappings.Add("address", "address");
                bc.ColumnMappings.Add("contact", "contact");
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updateDate", "updateDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_PurchaseDetail
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_PurchaseDetail.xml");

            dtPur = ds.Tables["tbl_PurchaseDetail"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_PurchaseDetail";
                bc.ColumnMappings.Add("pdetailsId", "pdetailsId");
                bc.ColumnMappings.Add("purchaseID", "purchaseID");
                bc.ColumnMappings.Add("productID", "productID");
                bc.ColumnMappings.Add("qty", "qty");
                bc.ColumnMappings.Add("weight", "weight");
                bc.ColumnMappings.Add("unit", "unit");
                bc.ColumnMappings.Add("melting", "melting");
                bc.ColumnMappings.Add("making", "making");
                bc.ColumnMappings.Add("rate", "rate");
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updatedDate", "updateDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_PurchaseMaster
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_PurchaseMaster.xml");

            dtPur = ds.Tables["tbl_PurchaseMaster"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_PurchaseMaster";
                bc.ColumnMappings.Add("pId", "pId");
                bc.ColumnMappings.Add("refNo", "refNo");
                bc.ColumnMappings.Add("ledgerId", "ledgerId");
                bc.ColumnMappings.Add("date", "date");
                bc.ColumnMappings.Add("totalWeight", "totalWeight");
                bc.ColumnMappings.Add("unit", "unit");
                bc.ColumnMappings.Add("totalMelting", "totalMelting");
                bc.ColumnMappings.Add("totalMaking", "totalMaking");
                bc.ColumnMappings.Add("totalAmt", "totalAmt");
                bc.ColumnMappings.Add("remarks", "remarks");
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updateDate", "updateDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_SalesDetails
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_SalesDetails.xml");

            dtPur = ds.Tables["tbl_SalesDetails"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_SalesDetails";
                bc.ColumnMappings.Add("sDetailsId", "sDetailsId");
                bc.ColumnMappings.Add("salesId", "salesId");
                bc.ColumnMappings.Add("productId", "productId");
                bc.ColumnMappings.Add("qty", "qty");
                bc.ColumnMappings.Add("weight", "weight");
                bc.ColumnMappings.Add("unit", "unit");
                bc.ColumnMappings.Add("karat", "karat");
                bc.ColumnMappings.Add("making", "making");
                bc.ColumnMappings.Add("rate", "rate"); 
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updateDate", "updateDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_SalesMaster
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_SalesMaster.xml");

            dtPur = ds.Tables["tbl_SalesMaster"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_SalesMaster";
                bc.ColumnMappings.Add("sId", "sId");
                bc.ColumnMappings.Add("billNo", "billNo");
                bc.ColumnMappings.Add("ledgerId", "ledgerId");
                bc.ColumnMappings.Add("date", "date");
                bc.ColumnMappings.Add("totalWeight", "totalWeight");
                bc.ColumnMappings.Add("unit", "unit");
                bc.ColumnMappings.Add("totalKarat", "totalKarat");
                bc.ColumnMappings.Add("totalMaking", "totalMaking");
                bc.ColumnMappings.Add("totalAmt", "totalAmt");
                bc.ColumnMappings.Add("remarks", "remarks");
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updateDate", "updateDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_StockItemDetails
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_StockItemDetails.xml");

            dtPur = ds.Tables["tbl_StockItemDetails"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_StockItemDetails";
                bc.ColumnMappings.Add("id", "id");
                bc.ColumnMappings.Add("itemId", "itemId");
                bc.ColumnMappings.Add("qty", "qty");
                bc.ColumnMappings.Add("weight", "weight");
                bc.ColumnMappings.Add("unit", "unit");
                bc.ColumnMappings.Add("melting", "melting");
                bc.ColumnMappings.Add("carret", "carret"); 
                bc.ColumnMappings.Add("remarks", "remarks");
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updatedDate", "updatedDate");

                bc.WriteToServer(dtPur);

            }
            #endregion

            #region tbl_TransactionMaster
            ds = new DataSet();
            ds.ReadXml(@"Data\tbl_TransactionMaster.xml");

            dtPur = ds.Tables["tbl_TransactionMaster"];

            using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            {
                bc.DestinationTableName = "tbl_TransactionMaster";
                bc.ColumnMappings.Add("tId", "tId");
                bc.ColumnMappings.Add("tDate", "tDate");
                bc.ColumnMappings.Add("voucherType", "voucherType");
                bc.ColumnMappings.Add("voucherRefNo", "voucherRefNo");
                bc.ColumnMappings.Add("crAmt", "crAmt");
                bc.ColumnMappings.Add("drAmt", "drAmt");
                bc.ColumnMappings.Add("ledgerId", "ledgerId");
             
                bc.ColumnMappings.Add("createdDate", "createdDate");
                bc.ColumnMappings.Add("updatedDate", "updatedDate");
                bc.ColumnMappings.Add("loginId", "loginId");    

                bc.WriteToServer(dtPur);

            }
            #endregion

            //#region tbl_UserLogiln
            //ds = new DataSet();
            //ds.ReadXml(@"Data\tbl_UserLogiln.xml");

            //dtPur = ds.Tables["tbl_UserLogiln"];

            //using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            //{
            //    bc.DestinationTableName = "tbl_UserLogiln";
            //    bc.ColumnMappings.Add("id", "id");
            //    bc.ColumnMappings.Add("userId", "userId");
            //    bc.ColumnMappings.Add("loginId", "loginId");
            //    bc.ColumnMappings.Add("password", "password");
            //    bc.ColumnMappings.Add("lastLogin", "lastLogin");
            //    bc.ColumnMappings.Add("unit", "unit"); 
              
            //    bc.ColumnMappings.Add("createdDate", "createdDate");
            //    bc.ColumnMappings.Add("updateDate", "updateDate");

            //    bc.WriteToServer(dtPur);

            //}
            //#endregion

            //#region tbl_UserProfile
            //ds = new DataSet();
            //ds.ReadXml(@"Data\tbl_UserProfile.xml");

            //dtPur = ds.Tables["tbl_UserProfile"];

            //using (SqlBulkCopy bc = new SqlBulkCopy(cnn))
            //{
            //    bc.DestinationTableName = "tbl_UserProfile";
            //    bc.ColumnMappings.Add("userId", "userId");
            //    bc.ColumnMappings.Add("email", "email");
            //    bc.ColumnMappings.Add("firstName", "firstName");
            //    bc.ColumnMappings.Add("lastName", "lastName");
            //    bc.ColumnMappings.Add("mobile", "mobile");
            
            //    bc.ColumnMappings.Add("createdDate", "createdDate");
            //    bc.ColumnMappings.Add("updateDate", "updateDate");

            //    bc.WriteToServer(dtPur);

            //}
            //#endregion


            cnn.Close();
        }
    }
}
