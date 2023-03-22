using NadaTech.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech.View
{
    public partial class AssetCategoryAddView : Form
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<AssetCategoryMaster> _ListOfAssetCategoryMaster;
        AssetTypeMaster _AssetTypeMaster;
        public AssetCategoryMaster _SelectAssetCategoryMaster;
        AssetCategoryMaster _AssetCategoryMaster;
        FormMode formMode;

        public AssetCategoryAddView()
        {
            InitializeComponent();
        }

        internal enum FormMode
        {
            Add, Edit, View
        }

        internal DialogResult Show(FormMode formMode, AssetTypeMaster _assetTypeMaster)
        {
            if (formMode == FormMode.Add)
            {
                this.formMode = formMode;
                _AssetTypeMaster = _assetTypeMaster;
                txtViewAssetType.Texts = _AssetTypeMaster.Name;
                txtAssetType.Texts = _AssetTypeMaster.Name;
                BindDataGrid();
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

        private void BindDataGrid()
        {
            string Search = txtSearch.Texts.Trim();
            _ListOfAssetCategoryMaster = new BindingList<AssetCategoryMaster>(_Entities.AssetCategoryMasters.AsEnumerable().Where(w => w.IsDelete != true && w.AssetTypeId == _AssetTypeMaster.AssetTypeId && (w.Name.ToLower().Contains(String.IsNullOrEmpty(Search) ? w.Name.ToLower() : Search.ToLower()))).OrderByDescending(o => o.AssetTypeId).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            GrinEditDeleteDetailView.DataSource = _ListOfAssetCategoryMaster;

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
            GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 13;
            GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 13;
            GrinEditDeleteDetailView.Columns["Name"].HeaderText = "AssetCategory";


        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                btnSelect.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnSelect.Visible = false;
                btnSave.Visible = true;
                ClearData();
            }
        }

        void ClearData()
        {
            txtAssetCategory.Texts = "";
            _AssetCategoryMaster = new AssetCategoryMaster();
        }

        private void FillRecord(AssetCategoryMaster _AssetCategoryMaster)
        {
            try
            {
                if (_AssetCategoryMaster != null)
                {
                    txtAssetCategory.Texts = _AssetCategoryMaster.Name;
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

        private void GrinEditDeleteDetailView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    tabControl1.SelectedIndex = 1;
                    _AssetCategoryMaster = _ListOfAssetCategoryMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_AssetCategoryMaster != null)
                    {
                        FillRecord(_AssetCategoryMaster);
                    }
                    else
                    {
                        RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    if (_ListOfAssetCategoryMaster != null)
                    {
                        _AssetCategoryMaster = _ListOfAssetCategoryMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                        if (_AssetCategoryMaster != null)
                        {
                            if (_AssetCategoryMaster.PartMasters.Where(w => w.IsDelete != true).Count() > 0)
                            {
                                RJMessageBox.Show("Asset Category is in used with Part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (msgresult == DialogResult.Yes)
                                {
                                    _AssetCategoryMaster.IsDelete = true;
                                    _AssetCategoryMaster.ModifiedDate = DateTime.Now;
                                    _AssetCategoryMaster.ModifiedBy = Program.UserId;
                                    _Entities.SaveChanges();
                                    _ListOfAssetCategoryMaster.Remove(_AssetCategoryMaster);
                                }
                            }
                        }
                        else
                        {
                            RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private bool Cansave()
        {
            if (string.IsNullOrEmpty(txtAssetCategory.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Asset Category.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_Entities.AssetCategoryMasters.Where(w => w.Name == txtAssetCategory.Texts.Trim() && w.IsDelete == false && w.AssetCategoryId != _AssetCategoryMaster.AssetCategoryId && w.AssetTypeId == _AssetTypeMaster.AssetTypeId).Count() > 0)
            {
                RJMessageBox.Show("Asset Category already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    bool IsAdd = false;
                    _AssetCategoryMaster.Name = txtAssetCategory.Texts.Trim();
                    _AssetCategoryMaster.ModifiedBy = Program.UserId;
                    _AssetCategoryMaster.ModifiedDate = DateTime.Now;
                    if (_AssetCategoryMaster.AssetCategoryId == 0)
                    {
                        IsAdd = true;
                        _AssetCategoryMaster.CreateDate = DateTime.Now;
                        _AssetCategoryMaster.CreatedBy = Program.UserId;
                        _AssetCategoryMaster.IsDelete = false;
                        AssetTypeMaster _AssettypeM = _Entities.AssetTypeMasters.First(w => w.AssetTypeId == _AssetTypeMaster.AssetTypeId);
                        _AssetCategoryMaster.AssetTypeId = _AssettypeM.AssetTypeId;
                        _AssetCategoryMaster.AssetTypeMaster = _AssettypeM;
                        _Entities.AssetCategoryMasters.Add(_AssetCategoryMaster);
                    }
                    _Entities.SaveChanges();
                    if (IsAdd)
                    {
                        _ListOfAssetCategoryMaster.Insert(0, _AssetCategoryMaster);
                    }
                    _ListOfAssetCategoryMaster.ResetBindings();
                    GrinEditDeleteDetailView.Refresh();
                    var msgresult = RJMessageBox.Show("Asset Category saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (msgresult == DialogResult.OK || msgresult == DialogResult.Cancel)
                    {
                        tabControl1.SelectedIndex = 0;
                        ClearData();
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
                    _SelectAssetCategoryMaster = _ListOfAssetCategoryMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_SelectAssetCategoryMaster != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        RJMessageBox.Show("Select Asset Category.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("Select Asset Category.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
