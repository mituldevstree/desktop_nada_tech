using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeviceId;
using DeviceId.Windows;
using GeneralCodeLibrary;
using MaterialSkin;
using MaterialSkin.Controls;
using NadaTech.Data;

namespace NadaTech
{
    public partial class Login : Form
    {
        GenC obj = new GenC();
        NadaTechEntities _Entities = new NadaTechEntities();
        public Login()
        {

            InitializeComponent();

            if (!Common.TestConnectionString())
            {
                RJMessageBox.Show("You are not connected to Internet or Server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var deviceId = new DeviceIdBuilder().ToString();
            //FillComboBox();
        }
        BindingList<LocationMaster> _listLocation = new BindingList<LocationMaster>();

        //void FillComboBox()
        //{
        //    _listLocation = new BindingList<LocationMaster>(_Entities.LocationMasters.Where(w => w.IsDelete != true).ToList());
        //    CmbLocation.DataSource = _listLocation;
        //    CmbLocation.DisplayMember = "Name";
        //    CmbLocation.ValueMember = "LocationId";
        //    CmbLocation.SelectedIndex = -1;
        //}
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                if (string.IsNullOrEmpty(txtUserName.Texts))
                {
                    RJMessageBox.Show("Enter Username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                }
                else if (string.IsNullOrEmpty(txtPassword.Texts))
                {
                    RJMessageBox.Show("Enter Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Focus();
                }
                else if (!Common.TestConnectionString())
                {
                    RJMessageBox.Show("You are not connected to Internet or Server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string pass = Common.EncryptNumber("", txtPassword.Texts);
                    UserMaster _UserMaster = _Entities.UserMasters.FirstOrDefault(f => f.UserName == txtUserName.Texts && f.Password == pass && f.IsDelete == false);
                    if (_UserMaster != null)
                    {
                        Program.UserId = _UserMaster.UserId;
                        Program.UserGroupId = (int)_UserMaster.UserGroupId;
                        Program.UserMaster = _UserMaster;
                        //if (CmbLocation.SelectedIndex < 0)
                        //{
                            Program.locationMaster = null;
                        //}
                        //else
                        //{
                        //    LocationMaster _LocationMaster = _listLocation.FirstOrDefault(w => w.LocationId == Convert.ToInt32(CmbLocation.SelectedValue));
                        //    Program.locationMaster = _LocationMaster;
                        //}
                        this.Hide();
                        MasterForm _Main = new MasterForm();
                        _Main.Show();
                    }
                    else
                    {
                        RJMessageBox.Show("Username or Passworsd not valid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                obj.Error(ex.Message);

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender, e);
            }
        }

        //void v1()
        //{
        //    DataSet ds =new DataSet(); 
        //    using (OpenFileDialog dialog = new OpenFileDialog(){ Filter = " Excel Workbook | * .xls | * .xlsx ", ValidateNames = true })
        //    {
        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            FileStream fileStream = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read);
        //            IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fileStream);
        //            reader.IsFirst RowAsColumnNames = true;
        //            ds = reader.AsDataSet();
        //            ResultGrid.DataSource = ds.Tables[0];
        //        }
        //    }
        //}
    }
}
