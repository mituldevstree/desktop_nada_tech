//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NadaTech_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionDetail
    {
        public long TraDetailId { get; set; }
        public Nullable<long> TransactionId { get; set; }
        public Nullable<long> AssetTagId { get; set; }
        public Nullable<int> LocationId { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public Nullable<int> LastLocationId { get; set; }
    
        public virtual AssetTagDetail AssetTagDetail { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
        public virtual TransactionHeader TransactionHeader { get; set; }
    }
}
