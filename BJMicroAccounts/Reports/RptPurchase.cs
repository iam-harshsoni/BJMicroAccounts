using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroAccounts;
using BJMicroAccounts.Data;
using System.Data.SqlClient; 
using Microsoft.Reporting.WinForms;
using System.IO;
using BJMicroAccounts.App_Code;
using System.Net.Mail;
using MicroAccounts.ViewModel;

namespace BJMicroAccounts.Reports
{
    public partial class RptPurchase : Form
    {
        SqlConnection cnn;
        private string passedId = "";
        MicroAccountsEntities1 _en;
        public RptPurchase(string id)
        {

            string str = Properties.Settings.Default.Dummy;

            cnn = new SqlConnection(str);

            InitializeComponent();
            this.passedId = id;
        }

        private void RptPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                //SqlDataAdapter dap = new SqlDataAdapter("SELECT tbl_PurchaseMaster.*, tbl_AccLedger.* FROM tbl_AccLedger INNER JOIN tbl_PurchaseMaster ON tbl_AccLedger.Id = tbl_PurchaseMaster.ledgerId where refNo='" + this.passedId + "'", cnn);
                //PurchaseDataSet ds = new PurchaseDataSet();
                //dap.Fill(ds, "DataTable1");

                _en = new MicroAccountsEntities1();
                var data = _en.tbl_PurchaseMaster.ToList();

                List<PurchaseMasterVM> listVm = new List<PurchaseMasterVM>();

                foreach (var item in data)
                {
                    PurchaseMasterVM vm = new PurchaseMasterVM();

                    vm.ledgerName = _en.tbl_AccLedger.Where(x => x.Id == item.ledgerId).FirstOrDefault().ledgerName;

                    listVm.Add(vm); 
                }
                ReportDataSource datasource = new ReportDataSource();

                datasource.Name = "DataSet1";
                datasource.Value = listVm;
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(datasource);

                ReportDataSource datasource1 = new ReportDataSource();

                _en = new MicroAccountsEntities1();
                var data1 = _en.tbl_PurchaseDetail.ToList();

                List<PurchaseDetailsVM> DetailslistVm = new List<PurchaseDetailsVM>();

                foreach (var item in data1)
                {
                    PurchaseDetailsVM vm = new PurchaseDetailsVM();

                    vm.purchaseID = item.purchaseID;

                    DetailslistVm.Add(vm);
                }


                datasource1.Name = "DataSet2";
                datasource1.Value = DetailslistVm;
                
                this.reportViewer1.LocalReport.DataSources.Add(datasource1);

                //reportViewer1.LocalReport.ReportEmbeddedResource = "Redport1.rdlc";
                //ReportDataSource datasource = new ReportDataSource("PurchaseDataSet", ds.Tables[0]);
                //this.reportViewer1.LocalReport.DataSources.Clear();
                //this.reportViewer1.LocalReport.DataSources.Add(data.ToList());

                this.reportViewer1.RefreshReport();
                cnn.Close();
            }   
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }

            this.reportViewer1.RefreshReport();

             //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // GenerateXmlFileOfDb cn = new GenerateXmlFileOfDb();
                //  cn.BjAdipur();

                //MailMessage mail = new MailMessage("dropzonecomputer09@gmail.com", "harshsoni6011@gmail.com");
                //SmtpClient client = new SmtpClient();
                //client.Port = 25;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Host = "smtp.gmail.com";
                //client.Credentials = new System.Net.NetworkCredential("dropzonecomputer09@gmail.com", "Hs9898464496Hs");
                //mail.Subject = "this is a test email.";
                //mail.Body = "this is my test email body";
                //client.Send(mail);
                //_en = new MicroAccountsEntities1();
                //var data = _en.tbl_PurchaseMaster.ToList();
                //DataTable dt = new DataTable();

                //tbl_PurchaseMaster pur = new tbl_PurchaseMaster();
                //pur.GetType().GetProperties().ToList().ForEach(f => { try { f.GetValue(pur, null); dt.Columns.Add(f.Name, f.PropertyType); } catch (Exception x) { } });
                //foreach (var item in data)
                //{
                //    dt.Rows.Add(item.pId, item.refNo, item.ledgerId, item.remarks);
                //}

                //cnn.Open();
                //string strSQL = "Select * from tbl_PurchaseMaster";

                //SqlDataAdapter dt = new SqlDataAdapter(strSQL, cnn);

                //DataSet ds = new DataSet();

                //dt.Fill(ds, "tbl_PurchaseMaster");

                //ds.WriteXml(File.OpenWrite(@"PurchaseTabless.xml"));

                //cnn.Close();


                //   GmailClient 
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //cnn.Open();

                //DataSet ds = new DataSet();
                //ds.ReadXml(@"PurchaseTabless.xml");

                //DataTable dtPur = ds.Tables["tbl_PurchaseMaster"];

                //using (SqlBulkCopy bc=new SqlBulkCopy(cnn))
                //{
                //    bc.DestinationTableName = "tbl_PurchaseMaster";
                //    bc.ColumnMappings.Add("pId", "pId");
                //    bc.ColumnMappings.Add("refNo", "refNo");
                //    bc.ColumnMappings.Add("ledgerId", "ledgerId");
                //    bc.ColumnMappings.Add("date", "date");
                //    bc.ColumnMappings.Add("totalWeight", "totalWeight");
                //    bc.ColumnMappings.Add("unit", "unit");
                //    bc.ColumnMappings.Add("totalMelting", "totalMelting");
                //    bc.ColumnMappings.Add("totalMaking", "totalMaking");
                //    bc.ColumnMappings.Add("totalAmt", "totalAmt");
                //    bc.ColumnMappings.Add("remarks", "remarks");
                //    bc.ColumnMappings.Add("createdDate", "createdDate");
                //    bc.ColumnMappings.Add("updateDate", "updateDate");

                //    bc.WriteToServer(dtPur);

                //}
            }
            catch(Exception x)
            {
                
            }
        }
    }
}
