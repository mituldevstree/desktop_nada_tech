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
    public partial class PartViewUC : UserControl
    {
        GenC obj = new GenC();
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<PartMaster> _ListOfPartMaster;
        PartMaster _PartMaster;
        MasterForm _Mainform;
        public PartViewUC(object _mainform)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            btnAdd.Focus();

        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            BindDataGrid();

        }
        private void BindDataGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string Search = txtSearch.Texts.Trim();
                _ListOfPartMaster = new BindingList<PartMaster>(_Entities.PartMasters.AsEnumerable().Where(w => w.IsDelete != true
                && (w.Name.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.Name.ToLower() : Search.ToLower())
                || w.AssetCategory.ToLower().ToLower().Contains(String.IsNullOrEmpty(Search) ? w.AssetCategory.ToLower() : Search.ToLower())
                || w.AssetType.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.AssetType.ToLower() : Search.ToLower())
                || w.Manufacturer.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.Manufacturer.ToLower() : Search.ToLower()))
                ).OrderByDescending(o => o.PartId).ToList());
                GrinEditDeleteDetailView.DataSource = null;
                GrinEditDeleteDetailView.DataSource = _ListOfPartMaster;

                GrinEditDeleteDetailView.Columns["AssetTypeId"].Visible = false;
                GrinEditDeleteDetailView.Columns["Code"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetTypeMaster"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetCategoryMaster"].Visible = false;
                GrinEditDeleteDetailView.Columns["ManufacturerMaster"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetTypeId"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetCategoryId"].Visible = false;
                GrinEditDeleteDetailView.Columns["ManufacturerId"].Visible = false;
                GrinEditDeleteDetailView.Columns["PartId"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetMasters"].Visible = false;
                GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 13;
                GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 13;
                GrinEditDeleteDetailView.Columns["Name"].HeaderText = "PartNumber";
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
        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            BindDataGrid();
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
                    if (_ListOfPartMaster != null)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        _PartMaster = _ListOfPartMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                        _Mainform.MasterFormclick("AddEditPartUC", _PartMaster);
                        this.Cursor = Cursors.Default;
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
                    if (_ListOfPartMaster != null)
                    {
                        _PartMaster = _ListOfPartMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                        if (_PartMaster != null)
                        {
                            if (_PartMaster.AssetMasters.Where(w => w.IsDelete != true).Count() > 0)
                            {
                                var msgresult = RJMessageBox.Show("Part is in used with Asset.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (msgresult == DialogResult.Yes)
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    _PartMaster.IsDelete = true;
                                    _PartMaster.ModifiedDate = DateTime.Now;
                                    _PartMaster.ModifiedBy = Program.UserId;
                                    _Entities.SaveChanges();
                                    _ListOfPartMaster.Remove(_PartMaster);
                                    this.Cursor = Cursors.Default;
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


        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            _PartMaster = new PartMaster();
            _Mainform.MasterFormclick("AddEditPartUC", _PartMaster);
            this.Cursor = Cursors.Default;
        }


    }
}
