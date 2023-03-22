using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadaTech.Data
{
    public partial class UserMaster
    {
        public string UserRole { get { return UserGroupMaster.Name; } }

    }
}
