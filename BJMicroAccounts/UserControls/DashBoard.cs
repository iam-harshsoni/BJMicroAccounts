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
using MicroAccounts.ViewModel;
using MicroAccounts.AccountsModuleClasses;
using MicroAccounts.Forms;

namespace MicroAccounts.UserControls
{
    public partial class DashBoard : UserControl
    {
        MicroAccountsEntities1 _entities;
        AmtFormatting amtFormat = new AmtFormatting();
        string passedUname;
        public DashBoard(string uName)
        {
            InitializeComponent();
            passedUname = uName;
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd-MM-yyyy";

                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "dd-MM-yyyy";

                dataGridBind();

                _entities = new MicroAccountsEntities1();

                DateTime todayDate = DateTime.Today.Date;

                var data = _entities.DailyRates.Where(x => x.date == todayDate).FirstOrDefault();


                if (data == null)
                    btnEnterRates.Enabled = true;
                else
                {
                    btnEnterRates.Enabled = false;

                    lblFine.Text = amtFormat.comma(data.fineGold).ToString();
                    lbl22C.Text = amtFormat.comma(data.twentyTwoC).ToString();
                    lbl23C.Text = amtFormat.comma(data.twentyThreeC).ToString();
                    lblhallMarkBuyBack.Text = amtFormat.comma(data.hallmarkBuyBack).ToString();
                    lblHallMark.Text = amtFormat.comma(data.hallmark).ToString();
                    lblSilver.Text = amtFormat.comma(data.silver).ToString();
                }
            }
            catch (Exception x)
            {

            }
        }

        private void dataGridBind()
        {
            try
            {
                dgDailyRateReport.AutoGenerateColumns = false;
                int rowNo = 1;
                _entities = new MicroAccountsEntities1();

                var data = _entities.DailyRates.OrderByDescending(x => x.id).ToList();
                List<DailyRateVM> modelList = new List<DailyRateVM>();

                foreach (var item in data)
                {
                    if (data.Count < 8)
                    {

                        DailyRateVM model = new DailyRateVM();
                        model.id = item.id;
                        model.rowNo = rowNo;
                        model.date = Convert.ToDateTime(item.date).Date.ToString("dd-MM-yyyy");

                        model.fineGold = Convert.ToDecimal(amtFormat.comma(item.fineGold));
                        model.twentyTwoC = Convert.ToDecimal(amtFormat.comma(item.twentyTwoC));
                        model.twentyThreeC = Convert.ToDecimal(amtFormat.comma(item.twentyThreeC));
                        model.silver = Convert.ToDecimal(amtFormat.comma(item.silver));
                        model.hallmark = Convert.ToDecimal(amtFormat.comma(item.hallmark));
                        model.hallmarkBuyBack = Convert.ToDecimal(amtFormat.comma(item.hallmarkBuyBack));

                        modelList.Add(model);
                        rowNo++;
                    }
                }

                dgDailyRateReport.DataSource = modelList;
            }
            catch (Exception x)
            {

            }
        }

        private void dgPurchaseReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _entities = new MicroAccountsEntities1();

                int rowNo = 1;
                dgDailyRateReport.AutoGenerateColumns = false;
                _entities = new MicroAccountsEntities1();

                List<DailyRateVM> modelList = new List<DailyRateVM>();
                List<DailyRate> data = new List<DailyRate>();

                DateTime fromdate = DateTime.ParseExact(dateTimePicker1.Text, "dd-MM-yyyy", null);
                DateTime todate = DateTime.ParseExact(dateTimePicker2.Text, "dd-MM-yyyy", null);

                if (fromdate > todate)
                {
                    MessageBox.Show("Invalid date entered. Select valid dates");
                    return;
                }
                else
                {
                    data = _entities.DailyRates.Where(x => x.date >= fromdate && x.date <= todate).OrderByDescending(x => x.id).ToList();

                    foreach (var item in data)
                    {
                        DailyRateVM model = new DailyRateVM();
                        model.id = item.id;
                        model.rowNo = rowNo;
                        model.date = Convert.ToDateTime(item.date).Date.ToString("dd-MM-yyyy");

                        model.fineGold = Convert.ToDecimal(amtFormat.comma(item.fineGold));
                        model.twentyTwoC = Convert.ToDecimal(amtFormat.comma(item.twentyTwoC));
                        model.twentyThreeC = Convert.ToDecimal(amtFormat.comma(item.twentyThreeC));
                        model.silver = Convert.ToDecimal(amtFormat.comma(item.silver));
                        model.hallmark = Convert.ToDecimal(amtFormat.comma(item.hallmark));
                        model.hallmarkBuyBack = Convert.ToDecimal(amtFormat.comma(item.hallmarkBuyBack));

                        modelList.Add(model);
                        rowNo++;

                    }

                    dgDailyRateReport.DataSource = modelList;
                }
            }
            catch (Exception x)
            {

            }
        }

        private void btnEnterRates_Click(object sender, EventArgs e)
        {
            DailyGoldRates dr = new DailyGoldRates(passedUname,0,1);
            dr.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.Date.ToString();
            dateTimePicker2.Text = DateTime.Now.Date.ToString();
            dataGridBind();
        }

        private void dgDailyRateReport_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgDailyRateReport.CurrentRow.Index != -1 && dgDailyRateReport.CurrentRow.Cells[1].Value != null)
                {
                    var lID = Convert.ToInt32(dgDailyRateReport.CurrentRow.Cells[0].Value);

                    DailyGoldRates acc = new DailyGoldRates(passedUname,lID,1);
                    acc.ShowDialog();
                    dataGridBind();
                }
            }
            catch(Exception x)
            {

            }
        }

        private void lblFine_Click(object sender, EventArgs e)
        {

        }

        private void lblHallMark_Click(object sender, EventArgs e)
        {

        }
    }
}
