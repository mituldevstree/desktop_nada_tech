namespace NadaTech.View
{
    partial class ReportMainUC
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
            this.btnTransactionReport = new CustomControls.RJControls.RJButton();
            this.btnInventoryReport = new CustomControls.RJControls.RJButton();
            this.SuspendLayout();
            // 
            // btnTransactionReport
            // 
            this.btnTransactionReport.BackColor = System.Drawing.Color.White;
            this.btnTransactionReport.BackgroundColor = System.Drawing.Color.White;
            this.btnTransactionReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnTransactionReport.BorderRadius = 3;
            this.btnTransactionReport.BorderSize = 2;
            this.btnTransactionReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransactionReport.FlatAppearance.BorderSize = 0;
            this.btnTransactionReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnTransactionReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTransactionReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionReport.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnTransactionReport.Location = new System.Drawing.Point(20, 15);
            this.btnTransactionReport.Name = "btnTransactionReport";
            this.btnTransactionReport.Size = new System.Drawing.Size(232, 40);
            this.btnTransactionReport.TabIndex = 18;
            this.btnTransactionReport.Text = "Transaction Report";
            this.btnTransactionReport.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnTransactionReport.UseVisualStyleBackColor = false;
            this.btnTransactionReport.Click += new System.EventHandler(this.btnTransactionReport_Click);
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.BackColor = System.Drawing.Color.White;
            this.btnInventoryReport.BackgroundColor = System.Drawing.Color.White;
            this.btnInventoryReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnInventoryReport.BorderRadius = 3;
            this.btnInventoryReport.BorderSize = 2;
            this.btnInventoryReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInventoryReport.FlatAppearance.BorderSize = 0;
            this.btnInventoryReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnInventoryReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnInventoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventoryReport.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnInventoryReport.Location = new System.Drawing.Point(20, 61);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(232, 40);
            this.btnInventoryReport.TabIndex = 19;
            this.btnInventoryReport.Text = "Asset Report";
            this.btnInventoryReport.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnInventoryReport.UseVisualStyleBackColor = false;
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // ReportMainUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnInventoryReport);
            this.Controls.Add(this.btnTransactionReport);
            this.Name = "ReportMainUC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1019, 688);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RJControls.RJButton btnTransactionReport;
        private CustomControls.RJControls.RJButton btnInventoryReport;
    }
}
