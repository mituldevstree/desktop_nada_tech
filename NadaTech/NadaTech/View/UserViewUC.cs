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
    public partial class UserViewUC : UserControl
    {
        GenC obj = new GenC();
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<UserMaster> _ListOfUserMaster;
        UserMaster _UserMaster;
        MasterForm _Mainform;
        public UserViewUC(object _mainform)
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
                _ListOfUserMaster = new BindingList<UserMaster>(_Entities.UserMasters.AsEnumerable().Where(w =>
                w.IsDelete != true &&
                (w.UserName.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.UserName.ToLower() : Search.ToLower()) ||
                w.Name.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.Name.ToLower() : Search.ToLower()) ||
                w.Email.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.Email.ToLower() : Search.ToLower()) ||
                w.Phone.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.Phone.ToLower() : Search.ToLower())
                )).OrderByDescending(o => o.UserId).ToList());
                GrinEditDeleteDetailView.AutoGenerateColumns = true;
                GrinEditDeleteDetailView.DataSource = null;
                GrinEditDeleteDetailView.DataSource = _ListOfUserMaster;
                GrinEditDeleteDetailView.AutoGenerateColumns = false;

                GrinEditDeleteDetailView.Columns["UserId"].Visible = false;
                GrinEditDeleteDetailView.Columns["UserGroupId"].Visible = false;
                GrinEditDeleteDetailView.Columns["UserType"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["Password"].Visible = false;
                GrinEditDeleteDetailView.Columns["UserGroupMaster"].Visible = false;
                GrinEditDeleteDetailView.Columns["DeviceID"].Visible = false;
                GrinEditDeleteDetailView.Columns["UserRole"].DisplayIndex = 8;
                GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 9;
                GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 9;

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
                    _UserMaster = _ListOfUserMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_UserMaster != null)
                    {
                        new UserAddEdit().Show(UserAddEdit.FormMode.Edit, _UserMaster, _Entities);
                        _ListOfUserMaster.ResetBindings();
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
                    _UserMaster = _ListOfUserMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_UserMaster != null)
                    {
                        var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgresult == DialogResult.Yes)
                        {
                            _UserMaster.IsDelete = true;
                            _UserMaster.ModifiedDate = DateTime.Now;
                            _UserMaster.ModifiedBy = Program.UserId;
                            _Entities.SaveChanges();
                            _ListOfUserMaster.Remove(_UserMaster);
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
            _UserMaster = new UserMaster();
            if (new UserAddEdit().Show(UserAddEdit.FormMode.Add, _UserMaster, _Entities) == DialogResult.OK)
            {
                _ListOfUserMaster.Insert(0, _UserMaster);
                _ListOfUserMaster.ResetBindings();
                GrinEditDeleteDetailView.Refresh();
            }
        }
    }
}
