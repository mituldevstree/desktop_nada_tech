namespace NadaTech.View
{
    partial class Reports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtToDate = new NadaTech.RJControls.RJDatePicker();
            this.labTodate = new System.Windows.Forms.Label();
            this.txtFromDate = new NadaTech.RJControls.RJDatePicker();
            this.labFromDate = new System.Windows.Forms.Label();
            this.rjButton5 = new CustomControls.RJControls.RJButton();
            this.btnLocation = new CustomControls.RJControls.RJButton();
            this.btnSearchPart = new CustomControls.RJControls.RJButton();
            this.btnSearchAssetCategory = new CustomControls.RJControls.RJButton();
            this.btnSearchAssetType = new CustomControls.RJControls.RJButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnReset = new CustomControls.RJControls.RJButton();
            this.btnApply = new CustomControls.RJControls.RJButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcheckedOutTo = new CustomControls.RJControls.RJTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerLocation = new CustomControls.RJControls.RJTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCheckedOut = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChkInStock = new System.Windows.Forms.CheckBox();
            this.txtSearPart = new CustomControls.RJControls.RJTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtserAssetCategory = new CustomControls.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearAssetType = new CustomControls.RJControls.RJTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GrinEditDeleteDetailView = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.txtSearch = new CustomControls.RJControls.RJTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1231, 833);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtToDate);
            this.panel1.Controls.Add(this.labTodate);
            this.panel1.Controls.Add(this.txtFromDate);
            this.panel1.Controls.Add(this.labFromDate);
            this.panel1.Controls.Add(this.rjButton5);
            this.panel1.Controls.Add(this.btnLocation);
            this.panel1.Controls.Add(this.btnSearchPart);
            this.panel1.Controls.Add(this.btnSearchAssetCategory);
            this.panel1.Controls.Add(this.btnSearchAssetType);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtcheckedOutTo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSerLocation);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chkCheckedOut);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ChkInStock);
            this.panel1.Controls.Add(this.txtSearPart);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtserAssetCategory);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSearAssetType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 827);
            this.panel1.TabIndex = 0;
            // 
            // txtToDate
            // 
            this.txtToDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtToDate.BorderSize = 1;
            this.txtToDate.CalendarForeColor = System.Drawing.Color.Black;
            this.txtToDate.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.txtToDate.CustomFormat = "dd-MMM-yyyy";
            this.txtToDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtToDate.Location = new System.Drawing.Point(11, 463);
            this.txtToDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(277, 35);
            this.txtToDate.SkinColor = System.Drawing.Color.White;
            this.txtToDate.TabIndex = 45;
            this.txtToDate.TextColor = System.Drawing.Color.Black;
            // 
            // labTodate
            // 
            this.labTodate.AutoSize = true;
            this.labTodate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTodate.Location = new System.Drawing.Point(11, 440);
            this.labTodate.Name = "labTodate";
            this.labTodate.Size = new System.Drawing.Size(61, 20);
            this.labTodate.TabIndex = 46;
            this.labTodate.Text = "To Date";
            // 
            // txtFromDate
            // 
            this.txtFromDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtFromDate.BorderSize = 1;
            this.txtFromDate.CalendarForeColor = System.Drawing.Color.Black;
            this.txtFromDate.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.txtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.txtFromDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFromDate.Location = new System.Drawing.Point(11, 401);
            this.txtFromDate.MinimumSize = new System.Drawing.Size(4, 35);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(277, 35);
            this.txtFromDate.SkinColor = System.Drawing.Color.White;
            this.txtFromDate.TabIndex = 43;
            this.txtFromDate.TextColor = System.Drawing.Color.Black;
            // 
            // labFromDate
            // 
            this.labFromDate.AutoSize = true;
            this.labFromDate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFromDate.Location = new System.Drawing.Point(11, 378);
            this.labFromDate.Name = "labFromDate";
            this.labFromDate.Size = new System.Drawing.Size(79, 20);
            this.labFromDate.TabIndex = 44;
            this.labFromDate.Text = "From Date";
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.Transparent;
            this.rjButton5.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.rjButton5.BorderRadius = 0;
            this.rjButton5.BorderSize = 1;
            this.rjButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton5.ForeColor = System.Drawing.Color.White;
            this.rjButton5.Image = global::NadaTech.Properties.Resources.Search__2_;
            this.rjButton5.Location = new System.Drawing.Point(248, 526);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(40, 35);
            this.rjButton5.TabIndex = 42;
            this.rjButton5.TextColor = System.Drawing.Color.White;
            this.rjButton5.UseVisualStyleBackColor = false;
            this.rjButton5.Visible = false;
            // 
            // btnLocation
            // 
            this.btnLocation.BackColor = System.Drawing.Color.Transparent;
            this.btnLocation.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnLocation.BorderRadius = 0;
            this.btnLocation.BorderSize = 1;
            this.btnLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLocation.FlatAppearance.BorderSize = 0;
            this.btnLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocation.ForeColor = System.Drawing.Color.White;
            this.btnLocation.Image = global::NadaTech.Properties.Resources.Search__2_;
            this.btnLocation.Location = new System.Drawing.Point(248, 338);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(40, 35);
            this.btnLocation.TabIndex = 41;
            this.btnLocation.TextColor = System.Drawing.Color.White;
            this.btnLocation.UseVisualStyleBackColor = false;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnSearchPart
            // 
            this.btnSearchPart.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchPart.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSearchPart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSearchPart.BorderRadius = 0;
            this.btnSearchPart.BorderSize = 1;
            this.btnSearchPart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPart.FlatAppearance.BorderSize = 0;
            this.btnSearchPart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPart.ForeColor = System.Drawing.Color.White;
            this.btnSearchPart.Image = global::NadaTech.Properties.Resources.Search__2_;
            this.btnSearchPart.Location = new System.Drawing.Point(248, 206);
            this.btnSearchPart.Name = "btnSearchPart";
            this.btnSearchPart.Size = new System.Drawing.Size(40, 35);
            this.btnSearchPart.TabIndex = 40;
            this.btnSearchPart.TextColor = System.Drawing.Color.White;
            this.btnSearchPart.UseVisualStyleBackColor = false;
            this.btnSearchPart.Click += new System.EventHandler(this.btnSearchPart_Click);
            // 
            // btnSearchAssetCategory
            // 
            this.btnSearchAssetCategory.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchAssetCategory.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSearchAssetCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSearchAssetCategory.BorderRadius = 0;
            this.btnSearchAssetCategory.BorderSize = 1;
            this.btnSearchAssetCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchAssetCategory.FlatAppearance.BorderSize = 0;
            this.btnSearchAssetCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAssetCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAssetCategory.ForeColor = System.Drawing.Color.White;
            this.btnSearchAssetCategory.Image = global::NadaTech.Properties.Resources.Search__2_;
            this.btnSearchAssetCategory.Location = new System.Drawing.Point(248, 136);
            this.btnSearchAssetCategory.Name = "btnSearchAssetCategory";
            this.btnSearchAssetCategory.Size = new System.Drawing.Size(40, 35);
            this.btnSearchAssetCategory.TabIndex = 39;
            this.btnSearchAssetCategory.TextColor = System.Drawing.Color.White;
            this.btnSearchAssetCategory.UseVisualStyleBackColor = false;
            this.btnSearchAssetCategory.Click += new System.EventHandler(this.btnSearchAssetCategory_Click);
            // 
            // btnSearchAssetType
            // 
            this.btnSearchAssetType.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchAssetType.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSearchAssetType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSearchAssetType.BorderRadius = 0;
            this.btnSearchAssetType.BorderSize = 1;
            this.btnSearchAssetType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchAssetType.FlatAppearance.BorderSize = 0;
            this.btnSearchAssetType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAssetType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAssetType.ForeColor = System.Drawing.Color.White;
            this.btnSearchAssetType.Image = global::NadaTech.Properties.Resources.Search__2_;
            this.btnSearchAssetType.Location = new System.Drawing.Point(248, 70);
            this.btnSearchAssetType.Name = "btnSearchAssetType";
            this.btnSearchAssetType.Size = new System.Drawing.Size(40, 35);
            this.btnSearchAssetType.TabIndex = 38;
            this.btnSearchAssetType.TextColor = System.Drawing.Color.White;
            this.btnSearchAssetType.UseVisualStyleBackColor = false;
            this.btnSearchAssetType.Click += new System.EventHandler(this.btnSearchAssetType_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 761);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 66);
            this.panel2.TabIndex = 37;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.BackgroundColor = System.Drawing.Color.White;
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnReset.BorderRadius = 3;
            this.btnReset.BorderSize = 2;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnReset.Location = new System.Drawing.Point(157, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(127, 40);
            this.btnReset.TabIndex = 37;
            this.btnReset.Text = "&Reset";
            this.btnReset.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnApply.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnApply.BorderRadius = 3;
            this.btnApply.BorderSize = 2;
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(11, 10);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(127, 40);
            this.btnApply.TabIndex = 36;
            this.btnApply.Text = "&Apply";
            this.btnApply.TextColor = System.Drawing.Color.White;
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(294, 36);
            this.label7.TabIndex = 34;
            this.label7.Text = "Filters";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtcheckedOutTo
            // 
            this.txtcheckedOutTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtcheckedOutTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtcheckedOutTo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtcheckedOutTo.BorderRadius = 0;
            this.txtcheckedOutTo.BorderSize = 1;
            this.txtcheckedOutTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtcheckedOutTo.Enabled = false;
            this.txtcheckedOutTo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcheckedOutTo.ForeColor = System.Drawing.Color.Black;
            this.txtcheckedOutTo.Location = new System.Drawing.Point(11, 526);
            this.txtcheckedOutTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtcheckedOutTo.Multiline = false;
            this.txtcheckedOutTo.Name = "txtcheckedOutTo";
            this.txtcheckedOutTo.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtcheckedOutTo.PasswordChar = false;
            this.txtcheckedOutTo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtcheckedOutTo.PlaceholderText = "";
            this.txtcheckedOutTo.Size = new System.Drawing.Size(237, 35);
            this.txtcheckedOutTo.TabIndex = 32;
            this.txtcheckedOutTo.Texts = "All";
            this.txtcheckedOutTo.UnderlinedStyle = false;
            this.txtcheckedOutTo.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 504);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "checked Out To";
            this.label6.Visible = false;
            // 
            // txtSerLocation
            // 
            this.txtSerLocation.BackColor = System.Drawing.SystemColors.Window;
            this.txtSerLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSerLocation.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSerLocation.BorderRadius = 0;
            this.txtSerLocation.BorderSize = 1;
            this.txtSerLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSerLocation.Enabled = false;
            this.txtSerLocation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerLocation.ForeColor = System.Drawing.Color.Black;
            this.txtSerLocation.Location = new System.Drawing.Point(11, 338);
            this.txtSerLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerLocation.Multiline = false;
            this.txtSerLocation.Name = "txtSerLocation";
            this.txtSerLocation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSerLocation.PasswordChar = false;
            this.txtSerLocation.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSerLocation.PlaceholderText = "";
            this.txtSerLocation.Size = new System.Drawing.Size(237, 35);
            this.txtSerLocation.TabIndex = 29;
            this.txtSerLocation.Texts = "All";
            this.txtSerLocation.UnderlinedStyle = false;
            this.txtSerLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Location";
            // 
            // chkCheckedOut
            // 
            this.chkCheckedOut.AutoSize = true;
            this.chkCheckedOut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCheckedOut.Location = new System.Drawing.Point(108, 279);
            this.chkCheckedOut.Name = "chkCheckedOut";
            this.chkCheckedOut.Size = new System.Drawing.Size(112, 24);
            this.chkCheckedOut.TabIndex = 27;
            this.chkCheckedOut.Text = "Checked Out";
            this.chkCheckedOut.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Asset Status";
            // 
            // ChkInStock
            // 
            this.ChkInStock.AutoSize = true;
            this.ChkInStock.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkInStock.Location = new System.Drawing.Point(14, 279);
            this.ChkInStock.Name = "ChkInStock";
            this.ChkInStock.Size = new System.Drawing.Size(80, 24);
            this.ChkInStock.TabIndex = 25;
            this.ChkInStock.Text = "In Stock";
            this.ChkInStock.UseVisualStyleBackColor = true;
            // 
            // txtSearPart
            // 
            this.txtSearPart.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearPart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSearPart.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSearPart.BorderRadius = 0;
            this.txtSearPart.BorderSize = 1;
            this.txtSearPart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearPart.Enabled = false;
            this.txtSearPart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearPart.ForeColor = System.Drawing.Color.Black;
            this.txtSearPart.Location = new System.Drawing.Point(11, 206);
            this.txtSearPart.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearPart.Multiline = false;
            this.txtSearPart.Name = "txtSearPart";
            this.txtSearPart.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearPart.PasswordChar = false;
            this.txtSearPart.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearPart.PlaceholderText = "";
            this.txtSearPart.Size = new System.Drawing.Size(237, 35);
            this.txtSearPart.TabIndex = 23;
            this.txtSearPart.Texts = "All";
            this.txtSearPart.UnderlinedStyle = false;
            this.txtSearPart.Click += new System.EventHandler(this.btnSearchPart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Part";
            // 
            // txtserAssetCategory
            // 
            this.txtserAssetCategory.BackColor = System.Drawing.SystemColors.Window;
            this.txtserAssetCategory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtserAssetCategory.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtserAssetCategory.BorderRadius = 0;
            this.txtserAssetCategory.BorderSize = 1;
            this.txtserAssetCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtserAssetCategory.Enabled = false;
            this.txtserAssetCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserAssetCategory.ForeColor = System.Drawing.Color.Black;
            this.txtserAssetCategory.Location = new System.Drawing.Point(11, 136);
            this.txtserAssetCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtserAssetCategory.Multiline = false;
            this.txtserAssetCategory.Name = "txtserAssetCategory";
            this.txtserAssetCategory.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtserAssetCategory.PasswordChar = false;
            this.txtserAssetCategory.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtserAssetCategory.PlaceholderText = "";
            this.txtserAssetCategory.Size = new System.Drawing.Size(237, 35);
            this.txtserAssetCategory.TabIndex = 20;
            this.txtserAssetCategory.Texts = "All";
            this.txtserAssetCategory.UnderlinedStyle = false;
            this.txtserAssetCategory.Click += new System.EventHandler(this.btnSearchAssetCategory_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Asset Category";
            // 
            // txtSearAssetType
            // 
            this.txtSearAssetType.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearAssetType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSearAssetType.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSearAssetType.BorderRadius = 0;
            this.txtSearAssetType.BorderSize = 1;
            this.txtSearAssetType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSearAssetType.Enabled = false;
            this.txtSearAssetType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearAssetType.ForeColor = System.Drawing.Color.Black;
            this.txtSearAssetType.Location = new System.Drawing.Point(11, 70);
            this.txtSearAssetType.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearAssetType.Multiline = false;
            this.txtSearAssetType.Name = "txtSearAssetType";
            this.txtSearAssetType.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearAssetType.PasswordChar = false;
            this.txtSearAssetType.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearAssetType.PlaceholderText = "";
            this.txtSearAssetType.Size = new System.Drawing.Size(237, 35);
            this.txtSearAssetType.TabIndex = 17;
            this.txtSearAssetType.Texts = "All";
            this.txtSearAssetType.UnderlinedStyle = false;
            this.txtSearAssetType.Click += new System.EventHandler(this.btnSearchAssetType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Asset Type ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GrinEditDeleteDetailView);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(303, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(925, 827);
            this.panel3.TabIndex = 1;
            // 
            // GrinEditDeleteDetailView
            // 
            this.GrinEditDeleteDetailView.AllowUserToAddRows = false;
            this.GrinEditDeleteDetailView.AllowUserToDeleteRows = false;
            this.GrinEditDeleteDetailView.AllowUserToResizeColumns = false;
            this.GrinEditDeleteDetailView.AllowUserToResizeRows = false;
            this.GrinEditDeleteDetailView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.GrinEditDeleteDetailView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.GrinEditDeleteDetailView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GrinEditDeleteDetailView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrinEditDeleteDetailView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrinEditDeleteDetailView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrinEditDeleteDetailView.ColumnHeadersHeight = 40;
            this.GrinEditDeleteDetailView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(157)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrinEditDeleteDetailView.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrinEditDeleteDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrinEditDeleteDetailView.EnableHeadersVisualStyles = false;
            this.GrinEditDeleteDetailView.Location = new System.Drawing.Point(0, 45);
            this.GrinEditDeleteDetailView.MultiSelect = false;
            this.GrinEditDeleteDetailView.Name = "GrinEditDeleteDetailView";
            this.GrinEditDeleteDetailView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(89)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.GrinEditDeleteDetailView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GrinEditDeleteDetailView.RowHeadersVisible = false;
            this.GrinEditDeleteDetailView.RowTemplate.Height = 30;
            this.GrinEditDeleteDetailView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.GrinEditDeleteDetailView.Size = new System.Drawing.Size(925, 782);
            this.GrinEditDeleteDetailView.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.rjButton1);
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(925, 45);
            this.panel4.TabIndex = 1;
            // 
            // rjButton1
            // 
            this.rjButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButton1.BackColor = System.Drawing.Color.White;
            this.rjButton1.BackgroundColor = System.Drawing.Color.White;
            this.rjButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.rjButton1.BorderRadius = 3;
            this.rjButton1.BorderSize = 2;
            this.rjButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.rjButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.rjButton1.Location = new System.Drawing.Point(767, 5);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(143, 33);
            this.rjButton1.TabIndex = 38;
            this.rjButton1.Text = "&Export To Excel ";
            this.rjButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSearch.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(208)))));
            this.txtSearch.BorderRadius = 0;
            this.txtSearch.BorderSize = 1;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(15, 6);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSearch.PasswordChar = false;
            this.txtSearch.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearch.PlaceholderText = "Search here";
            this.txtSearch.Size = new System.Drawing.Size(328, 32);
            this.txtSearch.TabIndex = 47;
            this.txtSearch.Texts = "";
            this.txtSearch.UnderlinedStyle = false;
            this.txtSearch._TextChanged += new System.EventHandler(this.txtSearch__TextChanged);
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reports";
            this.Size = new System.Drawing.Size(1231, 833);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RJTextBox txtSearAssetType;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox txtserAssetCategory;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtSearPart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ChkInStock;
        private System.Windows.Forms.CheckBox chkCheckedOut;
        private CustomControls.RJControls.RJTextBox txtSerLocation;
        private System.Windows.Forms.Label label5;
        private CustomControls.RJControls.RJTextBox txtcheckedOutTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView GrinEditDeleteDetailView;
        private CustomControls.RJControls.RJButton btnApply;
        private CustomControls.RJControls.RJButton btnReset;
        private CustomControls.RJControls.RJButton btnSearchAssetType;
        private CustomControls.RJControls.RJButton btnSearchAssetCategory;
        private CustomControls.RJControls.RJButton rjButton5;
        private CustomControls.RJControls.RJButton btnLocation;
        private CustomControls.RJControls.RJButton btnSearchPart;
        private RJControls.RJDatePicker txtToDate;
        private System.Windows.Forms.Label labTodate;
        private RJControls.RJDatePicker txtFromDate;
        private System.Windows.Forms.Label labFromDate;
        private CustomControls.RJControls.RJTextBox txtSearch;
        private CustomControls.RJControls.RJButton rjButton1;
    }
}
