using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NadaTech.View;
using NadaTech.Data;
using xSocketDLL;
using ReaderDemo;
using System.Collections.Concurrent;

namespace NadaTech
{
	public partial class MasterForm : Form
	{
		object openform;
		NadaTechEntities _Entities = new NadaTechEntities();

		public MasterForm()
		{
			InitializeComponent();

			FLPanelMenu.AutoScroll = false;
			FLPanelMenu.HorizontalScroll.Enabled = false;
			FLPanelMenu.HorizontalScroll.Visible = false;
			FLPanelMenu.HorizontalScroll.Maximum = 0;
			FLPanelMenu.AutoScroll = true;
			LblUserName.Text = Program.UserMaster.Name;
			uhfReaderCallback = new ReaderAPI.UHFReaderReportCallback(ReaderCallback);

			FillReaderList();
			hideSubMenu();
			GetUserPermission();
			this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
		}
		private void btnMenu_Click(object sender, EventArgs e)
		{
			if (MenuVertical.Width == 250)
			{
				MenuVertical.Width = 70;
			}
			else
				MenuVertical.Width = 250;
		}
		List<CompanyReader> _listCompanyReader = new List<CompanyReader>();
		void FillReaderList()
		{
			if (CheckDevice(1) == true)
			{
				_listCompanyReader.Add(new CompanyReader { id = 1, Name = "SYSIOT UHF FIXED READER" });
			}
			if (CheckDevice(2) == true)
			{
				_listCompanyReader.Add(new CompanyReader { id = 2, Name = "CHAINWAY R3 USB READER" });
			}
			//if (CheckDevice(3) == true)
			//{
			//	_listCompanyReader.Add(new CompanyReader { id = 3, Name = "CIRFID RF946 FIXED READER" });
			//}
			CmbReader.DataSource = _listCompanyReader;
			CmbReader.DisplayMember = "Name";
			CmbReader.ValueMember = "Id";
			if (_listCompanyReader.Count() > 0)
			{
				CmbReader.SelectedIndex = 0;
			}
		}

		#region CIRFID
		bool CheckDevice(int type)
		{
			bool IsConnect = false;

			if (type == 1)
			{
				xClient rpClient = new xClient();

				string textBox_IP = "192.168.0.200";
				int textBox_Port = 200;
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
					IsConnect = true;
					rpClient.SocketClose();
				}

			}
			else if (type == 2)
			{
				RFID_Reader.IUHF uhf = RFID_Reader.UHFAPIOfUsb.getInstance();
				bool usbConnect = uhf.Open();
				if (usbConnect)
				{
					IsConnect = true;
					uhf.Close();
				}
			}
			else if (type == 3)
			{
				string CiRFIDIP = "192.168.1.30";
				int DevicePort = 20058;
				ConfigMaster _CIRFIDFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREIP");
				if (_CIRFIDFIXEDREIP != null)
				{
					CiRFIDIP = _CIRFIDFIXEDREIP.ConfigValues;
				}
				ConfigMaster _CIRFIDFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREPORT");
				if (_CIRFIDFIXEDREPORT != null)
				{
					if (!string.IsNullOrEmpty(_CIRFIDFIXEDREPORT.ConfigValues))
					{
						DevicePort = Convert.ToInt32(_CIRFIDFIXEDREPORT.ConfigValues);
					}
				}
				string devinfo = string.Format("CommType=NET;RemoteIp={0};RemotePort={1}", CiRFIDIP, DevicePort);
				if (ConnectDev(devinfo))
				{
					IsConnect = true;
					DisConnectDev();
				}
			}
			return IsConnect;

		}
		private volatile IntPtr m_handler = IntPtr.Zero;
		private ReaderAPI.UHFReaderReportCallback uhfReaderCallback;
		private BlockingCollection<ReportData> reportQueue = new BlockingCollection<ReportData>(new ConcurrentQueue<ReportData>());
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
					m_handler = IntPtr.Zero;
					return false;
				}

				return true;
			}
			catch (Exception ex)
			{

				throw;
			}
			// GetConfig();
		}
		private bool DisConnectDev()
		{
			if (IntPtr.Zero == m_handler)
			{
				return false;
			}
			reportQueue.Add(null);
			ReaderAPI.UHFReader_Close(ref m_handler);
			m_handler = IntPtr.Zero;
			return true;
		}
		private void ReaderCallback(byte reader_id, UInt32 report_cmd_code, IntPtr report_data, UInt32 report_data_len)
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

		private void iconcerrar_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void iconmaximizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;

		}

		private void iconrestaurar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;

		}
		void GetUserPermission()
		{
			NadaTechEntities _Entities = new NadaTechEntities();
			BindingList<UserPermission> Um = new BindingList<UserPermission>(_Entities.UserPermissions.Where(w => w.UserGroupId == Program.UserGroupId).ToList());
			//Home Menu
			PnlHome.Visible = true;
			MbtnDashbord.Visible = true;
			SetColor(MbtnDashbord);
			openform = new Dashboard();
			AbrirFormEnPanel(openform, "Dashboard");

			//if (Um.Where(w => w.FormMaster.Module == "HOME").Count() > 0)
			//{
			//    PnlHome.Visible = true;
			//}
			//else
			//{
			//    PnlHome.Visible = false;
			//}
			//if (Um.Where(w => w.FormMaster.MenuName == MbtnDashbord.Text.Trim()).Count() > 0)
			//{
			//    MbtnDashbord.Visible = true;
			//    AbrirFormEnPanel(new Dashboard(), "Dashboard");
			//    SetColor(MbtnDashbord);
			//}
			//else
			//{
			//    MbtnDashbord.Visible = false;
			//}
			//Manage Asset
			if (Um.Where(w => w.FormMaster.Module == "MANAGE ASSET").Count() > 0)
			{
				PnlManageAsset.Visible = true;
			}
			else
			{
				PnlManageAsset.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MbtnCreateAsset.Text.Trim()).Count() > 0)
			{
				MbtnCreateAsset.Visible = true;
			}
			else
			{
				MbtnCreateAsset.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MbtnManageAsset.Text.Trim()).Count() > 0)
			{
				MbtnManageAsset.Visible = true;
			}
			else
			{
				MbtnManageAsset.Visible = false;
			}
			//Admin
			if (Um.Where(w => w.FormMaster.Module == "ADMIN").Count() > 0)
			{
				PnlAdmin.Visible = true;
			}
			else
			{
				PnlAdmin.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MbtnPartMaster.Text.Trim()).Count() > 0)
			{
				MbtnPartMaster.Visible = true;
			}
			else
			{
				MbtnPartMaster.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MBtnLocation.Text.Trim()).Count() > 0)
			{
				MBtnLocation.Visible = true;
			}
			else
			{
				MBtnLocation.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MbtnEmployee.Text.Trim()).Count() > 0)
			{
				MbtnEmployee.Visible = true;
			}
			else
			{
				MbtnEmployee.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MbtnEmployeeRole.Text.Trim()).Count() > 0)
			{
				MbtnEmployeeRole.Visible = true;
			}
			else
			{
				MbtnEmployeeRole.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MBtnConfiguration.Text.Trim()).Count() > 0)
			{
				MBtnConfiguration.Visible = true;
			}
			else
			{
				MBtnConfiguration.Visible = false;
			}
			//Transaction

			if (Um.Where(w => w.FormMaster.Module == "TRANSACTION").Count() > 0)
			{
				PnlTransaction.Visible = true;
			}
			else
			{
				PnlTransaction.Visible = false;
			}

			if (Um.Where(w => w.FormMaster.MenuName == "Check In").Count() > 0)
			{
				MbtnCheckinout.Visible = true;
			}
			else
			{
				MbtnCheckinout.Visible = false;
			}

			//if (Um.Where(w => w.FormMaster.MenuName == MbtnCheckOut.Text.Trim()).Count() > 0)
			//{
			//	MbtnCheckOut.Visible = true;
			//}
			//else
			//{
			//	MbtnCheckOut.Visible = false;
			//}
			MbtnCheckOut.Visible = false;

			//REPORTS

			if (Um.Where(w => w.FormMaster.Module == "REPORTS").Count() > 0)
			{
				PnlReport.Visible = true;
			}
			else
			{
				PnlReport.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MbtnReports.Text.Trim()).Count() > 0)
			{
				MbtnReports.Visible = true;
			}
			else
			{
				MbtnReports.Visible = false;
			}
			if (Um.Where(w => w.FormMaster.MenuName == MbtnTransactionReports.Text.Trim()).Count() > 0)
			{
				MbtnTransactionReports.Visible = true;
			}
			else
			{
				MbtnTransactionReports.Visible = false;
			}




		}
		private void iconminimizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
		{
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}

		private void AbrirFormEnPanel(object Formhijo, string Title)
		{
			this.Cursor = Cursors.WaitCursor;
			if (this.tableLayoutPanel1.Controls.Count > 0)
				this.tableLayoutPanel1.Controls.RemoveAt(0);
			tableLayoutPanel1.Controls.Clear();
			UserControl fh = Formhijo as UserControl;
			fh.Dock = DockStyle.Fill;
			tableLayoutPanel1.Controls.Add(fh);
			//fh.TopLevel = false;
			//fh.Dock = DockStyle.Fill;
			//this.tableLayoutPanel1.Controls.Add(fh);
			//this.tableLayoutPanel1.Tag = fh;
			//fh.Show();
			labTitle.Text = Title;
			this.Cursor = Cursors.Default;


		}
		private void hideSubMenu()
		{
			labTitle.Text = "";
			//panelMediaSubMenu.Visible = false;

		}
		private void showSubMenu(Panel subMenu)
		{
			if (subMenu.Visible == false)
			{
				hideSubMenu();
				subMenu.Visible = true;
			}
			else
				subMenu.Visible = false;
		}

		private void btnlogoInicio_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			btnlogoInicio_Click(null, e);
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			FormWindowState _FormWindowState = this.WindowState;
			if (this.WindowState == FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Maximized;
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
				this.WindowState = FormWindowState.Normal;

			}
		}

		private void pictureBox1_Click(object sender, MouseEventArgs e)
		{
			FormWindowState _FormWindowState = this.WindowState;
			if (this.WindowState == FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Maximized;
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
				this.WindowState = FormWindowState.Normal;

			}
		}
		void ClearColor()
		{
			MbtnDashbord.BackColor = Color.Transparent;
			MbtnCreateAsset.BackColor = Color.Transparent;
			MbtnManageAsset.BackColor = Color.Transparent;
			MbtnPartMaster.BackColor = Color.Transparent;
			MBtnLocation.BackColor = Color.Transparent;
			MbtnEmployee.BackColor = Color.Transparent;
			MbtnEmployeeRole.BackColor = Color.Transparent;
			MbtnReports.BackColor = Color.Transparent;
			MbtnCheckinout.BackColor = Color.Transparent;
			MbtnCheckOut.BackColor = Color.Transparent;
			MbtnTransactionReports.BackColor = Color.Transparent;
			MBtnConfiguration.BackColor = Color.Transparent;
		}

		void SetColor(object btnonject)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{

				if (labTitle.Text == "Create Asset")
				{
					CreateAssetUC _CreateAssetUC = openform as CreateAssetUC;
					if (_CreateAssetUC != null)
					{
						_CreateAssetUC.btnStopReader();

					}
				}
				else if (labTitle.Text == "Check In")
				{
					CheckIn _CheckInOut = openform as CheckIn;
					if (_CheckInOut != null)
					{
						_CheckInOut.MainDeviceDisconnect();
						_CheckInOut.timer1.Stop();
						_CheckInOut.Dispose();
					}
				}
				else if (labTitle.Text == "Check Out")
				{
					CheckOut _CheckInOut = openform as CheckOut;
					if (_CheckInOut != null)
					{
						_CheckInOut.MainDeviceDisconnect();
						_CheckInOut.timer1.Stop();
						_CheckInOut.Dispose();
					}
				}
				else if (labTitle.Text == "Check In & Out")
				{
					CheckInOutMain _CheckInOut = openform as CheckInOutMain;
					if (_CheckInOut != null)
					{
						_CheckInOut.CloseReader();
						//_CheckInOut.Dispose();
					}
				}
				else
				{
					UserControl userControl = openform as UserControl;
					if (userControl != null)
						userControl.Dispose();
				}
				ClearColor();
				Button _Button = btnonject as Button;
				_Button.BackColor = Color.FromArgb(8, 143, 250);
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}

		}


		private void rjButton1_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new Dashboard();
			AbrirFormEnPanel(openform, "Dashboard");
		}
		private void rjButton2_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new CreateAssetUC(this, null);
			AbrirFormEnPanel(openform, "Create Asset");

		}

		private void rjButton3_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new ManageAsset(this);
			AbrirFormEnPanel(openform, "Manage Assets");

		}

		private void rjButton4_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new PartViewUC(this);
			AbrirFormEnPanel(openform, "Part");
		}

		private void rjButton5_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new LocationViewUC(this);
			AbrirFormEnPanel(openform, "Location");

		}

		private void rjButton6_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new UserViewUC(this);

			AbrirFormEnPanel(openform, "Employee");
		}

		private void rjButton7_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new UserGroupViewUC(this);

			AbrirFormEnPanel(openform, "Employee Role");
		}

		private void MbtnCheckIn_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new CheckInOutMain();
			AbrirFormEnPanel(openform, "Check In & Out");
		}
		private void MbtnCheckOut_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new CheckOut(this);
			AbrirFormEnPanel(openform, "Check Out");
		}
		private void MbtnAssetReport_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new Reports(this, 2);
			AbrirFormEnPanel(openform, "Asset Report");

		}
		private void MbtnTransactionReports_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new Reports(this, 1);
			AbrirFormEnPanel(openform, "Transaction Report");
		}
		public void MasterFormclick(string strControlName, object Data = null)
		{
			if (strControlName == "AddEditPartUC")
			{
				SetColor(MbtnPartMaster);
				openform = new AddEditPartUC(this, Data as PartMaster);

				AbrirFormEnPanel(openform, "Part");
			}
			else if (strControlName == "PartViewUC")
			{
				SetColor(MbtnPartMaster);
				openform = new PartViewUC(this);
				AbrirFormEnPanel(openform, "Part");
			}
			else if (strControlName == "CreateAssetUC")
			{
				SetColor(MbtnCreateAsset);
				openform = new CreateAssetUC(this, Data as AssetTagDetail);
				AbrirFormEnPanel(openform, "Update Asset");
			}
			else if (strControlName == "ManageAsset")
			{
				SetColor(MbtnManageAsset);
				openform = new ManageAsset(this);
				AbrirFormEnPanel(openform, "Manage Assets");
			}
			else if (strControlName == "ReportMainUC")
			{
				SetColor(MbtnReports);
				openform = new ReportMainUC(this);
				AbrirFormEnPanel(openform, "Reports");
			}

		}

		private void btnlogout_Click(object sender, EventArgs e)
		{
			var msgresult = RJMessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (msgresult == DialogResult.Yes)
			{
				SetColor(MbtnCreateAsset);
				this.Hide();
				Login _Main = new Login();
				_Main.Show();
			}
		}

		private void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SetColor(MbtnCreateAsset);
		}

		private void MbtnHelp_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://nada-tech.com/");
		}
		public CompanyReader _selectReader = null;
		private void CmbReader_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				if (labTitle.Text == "Create Asset")
				{
					CreateAssetUC _CreateAssetUC = openform as CreateAssetUC;
					if (_CreateAssetUC != null)
					{
						_CreateAssetUC.btnStopReader();
					}
				}
				else if (labTitle.Text == "Check In")
				{
					CheckIn _CheckInOut = openform as CheckIn;
					if (_CheckInOut != null)
					{
						SetColor(MbtnDashbord);
						openform = new Dashboard();
						AbrirFormEnPanel(openform, "Dashboard");
						//_CheckInOut.MainReaderDisconnect();
						//_selectReader = CmbReader.SelectedItem as CompanyReader;
						//_CheckInOut.MainReaderConnect();
					}
				}
				else if (labTitle.Text == "Check Out")
				{
					CheckOut _CheckInOut = openform as CheckOut;
					if (_CheckInOut != null)
					{
						SetColor(MbtnDashbord);
						openform = new Dashboard();
						AbrirFormEnPanel(openform, "Dashboard");
						//_CheckInOut.MainReaderDisconnect();
						//_selectReader = CmbReader.SelectedItem as CompanyReader;
						//_CheckInOut.MainReaderConnect();
					}
				}
				_selectReader = CmbReader.SelectedItem as CompanyReader;
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void MBtnConfiguration_Click(object sender, EventArgs e)
		{
			SetColor(sender);
			openform = new Configuration(this);
			AbrirFormEnPanel(openform, "Configuration");
		}
	}
}

public class CompanyReader
{
	public int id { get; set; }
	public string Name { get; set; }
}