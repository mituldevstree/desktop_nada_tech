using NadaTech.Data;
using Newtonsoft.Json;
using ReaderDemo;
using RFID_Reader;
using RFID_Reader_Cmds;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xSocketDLL;

namespace NadaTech.View
{
    public partial class CreateAssetUC : UserControl
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        MasterForm _Mainform;
        AssetMaster _AssetMaster;
        AssetTagDetail _EditAssetTagDetail;
        List<DeleteImageData> ListDeleteImageData;
        string TagPrefix = "";
        public CreateAssetUC(object _mainform, AssetTagDetail _assetMaster)
        {
            InitializeComponent();
            btnStopReader();
            btnStartScan.Visible = true;
            btnStopScan.Visible = false;
            tbIsMoveable.Checked = true;
            _Mainform = _mainform as MasterForm;
            if (_assetMaster != null)
            {
                _EditAssetTagDetail = _assetMaster;
                _AssetMaster = _Entities.AssetMasters.FirstOrDefault(f => f.AssetId == _assetMaster.AssetId);
                FillEditData();
                btnSearchLocation.Enabled = false;
                btnStartScan.Visible = false;
                btnTagClear.Visible = false;
                btnStopScan.Visible = false;
            }
            ConfigMaster _PrefixCon = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "TAGPREFIX");
            if (_PrefixCon != null)
            {
                TagPrefix = _PrefixCon.ConfigValues;
            }
            txtExpiryDate.MinDate = DateTime.Now;

        }

        async void FillEditData()
        {
            try
            {


                _PartMaster = _AssetMaster.PartMaster;
                txtPart.Texts = _PartMaster.Name;
                txtPartDescription.Texts = _PartMaster.Description;

                _selectLocation = _EditAssetTagDetail.LocationMaster;
                if (_selectLocation != null)
                {
                    txtLocation.Texts = _selectLocation.Name;
                }
                txtAssetName.Texts = _AssetMaster.AssetName;
                txtAssetNote.Texts = _AssetMaster.Notes;
                txtSerialNumber.Texts = _AssetMaster.SerialNumber;
                tbIsMoveable.Checked = _AssetMaster.IsMoveable;
                if (_AssetMaster.ExpiryDate != null)
                {
                    txtExpiryDate.Value = (DateTime)_AssetMaster.ExpiryDate;
                }
                _listRFIDDATA = null;
                if (_listRFIDDATA == null)
                {
                    _listRFIDDATA = new BindingList<ScanTagDetail>();
                }
                _listRFIDDATA.Add(new ScanTagDetail { TagId = _EditAssetTagDetail.TagData, AssetTagId = _EditAssetTagDetail.AssetTagId });
                GrinEditDeleteDetailView.DataSource = _listRFIDDATA;
                GrinEditDeleteDetailView.Columns["AssetTagId"].Visible = false;


                ConfigMaster _ConfigMasters = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "AssertimgUploadurl");
                if (_ConfigMasters != null)
                {
                    //if (IsConnectedToInternet(_ConfigMasters.ConfigValues))
                    //{

                    List<AssetImage> ListAssetImg = _Entities.AssetImages.Where(w => w.AssetId == _AssetMaster.AssetId && w.IsDelete == false).ToList();
                    if (ListAssetImg.Count() > 0)
                    {
                        int x = 20;
                        int y = 20;
                        int maxHeight = -1;
                        foreach (AssetImage item in ListAssetImg)
                        {
                            //var img = await GetImageAsync(_ConfigMasters.ConfigValues + "/Document/AssetImages/" + item.AssetImage1);
                            FlowLayoutPanel panel = new FlowLayoutPanel();
                            Label label = new Label();
                            Button btnDeleteimg = new Button();
                            btnDeleteimg.Name = "btnDeleteimg";
                            btnDeleteimg.Text = "X";
                            btnDeleteimg.Cursor = Cursors.Hand;
                            btnDeleteimg.Click += BtnDeleteimg_Click;
                            label.Name = "uplAssetimgeid";
                            label.Text = item.AssetImgId.ToString();
                            label.Visible = false;
                            panel.Width = 100;
                            panel.Height = 100;
                            PictureBox pic = new PictureBox();
                            pic.Name = "uplAssetpic";
                            pic.Load(_ConfigMasters.ConfigValues + "/Document/AssetImages/" + item.AssetImage1);
                            pic.ImageLocation = _ConfigMasters.ConfigValues + "/Document/AssetImages/" + item.AssetImage1;
                            pic.Location = new Point(x, y);
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            x += pic.Width + 10;
                            maxHeight = Math.Max(pic.Height, maxHeight);
                            if (x > this.ClientSize.Width - 100)
                            {
                                x = 20;
                                y += maxHeight + 10;
                            }
                            panel.Controls.Add(label);
                            panel.Controls.Add(pic);
                            panel.Controls.Add(btnDeleteimg);
                            this.flowLayoutPanel1.Controls.Add(panel);
                        }
                    }
                    //}
                    //else
                    //{

                    //}
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool CheckUrl(string Url)
        {
            bool Status = false;
            try
            {
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(Url);
                httpReq.AllowAutoRedirect = false;

                HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();

                if (httpRes.StatusCode == HttpStatusCode.NotFound)
                {
                    httpRes.Close();
                    Status = false;
                }
                else
                {
                    httpRes.Close();
                    Status = true;
                }
            }
            catch (Exception)
            {
                Status = false;
            }
            return Status;
        }

        public static bool IsConnectedToInternet(string Url)
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(Url))
                    return true;
            }
            catch { }
            return false;
        }
        private async Task<Image> GetImageAsync(string url)
        {
            var httpClint = new HttpClient();
            var imageBytes = await httpClint.GetStreamAsync(url);
            return Image.FromStream(imageBytes);
        }
        PartMaster _PartMaster;
        private void rjButton3_Click(object sender, EventArgs e)
        {
            SearchFrom _AssetType = new SearchFrom();
            var Result = _AssetType.Show(SearchFrom.FormMode.Add, "Part");
            if (Result == DialogResult.OK)
            {
                _PartMaster = _AssetType._SelectSearchData as PartMaster;
                txtPart.Texts = _PartMaster.Name;
                txtPartDescription.Texts = _PartMaster.Description;
            }
            else
            {
                txtPart.Texts = "";
                txtPartDescription.Texts = "";
                _PartMaster = null;
            }
        }

        bool TagRead = false;
        private void btnStopScan_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnStopReader();
            this.Cursor = Cursors.Default;
        }
        public void btnStopReader()
        {
            btnStartScan.Visible = true;
            btnStopScan.Visible = false;
            if (_Mainform != null && _Mainform._selectReader != null)
            {
                if (_Mainform == null || _Mainform._selectReader.id == 1)
                {
                    StopReader();
                }
                else if (_Mainform._selectReader.id == 2)
                {
                    ChainwayUsebStopEPC(true);
                }
                else if (_Mainform._selectReader.id == 3)
                {
                    CIDisConnectReader();
                }
                TagRead = false;
            }

        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (_Mainform._selectReader != null)
            {

                if (_Mainform._selectReader.id == 1)
                {

                    StarScan();
                }
                else if (_Mainform._selectReader.id == 2)
                {
                    ChaiUsbStartEPC();
                }
                else if (_Mainform._selectReader.id == 3)
                {
                    CIReaderConnect();
                }
            }
            else
            {
                RJMessageBox.Show("Reader not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }
        void StarScan()
        {

            rpClient = new xClient();
            InitAddEvent(rp_PaketReceived); // Add a EventHandler
            ConnectReader();
            if (rpClient.bConnectSockFlag == true)
            {
                btnStartScan.Visible = false;
                btnStopScan.Visible = true;
                GetReaderDeviceAddr();
                TagRead = true;
            }
            else
            {
                RJMessageBox.Show("Reader not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTagClear_Click(object sender, EventArgs e)
        {
            _listRFIDDATA = null;
            GrinEditDeleteDetailView.DataSource = null;
            btnStartScan.Visible = true;
            btnStopScan.Visible = false;
            if (_Mainform != null && _Mainform._selectReader != null)
            {
                if (_Mainform._selectReader.id == 1)
                {
                    StopReader();
                }
                else if (_Mainform._selectReader.id == 2)
                {
                    ChainwayUsebStopEPC(true);
                }
                else if (_Mainform._selectReader.id == 3)
                {
                    CIDisConnectReader();
                }
            }
        }
        LocationMaster _selectLocation;
        private void btnSearchLocation_Click(object sender, EventArgs e)
        {
            SearchFrom _AssetType = new SearchFrom();
            var Result = _AssetType.Show(SearchFrom.FormMode.Add, "Location");
            if (Result == DialogResult.OK)
            {
                _selectLocation = _AssetType._SelectSearchData as LocationMaster;
                txtLocation.Texts = _selectLocation.Name;
            }
            else
            {
                txtLocation.Texts = "";
                _selectLocation = null;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select multiply images";
            ofd.Multiselect = true;
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = ofd.FileNames;
                int x = 20;
                int y = 20;
                int maxHeight = -1;
                foreach (string img in files)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.Name = "FlpuplodImg";
                    Label label = new Label();
                    label.Name = "uplAssetimgeid";
                    label.Text = "0";
                    label.Visible = false;

                    Button btnDeleteimg = new Button();
                    btnDeleteimg.Name = "btnDeleteimg";
                    btnDeleteimg.Text = "X";
                    btnDeleteimg.Click += BtnDeleteimg_Click;

                    panel.Width = 100;
                    panel.Height = 100;
                    PictureBox pic = new PictureBox();
                    pic.Name = "uplAssetpic";
                    pic.Image = Image.FromFile(img);
                    pic.ImageLocation = img;
                    pic.Location = new Point(x, y);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    x += pic.Width + 10;
                    maxHeight = Math.Max(pic.Height, maxHeight);
                    if (x > this.ClientSize.Width - 100)
                    {
                        x = 20;
                        y += maxHeight + 10;
                    }
                    panel.Controls.Add(label);
                    panel.Controls.Add(pic);
                    panel.Controls.Add(btnDeleteimg);

                    this.flowLayoutPanel1.Controls.Add(panel);
                }
            }
        }

        private void BtnDeleteimg_Click(object sender, EventArgs e)
        {
            Button _btndeleimg = sender as Button;
            var _ctl = _btndeleimg.Parent;
            Label _Label = _ctl.Controls.Find("uplAssetimgeid", true).FirstOrDefault() as Label;
            if (_Label.Text != "0")
            {
                long AIId = Convert.ToInt64(_Label.Text);
                if (ListDeleteImageData == null)
                {
                    ListDeleteImageData = new List<DeleteImageData>();
                }
                ListDeleteImageData.Add(new DeleteImageData { imgAssetId = AIId });
            }
            flowLayoutPanel1.Controls.Remove(_ctl);
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private bool Cansave()
        {
            if (_PartMaster == null)
            {
                RJMessageBox.Show("Select Part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtAssetName.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Asset ID/Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_selectLocation == null && _EditAssetTagDetail == null)
            {
                RJMessageBox.Show("Select Location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_listRFIDDATA == null)
            {
                RJMessageBox.Show("Scan Minimum One Tag Id.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_listRFIDDATA.Count() == 0)
            {
                RJMessageBox.Show("Scan Minimum One Tag Id.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (TagRead)
                {
                    btnStopReader();
                }
                if (Cansave())
                {
                    if (_AssetMaster == null)
                    {
                        _AssetMaster = new AssetMaster();
                        _AssetMaster.IsDelete = false;
                        _AssetMaster.CreateDate = DateTime.Now;
                        _AssetMaster.CreatedBy = Program.UserId;
                        _Entities.AssetMasters.Add(_AssetMaster);
                    }
                    PartMaster _PM = _Entities.PartMasters.FirstOrDefault(f => f.PartId == _PartMaster.PartId);
                    _AssetMaster.PartId = _PM.PartId;
                    _AssetMaster.PartMaster = _PM;
                    _AssetMaster.AssetName = txtAssetName.Texts.Trim();
                    if (_PM.IsExpire)
                    {
                        _AssetMaster.ExpiryDate = txtExpiryDate.Value;
                    }
                    _AssetMaster.SerialNumber = txtSerialNumber.Texts.Trim();
                    _AssetMaster.IsMoveable = tbIsMoveable.Checked;
                    _AssetMaster.Notes = txtAssetNote.Texts.Trim();
                    _AssetMaster.ModifiedDate = DateTime.Now;
                    _AssetMaster.ModifiedBy = Program.UserId;
                    LocationMaster _LM = new LocationMaster();
                    if (_selectLocation != null)
                    {
                        _LM = _Entities.LocationMasters.FirstOrDefault(f => f.LocationId == _selectLocation.LocationId);

                    }
                    foreach (ScanTagDetail item in _listRFIDDATA)
                    {
                        if (_Entities.AssetTagDetails.Where(w => w.TagData == item.TagId && w.IsDelete == false && w.AssetTagId != item.AssetTagId).Count() > 0)
                        {
                            RJMessageBox.Show("Tag : " + item.TagId + " already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (_AssetMaster.AssetId == 0)
                            {
                                _AssetMaster = null;
                            }
                            return;
                        }
                        AssetTagDetail _AssetTagDetail = _Entities.AssetTagDetails.FirstOrDefault(w => w.AssetTagId == item.AssetTagId);
                        if (_AssetTagDetail == null)
                        {
                            _AssetTagDetail = new AssetTagDetail();
                            _AssetTagDetail.LocationMaster = _LM;
                            _AssetTagDetail.AssetStatus = "1";
                            _AssetTagDetail.IsDelete = false;
                            _AssetTagDetail.CreateDate = DateTime.Now;
                            _AssetTagDetail.CreatedBy = Program.UserId;
                            _AssetMaster.AssetTagDetails.Add(_AssetTagDetail);
                        }
                        _AssetTagDetail.TagData = item.TagId;
                        _AssetTagDetail.ModifiedDate = DateTime.Now;
                        _AssetTagDetail.ModifiedBy = Program.UserId;
                    }
                    //Upload Asset Images

                    if (flowLayoutPanel1.Controls.Count > 0)
                    {
                        ConfigMaster _ConfigMasters = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "AssertimgUploadurl");
                        if (_ConfigMasters != null)
                        {
                            //if (!IsConnectedToInternet(_ConfigMasters.ConfigValues))
                            //{
                            //    _AssetMaster = null;
                            //    RJMessageBox.Show("Asset Image upload server not connect.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    return;
                            //}

                            var res = await MakeCall(_ConfigMasters.ConfigValues, 1);
                            ResponseDefault _ResponseDefault = res;
                            if (res.Message != "NoUplImg")
                            {
                                if (_ResponseDefault.Status && _ResponseDefault.Response != null)
                                {
                                    if (_ResponseDefault.Response.Count() > 0)
                                    {
                                        foreach (var item in _ResponseDefault.Response)
                                        {
                                            AssetImage _AssetImage = new AssetImage();
                                            _AssetImage.AssetImage1 = item.ImgName;
                                            _AssetImage.IsDelete = false;
                                            _AssetImage.CreateDate = DateTime.Now;
                                            _AssetImage.CreatedBy = Program.UserId;
                                            _AssetImage.ModifiedDate = DateTime.Now;
                                            _AssetImage.ModifiedBy = Program.UserId;
                                            _AssetMaster.AssetImages.Add(_AssetImage);
                                        }
                                    }
                                }
                                else
                                {
                                    _AssetMaster = null;
                                    RJMessageBox.Show(_ResponseDefault.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                    if (ListDeleteImageData != null)
                    {
                        foreach (DeleteImageData Aiitem in ListDeleteImageData)
                        {
                            AssetImage _AssetImage = _Entities.AssetImages.FirstOrDefault(f => f.AssetImgId == Aiitem.imgAssetId);
                            _AssetImage.IsDelete = true;
                            _AssetImage.ModifiedBy = Program.UserId;
                            _AssetImage.ModifiedDate = DateTime.Now;
                        }
                    }

                    _Entities.SaveChanges();
                    var msgresult = RJMessageBox.Show("Asset Registration successfully done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (msgresult == DialogResult.OK || msgresult == DialogResult.Cancel)
                    {
                        if (_EditAssetTagDetail != null)
                        {
                            this.Cursor = Cursors.Default;
                            _Mainform.MasterFormclick("ManageAsset");
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            ClearData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        private async void rjButton1_Click(object sender, EventArgs e)
        {
            ConfigMaster _ConfigMasters = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "AssertimgUploadurl");
            if (_ConfigMasters != null)
            {
                var res = await MakeCall(_ConfigMasters.ConfigValues, 1);
                ResponseDefault _ResponseDefault = res;

            }
        }

        public async Task<ResponseDefault> MakeCall(string url, long PartId)
        {
            ResponseDefault _ResponseDefault = new ResponseDefault();
            _ResponseDefault.Status = false;
            _ResponseDefault.Message = "";
            try
            {
                byte[] data;
                string result = "";
                ByteArrayContent bytes;
                MultipartFormDataContent multiForm = new MultipartFormDataContent();
                using (var client = new HttpClient())
                {
                    if (flowLayoutPanel1.Controls.Count > 0)
                    {
                        bool isPost = false;
                        foreach (Control ctl in flowLayoutPanel1.Controls)
                        {

                            FlowLayoutPanel _Panel = ctl as FlowLayoutPanel;
                            PictureBox _PictureBox = _Panel.Controls.Find("uplAssetpic", true).FirstOrDefault() as PictureBox;
                            Label _Label = _Panel.Controls.Find("uplAssetimgeid", true).FirstOrDefault() as Label;
                            if (_Label.Text == "0")
                            {
                                isPost = true;
                                data = ImageToByteArray(_PictureBox.Image);
                                bytes = new ByteArrayContent(data);
                                string imgName = "abc.jpg";
                                if (!string.IsNullOrEmpty(_PictureBox.ImageLocation))
                                {
                                    imgName = _PictureBox.ImageLocation.Split('\\').LastOrDefault();
                                }
                                multiForm.Add(bytes, "AssetImages", imgName);
                            }
                        }
                        if (isPost)
                        {
                            client.DefaultRequestHeaders.Add("userid", Program.UserId.ToString());
                            client.DefaultRequestHeaders.Add("PartId", PartId.ToString());
                            var res = await client.PostAsync(url + "/api/Master/UploadAssetImg", multiForm);
                            string resultContent = res.Content.ReadAsStringAsync().Result;
                            _ResponseDefault = JsonConvert.DeserializeObject<ResponseDefault>(resultContent);
                        }
                        else
                        {
                            _ResponseDefault.Message = "NoUplImg";

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _ResponseDefault.Message = ex.Message;
            }
            return _ResponseDefault;
        }

        void ClearData()
        {
            txtPart.Texts = "";
            txtPartDescription.Texts = "";
            _PartMaster = null;
            txtLocation.Texts = "";
            _selectLocation = null;
            txtAssetName.Texts = "";
            txtSerialNumber.Texts = "";
            txtAssetNote.Texts = "";
            _listRFIDDATA = null;
            GrinEditDeleteDetailView.DataSource = null;
            btnStartScan.Visible = true;
            btnStopScan.Visible = false;
            flowLayoutPanel1.Controls.Clear();
            _AssetMaster = null;
            _EditAssetTagDetail = null;
            btnSearchLocation.Enabled = true;
            ListDeleteImageData = new List<DeleteImageData>();
            tbIsMoveable.Checked = true;
            btnStopReader();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_EditAssetTagDetail != null)
            {
                _Mainform.MasterFormclick("ManageAsset");
            }
            else
            {
                ClearData();
            }
        }

        #region  RFID READ
        string textBox_IP = "192.168.0.200";
        int textBox_Port = 200;

        private xClient rpClient;
        private Thread threadClient;
        private Thread threadFramePaser;
        Queue<byte> qClient = new Queue<byte>(0xFFFFF);
        TextBox txtSend = new TextBox();
        TextBox textBox_RecvByteCounter = new TextBox();
        private void GetReaderDeviceAddr()
        {// If we do not know the current Reader's Device Address, we can use the Broadcast Device Address to get it.
            txtSend.Text = Commands.RFID_Q_ReaderDeviceAddr(ConstCode.READER_DEVICEADDR_BROADCAST, ConstCode.READER_OPERATION_GET, 0);
            NetSendCommand(txtSend.Text);//NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);            
        }
        public string GetReaderDeviceAddrs()
        {
            string address = Commands.RFID_Q_ReaderDeviceAddr(ConstCode.READER_DEVICEADDR_BROADCAST, ConstCode.READER_OPERATION_GET, 0);
            NetSendCommand(address);//NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);            
            return address;
        }
        public void NetSendCommand(string strCommandFrame)
        {
            if (bConnectToServerFlag == true)
            {
                rpClient.Send(txtSend.Text);
            }
            else
            {
                MessageBox.Show("Server has not been connected!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private static byte ReaderDeviceAddress = ConstCode.READER_DEVICEADDR_BROADCAST;//0xFF;

        bool bConnectToServerFlag = false;

        void ConnectReader()
        {
            ConfigMaster _SYSIOTFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "SYSIOTFIXEDREIP");
            if (_SYSIOTFIXEDREIP != null)
            {
                textBox_IP = _SYSIOTFIXEDREIP.ConfigValues;
            }
            ConfigMaster _SYSIOTFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "SYSIOTFIXEDREPORT");
            if (_SYSIOTFIXEDREPORT != null)
            {
                if (!string.IsNullOrEmpty(_SYSIOTFIXEDREPORT.ConfigValues))
                {
                    textBox_Port = Convert.ToInt32(_SYSIOTFIXEDREPORT.ConfigValues);
                }
            }
            rpClient.Connect(textBox_IP, textBox_Port);
            if (rpClient.bConnectSockFlag == true)
            {

                bConnectToServerFlag = true;
                threadClient = new Thread(ClientRecvMsgThread);
                threadClient.IsBackground = true;
                threadClient.Start();
                threadFramePaser = new Thread(ClientFramePaserThread);
                threadFramePaser.IsBackground = true;
                threadFramePaser.Start();
                checkReaderAvailable();
                Readtag();
            }
        }
        public void StopReader()
        {
            if (bConnectToServerFlag == true)
            {
                threadClient.Abort();
                threadFramePaser.Abort();

                StopReadTag();
                rpClient.SocketClose();
                bConnectToServerFlag = false;
            }

        }


        void Readtag()
        {

            ulClientRecvByteCounter = 0;
            ulClientRecvEnqueueCounter = 0;
            ulClientRecvQueueCounter = 0;
            ulClientRecvDequeueCounter = 0;
            //bSensorTag_InventoryFlag = false;
            int loopCnt = Convert.ToInt32(0);
            txtSend.Text = Commands.RFID_Q_ReadMulti(ReaderDeviceAddress, (byte)2, (byte)5, loopCnt);
            NetSendCommand(txtSend.Text);// NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);
            ClientRecvByteCounter = 0;
            textBox_RecvByteCounter.Text = ClientRecvByteCounter.ToString();
        }
        void StopReadTag()
        {
            txtSend.Text = Commands.RFID_Q_StopRead(ReaderDeviceAddress);
            NetSendCommand(txtSend.Text);//NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);
            Thread.Sleep(200);
            //txtSend.Text = Commands.RFID_Q_StopRead(ReaderDeviceAddress);
            //NetSendCommand(txtSend.Text);//NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);
        }


        public void checkReaderAvailable()
        {
            if (bConnectToServerFlag == true)
            {
                //GetReaderDeviceAddr();

                //hardwareVersion = "";
                //checkingReaderAvailable = true;
                //readerConnected = false;

                //Sp.GetInstance().Send(Commands.RFID_Q_GetModuleInfo(ReaderDeviceAddress,ConstCode.MODULE_HARDWARE_VERSION_FIELD));
                txtSend.Text = Commands.RFID_Q_GetModuleInfo(ReaderDeviceAddress, ConstCode.MODULE_HARDWARE_VERSION_FIELD);
                NetSendCommand(txtSend.Text);//NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);


                //Sp.GetInstance().Send(Commands.RFID_Q_GetModuleInfo(ConstCode.READER_DEVICEADDR_BROADCAST, ConstCode.MODULE_HARDWARE_VERSION_FIELD));
                //timerCheckReader.Enabled = true;//if executed System.Timers.Timer.Elapsed  Event
            }
        }

        private ulong ulClientRecvByteCounter = 0;
        private ulong ulClientRecvEnqueueCounter = 0;
        private ulong ulClientRecvQueueCounter = 0;
        private ulong ulClientRecvDequeueCounter = 0;
        static private ReaderWriterLock _rwlock = new ReaderWriterLock();

        private void ClientRecvMsgThread()
        {
            byte[] byteArray = new byte[0x1FFFF]; //System.Text.Encoding.ASCII.GetBytes(str);
            int i, iRecv;
            qClient.Clear();
            while (bConnectToServerFlag)
            {
                try
                {
                    iRecv = rpClient.ReceiveBytes(ref byteArray);
                    if (iRecv == 0)
                        continue;
                    ulClientRecvByteCounter = ulClientRecvByteCounter + (ulong)iRecv;
                    // Request Write Lock
                    _rwlock.AcquireWriterLock(500);
                    for (i = 0; i < iRecv; i++)
                    {
                        qClient.Enqueue(byteArray[i]);
                        ulClientRecvEnqueueCounter++;
                    }
                    _rwlock.ReleaseWriterLock();
                }
                catch (Exception ex)
                {
                    //_rwlock.ReleaseWriterLock();
                    // MessageBox.Show("RecvMsgThread Error:" + ex.Message + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                /*finally
                { // Release Write Lock
                    _rwlock.ReleaseWriterLock();
                } */

            }
        }
        private ulong ClientRecvByteCounter = 0;
        private void ClientFramePaserThread()
        {
            byte[] byteArray = new byte[4096]; //System.Text.Encoding.ASCII.GetBytes(str);
            int i, iQsize;

            byte[] ReaderRespFrame = new byte[655350];//bytesToRead];
            int ReaderRespLength = 0;
            int apist;
            int index = 0;

            while (bConnectToServerFlag)
            {
                try
                { //                     
                    try
                    {
                        iQsize = qClient.Count;// Get Current Queue Size 
                        if (iQsize == 0)
                            continue;
                        ulClientRecvQueueCounter = ulClientRecvQueueCounter + (ulong)iQsize;

                        _rwlock.AcquireReaderLock(1000);
                        for (i = 0; i < iQsize; i++)
                        {
                            byteArray[i] = (byte)qClient.Dequeue();
                            ulClientRecvDequeueCounter++;

                            apist = Commands.ReaderRespFrameParser(Commands.ReaderDeviceAddr, byteArray[i]);
                            if (apist == 0x00)
                            {
                                ReaderRespFrame = DataConvert.StructToBytes(Commands.ReaderRespFramePacket);
                                ReaderRespLength = (int)(ReaderRespFrame[3] + 3);
                                string[] array3 = new string[ReaderRespLength + 1L];
                                for (index = 0; index < ReaderRespLength; index++)
                                {
                                    array3[index] = ReaderRespFrame[index].ToString("X2");
                                }
                                iQsize = 0;//
                                this.clientEvtHandlerPacketReceived(this, new StrArrEventArgs(array3)); // Generate a receive Event Handler
                            }
                        }
                        ClientRecvByteCounter = ClientRecvByteCounter + (ulong)iQsize;
                        set_txtClientRecvByteCnt(ClientRecvByteCounter.ToString());
                        _rwlock.ReleaseReaderLock();

                    }
                    catch (Exception ex)
                    {
                        //_rwlock.ReleaseWriterLock();
                        // MessageBox.Show("Frame Parser Error:" + ex.Message + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    /*finally
                    {
                        _rwlock.ReleaseReaderLock();
                    }*/
                }
                catch (ApplicationException) // 如果请求读锁失败 
                {
                    Console.WriteLine("Paser Error!");
                }

            }
        }
        private delegate void ClientRecvByteCntDelegate(string strCnttext);
        private void set_txtClientRecvByteCnt(string strCnttext)
        {
            if (this.textBox_RecvByteCounter.InvokeRequired)
            {
                ClientRecvByteCntDelegate md = new ClientRecvByteCntDelegate(this.set_txtClientRecvByteCnt);
                this.Invoke(md, new object[] { strCnttext });
            }
            else
                this.textBox_RecvByteCounter.Text = strCnttext;
        }

        public event EventHandler<StrArrEventArgs> clientEvtHandlerPacketReceived;  // 
        public void InitAddEvent(EventHandler<StrArrEventArgs> addEvent)
        {
            //this.OnAddEvent = addEvent;     
            this.clientEvtHandlerPacketReceived += new EventHandler<StrArrEventArgs>(addEvent);
        }

        private void rp_PaketReceived(object sender, StrArrEventArgs e)
        {
            string[] packetRx = e.Data;
            string strPacket = string.Empty;
            for (int i = 0; i < packetRx.Length; i++)
            {
                strPacket += packetRx[i] + " ";
            }
            this.Invoke((EventHandler)(delegate
            {

                //auto clear received data region

                //--------------------------------------------------
                int dis;
                //int packetRxLen = Marshal.SizeOf(Commands.ReaderRespFramePacket);//Convert.ToInt16(packetRx[3],10);
                byte[] packetRxHex = new byte[256];//packetRxLen];
                packetRxHex = DataConvert.GetHexBytes(strPacket, out dis);

                Commands.ReaderResponseFrameString rxStrPkts = new Commands.ReaderResponseFrameString(true);
                rxStrPkts = Commands.GetReaderResponsFrameStringStructFromHexBuffer(packetRxHex);
                //Commands.ReaderResponseFrame RdRecv = (Commands.ReaderResponseFrame)RFID_Reader_Cmds.DataConvert.BytesToStruct(packetRxHex, Commands.ReaderRespFramePacket.GetType());
                //---------------------------------------------------- 
                if (rxStrPkts.strStatus == ConstCode.FAIL_OK)
                {
                    rp_PaketOK(rxStrPkts);
                }
                else
                {
                    rp_PacketFail(rxStrPkts.strStatus, rxStrPkts.strLength, rxStrPkts.strParameters);
                }


            }));
        }
        string pc = string.Empty;
        string epc = string.Empty;
        string crc = string.Empty;
        string rssi = string.Empty;
        string antno = string.Empty;
        int FailEPCNum = 0;
        int SucessEPCNum = 0;
        double errnum = 0;
        double db_errEPCNum = 0;
        double db_LoopNum_cnt = 0;
        string per = "0.000";
        private void rp_PaketOK(Commands.ReaderResponseFrameString rxStrPkts)
        {
            //setStatus("", Color.MediumSeaGreen);
            if (rxStrPkts.strCmdH == ConstCode.CMD_EXE_FAILED)
            {

            }
            else if (rxStrPkts.strCmdH == ConstCode.CMD_SET_QUERY_PARA)            //SetQuery
            {
                MessageBox.Show("Query Parameters has set up", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (rxStrPkts.strCmdH == ConstCode.CMD_INVENTORY || rxStrPkts.strCmdH == ConstCode.CMD_MULTI_ID)         //Succeed to Read EPC    
            {

                SucessEPCNum = SucessEPCNum + 1;
                db_errEPCNum = FailEPCNum;
                db_LoopNum_cnt = db_LoopNum_cnt + 1;
                errnum = (db_errEPCNum / db_LoopNum_cnt) * 100;
                per = string.Format("{0:0.000}", errnum);

                int rssidBm = Convert.ToInt16(rxStrPkts.strParameters[0], 16); // rssidBm is negative && in bytes
                if (rssidBm > 127)
                {
                    rssidBm = -((-rssidBm) & 0xFF);
                }
                rssidBm = rssidBm - (-10);//Hardware compensation.      rssidBm -= Convert.ToInt32(tbxCoupling.Text, 10);
                rssidBm = rssidBm - (3); //    rssidBm -= Convert.ToInt32(tbxAntennaGain.Text, 10);
                rssi = rssidBm.ToString();

                int PCEPCLength = ((Convert.ToInt32((rxStrPkts.strParameters[1]), 16)) / 8 + 1) * 2;
                pc = rxStrPkts.strParameters[1] + " " + rxStrPkts.strParameters[2];
                epc = string.Empty;
                for (int i = 0; i < PCEPCLength - 2; i++)
                {
                    epc = epc + rxStrPkts.strParameters[3 + i];
                }
                crc = rxStrPkts.strParameters[1 + PCEPCLength] + " " + rxStrPkts.strParameters[2 + PCEPCLength];

                antno = rxStrPkts.strParameters[3 + PCEPCLength];

                if (false == false)
                    GetEPC(pc, epc, crc, rssi, antno, per);


            }




        }

        private void rp_PacketFail(string FailCode, string rxstrLen, string[] strParam)
        {
            int failType = Convert.ToInt32(FailCode, 16);
            int rxlen = Convert.ToInt32(rxstrLen, 16);

            if (FailCode == ConstCode.FAIL_INVENTORY_TAG_TIMEOUT)
            {
                FailEPCNum = FailEPCNum + 1;
                db_errEPCNum = FailEPCNum;
                db_LoopNum_cnt = db_LoopNum_cnt + 1;
                errnum = (db_errEPCNum / db_LoopNum_cnt) * 100;
                per = string.Format("{0:0.000}", errnum);
            }
            else if (FailCode == ConstCode.FAIL_FHSS_FAIL)
            {
                //MessageBox.Show("FHSS Failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("FHSS Failed", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_ANT_NOT_AVAILABLE)
            {
                //MessageBox.Show("FHSS Failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Switch Antenna Port Failed! Please check the Antenna Setting.", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_ACCESS_PWD_ERROR)
            {
                //MessageBox.Show("Access Failed, Please Check the Access Password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Access Failed, Please Check the Access Password", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_READ_MEMORY_NO_TAG)
            {
                setStatus("No Tag Response, Fail to Read Tag Memory", Color.Red);
            }
            else if (FailCode.Substring(0, 1) == ConstCode.FAIL_READ_ERROR_CODE_BASE.Substring(0, 1))
            {
                //MessageBox.Show("Read Failed. Error Code: " + ParseErrCode(failType), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Read Failed. Error Code: " + ParseErrCode(failType), Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_WRITE_MEMORY_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, Fail to Write Tag Memory", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("No Tag Response, Fail to Write Tag Memory", Color.Red);
            }
            else if (FailCode.Substring(0, 1) == ConstCode.FAIL_WRITE_ERROR_CODE_BASE.Substring(0, 1))
            {
                //MessageBox.Show("Write Failed. Error Code: " + ParseErrCode(failType), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Write Failed. Error Code: " + ParseErrCode(failType), Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_LOCK_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, Lock Operation Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("No Tag Response, Lock Operation Failed", Color.Red);
            }
            else if (FailCode.Substring(0, 1) == ConstCode.FAIL_LOCK_ERROR_CODE_BASE.Substring(0, 1))
            {
                //MessageBox.Show("Lock Failed. Error Code: " + ParseErrCode(failType), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Lock Failed. Error Code: " + ParseErrCode(failType), Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_KILL_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, Kill Operation Failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("No Tag Response, Kill Operation Failed", Color.Red);
            }
            else if (FailCode.Substring(0, 1) == ConstCode.FAIL_KILL_ERROR_CODE_BASE.Substring(0, 1))
            {
                //MessageBox.Show("Kill Failed. Error Code: " + ParseErrCode(failType), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Kill Failed. Error Code: " + ParseErrCode(failType), Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_NXP_CHANGE_CONFIG_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, NXP Change Config Failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("No Tag Response, NXP Change Config Failed", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_NXP_CHANGE_EAS_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, NXP Change EAS Failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("No Tag Response, NXP Change EAS Failed", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_NXP_CHANGE_EAS_NOT_SECURE)
            {
                //MessageBox.Show("Tag is not in Secure State, NXP Change EAS Failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Tag is not in Secure State, NXP Change EAS Failed", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_NXP_EAS_ALARM_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, NXP EAS Alarm Operation Failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //txtOperateEpc.Text = "";
                setStatus("No Tag Response, NXP EAS Alarm Operation Failed", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_NXP_READPROTECT_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, NXP ReadProtect Failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("No Tag Response, NXP ReadProtect Failed", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_NXP_RESET_READPROTECT_NO_TAG)
            {
                //MessageBox.Show("No Tag Response, NXP Reset ReadProtect Failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("No Tag Response, NXP Reset ReadProtect Failed", Color.Red);
            }
            else if (FailCode == "2E") // QT Read/Write Failed
            {
                setStatus("No Tag Response, QT Command Failed", Color.Red);
            }
            else if (FailCode.Substring(0, 1) == ConstCode.FAIL_CUSTOM_CMD_BASE.Substring(0, 1))
            {
                //MessageBox.Show("Command Executed Failed. Error Code: " + ParseErrCode(failType), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Command Executed Failed. Error Code: " + ParseErrCode(failType), Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_INVALID_PARA)
            {
                MessageBox.Show("Invalid Parameters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (FailCode == ConstCode.FAIL_INVALID_CMD)
            {
                MessageBox.Show("Invalid Command!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (FailCode == ConstCode.FAIL_SUBCMD_UNDEF)
            {
                MessageBox.Show("Invalid Sub Command!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (FailCode == ConstCode.FAIL_MAINCMD_UNDEF)
            {
                MessageBox.Show("Invalid Main Command!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (FailCode == ConstCode.FAIL_COMMAND_CRC)//2019-05-10
            {
                setStatus("API command Crc is Error!", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_PARAMETER_FAIL)//2019-05-10
            {
                setStatus("Set or Get Reader Parameter is failed!", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_READER_FAIL)//2019-05-10
            {
                setStatus("Set Reader operation is failed1", Color.Red);
            }
            else if (FailCode == ConstCode.FAIL_TAG_FAIL)//2019-05-10
            {
                setStatus("Access Tag operation is failed!", Color.Red);
            }
        }
        private string ParseErrCode(int errorCode)
        {
            switch (errorCode & 0x0F)
            {
                case ConstCode.ERROR_CODE_OTHER_ERROR:
                    return "Other Error";
                case ConstCode.ERROR_CODE_MEM_OVERRUN:
                    return "Memory Overrun";
                case ConstCode.ERROR_CODE_MEM_LOCKED:
                    return "Memory Locked";
                case ConstCode.ERROR_CODE_INSUFFICIENT_POWER:
                    return "Insufficient Power";
                case ConstCode.ERROR_CODE_NON_SPEC_ERROR:
                    return "Non-specific Error";
                default:
                    return "Non-specific Error";
            }
        }

        private void setStatus(string msg, Color color)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        BindingList<ScanTagDetail> _listRFIDDATA = new BindingList<ScanTagDetail>();
        private void GetEPC(string pc, string epc, string crc, string rssi, string antno, string per)
        {
            //this.dgv_epc2.ClearSelection();
            bool isFoundEpc = false;
            string newEpcItemCnt;
            int indexEpc = 0;

            int EpcItemCnt;

            if (_listRFIDDATA == null)
            {
                _listRFIDDATA = new BindingList<ScanTagDetail>();
            }

            if (_EditAssetTagDetail != null)
            {
                ScanTagDetail _RFIDDATA = _listRFIDDATA.FirstOrDefault(w => w.AssetTagId == _EditAssetTagDetail.AssetTagId);
                _RFIDDATA.TagId = epc;
                _listRFIDDATA.ResetBindings();
            }
            else
            {
                if (_listRFIDDATA.Where(w => w.TagId == epc).Count() > 0)
                {
                    ScanTagDetail _RFIDDATA = _listRFIDDATA.FirstOrDefault(w => w.TagId == epc);
                    _listRFIDDATA.ResetBindings();
                }
                else
                {
                    if (!string.IsNullOrEmpty(epc))
                    {
                        _listRFIDDATA.Add(new ScanTagDetail { TagId = epc });
                        GrinEditDeleteDetailView.DataSource = _listRFIDDATA;
                        GrinEditDeleteDetailView.Columns["AssetTagId"].Visible = false;

                    }
                }
            }

        }



        #endregion

        #region Chainway USB Reader

        public IUHF uhf = null;
        long beginTime = 0;
        delegate void SetTextCallback(string epc, string tid, string rssi, string count, string ant, string user);
        SetTextCallback setTextCallback;
        bool isPz = false;

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
        bool isRuning = false;
        bool isComplete = true;

        private void ChaiUsbStartEPC()
        {
            setTextCallback = new SetTextCallback(UpdataEPC);
            ChangeUHFAPI(true);

            bool usbConnect = uhf.Open();
            if (usbConnect)
            {

                if (!isRuning && isComplete)
                {
                    isRuning = true;
                    isComplete = false;
                    btnStartScan.Visible = false;
                    btnStopScan.Visible = true;
                    if (uhf.Inventory())
                    {
                        new Thread(new ThreadStart(delegate { ChainwayUsebReadEPC(); })).Start();
                    }
                }
            }
            else
            {
                RJMessageBox.Show("Chainway USB Reader not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void ChainwayUsebReadEPC()
        {
            try
            {
                beginTime = System.Environment.TickCount;
                while (isRuning)
                {
                    UHFTAGInfo info = uhf.uhfGetReceived();
                    if (info != null)
                    {


                        this.BeginInvoke(setTextCallback, new object[] { info.Epc, info.Tid, info.Rssi, "1", info.Ant, info.User });

                    }
                }

                if (isPz)
                {
                    bool result = false;
                    for (int k = 0; (k < 2) || result; k++)
                    {
                        Thread.Sleep(1);
                        UHFTAGInfo info = uhf.uhfGetReceived();
                        if (result)
                        {

                            this.BeginInvoke(setTextCallback, new object[] { info.Epc, info.Tid, info.Rssi, "1", info.Ant, info.User });

                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
            isComplete = true;

        }

        private void UpdataEPC(string epc, string tid, string rssi, string count, string ant, string user)
        {
            try
            {


                string RFID = (string.IsNullOrEmpty(epc) ? "" : epc).Replace(" ", "");
                if (!string.IsNullOrEmpty(RFID))
                {

                    if (string.IsNullOrEmpty(TagPrefix))
                    {
                        GetEPC("", RFID, "", "", "", "");
                    }
                    else if (RFID.Contains(Common.ConvertASCIItoHex(TagPrefix)))
                    {
                        GetEPC("", RFID, "", "", "", "");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private void ChainwayUsebStopEPC(bool isStop)
        {
            if (uhf != null)
            {
                bool reuslt = uhf.StopGet();
                if (reuslt)
                {
                    isRuning = false;
                    uhf.Close();
                }
            }
        }



        #endregion

        #region CIRFID FIXED READER
        private volatile IntPtr m_handler = IntPtr.Zero;
        private Thread consumerThread = null;
        private BlockingCollection<ReportData> reportQueue = new BlockingCollection<ReportData>(new ConcurrentQueue<ReportData>());
        ReaderAPI.UHFReaderReportCallback uhfReaderCallback;
        private volatile bool consumer_running = false;
        bool isclient = false;
        byte readeruid = 0;
        private String devsn;

        void CIReaderConnect()
        {
            uhfReaderCallback = new ReaderAPI.UHFReaderReportCallback(ReaderCallback);
            string devinfo = "";
            string CIRIp = "192.168.1.30";
            int DevicePort = 20058;
            ConfigMaster _CIRFIDFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREIP");
            if (_CIRFIDFIXEDREIP != null)
            {
                CIRIp = _CIRFIDFIXEDREIP.ConfigValues;
            }
            ConfigMaster _CIRFIDFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREPORT");
            if (_CIRFIDFIXEDREPORT != null)
            {
                if (!string.IsNullOrEmpty(_CIRFIDFIXEDREPORT.ConfigValues))
                {
                    DevicePort = Convert.ToInt32(_CIRFIDFIXEDREPORT.ConfigValues);
                }
            }
            m_handler = IntPtr.Zero;
            devinfo = string.Format("CommType=NET;RemoteIp={0};RemotePort={1}", CIRIp, DevicePort);
            ConnectDev(devinfo);
            CIRstartreadBtn_Click();
            btnStartScan.Visible = false;
            btnStopScan.Visible = true;
        }
        void CIDisConnectReader()
        {
            CIRstopReadBtn_Click();
            consumer_running = false;
            reportQueue.Add(null);
            if (consumerThread != null)
            {
                consumerThread.Abort();
                consumerThread = null;
            }
            ReaderAPI.UHFReader_Close(ref m_handler);
            m_handler = IntPtr.Zero;
            //clearInventoryBtn_Click(null, null);
            while (reportQueue.TryTake(out ReportData _)) ;

            btnStartScan.Visible = true;
            btnStopScan.Visible = false;

        }
        private bool ConnectDev(String devinfo)
        {
            try
            {


                if (IntPtr.Zero != m_handler)
                {
                    return false;
                }

                UInt32 len = (UInt32)devinfo.Length;
                var iret = ReaderAPI.UHFReader_Connect(ref m_handler, devinfo, len, uhfReaderCallback);
                if (ReaderAPI.Err_noError != iret)
                {
                    MessageBox.Show("Fail to Connect Reader!");
                    m_handler = IntPtr.Zero;
                    return false;
                }
                setCIRFIDAntPower();
                isclient = false;
                readeruid = 0;
                consumer_running = true;
                consumerThread = new Thread(new ThreadStart(Consumer));
                consumerThread.IsBackground = true;
                consumerThread.Start();
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
            // GetConfig();
        }
        void setCIRFIDAntPower()
        {
            string antPower = "25";
            ConfigMaster _ReaderAntennaPower = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "ReaderAntennaPower");
            if (_ReaderAntennaPower != null)
            {
                antPower = string.IsNullOrEmpty(_ReaderAntennaPower.ConfigValues) ? "25" : _ReaderAntennaPower.ConfigValues;
            }
            byte[] ant_config = new byte[64];
            UInt32 ant_config_len = (UInt32)ant_config.Length;
            var iret = ReaderAPI.UHFReader_GetAntConfig(m_handler, readeruid, ant_config, ref ant_config_len);
            if (ReaderAPI.Err_noError != iret)
            {
                return;
            }
            uint AntCount = (uint)ant_config_len / 12;
            byte[] antConfig = new byte[48];
            for (int i = 0; i < AntCount; i++)
            {
                uint enable = 1;
                uint dwellTime = 3000;
                uint power = uint.Parse(antPower);

                Common.U32ToLittleEndianU8s(enable, antConfig, i * 12);
                Common.U32ToLittleEndianU8s(dwellTime, antConfig, i * 12 + 4);
                Common.U32ToLittleEndianU8s(power * 10, antConfig, i * 12 + 8);
            }
            UInt32 antConfigLen = (UInt32)antConfig.Length;
            var iret1 = ReaderAPI.UHFReader_SetAntConfig(m_handler, readeruid, antConfig, antConfigLen);

        }

        //private void CIRstartreadBtn_Click()
        //{
        //    byte ibank = 0xff;
        //    ibank = 1;
        //    byte offset = Convert.ToByte(0);
        //    byte length = Convert.ToByte(6);
        //    byte[] pwd = { 0, 0, 0, 0 };
        //    uint pwdlen = Convert.ToUInt32(pwd.Length);
        //    var iret = ReaderAPI.UHFReader_SetAutoReadParams(m_handler, readeruid, ibank, offset, length, pwd, pwdlen);
        //    if (ReaderAPI.Err_noError != iret)
        //    {
        //        MessageBox.Show(String.Format("fail to Set Automatic parameter! ErrCode:{0}", iret));
        //        return;
        //    }

        //    iret = ReaderAPI.UHFReader_StartAutoRead(m_handler, readeruid);
        //    if (ReaderAPI.Err_noError != iret)
        //    {
        //        MessageBox.Show(String.Format("fail to Start Auto read tag! ErrCode:{0}", iret));
        //        return;
        //    }
        //}

        //private void CIRstopReadBtn_Click()
        //{
        //    var iret = ReaderAPI.UHFReader_StopAutoRead(m_handler, readeruid);
        //    if (ReaderAPI.Err_noError != iret)
        //    {
        //        //MessageBox.Show(String.Format("fail to Stop Auto read tag! ErrCode:{0}", iret));
        //        return;
        //    }

        //}

        private void CIRstartreadBtn_Click()
        {
            var iret = ReaderAPI.UHFReader_Inventory(m_handler, readeruid);
            if (ReaderAPI.Err_noError != iret)
            {
                //  MessageBox.Show(String.Format("Fail to Inventory! errorcode:{0}", iret));
                return;
            }
        }

        private void CIRstopReadBtn_Click()
        {

            var iret = ReaderAPI.UHFReader_StopInventory(m_handler, readeruid);
            if (ReaderAPI.Err_noError != iret)
            {
                //      MessageBox.Show(String.Format("Fail to Stop Inventory! errorcode:{0}", iret));
                return;
            }
        }
        private void Consumer()
        {
            while (consumer_running)
            {
                if (IntPtr.Zero == m_handler)
                {
                    break;
                }

                if (!reportQueue.TryTake(out ReportData reportData, 50))
                {
                    continue;
                }

                if (reportData == null)
                {
                    break;
                }
                if ((uint)ReaderAPI.CmdCode.CmdSetTcpHeartbeatInterval == reportData.cmd_code)
                {
                    continue;
                }
                else if ((uint)ReaderAPI.CmdCode.CmdDeviceInfoReport == reportData.cmd_code)
                {

                    onReaderConnectReportProcess(reportData);


                }
                else if ((uint)ReaderAPI.CmdCode.CmdStartInventory == reportData.cmd_code)
                {
                    if (!isclient)
                        reportData.reader_id = 0;
                    if (reportData.reader_id > 0)
                    {
                        if (devsn == null)
                            continue;
                    }

                    if (reportData.reader_id != readeruid)
                        continue;
                    onTagInventoryReportProcess(reportData);
                }
                else if ((uint)ReaderAPI.CmdCode.CmdStartAutoRead == reportData.cmd_code)
                {
                    if (!isclient)
                        reportData.reader_id = 0;

                    if (reportData.reader_id > 0)
                    {
                        if (devsn == null)
                            continue;

                    }
                    if (reportData.reader_id != readeruid)
                        continue;

                    onTagAutoMaticReportProcess(reportData);
                }

            }
        }
        private void onReaderConnectReportProcess(ReportData reportData)
        {
            if (8 > reportData.data.Length)
            {
                return;
            }

            readeruid = 0;
            String device_info = System.Text.ASCIIEncoding.UTF8.GetString(reportData.data);
            String[] fields = device_info.Split(',');
            if (fields.Length == 3)
            {
                String ip = fields[0].Trim();
                String mac = fields[1].Trim();
                String name = fields[2].Trim();



            }

        }


        private void onTagInventoryReportProcess(ReportData reportData)
        {
            if (reportData.data.Length == 2)
                return;

            int buffferSize = (int)reportData.data.Length;
            string pc = Common.BytesToHexString(reportData.data, 0, 2);
            string epc = Common.BytesToHexString(reportData.data, 2, buffferSize - 7);
            uint ant = reportData.data.ElementAt(buffferSize - 3);
            String rssi = String.Format("-{0:.0}", (0xFFFF - Common.U16FromLittleEndianU8s(reportData.data, buffferSize - 2)) / 10.0);
            this.Invoke(new Action(() =>
            {
                FillData(epc, ant.ToString(), pc, "", rssi, "");
            }));


        }


        private void onTagAutoMaticReportProcess(ReportData reportData)
        {
            int buffferSize = (int)reportData.data.Length;
            if (buffferSize == 1)
                return;
            uint ibank = (uint)reportData.data[0];
            if (ibank != 1)
                return;
            int tidlen = (int)reportData.data[1];
            string tid = Common.BytesToHexString(reportData.data, 2, tidlen);
            uint ant = reportData.data.ElementAt(buffferSize - 1);
            this.Invoke(new Action(() =>
            {
                FillData(tid, ant.ToString(), "", "", "", "");
            }));
        }

        void FillData(string epc, string ant, string pc, string crc, string rssi, string per)
        {
            string RFID = (string.IsNullOrEmpty(epc) ? "" : epc).Replace(" ", "");
            if (!string.IsNullOrEmpty(RFID))
            {
                if (string.IsNullOrEmpty(TagPrefix))
                {
                    GetEPC("", RFID, "", "", "", "");
                }
                else if (RFID.Contains(Common.ConvertASCIItoHex(TagPrefix)))
                {
                    GetEPC("", RFID, "", "", "", "");
                }
            }
        }


        void ReaderCallback(byte reader_id, UInt32 report_cmd_code, IntPtr report_data, UInt32 report_data_len)
        {
            ReportData reportData = new ReportData(reader_id, report_cmd_code, null);
            if (report_data.ToInt64() != 0)
            {
                byte[] copiedData = new byte[(int)report_data_len];
                Marshal.Copy(report_data, copiedData, 0, (int)report_data_len);
                reportData.data = copiedData;
            }
            reportQueue.Add(reportData);
        }
        #endregion
    }

}
public class ScanTagDetail
{
    public long AssetTagId { get; set; }
    public string TagId { get; set; }
}
public class ResponseDefault
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public List<ImageData> Response { get; set; }

}
public class ImageData
{
    public string ImgName { get; set; }

}

public class DeleteImageData
{
    public long imgAssetId { get; set; }

}