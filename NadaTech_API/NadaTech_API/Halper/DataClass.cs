using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NadaTech_API
{
    public class DataClass
    {
    }
    public class ResponseDefault
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public dynamic Response { get; set; }

    }
    public class ReqUserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Puch_token { get; set; }
        public string Devicetype { get; set; }
        public string Deviceinfo { get; set; }
        //public string Deviceid { get; set; }
    }
    public class RequestDefault
    {
        public int UserId { get; set; }

    }
    public class RequestAssetCategory : RequestDefault
    {
        public int AssetTypeId { get; set; }

    }

    public class Reqtagdata
    {
        public string Tag { get; set; }

    }
    public class ReqInventoryReport
    {
        public int AssetTypeId { get; set; }
        public int AssetCategoryId { get; set; }
        public long PartId { get; set; }
        public bool CheckIn { get; set; }
        public bool CheckOut { get; set; }
        public int LocationId { get; set; }
        public string IdleAssetDate { get; set; }
        public string Search { get; set; }
        public long PageNumber { get; set; }
        public long PageSize { get; set; }
    }

    public class ReqCheckinCheckout
    {
        public string TransactionType { get; set; }//In,Out,Move
        public int LocationId { get; set; }
        public string Notes { get; set; }
        public List<ReqCheckinCheckoutDetail>  TagDetail { get; set; }

    }
    public class ReqCheckinCheckoutDetail
    {
        public string Tag { get; set; }

    }

    public class ResAssetImg
    {
        public string ImgName { get; set; }

    }
    public class ReqLocation
    {
        public int LocationId { get; set; }
        public string LocationCode { get; set; }
        public string Location { get; set; }

    }
    public class ReqAssetType
    {
        public int AssetTypeId { get; set; }
        public string AssetType { get; set; }

    }
    public class ReqAssetCategory
    {
        public int AssetCategoryId { get; set; }
        public int AssetTypeId { get; set; }
        public string AssetCategory { get; set; }

    }
    public class ReqManufacturer
    {
        public int ManufacturerId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
    public class ReqPart
    {
        public long PartId { get; set; }
        public int AssetTypeId { get; set; }
        public int AssetCategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsExpire { get; set; }
        public bool IsSerial { get; set; }

    }
}