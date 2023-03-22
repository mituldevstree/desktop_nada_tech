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
    public partial class UserGroupAddEdit : Form
    {
        NadaTechEntities _Entities;
        GenC obj = new GenC();
        FormMode formMode;
        UserGroupMaster _UserGroupMaster;
        BindingList<FormMaster> _ListOfFormMaster;
        public UserGroupAddEdit()
        {
            InitializeComponent();
        }


        internal enum FormMode
        {
            Add, Edit, View
        }

        internal DialogResult Show(FormMode formMode, UserGroupMaster _userGroupMaster, NadaTechEntities _gIEntities)
        {
            _Entities = _gIEntities;
            if (formMode == FormMode.Add)
            {
                this.Text = "Add UserRole";
                this.formMode = formMode;
                this.btnSave.Text = "&Save";
                _UserGroupMaster = _userGroupMaster;
                FillForm();
                return base.ShowDialog();
            }
            else if (formMode == FormMode.Edit)
            {
                this.Text = "Edit UserRole";
                this.formMode = formMode;
                this.btnSave.Text = "&Update";
                _UserGroupMaster = _userGroupMaster;
                FillRecord(_UserGroupMaster);
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
        void FillForm()
        {
            _ListOfFormMaster = null;
            _ListOfFormMaster = new BindingList<FormMaster>(_Entities.FormMasters.Where(w => w.MenuName != "Dashbord").OrderBy(o=>o.SortBy).ToList());
            _ListOfFormMaster.ToList().ForEach(f => f.IsDisplay = false);
            if (_UserGroupMaster.UserGroupId > 0)
            {
                foreach (UserPermission item in _Entities.UserPermissions.Where(w => w.UserGroupId == _UserGroupMaster.UserGroupId))
                {
                    _ListOfFormMaster.Where(w => w.FormId == item.FormId).All(a => a.IsDisplay = true);
                }

            }
            GridPermission.DataSource = null;
            GridPermission.AutoGenerateColumns = true;
            GridPermission.DataSource = _ListOfFormMaster;
            GridPermission.AutoGenerateColumns = false;

            GridPermission.Columns["FormId"].Visible = false;
            GridPermission.Columns["SortBy"].Visible = false;
            GridPermission.Columns["MenuName"].Visible = false;
            GridPermission.Columns["UserPermissions"].Visible = false;
            GridPermission.Columns["IsDisplay"].DisplayIndex = 2;
            GridPermission.Columns["FormName"].DisplayIndex = 1;
            GridPermission.Columns["Module"].DisplayIndex = 0;
            GridPermission.Columns["FormName"].ReadOnly = true;
            GridPermission.Columns["Module"].ReadOnly = true;
            GridPermission.Columns["FormName"].HeaderText = "Menu";
            GridPermission.Columns["IsDisplay"].HeaderText = "Active";

        }
        private void FillRecord(UserGroupMaster _UserGroupMaster)
        {
            try
            {
                if (_UserGroupMaster != null)
                {
                    txtUserRole.Texts = _UserGroupMaster.Name;
                    FillForm();
                }
                else
                    obj.Information("Sorry No Record Found.");
            }
            catch (Exception _Exception)
            {
                obj.Error(_Exception.Message);
                Application.ExitThread();
            }
        }

        private bool Cansave()
        {
            if (string.IsNullOrEmpty(txtUserRole.Texts.Trim()))
            {
                RJMessageBox.Show("Enter User Role", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserRole.Focus();
                return false;
            }
            else if (_Entities.UserGroupMasters.Where(w => w.Name == txtUserRole.Texts.Trim() && w.IsDelete == false && w.UserGroupId != _UserGroupMaster.UserGroupId).Count() > 0)
            {
                RJMessageBox.Show("User Role already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_ListOfFormMaster.Where(w => w.IsDisplay == true).Count() == 0)
            {
                RJMessageBox.Show("Set Minimum One User Role.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    _UserGroupMaster.Name = txtUserRole.Texts.Trim();
                    _UserGroupMaster.Code = "";
                    _UserGroupMaster.ModifiedBy = Program.UserId;
                    _UserGroupMaster.ModifiedDate = DateTime.Now;
                    List<UserPermission> _listUP = new List<UserPermission>(_Entities.UserPermissions.Where(w => w.UserGroupId == _UserGroupMaster.UserGroupId).ToList());
                    _Entities.UserPermissions.RemoveRange(_listUP);
                    foreach (FormMaster item in _ListOfFormMaster)
                    {
                        if (item.IsDisplay == true)
                        {
                            UserPermission _UP = new UserPermission();
                            _UP.FormId = item.FormId;
                            _UP.UserGroupMaster = _UserGroupMaster;
                            _Entities.UserPermissions.Add(_UP);
                        }
                    }

                    if (this.formMode == FormMode.Add)
                    {
                        _UserGroupMaster.CreateDate = DateTime.Now;
                        _UserGroupMaster.CreatedBy = Program.UserId;
                        _UserGroupMaster.IsDelete = false;
                        _Entities.UserGroupMasters.Add(_UserGroupMaster);
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
