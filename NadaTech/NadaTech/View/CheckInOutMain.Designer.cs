namespace NadaTech.View
{
    partial class CheckInOutMain
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.GrinEditDeleteDetailView = new System.Windows.Forms.DataGridView();
			this.labDevicestatus = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.rjButton1 = new CustomControls.RJControls.RJButton();
			this.btnRefresh = new CustomControls.RJControls.RJButton();
			this.btnAdd = new CustomControls.RJControls.RJButton();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel1.Controls.Add(this.rjButton1);
			this.panel1.Controls.Add(this.GrinEditDeleteDetailView);
			this.panel1.Controls.Add(this.btnRefresh);
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Controls.Add(this.labDevicestatus);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(349, 782);
			this.panel1.TabIndex = 0;
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
			this.GrinEditDeleteDetailView.EnableHeadersVisualStyles = false;
			this.GrinEditDeleteDetailView.Location = new System.Drawing.Point(6, 30);
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
			this.GrinEditDeleteDetailView.Size = new System.Drawing.Size(337, 374);
			this.GrinEditDeleteDetailView.TabIndex = 23;
			// 
			// labDevicestatus
			// 
			this.labDevicestatus.AutoSize = true;
			this.labDevicestatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labDevicestatus.Location = new System.Drawing.Point(3, 10);
			this.labDevicestatus.Name = "labDevicestatus";
			this.labDevicestatus.Size = new System.Drawing.Size(90, 17);
			this.labDevicestatus.TabIndex = 19;
			this.labDevicestatus.Text = "List of Reader";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.tabControl1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(349, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(904, 782);
			this.panel2.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(904, 782);
			this.tabControl1.TabIndex = 0;
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
			this.rjButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rjButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.rjButton1.Location = new System.Drawing.Point(28, 410);
			this.rjButton1.Name = "rjButton1";
			this.rjButton1.Size = new System.Drawing.Size(101, 35);
			this.rjButton1.TabIndex = 24;
			this.rjButton1.Text = "Select";
			this.rjButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.rjButton1.UseVisualStyleBackColor = false;
			this.rjButton1.Visible = false;
			this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.BackColor = System.Drawing.Color.White;
			this.btnRefresh.BackgroundColor = System.Drawing.Color.White;
			this.btnRefresh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnRefresh.BorderRadius = 3;
			this.btnRefresh.BorderSize = 2;
			this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefresh.FlatAppearance.BorderSize = 0;
			this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
			this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnRefresh.Location = new System.Drawing.Point(135, 410);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(101, 35);
			this.btnRefresh.TabIndex = 22;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.BackColor = System.Drawing.Color.White;
			this.btnAdd.BackgroundColor = System.Drawing.Color.White;
			this.btnAdd.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnAdd.BorderRadius = 3;
			this.btnAdd.BorderSize = 2;
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAdd.FlatAppearance.BorderSize = 0;
			this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
			this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnAdd.Location = new System.Drawing.Point(242, 410);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(101, 35);
			this.btnAdd.TabIndex = 20;
			this.btnAdd.Text = "Connect";
			this.btnAdd.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// CheckInOutMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "CheckInOutMain";
			this.Size = new System.Drawing.Size(1253, 782);
			this.VisibleChanged += new System.EventHandler(this.CheckInOutMain_VisibleChanged);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labDevicestatus;
        private CustomControls.RJControls.RJButton btnAdd;
        private System.Windows.Forms.TabControl tabControl1;
		private CustomControls.RJControls.RJButton btnRefresh;
		private System.Windows.Forms.DataGridView GrinEditDeleteDetailView;
		private CustomControls.RJControls.RJButton rjButton1;
	}
}
