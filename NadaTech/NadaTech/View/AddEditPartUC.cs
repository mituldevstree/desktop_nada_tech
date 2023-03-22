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
    public partial class AddEditPartUC : UserControl
    {
        MasterForm _Mainform;
        NadaTechEntities _Entities = new NadaTechEntities();
        PartMaster _PartMaster;
        AssetTypeMaster _SelectAssetTypeMaster;

        public AddEditPartUC(object _mainform, PartMaster _partMaster)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            _PartMaster = _partMaster;
            if (_PartMaster.PartId > 0)
            {
                _PartMaster = _Entities.PartMasters.FirstOrDefault(x => x.PartId == _partMaster.PartId);
                FillRecord(_PartMaster);
            }
            else
            {
                _SelectAssetTypeMaster = _Entities.AssetTypeMasters.OrderBy(o => o.Name).FirstOrDefault(f => f.IsDelete == false);
                if (_SelectAssetTypeMaster != null)
                {
                    txtAssetType.Texts = _SelectAssetTypeMaster.Name;

                    _SelectAssetCategoryMaster = _SelectAssetTypeMaster.AssetCategoryMasters.OrderBy(o => o.Name).FirstOrDefault(f => f.IsDelete == false);
                    if (_SelectAssetCategoryMaster != null)
                    {
                        txtAssetCategory.Texts = _SelectAssetCategoryMaster.Name;
                    }
                }
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

            AssetType _AssetType = new AssetType();
            var Result = _AssetType.Show(AssetType.FormMode.Add);
            if (Result == DialogResult.OK)
            {
                _SelectAssetTypeMaster = _AssetType._SelectAssetTypeMaster;
                txtAssetType.Texts = _SelectAssetTypeMaster.Name;
                _SelectAssetCategoryMaster = null;
                txtAssetCategory.Texts = "";
            }
            else
            {
                _SelectAssetCategoryMaster = null;
                txtAssetCategory.Texts = "";
                _SelectAssetTypeMaster = null;
                txtAssetType.Texts = "";
            }

        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            _Mainform.MasterFormclick("PartViewUC");

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

        }
        AssetCategoryMaster _SelectAssetCategoryMaster;
        private void btnSerAssetCategory_Click(object sender, EventArgs e)
        {
            if (_SelectAssetTypeMaster == null)
            {
                RJMessageBox.Show("Select Asset Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AssetCategoryAddView _AssetType = new AssetCategoryAddView();
                var Result = _AssetType.Show(AssetCategoryAddView.FormMode.Add, _SelectAssetTypeMaster);
                if (Result == DialogResult.OK)
                {
                    _SelectAssetCategoryMaster = _AssetType._SelectAssetCategoryMaster;
                    txtAssetCategory.Texts = _SelectAssetCategoryMaster.Name;
                }
                else
                {
                    //_AssetTypeMaster=null;
                    //txtAssetType.Texts = "";
                }
            }

        }

        ManufacturerMaster _SelectManufacturerMaster;
        private void bntSerManufacturer_Click(object sender, EventArgs e)
        {
            ManufacturerAddView _AssetType = new ManufacturerAddView();
            var Result = _AssetType.Show(ManufacturerAddView.FormMode.Add);
            if (Result == DialogResult.OK)
            {
                _SelectManufacturerMaster = _AssetType._SelectManufacturerMaster;
                txtManufacturer.Texts = _SelectManufacturerMaster.Code + " # " + _SelectManufacturerMaster.Name;
            }
            else
            {
                _SelectManufacturerMaster = null;
                txtManufacturer.Texts = "";
            }
        }

        private void FillRecord(PartMaster _PartMaster)
        {
            try
            {
                if (_PartMaster != null)
                {
                    txtPartNumber.Texts = _PartMaster.Name;
                    txtPartDescription.Texts = _PartMaster.Description;
                    tbCanExpire.Checked = _PartMaster.IsExpire;
                    tbHasSerial.Checked = _PartMaster.IsSerial;
                    _SelectAssetTypeMaster = _PartMaster.AssetTypeMaster;
                    txtAssetType.Texts = _SelectAssetTypeMaster.Name;
                    _SelectAssetCategoryMaster = _PartMaster.AssetCategoryMaster;
                    txtAssetCategory.Texts = _SelectAssetCategoryMaster.Name;
                    _SelectManufacturerMaster = _PartMaster.ManufacturerMaster;
                    txtManufacturer.Texts = _SelectManufacturerMaster.Code + " # " + _SelectManufacturerMaster.Name;
                }
                else
                {
                    RJMessageBox.Show("Sorry No Record Found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception _Exception)
            {
                RJMessageBox.Show(_Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.ExitThread();
            }
        }
        private bool Cansave()
        {
            if (_SelectAssetTypeMaster == null)
            {
                RJMessageBox.Show("Select AssetType.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_SelectAssetCategoryMaster == null)
            {
                RJMessageBox.Show("Select AssetCategory.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (string.IsNullOrEmpty(txtPartNumber.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Part Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_SelectManufacturerMaster == null)
            {
                RJMessageBox.Show("Select Manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_Entities.PartMasters.Where(w => w.Name == txtPartNumber.Texts.Trim() && w.IsDelete == false && w.PartId != _PartMaster.PartId).Count() > 0)
            {
                RJMessageBox.Show("Part Number already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    AssetTypeMaster _AssettypeM = _Entities.AssetTypeMasters.FirstOrDefault(w => w.AssetTypeId == _SelectAssetTypeMaster.AssetTypeId);
                    AssetCategoryMaster _AssetcateM = _Entities.AssetCategoryMasters.FirstOrDefault(w => w.AssetCategoryId == _SelectAssetCategoryMaster.AssetCategoryId);
                    ManufacturerMaster _ManufacturerM = _Entities.ManufacturerMasters.FirstOrDefault(w => w.ManufacturerId == _SelectManufacturerMaster.ManufacturerId);
                    _PartMaster.AssetTypeMaster = _AssettypeM;
                    _PartMaster.AssetCategoryMaster = _AssetcateM;
                    _PartMaster.ManufacturerMaster = _ManufacturerM;
                    _PartMaster.Code = txtPartNumber.Texts.Trim();
                    _PartMaster.Name = txtPartNumber.Texts.Trim();
                    _PartMaster.Description = txtPartDescription.Texts.Trim();
                    _PartMaster.IsExpire = tbCanExpire.Checked;
                    _PartMaster.IsSerial = tbHasSerial.Checked;
                    _PartMaster.ModifiedBy = Program.UserId;
                    _PartMaster.ModifiedDate = DateTime.Now;
                    if (_PartMaster.PartId == 0)
                    {
                        _PartMaster.CreateDate = DateTime.Now;
                        _PartMaster.CreatedBy = Program.UserId;
                        _PartMaster.IsDelete = false;
                        _Entities.PartMasters.Add(_PartMaster);
                    }
                    _Entities.SaveChanges();
                    var msgresult = RJMessageBox.Show("Part saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (msgresult == DialogResult.OK || msgresult == DialogResult.Cancel)
                    {
                        _Mainform.MasterFormclick("PartViewUC");
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
    }
}
