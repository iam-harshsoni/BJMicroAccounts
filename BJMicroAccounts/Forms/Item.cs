using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum;
using System.IO;
using BJMicroAccounts.Data;
using MicroAccounts.App_Code;
using MicroAccounts.ViewModel;
using DarrenLee.Media;

namespace MicroAccounts.Forms
{
    public partial class Item : Form
    {
        MicroAccountsEntities1 _entities;
        private Capture capture;        //takes images from camera as image frames
        private bool captureInProgress;
        private int itemIDGlobal, itemIdPassed = 0;

        int count = 0;
        Camera MyCamera = new Camera();

        public Item(int id)
        {
            this.itemIdPassed = this.itemIDGlobal = id;

            InitializeComponent();

            GetInfo();
            MyCamera.OnFrameArrived += MyCamera_OnFrameArrived;
        }

        private void GetInfo()
        {

            var cameraDevices = MyCamera.GetCameraSources();
            var cameraRedol = MyCamera.GetSupportedResolutions();

            foreach (var item in cameraDevices)
            {
                comboBox1.Items.Add(item);
            }

            foreach (var item in cameraRedol)
            {
                comboBox2.Items.Add(item);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }


        private void MyCamera_OnFrameArrived(Object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            pictureBox1.Image = img;
        }

        private void ReleaseData()
        {
            try
            {
                if (capture != null)
                    capture.Dispose();
            }
            catch (Exception x)
            {

            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            try
            {
                Image<Bgr, Byte> ImageFrame = capture.QuerySmallFrame();
                CamImgBoxs.Image = ImageFrame;
            }
            catch (Exception x)
            {
                // MessageBox.Show(x.ToString());
            }


        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        void comboBoxBind()
        {
            try
            {
                _entities = new MicroAccountsEntities1();

                var data = _entities.tbl_CategoryMaster;
                List<CategoryMasterVM> modellist = new List<CategoryMasterVM>();

                CategoryMasterVM model = new CategoryMasterVM();
                model.cId = -1;
                model.cName = "--Select--";

                modellist.Add(model);

                foreach (var item in data)
                {
                    model = new CategoryMasterVM();
                    model.cId = item.cId;
                    model.cName = item.cName;

                    modellist.Add(model);
                }

                cmbItemCategory.DataSource = modellist.ToList();
                cmbItemCategory.DisplayMember = "cName";
                cmbItemCategory.ValueMember = "cId";
            }
            catch (Exception x)
            {

            }
        }
        void clear()
        {
            cmbItemCategory.Focus();
            cmbUnit.SelectedIndex = 0;
            lblItemCode.Text = "---";
            txtMelting.Text = "0.00";
            txtQty.Text = "0";
            txtRemarks.Text = "";
            txtWeight.Text = "0.00";
            panel3.Hide();
            btnCreate.Text = "Create";
            CaptureBox.Image = null;
            cmbItemCategory.SelectedIndex = 0;

            cmbKarat.SelectedIndex = 0;
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            byte[] pic = null;
            try
            { 
                if (CaptureBox.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    CaptureBox.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    pic = stream.ToArray();
                }

                if (txtWeight.Text == string.Empty && txtMelting.Text == string.Empty && txtQty.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtWeight, "Enter all details.");
                    txtWeight.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter all details.";
                }
                else if (txtWeight.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtWeight, "Enter weight.");
                    txtWeight.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter weight.";
                }
                else if (txtQty.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtQty, "Enter qty.");
                    txtQty.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter qty.";
                }
                else if (txtMelting.Text == string.Empty)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtMelting, "Enter melting.");
                    txtMelting.Focus();
                    panel3.Visible = true;
                    lblError.Text = "Enter melting.";
                }

                //else if (CaptureBox.Image == null)
                //{
                //    errorProvider1.Clear();
                //    errorProvider1.SetError(CaptureBox, "Select Image.");
                //    CaptureBox.Focus();
                //    panel3.Visible = true;
                //    lblError.Text = "Select Image.";
                //}
                else
                {
                    if (btnCreate.Text == "Create")
                    {
                        //insert Code

                        _entities = new MicroAccountsEntities1();

                        tbl_ItemMaster itemMaster = new tbl_ItemMaster();
                        //itemMaster.categoryId = Convert.ToInt32(cmbItemCategory.SelectedValue);
                        itemMaster.categoryId = Convert.ToInt32(cmbItemCategory.SelectedValue);
                        itemMaster.photo = pic;
                        itemMaster.itemCode = lblItemCode.Text;
                        itemMaster.createdDate = DateTime.Now;

                        _entities.tbl_ItemMaster.Add(itemMaster);
                        _entities.SaveChanges();

                        tbl_StockItemDetails stockDetail = new tbl_StockItemDetails();
                        stockDetail.weight = Convert.ToDecimal(txtWeight.Text);

                        if (cmbKarat.SelectedIndex > 0)
                            stockDetail.carret = Convert.ToDecimal(cmbKarat.Text);
                        else
                            stockDetail.carret = 0;

                        stockDetail.qty = Convert.ToDecimal(txtQty.Text);
                        stockDetail.unit = cmbUnit.Text.ToString();
                        stockDetail.melting = Convert.ToDecimal(txtMelting.Text);
                        stockDetail.remarks = txtRemarks.Text.Trim().ToString();
                        stockDetail.itemId = _entities.tbl_ItemMaster.OrderByDescending(x => x.id).FirstOrDefault().id;
                        stockDetail.createdDate = DateTime.Now;
                        stockDetail.upadtedDate = DateTime.Now;

                        _entities.tbl_StockItemDetails.Add(stockDetail);
                        _entities.SaveChanges();

                        MessageBox.Show("Record Successfully Saved!");
                    }
                    else
                    {
                        //Update Code
                        _entities = new MicroAccountsEntities1();

                        var itemData = (from a in _entities.tbl_ItemMaster
                                        join b in _entities.tbl_StockItemDetails on a.id equals b.itemId
                                        where a.id == itemIDGlobal
                                        select new { a, b }).FirstOrDefault();

                        itemData.a.categoryId = Convert.ToInt32(cmbItemCategory.SelectedValue);
                        itemData.a.photo = pic;
                        itemData.a.itemCode = lblItemCode.Text;
                        itemData.a.updateDate = DateTime.Now;

                        itemData.b.weight = Convert.ToDecimal(txtWeight.Text);
                        if (cmbKarat.SelectedIndex > 0)
                            itemData.b.carret = Convert.ToDecimal(cmbKarat.Text);
                        else
                            itemData.b.carret = 0;
                        itemData.b.qty = Convert.ToDecimal(txtQty.Text);
                        itemData.b.unit = cmbUnit.Text.ToString();
                        itemData.b.melting = Convert.ToDecimal(txtMelting.Text);
                        itemData.b.remarks = txtRemarks.Text.Trim().ToString();
                    
                        itemData.b.upadtedDate = DateTime.Now;

                        _entities.SaveChanges();

                        MessageBox.Show("Record Successfully Updated!");
                    }
                    clear();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }

        private void Item_Load(object sender, EventArgs e)
        {
            try
            {
                MyCamera.Start();

                comboBox2.SelectedIndex = 1;

                comboBoxBind();
                clear();
              //  startImage();

                if (itemIdPassed > 0)
                {
                    var itemData = (from a in _entities.tbl_ItemMaster
                                    join b in _entities.tbl_StockItemDetails on a.id equals b.itemId
                                    where a.id == itemIdPassed
                                    select new { a, b }).FirstOrDefault();

                    cmbKarat.Text = itemData.b.carret.ToString();
                    txtMelting.Text = itemData.b.melting.ToString();
                    txtQty.Text = itemData.b.qty.ToString();
                    txtRemarks.Text = itemData.b.remarks.ToString();
                    txtWeight.Text = itemData.b.weight.ToString();

                    cmbItemCategory.SelectedValue = itemData.a.categoryId;
                    cmbUnit.SelectedText = itemData.b.unit;

                    if (itemData.a.photo != null)
                    {
                        var imageMemoryStream = new MemoryStream(itemData.a.photo);
                        Image img = Image.FromStream(imageMemoryStream);

                        CaptureBox.Image = img;
                    }
                    btnCreate.Text = "Update";
                }

            }
            catch (Exception x)
            {

            }
        }

        void startImage()
        {

            try
            {
                #region if capture is not created, create it now
                if (capture == null)
                {
                    try
                    {
                        capture = new Capture();
                        capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, 300);
                        capture.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, 250);
                    }
                    catch (NullReferenceException excpt)
                    {
                        MessageBox.Show("Something went wrong. Contact your system administrator");
                    }
                }
                #endregion

                if (capture != null)
                {
                    if (captureInProgress)
                    {  //if camera is getting frames then stop the capture and set button Text
                       // "Start" for resuming capture
                       /// btnStart.Text = "Start!"; //
                        Application.Idle -= ProcessFrame;
                    }
                    else
                    {
                        //if camera is NOT getting frames then start the capture and set button
                        // Text to "Stop" for pausing capture
                        // btnStart.Text = "Stop";
                        Application.Idle += ProcessFrame;
                    }

                    captureInProgress = !captureInProgress;
                }
            }
            catch (Exception x)
            {
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                //Bitmap bitmap = new Bitmap(CamImgBoxs.Image.Bitmap);
                //CaptureBox.Image = bitmap;

                Bitmap bitmap = new Bitmap(pictureBox1.Image);
                CaptureBox.Image = bitmap;
            }
            catch (Exception x)
            {

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

                capture.Dispose(); //To stop and call Garbage Collector
                this.Close();
            }
            catch (Exception x)

            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWeight.Focus();
            }
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUnit.Focus();
            }
        }

        private void cmbUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMelting.Focus();
            }
        }

        private void txtMelting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbKarat.Focus();
            }
        }

        private void txtCarret_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.Focus();
            }
        }

        private void txtWeight_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtWeight.Height;
            SidePanel2.Top = txtWeight.Top;
        }

        private void cmbUnit_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbUnit.Height;
            SidePanel2.Top = cmbUnit.Top;
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtQty.Height;
            SidePanel2.Top = txtQty.Top;
        }

        private void txtMelting_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtMelting.Height;
            SidePanel2.Top = txtMelting.Top;
        }

        private void txtCarret_Enter(object sender, EventArgs e)
        {

        }

        private void txtRemarks_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = txtRemarks.Height;
            SidePanel2.Top = txtRemarks.Top;
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxValidation val = new TextBoxValidation();
            val.onlyNumber(sender, e);
        }

        private void cmbKarat_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtRemarks.Focus();
            }
        }

        private void cmbKarat_Enter(object sender, EventArgs e)
        {
            SidePanel2.Height = cmbKarat.Height;
            SidePanel2.Top = cmbKarat.Top;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyCamera.ChangeCamera(comboBox1.SelectedIndex);
            MyCamera.Start();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyCamera.Start(comboBox2.SelectedIndex);
           // MyCamera.Start();
        }

        private void Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyCamera.Stop();
        }

        private void cmbItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbItemCategory.SelectedIndex > 0)
                {
                    _entities = new MicroAccountsEntities1();
                    // MessageBox.Show(cmbItemCategory.SelectedIndex.ToString());
                    var categoryId = Convert.ToInt32(cmbItemCategory.SelectedValue);

                    var prefix = _entities.tbl_CategoryMaster.Where(x => x.cId == categoryId).FirstOrDefault().prefix;

                   // lblItemCode.Text = prefix + "-" + DateTime.Now.Year + "001";

                    var getLastId = _entities.tbl_ItemMaster.OrderByDescending(x => x.id).FirstOrDefault();

                    if (getLastId == null)
                    {
                        string str = DateTime.Now.ToString("yy");
                        lblItemCode.Text = prefix + "-" + str + "01";
                    }
                    else
                    {
                        string str = DateTime.Now.ToString("yy");

                        var idInc = (getLastId.id) + 1;
                        lblItemCode.Text = prefix + "-" + str + "0" + idInc.ToString();
                    }

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Something went wrong. Contact your system administrator");
            }
        }
    }
}
