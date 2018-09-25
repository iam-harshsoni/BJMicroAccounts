namespace MicroAccounts.UserControls
{
    partial class StockInventoryDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgStockDetails = new System.Windows.Forms.DataGridView();
            this.cmbKarat = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLedgerName = new System.Windows.Forms.TextBox();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblTotalRows = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgStockDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dgStockDetails
            // 
            this.dgStockDetails.AllowUserToAddRows = false;
            this.dgStockDetails.AllowUserToDeleteRows = false;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgStockDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle45;
            this.dgStockDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgStockDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgStockDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle46.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStockDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle46;
            this.dgStockDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStockDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column2,
            this.Column6,
            this.Column3,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column9,
            this.Column10,
            this.Delete});
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStockDetails.DefaultCellStyle = dataGridViewCellStyle47;
            this.dgStockDetails.Location = new System.Drawing.Point(3, 128);
            this.dgStockDetails.Name = "dgStockDetails";
            this.dgStockDetails.ReadOnly = true;
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStockDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle48;
            this.dgStockDetails.Size = new System.Drawing.Size(1024, 481);
            this.dgStockDetails.TabIndex = 108;
            this.dgStockDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStockDetails_CellContentClick);
            this.dgStockDetails.DoubleClick += new System.EventHandler(this.dgStockDetails_DoubleClick);
            // 
            // cmbKarat
            // 
            this.cmbKarat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbKarat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKarat.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbKarat.FormattingEnabled = true;
            this.cmbKarat.Items.AddRange(new object[] {
            "--All--",
            "18",
            "22",
            "23",
            "24",
            "916"});
            this.cmbKarat.Location = new System.Drawing.Point(660, 83);
            this.cmbKarat.Name = "cmbKarat";
            this.cmbKarat.Size = new System.Drawing.Size(133, 28);
            this.cmbKarat.TabIndex = 107;
            this.cmbKarat.SelectedIndexChanged += new System.EventHandler(this.cmbKarat_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Goldenrod;
            this.panel3.Location = new System.Drawing.Point(645, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 40);
            this.panel3.TabIndex = 103;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(799, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 32);
            this.button1.TabIndex = 97;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.25F);
            this.label4.Location = new System.Drawing.Point(656, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 100;
            this.label4.Text = "Karat :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.25F);
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 102;
            this.label1.Text = "Item Name : ";
            // 
            // txtLedgerName
            // 
            this.txtLedgerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtLedgerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLedgerName.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.txtLedgerName.Location = new System.Drawing.Point(5, 84);
            this.txtLedgerName.MaxLength = 13;
            this.txtLedgerName.Name = "txtLedgerName";
            this.txtLedgerName.Size = new System.Drawing.Size(389, 26);
            this.txtLedgerName.TabIndex = 98;
            this.txtLedgerName.TextChanged += new System.EventHandler(this.txtLedgerName_TextChanged);
            this.txtLedgerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLedgerName_KeyUp);
            // 
            // btnNewItem
            // 
            this.btnNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewItem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnNewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewItem.ForeColor = System.Drawing.Color.White;
            this.btnNewItem.Location = new System.Drawing.Point(748, 7);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(135, 39);
            this.btnNewItem.TabIndex = 95;
            this.btnNewItem.Text = "Add New Item";
            this.btnNewItem.UseVisualStyleBackColor = false;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Goldenrod;
            this.panel2.Location = new System.Drawing.Point(7, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1017, 2);
            this.panel2.TabIndex = 96;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCategory.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Location = new System.Drawing.Point(889, 7);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(137, 39);
            this.btnAddCategory.TabIndex = 95;
            this.btnAddCategory.Text = "Add Category";
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Goldenrod;
            this.panel4.Location = new System.Drawing.Point(404, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 40);
            this.panel4.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.25F);
            this.label3.Location = new System.Drawing.Point(414, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 100;
            this.label3.Text = "Category :";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Dr",
            "Cr"});
            this.cmbCategory.Location = new System.Drawing.Point(418, 83);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(218, 28);
            this.cmbCategory.TabIndex = 107;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewImageColumn1.HeaderText = "Actions";
            this.dataGridViewImageColumn1.Image = global::BJMicroAccounts.Properties.Resources.delete1;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // lblTotalRows
            // 
            this.lblTotalRows.AutoSize = true;
            this.lblTotalRows.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRows.Location = new System.Drawing.Point(118, 21);
            this.lblTotalRows.Name = "lblTotalRows";
            this.lblTotalRows.Size = new System.Drawing.Size(18, 19);
            this.lblTotalRows.TabIndex = 142;
            this.lblTotalRows.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 143;
            this.label2.Text = "Total Rows : ";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Crimson;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(919, 81);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(108, 32);
            this.btnClear.TabIndex = 149;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "SrNo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 60;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column8.DataPropertyName = "rowNo";
            this.Column8.HeaderText = "#";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 40;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.DataPropertyName = "photo";
            this.Column2.HeaderText = "Photo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 66;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.DataPropertyName = "itemCode";
            this.Column6.HeaderText = "Item Code";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 95;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "categoryName";
            this.Column3.HeaderText = "Category";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "qty";
            this.Column7.HeaderText = "Qty";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 50;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "weight";
            this.Column4.HeaderText = "Weight";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 73;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.DataPropertyName = "carret";
            this.Column5.HeaderText = "Karats";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 68;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column9.DataPropertyName = "createdDate";
            this.Column9.HeaderText = "CreatedDate";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 108;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column10.DataPropertyName = "updatedDate";
            this.Column10.HeaderText = "UpdatedDate";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 111;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.HeaderText = "Actions";
            this.Delete.Image = global::BJMicroAccounts.Properties.Resources.delete1;
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 57;
            // 
            // StockInventoryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotalRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgStockDetails);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbKarat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLedgerName);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnNewItem);
            this.Controls.Add(this.panel2);
            this.Name = "StockInventoryDetails";
            this.Size = new System.Drawing.Size(1030, 612);
            this.Load += new System.EventHandler(this.StockInventoryDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgStockDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgStockDetails;
        private System.Windows.Forms.ComboBox cmbKarat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLedgerName;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblTotalRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}
