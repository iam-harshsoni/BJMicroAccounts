namespace MicroAccounts.Forms
{
    partial class DailyGoldRates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyGoldRates));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txt18c = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSilver = new System.Windows.Forms.TextBox();
            this.txt23c = new System.Windows.Forms.TextBox();
            this.txt22c = new System.Windows.Forms.TextBox();
            this.txtBuyBack = new System.Windows.Forms.TextBox();
            this.txtHallMark = new System.Windows.Forms.TextBox();
            this.txt999 = new System.Windows.Forms.TextBox();
            this.SidePanel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt18c);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSilver);
            this.panel1.Controls.Add(this.txt23c);
            this.panel1.Controls.Add(this.txt22c);
            this.panel1.Controls.Add(this.txtBuyBack);
            this.panel1.Controls.Add(this.txtHallMark);
            this.panel1.Controls.Add(this.txt999);
            this.panel1.Controls.Add(this.SidePanel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button13);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 365);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label8.Location = new System.Drawing.Point(21, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 46;
            this.label8.Text = "18c : ";
            // 
            // txt18c
            // 
            this.txt18c.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt18c.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt18c.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txt18c.Location = new System.Drawing.Point(246, 218);
            this.txt18c.MaxLength = 12;
            this.txt18c.Name = "txt18c";
            this.txt18c.Size = new System.Drawing.Size(246, 26);
            this.txt18c.TabIndex = 5;
            this.txt18c.Enter += new System.EventHandler(this.txt18c_Enter);
            this.txt18c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt18c_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Pink;
            this.panel3.Controls.Add(this.lblError);
            this.panel3.Location = new System.Drawing.Point(14, 317);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 32);
            this.panel3.TabIndex = 44;
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
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(316, 279);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(85, 32);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(407, 279);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 32);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label7.Location = new System.Drawing.Point(21, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 20);
            this.label7.TabIndex = 41;
            this.label7.Text = "Silver fine 1kg : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label5.Location = new System.Drawing.Point(21, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "22c 10g : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(21, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "916 HallMark 10g : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label6.Location = new System.Drawing.Point(21, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "23c 10g : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label4.Location = new System.Drawing.Point(21, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "916 HallMark buyback 10g : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label1.Location = new System.Drawing.Point(21, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "999 Fine Gold(100 g) : ";
            // 
            // txtSilver
            // 
            this.txtSilver.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSilver.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSilver.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtSilver.Location = new System.Drawing.Point(246, 249);
            this.txtSilver.MaxLength = 12;
            this.txtSilver.Name = "txtSilver";
            this.txtSilver.Size = new System.Drawing.Size(246, 26);
            this.txtSilver.TabIndex = 6;
            this.txtSilver.Enter += new System.EventHandler(this.txtSilver_Enter);
            this.txtSilver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSilver_KeyDown);
            this.txtSilver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuyBack_KeyPress);
            // 
            // txt23c
            // 
            this.txt23c.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt23c.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt23c.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txt23c.Location = new System.Drawing.Point(246, 187);
            this.txt23c.MaxLength = 12;
            this.txt23c.Name = "txt23c";
            this.txt23c.Size = new System.Drawing.Size(246, 26);
            this.txt23c.TabIndex = 4;
            this.txt23c.Enter += new System.EventHandler(this.txt23c_Enter);
            this.txt23c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt23c_KeyDown);
            this.txt23c.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuyBack_KeyPress);
            // 
            // txt22c
            // 
            this.txt22c.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt22c.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt22c.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txt22c.Location = new System.Drawing.Point(246, 155);
            this.txt22c.MaxLength = 12;
            this.txt22c.Name = "txt22c";
            this.txt22c.Size = new System.Drawing.Size(246, 26);
            this.txt22c.TabIndex = 3;
            this.txt22c.Enter += new System.EventHandler(this.txt22c_Enter);
            this.txt22c.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt22c_KeyDown);
            this.txt22c.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuyBack_KeyPress);
            // 
            // txtBuyBack
            // 
            this.txtBuyBack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuyBack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuyBack.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtBuyBack.Location = new System.Drawing.Point(246, 123);
            this.txtBuyBack.MaxLength = 12;
            this.txtBuyBack.Name = "txtBuyBack";
            this.txtBuyBack.Size = new System.Drawing.Size(246, 26);
            this.txtBuyBack.TabIndex = 2;
            this.txtBuyBack.Enter += new System.EventHandler(this.txtBuyBack_Enter);
            this.txtBuyBack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuyBack_KeyDown);
            this.txtBuyBack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuyBack_KeyPress);
            // 
            // txtHallMark
            // 
            this.txtHallMark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtHallMark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHallMark.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtHallMark.Location = new System.Drawing.Point(246, 91);
            this.txtHallMark.MaxLength = 12;
            this.txtHallMark.Name = "txtHallMark";
            this.txtHallMark.Size = new System.Drawing.Size(246, 26);
            this.txtHallMark.TabIndex = 1;
            this.txtHallMark.Enter += new System.EventHandler(this.txtHallMark_Enter);
            this.txtHallMark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHallMark_KeyDown);
            this.txtHallMark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHallMark_KeyPress);
            // 
            // txt999
            // 
            this.txt999.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt999.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt999.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txt999.Location = new System.Drawing.Point(246, 60);
            this.txt999.MaxLength = 12;
            this.txt999.Name = "txt999";
            this.txt999.Size = new System.Drawing.Size(246, 26);
            this.txt999.TabIndex = 0;
            this.txt999.FontChanged += new System.EventHandler(this.txt999_FontChanged);
            this.txt999.Enter += new System.EventHandler(this.txt999_Enter);
            this.txt999.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt999_KeyDown);
            this.txt999.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt999_KeyPress);
            // 
            // SidePanel2
            // 
            this.SidePanel2.BackColor = System.Drawing.Color.Goldenrod;
            this.SidePanel2.Location = new System.Drawing.Point(14, 52);
            this.SidePanel2.Name = "SidePanel2";
            this.SidePanel2.Size = new System.Drawing.Size(5, 34);
            this.SidePanel2.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 38;
            this.label3.Text = "Daily Rates";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Goldenrod;
            this.panel4.Location = new System.Drawing.Point(10, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(150, 3);
            this.panel4.TabIndex = 37;
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
            this.button13.Location = new System.Drawing.Point(467, 3);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(32, 35);
            this.button13.TabIndex = 35;
            this.button13.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DailyGoldRates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(505, 367);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DailyGoldRates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DailyGoldRates";
            this.Load += new System.EventHandler(this.DailyGoldRates_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSilver;
        private System.Windows.Forms.TextBox txt23c;
        private System.Windows.Forms.TextBox txt22c;
        private System.Windows.Forms.TextBox txtBuyBack;
        private System.Windows.Forms.TextBox txtHallMark;
        private System.Windows.Forms.TextBox txt999;
        private System.Windows.Forms.Panel SidePanel2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt18c;
    }
}