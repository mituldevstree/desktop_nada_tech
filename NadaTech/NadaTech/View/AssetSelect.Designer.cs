namespace NadaTech.View
{
    partial class AssetSelect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GrinEditDeleteDetailView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearchSearial = new CustomControls.RJControls.RJTextBox();
            this.txtSearchTag = new CustomControls.RJControls.RJTextBox();
            this.txtSearchPart = new CustomControls.RJControls.RJTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lablocation = new System.Windows.Forms.Label();
            this.CmbLocation = new System.Windows.Forms.ComboBox();
            this.btnClose = new CustomControls.RJControls.RJButton();
            this.btnSelect = new CustomControls.RJControls.RJButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(731, 554);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(723, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual Entry";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GrinEditDeleteDetailView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(715, 393);
            this.panel3.TabIndex = 5;
            // 
            // GrinEditDeleteDetailView
            // 
            this.GrinEditDeleteDetailView.AllowUserToAddRows = false;
            this.GrinEditDeleteDetailView.AllowUserToDeleteRows = false;
            this.GrinEditDeleteDetailView.AllowUserToResizeColumns = false;
            this.GrinEditDeleteDetailView.AllowUserToResizeRows = false;
            this.GrinEditDeleteDetailView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrinEditDeleteDetailView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GrinEditDeleteDetailView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GrinEditDeleteDetailView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrinEditDeleteDetailView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GrinEditDeleteDetailView.ColumnHeadersHeight = 40;
            this.GrinEditDeleteDetailView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(157)))), ((int)(((byte)(213)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GrinEditDeleteDetailView.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrinEditDeleteDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrinEditDeleteDetailView.EnableHeadersVisualStyles = false;
            this.GrinEditDeleteDetailView.Location = new System.Drawing.Point(0, 0);
            this.GrinEditDeleteDetailView.MultiSelect = false;
            this.GrinEditDeleteDetailView.Name = "GrinEditDeleteDetailView";
            this.GrinEditDeleteDetailView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(89)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GrinEditDeleteDetailView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.GrinEditDeleteDetailView.RowHeadersVisible = false;
            this.GrinEditDeleteDetailView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.GrinEditDeleteDetailView.RowTemplate.Height = 30;
            this.GrinEditDeleteDetailView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GrinEditDeleteDetailView.Size = new System.Drawing.Size(715, 393);
            this.GrinEditDeleteDetailView.TabIndex = 3;
            this.GrinEditDeleteDetailView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrinEditDeleteDetailView_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSearchSearial);
            this.panel2.Controls.Add(this.txtSearchTag);
            this.panel2.Controls.Add(this.txtSearchPart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(715, 123);
            this.panel2.TabIndex = 4;
            // 
            // txtSearchSearial
            // 
            this.txtSearchSearial.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearchSearial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSearchSearial.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSearchSearial.BorderRadius = 0;
            this.txtSearchSearial.BorderSize = 1;
            this.txtSearchSearial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSearial.ForeColor = System.Drawing.Color.Black;
            this.txtSearchSearial.Location = new System.Drawing.Point(4, 82);
            this.txtSearchSearial.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchSearial.Multiline = false;
            this.txtSearchSearial.Name = "txtSearchSearial";
            this.txtSearchSearial.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtSearchSearial.PasswordChar = false;
            this.txtSearchSearial.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchSearial.PlaceholderText = "Serial Number";
            this.txtSearchSearial.Size = new System.Drawing.Size(380, 32);
            this.txtSearchSearial.TabIndex = 18;
            this.txtSearchSearial.Texts = "";
            this.txtSearchSearial.UnderlinedStyle = false;
            this.txtSearchSearial.Leave += new System.EventHandler(this.txtSearchPart__TextChanged);
            // 
            // txtSearchTag
            // 
            this.txtSearchTag.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearchTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSearchTag.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSearchTag.BorderRadius = 0;
            this.txtSearchTag.BorderSize = 1;
            this.txtSearchTag.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTag.ForeColor = System.Drawing.Color.Black;
            this.txtSearchTag.Location = new System.Drawing.Point(4, 46);
            this.txtSearchTag.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchTag.Multiline = false;
            this.txtSearchTag.Name = "txtSearchTag";
            this.txtSearchTag.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtSearchTag.PasswordChar = false;
            this.txtSearchTag.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchTag.PlaceholderText = "Tag Id";
            this.txtSearchTag.Size = new System.Drawing.Size(380, 32);
            this.txtSearchTag.TabIndex = 17;
            this.txtSearchTag.Texts = "";
            this.txtSearchTag.UnderlinedStyle = false;
            this.txtSearchTag.Leave += new System.EventHandler(this.txtSearchPart__TextChanged);
            // 
            // txtSearchPart
            // 
            this.txtSearchPart.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearchPart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSearchPart.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSearchPart.BorderRadius = 0;
            this.txtSearchPart.BorderSize = 1;
            this.txtSearchPart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPart.ForeColor = System.Drawing.Color.Black;
            this.txtSearchPart.Location = new System.Drawing.Point(4, 6);
            this.txtSearchPart.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchPart.Multiline = false;
            this.txtSearchPart.Name = "txtSearchPart";
            this.txtSearchPart.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.txtSearchPart.PasswordChar = false;
            this.txtSearchPart.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchPart.PlaceholderText = "Part Number or Asset Name";
            this.txtSearchPart.Size = new System.Drawing.Size(380, 32);
            this.txtSearchPart.TabIndex = 16;
            this.txtSearchPart.Texts = "";
            this.txtSearchPart.UnderlinedStyle = false;
            this.txtSearchPart.Leave += new System.EventHandler(this.txtSearchPart__TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(739, 625);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lablocation);
            this.panel1.Controls.Add(this.CmbLocation);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 565);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 57);
            this.panel1.TabIndex = 1;
            // 
            // lablocation
            // 
            this.lablocation.AutoSize = true;
            this.lablocation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablocation.Location = new System.Drawing.Point(9, 16);
            this.lablocation.Name = "lablocation";
            this.lablocation.Size = new System.Drawing.Size(66, 20);
            this.lablocation.TabIndex = 41;
            this.lablocation.Text = "Location";
            // 
            // CmbLocation
            // 
            this.CmbLocation.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLocation.FormattingEnabled = true;
            this.CmbLocation.Location = new System.Drawing.Point(87, 13);
            this.CmbLocation.Name = "CmbLocation";
            this.CmbLocation.Size = new System.Drawing.Size(306, 28);
            this.CmbLocation.TabIndex = 40;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundColor = System.Drawing.Color.White;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnClose.BorderRadius = 3;
            this.btnClose.BorderSize = 2;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnClose.Location = new System.Drawing.Point(627, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 42);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "&Close";
            this.btnClose.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSelect.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSelect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSelect.BorderRadius = 3;
            this.btnSelect.BorderSize = 2;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(516, 8);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(97, 40);
            this.btnSelect.TabIndex = 22;
            this.btnSelect.Text = "S&elect";
            this.btnSelect.TextColor = System.Drawing.Color.White;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // AssetSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(739, 625);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssetSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Entry";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView GrinEditDeleteDetailView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CustomControls.RJControls.RJTextBox txtSearchPart;
        private CustomControls.RJControls.RJButton btnSelect;
        private CustomControls.RJControls.RJButton btnClose;
        private CustomControls.RJControls.RJTextBox txtSearchTag;
        private CustomControls.RJControls.RJTextBox txtSearchSearial;
        private System.Windows.Forms.ComboBox CmbLocation;
        private System.Windows.Forms.Label lablocation;
    }
}