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
using System.Windows.Forms.DataVisualization.Charting;

namespace NadaTech.View
{
    public partial class Dashboard : UserControl
    {
        sqlhelper _obj = new sqlhelper();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void BindDataGrid()
        {
            #region SqlParameter
            SqlParameter[] _Para =
            {
                            new SqlParameter("@Action",1)
                 };

            #endregion
            DataSet Dt = _obj.GetDataSet(CommandType.StoredProcedure, "SP_GetDashbordData", _Para);
            GrinhighestChechoutDetailView.DataSource = null;
            GrinhighestChechoutDetailView.DataSource = Dt.Tables[0];

            GridLocationPartAssetDetailview.DataSource = null;
            GridLocationPartAssetDetailview.DataSource = Dt.Tables[1];


            chart1.DataSource = Dt.Tables[2];
            chart1.Series["Asset"].XValueMember = "Title";
            chart1.Series["Asset"].YValueMembers = "Total";
            
            this.chart1.Titles.Add("Asset Detail");
            chart1.Series["Asset"].ChartType = SeriesChartType.Pie;
            //chart1.Series["Asset"].IsValueShownAsLabel = true;


            DataGridTransactionView.DataSource = null;
            DataGridTransactionView.DataSource = Dt.Tables[3];
        }

        void FillGrid()
        {
            List<AssetDetail> _listAssetDetail = new List<AssetDetail>();
            _listAssetDetail.Add(new AssetDetail { PartNumber = "Part 01", Description = "", TotalCheckout = 10 });
            _listAssetDetail.Add(new AssetDetail { PartNumber = "Part 02", Description = "", TotalCheckout = 20 });
            _listAssetDetail.Add(new AssetDetail { PartNumber = "Part 03", Description = "", TotalCheckout = 20 });
            _listAssetDetail.Add(new AssetDetail { PartNumber = "Part 04", Description = "", TotalCheckout = 30 });
            _listAssetDetail.Add(new AssetDetail { PartNumber = "Part 05", Description = "", TotalCheckout = 10 });
            _listAssetDetail.Add(new AssetDetail { PartNumber = "Part 06", Description = "", TotalCheckout = 10 });
            GrinhighestChechoutDetailView.DataSource = null;
            GrinhighestChechoutDetailView.DataSource = _listAssetDetail;

            List<PartAssetDetail> _listPartAssetDetail = new List<PartAssetDetail>();
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 01", PartNumber = "Part 01", Description = "", TotalAsset = 5 });
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 02", PartNumber = "Part 01", Description = "", TotalAsset = 5 });
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 01", PartNumber = "Part 02", Description = "", TotalAsset = 20 });
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 02", PartNumber = "Part 03", Description = "", TotalAsset = 20 });
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 03", PartNumber = "Part 04", Description = "", TotalAsset = 10 });
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 02", PartNumber = "Part 04", Description = "", TotalAsset = 20 });
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 01", PartNumber = "Part 05", Description = "", TotalAsset = 10 });
            _listPartAssetDetail.Add(new PartAssetDetail { Location = "Location 02", PartNumber = "Part 06", Description = "", TotalAsset = 10 });
            GridLocationPartAssetDetailview.DataSource = null;
            GridLocationPartAssetDetailview.DataSource = _listPartAssetDetail;


        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.Cursor= Cursors.WaitCursor;
            BindDataGrid();
            this.Cursor = Cursors.Default;


        }
    }
}
public class AssetDetail
{
    public string PartNumber { get; set; }
    public string Description { get; set; }
    public int TotalCheckout { get; set; }
}
public class PartAssetDetail
{
    public string Location { get; set; }
    public string PartNumber { get; set; }
    public string Description { get; set; }
    public int TotalAsset { get; set; }
}