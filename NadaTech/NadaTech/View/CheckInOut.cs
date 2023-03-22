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
	public partial class CheckInOut : UserControl
	{
		private NadaTechEntities _Entities = new NadaTechEntities();
		private BindingList<PartMaster> _ListOfPartMaster;
		private sqlhelper _obj = new sqlhelper();
		private BindingList<TagReader> _ListTagReader = new BindingList<TagReader>();
		private int duration = 8;
		private DeviceInfo deviceInfo;
		private CheckInOutMain _CheckInOutMain;
		private System.Windows.Forms.Timer timer1;
		public CheckInOut(DeviceInfo _deviceInfo, object _CheckInOutmainform)
		{
			InitializeComponent();
			deviceInfo = _deviceInfo;
			_CheckInOutMain = _CheckInOutmainform as CheckInOutMain;
			timer1 = new System.Windows.Forms.Timer();
			timer1.Tick += new EventHandler(count_down);
			timer1.Interval = 1000;

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

		}
		BindingList<LocationMaster> _listLocation = new BindingList<LocationMaster>();

		public void CloseConnectedReader()
		{
			CIDisConnectReader();
		}

		private void UserControl1_Load(object sender, EventArgs e)
		{
			ReaderConnorDisconn(false);
			if (deviceInfo != null)
			{
				CIReaderConnect(deviceInfo.IP, deviceInfo.Port);
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
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private void BindDataGrid(string TagId, string LocationCode)
		{
			LocationCode = deviceInfo.Mac;
			#region SqlParameter
			SqlParameter[] _Para =
			{
							new SqlParameter("@Action",1),
							new SqlParameter("@TagData",TagId),
							new SqlParameter("@LocationCode",LocationCode)
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

		private void SaveData()
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				duration = 8;
				CIRstopReadBtn_Click();
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
						if (_AssetTagDetail != null)
						{
							TransactionHeader transactionHeader = new TransactionHeader();
							transactionHeader.TransactionType = item.ToStatus;
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
					}
					_Entities.SaveChanges();
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
				CIRstartreadBtn_Click();
				timer1.Stop();
				label1.Text = "(" + duration.ToString() + " Sec)";
			}
		}

		private void ReaderConnorDisconn(bool status)
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


		private BindingList<ScanTagDetail> _listRFIDDATA = new BindingList<ScanTagDetail>();
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
		}

		#region CIRFID FIXED READER
		private volatile IntPtr m_handler = IntPtr.Zero;
		private Thread consumerThread = null;
		private BlockingCollection<ReportData> reportQueue = new BlockingCollection<ReportData>(new ConcurrentQueue<ReportData>());
		private ReaderAPI.UHFReaderReportCallback uhfReaderCallbackin;
		private volatile bool consumer_running = false;
		private bool isclient = false;
		private byte readeruid = 0;
		private String devsn;
		private System.Windows.Forms.Timer CItimer1;
		private int CIRduration = 0;

		void CIReaderConnect(string IP, int Port)
		{
			this.Cursor = Cursors.WaitCursor;
			uhfReaderCallbackin = new ReaderAPI.UHFReaderReportCallback(ReaderCallbackin);
			string devinfo = "";
			string CIRIp = IP;
			int DevicePort = Port;
			//ConfigMaster _CIRFIDFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREIP");
			//if (_CIRFIDFIXEDREIP != null)
			//{
			//	CIRIp = _CIRFIDFIXEDREIP.ConfigValues;
			//}
			//ConfigMaster _CIRFIDFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREPORT");
			//if (_CIRFIDFIXEDREPORT != null)
			//{
			//	if (!string.IsNullOrEmpty(_CIRFIDFIXEDREPORT.ConfigValues))
			//	{
			//		DevicePort = Convert.ToInt32(_CIRFIDFIXEDREPORT.ConfigValues);
			//	}
			//}
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
				//setCIRFIDAntPower();
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
		private void setCIRFIDAntPower()
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
			btnStartScan.Visible = false;
			btnStopScan.Visible = true;

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
			btnStopScan.Visible = false;
			btnStartScan.Visible = true;

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

		private void FillData(string epc, string ant, string pc, string crc, string rssi, string per)
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

		private void btnStartScan_Click(object sender, EventArgs e)
		{
			CIRstartreadBtn_Click();
		}

		private void btnStopScan_Click(object sender, EventArgs e)
		{
			CIRstopReadBtn_Click();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			CIRstopReadBtn_Click();
			_CheckInOutMain.removeTab(deviceInfo);
		}
	}
}


