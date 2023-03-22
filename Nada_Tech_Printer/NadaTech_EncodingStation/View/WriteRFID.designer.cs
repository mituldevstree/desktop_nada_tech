namespace NadaTech_EncodingStation.View
{
    partial class WriteRFID
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteRFID));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFreeText = new CustomControls.RJControls.RJTextBox();
            this.RbRFIDBarcode = new CustomControls.RJControls.RJRadioButton();
            this.RbRFIDText = new CustomControls.RJControls.RJRadioButton();
            this.RbRFIDOnly = new CustomControls.RJControls.RJRadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrefixHex = new CustomControls.RJControls.RJTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoofTag = new CustomControls.RJControls.RJTextBox();
            this.txtPrefix = new CustomControls.RJControls.RJTextBox();
            this.panelUSB = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUSBPorts = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlDriver = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDriver = new System.Windows.Forms.ComboBox();
            this.lblDriverVersion = new System.Windows.Forms.Label();
            this.btnRefDriver = new System.Windows.Forms.Button();
            this.panelSocket = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPort = new CustomControls.RJControls.RJTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIP = new CustomControls.RJControls.RJTextBox();
            this.cbTCPIP = new System.Windows.Forms.ComboBox();
            this.btn_TCPIPRefresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbInterfaces = new System.Windows.Forms.ComboBox();
            this.btnSave = new CustomControls.RJControls.RJButton();
            this.panel1.SuspendLayout();
            this.panelUSB.SuspendLayout();
            this.pnlDriver.SuspendLayout();
            this.panelSocket.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtFreeText);
            this.panel1.Controls.Add(this.RbRFIDBarcode);
            this.panel1.Controls.Add(this.RbRFIDText);
            this.panel1.Controls.Add(this.RbRFIDOnly);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPrefixHex);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNoofTag);
            this.panel1.Controls.Add(this.txtPrefix);
            this.panel1.Controls.Add(this.panelUSB);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pnlDriver);
            this.panel1.Controls.Add(this.panelSocket);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbInterfaces);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 620);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "Free Text";
            // 
            // txtFreeText
            // 
            this.txtFreeText.BackColor = System.Drawing.SystemColors.Window;
            this.txtFreeText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtFreeText.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtFreeText.BorderRadius = 0;
            this.txtFreeText.BorderSize = 1;
            this.txtFreeText.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFreeText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFreeText.ForeColor = System.Drawing.Color.Black;
            this.txtFreeText.Location = new System.Drawing.Point(31, 292);
            this.txtFreeText.Margin = new System.Windows.Forms.Padding(4);
            this.txtFreeText.MaxLength = 30;
            this.txtFreeText.Multiline = false;
            this.txtFreeText.Name = "txtFreeText";
            this.txtFreeText.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFreeText.PasswordChar = false;
            this.txtFreeText.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFreeText.PlaceholderText = "";
            this.txtFreeText.Size = new System.Drawing.Size(502, 35);
            this.txtFreeText.TabIndex = 8;
            this.txtFreeText.Texts = "";
            this.txtFreeText.UnderlinedStyle = false;
            // 
            // RbRFIDBarcode
            // 
            this.RbRFIDBarcode.AutoSize = true;
            this.RbRFIDBarcode.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.RbRFIDBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbRFIDBarcode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbRFIDBarcode.Location = new System.Drawing.Point(292, 172);
            this.RbRFIDBarcode.MinimumSize = new System.Drawing.Size(0, 21);
            this.RbRFIDBarcode.Name = "RbRFIDBarcode";
            this.RbRFIDBarcode.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.RbRFIDBarcode.Size = new System.Drawing.Size(162, 24);
            this.RbRFIDBarcode.TabIndex = 4;
            this.RbRFIDBarcode.Text = "RFID With Barcode";
            this.RbRFIDBarcode.UnCheckedColor = System.Drawing.Color.Gray;
            this.RbRFIDBarcode.UseVisualStyleBackColor = true;
            this.RbRFIDBarcode.CheckedChanged += new System.EventHandler(this.RbRFIDOnly_CheckedChanged);
            // 
            // RbRFIDText
            // 
            this.RbRFIDText.AutoSize = true;
            this.RbRFIDText.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.RbRFIDText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbRFIDText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbRFIDText.Location = new System.Drawing.Point(150, 172);
            this.RbRFIDText.MinimumSize = new System.Drawing.Size(0, 21);
            this.RbRFIDText.Name = "RbRFIDText";
            this.RbRFIDText.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.RbRFIDText.Size = new System.Drawing.Size(134, 24);
            this.RbRFIDText.TabIndex = 3;
            this.RbRFIDText.Text = "RFID With Text";
            this.RbRFIDText.UnCheckedColor = System.Drawing.Color.Gray;
            this.RbRFIDText.UseVisualStyleBackColor = true;
            this.RbRFIDText.CheckedChanged += new System.EventHandler(this.RbRFIDOnly_CheckedChanged);
            // 
            // RbRFIDOnly
            // 
            this.RbRFIDOnly.AutoSize = true;
            this.RbRFIDOnly.Checked = true;
            this.RbRFIDOnly.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.RbRFIDOnly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RbRFIDOnly.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RbRFIDOnly.ForeColor = System.Drawing.Color.Black;
            this.RbRFIDOnly.Location = new System.Drawing.Point(36, 172);
            this.RbRFIDOnly.MinimumSize = new System.Drawing.Size(0, 21);
            this.RbRFIDOnly.Name = "RbRFIDOnly";
            this.RbRFIDOnly.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.RbRFIDOnly.Size = new System.Drawing.Size(102, 24);
            this.RbRFIDOnly.TabIndex = 2;
            this.RbRFIDOnly.TabStop = true;
            this.RbRFIDOnly.Text = "RFID Only";
            this.RbRFIDOnly.UnCheckedColor = System.Drawing.Color.Gray;
            this.RbRFIDOnly.UseVisualStyleBackColor = true;
            this.RbRFIDOnly.CheckedChanged += new System.EventHandler(this.RbRFIDOnly_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 54;
            this.label2.Text = "Prefix Hexa";
            // 
            // txtPrefixHex
            // 
            this.txtPrefixHex.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrefixHex.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtPrefixHex.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtPrefixHex.BorderRadius = 0;
            this.txtPrefixHex.BorderSize = 1;
            this.txtPrefixHex.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPrefixHex.Enabled = false;
            this.txtPrefixHex.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefixHex.ForeColor = System.Drawing.Color.Black;
            this.txtPrefixHex.Location = new System.Drawing.Point(200, 230);
            this.txtPrefixHex.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrefixHex.MaxLength = 4;
            this.txtPrefixHex.Multiline = false;
            this.txtPrefixHex.Name = "txtPrefixHex";
            this.txtPrefixHex.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPrefixHex.PasswordChar = false;
            this.txtPrefixHex.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPrefixHex.PlaceholderText = "";
            this.txtPrefixHex.Size = new System.Drawing.Size(160, 35);
            this.txtPrefixHex.TabIndex = 6;
            this.txtPrefixHex.Texts = "";
            this.txtPrefixHex.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "No of Tag";
            // 
            // txtNoofTag
            // 
            this.txtNoofTag.BackColor = System.Drawing.SystemColors.Window;
            this.txtNoofTag.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtNoofTag.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtNoofTag.BorderRadius = 0;
            this.txtNoofTag.BorderSize = 1;
            this.txtNoofTag.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNoofTag.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoofTag.ForeColor = System.Drawing.Color.Black;
            this.txtNoofTag.Location = new System.Drawing.Point(380, 230);
            this.txtNoofTag.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoofTag.MaxLength = 6;
            this.txtNoofTag.Multiline = false;
            this.txtNoofTag.Name = "txtNoofTag";
            this.txtNoofTag.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtNoofTag.PasswordChar = false;
            this.txtNoofTag.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNoofTag.PlaceholderText = "";
            this.txtNoofTag.Size = new System.Drawing.Size(153, 35);
            this.txtNoofTag.TabIndex = 7;
            this.txtNoofTag.Texts = "";
            this.txtNoofTag.UnderlinedStyle = false;
            this.txtNoofTag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofTag_KeyPress);
            // 
            // txtPrefix
            // 
            this.txtPrefix.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrefix.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtPrefix.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtPrefix.BorderRadius = 0;
            this.txtPrefix.BorderSize = 1;
            this.txtPrefix.CharacterCasings = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrefix.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrefix.ForeColor = System.Drawing.Color.Black;
            this.txtPrefix.Location = new System.Drawing.Point(31, 230);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrefix.MaxLength = 4;
            this.txtPrefix.Multiline = false;
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPrefix.PasswordChar = false;
            this.txtPrefix.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPrefix.PlaceholderText = "";
            this.txtPrefix.Size = new System.Drawing.Size(153, 35);
            this.txtPrefix.TabIndex = 5;
            this.txtPrefix.Texts = "";
            this.txtPrefix.UnderlinedStyle = false;
            this.txtPrefix._TextChanged += new System.EventHandler(this.txtPrefix__TextChanged);
            // 
            // panelUSB
            // 
            this.panelUSB.Controls.Add(this.label3);
            this.panelUSB.Controls.Add(this.cbUSBPorts);
            this.panelUSB.Controls.Add(this.btnRefresh);
            this.panelUSB.Location = new System.Drawing.Point(18, 80);
            this.panelUSB.Name = "panelUSB";
            this.panelUSB.Size = new System.Drawing.Size(663, 76);
            this.panelUSB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Printer or Port";
            // 
            // cbUSBPorts
            // 
            this.cbUSBPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUSBPorts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUSBPorts.FormattingEnabled = true;
            this.cbUSBPorts.Location = new System.Drawing.Point(13, 31);
            this.cbUSBPorts.Name = "cbUSBPorts";
            this.cbUSBPorts.Size = new System.Drawing.Size(293, 28);
            this.cbUSBPorts.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(312, 33);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "Prefix";
            // 
            // pnlDriver
            // 
            this.pnlDriver.Controls.Add(this.label4);
            this.pnlDriver.Controls.Add(this.cbDriver);
            this.pnlDriver.Controls.Add(this.lblDriverVersion);
            this.pnlDriver.Controls.Add(this.btnRefDriver);
            this.pnlDriver.Location = new System.Drawing.Point(18, 80);
            this.pnlDriver.Name = "pnlDriver";
            this.pnlDriver.Size = new System.Drawing.Size(663, 76);
            this.pnlDriver.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Printer or Port";
            // 
            // cbDriver
            // 
            this.cbDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDriver.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDriver.FormattingEnabled = true;
            this.cbDriver.Location = new System.Drawing.Point(13, 32);
            this.cbDriver.Name = "cbDriver";
            this.cbDriver.Size = new System.Drawing.Size(293, 28);
            this.cbDriver.TabIndex = 47;
            this.cbDriver.SelectedIndexChanged += new System.EventHandler(this.cbDriver_SelectedIndexChanged);
            // 
            // lblDriverVersion
            // 
            this.lblDriverVersion.AutoSize = true;
            this.lblDriverVersion.Location = new System.Drawing.Point(348, 39);
            this.lblDriverVersion.Name = "lblDriverVersion";
            this.lblDriverVersion.Size = new System.Drawing.Size(45, 13);
            this.lblDriverVersion.TabIndex = 8;
            this.lblDriverVersion.Text = "Version";
            // 
            // btnRefDriver
            // 
            this.btnRefDriver.Image = ((System.Drawing.Image)(resources.GetObject("btnRefDriver.Image")));
            this.btnRefDriver.Location = new System.Drawing.Point(312, 35);
            this.btnRefDriver.Name = "btnRefDriver";
            this.btnRefDriver.Size = new System.Drawing.Size(21, 21);
            this.btnRefDriver.TabIndex = 7;
            this.btnRefDriver.UseVisualStyleBackColor = true;
            this.btnRefDriver.Click += new System.EventHandler(this.btnRefDriver_Click);
            // 
            // panelSocket
            // 
            this.panelSocket.Controls.Add(this.label6);
            this.panelSocket.Controls.Add(this.label13);
            this.panelSocket.Controls.Add(this.txtPort);
            this.panelSocket.Controls.Add(this.label9);
            this.panelSocket.Controls.Add(this.txtIP);
            this.panelSocket.Controls.Add(this.cbTCPIP);
            this.panelSocket.Controls.Add(this.btn_TCPIPRefresh);
            this.panelSocket.Location = new System.Drawing.Point(18, 80);
            this.panelSocket.Name = "panelSocket";
            this.panelSocket.Size = new System.Drawing.Size(663, 76);
            this.panelSocket.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "Printer or Port";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(530, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 20);
            this.label13.TabIndex = 46;
            this.label13.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtPort.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtPort.BorderRadius = 0;
            this.txtPort.BorderSize = 1;
            this.txtPort.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.ForeColor = System.Drawing.Color.Black;
            this.txtPort.Location = new System.Drawing.Point(530, 29);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.MaxLength = 32767;
            this.txtPort.Multiline = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPort.PasswordChar = false;
            this.txtPort.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPort.PlaceholderText = "";
            this.txtPort.Size = new System.Drawing.Size(89, 35);
            this.txtPort.TabIndex = 45;
            this.txtPort.Texts = "9100";
            this.txtPort.UnderlinedStyle = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(342, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 20);
            this.label9.TabIndex = 43;
            this.label9.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtIP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtIP.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtIP.BorderRadius = 0;
            this.txtIP.BorderSize = 1;
            this.txtIP.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.ForeColor = System.Drawing.Color.Black;
            this.txtIP.Location = new System.Drawing.Point(342, 29);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.MaxLength = 32767;
            this.txtIP.Multiline = false;
            this.txtIP.Name = "txtIP";
            this.txtIP.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtIP.PasswordChar = false;
            this.txtIP.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtIP.PlaceholderText = "";
            this.txtIP.Size = new System.Drawing.Size(172, 35);
            this.txtIP.TabIndex = 44;
            this.txtIP.Texts = "";
            this.txtIP.UnderlinedStyle = false;
            // 
            // cbTCPIP
            // 
            this.cbTCPIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTCPIP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTCPIP.FormattingEnabled = true;
            this.cbTCPIP.Location = new System.Drawing.Point(13, 29);
            this.cbTCPIP.Name = "cbTCPIP";
            this.cbTCPIP.Size = new System.Drawing.Size(293, 28);
            this.cbTCPIP.TabIndex = 43;
            // 
            // btn_TCPIPRefresh
            // 
            this.btn_TCPIPRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_TCPIPRefresh.Image")));
            this.btn_TCPIPRefresh.Location = new System.Drawing.Point(312, 34);
            this.btn_TCPIPRefresh.Name = "btn_TCPIPRefresh";
            this.btn_TCPIPRefresh.Size = new System.Drawing.Size(21, 21);
            this.btn_TCPIPRefresh.TabIndex = 7;
            this.btn_TCPIPRefresh.UseVisualStyleBackColor = true;
            this.btn_TCPIPRefresh.Click += new System.EventHandler(this.btn_TCPIPRefresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Type ";
            // 
            // cbInterfaces
            // 
            this.cbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterfaces.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInterfaces.FormattingEnabled = true;
            this.cbInterfaces.Location = new System.Drawing.Point(31, 46);
            this.cbInterfaces.Name = "cbInterfaces";
            this.cbInterfaces.Size = new System.Drawing.Size(293, 28);
            this.cbInterfaces.TabIndex = 0;
            this.cbInterfaces.SelectedIndexChanged += new System.EventHandler(this.CmbUserRole_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnSave.BorderRadius = 3;
            this.btnSave.BorderSize = 2;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(396, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 40);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Print";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WriteRFID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "WriteRFID";
            this.Size = new System.Drawing.Size(865, 620);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelUSB.ResumeLayout(false);
            this.panelUSB.PerformLayout();
            this.pnlDriver.ResumeLayout(false);
            this.pnlDriver.PerformLayout();
            this.panelSocket.ResumeLayout(false);
            this.panelSocket.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RJButton btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelSocket;
        private System.Windows.Forms.Button btn_TCPIPRefresh;
        private System.Windows.Forms.ComboBox cbTCPIP;
        private System.Windows.Forms.Label label9;
        private CustomControls.RJControls.RJTextBox txtIP;
        private System.Windows.Forms.Label label13;
        private CustomControls.RJControls.RJTextBox txtPort;
        private System.Windows.Forms.Panel pnlDriver;
        private System.Windows.Forms.ComboBox cbDriver;
        private System.Windows.Forms.Label lblDriverVersion;
        private System.Windows.Forms.Button btnRefDriver;
        private System.Windows.Forms.Panel panelUSB;
        private System.Windows.Forms.ComboBox cbUSBPorts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbInterfaces;
        private CustomControls.RJControls.RJTextBox txtPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox txtNoofTag;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtPrefixHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJRadioButton RbRFIDBarcode;
        private CustomControls.RJControls.RJRadioButton RbRFIDText;
        private CustomControls.RJControls.RJRadioButton RbRFIDOnly;
        private System.Windows.Forms.Label label7;
        private CustomControls.RJControls.RJTextBox txtFreeText;
    }
}
