namespace MicroAccounts
{
    partial class Group
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtGroupList = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SidePanel2 = new System.Windows.Forms.Panel();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.cmbParentGroup = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHiddenId = new System.Windows.Forms.Label();
            this.lblhiddenGName = new System.Windows.Forms.Label();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtGroupList)).BeginInit();
            this.panel3.SuspendLayout();
            this.SidePanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label1.Location = new System.Drawing.Point(20, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Group Name : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label2.Location = new System.Drawing.Point(16, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Parent Group : ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Goldenrod;
            this.panel4.Location = new System.Drawing.Point(10, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(734, 3);
            this.panel4.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "Add Account Group";
            // 
            // dtGroupList
            // 
            this.dtGroupList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.dtGroupList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGroupList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGroupList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGroupList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.Column1,
            this.GroupName,
            this.ParentName,
            this.CreatedDate,
            this.UpdateDate,
            this.Delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGroupList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtGroupList.Location = new System.Drawing.Point(8, 219);
            this.dtGroupList.Name = "dtGroupList";
            this.dtGroupList.ReadOnly = true;
            this.dtGroupList.Size = new System.Drawing.Size(742, 343);
            this.dtGroupList.TabIndex = 37;
            this.dtGroupList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGroupList_CellContentClick);
            this.dtGroupList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGroupList_CellDoubleClick);
            this.dtGroupList.DoubleClick += new System.EventHandler(this.dtGroupList_DoubleClick);
            // 
            // SrNo
            // 
            this.SrNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SrNo.DataPropertyName = "groupId";
            this.SrNo.HeaderText = "SrNo";
            this.SrNo.Name = "SrNo";
            this.SrNo.ReadOnly = true;
            this.SrNo.Visible = false;
            this.SrNo.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "rowNo";
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // GroupName
            // 
            this.GroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GroupName.DataPropertyName = "groupName";
            this.GroupName.HeaderText = "Group Name";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // ParentName
            // 
            this.ParentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ParentName.DataPropertyName = "ParentGroupName";
            this.ParentName.HeaderText = "Parent Group";
            this.ParentName.Name = "ParentName";
            this.ParentName.ReadOnly = true;
            this.ParentName.Width = 160;
            // 
            // CreatedDate
            // 
            this.CreatedDate.DataPropertyName = "CreatedDate";
            this.CreatedDate.HeaderText = "Created On";
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 120;
            // 
            // UpdateDate
            // 
            this.UpdateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UpdateDate.DataPropertyName = "UpdateDate";
            this.UpdateDate.HeaderText = "Updated On";
            this.UpdateDate.Name = "UpdateDate";
            this.UpdateDate.ReadOnly = true;
            this.UpdateDate.Width = 120;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.HeaderText = "Action";
            this.Delete.Image = global::BJMicroAccounts.Properties.Resources.delete1;
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 52;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(645, 121);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 32);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(554, 121);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(85, 32);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Pink;
            this.panel3.Controls.Add(this.lblError);
            this.panel3.Location = new System.Drawing.Point(149, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 32);
            this.panel3.TabIndex = 40;
            this.panel3.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Location = new System.Drawing.Point(0, -18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 34);
            this.panel1.TabIndex = 24;
            // 
            // SidePanel2
            // 
            this.SidePanel2.BackColor = System.Drawing.Color.Goldenrod;
            this.SidePanel2.Controls.Add(this.panel1);
            this.SidePanel2.Location = new System.Drawing.Point(4, 50);
            this.SidePanel2.Name = "SidePanel2";
            this.SidePanel2.Size = new System.Drawing.Size(5, 34);
            this.SidePanel2.TabIndex = 31;
            // 
            // txtGroupName
            // 
            this.txtGroupName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtGroupName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtGroupName.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtGroupName.Location = new System.Drawing.Point(149, 55);
            this.txtGroupName.MaxLength = 50;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(579, 26);
            this.txtGroupName.TabIndex = 0;
            this.txtGroupName.Enter += new System.EventHandler(this.txtGroupName_Enter);
            this.txtGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupName_KeyDown);
            this.txtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGroupName_KeyPress);
            this.txtGroupName.Leave += new System.EventHandler(this.txtGroupName_Leave);
            // 
            // cmbParentGroup
            // 
            this.cmbParentGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbParentGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbParentGroup.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbParentGroup.FormattingEnabled = true;
            this.cmbParentGroup.Location = new System.Drawing.Point(149, 87);
            this.cmbParentGroup.Name = "cmbParentGroup";
            this.cmbParentGroup.Size = new System.Drawing.Size(579, 28);
            this.cmbParentGroup.TabIndex = 1;
            this.cmbParentGroup.SelectedIndexChanged += new System.EventHandler(this.cmbParentGroup_SelectedIndexChanged);
            this.cmbParentGroup.Enter += new System.EventHandler(this.cmbParentGroup_Enter);
            this.cmbParentGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbParentGroup_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.lblHiddenId);
            this.panel2.Controls.Add(this.lblhiddenGName);
            this.panel2.Controls.Add(this.lblTotalRows);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.SidePanel2);
            this.panel2.Controls.Add(this.dtGroupList);
            this.panel2.Controls.Add(this.txtGroupName);
            this.panel2.Controls.Add(this.cmbParentGroup);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 590);
            this.panel2.TabIndex = 41;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(10, 565);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(270, 17);
            this.label15.TabIndex = 44;
            this.label15.Text = "* Note : Double-Click on any one row to EDIT.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "Account Group List";
            // 
            // lblHiddenId
            // 
            this.lblHiddenId.AutoSize = true;
            this.lblHiddenId.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.lblHiddenId.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblHiddenId.Location = new System.Drawing.Point(605, 565);
            this.lblHiddenId.Name = "lblHiddenId";
            this.lblHiddenId.Size = new System.Drawing.Size(139, 20);
            this.lblHiddenId.TabIndex = 29;
            this.lblHiddenId.Text = "Hidden Group Id: ";
            this.lblHiddenId.Visible = false;
            // 
            // lblhiddenGName
            // 
            this.lblhiddenGName.AutoSize = true;
            this.lblhiddenGName.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.lblhiddenGName.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblhiddenGName.Location = new System.Drawing.Point(443, 565);
            this.lblhiddenGName.Name = "lblhiddenGName";
            this.lblhiddenGName.Size = new System.Drawing.Size(168, 20);
            this.lblhiddenGName.TabIndex = 29;
            this.lblhiddenGName.Text = "Hidden Group Name: ";
            this.lblhiddenGName.Visible = false;
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRows.Location = new System.Drawing.Point(655, 178);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(18, 19);
            this.lblTotalRows.TabIndex = 29;
            this.lblTotalRows.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(550, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 19);
            this.label5.TabIndex = 29;
            this.label5.Text = "Total Rows : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewImageColumn1.HeaderText = "Action";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Goldenrod;
            this.panel6.Location = new System.Drawing.Point(13, 164);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(734, 3);
            this.panel6.TabIndex = 35;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Goldenrod;
            this.panel5.Location = new System.Drawing.Point(13, 206);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(734, 3);
            this.panel5.TabIndex = 35;
            // 
            // Group
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(766, 596);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Group";
            this.Load += new System.EventHandler(this.Group_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGroupList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.SidePanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dtGroupList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel SidePanel2;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.ComboBox cmbParentGroup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblhiddenGName;
        private System.Windows.Forms.Label lblHiddenId;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}