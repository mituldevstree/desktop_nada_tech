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
    public partial class LocationViewUC : UserControl
    {
        GenC obj = new GenC();
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<LocationMaster> _ListOfLocationMaster;
        LocationMaster _LocationMaster;
        MasterForm _Mainform;
        public LocationViewUC(object _mainform)
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

                _ListOfLocationMaster = new BindingList<LocationMaster>(_Entities.LocationMasters.Where(w => w.IsDelete != true && (w.Name.Contains(String.IsNullOrEmpty(Search) ? w.Name : Search) || w.Code.Contains(String.IsNullOrEmpty(Search) ? w.Code : Search))).OrderByDescending(o => o.LocationId).ToList());
                GrinEditDeleteDetailView.DataSource = null;
                GrinEditDeleteDetailView.DataSource = _ListOfLocationMaster;
                GrinEditDeleteDetailView.Columns["LocationId"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["TransactionDetails"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetTagDetails"].Visible = false;

                GrinEditDeleteDetailView.EnableHeadersVisualStyles = false;
                GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 5;
                GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 5;
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
                    _LocationMaster = _ListOfLocationMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    _LocationMaster = _ListOfLocationMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_LocationMaster != null)
                    {
                        new LocationAddEdit().Show(LocationAddEdit.FormMode.Edit, _LocationMaster, _Entities);
                        _ListOfLocationMaster.ResetBindings();
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
                    _LocationMaster = _ListOfLocationMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_LocationMaster != null)
                    {
                        if (_LocationMaster.AssetTagDetails.Where(w => w.IsDelete != true).Count() > 0)
                        {
                            var msgresult = RJMessageBox.Show("Location is in used with AssetTag.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgresult == DialogResult.Yes)
                            {
                                _LocationMaster.IsDelete = true;
                                _LocationMaster.ModifiedDate = DateTime.Now;
                                _LocationMaster.ModifiedBy = Program.UserId;
                                _Entities.SaveChanges();
                                _ListOfLocationMaster.Remove(_LocationMaster);

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _LocationMaster = new LocationMaster();
            if (new LocationAddEdit().Show(LocationAddEdit.FormMode.Add, _LocationMaster, _Entities) == DialogResult.OK)
            {
                _ListOfLocationMaster.Insert(0, _LocationMaster);
                _ListOfLocationMaster.ResetBindings();
                GrinEditDeleteDetailView.Refresh();
            }

        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            BindDataGrid();
        }
    }
}
