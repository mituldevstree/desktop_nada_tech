using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech.View
{
	public partial class CheckInOutMain : UserControl
	{
		//private IntPtr handle = IntPtr.Zero;
		private DeviceFinderApi.DeviceFinder_ReportCallback deviceFinder_report_callback;
		private BindingList<DeviceInfo> _listofDeviceInfo;
		public CheckInOutMain()
		{
			InitializeComponent();

		}
		protected override void OnLoad(EventArgs e)
		{
			//Your code to run on load goes here 
			if (_listofDeviceInfo == null)
			{
				_listofDeviceInfo = new BindingList<DeviceInfo>();
			}
			if (!IsHandleCreated)
				this.CreateControl();
			Binddataintogrid();
			GetAllReader();
			// Call the base class OnLoad to ensure any delegate event handlers are still callled
			base.OnLoad(e);

		}
		private void GetAllReader()
		{
			this.deviceFinder_report_callback = new DeviceFinderApi.DeviceFinder_ReportCallback(this.DeviceFinderReportCallback);
			int num = (int)DeviceFinderApi.DeviceFinder_Open(ref Program.handle, this.deviceFinder_report_callback);
			int num1 = (int)DeviceFinderApi.DeviceFinder_Discovery(Program.handle);
		}
		List<object> _listofCheckinoutUC = new List<object>();
		public void CloseReader()
		{
			foreach (TabPage item in tabControl1.TabPages)
			{
				var tab = item.Controls;
				foreach (Control Subitem in item.Controls)
				{
					CheckInOut _CheckInOut = Subitem as CheckInOut;
					_CheckInOut.CloseConnectedReader();
					_CheckInOut.Dispose();
				}
			}
			//int num = (int)DeviceFinderApi.UHFReader_Close(ref handle1);
		}
		public void removeTab(DeviceInfo _DI)
		{
			DeviceInfo deviceInfo = _listofDeviceInfo.FirstOrDefault(w => w.Mac == _DI.Mac);
			if (deviceInfo != null)
			{
				deviceInfo.Status = "Disconnected";
				_listofDeviceInfo.ResetBindings();
				this.GrinEditDeleteDetailView.Refresh();
			}
			TabPage tabPage1 = tabControl1.SelectedTab;
			foreach (Control Subitem in tabPage1.Controls)
			{
				CheckInOut _CheckInOut = Subitem as CheckInOut;
				_CheckInOut.CloseConnectedReader();
				_CheckInOut.Dispose();
			}
			tabControl1.TabPages.Remove(tabPage1);
			//if (tabControl1.TabCount > 0)
			//{
			//	tabControl1.SelectTab(tabControl1.TabCount - 1);
			//}

		}
		private void Binddataintogrid()
		{
			this.GrinEditDeleteDetailView.Invoke((MethodInvoker)(delegate
			{
				GrinEditDeleteDetailView.DataSource = null;
				GrinEditDeleteDetailView.DataSource = _listofDeviceInfo;
				GrinEditDeleteDetailView.Columns["Gateway"].Visible = false;
				GrinEditDeleteDetailView.Columns["DHCP"].Visible = false;
				GrinEditDeleteDetailView.Columns["Port"].Visible = false;
				GrinEditDeleteDetailView.Columns["Baudrate"].Visible = false;
				GrinEditDeleteDetailView.Columns["Parity"].Visible = false;
				GrinEditDeleteDetailView.Columns["Databit"].Visible = false;
				GrinEditDeleteDetailView.Columns["Stopbit"].Visible = false;
				GrinEditDeleteDetailView.Columns["ServerIP"].Visible = false;
				GrinEditDeleteDetailView.Columns["ServerPort"].Visible = false;
				GrinEditDeleteDetailView.Columns["NetMode"].Visible = false;
			}));
		}
		private void DeviceFinderReportCallback(IntPtr report_data, uint report_data_len)
		{
			try
			{
				byte[] numArray = new byte[(int)report_data_len];
				Marshal.Copy(report_data, numArray, 0, (int)report_data_len);
				Console.WriteLine("report: " + Encoding.Default.GetString(numArray));
				Dictionary<string, string> net_config = Common.ParseNetConfig(numArray, numArray.Length);
				if (InvokeRequired)
				{

					this.Invoke((MethodInvoker)(delegate
					{
						string key = net_config["mac_address"];
						int num = -1;
						string str = "TCP Server";
						if (net_config.ContainsKey("net_mode"))
							num = int.Parse(net_config["net_mode"]);
						if (num == 0)
							str = "TCP Client";
						if (num == 1)
							str = "TCP Server";
						else if (num == 2)
							str = "HTTP Server";
						string ReaerName = net_config["name"];
						if (_listofDeviceInfo.Any(w => w.Name == ReaerName))
						{
							DeviceInfo deviceInfo = _listofDeviceInfo.FirstOrDefault(w => w.Mac == key);
							BindReaderList(deviceInfo);
						}
						else
						{
							DeviceInfo deviceInfo = new DeviceInfo()
							{
								Index = _listofDeviceInfo.Count + 1,
								Name = net_config["name"],
								Version = net_config["version"],
								IP = net_config["ip"],
								Mac = key,
								NetMode = num,
								NetMode1 = str,
								Status = "Disconnected"
							};
							BindReaderList(deviceInfo);
						}
					}));
				}
				else
				{
					string key = net_config["mac_address"];
					int num = -1;
					string str = "TCP Server";
					if (net_config.ContainsKey("net_mode"))
						num = int.Parse(net_config["net_mode"]);
					if (num == 0)
						str = "TCP Client";
					if (num == 1)
						str = "TCP Server";
					else if (num == 2)
						str = "HTTP Server";
					string ReaerName = net_config["name"];
					if (_listofDeviceInfo.Any(w => w.Name == ReaerName))
					{
						DeviceInfo deviceInfo = _listofDeviceInfo.FirstOrDefault(w => w.Mac == key);
						BindReaderList(deviceInfo);
					}
					else
					{
						DeviceInfo deviceInfo = new DeviceInfo()
						{
							Index = _listofDeviceInfo.Count + 1,
							Name = net_config["name"],
							Version = net_config["version"],
							IP = net_config["ip"],
							Mac = key,
							NetMode = num,
							NetMode1 = str,
							Status = "Disconnected"
						};
						BindReaderList(deviceInfo);
					}
				}


			}
			catch (Exception ex)
			{

			}
		}

		private void BindReaderList(DeviceInfo _deviceInfo)
		{
			DeviceInfo deviceInfo = _listofDeviceInfo.FirstOrDefault(w => w.Mac == _deviceInfo.Mac);
			if (deviceInfo != null)
			{
				deviceInfo.Name = _deviceInfo.Name;
				deviceInfo.Version = _deviceInfo.Version;
				deviceInfo.IP = _deviceInfo.IP;
				deviceInfo.Mac = _deviceInfo.Mac;
				deviceInfo.NetMode = _deviceInfo.NetMode;
				deviceInfo.NetMode1 = _deviceInfo.NetMode1;
				_listofDeviceInfo.ResetBindings();
			}
			else
			{
				_listofDeviceInfo.Add(_deviceInfo);
			}
			this.GrinEditDeleteDetailView.Refresh();
		}
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			GetAllReader();
		}

		private void CheckInOutMain_VisibleChanged(object sender, EventArgs e)
		{
			if (!Visible)
			{
				//GetAllReaderClose();
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			GetReaderDatetil();
		}
		private byte[] GetSelectedDevice() => this.GrinEditDeleteDetailView.CurrentRow == null ? (byte[])null : Encoding.Default.GetBytes(this.GrinEditDeleteDetailView.CurrentRow.Cells[1].Value.ToString());
		private void GetReaderDatetil()
		{
			this.Invoke(new Action(() =>
			{
				byte[] selectedDevice = this.GetSelectedDevice();
				if (selectedDevice == null)
					return;
				uint length1 = (uint)selectedDevice.Length;
				byte[] numArray1 = new byte[256];
				uint length2 = (uint)numArray1.Length;

				if (DeviceFinderApi.DeviceFinder_GetNetConfig(Program.handle, selectedDevice, length1, numArray1, ref length2) > 0U)
				{
					int num1 = (int)MessageBox.Show("Get failed !", "Request Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					Console.WriteLine("get net config: " + Encoding.Default.GetString(numArray1, 0, (int)length2));
					Dictionary<string, string> netConfig = Common.ParseNetConfig(numArray1, (int)length2);
					DeviceInfo deviceInfo = _listofDeviceInfo.FirstOrDefault(w => w.Mac == Encoding.Default.GetString(selectedDevice, 0, (int)length1));
					if (deviceInfo.Status != "Connected")
					{
						deviceInfo.Mask = netConfig["mask"];
						deviceInfo.Gateway = netConfig["gateway"];
						deviceInfo.DHCP = int.Parse(netConfig["dhcp"]);
						deviceInfo.Port = short.Parse(netConfig["port"]);
						deviceInfo.Baudrate = uint.Parse(netConfig["baud"]);
						deviceInfo.Parity = int.Parse(netConfig["parity"]);
						deviceInfo.Databit = int.Parse(netConfig["databits"]);
						deviceInfo.Stopbit = int.Parse(netConfig["stopbits"]);
						deviceInfo.Status = "Connected";

						tabControl1.TabPages.Add(deviceInfo.Name + " # " + deviceInfo.Mac);
						CheckInOut dev = new CheckInOut(deviceInfo, this);
						_listofCheckinoutUC.Add(dev);
						dev.Parent = tabControl1.TabPages[tabControl1.TabCount - 1];
						dev.Dock = DockStyle.Fill;
						dev.Show();
						TabPage _tp = tabControl1.TabPages[tabControl1.TabCount - 1];
						_tp.AutoScroll = true;
						_listofDeviceInfo.ResetBindings();
						tabControl1.SelectTab(tabControl1.TabCount - 1);
					}
					else
					{
						MessageBox.Show("Reader already connected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

					}

				}
			}));
		}

		private void rjButton1_Click(object sender, EventArgs e)
		{
			SelectReader _AssetSelect = new SelectReader();
			var Result = _AssetSelect.Show(SelectReader.FormMode.Add);
			if (Result == DialogResult.OK)
			{

			}
		}
	}
}
