//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NadaTech.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FormMaster()
        {
            this.UserPermissions = new HashSet<UserPermission>();
        }
    
        public int FormId { get; set; }
        public string FormName { get; set; }
        public string MenuName { get; set; }
        public string Module { get; set; }
        public Nullable<int> SortBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}