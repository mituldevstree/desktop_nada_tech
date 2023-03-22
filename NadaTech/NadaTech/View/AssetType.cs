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
    public partial class AssetType : Form
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<AssetTypeMaster> _ListOfAssetTypeMaster;
        public AssetTypeMaster _AssetTypeMaster;
        public AssetTypeMaster _SelectAssetTypeMaster;
        FormMode formMode;

        public AssetType()
        {
            InitializeComponent();
            BindDataGrid();
        }

        internal enum FormMode
        {
            Add, Edit, View
        }

        internal DialogResult Show(FormMode formMode)
        {

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

        private void BindDataGrid()
        {
            string Search = txtSearch.Texts.Trim();
            _ListOfAssetTypeMaster = new BindingList<AssetTypeMaster>(_Entities.AssetTypeMasters.Where(w => w.IsDelete != true && w.Name.Contains(String.IsNullOrEmpty(Search) ? w.Name : Search)).OrderByDescending(o => o.AssetTypeId).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            GrinEditDeleteDetailView.DataSource = _ListOfAssetTypeMaster;

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

            GrinEditDeleteDetailView.Columns["Name"].DisplayIndex = 0;
            GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 1;
            GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 2;


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
            txtAssetType.Texts = "";
            _AssetTypeMaster = new AssetTypeMaster();
        }

        private void FillRecord(AssetTypeMaster _AssetTypeMaster)
        {
            try
            {
                if (_AssetTypeMaster != null)
                {
                    txtAssetType.Texts = _AssetTypeMaster.Name;
                }
                else
                    RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrinEditDeleteDetailView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Edit")
                {
                    if (GrinEditDeleteDetailView.CurrentRow != null)
                    {
                        tabControl1.SelectedIndex = 1;
                        _AssetTypeMaster = _ListOfAssetTypeMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                        if (_AssetTypeMaster != null)
                        {
                            FillRecord(_AssetTypeMaster);
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
                        if (_ListOfAssetTypeMaster != null)
                        {
                            _AssetTypeMaster = _ListOfAssetTypeMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                            if (_AssetTypeMaster != null)
                            {
                                if (_AssetTypeMaster.AssetCategoryMasters.Where(w => w.IsDelete != true).Count() > 0)
                                {
                                    var msgresult = RJMessageBox.Show("AssetType is in used with AssetCategory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else if (_AssetTypeMaster.PartMasters.Where(w => w.IsDelete != true).Count() > 0)
                                {
                                    RJMessageBox.Show("AssetType is in used with Part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (msgresult == DialogResult.Yes)
                                    {
                                        _AssetTypeMaster.IsDelete = true;
                                        _AssetTypeMaster.ModifiedDate = DateTime.Now;
                                        _AssetTypeMaster.ModifiedBy = Program.UserId;
                                        _Entities.SaveChanges();
                                        _ListOfAssetTypeMaster.Remove(_AssetTypeMaster);
                                    }
                                }
                            }
                            else
                            {
                                RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    else
                    {
                        RJMessageBox.Show("No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            if (string.IsNullOrEmpty(txtAssetType.Texts.Trim()))
            {
                RJMessageBox.Show("Enter AssetType.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_Entities.AssetTypeMasters.Where(w => w.Name == txtAssetType.Texts.Trim() && w.IsDelete == false && w.AssetTypeId != _AssetTypeMaster.AssetTypeId).Count() > 0)
            {
                RJMessageBox.Show("AssetType already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor= Cursors.WaitCursor;
            try
            {
                if (Cansave())
                {
                    bool IsAdd = false;
                    if (_AssetTypeMaster.AssetTypeId == 0)
                    {
                        IsAdd = true;
                        _AssetTypeMaster.CreateDate = DateTime.Now;
                        _AssetTypeMaster.CreatedBy = Program.UserId;
                        _Entities.AssetTypeMasters.Add(_AssetTypeMaster);
                        _AssetTypeMaster.IsDelete = false;
                    }
                    _AssetTypeMaster.Name = txtAssetType.Texts.Trim();
                    _AssetTypeMaster.ModifiedBy = Program.UserId;
                    _AssetTypeMaster.ModifiedDate = DateTime.Now;
                    _Entities.SaveChanges();
                    if (IsAdd)
                    {
                        _ListOfAssetTypeMaster.Insert(0, _AssetTypeMaster);
                    }
                    _ListOfAssetTypeMaster.ResetBindings();
                    GrinEditDeleteDetailView.Refresh();
                    var msgresult = RJMessageBox.Show("AssetType saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _SelectAssetTypeMaster = _ListOfAssetTypeMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_SelectAssetTypeMaster != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        RJMessageBox.Show("Select Asset Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("Select Asset Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
