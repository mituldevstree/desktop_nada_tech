using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadaTech.Data
{
    public partial class AssetCategoryMaster
    {
        public string AssetType { get { return AssetTypeMaster.Name; } }

    }
}
