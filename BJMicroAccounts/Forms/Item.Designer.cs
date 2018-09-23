namespace MicroAccounts.Forms
{
    partial class Item
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Item));
            this.panel4 = new System.Windows.Forms.Panel();
            this.SidePanel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblhiddenCategoryName = new System.Windows.Forms.Label();
            this.lblHiddenId = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbKarat = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.CamImgBoxs = new Emgu.CV.UI.ImageBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.txtMelting = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CaptureBox = new System.Windows.Forms.PictureBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.cmbItemCategory = new System.Windows.Forms.ComboBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.SidePanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamImgBoxs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Goldenrod;
            this.panel4.Location = new System.Drawing.Point(10, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 3);
            this.panel4.TabIndex = 35;
            // 
            // SidePanel2
            // 
            this.SidePanel2.BackColor = System.Drawing.Color.Goldenrod;
            this.SidePanel2.Controls.Add(this.panel1);
            this.SidePanel2.Location = new System.Drawing.Point(4, 64);
            this.SidePanel2.Name = "SidePanel2";
            this.SidePanel2.Size = new System.Drawing.Size(5, 34);
            this.SidePanel2.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 34);
            this.panel1.TabIndex = 24;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(307, 372);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 32);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(16, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Item Code :";
            // 
            // lblhiddenCategoryName
            // 
            this.lblhiddenCategoryName.AutoSize = true;
            this.lblhiddenCategoryName.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.lblhiddenCategoryName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblhiddenCategoryName.Location = new System.Drawing.Point(427, 541);
            this.lblhiddenCategoryName.Name = "lblhiddenCategoryName";
            this.lblhiddenCategoryName.Size = new System.Drawing.Size(148, 20);
            this.lblhiddenCategoryName.TabIndex = 29;
            this.lblhiddenCategoryName.Text = "Hidden Cat Name: ";
            this.lblhiddenCategoryName.Visible = false;
            // 
            // lblHiddenId
            // 
            this.lblHiddenId.AutoSize = true;
            this.lblHiddenId.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.lblHiddenId.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblHiddenId.Location = new System.Drawing.Point(589, 541);
            this.lblHiddenId.Name = "lblHiddenId";
            this.lblHiddenId.Size = new System.Drawing.Size(88, 20);
            this.lblHiddenId.TabIndex = 29;
            this.lblHiddenId.Text = "Hidden Id: ";
            this.lblHiddenId.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(216, 372);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(85, 32);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label1.Location = new System.Drawing.Point(16, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Item Category: ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Pink;
            this.panel3.Controls.Add(this.lblError);
            this.panel3.Location = new System.Drawing.Point(12, 410);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 32);
            this.panel3.TabIndex = 40;
            this.panel3.Visible = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.lblError.Location = new System.Drawing.Point(3, 6);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(152, 20);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "Confirm Password : ";
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
            this.button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button13.Location = new System.Drawing.Point(655, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(32, 35);
            this.button13.TabIndex = 34;
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Add Product";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cmbKarat);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.CamImgBoxs);
            this.panel2.Controls.Add(this.txtRemarks);
            this.panel2.Controls.Add(this.txtQty);
            this.panel2.Controls.Add(this.txtMelting);
            this.panel2.Controls.Add(this.txtWeight);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.CaptureBox);
            this.panel2.Controls.Add(this.cmbUnit);
            this.panel2.Controls.Add(this.cmbItemCategory);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCapture);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblHiddenId);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblhiddenCategoryName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblItemCode);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.SidePanel2);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 450);
            this.panel2.TabIndex = 43;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // cmbKarat
            // 
            this.cmbKarat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKarat.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbKarat.FormattingEnabled = true;
            this.cmbKarat.Items.AddRange(new object[] {
            "--All--",
            "18",
            "22",
            "84",
            "916"});
            this.cmbKarat.Location = new System.Drawing.Point(154, 279);
            this.cmbKarat.Name = "cmbKarat";
            this.cmbKarat.Size = new System.Drawing.Size(212, 28);
            this.cmbKarat.TabIndex = 5;
            this.cmbKarat.Enter += new System.EventHandler(this.cmbKarat_Enter);
            this.cmbKarat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbKarat_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label19.Location = new System.Drawing.Point(372, 287);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 20);
            this.label19.TabIndex = 126;
            this.label19.Text = "K";
            // 
            // CamImgBoxs
            // 
            this.CamImgBoxs.Location = new System.Drawing.Point(478, 57);
            this.CamImgBoxs.Name = "CamImgBoxs";
            this.CamImgBoxs.Size = new System.Drawing.Size(165, 127);
            this.CamImgBoxs.TabIndex = 2;
            this.CamImgBoxs.TabStop = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtRemarks.Location = new System.Drawing.Point(154, 325);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(238, 45);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtRemarks.Enter += new System.EventHandler(this.txtRemarks_Enter);
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtQty.Location = new System.Drawing.Point(154, 199);
            this.txtQty.MaxLength = 5;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(236, 26);
            this.txtQty.TabIndex = 3;
            this.txtQty.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtQty.Enter += new System.EventHandler(this.txtQty_Enter);
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // txtMelting
            // 
            this.txtMelting.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtMelting.Location = new System.Drawing.Point(154, 239);
            this.txtMelting.MaxLength = 10;
            this.txtMelting.Name = "txtMelting";
            this.txtMelting.Size = new System.Drawing.Size(236, 26);
            this.txtMelting.TabIndex = 4;
            this.txtMelting.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtMelting.Enter += new System.EventHandler(this.txtMelting_Enter);
            this.txtMelting.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMelting_KeyDown);
            this.txtMelting.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtWeight.Location = new System.Drawing.Point(156, 157);
            this.txtWeight.MaxLength = 10;
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(135, 26);
            this.txtWeight.TabIndex = 1;
            this.txtWeight.Enter += new System.EventHandler(this.txtWeight_Enter);
            this.txtWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWeight_KeyDown);
            this.txtWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWeight_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Goldenrod;
            this.panel5.Location = new System.Drawing.Point(442, 57);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 338);
            this.panel5.TabIndex = 24;
            // 
            // CaptureBox
            // 
            this.CaptureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CaptureBox.Location = new System.Drawing.Point(478, 245);
            this.CaptureBox.Name = "CaptureBox";
            this.CaptureBox.Size = new System.Drawing.Size(165, 125);
            this.CaptureBox.TabIndex = 42;
            this.CaptureBox.TabStop = false;
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "Grams",
            "Kg"});
            this.cmbUnit.Location = new System.Drawing.Point(305, 156);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(87, 28);
            this.cmbUnit.TabIndex = 2;
            this.cmbUnit.Enter += new System.EventHandler(this.cmbUnit_Enter);
            this.cmbUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUnit_KeyDown);
            // 
            // cmbItemCategory
            // 
            this.cmbItemCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemCategory.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbItemCategory.FormattingEnabled = true;
            this.cmbItemCategory.Location = new System.Drawing.Point(154, 71);
            this.cmbItemCategory.Name = "cmbItemCategory";
            this.cmbItemCategory.Size = new System.Drawing.Size(238, 28);
            this.cmbItemCategory.TabIndex = 0;
            this.cmbItemCategory.SelectedIndexChanged += new System.EventHandler(this.cmbItemCategory_SelectedIndexChanged);
            this.cmbItemCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemCategory_KeyDown);
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.ForeColor = System.Drawing.Color.White;
            this.btnCapture.Location = new System.Drawing.Point(478, 199);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(165, 32);
            this.btnCapture.TabIndex = 7;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label8.Location = new System.Drawing.Point(16, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Remarks:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label7.Location = new System.Drawing.Point(16, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Karat :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label6.Location = new System.Drawing.Point(15, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Melting :";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.lblItemCode.Location = new System.Drawing.Point(152, 121);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(29, 20);
            this.lblItemCode.TabIndex = 29;
            this.lblItemCode.Text = "----";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label5.Location = new System.Drawing.Point(16, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Qty :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label4.Location = new System.Drawing.Point(16, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Weight :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 466);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Item";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item";
            this.Load += new System.EventHandler(this.Item_Load);
            this.SidePanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CamImgBoxs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel SidePanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblhiddenCategoryName;
        private System.Windows.Forms.Label lblHiddenId;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.ComboBox cmbItemCategory;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider1;
     
        private System.Windows.Forms.PictureBox CaptureBox;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtMelting;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtQty;
        private Emgu.CV.UI.ImageBox CamImgBoxs;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ComboBox cmbKarat;
        private System.Windows.Forms.Label label19;
    }
}