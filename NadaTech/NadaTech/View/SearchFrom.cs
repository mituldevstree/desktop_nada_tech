using NadaTech.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech.View
{
    public partial class SearchFrom : Form
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        List<object> _ListOfSearchList;
        public AssetTypeMaster _AssetTypeMaster;
        public object _SelectSearchData;
        FormMode formMode;
        string _Title = "";
        int _RefId = 0;
        public SearchFrom()
        {
            InitializeComponent();
        }

        internal enum FormMode
        {
            Add, Edit, View
        }

        internal DialogResult Show(FormMode formMode, string Title, int refId = 0)
        {
            _Title = Title;
            this.Text = Title;
            _RefId = refId;
            BindDataGrid();

            if (formMode == FormMode.Add)
            {
                this.formMode = formMode;
                return base.ShowDialog();
            }
            else if (formMode == FormMode.Edit)
            {
                this.formMode = formMode;
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

        void BindDataGrid()
        {
            string Search = txtSearch.Texts.Trim();

            if (_Title == "Part")
            {
                BindPartDataGrid(Search);
            }
            else if (_Title == "Location")
            {
                BindLocation(Search);
            }
            else if (_Title == "AssetType")
            {
                BindAssetType(Search);
            }
            else if (_Title == "AssetCategory")
            {
                BindAssetCategory(Search);
            }
        }
        private void BindPartDataGrid(string Search)
        {
            _ListOfSearchList = new List<object>(_Entities.PartMasters.Where(w => w.IsDelete != true && (w.Name.Contains(String.IsNullOrEmpty(Search) ? w.Name : Search) || w.Code.Contains(String.IsNullOrEmpty(Search) ? w.Code : Search))).OrderByDescending(o => o.PartId).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            if (_ListOfSearchList.Count > 0)
            {
                GrinEditDeleteDetailView.DataSource = _ListOfSearchList;
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
                GrinEditDeleteDetailView.Columns["AssetType"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetCategory"].Visible = false;
                GrinEditDeleteDetailView.Columns["Manufacturer"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsSerial"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsExpire"].Visible = false;
                GrinEditDeleteDetailView.Columns["Name"].HeaderText = "PartNumber";
            }

        }

        private void BindLocation(string Search)
        {
            _ListOfSearchList = new List<object>(_Entities.LocationMasters.Where(w => w.IsDelete != true && (w.Name.Contains(String.IsNullOrEmpty(Search) ? w.Name : Search) || w.Code.Contains(String.IsNullOrEmpty(Search) ? w.Code : Search))).OrderByDescending(o => o.LocationId).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            if (_ListOfSearchList.Count > 0)
            {
                GrinEditDeleteDetailView.DataSource = _ListOfSearchList;
                GrinEditDeleteDetailView.Columns["LocationId"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["TransactionDetails"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetTagDetails"].Visible = false;
            }
        }
        private void BindAssetType(string Search)
        {
            _ListOfSearchList = new List<object>(_Entities.AssetTypeMasters.Where(w => w.IsDelete != true && (w.Name.Contains(String.IsNullOrEmpty(Search) ? w.Name : Search))).OrderByDescending(o => o.Name).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            if (_ListOfSearchList.Count > 0)
            {
                GrinEditDeleteDetailView.DataSource = _ListOfSearchList;

                GrinEditDeleteDetailView.Columns["AssetTypeId"].Visible = false;
                GrinEditDeleteDetailView.Columns["Description"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetCategoryMasters"].Visible = false;
                GrinEditDeleteDetailView.Columns["PartMasters"].Visible = false;
                GrinEditDeleteDetailView.Columns["Name"].HeaderText = "Asset Type";
            }
        }
        private void BindAssetCategory(string Search)
        {
            _ListOfSearchList = new List<object>(_Entities.AssetCategoryMasters.Where(w => w.IsDelete != true && w.AssetTypeId == _RefId && (w.Name.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.Name.ToLower() : Search.ToLower()))).OrderByDescending(o => o.Name).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            if (_ListOfSearchList.Count > 0)
            {
                GrinEditDeleteDetailView.DataSource = _ListOfSearchList;

                GrinEditDeleteDetailView.Columns["AssetTypeId"].Visible = false;
                GrinEditDeleteDetailView.Columns["Description"].Visible = false;
                GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
                GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetTypeMaster"].Visible = false;
                GrinEditDeleteDetailView.Columns["PartMasters"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetCategoryId"].Visible = false;
                GrinEditDeleteDetailView.Columns["AssetType"].DisplayIndex = 0;
                GrinEditDeleteDetailView.Columns["Name"].DisplayIndex = 0;
                GrinEditDeleteDetailView.Columns["Name"].HeaderText = "AssetCategory";
            }
        }

        private void txtSearch__TextChanged(object sender, EventArgs e)
        {
            BindDataGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {


                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    _SelectSearchData = _ListOfSearchList[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_SelectSearchData != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        RJMessageBox.Show("Select " + _Title + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("Select " + _Title + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
