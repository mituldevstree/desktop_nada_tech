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
    public partial class ManufacturerAddView : Form
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<ManufacturerMaster> _ListOfManufacturerMaster;
        ManufacturerMaster _ManufacturerMaster;
        public ManufacturerMaster _SelectManufacturerMaster;
        FormMode formMode;

        public ManufacturerAddView()
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
            _ListOfManufacturerMaster = new BindingList<ManufacturerMaster>(_Entities.ManufacturerMasters.Where(w => w.IsDelete != true && (w.Name.Contains(String.IsNullOrEmpty(Search) ? w.Name : Search) || w.Code.Contains(String.IsNullOrEmpty(Search) ? w.Code : Search))).OrderByDescending(o => o.ManufacturerId).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            GrinEditDeleteDetailView.DataSource = _ListOfManufacturerMaster;
            GrinEditDeleteDetailView.Columns["ManufacturerId"].Visible = false;
            GrinEditDeleteDetailView.Columns["IsDelete"].Visible = false;
            GrinEditDeleteDetailView.Columns["CreateDate"].Visible = false;
            GrinEditDeleteDetailView.Columns["ModifiedBy"].Visible = false;
            GrinEditDeleteDetailView.Columns["ModifiedDate"].Visible = false;
            GrinEditDeleteDetailView.Columns["CreatedBy"].Visible = false;
            GrinEditDeleteDetailView.Columns["PartMasters"].Visible = false;

            GrinEditDeleteDetailView.Columns["Code"].DisplayIndex = 0;
            GrinEditDeleteDetailView.Columns["Name"].DisplayIndex = 1;
            GrinEditDeleteDetailView.Columns["Edit"].DisplayIndex = 2;
            GrinEditDeleteDetailView.Columns["Delete"].DisplayIndex = 3;


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
            txtCode.Texts = "";
            _ManufacturerMaster = new ManufacturerMaster();
        }

        private void FillRecord(ManufacturerMaster _ManufacturerMaster)
        {
            try
            {
                if (_ManufacturerMaster != null)
                {
                    txtCode.Texts = _ManufacturerMaster.Code;
                    txtName.Texts = _ManufacturerMaster.Name;
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

        private void GrinEditDeleteDetailView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GrinEditDeleteDetailView.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {
                    tabControl1.SelectedIndex = 1;
                    _ManufacturerMaster = _ListOfManufacturerMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_ManufacturerMaster != null)
                    {
                        FillRecord(_ManufacturerMaster);
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
                    if (_ListOfManufacturerMaster != null)
                    {
                        _ManufacturerMaster = _ListOfManufacturerMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                        if (_ManufacturerMaster.PartMasters.Where(w => w.IsDelete != true).Count() > 0)
                        {
                            RJMessageBox.Show("Manufacturer is in used with Part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            var msgresult = RJMessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgresult == DialogResult.Yes)
                            {
                                _ManufacturerMaster.IsDelete = true;
                                _ManufacturerMaster.ModifiedDate = DateTime.Now;
                                _ManufacturerMaster.ModifiedBy = Program.UserId;
                                _Entities.SaveChanges();
                                _ListOfManufacturerMaster.Remove(_ManufacturerMaster);
                            }
                        }

                    }
                }
            }
        }

        private bool Cansave()
        {
            if (string.IsNullOrEmpty(txtCode.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (_Entities.ManufacturerMasters.Where(w => w.Code == txtCode.Text.Trim() && w.IsDelete == false && w.ManufacturerId != _ManufacturerMaster.ManufacturerId).Count() > 0)
            {
                RJMessageBox.Show("Code already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (_ManufacturerMaster.ManufacturerId == 0)
                    {
                        IsAdd = true;
                        _ManufacturerMaster.CreateDate = DateTime.Now;
                        _ManufacturerMaster.CreatedBy = Program.UserId;
                        _Entities.ManufacturerMasters.Add(_ManufacturerMaster);
                        _ManufacturerMaster.IsDelete = false;
                    }
                    _ManufacturerMaster.Code = txtCode.Texts.Trim();
                    _ManufacturerMaster.Name = txtName.Texts.Trim();
                    _ManufacturerMaster.ModifiedBy = Program.UserId;
                    _ManufacturerMaster.ModifiedDate = DateTime.Now;
                    _Entities.SaveChanges();
                    if (IsAdd)
                    {
                        _ListOfManufacturerMaster.Insert(0, _ManufacturerMaster);
                    }
                    _ListOfManufacturerMaster.ResetBindings();
                    GrinEditDeleteDetailView.Refresh();
                    var msgresult = RJMessageBox.Show("Manufacturer saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _SelectManufacturerMaster = _ListOfManufacturerMaster[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_SelectManufacturerMaster != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        RJMessageBox.Show("Select Manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    RJMessageBox.Show("Select Manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
