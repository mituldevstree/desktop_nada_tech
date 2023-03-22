using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralCodeLibrary;
using MaterialSkin;
using MaterialSkin.Controls;
using NadaTech.Data;
using RFID_Reader_Cmds;

namespace NadaTech.View
{
    public partial class LocationAddEdit : Form
    {
        NadaTechEntities _Entities;
        GenC obj = new GenC();
        FormMode formMode;
        LocationMaster _LocationMaster;
        public LocationAddEdit()
        {
            InitializeComponent();
        }


        internal enum FormMode
        {
            Add, Edit, View
        }

        internal DialogResult Show(FormMode formMode, LocationMaster _locationMaster, NadaTechEntities _gIEntities)
        {
            _Entities = _gIEntities;
            if (formMode == FormMode.Add)
            {
                this.Text = "Add Location";
                this.formMode = formMode;
                this.btnSave.Text = "&Save";
                _LocationMaster = _locationMaster;
                return base.ShowDialog();
            }
            else if (formMode == FormMode.Edit)
            {
                this.Text = "Edit Location";
                this.formMode = formMode;
                this.btnSave.Text = "&Update";
                _LocationMaster = _locationMaster;
                FillRecord(_LocationMaster);
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

        private void FillRecord(LocationMaster _LocationMaster)
        {
            try
            {
                if (_LocationMaster != null)
                {
                    txtCode.Texts = _LocationMaster.Code;
                    txtName.Texts = _LocationMaster.Name;
                }
                else
                {
                    RJMessageBox.Show("No Record Found.", "Warning-Exclamation Icon", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Cansave()
        {
            if (string.IsNullOrEmpty(txtCode.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            else if (_Entities.LocationMasters.Where(w => w.Code == txtCode.Texts.Trim() && w.IsDelete == false && w.LocationId != _LocationMaster.LocationId).Count() > 0)
            {
                RJMessageBox.Show("Code already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (Cansave())
                {

                    _LocationMaster.Name = txtName.Texts.Trim();
                    _LocationMaster.Code = txtCode.Texts.Trim();
                    _LocationMaster.ModifiedBy = Program.UserId;
                    _LocationMaster.ModifiedDate = DateTime.Now;
                    if (this.formMode == FormMode.Add)
                    {
                        _LocationMaster.CreateDate = DateTime.Now;
                        _LocationMaster.CreatedBy = Program.UserId;
                        _LocationMaster.IsDelete = false;
                        _Entities.LocationMasters.Add(_LocationMaster);
                        _Entities.SaveChanges();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else if (this.formMode == FormMode.Edit)
                    {
                        _Entities.SaveChanges();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
                this.Cursor = Cursors.Default;
            }
        }
        public string GetReaderDeviceAddrs()
        {
            string address = Commands.RFID_Q_ReaderDeviceAddr(ConstCode.READER_DEVICEADDR_BROADCAST, ConstCode.READER_OPERATION_GET, 0);
            return address;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linklabDeviceAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string DeviceAdd = GetReaderDeviceAddrs();
            txtCode.Texts = DeviceAdd;
        }
    }
}
