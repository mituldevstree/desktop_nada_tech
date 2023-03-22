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
    public partial class ReportMainUC : UserControl
    {
        MasterForm _Mainform;
        public ReportMainUC(object _mainform)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
        }

        private void btnTransactionReport_Click(object sender, EventArgs e)
        {
            _Mainform.MasterFormclick("Reports", 1);
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            _Mainform.MasterFormclick("Reports", 2);
        }
    }
}
