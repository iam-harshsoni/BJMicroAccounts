namespace MicroAccounts
{
    partial class AccountLedger
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.addressPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkBankOrCash = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbParentGroup = new System.Windows.Forms.ComboBox();
            this.txtOpeningBal = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cmbDRCR = new System.Windows.Forms.ComboBox();
            this.txtLedgerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.SidePanel2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.addressPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SidePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.addressPanel);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.chkBankOrCash);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbParentGroup);
            this.panel1.Controls.Add(this.txtOpeningBal);
            this.panel1.Controls.Add(this.txtNotes);
            this.panel1.Controls.Add(this.cmbDRCR);
            this.panel1.Controls.Add(this.txtLedgerName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.SidePanel2);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 605);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 25);
            this.label10.TabIndex = 117;
            this.label10.Text = "Account Ledger";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Goldenrod;
            this.panel4.Location = new System.Drawing.Point(11, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(709, 3);
            this.panel4.TabIndex = 116;
            // 
            // addressPanel
            // 
            this.addressPanel.Controls.Add(this.label8);
            this.addressPanel.Controls.Add(this.label9);
            this.addressPanel.Controls.Add(this.txtAddress);
            this.addressPanel.Controls.Add(this.txtContact);
            this.addressPanel.Enabled = false;
            this.addressPanel.Location = new System.Drawing.Point(3, 356);
            this.addressPanel.Name = "addressPanel";
            this.addressPanel.Size = new System.Drawing.Size(725, 173);
            this.addressPanel.TabIndex = 114;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label8.Location = new System.Drawing.Point(8, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 76;
            this.label8.Text = "Address :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label9.Location = new System.Drawing.Point(8, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 77;
            this.label9.Text = "Contact :";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtAddress.Location = new System.Drawing.Point(157, 63);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(548, 82);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtContact.Location = new System.Drawing.Point(157, 27);
            this.txtContact.MaxLength = 50;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(548, 26);
            this.txtContact.TabIndex = 0;
            this.txtContact.Enter += new System.EventHandler(this.txtContact_Enter);
            this.txtContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContact_KeyDown);
            this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpeningBal_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(504, 336);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(208, 17);
            this.label15.TabIndex = 113;
            this.label15.Text = "* Note : Upto 200 Characters only.";
            // 
            // chkBankOrCash
            // 
            this.chkBankOrCash.AutoSize = true;
            this.chkBankOrCash.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.chkBankOrCash.Location = new System.Drawing.Point(174, 208);
            this.chkBankOrCash.Name = "chkBankOrCash";
            this.chkBankOrCash.Size = new System.Drawing.Size(189, 24);
            this.chkBankOrCash.TabIndex = 4;
            this.chkBankOrCash.Text = "Bank or cash account";
            this.chkBankOrCash.UseVisualStyleBackColor = true;
            this.chkBankOrCash.Enter += new System.EventHandler(this.chkBankOrCash_Enter);
            this.chkBankOrCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkBankOrCash_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(171, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(383, 17);
            this.label6.TabIndex = 107;
            this.label6.Text = "Note : Select if the ledger account is a bank or a cash account.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(171, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 34);
            this.label4.TabIndex = 106;
            this.label4.Text = "Note : Assets / Expenses always have Dr balance and Liabilities / \r\nIncomes alway" +
    "s have Cr balance.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label7.Location = new System.Drawing.Point(21, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 109;
            this.label7.Text = "Notes :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label5.Location = new System.Drawing.Point(21, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 104;
            this.label5.Text = "Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label3.Location = new System.Drawing.Point(18, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 20);
            this.label3.TabIndex = 105;
            this.label3.Text = "Opening Balance : ";
            // 
            // cmbParentGroup
            // 
            this.cmbParentGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbParentGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbParentGroup.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbParentGroup.FormattingEnabled = true;
            this.cmbParentGroup.Location = new System.Drawing.Point(174, 101);
            this.cmbParentGroup.Name = "cmbParentGroup";
            this.cmbParentGroup.Size = new System.Drawing.Size(540, 28);
            this.cmbParentGroup.TabIndex = 1;
            this.cmbParentGroup.SelectedIndexChanged += new System.EventHandler(this.cmbParentGroup_SelectedIndexChanged_1);
            this.cmbParentGroup.Enter += new System.EventHandler(this.cmbParentGroup_Enter);
            this.cmbParentGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbParentGroup_KeyDown);
            // 
            // txtOpeningBal
            // 
            this.txtOpeningBal.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtOpeningBal.Location = new System.Drawing.Point(245, 135);
            this.txtOpeningBal.MaxLength = 13;
            this.txtOpeningBal.Name = "txtOpeningBal";
            this.txtOpeningBal.Size = new System.Drawing.Size(309, 26);
            this.txtOpeningBal.TabIndex = 3;
            this.txtOpeningBal.Enter += new System.EventHandler(this.txtOpeningBal_Enter);
            this.txtOpeningBal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOpeningBal_KeyDown);
            this.txtOpeningBal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpeningBal_KeyPress);
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtNotes.Location = new System.Drawing.Point(168, 264);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(544, 69);
            this.txtNotes.TabIndex = 5;
            this.txtNotes.Enter += new System.EventHandler(this.txtNotes_Enter);
            this.txtNotes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNotes_KeyDown);
            // 
            // cmbDRCR
            // 
            this.cmbDRCR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDRCR.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.cmbDRCR.FormattingEnabled = true;
            this.cmbDRCR.Items.AddRange(new object[] {
            "Dr",
            "Cr"});
            this.cmbDRCR.Location = new System.Drawing.Point(174, 135);
            this.cmbDRCR.Name = "cmbDRCR";
            this.cmbDRCR.Size = new System.Drawing.Size(65, 25);
            this.cmbDRCR.TabIndex = 2;
            this.cmbDRCR.Enter += new System.EventHandler(this.cmbDRCR_Enter);
            // 
            // txtLedgerName
            // 
            this.txtLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLedgerName.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtLedgerName.Location = new System.Drawing.Point(174, 69);
            this.txtLedgerName.MaxLength = 50;
            this.txtLedgerName.Name = "txtLedgerName";
            this.txtLedgerName.Size = new System.Drawing.Size(540, 26);
            this.txtLedgerName.TabIndex = 0;
            this.txtLedgerName.Enter += new System.EventHandler(this.txtLedgerName_Enter);
            this.txtLedgerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLedgerName_KeyDown);
            this.txtLedgerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLedgerName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label1.Location = new System.Drawing.Point(21, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 108;
            this.label1.Text = "Ledger Name : ";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(549, 535);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(85, 32);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(19, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "Parent Group : ";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(640, 535);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 32);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Pink;
            this.panel3.Controls.Add(this.lblError);
            this.panel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(8, 534);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(533, 32);
            this.panel3.TabIndex = 111;
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
            // SidePanel2
            // 
            this.SidePanel2.BackColor = System.Drawing.Color.Goldenrod;
            this.SidePanel2.Controls.Add(this.panel2);
            this.SidePanel2.Location = new System.Drawing.Point(9, 62);
            this.SidePanel2.Name = "SidePanel2";
            this.SidePanel2.Size = new System.Drawing.Size(5, 34);
            this.SidePanel2.TabIndex = 110;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Goldenrod;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 34);
            this.panel2.TabIndex = 24;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AccountLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(735, 576);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccountLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountLedger";
            this.Load += new System.EventHandler(this.AccountLedger_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.addressPanel.ResumeLayout(false);
            this.addressPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.SidePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel addressPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkBankOrCash;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbParentGroup;
        private System.Windows.Forms.TextBox txtOpeningBal;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cmbDRCR;
        private System.Windows.Forms.TextBox txtLedgerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel SidePanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel4;
    }
}