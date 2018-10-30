using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MicroAccounts.UserControls;
using BJMicroAccounts.UserControls;

namespace MicroAccounts
{
    public partial class MainDashboard : Form
    {
        string userName;
        public MainDashboard(string LoginName)
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            userName = LoginName;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();

            label1.Text = "Dashboard";
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            DashBoard db = new DashBoard(userName);
            db.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(db);
            db.Show();

            entriesButtonHide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Stock Inventory";
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            //  mySecondCustomControl1.BringToFront();
            StockInventoryDetails db = new StockInventoryDetails();
            MainWindow.Controls.Add(db);
            db.Dock = DockStyle.Fill;
            db.Show();

            entriesButtonHide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            lblAdmin.Text = userName;

            MainWindow.Controls.Clear();

            label1.Text = "Dashboard";
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            DashBoard db = new DashBoard(userName);
            db.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(db);
            db.Show();

            entriesButtonHide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;
            label1.Text = "User Registration";

            NewUserRegistration nr = new NewUserRegistration();

            nr.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(nr);
            nr.Show();
            nr.DataGridSource();

            entriesButtonHide();
        }

        public void showPay()
        {
            //Payment nr = new Payment();

            //nr.Dock = DockStyle.Fill;
            //MainWindow.Controls.Add(nr);
            //nr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button5.Height;
            SidePanel.Top = button5.Top;
            Group grp = new Group();
            grp.ShowDialog();
            label1.Text = "Account Group";

            entriesButtonHide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();

            SidePanel.Height = button8.Height;
            SidePanel.Top = button8.Top;

            LedgerDetails ss = new LedgerDetails();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();
            label1.Text = "Account Ledger";

            entriesButtonHide();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Supplier Details";
            SidePanel.Height = button9.Height;
            SidePanel.Top = button9.Top;


            SupplierDetails ss = new SupplierDetails();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Customer Details";
            SidePanel.Height = button7.Height;
            SidePanel.Top = button7.Top;

            CustomerDetails ss = new CustomerDetails();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Purchase Register";
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;

            PurchaseDetails ss = new PurchaseDetails();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Sales Register";
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;

            SalesDetails ss = new SalesDetails();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
        }


        void entriesButtonShow()
        {
            btnPayment.Visible = btnContra.Visible = btnJournal.Visible = btnReceipt.Visible = true;
        }

        void entriesButtonHide()
        {
            btnPayment.Visible = btnContra.Visible = btnJournal.Visible = btnReceipt.Visible = false;
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            SidePanel.Height = btnPayment.Height;
            SidePanel.Top = btnPayment.Top;
            label1.Text = "Receipt";

            Payment nr = new Payment(2);

            nr.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(nr);
            nr.Show();

            entriesButtonShow();

            btnPayment.Enabled = true;
            btnReceipt.Enabled = false;
            btnJournal.Enabled = true;
            btnContra.Enabled = true;

            btnReceipt.BackColor = Color.LightGray;
            btnPayment.BackColor = Color.Black;
            btnJournal.BackColor = Color.Black;
            btnContra.BackColor = Color.Black;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            SidePanel.Height = btnPayment.Height;
            SidePanel.Top = btnPayment.Top;
            label1.Text = "Payment";

            Payment nr = new Payment(1);

            nr.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(nr);
            nr.Show();

            entriesButtonShow();

            btnPayment.Enabled = false;
            btnReceipt.Enabled = true;
            btnJournal.Enabled = true;
            btnContra.Enabled = true;

            btnReceipt.BackColor = Color.Black;
            btnPayment.BackColor = Color.LightGray;
            btnJournal.BackColor = Color.Black;
            btnContra.BackColor = Color.Black;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            SidePanel.Height = button10.Height;
            SidePanel.Top = button10.Top;
            label1.Text = "Payment";

            Payment nr = new Payment(1);

            nr.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(nr);
            nr.Show();

            entriesButtonShow();

            btnPayment.Enabled = false;
            btnReceipt.Enabled = true;
            btnJournal.Enabled = true;
            btnContra.Enabled = true;


            btnReceipt.BackColor = Color.Black;
            btnPayment.BackColor = Color.LightGray;
            btnJournal.BackColor = Color.Black;
            btnContra.BackColor = Color.Black;
        }

        private void btnJournal_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            SidePanel.Height = btnPayment.Height;
            SidePanel.Top = btnPayment.Top;
            label1.Text = "Journal";

            Payment nr = new Payment(3);

            nr.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(nr);
            nr.Show();

            entriesButtonShow();

            btnPayment.Enabled = true;
            btnReceipt.Enabled = true;
            btnJournal.Enabled = false;
            btnContra.Enabled = true;


            btnReceipt.BackColor = Color.Black;
            btnPayment.BackColor = Color.Black;
            btnJournal.BackColor = Color.LightGray;
            btnContra.BackColor = Color.Black;
        }

        private void btnContra_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            SidePanel.Height = btnPayment.Height;
            SidePanel.Top = btnPayment.Top;
            label1.Text = "Contra";

            Payment nr = new Payment(4);

            nr.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(nr);
            nr.Show();

            entriesButtonShow();

            btnPayment.Enabled = true;
            btnReceipt.Enabled = true;
            btnJournal.Enabled = true;
            btnContra.Enabled = false;


            btnReceipt.BackColor = Color.Black;
            btnPayment.BackColor = Color.Black;
            btnJournal.BackColor = Color.Black;
            btnContra.BackColor = Color.LightGray;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Balance Sheet";
            SidePanel.Height = button11.Height;
            SidePanel.Top = button11.Top;

            BalanceSheet ss = new BalanceSheet();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Amount Payable";
            SidePanel.Height = button12.Height;
            SidePanel.Top = button12.Top;

            PayableAmt ss = new PayableAmt();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();

            btnPayment.Show();
            btnReceipt.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Amount Receivable";
            SidePanel.Height = button14.Height;
            SidePanel.Top = button14.Top;

            RecievableAmt ss = new RecievableAmt();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
            btnReceipt.Show();
            btnPayment.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Purchase/Sales Report";
            SidePanel.Height = button16.Height;
            SidePanel.Top = button16.Top;

            PurchaseSalesReport ss = new PurchaseSalesReport();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            MainWindow.Controls.Clear();
            label1.Text = "Trial Balance";
            SidePanel.Height = button17.Height;
            SidePanel.Top = button17.Top;

            TrailBalance ss = new TrailBalance();
            ss.Dock = DockStyle.Fill;
            MainWindow.Controls.Add(ss);
            ss.Show();

            entriesButtonHide();
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
