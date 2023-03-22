using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralCodeLibrary;
using NadaTech.Data;
using ReaderDemo;
using RFID_Reader;
using RFID_Reader_Cmds;
using xSocketDLL;

namespace NadaTech.View
{
    public partial class CheckIn : UserControl
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<PartMaster> _ListOfPartMaster;
        sqlhelper _obj = new sqlhelper();
        MasterForm _Mainform;
        BindingList<TagReader> _ListTagReader = new BindingList<TagReader>();
        private int duration = 8;
        public System.Windows.Forms.Timer timer1;
        public CheckIn(object _mainform)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(count_down);
            timer1.Interval = 1000;
            string lIp = GetReaderDeviceAddrs();

            GrinEditDeleteDetailView.DataSource = null;
            GrinEditDeleteDetailView.DataSource = _ListTagReader;
            GrinEditDeleteDetailView.Columns["AssetTagId"].Visible = false;
            GrinEditDeleteDetailView.Columns["ToStatus"].Visible = false;
            GrinEditDeleteDetailView.Columns["FromLocationId"].Visible = false;
            GrinEditDeleteDetailView.Columns["ToLocationId"].Visible = false;
            GrinEditDeleteDetailView.Columns["IsMoveable"].Visible = false;
            GrinEditDeleteDetailView.Columns["TraStatus"].Visible = false;
            GrinEditDeleteDetailView.Columns["Person"].Visible = false;
            GrinEditDeleteDetailView.Columns["Note"].Visible = false;
            if (Program.locationMaster!=null)
            {
                _selectLocation = Program.locationMaster;
                txtLocation.Texts = _selectLocation.Name;   
            }
        }
        BindingList<LocationMaster> _listLocation = new BindingList<LocationMaster>();

      
        private void UserControl1_Load(object sender, EventArgs e)
        {
            ReaderConnorDisconn(false);
            if (_Mainform != null && _Mainform._selectReader != null)
            {
                MainDeviceConnect();
            }
        }
        private void count_down(object sender, EventArgs e)
        {

            if (duration == 0)
            {
                timer1.Stop();
                duration = 8;
                label1.Text = "(" + duration.ToString() + " Sec)";
                SaveData();
            }
            else if (duration > 0)
            {
                duration--;
                label1.Text = "(" + duration.ToString() + " Sec)";
            }
        }
        private void btnStopScan_Click(object sender, EventArgs e)
        {

        }
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private void BindDataGrid(string TagId, string LocationCode)
        {

            if (_selectLocation ==null && string.IsNullOrEmpty(LocationCode))
            {
                MainReaderDisconnect();
                timer1.Stop();
                RJMessageBox.Show("Select Location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LocationMaster _LocationMasterM = null;
            if (_selectLocation!=null)
            {
                _LocationMasterM = _selectLocation;
            }
            #region SqlParameter
            SqlParameter[] _Para =
            {
                            new SqlParameter("@Action",1),
                            new SqlParameter("@TagData",TagId),
                            new SqlParameter("@LocationCode",(string.IsNullOrEmpty(LocationCode)? _LocationMasterM.Code:LocationCode))
                 };

            #endregion
            DataTable Dt = _obj.GetDataTable(CommandType.StoredProcedure, "SP_GetAssettagdata", _Para);
            TagReader _TagReader = Dt.AsEnumerable().Select(s => new TagReader
            {
                AssetTagId = s.Field<long>("AssetTagId"),
                PartNumber = s.Field<string>("PartNumber"),
                Description = s.Field<string>("Description"),
                AssetName = s.Field<string>("AssetName"),
                TagData = s.Field<string>("TagData"),
                FromLocation = s.Field<string>("FromLocation"),
                FromLocationId = s.Field<int?>("FromLocationId"),
                Status = s.Field<string>("Status"),
                ToLocation = s.Field<string>("ToLocation"),
                ToLocationId = s.Field<int>("ToLocationId"),
                ToStatus = s.Field<int>("ToStatus"),
                IsMoveable = s.Field<bool>("IsMoveable"),
                Note = "",
                Person = "",
                TraStatus = "A"
            }).FirstOrDefault();
            if (_ListTagReader == null)
            {
                _ListTagReader = new BindingList<TagReader>();
            }

            if (_TagReader != null)
            {
                _ListTagReader.Add(_TagReader);
                _ListTagReader.ResetBindings();
            }


        }



        void SaveData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MainStopReadTag();
                duration = 8;
                timer1.Stop();
                label1.Text = "(" + duration.ToString() + " Sec)";

                if (_ListTagReader.Where(w => w.IsMoveable == false && w.Status == "Checkout").Count() > 0)
                {
                    NonMoveable _NonMoveable = new NonMoveable();
                    var Result = _NonMoveable.Show(NonMoveable.FormMode.Add, _ListTagReader.Where(w => w.IsMoveable == false && w.Status == "Checkout").ToList());
                    foreach (var item in _NonMoveable._ListOfTagReader)
                    {
                        _ListTagReader.Where(w => w.AssetTagId == item.AssetTagId).ToList().ForEach(subitem =>
                        {
                            subitem.Note = item.Note;
                            subitem.Person = item.Person;
                            subitem.TraStatus = item.TraStatus;
                        });
                    }
                    this.Cursor = Cursors.WaitCursor;
                }

                string Assetcheckin = "";
                if (_ListTagReader.Count() > 0)
                {
                    foreach (var item in _ListTagReader)
                    {
                        AssetTagDetail _AssetTagDetail = _Entities.AssetTagDetails.FirstOrDefault(f => f.AssetTagId == item.AssetTagId && f.IsDelete == false);
                        if (_AssetTagDetail.AssetStatus != "1")
                        {
                            TransactionHeader transactionHeader = new TransactionHeader();
                            transactionHeader.TransactionType = 1;
                            transactionHeader.TransactionDate = DateTime.Now;
                            transactionHeader.Notes = item.Note;
                            transactionHeader.Status = item.TraStatus;
                            transactionHeader.Person = item.Person;
                            transactionHeader.ScanType = (int)Common.ScanType.Desktop;
                            transactionHeader.IsDelete = false;
                            transactionHeader.CreateDate = DateTime.Now;
                            transactionHeader.CreatedBy = Program.UserId;
                            transactionHeader.ModifiedBy = Program.UserId;
                            transactionHeader.ModifiedDate = DateTime.Now;
                            _Entities.TransactionHeaders.Add(transactionHeader);

                            TransactionDetail transactionDetail = new TransactionDetail();
                            transactionDetail.AssetTagId = item.AssetTagId;
                            transactionDetail.LocationId = (transactionHeader.TransactionType == 1 ? item.ToLocationId : _AssetTagDetail.LocationId);
                            transactionDetail.LastLocationId = (transactionHeader.TransactionType == 1 ? _AssetTagDetail.LastLocationId : _AssetTagDetail.LocationId);
                            transactionDetail.IsDelete = false;
                            transactionDetail.AssetTagId = item.AssetTagId;
                            transactionDetail.CreateDate = DateTime.Now;
                            transactionDetail.CreatedBy = Program.UserId;
                            transactionDetail.ModifiedBy = Program.UserId;
                            transactionDetail.ModifiedDate = DateTime.Now;
                            transactionHeader.TransactionDetails.Add(transactionDetail);
                            if (transactionHeader.Status == "A")
                            {
                                if (transactionHeader.TransactionType == 1)
                                {
                                    _AssetTagDetail.AssetStatus = "1";
                                    //_AssetTagDetail.LastLocationId = _AssetTagDetail.LocationId;
                                    _AssetTagDetail.LocationId = item.ToLocationId;
                                    _AssetTagDetail.ModifiedDate = DateTime.Now;
                                    _AssetTagDetail.ModifiedBy = Program.UserId;
                                }
                                else
                                {
                                    _AssetTagDetail.AssetStatus = "2";
                                    _AssetTagDetail.LastLocationId = _AssetTagDetail.LocationId;
                                    _AssetTagDetail.LocationId = null;
                                    _AssetTagDetail.ModifiedDate = DateTime.Now;
                                    _AssetTagDetail.ModifiedBy = Program.UserId;
                                }
                            }
                        }
                        else
                        {
                            Assetcheckin += "Asset : " + _AssetTagDetail.AssetMaster.AssetName + " Tag : " + _AssetTagDetail.TagData + "\r\n";
                        }
                    }
                    _Entities.SaveChanges();
                }
                if (!string.IsNullOrEmpty(Assetcheckin.Trim()))
                {
                    var msgresult = RJMessageBox.Show("Asset already checkin at other location. First You need to checkout from there. \r\n" + Assetcheckin, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (msgresult == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _ListTagReader.Clear();
                _ListTagReader.ResetBindings();
                this.Cursor = Cursors.Default;
                MainStartReadTag();
                timer1.Stop();
                label1.Text = "(" + duration.ToString() + " Sec)";
            }
        }

        private void GrinEditDeleteDetailView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Edit")
            {

            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainReaderDisconnect();
            timer1.Stop();
            if (_selectLocation == null)
            {
                RJMessageBox.Show("Select Location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            AssetSelect _AssetSelect = new AssetSelect();
            var Result = _AssetSelect.Show(AssetSelect.FormMode.Add, 2);
            if (Result == DialogResult.OK)
            {
                string Tag = _AssetSelect._selectManualTagReader.TagData;
                //string Tolocation = _AssetSelect._selectManualTagReader.ToLocation;
                //string ToLocationName = _AssetSelect._selectManualTagReader.ToLocationName;
                //int ToLocationId = _AssetSelect._selectManualTagReader.ToLocationId;
                if (_ListTagReader.Where(w => w.TagData == Tag).Count() > 0)
                {
                    //_ListTagReader.Where(_w => _w.TagData == Tag).ToList().ForEach(w => { w.ToLocation = ToLocationName; w.ToLocationId = ToLocationId; });
                    _ListTagReader.ResetBindings();
                }
                else
                {
                    BindDataGrid(Tag, "");
                }
                if (_ListTagReader.Count() > 0)
                {
                    timer1.Start();
                }
                MainReaderConnect();
            }
            else
            {
                if (_ListTagReader.Count() > 0)
                {
                    timer1.Start();
                }
                MainReaderConnect();

            }
        }

        void MainDeviceConnect()
        {
            if (_Mainform != null && _Mainform._selectReader != null)
            {
                if (_Mainform == null || _Mainform._selectReader.id == 1)
                {
                    //string Devadd = GetReaderDeviceAddrs();
                    //LocationMaster locationMaster = _Entities.LocationMasters.FirstOrDefault(f => f.Code == Devadd && f.IsDelete == false);

                    rpClient = new xClient();
                    //if (locationMaster != null)
                    //{
                    InitAddEvent(rp_PaketReceived); // Add a EventHandler
                    MainReaderConnect();
                    if (rpClient.bConnectSockFlag)
                    {
                        GetReaderDeviceAddr();
                    }
                    //}
                    //else
                    //{
                    //    RJMessageBox.Show("Device not map with Location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    MainReaderDisconnect();
                    //}

                }
                else if (_Mainform._selectReader.id == 2)
                {
                    ChangeUHFAPI(true);
                    ChaiUsbStartEPC();
                }
                else if (_Mainform._selectReader.id == 3)
                {
                    CIReaderConnect();
                }
            }
        }

        public void MainDeviceDisconnect()
        {
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
                    IsdisconnectReader = true;
                }
            }
        }

        void MainReaderConnect()
        {
            if (_Mainform != null && _Mainform._selectReader != null)
            {
                if (_Mainform == null || _Mainform._selectReader.id == 1)
                {
                    ConnectReader();
                }
                else if (_Mainform._selectReader.id == 2)
                {
                    ChaiUsbStartEPC();
                }
                else if (_Mainform._selectReader.id == 3)
                {
                    CIRstartreadBtn_Click();
                    IsdisconnectReader = false;
                    ReaderConnorDisconn(true);
                }
            }
        }
        bool IsdisconnectReader = false;
        public void MainReaderDisconnect()
        {
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
                    CIRstopReadBtn_Click();
                    IsdisconnectReader = true;
                    ReaderConnorDisconn(false);
                }
            }
        }

        void MainStartReadTag()
        {
            if (_Mainform != null && _Mainform._selectReader != null)
            {
                if (_Mainform == null || _Mainform._selectReader.id == 1)
                {
                    Readtag();
                }
                else if (_Mainform._selectReader.id == 2)
                {
                    ChaiUsbStartEPC();
                }
                else if (_Mainform._selectReader.id == 3)
                {
                    CIRstartreadBtn_Click();
                }
            }
        }

        void MainStopReadTag()
        {
            if (_Mainform != null && _Mainform._selectReader != null)
            {
                if (_Mainform == null || _Mainform._selectReader.id == 1)
                {
                    StopReadTag();
                }
                else if (_Mainform._selectReader.id == 2)
                {
                    ChainwayUsebStopEPC(true);
                }
                else if (_Mainform._selectReader.id == 2)
                {
                    CIRstopReadBtn_Click();

                }
            }
        }

        void ReaderConnorDisconn(bool status)
        {
            if (status == true)
            {
                labDevicestatus.Text = "Device Connected";
                labDevicestatus.ForeColor = Color.Green;
            }
            else
            {
                labDevicestatus.ForeColor = Color.Red;
                labDevicestatus.Text = "Device Disconnected";
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
                //MessageBox.Show("Server has not been connected!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                ReaderConnorDisconn(true);
            }
            else
            {
                ReaderConnorDisconn(false);

            }


        }
        public void StopReader()
        {
            if (rpClient.bConnectSockFlag == true)
            {
                if (threadClient.IsAlive)
                {
                    threadClient.Abort();
                }
                if (threadFramePaser.IsAlive)
                {
                    threadFramePaser.Abort();
                }

                StopReadTag();
                rpClient.SocketClose();
                bConnectToServerFlag = false;
                ReaderConnorDisconn(false);
            }
        }


        void Readtag()
        {
            if (rpClient.bConnectSockFlag)
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

        }
        void StopReadTag()
        {
            if (rpClient.bConnectSockFlag)
            {
                txtSend.Text = Commands.RFID_Q_StopRead(ReaderDeviceAddress);
                NetSendCommand(txtSend.Text);//NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);
                Thread.Sleep(200);
                //txtSend.Text = Commands.RFID_Q_StopRead(ReaderDeviceAddress);
                //NetSendCommand(txtSend.Text);//NetSendCommand(txtSend.Text);//Sp.GetInstance().Send(frame);
            }
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
        private ReaderWriterLock _rwlock = new ReaderWriterLock();

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

                    //MessageBox.Show("RecvMsgThread Error:" + ex.Message + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        //MessageBox.Show("Frame Parser Error:" + ex.Message + "!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (_ListTagReader.Where(w => w.TagData == epc).Count() == 0)
            {
                duration = 8;
                timer1.Stop();
                timer1.Start();

                BindDataGrid(epc, "");

            }
            //if (_listRFIDDATA.Where(w => w.TagId == epc).Count() > 0)
            //{
            //    ScanTagDetail _RFIDDATA = _listRFIDDATA.FirstOrDefault(w => w.TagId == epc);
            //    _listRFIDDATA.ResetBindings();
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(epc))
            //    {
            //        _listRFIDDATA.Add(new ScanTagDetail { TagId = epc });
            //        GrinEditDeleteDetailView.DataSource = _listRFIDDATA;
            //        GrinEditDeleteDetailView.Columns["AssetTagId"].Visible = false;

            //    }

            //}

        }



        #endregion

        #region Chainway USB Reader

        private Thread ChainwaythreadFramePaser;
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

            bool usbConnect = uhf.Open();
            if (usbConnect)
            {
                ReaderConnorDisconn(true);
                if (!isRuning && isComplete)
                {
                    isRuning = true;
                    isComplete = false;

                    if (uhf.Inventory())
                    {
                        ChainwaythreadFramePaser = new Thread(new ThreadStart(delegate { ChainwayUsebReadEPC(); }));
                        ChainwaythreadFramePaser.IsBackground = true;
                        ChainwaythreadFramePaser.Start();
                    }
                }
            }
            else
            {
                //RJMessageBox.Show("Chainway USB Reader not connected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReaderConnorDisconn(false);
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
                    GetEPC("", RFID, "", "", "", "");

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

                    if (ChainwaythreadFramePaser != null && ChainwaythreadFramePaser.IsAlive)
                    {
                        ChainwaythreadFramePaser.Abort();
                    }
                    ReaderConnorDisconn(false);
                    isRuning = false;
                    isComplete = true;
                    uhf.Close();
                }
            }
        }



        #endregion

        #region CIRFID FIXED READER
        private volatile IntPtr m_handler = IntPtr.Zero;
        private Thread consumerThread = null;
        private BlockingCollection<ReportData> reportQueue = new BlockingCollection<ReportData>(new ConcurrentQueue<ReportData>());
        private ReaderAPI.UHFReaderReportCallback uhfReaderCallbackin;
        private volatile bool consumer_running = false;
        bool isclient = false;
        byte readeruid = 0;
        private String devsn;
        System.Windows.Forms.Timer CItimer1;
        int CIRduration = 0;

        void CIReaderConnect()
        {
            this.Cursor = Cursors.WaitCursor;
            uhfReaderCallbackin = new ReaderAPI.UHFReaderReportCallback(ReaderCallbackin);
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

            CItimer1 = new System.Windows.Forms.Timer();
            CItimer1.Tick += new EventHandler(CIRcount_down);
            CItimer1.Interval = 250;
            CItimer1.Start();

        }
        private void CIRcount_down(object sender, EventArgs e)
        {

            CIRduration++;
            if (CIRduration == 1)
            {
                CItimer1.Stop();
                CIRstartreadBtn_Click();
                ReaderConnorDisconn(true);
                this.Cursor = Cursors.Default;
            }

        }
        void CIDisConnectReader()
        {

            CIRstopReadBtn_Click();
            consumer_running = false;
            reportQueue.Add(null);
            if (consumerThread != null && consumerThread.IsAlive)
            {
                consumerThread.Abort();
            }
            consumerThread = null;
            uhfReaderCallbackin = null;
            ReaderAPI.UHFReader_Close(ref m_handler);
            m_handler = IntPtr.Zero;
            //clearInventoryBtn_Click(null, null);
            while (reportQueue.TryTake(out ReportData _)) ;


            ReaderConnorDisconn(false);



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
                var iret = ReaderAPI.UHFReader_Connect(ref m_handler, devinfo, len, uhfReaderCallbackin);
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
        private void CIRstartreadBtn_Click()
        {
            var iret = ReaderAPI.UHFReader_Inventory(m_handler, readeruid);
            if (ReaderAPI.Err_noError != iret)
            {
                MessageBox.Show(String.Format("Fail to Inventory! errorcode:{0}", iret));
                return;
            }
            ReaderConnorDisconn(true);

        }

        private void CIRstopReadBtn_Click()
        {
            var iret = ReaderAPI.UHFReader_StopInventory(m_handler, readeruid);
            if (ReaderAPI.Err_noError != iret)
            {
                //      MessageBox.Show(String.Format("Fail to Stop Inventory! errorcode:{0}", iret));
                return;
            }
            ReaderConnorDisconn(false);

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
            this.BeginInvoke((MethodInvoker)(delegate
            {
                int buffferSize = (int)reportData.data.Length;
                string pc = Common.BytesToHexString(reportData.data, 0, 2);
                string epc = Common.BytesToHexString(reportData.data, 2, buffferSize - 7);
                uint ant = reportData.data.ElementAt(buffferSize - 3);
                String rssi = String.Format("-{0:.0}", (0xFFFF - Common.U16FromLittleEndianU8s(reportData.data, buffferSize - 2)) / 10.0);

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

                GetEPC("", RFID, "", "", "", "");

            }
        }


        private void ReaderCallbackin(byte reader_id, UInt32 report_cmd_code, IntPtr report_data, UInt32 report_data_len)
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

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }

     
        LocationMaster _selectLocation;
        private void btnSearchLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsdisconnectReader)
                {
                    MainReaderDisconnect();
                }
                timer1.Stop();
                SearchFrom _AssetType = new SearchFrom();
                var Result = _AssetType.Show(SearchFrom.FormMode.Add, "Location");
                if (Result == DialogResult.OK)
                {
                    _selectLocation = _AssetType._SelectSearchData as LocationMaster;
                    txtLocation.Texts = _selectLocation.Name;
                    MainReaderConnect();
                    if (_ListTagReader.Count() > 0)
                    {
                        timer1.Start();
                    }

                }
                else
                {
                    txtLocation.Texts = "";
                    _selectLocation = null;
                    MainReaderConnect();

                }
            }
            catch (Exception)
            {

            }
            finally
            {
                MainReaderConnect();
            }
        }
    }
}


public class TagReader
{
    public long AssetTagId { get; set; }
    public string PartNumber { get; set; }
    public string Description { get; set; }
    public string AssetName { get; set; }
    public int? FromLocationId { get; set; }
    public string FromLocation { get; set; }
    public string TagData { get; set; }
    public string Status { get; set; }
    public string ToLocation { get; set; }
    public int? ToLocationId { get; set; }
    public int ToStatus { get; set; }
    public bool IsMoveable { get; set; }
    public string TraStatus { get; set; }
    public string Note { get; set; }
    public string Person { get; set; }

}