using NadaTech_EncodingStation;
using RFID_Reader;
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
using UHFAPP;

namespace NadaTech_EncodingStation.View
{
    public partial class ReaderToWriteRFID : UserControl
    {
        MasterForm _Mainform;
        public IUHF uhf = null;
        List<TypeModel> _listofType = new List<TypeModel>();

        public ReaderToWriteRFID(object _mainform)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            ChangeUHFAPI(true);
            FillReaderList();
        }
        void FillReaderList()
        {
            if (CheckDevice(1) == true)
            {
                _listofType.Add(new TypeModel { Value = 1, Text = "CHAINWAY R3 Desktop READER" });
            }

            CmbReader.DataSource = _listofType;
            CmbReader.DisplayMember = "Text";
            CmbReader.ValueMember = "Value";
            if (_listofType.Count() > 0)
            {
                CmbReader.SelectedValue = 1;
                ConnectReader();
            }
        }
        public void ChangeUHFAPI(bool isUSB)
        {
            if (isUSB)
            {
                uhf = UHFAPIOfUsb.getInstance();
            }
            else
            {
                uhf = UHFAPI.getInstance();
            }
        }
        bool CheckDevice(int Type)
        {
            bool IsConnect = false;
            if (Type == 1)
            {
                //CHAINWAY R3 Desktop READER
                bool IsRun = uhf.Open();
                if (IsRun)
                {
                    IsConnect = true;
                    uhf.Close();
                }
            }
            return IsConnect;
        }
        bool isRuning = false;

        void ConnectReader()
        {
            if (CmbReader.SelectedValue != null)
            {
                if (CmbReader.SelectedValue.ToString() == "1")
                {
                    bool IsRun = uhf.Open();
                    if (IsRun)
                    {
                        isRuning = true;
                    }
                }
            }
        }
        public void DisconnectReader()
        {
            if (CmbReader.SelectedValue != null)
            {
                if (CmbReader.SelectedValue.ToString() == "1")
                {
                    bool IsRun = uhf.Close();
                    if (IsRun)
                    {
                        isRuning = false;
                    }
                }
            }
        }
        private void CmbReader_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectReader();
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
            if (CmbReader.SelectedIndex < 0)
            {
                RJMessageBox.Show("Reader not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPrefix.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Prefix.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtPrefix.Texts.Trim().Length < 4)
            {
                RJMessageBox.Show("Minimum 4 characters in Prefix.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGH456IJKLMNOPklmnopqrYZ01789abcdef23ghijstQRSTUVWXuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Cansave())
            {

                MouseWait = true;
                try
                {
                    if (!isRuning)
                    {
                        RJMessageBox.Show("Reader not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    string filerData = "";
                    string accessPwd = "00000000";
                    int filerBank = 1;
                    byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
                    int filerPtr = int.Parse("32");
                    int filerLen = int.Parse("0");

                    if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
                    {
                        RJMessageBox.Show("filter data length error!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //if (rbTID.Checked)
                    //    filerBank = 2;
                    //if (rbUser.Checked)
                    //    filerBank = 3;
                    //----------
                    byte[] pwd = DataConvert.HexStringToByteArray(accessPwd);
                    int bank = 1;
                    int Ptr = int.Parse("2");
                    int leng = int.Parse("6");
                    string msg = "";
                    string H2 = txtPrefixHex.Texts;
                    string RndNo = RandomString(8);
                    string Databuf = H2 + ASCIItoHex(RndNo.ToUpper());
                    if (!StringUtils.IsHexNumber(Databuf))
                    {
                        RJMessageBox.Show("Please input hexadecimal data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Databuf.Length % 4 != 0)
                    {
                        RJMessageBox.Show("Write data of the length of the string must be in multiples of four!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    if (leng > (Databuf.Length / 4))
                    {
                        RJMessageBox.Show("Write data length error!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    int time = 500;
                    byte[] uDatabuf = DataConvert.HexStringToByteArray(Databuf);
                    bool result = uhf.WriteData(pwd, (byte)filerBank, filerPtr, filerLen, filerBuff, (byte)bank, Ptr, (byte)leng, uDatabuf);
                    if (result)
                    {
                        txtWriteData.Texts = Databuf;
                        time = 100;
                        RJMessageBox.Show("Successfully Write Tag", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtWriteData.Texts = "";
                        RJMessageBox.Show("Tag not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    txtWriteData.Texts = "";
                    string ErrorMsg = Common.GetString(ex);
                    RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MouseWait = false;
                }
            }
        }
        private void txtPrefix__TextChanged(object sender, EventArgs e)
        {
            txtPrefixHex.Texts = Common.ConvertASCIItoHex(txtPrefix.Texts);
        }


        private void btnRead_Click(object sender, EventArgs e)
        {
            if (CmbReader.SelectedIndex < 0)
            {
                RJMessageBox.Show("Reader not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string filerData = "";
            string accessPwd = "00000000";
            if (!StringUtils.IsHexNumber(accessPwd) || accessPwd.Length != 8)
            {
                RJMessageBox.Show("The length of the password must be 8!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int filerBank = 1;
            byte[] filerBuff = DataConvert.HexStringToByteArray(filerData);
            int filerPtr = int.Parse("32");
            int filerLen = int.Parse("0");

            if ((filerLen / 8 + (filerLen % 8 == 0 ? 0 : 1)) * 2 > filerData.Length)
            {
                RJMessageBox.Show("filter data length error!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (rbTID.Checked)
            //    filerBank = 2;
            //if (rbUser.Checked)
            //    filerBank = 3;
            //-----------------------------------------
            byte[] pwd = DataConvert.HexStringToByteArray(accessPwd);
            int bank = 1;
            int Ptr = int.Parse("2");
            int leng = int.Parse("6");
            string msg = "";

            string result = uhf.ReadData(pwd, (byte)filerBank, filerPtr, filerLen, filerBuff, (byte)bank, Ptr, leng);

            int time = 500;
            if (result != string.Empty)
            {
                time = 100;
                string txtRead_Data = result;
                txtReadtagdata.Texts = txtRead_Data.Replace(" ", "");
            }
            else
            {
                RJMessageBox.Show("Tag not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
