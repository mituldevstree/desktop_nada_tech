using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadaTech.Data
{
    public partial class PartMaster
    {
        public string AssetType { get { return AssetTypeMaster.Name; } }
        public string AssetCategory { get { return AssetCategoryMaster.Name; } }
        public string Manufacturer { get { return ManufacturerMaster.Name; } }                                                                                                                                                                                            

    }
}
