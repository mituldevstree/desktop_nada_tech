﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NadaTechEntities : DbContext
    {
        public NadaTechEntities()
            : base("name=NadaTechEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTToken> AUTTokens { get; set; }
        public virtual DbSet<DeviceDetail> DeviceDetails { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<AssetCategoryMaster> AssetCategoryMasters { get; set; }
        public virtual DbSet<AssetMaster> AssetMasters { get; set; }
        public virtual DbSet<AssetTagDetail> AssetTagDetails { get; set; }
        public virtual DbSet<AssetTypeMaster> AssetTypeMasters { get; set; }
        public virtual DbSet<FormMaster> FormMasters { get; set; }
        public virtual DbSet<LocationMaster> LocationMasters { get; set; }
        public virtual DbSet<ManufacturerMaster> ManufacturerMasters { get; set; }
        public virtual DbSet<PartMaster> PartMasters { get; set; }
        public virtual DbSet<AssetImage> AssetImages { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<TransactionHeader> TransactionHeaders { get; set; }
        public virtual DbSet<UserGroupMaster> UserGroupMasters { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<ConfigMaster> ConfigMasters { get; set; }
    }
}