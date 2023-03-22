namespace NadaTech.View
{
    partial class CheckInOut
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.GrinEditDeleteDetailView = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labDevicestatus = new System.Windows.Forms.Label();
			this.btnStartScan = new CustomControls.RJControls.RJButton();
			this.btnStopScan = new CustomControls.RJControls.RJButton();
			this.iconcerrar = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 591);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1002, 585);
			this.panel1.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.GrinEditDeleteDetailView);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 47);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(1002, 538);
			this.panel4.TabIndex = 7;
			// 
			// GrinEditDeleteDetailView
			// 
			this.GrinEditDeleteDetailView.AllowUserToAddRows = false;
			this.GrinEditDeleteDetailView.AllowUserToDeleteRows = false;
			this.GrinEditDeleteDetailView.AllowUserToOrderColumns = true;
			this.GrinEditDeleteDetailView.AllowUserToResizeColumns = false;
			this.GrinEditDeleteDetailView.AllowUserToResizeRows = false;
			this.GrinEditDeleteDetailView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.GrinEditDeleteDetailView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.GrinEditDeleteDetailView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GrinEditDeleteDetailView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(208)))));
			dataGridViewCellStyle31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle31.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(118)))), ((int)(((byte)(208)))));
			dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.GrinEditDeleteDetailView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
			this.GrinEditDeleteDetailView.ColumnHeadersHeight = 40;
			this.GrinEditDeleteDetailView.Cursor = System.Windows.Forms.Cursors.Hand;
			dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle32.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(157)))), ((int)(((byte)(213)))));
			dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.GrinEditDeleteDetailView.DefaultCellStyle = dataGridViewCellStyle32;
			this.GrinEditDeleteDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GrinEditDeleteDetailView.EnableHeadersVisualStyles = false;
			this.GrinEditDeleteDetailView.Location = new System.Drawing.Point(0, 0);
			this.GrinEditDeleteDetailView.MultiSelect = false;
			this.GrinEditDeleteDetailView.Name = "GrinEditDeleteDetailView";
			this.GrinEditDeleteDetailView.ReadOnly = true;
			dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(89)))), ((int)(((byte)(115)))));
			dataGridViewCellStyle33.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle33.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.GrinEditDeleteDetailView.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
			this.GrinEditDeleteDetailView.RowHeadersVisible = false;
			this.GrinEditDeleteDetailView.RowTemplate.Height = 30;
			this.GrinEditDeleteDetailView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.GrinEditDeleteDetailView.Size = new System.Drawing.Size(1002, 538);
			this.GrinEditDeleteDetailView.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel2.Controls.Add(this.iconcerrar);
			this.panel2.Controls.Add(this.btnStartScan);
			this.panel2.Controls.Add(this.btnStopScan);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.labDevicestatus);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1002, 47);
			this.panel2.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Green;
			this.label2.Location = new System.Drawing.Point(184, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 25);
			this.label2.TabIndex = 21;
			this.label2.Text = "Auto Save";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Green;
			this.label1.Location = new System.Drawing.Point(279, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 25);
			this.label1.TabIndex = 20;
			this.label1.Text = "(8 Sec)";
			// 
			// labDevicestatus
			// 
			this.labDevicestatus.AutoSize = true;
			this.labDevicestatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labDevicestatus.Location = new System.Drawing.Point(73, 13);
			this.labDevicestatus.Name = "labDevicestatus";
			this.labDevicestatus.Size = new System.Drawing.Size(58, 17);
			this.labDevicestatus.TabIndex = 18;
			this.labDevicestatus.Text = "Connect";
			// 
			// btnStartScan
			// 
			this.btnStartScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnStartScan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnStartScan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnStartScan.BorderRadius = 3;
			this.btnStartScan.BorderSize = 2;
			this.btnStartScan.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnStartScan.FlatAppearance.BorderSize = 0;
			this.btnStartScan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
			this.btnStartScan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
			this.btnStartScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStartScan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStartScan.ForeColor = System.Drawing.Color.White;
			this.btnStartScan.Location = new System.Drawing.Point(380, 5);
			this.btnStartScan.Name = "btnStartScan";
			this.btnStartScan.Size = new System.Drawing.Size(98, 32);
			this.btnStartScan.TabIndex = 25;
			this.btnStartScan.Text = "Start Scan";
			this.btnStartScan.TextColor = System.Drawing.Color.White;
			this.btnStartScan.UseVisualStyleBackColor = false;
			this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
			// 
			// btnStopScan
			// 
			this.btnStopScan.BackColor = System.Drawing.Color.White;
			this.btnStopScan.BackgroundColor = System.Drawing.Color.White;
			this.btnStopScan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnStopScan.BorderRadius = 3;
			this.btnStopScan.BorderSize = 2;
			this.btnStopScan.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnStopScan.FlatAppearance.BorderSize = 0;
			this.btnStopScan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
			this.btnStopScan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
			this.btnStopScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStopScan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStopScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnStopScan.Location = new System.Drawing.Point(380, 5);
			this.btnStopScan.Name = "btnStopScan";
			this.btnStopScan.Size = new System.Drawing.Size(98, 32);
			this.btnStopScan.TabIndex = 24;
			this.btnStopScan.Text = "Stop Scan";
			this.btnStopScan.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
			this.btnStopScan.UseVisualStyleBackColor = false;
			this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
			// 
			// iconcerrar
			// 
			this.iconcerrar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.iconcerrar.Image = global::NadaTech.Properties.Resources.error;
			this.iconcerrar.Location = new System.Drawing.Point(7, 10);
			this.iconcerrar.Name = "iconcerrar";
			this.iconcerrar.Size = new System.Drawing.Size(25, 23);
			this.iconcerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.iconcerrar.TabIndex = 27;
			this.iconcerrar.TabStop = false;
			this.iconcerrar.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// CheckInOut
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "CheckInOut";
			this.Size = new System.Drawing.Size(1008, 591);
			this.Load += new System.EventHandler(this.UserControl1_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GrinEditDeleteDetailView)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView GrinEditDeleteDetailView;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labDevicestatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private CustomControls.RJControls.RJButton btnStopScan;
		private CustomControls.RJControls.RJButton btnStartScan;
		private System.Windows.Forms.PictureBox iconcerrar;
	}
}
