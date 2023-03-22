
using ClosedXML.Excel;
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
    public partial class Reports : UserControl
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        BindingList<AssetTagDetail> _ListOfAssetTagDetails;
        AssetTagDetail _AssetTagDetails;
        sqlhelper _obj = new sqlhelper();
        MasterForm _Mainform;
        int _id = 0;
        string ReportName = "";
        public Reports(object _mainform, object ReportType)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            _id = Convert.ToInt32(ReportType);
            ResetFilter();
            if (_id == 1)
            {
                ReportName = "Transaction Report";
            }
            else if (_id == 2)
            {
                ReportName = "Asset Report";
            }
            BindDataGrid();
        }

        void FillCmbReport()
        {
            BindingList<ReportType> _listofReportType = new BindingList<ReportType>();
            _listofReportType.Add(new ReportType { values = 0, Text = "Select Report" });
            _listofReportType.Add(new ReportType { values = 1, Text = "Transaction Report" });
            _listofReportType.Add(new ReportType { values = 2, Text = "Asset Report" });
            //CmbReport.DataSource = _listofReportType;
            //CmbReport.DisplayMember = "Text";
            //CmbReport.ValueMember = "values";
            //CmbReport.SelectedValue = 0;

        }

        private void BindDataGrid()
        {
            this.Cursor = Cursors.Default;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //if (CmbReport.SelectedValue.ToString() == "0")
                //{
                //    RJMessageBox.Show("Select Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
                //else
                //{

                string Search = txtSearch.Texts.Trim();
                int AssetStatus = ChkInStock.Checked == true && chkCheckedOut.Checked == false ? 1 : (ChkInStock.Checked == false && chkCheckedOut.Checked == true) ? 2 : 0;
                #region SqlParameter
                SqlParameter[] _Para =
                {
                                    new SqlParameter("@Action",_id.ToString()),
                                    new SqlParameter("@AssetTypeId",(_selectAssetType==null?0:_selectAssetType.AssetTypeId)),
                                    new SqlParameter("@AssetCategoryId",(_selectAssetCategoryMaster==null?0:_selectAssetCategoryMaster.AssetCategoryId)),
                                    new SqlParameter("@PartId",(_SelectPartMaster==null?0:_SelectPartMaster.PartId)),
                                    new SqlParameter("@LocationId",(_SelectLocationMaster==null?0:_SelectLocationMaster.LocationId)),
                                    new SqlParameter("@AssetStatus",AssetStatus),
                                    new SqlParameter("@IdleAssetDate",""),
                                    new SqlParameter("@Search",txtSearch.Texts.Trim()),
                                    new SqlParameter("@FromDate",txtFromDate.Value),
                                    new SqlParameter("@ToDate",txtToDate.Value),
                         };

                #endregion
                DataTable Dt = _obj.GetDataTable(CommandType.StoredProcedure, "SP_AllReports", _Para);
                GrinEditDeleteDetailView.DataSource = null;
                GrinEditDeleteDetailView.DataSource = Dt;

                //}
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
            GrinEditDeleteDetailView.DataSource = null;
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
            if (_id == 2)
            {
                labFromDate.Visible = false;
                labTodate.Visible = false;
                txtFromDate.Visible = false;
                txtToDate.Visible = false;
            }
            txtFromDate.Value = DateTime.Now;
            txtToDate.Value = DateTime.Now;
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
            //CmbReport.SelectedIndex = 0;
            ResetFilter();
        }

        private void CmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CmbReport.SelectedIndex > 0)
            //{
            //    if (CmbReport.SelectedValue.ToString() == "1")
            //    {
            //        ResetFilter();
            //        labFromDate.Visible = true;
            //        labTodate.Visible = true;
            //        txtFromDate.Visible = true;
            //        txtToDate.Visible = true;
            //    }
            //    else if (CmbReport.SelectedValue.ToString() == "2")
            //    {
            //        ResetFilter();
            //        labFromDate.Visible = false;
            //        labTodate.Visible = false;
            //        txtFromDate.Visible = false;
            //        txtToDate.Visible = false;
            //    }

            //}
            //else
            //{

            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                if (GrinEditDeleteDetailView.RowCount == 0)
                {
                    RJMessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    //Creating DataTable.
                    DataTable dt = new DataTable();

                    //Adding the Columns.
                    foreach (DataGridViewColumn column in GrinEditDeleteDetailView.Columns)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }

                    //Adding the Rows.
                    foreach (DataGridViewRow row in GrinEditDeleteDetailView.Rows)
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {

                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }

                    //Exporting to Excel.
                    string folderPath = "C:\\Excel\\";

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "sheet1");

                        //Adjust widths of Columns.
                        wb.Worksheet(1).Columns().AdjustToContents();
                        var SaveFile = new SaveFileDialog();
                        SaveFile.FileName = ReportName + "_" + DateTime.Now.ToString("dd-MM-yyyy");
                        SaveFile.DefaultExt = ".xlsx";
                        if (SaveFile.ShowDialog() == DialogResult.OK)
                        {
                            wb.SaveAs(SaveFile.FileName);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _Mainform.MasterFormclick("ReportMainUC");
        }
    }
}

public class ReportType
{
    public int values { get; set; }
    public string Text { get; set; }
}