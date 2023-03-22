namespace NadaTech.View
{
    partial class Configuration
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbmPower = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCirfidPort = new CustomControls.RJControls.RJTextBox();
            this.txtCirfidIP = new CustomControls.RJControls.RJTextBox();
            this.txtSYSOTReaderPort = new CustomControls.RJControls.RJTextBox();
            this.txtSYSOTReaderIP = new CustomControls.RJControls.RJTextBox();
            this.txtPrefixHex = new CustomControls.RJControls.RJTextBox();
            this.btnSave = new CustomControls.RJControls.RJButton();
            this.txtTagPrefix = new CustomControls.RJControls.RJTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbmPower);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCirfidPort);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtCirfidIP);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSYSOTReaderPort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSYSOTReaderIP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPrefixHex);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtTagPrefix);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 620);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 20);
            this.label6.TabIndex = 66;
            this.label6.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 64;
            this.label7.Text = "IP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(27, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(286, 19);
            this.label8.TabIndex = 63;
            this.label8.Text = "CIRFID RF946 FIXED READER IP AND PORT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 19);
            this.label1.TabIndex = 58;
            this.label1.Text = "SYSIOT UHF FIXED READER IP AND PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Prefix Hexa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tag Prefix";
            // 
            // cbmPower
            // 
            this.cbmPower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmPower.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmPower.FormattingEnabled = true;
            this.cbmPower.Items.AddRange(new object[] {
            "33",
            "32",
            "31",
            "30",
            "29",
            "28",
            "27",
            "26",
            "25",
            "24",
            "23",
            "22",
            "21",
            "20",
            "19",
            "18",
            "17",
            "16",
            "15"});
            this.cbmPower.Location = new System.Drawing.Point(27, 306);
            this.cbmPower.Name = "cbmPower";
            this.cbmPower.Size = new System.Drawing.Size(229, 28);
            this.cbmPower.TabIndex = 2002;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(27, 284);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 20);
            this.label13.TabIndex = 2003;
            this.label13.Text = "Antenna Power(dBm)";
            // 
            // txtCirfidPort
            // 
            this.txtCirfidPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtCirfidPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtCirfidPort.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtCirfidPort.BorderRadius = 0;
            this.txtCirfidPort.BorderSize = 1;
            this.txtCirfidPort.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCirfidPort.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCirfidPort.ForeColor = System.Drawing.Color.Black;
            this.txtCirfidPort.Location = new System.Drawing.Point(264, 240);
            this.txtCirfidPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtCirfidPort.MaxLength = 100;
            this.txtCirfidPort.Multiline = false;
            this.txtCirfidPort.Name = "txtCirfidPort";
            this.txtCirfidPort.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCirfidPort.PasswordChar = false;
            this.txtCirfidPort.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCirfidPort.PlaceholderText = "";
            this.txtCirfidPort.Size = new System.Drawing.Size(126, 35);
            this.txtCirfidPort.TabIndex = 65;
            this.txtCirfidPort.Texts = "";
            this.txtCirfidPort.UnderlinedStyle = false;
            this.txtCirfidPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCirfidPort_KeyPress);
            // 
            // txtCirfidIP
            // 
            this.txtCirfidIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtCirfidIP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtCirfidIP.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtCirfidIP.BorderRadius = 0;
            this.txtCirfidIP.BorderSize = 1;
            this.txtCirfidIP.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCirfidIP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCirfidIP.ForeColor = System.Drawing.Color.Black;
            this.txtCirfidIP.Location = new System.Drawing.Point(27, 240);
            this.txtCirfidIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtCirfidIP.MaxLength = 100;
            this.txtCirfidIP.Multiline = false;
            this.txtCirfidIP.Name = "txtCirfidIP";
            this.txtCirfidIP.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCirfidIP.PasswordChar = false;
            this.txtCirfidIP.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCirfidIP.PlaceholderText = "";
            this.txtCirfidIP.Size = new System.Drawing.Size(229, 35);
            this.txtCirfidIP.TabIndex = 62;
            this.txtCirfidIP.Texts = "";
            this.txtCirfidIP.UnderlinedStyle = false;
            this.txtCirfidIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSYSOTReaderIP_KeyPress);
            // 
            // txtSYSOTReaderPort
            // 
            this.txtSYSOTReaderPort.BackColor = System.Drawing.SystemColors.Window;
            this.txtSYSOTReaderPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSYSOTReaderPort.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSYSOTReaderPort.BorderRadius = 0;
            this.txtSYSOTReaderPort.BorderSize = 1;
            this.txtSYSOTReaderPort.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSYSOTReaderPort.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSYSOTReaderPort.ForeColor = System.Drawing.Color.Black;
            this.txtSYSOTReaderPort.Location = new System.Drawing.Point(264, 141);
            this.txtSYSOTReaderPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtSYSOTReaderPort.MaxLength = 100;
            this.txtSYSOTReaderPort.Multiline = false;
            this.txtSYSOTReaderPort.Name = "txtSYSOTReaderPort";
            this.txtSYSOTReaderPort.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSYSOTReaderPort.PasswordChar = false;
            this.txtSYSOTReaderPort.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSYSOTReaderPort.PlaceholderText = "";
            this.txtSYSOTReaderPort.Size = new System.Drawing.Size(126, 35);
            this.txtSYSOTReaderPort.TabIndex = 60;
            this.txtSYSOTReaderPort.Texts = "";
            this.txtSYSOTReaderPort.UnderlinedStyle = false;
            // 
            // txtSYSOTReaderIP
            // 
            this.txtSYSOTReaderIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtSYSOTReaderIP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtSYSOTReaderIP.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtSYSOTReaderIP.BorderRadius = 0;
            this.txtSYSOTReaderIP.BorderSize = 1;
            this.txtSYSOTReaderIP.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSYSOTReaderIP.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSYSOTReaderIP.ForeColor = System.Drawing.Color.Black;
            this.txtSYSOTReaderIP.Location = new System.Drawing.Point(27, 141);
            this.txtSYSOTReaderIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtSYSOTReaderIP.MaxLength = 100;
            this.txtSYSOTReaderIP.Multiline = false;
            this.txtSYSOTReaderIP.Name = "txtSYSOTReaderIP";
            this.txtSYSOTReaderIP.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSYSOTReaderIP.PasswordChar = false;
            this.txtSYSOTReaderIP.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSYSOTReaderIP.PlaceholderText = "";
            this.txtSYSOTReaderIP.Size = new System.Drawing.Size(229, 35);
            this.txtSYSOTReaderIP.TabIndex = 57;
            this.txtSYSOTReaderIP.Texts = "";
            this.txtSYSOTReaderIP.UnderlinedStyle = false;
            this.txtSYSOTReaderIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSYSOTReaderIP_KeyPress);
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
            this.txtPrefixHex.Location = new System.Drawing.Point(190, 44);
            this.txtPrefixHex.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrefixHex.MaxLength = 4;
            this.txtPrefixHex.Multiline = false;
            this.txtPrefixHex.Name = "txtPrefixHex";
            this.txtPrefixHex.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPrefixHex.PasswordChar = false;
            this.txtPrefixHex.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPrefixHex.PlaceholderText = "";
            this.txtPrefixHex.Size = new System.Drawing.Size(200, 35);
            this.txtPrefixHex.TabIndex = 55;
            this.txtPrefixHex.Texts = "";
            this.txtPrefixHex.UnderlinedStyle = false;
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
            this.btnSave.Location = new System.Drawing.Point(253, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTagPrefix
            // 
            this.txtTagPrefix.BackColor = System.Drawing.SystemColors.Window;
            this.txtTagPrefix.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtTagPrefix.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtTagPrefix.BorderRadius = 0;
            this.txtTagPrefix.BorderSize = 1;
            this.txtTagPrefix.CharacterCasings = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTagPrefix.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagPrefix.ForeColor = System.Drawing.Color.Black;
            this.txtTagPrefix.Location = new System.Drawing.Point(31, 44);
            this.txtTagPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.txtTagPrefix.MaxLength = 4;
            this.txtTagPrefix.Multiline = false;
            this.txtTagPrefix.Name = "txtTagPrefix";
            this.txtTagPrefix.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtTagPrefix.PasswordChar = false;
            this.txtTagPrefix.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTagPrefix.PlaceholderText = "";
            this.txtTagPrefix.Size = new System.Drawing.Size(152, 35);
            this.txtTagPrefix.TabIndex = 4;
            this.txtTagPrefix.Texts = "";
            this.txtTagPrefix.UnderlinedStyle = false;
            this.txtTagPrefix._TextChanged += new System.EventHandler(this.txtTagPrefix__TextChanged);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "Configuration";
            this.Size = new System.Drawing.Size(865, 620);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RJTextBox txtTagPrefix;
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.RJButton btnSave;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtPrefixHex;
        private CustomControls.RJControls.RJTextBox txtSYSOTReaderIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private CustomControls.RJControls.RJTextBox txtSYSOTReaderPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CustomControls.RJControls.RJTextBox txtCirfidPort;
        private System.Windows.Forms.Label label7;
        private CustomControls.RJControls.RJTextBox txtCirfidIP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbmPower;
        private System.Windows.Forms.Label label13;
    }
}
