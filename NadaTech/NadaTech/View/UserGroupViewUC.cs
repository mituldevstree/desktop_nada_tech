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
using NadaTech.Data;

namespace NadaTech.View
{
    public partial class UserGroupViewUC : UserControl
    {
        GenC obj = new GenC();
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<UserGroupMaster> _ListOfUserGroupMaster;
        UserGroupMaster _UserGroupMaster;
        MasterForm _Mainform;
        public UserGroupViewUC(object _mainform)
        {
            InitializeComponent();
            BindDataGrid();
            _Mainform = _mainform as MasterForm;

        }
        private void BindDataGrid()
        {
            try
            {
                string Search = txtSearch.Texts.Trim();
                _ListOfUserGroupMaster = new BindingList<UserGroupMaster>(_Entities.UserGroupMasters.Where(w => w.IsDelete != true && (w.Name.Contains(String.IsNullOrEmpty(Search) ? w.Name : Search) || w.Code.Contains(String.IsNullOrEmpty(Search) ? w.Code : Search))).OrderByDescending(o => o.UserGroupId).ToList());
                GrinEditDeleteDetailView.DataSource = null;
                GrinEditDeleteDetailView.DataSource = _ListOfUserGroupMaster;
                GrinEditDeleteDetailView.Columns["UserGroupId"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["UserMasters"].Visible = false;
                GrinEditDeleteDetailView.Columns["UserPermissions"].Visible = false;
                GrinEditDeleteDetailView.Columns["Code"].Visible = false;
                GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 8;
                GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 8;
                GrinEditDeleteDetailView.Columns["Name"].HeaderText = "UserRole";

            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        private void GrinEditDeleteDetailView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    _UserGroupMaster = _ListOfUserGroupMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_UserGroupMaster != null)
                    {
                        new UserGroupAddEdit().Show(UserGroupAddEdit.FormMode.Edit, _UserGroupMaster, _Entities);
                        _ListOfUserGroupMaster.ResetBindings();
                        GrinEditDeleteDetailView.Refresh();
                    }
                    else
                    {
                        RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    _UserGroupMaster = _ListOfUserGroupMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_UserGroupMaster != null)
                    {
                        if (_UserGroupMaster.UserMasters.Where(w => w.IsDelete != true).Count() > 0)
                        {
                            RJMessageBox.Show("UserRole is in used with User.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgresult == DialogResult.Yes)
                            {
                                _UserGroupMaster.IsDelete = true;
                                _UserGroupMaster.ModifiedDate = DateTime.Now;
                                _UserGroupMaster.ModifiedBy = Program.UserId;
                                _Entities.SaveChanges();
                                _ListOfUserGroupMaster.Remove(_UserGroupMaster);
                            }
                        }
                    }
                    else
                    {
                        RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _UserGroupMaster = new UserGroupMaster();
            if (new UserGroupAddEdit().Show(UserGroupAddEdit.FormMode.Add, _UserGroupMaster, _Entities) == DialogResult.OK)
            {
                _ListOfUserGroupMaster.Insert(0, _UserGroupMaster);
                _ListOfUserGroupMaster.ResetBindings();
                GrinEditDeleteDetailView.Refresh();
            }
        }
    }
}
