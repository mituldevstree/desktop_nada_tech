using NadaTech.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech.View
{
    public partial class ManageAsset : UserControl
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<AssetTagDetail> _ListOfAssetTagDetails;
        AssetTagDetail _AssetTagDetails;
        sqlhelper _obj = new sqlhelper();
        MasterForm _Mainform;
        public ManageAsset(object _mainform)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            BindDataGrid();
        }

        private void BindDataGrid()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                string Search = txtSearch.Text.Trim();
                int AssetStatus = ChkInStock.Checked == true && chkCheckedOut.Checked == false ? 1 : (ChkInStock.Checked == false && chkCheckedOut.Checked == true) ? 2 : 0;
                #region SqlParameter
                SqlParameter[] _Para =
                {
                            new SqlParameter("@Action",1),
                            new SqlParameter("@AssetTypeId",(_selectAssetType==null?0:_selectAssetType.AssetTypeId)),
                            new SqlParameter("@AssetCategoryId",(_selectAssetCategoryMaster==null?0:_selectAssetCategoryMaster.AssetCategoryId)),
                            new SqlParameter("@PartId",(_SelectPartMaster==null?0:_SelectPartMaster.PartId)),
                            new SqlParameter("@LocationId",(_SelectLocationMaster==null?0:_SelectLocationMaster.LocationId)),
                            new SqlParameter("@AssetStatus",AssetStatus),
                            new SqlParameter("@IdleAssetDate",""),
                            new SqlParameter("@Search",txtSearch.Texts.Trim()),
                 };

                #endregion
                DataTable Dt = _obj.GetDataTable(CommandType.StoredProcedure, "SP_InventoryReport", _Para);

                GrinEditDeleteDetailView.DataSource = null;
                GrinEditDeleteDetailView.DataSource = Dt;

                GrinEditDeleteDetailView.Columns["AssetId"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetTagId"].Visible = false;
                GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 16;
                GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 16;
            }
            catch (Exception ex)
            {

            }
            finally
            {   
                this.Cursor = Cursors.Default;
            }
        }

        void ResetFilter()
        {
            txtSearAssetType.Texts = "All";
            _selectAssetType = null;
            txtserAssetCategory.Texts = "All";
            _selectAssetCategoryMaster = null;
            txtSerLocation.Texts = "All";
            _SelectLocationMaster = null;
            txtSearPart.Texts = "All";
            _SelectPartMaster = null;
            chkCheckedOut.Checked = false;
            ChkInStock.Checked = false;
            txtSearch.Texts = "";
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {

        }

        private void rjButton8_Click(object sender, EventArgs e)
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
                    var AssetTagId = GrinEditDeleteDetailView.CurrentRow.Cells["AssetTagId"].Value;
                    if (AssetTagId != null)
                    {
                        long ATagId = Convert.ToInt64(AssetTagId);
                        AssetTagDetail assetTagDetail = _Entities.AssetTagDetails.FirstOrDefault(x => x.AssetTagId == ATagId);
                        _Mainform.MasterFormclick("CreateAssetUC", assetTagDetail);
                    }
                }
            }
            else if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    var AssetTagId = GrinEditDeleteDetailView.CurrentRow.Cells["AssetTagId"].Value;
                    if (AssetTagId != null)
                    {
                        long ATagId = Convert.ToInt64(AssetTagId);
                        AssetTagDetail assetTagDetail = _Entities.AssetTagDetails.FirstOrDefault(x => x.AssetTagId == ATagId);
                        if (assetTagDetail != null)
                        {
                            var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgresult == DialogResult.Yes)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                assetTagDetail.IsDelete = true;
                                assetTagDetail.ModifiedDate = DateTime.Now;
                                assetTagDetail.ModifiedBy = Program.UserId;
                                _Entities.SaveChanges();
                                GrinEditDeleteDetailView.Rows.RemoveAt(e.RowIndex);
                                this.Cursor = Cursors.Default;
                            }
                        }
                    }
                }
            }


        }
        AssetTypeMaster _selectAssetType;
        private void btnSearchAssetType_Click(object sender, EventArgs e)
        {
            SearchFrom _SearchFrom = new SearchFrom();
            var Result = _SearchFrom.Show(SearchFrom.FormMode.Add, "AssetType");
            if (Result == DialogResult.OK)
            {
                _selectAssetType = _SearchFrom._SelectSearchData as AssetTypeMaster;
                txtSearAssetType.Texts = _selectAssetType.Name;
                txtserAssetCategory.Texts = "All";
                _selectAssetCategoryMaster = null;
            }
            else
            {
                txtSearAssetType.Texts = "All";
                _selectAssetType = null;
                txtserAssetCategory.Texts = "All";
                _selectAssetCategoryMaster = null;
            }
        }
        AssetCategoryMaster _selectAssetCategoryMaster;
        private void btnSearchAssetCategory_Click(object sender, EventArgs e)
        {
            if (_selectAssetType == null)
            {
                RJMessageBox.Show("Select Asset Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SearchFrom _SearchFrom = new SearchFrom();
                var Result = _SearchFrom.Show(SearchFrom.FormMode.Add, "AssetCategory", _selectAssetType.AssetTypeId);
                if (Result == DialogResult.OK)
                {
                    _selectAssetCategoryMaster = _SearchFrom._SelectSearchData as AssetCategoryMaster;
                    txtserAssetCategory.Texts = _selectAssetCategoryMaster.Name;
                }
                else
                {
                    txtserAssetCategory.Texts = "All";
                    _selectAssetCategoryMaster = null;
                }
            }
        }
        PartMaster _SelectPartMaster;
        private void btnSearchPart_Click(object sender, EventArgs e)
        {
            SearchFrom _SearchFrom = new SearchFrom();
            var Result = _SearchFrom.Show(SearchFrom.FormMode.Add, "Part");
            if (Result == DialogResult.OK)
            {
                _SelectPartMaster = _SearchFrom._SelectSearchData as PartMaster;
                txtSearPart.Texts = _SelectPartMaster.Name;
            }
            else
            {
                txtSearPart.Texts = "All";
                _SelectPartMaster = null;
            }
        }
        LocationMaster _SelectLocationMaster;
        private void btnLocation_Click(object sender, EventArgs e)
        {
            SearchFrom _SearchFrom = new SearchFrom();
            var Result = _SearchFrom.Show(SearchFrom.FormMode.Add, "Location");
            if (Result == DialogResult.OK)
            {
                _SelectLocationMaster = _SearchFrom._SelectSearchData as LocationMaster;
                txtSerLocation.Texts = _SelectLocationMaster.Name;
            }
            else
            {
                txtSerLocation.Texts = "All";
                _SelectLocationMaster = null;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFilter();
            BindDataGrid();
        }
    }
}
