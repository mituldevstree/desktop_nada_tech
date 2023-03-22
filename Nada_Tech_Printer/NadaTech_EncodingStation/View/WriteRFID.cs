using NadaTech_EncodingStation;
using SATOPrinterAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech_EncodingStation.View
{
    public partial class WriteRFID : UserControl
    {
        MasterForm _Mainform;
        Printer SATOPrinter = null;
        Driver SATODriver = null;
        public WriteRFID(object _mainform)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            SATOPrinter = new Printer();
            SATODriver = new Driver();
            FillType();
            CmbUserRole_SelectedIndexChanged(cbInterfaces, null);
            RedcheckType();
        }
        void FillType()
        {
            List<TypeModel> _listofType = new List<TypeModel>();
            _listofType.Add(new TypeModel { Value = 3, Text = "USB Port" });
            _listofType.Add(new TypeModel { Value = 1, Text = "Serial COM" });
            _listofType.Add(new TypeModel { Value = 0, Text = "TCP / IP Socket" });
            _listofType.Add(new TypeModel { Value = 2, Text = "Parallel LPT" });
            _listofType.Add(new TypeModel { Value = 4, Text = "Driver" });
            cbInterfaces.DataSource = _listofType;
            cbInterfaces.DisplayMember = "Text";
            cbInterfaces.ValueMember = "Value";
            cbInterfaces.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            RefreshCOM_USBList();
            btnRefresh.Enabled = true;
        }

        private void CmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbInterfaces.SelectedValue)
            {
                case 0:
                    panelSocket.Show();
                    panelUSB.Hide();
                    pnlDriver.Hide();
                    break;
                case 1:
                    RefreshCOM_USBList();
                    panelUSB.Show();
                    panelSocket.Hide();
                    pnlDriver.Hide();
                    break;
                case 2:
                    RefreshCOM_USBList();
                    panelUSB.Show();
                    panelSocket.Hide();
                    pnlDriver.Hide();
                    break;
                case 3:
                    RefreshCOM_USBList();
                    panelUSB.Show();
                    panelSocket.Hide();
                    pnlDriver.Hide();
                    break;
                case 4:
                    panelUSB.Hide();
                    panelSocket.Hide();
                    pnlDriver.Show();
                    break;
            }

            //if (chkPermanent.Checked)
            //{
            //    SATOPrinter.Disconnect();
            //}
        }
        private void RefreshCOM_USBList()
        {
            cbUSBPorts.DataSource = null;
            cbUSBPorts.Items.Clear();
            Dictionary<string, string> cbObj = new Dictionary<string, string>();
            switch (cbInterfaces.SelectedValue)
            {
                case 1:
                    foreach (string comport in SATOPrinter.GetCOMList())
                    {
                        cbObj.Add(comport, comport);
                    }
                    break;
                case 2:
                    foreach (string lptport in SATOPrinter.GetLPTList())
                    {
                        cbObj.Add(lptport, lptport);
                    }
                    break;
                case 3:

                    foreach (Printer.USBInfo usbPorts in SATOPrinter.GetUSBList())
                    {
                        cbObj.Add(usbPorts.PortID, usbPorts.Name);
                    }
                    break;
            }

            if (cbObj.Count > 0)
            {
                cbUSBPorts.DataSource = new BindingSource(cbObj, null);
                cbUSBPorts.DisplayMember = "Value";
                cbUSBPorts.ValueMember = "Key";
                cbUSBPorts.SelectedIndex = 0;
            }
        }

        private void RefreshTCPIPList()
        {
            cbTCPIP.DisplayMember = "Name";
            cbTCPIP.ValueMember = "IPAddress";
            cbTCPIP.DataSource = new BindingSource(SATOPrinter.GetTCPIPList(), null);
        }

        private void Refresh_DriverList()
        {
            cbDriver.DisplayMember = "DriverName";
            cbDriver.ValueMember = "DriverName";
            cbDriver.DataSource = new BindingSource(SATODriver.GetDriverList(), null);
        }

        private void SetInterface()
        {
            try
            {
                int timeOut = int.Parse("2500");
                if (timeOut <= 1000)
                    timeOut = 1000;
                SATOPrinter.Timeout = timeOut;

                switch (cbInterfaces.SelectedValue)
                {
                    case 0: //Socket
                        SATOPrinter.Interface = Printer.InterfaceType.TCPIP;
                        SATOPrinter.TCPIPAddress = txtIP.Text;
                        SATOPrinter.TCPIPPort = txtPort.Text;
                        break;
                    case 1: //COM
                        SATOPrinter.Interface = Printer.InterfaceType.COM; ;
                        if (cbUSBPorts.SelectedItem != null)
                            SATOPrinter.COMPort = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                        break;
                    case 2: //LPT
                        SATOPrinter.Interface = Printer.InterfaceType.LPT;
                        if (cbUSBPorts.SelectedItem != null)
                            SATOPrinter.LPTPort = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                        break;
                    case 3: //USB
                        SATOPrinter.Interface = Printer.InterfaceType.USB;
                        if (cbUSBPorts.SelectedItem != null)
                            SATOPrinter.USBPortID = ((KeyValuePair<string, string>)cbUSBPorts.SelectedItem).Key;
                        break;
                    default:
                        MessageBox.Show("Error : Invalid Interface Selection!");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string rtxtRecv = "";
        private void AppendRecvText(byte[] data, bool empty)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<byte[], bool>(AppendRecvText), new object[] { data, empty });
                return;
            }
            if (empty)
                rtxtRecv = "";


            string smsg = ControlCharConvert(Utils.ByteArrayToString(data));
            //if (chkPermanent.Checked)
            //    rtxtRecv.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + Environment.NewLine);

            //rtxtRecv.AppendText(smsg + Environment.NewLine);
            //txtTotalRecvBytes.Text = data.Length.ToString();
        }

        private string ControlCharConvert(string data)
        {
            Dictionary<char, string> chrList = ControlCharList().ToDictionary(x => x.Value, x => x.Key);
            foreach (char key in chrList.Keys)
            {
                data = data.Replace(key.ToString(), chrList[key]);
            }
            return data;
        }

        private string ControlCharReplace(string data)
        {
            Dictionary<string, char> chrList = ControlCharList();
            foreach (string key in chrList.Keys)
            {
                data = data.Replace(key, chrList[key].ToString());
            }
            return data;
        }

        private Dictionary<string, char> ControlCharList()
        {
            Dictionary<string, char> ctr = new Dictionary<string, char>();
            ctr.Add("[NUL]", '\u0000');
            ctr.Add("[SOH]", '\u0001');
            ctr.Add("[STX]", '\u0002');
            ctr.Add("[ETX]", '\u0003');
            ctr.Add("[EOT]", '\u0004');
            ctr.Add("[ENQ]", '\u0005');
            ctr.Add("[ACK]", '\u0006');
            ctr.Add("[BEL]", '\u0007');
            ctr.Add("[BS]", '\u0008');
            ctr.Add("[HT]", '\u0009');
            ctr.Add("[LF]", '\u000A');
            ctr.Add("[VT]", '\u000B');
            ctr.Add("[FF]", '\u000C');
            ctr.Add("[CR]", '\u000D');
            ctr.Add("[SO]", '\u000E');
            ctr.Add("[SI]", '\u000F');
            ctr.Add("[DLE]", '\u0010');
            ctr.Add("[DC1]", '\u0011');
            ctr.Add("[DC2]", '\u0012');
            ctr.Add("[DC3]", '\u0013');
            ctr.Add("[DC4]", '\u0014');
            ctr.Add("[NAK]", '\u0015');
            ctr.Add("[SYN]", '\u0016');
            ctr.Add("[ETB]", '\u0017');
            ctr.Add("[CAN]", '\u0018');
            ctr.Add("[EM]", '\u0019');
            ctr.Add("[SUB]", '\u001A');
            ctr.Add("[ESC]", '\u001B');
            ctr.Add("[FS]", '\u001C');
            ctr.Add("[GS]", '\u001D');
            ctr.Add("[RS]", '\u001E');
            ctr.Add("[US]", '\u001F');
            ctr.Add("[DEL]", '\u007F');
            return ctr;
        }

        private void cbTCPIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTCPIP.SelectedValue != null)
            {
                txtIP.Text = cbTCPIP.SelectedValue.ToString();
            }
        }
        private bool MouseWait
        {
            set
            {
                if (value)
                    Cursor = Cursors.WaitCursor;
                else
                    Cursor = Cursors.Default;
            }
        }
        private void cbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            MouseWait = true;
            lblDriverVersion.Text = SATODriver.GetVersion(cbDriver.Text);
            MouseWait = false;
        }



        private void btnRefDriver_Click(object sender, EventArgs e)
        {
            btnRefDriver.Enabled = false;
            Refresh_DriverList();
            btnRefDriver.Enabled = true;
        }

        private void btn_TCPIPRefresh_Click(object sender, EventArgs e)
        {
            btn_TCPIPRefresh.Enabled = false;
            RefreshTCPIPList();
            btn_TCPIPRefresh.Enabled = true;
        }
        public static string ConvertHex(string hexString)
        {
            string ascii = string.Empty;
            try
            {
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    string hs = string.Empty;
                    hs = hexString.Substring(i, 2);
                    ulong decval = Convert.ToUInt64(hs, 16);
                    long deccc = Convert.ToInt64(hs, 16);
                    char character = Convert.ToChar(deccc);
                    ascii += character;
                }
            }
            catch (Exception ex)
            {

            }
            return ascii;
        }
        public string ASCIItoHex(string Value)
        {
            StringBuilder sb = new StringBuilder();

            byte[] inputByte = Encoding.UTF8.GetBytes(Value);

            foreach (byte b in inputByte)
            {
                sb.Append(string.Format("{0:x2}", b));
            }
            return sb.ToString().ToUpper();
        }


        private bool Cansave()
        {
            if (cbInterfaces.SelectedValue.ToString() == "3" && cbUSBPorts.SelectedValue == null)
            {
                RJMessageBox.Show("USB Printer not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cbInterfaces.SelectedValue.ToString() == "2" && cbUSBPorts.SelectedValue == null)
            {
                RJMessageBox.Show("Serial COM Printer not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cbInterfaces.SelectedValue.ToString() == "1" && cbUSBPorts.SelectedValue == null)
            {
                RJMessageBox.Show("Parallel LPT Printer not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cbInterfaces.SelectedValue.ToString() == "4" && cbDriver.SelectedValue == null)
            {
                RJMessageBox.Show("Driver LPT Printer not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cbInterfaces.SelectedValue.ToString() == "0" && cbTCPIP.SelectedValue == null)
            {
                RJMessageBox.Show("TCP / IP Socket  Printer not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrefix.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Prefix.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPrefix.Texts.Trim().Length < 4)
            {
                RJMessageBox.Show("minimum 4 characters in Prefix.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtNoofTag.Texts.Trim()))
            {
                RJMessageBox.Show("Enter No of Tag.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        string PrinterStatusCheck()
        {
            string errorMsg = "";
            try
            {
                SetInterface();
                Printer.Status status = SATOPrinter.GetPrinterStatus();
                if (status != null)
                {
                    if (status.IsOnline == false)
                    {
                        errorMsg = "Printer State : " + status.State + " \n\rDescription : " + status.Description;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMsg = Common.GetString(ex);
            }
            return errorMsg;

        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGH456IJKLMNOPklmnopqrYZ01789abcdef23ghijstQRSTUVWXuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Cansave())
            {
                string PrinterStatus = PrinterStatusCheck();
                if (!string.IsNullOrEmpty(PrinterStatus))
                {
                    RJMessageBox.Show(PrinterStatus, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MouseWait = true;
                try
                {
                    if (cbInterfaces.SelectedValue.ToString() == "4")
                    {
                        if (cbDriver.SelectedValue != null)
                        {
                            int Nooftag = Convert.ToInt32(txtNoofTag.Texts);
                            for (int i = 1; i <= Nooftag; i++)
                            {
                                string H2 = ASCIItoHex(txtPrefix.Texts.Trim());
                                string RndNo = RandomString(8);
                                string trag = H2 + ASCIItoHex(RndNo.ToUpper());

                                //string RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F7[ESC]VB0,,,,,,[ESC]A1V00200H0599[ESC]PM0[ESC]PO3+00[ESC]PH1[ESC]IG1[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:1;[ESC]%0[ESC]H0120[ESC]V00038[ESC]D304079123456789012[ESC]XM4554567890128[ESC]Q1[ESC]Z[ETX]";
                                string RFID1 = "";
                                if (RbRFIDOnly.Checked)
                                {
                                    //RFID Only
                                    RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F5[ESC]A1V00136H0583[ESC]Z[EXT][ESC]##[EXT][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:1;[ESC]Q1[ESC]Z[EXT][ESC]";
                                }
                                else if (RbRFIDText.Checked)
                                {
                                    //RFID With Text
                                    //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0080[ESC]V00048[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,031,034," + trag + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT] [ESC]##[ENO]";
                                    //Changes 25-08-2022
                                    //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0107[ESC]V00053[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,027,028," + trag + "[ESC]%0[ESC]H0201[ESC]V00014[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,027,028,NADA TECH[ESC]Q1[ESC]Z[ETX][ESC]##[EOT][ESC]##[ENQ]";
                                    //Changes 29-08-2022
                                    RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH L[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0119[ESC]V00073[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,021,023," + trag + "[ESC]%0[ESC]H0201[ESC]V00013[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,021,023,NADA TECH[ESC]%0[ESC]H0136[ESC]V00047[ESC]P02[ESC]RH0,SATOSERIF.ttf,1,020,020," + txtFreeText.Texts.Trim() + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT]  [ESC]##[ENQ] ";
                                }
                                else if (RbRFIDBarcode.Checked)
                                {
                                    //RFID With Barcode
                                    //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0064[ESC]V00028[ESC]BG02072>H4E4>C14441474255334>DB4F>C5858[ESC]%0[ESC]H0192[ESC]V00102[ESC]P02[ESC]RDB@0,019,019," + trag + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT][ESC]##[ENO]";
                                    //Changes 25-08-2022
                                    //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00120H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0056[ESC]V00043[ESC]BG02042>H4E4>C14441474255334>DB4F>C5858[ESC]%0[ESC]H0184[ESC]V00087[ESC]P02[ESC]RDB@0,019,019," + trag + "[ESC]%0[ESC]H0225[ESC]V00009[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,021,023,NADA TECH[ESC]Q1[ESC]Z[ETX][ESC]##[EOT][ESC]##[ENQ]";
                                    //Changes 29-08-2022
                                    RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00120H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0049[ESC]V00055[ESC]BG02032>H4E4>C14441474255334>DB4F>C5858[ESC]%0[ESC]H0177[ESC]V00089[ESC]P02[ESC]RDB@0,019,019," + trag + "[ESC]%0[ESC]H0225[ESC]V00009[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,020,020,NADA TECH[ESC]%0[ESC]H0189[ESC]V00033[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,020,020," + txtFreeText.Texts.Trim() + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT]  [ESC]##[ENQ]  ";
                                }
                                byte[] cmddata12 = Utils.StringToByteArray(ControlCharReplace(RFID1.ToString()));
                                SATODriver.SendRawData(cbDriver.SelectedValue.ToString(), cmddata12);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select SATO printer driver");
                        }
                    }
                    else
                    {
                        SetInterface();
                        int Nooftag = Convert.ToInt32(txtNoofTag.Texts);
                        for (int i = 1; i <= Nooftag; i++)
                        {
                            string H2 = ASCIItoHex(txtPrefix.Texts.Trim());
                            string RndNo = RandomString(8);
                            string trag = H2 + ASCIItoHex(RndNo.ToUpper());

                            //string RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F7[ESC]VB0,,,,,,[ESC]A1V00200H0599[ESC]PM0[ESC]PO3+00[ESC]PH1[ESC]IG1[ESC]Z[ETX][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:1;[ESC]%0[ESC]H0120[ESC]V00038[ESC]D304079123456789012[ESC]XM4554567890128[ESC]Q1[ESC]Z[ETX]";
                            string RFID1 = "";
                            if (RbRFIDOnly.Checked)
                            {
                                //RFID Only
                                RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]WKRFID Only[ESC]IP0e:h,epc:" + trag + ",fsw:1;[ESC]Q1[ESC]Z[ETX][ESC]##[EOT]  [ESC]##[ENO] ";
                            }
                            else if (RbRFIDText.Checked)
                            {
                                //RFID With Text
                                //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0080[ESC]V00048[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,031,034," + trag + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT] [ESC]##[ENO]";
                                //Changes 25-08-2022
                                //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0107[ESC]V00053[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,027,028," + trag + "[ESC]%0[ESC]H0201[ESC]V00014[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,027,028,NADA TECH[ESC]Q1[ESC]Z[ETX][ESC]##[EOT][ESC]##[ENQ]";
                                //Changes 29-08-2022
                                RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH L[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0119[ESC]V00073[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,021,023," + trag + "[ESC]%0[ESC]H0201[ESC]V00013[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,021,023,NADA TECH[ESC]%0[ESC]H0136[ESC]V00047[ESC]P02[ESC]RH0,SATOSERIF.ttf,1,020,020," + txtFreeText.Texts.Trim() + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT]  [ESC]##[ENQ] ";
                            }
                            else if (RbRFIDBarcode.Checked)
                            {
                                //RFID With Barcode
                                //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS4[ESC]#F5[ESC]A1V00136H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0064[ESC]V00028[ESC]BG02072>H4E4>C14441474255334>DB4F>C5858[ESC]%0[ESC]H0192[ESC]V00102[ESC]P02[ESC]RDB@0,019,019," + trag + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT][ESC]##[ENO]";
                                //Changes 25-08-2022
                                //RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00120H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0056[ESC]V00043[ESC]BG02042>H4E4>C14441474255334>DB4F>C5858[ESC]%0[ESC]H0184[ESC]V00087[ESC]P02[ESC]RDB@0,019,019," + trag + "[ESC]%0[ESC]H0225[ESC]V00009[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,021,023,NADA TECH[ESC]Q1[ESC]Z[ETX][ESC]##[EOT][ESC]##[ENQ]";
                                //Changes 29-08-2022
                                RFID1 = "[STX][ESC]A[ESC]A3V+00000H+0000[ESC]CS6[ESC]#F5[ESC]A1V00120H0583[ESC]Z[ETX][ESC]##[ETX][FS][SOH][STX][ESC]A[ESC]PS[ESC]NADA TECH[ESC]IP0e:h,epc:" + trag + ",fsw:0;[ESC]%0[ESC]H0049[ESC]V00055[ESC]BG02032>H4E4>C14441474255334>DB4F>C5858[ESC]%0[ESC]H0177[ESC]V00089[ESC]P02[ESC]RDB@0,019,019," + trag + "[ESC]%0[ESC]H0225[ESC]V00009[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,020,020,NADA TECH[ESC]%0[ESC]H0189[ESC]V00033[ESC]P02[ESC]RH0,SATOSERIF.ttf,0,020,020," + txtFreeText.Texts.Trim() + "[ESC]Q1[ESC]Z[ETX][ESC]##[EOT]  [ESC]##[ENQ]  ";

                            }


                            byte[] cmddata12 = Utils.StringToByteArray(ControlCharReplace(RFID1.ToString()));
                            SATOPrinter.Send(cmddata12);
                            Printer.Status status = SATOPrinter.GetPrinterStatus();

                        }
                        var msgresult = RJMessageBox.Show("Tag Encode successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    string ErrorMsg = Common.GetString(ex);
                    RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MouseWait = false;
            }
        }

        private void txtNoofTag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}

        }

        public void DisconnectPrinter()
        {
            SATOPrinter.Disconnect();
        }

        private void txtPrefix__TextChanged(object sender, EventArgs e)
        {
            txtPrefixHex.Texts = Common.ConvertASCIItoHex(txtPrefix.Texts);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        void RedcheckType()
        {
            if (RbRFIDOnly.Checked)
            {
                txtFreeText.Enabled = false;
            }
            else
            {
                txtFreeText.Enabled = true;
            }
        }
        private void RbRFIDOnly_CheckedChanged(object sender, EventArgs e)
        {
            RedcheckType();
        }
    }
}
