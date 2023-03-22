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
    public partial class AssetSelect : Form
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        sqlhelper _obj = new sqlhelper();
        FormMode formMode;

        BindingList<ManualTagReader> _ListTagReader;
        public ManualTagReader _selectManualTagReader;
        BindingList<LocationMaster> _listLocation = new BindingList<LocationMaster>();
        public AssetSelect()
        {
            InitializeComponent();

        }
        internal enum FormMode
        {
            Add, Edit, View
        }
        int AssetStatus = 0;
        internal DialogResult Show(FormMode formMode, int assetstatus)
        {
            AssetStatus = assetstatus;
            if (AssetStatus == 1)
            {
                lablocation.Visible = false;
                CmbLocation.Visible = false;
            }
            else
            {
                lablocation.Visible = false;
                CmbLocation.Visible = false;
            }
            //FillComboBox();
            BindDataGrid(AssetStatus);
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
        void FillComboBox()
        {
            _listLocation = new BindingList<LocationMaster>(_Entities.LocationMasters.Where(w => w.IsDelete != true).ToList());
            CmbLocation.DataSource = _listLocation;
            CmbLocation.DisplayMember = "Name";
            CmbLocation.ValueMember = "LocationId";
            CmbLocation.SelectedIndex = -1;
        }
        private void BindDataGrid(int AssetStatus)
        {
            #region SqlParameter
            SqlParameter[] _Para =
            {
                            new SqlParameter("@Action",1),
                            new SqlParameter("@PartAsset",txtSearchPart.Texts.Trim()),
                            new SqlParameter("@Tag",txtSearchTag.Texts.Trim()),
                            new SqlParameter("@SerialNumber",txtSearchSearial.Texts.Trim()),
                            new SqlParameter("@AssetStatus",AssetStatus)
                 };

            #endregion
            DataTable Dt = _obj.GetDataTable(CommandType.StoredProcedure, "SP_GetManualAssettagdata", _Para);
            _ListTagReader = new BindingList<ManualTagReader>(Dt.AsEnumerable().Select(s => new ManualTagReader
            {
                AssetTagId = s.Field<long>("AssetTagId"),
                PartNumber = s.Field<string>("PartNumber"),
                Description = s.Field<string>("Description"),
                AssetName = s.Field<string>("AssetName"),
                TagData = s.Field<string>("TagData"),
                Location = s.Field<string>("FromLocation"),
                Status = s.Field<string>("Status"),
            }).ToList());
            GrinEditDeleteDetailView.DataSource = null;
            GrinEditDeleteDetailView.DataSource = _ListTagReader;
            GrinEditDeleteDetailView.Columns["AssetTagId"].Visible = false;
            GrinEditDeleteDetailView.Columns["ToLocation"].Visible = false;
            GrinEditDeleteDetailView.Columns["ToLocationId"].Visible = false;
            GrinEditDeleteDetailView.Columns["ToLocationName"].Visible = false;


        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                btnSelect.Visible = true;

            }
            else
            {
                btnSelect.Visible = false;
            }
        }

        private void GrinEditDeleteDetailView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (GrinEditDeleteDetailView.CurrentRow != null)
                {


                    _selectManualTagReader = _ListTagReader[GrinEditDeleteDetailView.CurrentRow.Index];
                    if (_selectManualTagReader != null)
                    {

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        RJMessageBox.Show("Select Asset.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    RJMessageBox.Show("Select Asset.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchPart__TextChanged(object sender, EventArgs e)
        {
            BindDataGrid(AssetStatus);
        }
    }
}


public class ManualTagReader
{
    public long AssetTagId { get; set; }
    public string PartNumber { get; set; }
    public string Description { get; set; }
    public string AssetName { get; set; }
    public string Location { get; set; }
    public string TagData { get; set; }
    public string Status { get; set; }
    public string ToLocation { get; set; }
    public string ToLocationName { get; set; }
    public int ToLocationId { get; set; }

}