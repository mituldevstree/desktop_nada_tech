namespace NadaTech_EncodingStation.View
{
    partial class ReaderToWriteRFID
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
            this.btnRead = new CustomControls.RJControls.RJButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReadtagdata = new CustomControls.RJControls.RJTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrefixHex = new CustomControls.RJControls.RJTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWriteData = new CustomControls.RJControls.RJTextBox();
            this.txtPrefix = new CustomControls.RJControls.RJTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbReader = new System.Windows.Forms.ComboBox();
            this.btnSave = new CustomControls.RJControls.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRead);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtReadtagdata);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPrefixHex);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtWriteData);
            this.panel1.Controls.Add(this.txtPrefix);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.CmbReader);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 620);
            this.panel1.TabIndex = 0;
            // 
            // btnRead
            // 
            this.btnRead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnRead.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnRead.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.btnRead.BorderRadius = 3;
            this.btnRead.BorderSize = 2;
            this.btnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRead.FlatAppearance.BorderSize = 0;
            this.btnRead.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnRead.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(143)))), ((int)(((byte)(250)))));
            this.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRead.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRead.ForeColor = System.Drawing.Color.White;
            this.btnRead.Location = new System.Drawing.Point(31, 157);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(137, 40);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "&Read Tag";
            this.btnRead.TextColor = System.Drawing.Color.White;
            this.btnRead.UseVisualStyleBackColor = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Read Tag Data";
            // 
            // txtReadtagdata
            // 
            this.txtReadtagdata.BackColor = System.Drawing.SystemColors.Window;
            this.txtReadtagdata.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtReadtagdata.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtReadtagdata.BorderRadius = 0;
            this.txtReadtagdata.BorderSize = 1;
            this.txtReadtagdata.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtReadtagdata.Enabled = false;
            this.txtReadtagdata.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReadtagdata.ForeColor = System.Drawing.Color.Black;
            this.txtReadtagdata.Location = new System.Drawing.Point(31, 110);
            this.txtReadtagdata.Margin = new System.Windows.Forms.Padding(4);
            this.txtReadtagdata.MaxLength = 6;
            this.txtReadtagdata.Multiline = false;
            this.txtReadtagdata.Name = "txtReadtagdata";
            this.txtReadtagdata.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtReadtagdata.PasswordChar = false;
            this.txtReadtagdata.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReadtagdata.PlaceholderText = "";
            this.txtReadtagdata.Size = new System.Drawing.Size(377, 35);
            this.txtReadtagdata.TabIndex = 1;
            this.txtReadtagdata.Texts = "";
            this.txtReadtagdata.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 207);
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
            this.txtPrefixHex.Location = new System.Drawing.Point(236, 230);
            this.txtPrefixHex.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrefixHex.MaxLength = 4;
            this.txtPrefixHex.Multiline = false;
            this.txtPrefixHex.Name = "txtPrefixHex";
            this.txtPrefixHex.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPrefixHex.PasswordChar = false;
            this.txtPrefixHex.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPrefixHex.PlaceholderText = "";
            this.txtPrefixHex.Size = new System.Drawing.Size(172, 35);
            this.txtPrefixHex.TabIndex = 4;
            this.txtPrefixHex.Texts = "";
            this.txtPrefixHex.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Write Tag Data";
            // 
            // txtWriteData
            // 
            this.txtWriteData.BackColor = System.Drawing.SystemColors.Window;
            this.txtWriteData.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(96)))), ((int)(((byte)(168)))));
            this.txtWriteData.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(244)))));
            this.txtWriteData.BorderRadius = 0;
            this.txtWriteData.BorderSize = 1;
            this.txtWriteData.CharacterCasings = System.Windows.Forms.CharacterCasing.Normal;
            this.txtWriteData.Enabled = false;
            this.txtWriteData.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWriteData.ForeColor = System.Drawing.Color.Black;
            this.txtWriteData.Location = new System.Drawing.Point(31, 353);
            this.txtWriteData.Margin = new System.Windows.Forms.Padding(4);
            this.txtWriteData.MaxLength = 6;
            this.txtWriteData.Multiline = false;
            this.txtWriteData.Name = "txtWriteData";
            this.txtWriteData.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtWriteData.PasswordChar = false;
            this.txtWriteData.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtWriteData.PlaceholderText = "";
            this.txtWriteData.Size = new System.Drawing.Size(377, 35);
            this.txtWriteData.TabIndex = 6;
            this.txtWriteData.Texts = "";
            this.txtWriteData.UnderlinedStyle = false;
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
            this.txtPrefix.Size = new System.Drawing.Size(190, 35);
            this.txtPrefix.TabIndex = 3;
            this.txtPrefix.Texts = "";
            this.txtPrefix.UnderlinedStyle = false;
            this.txtPrefix._TextChanged += new System.EventHandler(this.txtPrefix__TextChanged);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "Reader";
            // 
            // CmbReader
            // 
            this.CmbReader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReader.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbReader.FormattingEnabled = true;
            this.CmbReader.Location = new System.Drawing.Point(31, 46);
            this.CmbReader.Name = "CmbReader";
            this.CmbReader.Size = new System.Drawing.Size(377, 28);
            this.CmbReader.TabIndex = 0;
            this.CmbReader.SelectedIndexChanged += new System.EventHandler(this.CmbReader_SelectedIndexChanged);
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
            this.btnSave.Location = new System.Drawing.Point(31, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 40);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Write Tag";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ReaderToWriteRFID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Name = "ReaderToWriteRFID";
            this.Size = new System.Drawing.Size(865, 620);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomControls.RJControls.RJButton btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CmbReader;
        private CustomControls.RJControls.RJTextBox txtPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.RJTextBox txtWriteData;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJTextBox txtPrefixHex;
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.RJTextBox txtReadtagdata;
        private CustomControls.RJControls.RJButton btnRead;
    }
}
