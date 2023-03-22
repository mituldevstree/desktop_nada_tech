namespace NadaTech_EncodingStation
{
    partial class MasterForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.FLPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnlHome = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlHelp = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.LblUserName = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnlogout = new CustomControls.RJControls.RJCircularPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iconminimizar = new System.Windows.Forms.PictureBox();
            this.iconcerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.MbtnDashbord = new CustomControls.RJControls.RJButton();
            this.MbtnReaderEncoding = new CustomControls.RJControls.RJButton();
            this.MbtnHelp = new CustomControls.RJControls.RJButton();
            this.MenuVertical.SuspendLayout();
            this.FLPanelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PnlHome.SuspendLayout();
            this.PnlHelp.SuspendLayout();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.MenuVertical.Controls.Add(this.FLPanelMenu);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(250, 972);
            this.MenuVertical.TabIndex = 0;
            // 
            // FLPanelMenu
            // 
            this.FLPanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.FLPanelMenu.Controls.Add(this.panel1);
            this.FLPanelMenu.Controls.Add(this.PnlHome);
            this.FLPanelMenu.Controls.Add(this.MbtnDashbord);
            this.FLPanelMenu.Controls.Add(this.MbtnReaderEncoding);
            this.FLPanelMenu.Controls.Add(this.PnlHelp);
            this.FLPanelMenu.Controls.Add(this.MbtnHelp);
            this.FLPanelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelMenu.Location = new System.Drawing.Point(0, 0);
            this.FLPanelMenu.Name = "FLPanelMenu";
            this.FLPanelMenu.Size = new System.Drawing.Size(250, 972);
            this.FLPanelMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 76);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 2);
            this.panel2.TabIndex = 1;
            // 
            // PnlHome
            // 
            this.PnlHome.Controls.Add(this.label1);
            this.PnlHome.Location = new System.Drawing.Point(3, 76);
            this.PnlHome.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.PnlHome.Name = "PnlHome";
            this.PnlHome.Size = new System.Drawing.Size(239, 34);
            this.PnlHome.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "HOME";
            // 
            // PnlHelp
            // 
            this.PnlHelp.Controls.Add(this.label8);
            this.PnlHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlHelp.Location = new System.Drawing.Point(3, 235);
            this.PnlHelp.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.PnlHelp.Name = "PnlHelp";
            this.PnlHelp.Size = new System.Drawing.Size(239, 34);
            this.PnlHelp.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightGray;
            this.label8.Location = new System.Drawing.Point(5, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "HELP";
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.BarraTitulo.Controls.Add(this.LblUserName);
            this.BarraTitulo.Controls.Add(this.btnlogout);
            this.BarraTitulo.Controls.Add(this.pictureBox1);
            this.BarraTitulo.Controls.Add(this.labTitle);
            this.BarraTitulo.Controls.Add(this.iconminimizar);
            this.BarraTitulo.Controls.Add(this.iconcerrar);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(250, 0);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1050, 55);
            this.BarraTitulo.TabIndex = 1;
            this.BarraTitulo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            this.BarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraTitulo_MouseDown);
            // 
            // LblUserName
            // 
            this.LblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserName.ForeColor = System.Drawing.Color.White;
            this.LblUserName.Location = new System.Drawing.Point(829, 17);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblUserName.Size = new System.Drawing.Size(118, 18);
            this.LblUserName.TabIndex = 6;
            this.LblUserName.Text = "ADMIN";
            this.LblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblUserName.Visible = false;
            this.LblUserName.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.ForeColor = System.Drawing.Color.White;
            this.labTitle.Location = new System.Drawing.Point(9, 12);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(139, 30);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "NADA TECH.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(250, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 917F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 917F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1050, 917);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnlogout
            // 
            this.btnlogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlogout.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.btnlogout.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnlogout.BorderColor2 = System.Drawing.Color.HotPink;
            this.btnlogout.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btnlogout.BorderSize = 2;
            this.btnlogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogout.GradientAngle = 50F;
            this.btnlogout.Location = new System.Drawing.Point(786, 8);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(37, 37);
            this.btnlogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnlogout.TabIndex = 0;
            this.btnlogout.TabStop = false;
            this.btnlogout.Visible = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(991, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // iconminimizar
            // 
            this.iconminimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconminimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconminimizar.ErrorImage = null;
            this.iconminimizar.Image = global::NadaTech_EncodingStation.Properties.Resources.icons8_minimize_window_30;
            this.iconminimizar.Location = new System.Drawing.Point(963, 16);
            this.iconminimizar.Name = "iconminimizar";
            this.iconminimizar.Size = new System.Drawing.Size(25, 23);
            this.iconminimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconminimizar.TabIndex = 4;
            this.iconminimizar.TabStop = false;
            this.iconminimizar.Click += new System.EventHandler(this.iconminimizar_Click);
            // 
            // iconcerrar
            // 
            this.iconcerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconcerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconcerrar.Image = global::NadaTech_EncodingStation.Properties.Resources.error;
            this.iconcerrar.Location = new System.Drawing.Point(1019, 16);
            this.iconcerrar.Name = "iconcerrar";
            this.iconcerrar.Size = new System.Drawing.Size(25, 23);
            this.iconcerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconcerrar.TabIndex = 1;
            this.iconcerrar.TabStop = false;
            this.iconcerrar.Click += new System.EventHandler(this.iconcerrar_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::NadaTech_EncodingStation.Properties.Resources.logoNew;
            this.pictureBox5.Location = new System.Drawing.Point(28, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(184, 64);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // MbtnDashbord
            // 
            this.MbtnDashbord.BackColor = System.Drawing.Color.Transparent;
            this.MbtnDashbord.BackgroundColor = System.Drawing.Color.Transparent;
            this.MbtnDashbord.BorderColor = System.Drawing.Color.Transparent;
            this.MbtnDashbord.BorderRadius = 10;
            this.MbtnDashbord.BorderSize = 0;
            this.MbtnDashbord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MbtnDashbord.FlatAppearance.BorderSize = 0;
            this.MbtnDashbord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.MbtnDashbord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.MbtnDashbord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MbtnDashbord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MbtnDashbord.ForeColor = System.Drawing.Color.White;
            this.MbtnDashbord.Image = global::NadaTech_EncodingStation.Properties.Resources.Icon_Printer;
            this.MbtnDashbord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MbtnDashbord.Location = new System.Drawing.Point(10, 116);
            this.MbtnDashbord.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.MbtnDashbord.Name = "MbtnDashbord";
            this.MbtnDashbord.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MbtnDashbord.Size = new System.Drawing.Size(229, 50);
            this.MbtnDashbord.TabIndex = 31;
            this.MbtnDashbord.Text = "     Printer Encoding";
            this.MbtnDashbord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MbtnDashbord.TextColor = System.Drawing.Color.White;
            this.MbtnDashbord.UseVisualStyleBackColor = false;
            this.MbtnDashbord.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // MbtnReaderEncoding
            // 
            this.MbtnReaderEncoding.BackColor = System.Drawing.Color.Transparent;
            this.MbtnReaderEncoding.BackgroundColor = System.Drawing.Color.Transparent;
            this.MbtnReaderEncoding.BorderColor = System.Drawing.Color.Transparent;
            this.MbtnReaderEncoding.BorderRadius = 10;
            this.MbtnReaderEncoding.BorderSize = 0;
            this.MbtnReaderEncoding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MbtnReaderEncoding.FlatAppearance.BorderSize = 0;
            this.MbtnReaderEncoding.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.MbtnReaderEncoding.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.MbtnReaderEncoding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MbtnReaderEncoding.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MbtnReaderEncoding.ForeColor = System.Drawing.Color.White;
            this.MbtnReaderEncoding.Image = global::NadaTech_EncodingStation.Properties.Resources.Icon_RFIDReader;
            this.MbtnReaderEncoding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MbtnReaderEncoding.Location = new System.Drawing.Point(10, 172);
            this.MbtnReaderEncoding.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.MbtnReaderEncoding.Name = "MbtnReaderEncoding";
            this.MbtnReaderEncoding.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MbtnReaderEncoding.Size = new System.Drawing.Size(229, 50);
            this.MbtnReaderEncoding.TabIndex = 45;
            this.MbtnReaderEncoding.Text = "     Reader Encoding";
            this.MbtnReaderEncoding.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MbtnReaderEncoding.TextColor = System.Drawing.Color.White;
            this.MbtnReaderEncoding.UseVisualStyleBackColor = false;
            this.MbtnReaderEncoding.Click += new System.EventHandler(this.MbtnReaderEncoding_Click);
            // 
            // MbtnHelp
            // 
            this.MbtnHelp.BackColor = System.Drawing.Color.Transparent;
            this.MbtnHelp.BackgroundColor = System.Drawing.Color.Transparent;
            this.MbtnHelp.BorderColor = System.Drawing.Color.Transparent;
            this.MbtnHelp.BorderRadius = 10;
            this.MbtnHelp.BorderSize = 0;
            this.MbtnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MbtnHelp.FlatAppearance.BorderSize = 0;
            this.MbtnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.MbtnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.MbtnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MbtnHelp.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MbtnHelp.ForeColor = System.Drawing.Color.White;
            this.MbtnHelp.Image = global::NadaTech_EncodingStation.Properties.Resources.Help;
            this.MbtnHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MbtnHelp.Location = new System.Drawing.Point(10, 272);
            this.MbtnHelp.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.MbtnHelp.Name = "MbtnHelp";
            this.MbtnHelp.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MbtnHelp.Size = new System.Drawing.Size(229, 50);
            this.MbtnHelp.TabIndex = 44;
            this.MbtnHelp.Text = "     Help Center";
            this.MbtnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MbtnHelp.TextColor = System.Drawing.Color.White;
            this.MbtnHelp.UseVisualStyleBackColor = false;
            this.MbtnHelp.Click += new System.EventHandler(this.MbtnHelp_Click);
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 972);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.MenuVertical);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NADA TECH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuVertical.ResumeLayout(false);
            this.FLPanelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PnlHome.ResumeLayout(false);
            this.PnlHome.PerformLayout();
            this.PnlHelp.ResumeLayout(false);
            this.PnlHelp.PerformLayout();
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconminimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconcerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MenuVertical;
        private System.Windows.Forms.Panel BarraTitulo;
        private System.Windows.Forms.PictureBox iconcerrar;
        private System.Windows.Forms.FlowLayoutPanel FLPanelMenu;
        private System.Windows.Forms.PictureBox iconminimizar;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.RJControls.RJButton MbtnDashbord;
        private CustomControls.RJControls.RJCircularPictureBox btnlogout;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel PnlHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlHelp;
        private System.Windows.Forms.Label label8;
        private CustomControls.RJControls.RJButton MbtnHelp;
        private CustomControls.RJControls.RJButton MbtnReaderEncoding;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

