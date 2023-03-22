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

namespace NadaTech.View
{
    public partial class UserAddEdit : Form
    {
        NadaTechEntities _Entities;
        GenC obj = new GenC();
        FormMode formMode;
        UserMaster _UserMaster;
        BindingList<UserGroupMaster> ListOfUserGroupMaster = new BindingList<UserGroupMaster>();

        public UserAddEdit()
        {
            InitializeComponent();
        }


        internal enum FormMode
        {
            Add, Edit, View
        }

        internal DialogResult Show(FormMode formMode, UserMaster _userGroupMaster, NadaTechEntities _gIEntities)
        {
            _Entities = _gIEntities;
            FillComboBox();
            if (formMode == FormMode.Add)
            {
                this.Text = "Add Employee";
                this.formMode = formMode;
                this.btnSave.Text = "&Save";
                _UserMaster = _userGroupMaster;
                return base.ShowDialog();
            }
            else if (formMode == FormMode.Edit)
            {
                this.Text = "Edit Employee";
                this.formMode = formMode;
                this.btnSave.Text = "&Update";
                _UserMaster = _userGroupMaster;
                FillRecord(_UserMaster);
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
        void FillComboBox()
        {
            ListOfUserGroupMaster = new BindingList<UserGroupMaster>(_Entities.UserGroupMasters.Where(w => w.IsDelete != true).ToList());
            CmbUserRole.DataSource = ListOfUserGroupMaster;
            CmbUserRole.DisplayMember = "Name";
            CmbUserRole.ValueMember = "UserGroupId";
            CmbUserRole.SelectedIndex = -1;
        }
        private void FillRecord(UserMaster _UserMaster)
        {
            try
            {
                if (_UserMaster != null)
                {
                    txtName.Texts = _UserMaster.Name;
                    txtUserName.Texts = _UserMaster.UserName;
                    txtPassword.Texts = Common.DecryptNumber("", _UserMaster.Password);
                    txtEmail.Texts = _UserMaster.Email;
                    txtPhone.Texts = _UserMaster.Phone;
                    CmbUserRole.SelectedValue = _UserMaster.UserGroupId;
                    txtPassword.Focus();
                    txtUserName.Focus();
                }
                else
                {
                    RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (string.IsNullOrEmpty(txtName.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtUserName.Texts.Trim()))
            {
                RJMessageBox.Show("Enter User Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (CmbUserRole.SelectedIndex < 0)
            {
                RJMessageBox.Show("Select UserRole.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_Entities.UserMasters.Where(w => w.UserName == txtUserName.Texts.Trim() && w.IsDelete == false && w.UserId != _UserMaster.UserId).Count() > 0)
            {
                RJMessageBox.Show("User Name already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    UserGroupMaster _UserGroupM = ListOfUserGroupMaster.First(w => w.UserGroupId == Convert.ToInt32(CmbUserRole.SelectedValue));
                    _UserMaster.UserGroupMaster = _UserGroupM;
                    _UserMaster.UserGroupId = Convert.ToInt32(CmbUserRole.SelectedValue);
                    _UserMaster.Name = txtName.Texts.Trim();
                    _UserMaster.UserName = txtUserName.Texts.Trim();
                    _UserMaster.Password = Common.EncryptNumber("", txtPassword.Texts.Trim());
                    _UserMaster.Email = txtEmail.Texts.Trim();
                    _UserMaster.Phone = txtPhone.Texts.Trim();
                    _UserMaster.ModifiedBy = Program.UserId;
                    _UserMaster.ModifiedDate = DateTime.Now;
                    if (this.formMode == FormMode.Add)
                    {
                        _UserMaster.CreateDate = DateTime.Now;
                        _UserMaster.CreatedBy = Program.UserId;
                        _UserMaster.IsDelete = false;
                        _Entities.UserMasters.Add(_UserMaster);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
