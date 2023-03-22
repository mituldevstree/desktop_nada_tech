using NadaTech.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech.View
{
    public partial class SelectReader : Form
    {
		private DeviceFinderApi.DeviceFinder_ReportCallback deviceFinder_report_callback;
		private BindingList<DeviceInfo> _listofDeviceInfo;
		FormMode formMode;
        public SelectReader()
        {
            InitializeComponent();

        }
        internal enum FormMode
        {
            Add, Edit, View
        }
        int AssetStatus = 0;
        internal DialogResult Show(FormMode formMode)
        {
          
            if (formMode == FormMode.Add)
            {
                this.formMode = formMode;
				if (_listofDeviceInfo == null)
				{
					_listofDeviceInfo = new BindingList<DeviceInfo>();
				}
				Binddataintogrid();
				GetAllReader();
				return base.ShowDialog();
            }
            else if (formMode == FormMode.Edit)
            {
                this.formMode = formMode;
                return base.ShowDialog();
            }
            return DialogResult.Cancel;

        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                return true;
            }
            if (msg.WParam.ToInt32() == (int)Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

		private void GetAllReader()
		{
			this.deviceFinder_report_callback = new DeviceFinderApi.DeviceFinder_ReportCallback(this.DeviceFinderReportCallback);
			int num = (int)DeviceFinderApi.DeviceFinder_Open(ref Program.handle, this.deviceFinder_report_callback);
			int num1 = (int)DeviceFinderApi.DeviceFinder_Discovery(Program.handle);
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
					this.GrinEditDeleteDetailView.Invoke((MethodInvoker)(delegate
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
				deviceInfo.IP = _deviceInfo.Version;
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


		private void GrinEditDeleteDetailView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    if (true)
                    {

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        RJMessageBox.Show("Select Asset.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    RJMessageBox.Show("Select Asset.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}


