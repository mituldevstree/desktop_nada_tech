using NadaTech_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NadaTech_API.Controllers
{
    public class MobileApiController : ApiController
    {
        sqlhelper _obj = new sqlhelper();

        #region User

        [HttpPost]
        [Route("api/User/UserLogin")]
        public HttpResponseMessage UserLogin(ReqUserLogin model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {

                if (!string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password))
                {
                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {

                        var Pwd = Common.EncryptNumber("", model.Password);
                        var _UserMaster = ctx.UserMasters.FirstOrDefault(x => x.UserName == model.Username && x.Password == Pwd && x.IsDelete == false);
                        if (_UserMaster == null)
                        {
                            objUser.Message = "InValid Login Credintial";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        //if (!string.IsNullOrEmpty(_UserMaster.DeviceID))
                        //{
                        //    if (_UserMaster.DeviceID != model.Deviceid)
                        //    {
                        //        objUser.Message = "Unauthorized ";
                        //        return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                        //    }
                        //}
                        //else
                        //{
                        //    _UserMaster.DeviceID = model.Deviceid;
                        //}

                        DeviceDetail _DeviceDetail = ctx.DeviceDetails.FirstOrDefault(x => x.UserId == _UserMaster.UserId);
                        if (_DeviceDetail == null)
                        {
                            _DeviceDetail = new DeviceDetail
                            {
                                UserId = _UserMaster.UserId,
                                CreateDate = DateTime.Now
                            };
                            ctx.DeviceDetails.Add(_DeviceDetail);
                        }
                        _DeviceDetail.Puch_Token = model.Puch_token;
                        _DeviceDetail.DeviceType = model.Devicetype;
                        _DeviceDetail.DeviceInfo = model.Deviceinfo;
                        _DeviceDetail.LastLogin = DateTime.Now;

                        ctx.SaveChanges();


                        AUTToken _AUTToken = ctx.AUTTokens.FirstOrDefault(x => x.UserId == _UserMaster.UserId);
                        if (_AUTToken == null)
                        {
                            _AUTToken = new AUTToken();
                            _AUTToken.UserId = _UserMaster.UserId;
                            ctx.AUTTokens.Add(_AUTToken);
                        }
                        _AUTToken.Token = Guid.NewGuid().ToString("N");


                        List<UserPermission> Um = new List<UserPermission>(ctx.UserPermissions.Where(w => w.UserGroupId == _UserMaster.UserGroupId).ToList());
                        string TagPrefix = "";
                        ConfigMaster _PrefixCon = ctx.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "TAGPREFIX");
                        if (_PrefixCon != null)
                        {
                            TagPrefix = _PrefixCon.ConfigValues;
                        }
                        var Data = new
                        {
                            _UserMaster.UserId,
                            UserName = _UserMaster.Name,
                            _UserMaster.Email,
                            _UserMaster.Phone,
                            IsCreateAsset = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            IsManageAsset = (Um.Where(w => w.FormMaster.MenuName == "Manage Asset").Count() == 0 ? false : true),
                            IsCheckInOut = (Um.Where(w => w.FormMaster.MenuName == "Check In").Count() == 0 ? false : true),
                            IsCheckOut = (Um.Where(w => w.FormMaster.MenuName == "Check Out").Count() == 0 ? false : true),
                            IsLocation = (Um.Where(w => w.FormMaster.MenuName == "Location").Count() == 0 ? false : true),
                            IsPart = (Um.Where(w => w.FormMaster.MenuName == "Part Master").Count() == 0 ? false : true),
                            IsAssetType = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            IsAssetCategory = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            IsManufacturer = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            TagPrefix = string.IsNullOrEmpty(TagPrefix) ? "" : Common.ConvertASCIItoHex(TagPrefix),
                            AuthToken = _AUTToken.Token,
                            //_UserMaster.DeviceID,
                        };
                        ctx.SaveChanges();

                        objUser.Message = "Success";
                        objUser.Status = true;
                        objUser.Response = Data;

                    }
                }
                else
                {
                    objUser.Message = "UserName or Password cannot be blank !";
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        [HttpGet]
        [Route("api/Master/GetUserProfile")]
        public HttpResponseMessage GetUserProfile()
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var ctx = HttpContext.Current;
                if (ctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }

                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = ctx.Request.Headers.GetValues("userid").First();
                    using (NadaTechEntities Entities = new NadaTechEntities())
                    {
                        int UId = Convert.ToInt32(UserId);
                        var _UserMaster = Entities.UserMasters.FirstOrDefault(x => x.UserId == UId);
                        if (_UserMaster == null)
                        {
                            objUser.Message = "InValid Login Credintial";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        List<UserPermission> Um = new List<UserPermission>(Entities.UserPermissions.Where(w => w.UserGroupId == _UserMaster.UserGroupId).ToList());
                        string TagPrefix = "";
                        ConfigMaster _PrefixCon = Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "TAGPREFIX");
                        if (_PrefixCon != null)
                        {
                            TagPrefix = _PrefixCon.ConfigValues;
                        }
                        var Data = new
                        {
                            _UserMaster.UserId,
                            UserName = _UserMaster.Name,
                            _UserMaster.Email,
                            _UserMaster.Phone,
                            IsCreateAsset = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            IsManageAsset = (Um.Where(w => w.FormMaster.MenuName == "Manage Asset").Count() == 0 ? false : true),
                            IsCheckInOut = (Um.Where(w => w.FormMaster.MenuName == "Check In").Count() == 0 ? false : true),
                            IsCheckOut = (Um.Where(w => w.FormMaster.MenuName == "Check Out").Count() == 0 ? false : true),
                            IsLocation = (Um.Where(w => w.FormMaster.MenuName == "Location").Count() == 0 ? false : true),
                            IsPart = (Um.Where(w => w.FormMaster.MenuName == "Part Master").Count() == 0 ? false : true),
                            IsAssetType = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            IsAssetCategory = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            IsManufacturer = (Um.Where(w => w.FormMaster.MenuName == "Create Asset").Count() == 0 ? false : true),
                            TagPrefix = string.IsNullOrEmpty(TagPrefix) ? "" : Common.ConvertASCIItoHex(TagPrefix),
                        };

                        objUser.Message = "Success";
                        objUser.Status = true;
                        objUser.Response = Data;
                    }
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        #endregion

        #region Master

        #region Location

        [HttpGet]
        [Route("api/Master/GetLocation")]
        public HttpResponseMessage GetLocation(string search = "")
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                //var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                //if (!string.IsNullOrEmpty(Msg))
                //{
                //    objUser.Message = Msg;
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                //}
                //else
                //{
                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        var _Data = ctx.LocationMasters.Where(w => w.IsDelete == false && (w.Name.Contains(String.IsNullOrEmpty(search) ? w.Name : search) || w.Code.Contains(String.IsNullOrEmpty(search) ? w.Code : search))).OrderBy(o => o.Name).Select(s => new
                        {
                            LocationId = s.LocationId,
                            LocationCode = s.Code,
                            Location = s.Name,
                        }).ToList();

                        objUser.Message = "Success";
                        objUser.Response = _Data;
                        objUser.Status = true;
                    }
                //}

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [HttpPost]
        [Route("api/Master/SetLocation")]
        public HttpResponseMessage SetLocation(ReqLocation model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (string.IsNullOrEmpty(model.LocationCode))
                        {
                            objUser.Message = "Enter LocationCode";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        if (string.IsNullOrEmpty(model.Location))
                        {
                            objUser.Message = "Enter Location";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (ctx.LocationMasters.Where(w => w.Code == model.LocationCode.Trim() && w.IsDelete == false && w.LocationId != model.LocationId).Count() > 0)
                        {
                            objUser.Message = "Location Code already exists.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        LocationMaster locationMaster = ctx.LocationMasters.FirstOrDefault(w => w.LocationId == model.LocationId && w.IsDelete == false);
                        if (locationMaster == null)
                        {
                            locationMaster = new LocationMaster();
                            locationMaster.CreateDate = DateTime.Now;
                            locationMaster.CreatedBy = Convert.ToInt32(UserId);
                            locationMaster.IsDelete = false;
                            ctx.LocationMasters.Add(locationMaster);
                        }
                        locationMaster.Name = model.Location;
                        locationMaster.Code = model.LocationCode;
                        locationMaster.ModifiedBy = Convert.ToInt32(UserId);
                        locationMaster.ModifiedDate = DateTime.Now;
                        ctx.SaveChanges();
                        objUser.Message = "Location Saved successfully.";
                        objUser.Response = new
                        {
                            LocationId = locationMaster.LocationId,
                            LocationCode = locationMaster.Code,
                            Location = locationMaster.Name
                        };
                        objUser.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [HttpGet]
        [Route("api/Master/DeleteLocation")]
        public HttpResponseMessage DeleteLocation(int locationid)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (ctx.AssetTagDetails.Where(w => w.IsDelete != true && w.LocationId == locationid).Count() > 0)
                        {
                            objUser.Message = "Location is in used with AssetTag.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        LocationMaster _LocationMaster = ctx.LocationMasters.FirstOrDefault(f => f.LocationId == locationid && f.IsDelete == false);
                        if (_LocationMaster != null)
                        {
                            _LocationMaster.IsDelete = true;
                            _LocationMaster.ModifiedDate = DateTime.Now;
                            _LocationMaster.ModifiedBy = Convert.ToInt32(UserId);
                            ctx.SaveChanges();
                            objUser.Message = "Location Deleted successfully.";
                            objUser.Status = true;
                        }
                        else
                        {
                            objUser.Message = "Location not found.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        #endregion

        #region AssetType

        [HttpGet]
        [Route("api/Master/GetAssetType")]
        public HttpResponseMessage GetAssetType()
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        var _Data = ctx.AssetTypeMasters.Where(w => w.IsDelete == false).OrderBy(o => o.Name).Select(s => new
                        {
                            AssetTypeId = s.AssetTypeId,
                            AssetType = s.Name
                        }).ToList();

                        objUser.Message = "Success";
                        objUser.Response = _Data;
                        objUser.Status = true;
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [Route("api/Master/SetAssetType")]
        public HttpResponseMessage SetAssetType(ReqAssetType model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {

                        if (string.IsNullOrEmpty(model.AssetType))
                        {
                            objUser.Message = "Enter Asset Type";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (ctx.AssetTypeMasters.Where(w => w.Name == model.AssetType.Trim() && w.IsDelete == false && w.AssetTypeId != model.AssetTypeId).Count() > 0)
                        {
                            objUser.Message = "Asset Type already exists.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        AssetTypeMaster assettypemaster = ctx.AssetTypeMasters.FirstOrDefault(w => w.AssetTypeId == model.AssetTypeId && w.IsDelete == false);
                        if (assettypemaster == null)
                        {
                            assettypemaster = new AssetTypeMaster();
                            assettypemaster.CreateDate = DateTime.Now;
                            assettypemaster.CreatedBy = Convert.ToInt32(UserId);
                            assettypemaster.IsDelete = false;
                            ctx.AssetTypeMasters.Add(assettypemaster);
                        }
                        assettypemaster.Name = model.AssetType;
                        assettypemaster.ModifiedBy = Convert.ToInt32(UserId);
                        assettypemaster.ModifiedDate = DateTime.Now;
                        ctx.SaveChanges();
                        objUser.Message = "Asset Type Saved successfully.";
                        objUser.Response = new
                        {
                            AssetTypeId = assettypemaster.AssetTypeId,
                            AssetType = assettypemaster.Name,
                        };
                        objUser.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [HttpGet]
        [Route("api/Master/DeleteAssetType")]
        public HttpResponseMessage DeleteAssetType(int assettypeid)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (ctx.AssetCategoryMasters.Where(w => w.IsDelete != true && w.AssetTypeId == assettypeid).Count() > 0)
                        {
                            objUser.Message = "Asset Type is in used with Asset Category.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        AssetTypeMaster _AssetTypeMaster = ctx.AssetTypeMasters.FirstOrDefault(f => f.AssetTypeId == assettypeid && f.IsDelete == false);
                        if (_AssetTypeMaster != null)
                        {
                            _AssetTypeMaster.IsDelete = true;
                            _AssetTypeMaster.ModifiedDate = DateTime.Now;
                            _AssetTypeMaster.ModifiedBy = Convert.ToInt32(UserId);
                            ctx.SaveChanges();
                            objUser.Message = "Asset Type Deleted successfully.";
                            objUser.Status = true;
                        }
                        else
                        {
                            objUser.Message = "Asset Type not found.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        #endregion

        #region AssetCategory

        [HttpGet]
        [Route("api/Master/GetAssetCategory")]
        public HttpResponseMessage GetAssetCategory(int AssetTypeId)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        var _Data = ctx.AssetCategoryMasters.Where(w => w.IsDelete == false && w.AssetTypeId == AssetTypeId).OrderBy(o => o.Name).Select(s => new
                        {
                            AssetTypeId = s.AssetTypeId,
                            AssetType = s.AssetTypeMaster.Name,
                            AssetCategoryId = s.AssetCategoryId,
                            AssetCategory = s.Name,
                        }).ToList();

                        objUser.Message = "Success";
                        objUser.Response = _Data;
                        objUser.Status = true;
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [Route("api/Master/SetAssetCategory")]
        public HttpResponseMessage SetAssetCategory(ReqAssetCategory model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (model.AssetTypeId <= 0)
                        {
                            objUser.Message = "Enter Asset Type";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (string.IsNullOrEmpty(model.AssetCategory))
                        {
                            objUser.Message = "Enter Asset Category";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (ctx.AssetCategoryMasters.Where(w => w.Name == model.AssetCategory.Trim() && w.IsDelete == false && w.AssetCategoryId != model.AssetCategoryId && w.AssetTypeId == model.AssetTypeId).Count() > 0)
                        {
                            objUser.Message = "Asset Category already exists.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        AssetCategoryMaster assetCategoryMaster = ctx.AssetCategoryMasters.FirstOrDefault(w => w.AssetCategoryId == model.AssetCategoryId && w.IsDelete == false);
                        if (assetCategoryMaster == null)
                        {
                            assetCategoryMaster = new AssetCategoryMaster();
                            assetCategoryMaster.CreateDate = DateTime.Now;
                            assetCategoryMaster.CreatedBy = Convert.ToInt32(UserId);
                            assetCategoryMaster.IsDelete = false;
                            ctx.AssetCategoryMasters.Add(assetCategoryMaster);
                        }
                        AssetTypeMaster _AssettypeM = ctx.AssetTypeMasters.First(w => w.AssetTypeId == model.AssetTypeId);

                        assetCategoryMaster.AssetTypeId = model.AssetTypeId;
                        assetCategoryMaster.AssetTypeMaster = _AssettypeM;
                        assetCategoryMaster.Name = model.AssetCategory;
                        assetCategoryMaster.ModifiedBy = Convert.ToInt32(UserId);
                        assetCategoryMaster.ModifiedDate = DateTime.Now;
                        ctx.SaveChanges();
                        objUser.Message = "Asset Category Saved successfully.";
                        objUser.Response = new
                        {
                            AssetTypeId = assetCategoryMaster.AssetTypeId,
                            AssetType = assetCategoryMaster.AssetTypeMaster.Name,
                            AssetCategoryId = assetCategoryMaster.AssetCategoryId,
                            AssetCategory = assetCategoryMaster.Name
                        };
                        objUser.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [HttpGet]
        [Route("api/Master/DeleteAssetCategory")]
        public HttpResponseMessage DeleteAssetCategory(int assetcategoryid)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (ctx.PartMasters.Where(w => w.IsDelete != true && w.AssetCategoryId == assetcategoryid).Count() > 0)
                        {
                            objUser.Message = "Asset Category is in used with Part.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        AssetCategoryMaster _AssetCategoryMaster = ctx.AssetCategoryMasters.FirstOrDefault(f => f.AssetCategoryId == assetcategoryid && f.IsDelete == false);
                        if (_AssetCategoryMaster != null)
                        {
                            _AssetCategoryMaster.IsDelete = true;
                            _AssetCategoryMaster.ModifiedDate = DateTime.Now;
                            _AssetCategoryMaster.ModifiedBy = Convert.ToInt32(UserId);
                            ctx.SaveChanges();
                            objUser.Message = "Asset Category Deleted successfully.";
                            objUser.Status = true;
                        }
                        else
                        {
                            objUser.Message = "Asset Category not found.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        #endregion

        #region Manufacturer

        [HttpGet]
        [Route("api/Master/GetManufacturer")]
        public HttpResponseMessage GetManufacturer()
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        var _Data = ctx.ManufacturerMasters.Where(w => w.IsDelete == false).OrderBy(o => o.Name).Select(s => new
                        {
                            ManufacturerId = s.ManufacturerId,
                            Manufacturer = s.Name,
                            Code = s.Code
                        }).ToList();

                        objUser.Message = "Success";
                        objUser.Response = _Data;
                        objUser.Status = true;
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        [Route("api/Master/SetManufacturer")]
        public HttpResponseMessage SetManufacturer(ReqManufacturer model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (string.IsNullOrEmpty(model.Code))
                        {
                            objUser.Message = "Enter Code";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        if (string.IsNullOrEmpty(model.Name))
                        {
                            objUser.Message = "Enter Name";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (ctx.ManufacturerMasters.Where(w => w.Code == model.Code.Trim() && w.IsDelete == false && w.ManufacturerId != model.ManufacturerId).Count() > 0)
                        {
                            objUser.Message = "Manufacturer already exists.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        ManufacturerMaster manufacturermaster = ctx.ManufacturerMasters.FirstOrDefault(w => w.ManufacturerId == model.ManufacturerId && w.IsDelete == false);
                        if (manufacturermaster == null)
                        {
                            manufacturermaster = new ManufacturerMaster();
                            manufacturermaster.CreateDate = DateTime.Now;
                            manufacturermaster.CreatedBy = Convert.ToInt32(UserId);
                            manufacturermaster.IsDelete = false;
                            ctx.ManufacturerMasters.Add(manufacturermaster);
                        }
                        manufacturermaster.Code = model.Code;
                        manufacturermaster.Name = model.Name;
                        manufacturermaster.ModifiedBy = Convert.ToInt32(UserId);
                        manufacturermaster.ModifiedDate = DateTime.Now;
                        ctx.SaveChanges();
                        objUser.Message = "Manufacturer Saved successfully.";
                        objUser.Response = new
                        {
                            ManufacturerId = manufacturermaster.ManufacturerId,
                            Manufacturer = manufacturermaster.Name,
                            Code = manufacturermaster.Code
                        };
                        objUser.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [HttpGet]
        [Route("api/Master/DeleteManufacturer")]
        public HttpResponseMessage DeleteManufacturer(int manufacturerid)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (ctx.PartMasters.Where(w => w.IsDelete != true && w.ManufacturerId == manufacturerid).Count() > 0)
                        {
                            objUser.Message = "Manufacturer is in used with Part.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        ManufacturerMaster _ManufacturerMaster = ctx.ManufacturerMasters.FirstOrDefault(f => f.ManufacturerId == manufacturerid && f.IsDelete == false);
                        if (_ManufacturerMaster != null)
                        {
                            _ManufacturerMaster.IsDelete = true;
                            _ManufacturerMaster.ModifiedDate = DateTime.Now;
                            _ManufacturerMaster.ModifiedBy = Convert.ToInt32(UserId);
                            ctx.SaveChanges();
                            objUser.Message = "Manufacturer Deleted successfully.";
                            objUser.Status = true;
                        }
                        else
                        {
                            objUser.Message = "Manufacturer not found.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        #endregion

        #region  Part

        [HttpGet]
        [Route("api/Master/GetPart")]
        public HttpResponseMessage GetPart()
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        var _Data = ctx.PartMasters.Where(w => w.IsDelete == false).OrderBy(o => o.Code).Select(s => new
                        {
                            AssetType = s.AssetTypeMaster.Name,
                            AssetCategory = s.AssetCategoryMaster.Name,
                            AssetTypeId = s.AssetTypeId,
                            AssetCategoryId = s.AssetCategoryId,
                            ManufacturerId = s.ManufacturerId,
                            Manufacturer = s.ManufacturerMaster.Code + " # " + s.ManufacturerMaster.Name,
                            PartId = s.PartId,
                            PartNumber = s.Code,
                            PartName = s.Name,
                            s.Description,
                            s.IsExpire,
                            s.IsSerial,

                        }).ToList();

                        objUser.Message = "Success";
                        objUser.Response = _Data;
                        objUser.Status = true;
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        [Route("api/Master/SetPart")]
        public HttpResponseMessage SetPart(ReqPart model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (model.AssetTypeId <= 0)
                        {
                            objUser.Message = "Select Asset Type";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (model.AssetCategoryId <= 0)
                        {
                            objUser.Message = "Select Asset Category";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (model.ManufacturerId <= 0)
                        {
                            objUser.Message = "Select Manufacturer";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        if (string.IsNullOrEmpty(model.Name))
                        {
                            objUser.Message = "Enter Name";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (ctx.PartMasters.Where(w => w.Name == model.Name.Trim() && w.IsDelete == false && w.PartId != model.PartId).Count() > 0)
                        {
                            objUser.Message = "Part already exists.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        PartMaster partmaster = ctx.PartMasters.FirstOrDefault(w => w.PartId == model.PartId && w.IsDelete == false);
                        if (partmaster == null)
                        {
                            partmaster = new PartMaster();
                            partmaster.CreateDate = DateTime.Now;
                            partmaster.CreatedBy = Convert.ToInt32(UserId);
                            partmaster.IsDelete = false;
                            ctx.PartMasters.Add(partmaster);
                        }
                        partmaster.Code = model.Name;
                        partmaster.Name = model.Name;
                        partmaster.Description = model.Description;
                        partmaster.IsExpire = model.IsExpire;
                        partmaster.IsSerial = model.IsSerial;
                        AssetTypeMaster _AssettypeM = ctx.AssetTypeMasters.FirstOrDefault(w => w.AssetTypeId == model.AssetTypeId);
                        AssetCategoryMaster _AssetcateM = ctx.AssetCategoryMasters.FirstOrDefault(w => w.AssetCategoryId == model.AssetCategoryId);
                        ManufacturerMaster _ManufacturerM = ctx.ManufacturerMasters.FirstOrDefault(w => w.ManufacturerId == model.ManufacturerId);
                        partmaster.AssetTypeMaster = _AssettypeM;
                        partmaster.AssetCategoryMaster = _AssetcateM;
                        partmaster.ManufacturerMaster = _ManufacturerM;
                        partmaster.AssetTypeId = model.AssetTypeId;
                        partmaster.AssetCategoryId = model.AssetCategoryId;
                        partmaster.ManufacturerId = model.ManufacturerId;
                        partmaster.ModifiedBy = Convert.ToInt32(UserId);
                        partmaster.ModifiedDate = DateTime.Now;
                        ctx.SaveChanges();
                        objUser.Message = "Part Saved successfully.";
                        objUser.Response = new
                        {
                            AssetType = partmaster.AssetTypeMaster.Name,
                            AssetCategory = partmaster.AssetCategoryMaster.Name,
                            AssetTypeId = partmaster.AssetTypeId,
                            AssetCategoryId = partmaster.AssetCategoryId,
                            ManufacturerId = partmaster.ManufacturerId,
                            Manufacturer = partmaster.ManufacturerMaster.Code + " # " + partmaster.ManufacturerMaster.Name,
                            PartId = partmaster.PartId,
                            PartNumber = partmaster.Code,
                            PartName = partmaster.Name,
                            partmaster.Description,
                            partmaster.IsExpire,
                            partmaster.IsSerial,
                        };
                        objUser.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }
        [HttpGet]
        [Route("api/Master/DeletePart")]
        public HttpResponseMessage DeletePart(long partid)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var httpctx = HttpContext.Current;
                if (httpctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    string UserId = httpctx.Request.Headers.GetValues("userid").First();

                    using (NadaTechEntities ctx = new NadaTechEntities())
                    {
                        if (ctx.AssetMasters.Where(w => w.IsDelete != true && w.PartId == partid).Count() > 0)
                        {
                            objUser.Message = "Part is in used with Asset.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        PartMaster _PartMaster = ctx.PartMasters.FirstOrDefault(f => f.PartId == partid && f.IsDelete == false);
                        if (_PartMaster != null)
                        {
                            _PartMaster.IsDelete = true;
                            _PartMaster.ModifiedDate = DateTime.Now;
                            _PartMaster.ModifiedBy = Convert.ToInt32(UserId);
                            ctx.SaveChanges();
                            objUser.Message = "Part Deleted successfully.";
                            objUser.Status = true;
                        }
                        else
                        {
                            objUser.Message = "Part not found.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        #endregion

        #region AssetRegistration

        [HttpPost]
        [Route("api/Master/SetAssetRegistration")]
        public async Task<HttpResponseMessage> SetAssetRegistration()
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var ctx = HttpContext.Current;
                if (ctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }

                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {

                    string UserId = ctx.Request.Headers.GetValues("userid").First();
                    string PartId = (ctx.Request.Form.AllKeys.Contains("PartId") ? ctx.Request.Form.GetValues("PartId")[0] : "");
                    string AssetName = (ctx.Request.Form.AllKeys.Contains("AssetName") ? ctx.Request.Form.GetValues("AssetName")[0] : "");
                    string SerialNumber = (ctx.Request.Form.AllKeys.Contains("SerialNumber") ? ctx.Request.Form.GetValues("SerialNumber")[0] : "");
                    string ExpiryDate = (ctx.Request.Form.AllKeys.Contains("ExpiryDate") ? ctx.Request.Form.GetValues("ExpiryDate")[0] : "");
                    string Notes = (ctx.Request.Form.AllKeys.Contains("Notes") ? ctx.Request.Form.GetValues("Notes")[0] : "");
                    string LocationId = (ctx.Request.Form.AllKeys.Contains("LocationId") ? ctx.Request.Form.GetValues("LocationId")[0] : "");
                    string TagData = (ctx.Request.Form.AllKeys.Contains("TagData") ? ctx.Request.Form.GetValues("TagData")[0] : "");
                    string IsMB = (ctx.Request.Form.AllKeys.Contains("IsMoveable") ? ctx.Request.Form.GetValues("IsMoveable")[0] : "");
                    bool IsMoveable = string.IsNullOrEmpty(IsMB) ? true : Convert.ToBoolean(IsMB);
                    List<Reqtagdata> _ListReqtagdata = JsonConvert.DeserializeObject<List<Reqtagdata>>(TagData);

                    #region Validation
                    if (string.IsNullOrEmpty(PartId))
                    {
                        objUser.Message = "Part required to register assets.";
                        return Request.CreateResponse(HttpStatusCode.OK, objUser);
                    }
                    else if (string.IsNullOrEmpty(AssetName))
                    {
                        objUser.Message = "Asset ID/Name required to register assets.";
                        return Request.CreateResponse(HttpStatusCode.OK, objUser);
                    }
                    else if (string.IsNullOrEmpty(LocationId))
                    {
                        objUser.Message = "Location required to register assets.";
                        return Request.CreateResponse(HttpStatusCode.OK, objUser);
                    }
                    else if (_ListReqtagdata == null || _ListReqtagdata.Where(w => !string.IsNullOrEmpty(w.Tag.Trim())).Count() == 0)
                    {
                        objUser.Message = "Tag required to register assets.";
                        return Request.CreateResponse(HttpStatusCode.OK, objUser);
                    }
                    //else if (_ListReqtagdata.Where(w => string.IsNullOrEmpty(w.Tag.Trim())).Count() > 0)
                    //{
                    //    objUser.Message = "Tag not Blank in register assets.";
                    //    return Request.CreateResponse(HttpStatusCode.OK, objUser);
                    //}
                    #endregion

                    using (NadaTechEntities Entities = new NadaTechEntities())
                    {
                        if (Entities.AssetMasters.Where(w => w.AssetName == AssetName).Count() > 0)
                        {
                            objUser.Message = "Asset ID/Name already exists.";
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        AssetMaster _AssetMaster = new AssetMaster();
                        _AssetMaster.PartId = Convert.ToInt32(PartId);
                        _AssetMaster.AssetName = AssetName;
                        _AssetMaster.SerialNumber = SerialNumber;
                        if (!string.IsNullOrEmpty(ExpiryDate))
                        {
                            _AssetMaster.ExpiryDate = Common.DateTimeConvert(ExpiryDate);
                        }
                        _AssetMaster.Notes = Notes;
                        _AssetMaster.PartId = Convert.ToInt32(PartId);
                        _AssetMaster.IsDelete = false;
                        _AssetMaster.IsMoveable = IsMoveable;
                        _AssetMaster.CreateDate = DateTime.Now;
                        _AssetMaster.CreatedBy = Convert.ToInt32(UserId);
                        _AssetMaster.ModifiedDate = DateTime.Now;
                        _AssetMaster.ModifiedBy = Convert.ToInt32(UserId);
                        Entities.AssetMasters.Add(_AssetMaster);

                        List<Reqtagdata> _ListGrptagdata = _ListReqtagdata.Where(w => !string.IsNullOrEmpty(w.Tag.Trim())).GroupBy(g => g.Tag).Select(s => new Reqtagdata { Tag = s.Key }).ToList();
                        foreach (Reqtagdata item in _ListGrptagdata)
                        {
                            if (Entities.AssetTagDetails.Where(w => w.TagData == item.Tag && w.IsDelete == false).Count() > 0)
                            {
                                objUser.Message = "Tag : " + item.Tag + " already exists.";
                                return Request.CreateResponse(HttpStatusCode.OK, objUser);
                            }
                            AssetTagDetail _AssetTagDetail = new AssetTagDetail();
                            _AssetTagDetail.LocationId = Convert.ToInt32(LocationId);
                            _AssetTagDetail.TagData = item.Tag;
                            _AssetTagDetail.AssetStatus = "1";
                            _AssetTagDetail.IsDelete = false;
                            _AssetTagDetail.CreateDate = DateTime.Now;
                            _AssetTagDetail.CreatedBy = Convert.ToInt32(UserId);
                            _AssetTagDetail.ModifiedDate = DateTime.Now;
                            _AssetTagDetail.ModifiedBy = Convert.ToInt32(UserId);
                            _AssetMaster.AssetTagDetails.Add(_AssetTagDetail);

                        }
                        #region  Upload Asset Images
                        string Path = ctx.Server.MapPath("~/Document/AssetImages/");
                        if (!Directory.Exists(Path))
                        {
                            Directory.CreateDirectory(Path);
                        }
                        var provider = new MultipartFormDataStreamProvider(Path);
                        await Request.Content.ReadAsMultipartAsync(provider);
                        int index = 0;
                        if (provider.FileData.Count > 0)
                        {
                            foreach (var file in provider.FileData)
                            {
                                index++;
                                var filename = file.LocalFileName;
                                string ext = file.Headers.ContentDisposition.FileName.Trim(new Char[] { '"' }).Split('.')[1];
                                string FName = "IMGASSET" + index + PartId + UserId + DateTime.Now.ToString("ddMMyyyyHHmmssffff") + "." + ext;
                                ////byte[] content = File.ReadAllBytes(filename);
                                string originalFileName = String.Concat(Path, FName);
                                File.Move(filename, originalFileName);

                                AssetImage _AssetImage = new AssetImage();
                                _AssetImage.AssetImage1 = FName;
                                _AssetImage.IsDelete = false;
                                _AssetImage.CreateDate = DateTime.Now;
                                _AssetImage.CreatedBy = Convert.ToInt32(UserId);
                                _AssetImage.ModifiedDate = DateTime.Now;
                                _AssetImage.ModifiedBy = Convert.ToInt32(UserId);
                                _AssetMaster.AssetImages.Add(_AssetImage);
                            }
                        }
                        #endregion
                        Entities.SaveChanges();

                        objUser.Message = "Asset Registration successfully done";
                        objUser.Status = true;
                    }
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        [HttpPost]
        [Route("api/Master/UploadAssetImg")]
        public async Task<HttpResponseMessage> UploadAssetImg()
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var ctx = HttpContext.Current;
                if (ctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }

                string UserId = (ctx.Request.Form.AllKeys.Contains("userid") ? ctx.Request.Headers.GetValues("userid").First() : "");
                string PartId = (ctx.Request.Form.AllKeys.Contains("PartId") ? ctx.Request.Form.GetValues("PartId")[0] : "");
                if (!string.IsNullOrEmpty(UserId))
                {
                    objUser.Message = "UserId not Found  in Asset Image upload Api.";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else if (!string.IsNullOrEmpty(PartId))
                {
                    objUser.Message = "Part not Found in Asset Image upload Api.";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {

                    using (NadaTechEntities Entities = new NadaTechEntities())
                    {
                        #region  Upload Asset Images
                        string Path = ctx.Server.MapPath("~/Document/AssetImages/");
                        if (!Directory.Exists(Path))
                        {
                            Directory.CreateDirectory(Path);
                        }
                        var provider = new MultipartFormDataStreamProvider(Path);
                        await Request.Content.ReadAsMultipartAsync(provider);
                        int index = 0;
                        List<ResAssetImg> _listResAssetImg = new List<ResAssetImg>();
                        if (provider.FileData.Count > 0)
                        {

                            foreach (var file in provider.FileData)
                            {
                                index++;
                                var filename = file.LocalFileName;
                                string ext = file.Headers.ContentDisposition.FileName.Trim(new Char[] { '"' }).Split('.')[1];
                                string FName = "IMGASSET" + index + PartId + UserId + DateTime.Now.ToString("ddMMyyyyHHmmssffff") + "." + ext;
                                ////byte[] content = File.ReadAllBytes(filename);
                                string originalFileName = String.Concat(Path, FName);
                                File.Move(filename, originalFileName);
                                _listResAssetImg.Add(new ResAssetImg { ImgName = FName });
                            }
                        }
                        #endregion
                        objUser.Message = "Asset Registration successfully done";
                        objUser.Status = true;
                        objUser.Response = _listResAssetImg;
                    }
                }
            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }

        #endregion

        #endregion

        #region  Transaction


        [HttpPost]
        [Route("api/Transaction/SetCheckinCheckout")]
        public HttpResponseMessage SetCheckinCheckout(ReqCheckinCheckout model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var ctx = HttpContext.Current;
                if (ctx == null)
                {
                    objUser.Message = "Token is Invalid";
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                #region Validation
                string TraType = "";
                if (!string.IsNullOrEmpty(model.TransactionType))
                {
                    TraType = model.TransactionType;
                    if (model.TransactionType == "Move")
                    {
                        model.TransactionType = "In";
                    }
                }
                if (string.IsNullOrEmpty(model.TransactionType))
                {
                    objUser.Message = "Transaction Type required.";
                    return Request.CreateResponse(HttpStatusCode.OK, objUser);
                }
                else if (model.TransactionType == "In" && model.LocationId == 0)
                {
                    objUser.Message = "Location required to " + (TraType == "Move" ? "Move" : "Check In") + ".";
                    return Request.CreateResponse(HttpStatusCode.OK, objUser);
                }
                else if (model.TagDetail == null || model.TagDetail.Where(w => !string.IsNullOrEmpty(w.Tag.Trim())).Count() == 0)
                {
                    objUser.Message = "Asset Tag required to " + (TraType == "Move" ? "Move" : (TraType == "In" ? "Check In" : "Check Out"));
                    return Request.CreateResponse(HttpStatusCode.OK, objUser);
                }
                #endregion
                string UserId = ctx.Request.Headers.GetValues("userid").First();
                using (NadaTechEntities Entities = new NadaTechEntities())
                {
                    LocationMaster _LocationMaster = Entities.LocationMasters.FirstOrDefault(f => f.LocationId == model.LocationId && f.IsDelete == false);
                    if (model.TransactionType == "In" && _LocationMaster == null)
                    {
                        objUser.Message = "Location required to " + (TraType == "Move" ? "Move" : "Check In") + ".";
                        return Request.CreateResponse(HttpStatusCode.OK, objUser);
                    }
                    TransactionHeader _TransactionHeader = new TransactionHeader();
                    _TransactionHeader.TransactionType = (model.TransactionType == "In" ? 1 : 2);
                    _TransactionHeader.TransactionDate = DateTime.Now;
                    _TransactionHeader.Notes = (TraType == "Move" ? "Transaction Move " : "") + model.Notes;
                    _TransactionHeader.ScanType = (int)Common.ScanType.Mobile;
                    _TransactionHeader.IsDelete = false;
                    _TransactionHeader.CreatedBy = Convert.ToInt32(UserId);
                    _TransactionHeader.CreateDate = DateTime.Now;
                    _TransactionHeader.ModifiedDate = DateTime.Now;
                    _TransactionHeader.ModifiedBy = Convert.ToInt32(UserId);
                    _TransactionHeader.Status = "A";

                    Entities.TransactionHeaders.Add(_TransactionHeader);

                    List<ReqCheckinCheckoutDetail> _ListGrpCheckinCheckoutDetail = model.TagDetail.Where(w => !string.IsNullOrEmpty(w.Tag.Trim())).GroupBy(g => g.Tag).Select(s => new ReqCheckinCheckoutDetail { Tag = s.Key }).ToList();
                    foreach (var item in _ListGrpCheckinCheckoutDetail)
                    {
                        AssetTagDetail _AssetTagDetail = Entities.AssetTagDetails.FirstOrDefault(f => f.TagData == item.Tag && f.IsDelete == false);
                        if (_AssetTagDetail == null)
                        {
                            objUser.Message = "Asset Tag not found in Inventory. Tag : " + item.Tag;
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (Convert.ToInt32(_AssetTagDetail.AssetStatus) == _TransactionHeader.TransactionType && TraType != "Move")
                        {
                            objUser.Message = "Asset already " + (model.TransactionType == "In" ? "Check In" : "Check Out") + ". Tag : " + item.Tag;
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        else if (_AssetTagDetail.AssetMaster.IsMoveable == false)
                        {
                            objUser.Message = "The asset doesn't have permission to move to another location. Please contact the admin/supervisor to allow this item to check-in/checkout. Asset Name :  " + _AssetTagDetail.AssetMaster.AssetName + " Tag : " + item.Tag;
                            return Request.CreateResponse(HttpStatusCode.OK, objUser);
                        }
                        TransactionDetail _TransactionDetail = new TransactionDetail();
                        _TransactionDetail.AssetTagId = _AssetTagDetail.AssetTagId;
                        _TransactionDetail.LastLocationId = (model.TransactionType == "In" ? _AssetTagDetail.LastLocationId : _AssetTagDetail.LocationId);
                        _TransactionDetail.LocationId = (model.TransactionType == "In" ? _LocationMaster.LocationId : _AssetTagDetail.LocationId);
                        _TransactionDetail.IsDelete = false;
                        _TransactionDetail.CreatedBy = Convert.ToInt32(UserId);
                        _TransactionDetail.CreateDate = DateTime.Now;
                        _TransactionDetail.ModifiedDate = DateTime.Now;
                        _TransactionDetail.ModifiedBy = Convert.ToInt32(UserId);
                        _TransactionHeader.TransactionDetails.Add(_TransactionDetail);
                        if (model.TransactionType == "In")
                        {
                            _AssetTagDetail.AssetStatus = "1";
                            //_AssetTagDetail.LastLocationId = _AssetTagDetail.LocationId;
                            _AssetTagDetail.LocationId = _LocationMaster.LocationId;
                            _AssetTagDetail.ModifiedDate = DateTime.Now;
                            _AssetTagDetail.ModifiedBy = Convert.ToInt32(UserId);
                        }
                        else
                        {
                            _AssetTagDetail.AssetStatus = "2";
                            _AssetTagDetail.LastLocationId = _AssetTagDetail.LocationId;
                            _AssetTagDetail.LocationId = null;
                            _AssetTagDetail.ModifiedDate = DateTime.Now;
                            _AssetTagDetail.ModifiedBy = Convert.ToInt32(UserId);
                        }

                    }
                    Entities.SaveChanges();
                    if (TraType == "Move")
                    {
                        objUser.Message = "Your item moved successfully.";
                    }
                    else
                    {
                        objUser.Message = "Asset " + (TraType == "In" ? "Check In" : "Check Out") + " successfully done";
                    }
                    objUser.Status = true;
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }


        #endregion

        #region Report

        [HttpPost]
        [Route("api/Report/InventoryData")]
        public HttpResponseMessage InventoryData(ReqInventoryReport model)
        {
            ResponseDefault objUser = new ResponseDefault();
            objUser.Status = false;
            try
            {
                var Msg = Common.CheckTokenAndVersion(HttpContext.Current.Request);
                if (!string.IsNullOrEmpty(Msg))
                {
                    objUser.Message = Msg;
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, objUser);
                }
                else
                {
                    var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);

                    int AssetStatus = model.CheckIn == true && model.CheckOut == false ? 1 : (model.CheckIn == false && model.CheckOut == true) ? 2 : 0;
                    #region SqlParameter
                    SqlParameter[] _Para =
                    {
                            new SqlParameter("@Action",1),
                            new SqlParameter("@AssetTypeId",model.AssetTypeId),
                            new SqlParameter("@AssetCategoryId",model.AssetCategoryId),
                            new SqlParameter("@PartId",model.PartId),
                            new SqlParameter("@LocationId",model.LocationId),
                            new SqlParameter("@AssetStatus",AssetStatus),
                            new SqlParameter("@IdleAssetDate",(string.IsNullOrEmpty(model.IdleAssetDate)?"": Common.DateTimeConvert(model.IdleAssetDate).ToString("yyyy/MM/dd"))),
                            new SqlParameter("@Search",model.Search),
                            new SqlParameter("@PageNumber",model.PageNumber),
                            new SqlParameter("@RowspPage",model.PageSize),
                 };

                    #endregion
                    DataTable Dt = _obj.GetDataTable(CommandType.StoredProcedure, "SPAPI_InventoryReport", _Para);
                    var data = Dt.AsEnumerable().Select(s => new
                    {
                        TotalRecord = s.Field<dynamic>("TotalRecord"),
                        AssetId = s.Field<dynamic>("AssetId"),
                        AssetType = s.Field<dynamic>("AssetType"),
                        AssetCategory = s.Field<dynamic>("AssetCategory"),
                        PartNumber = s.Field<dynamic>("PartNumber"),
                        PartName = s.Field<dynamic>("PartName"),
                        PartDescription = s.Field<dynamic>("PartDescription"),
                        AssetName = s.Field<dynamic>("AssetName"),
                        SerialNumber = s.Field<dynamic>("SerialNumber"),
                        ExpiryDate = s.Field<dynamic>("ExpiryDate"),
                        AssetNotes = s.Field<dynamic>("AssetNotes"),
                        Location = s.Field<dynamic>("Location"),
                        TagData = s.Field<dynamic>("TagData"),
                        AssetStatus = s.Field<dynamic>("AssetStatus"),
                        AssetImage = s.Field<dynamic>("AssetImage"),
                        IsMoveable = s.Field<dynamic>("IsMoveable"),
                    }).GroupBy(s => new
                    {
                        s.TotalRecord,
                        s.AssetId,
                        s.AssetType,
                        s.AssetCategory,
                        s.PartNumber,
                        s.PartName,
                        s.PartDescription,
                        s.AssetName,
                        s.SerialNumber,
                        s.ExpiryDate,
                        s.AssetNotes,
                        s.Location,
                        s.TagData,
                        s.AssetStatus,
                        s.IsMoveable,
                    }).Select(s => new
                    {
                        //s.Key.TotalRecord,
                        //s.Key.AssetId,
                        s.Key.AssetType,
                        s.Key.AssetCategory,
                        s.Key.PartNumber,
                        s.Key.PartName,
                        s.Key.PartDescription,
                        s.Key.AssetName,
                        s.Key.SerialNumber,
                        s.Key.ExpiryDate,
                        s.Key.AssetNotes,
                        s.Key.Location,
                        s.Key.TagData,
                        s.Key.AssetStatus,
                        s.Key.IsMoveable,
                        ListAssetImages = s.Where(w => !string.IsNullOrEmpty(w.AssetImage)).AsEnumerable().Select(i => new
                        {
                            AssetImage = baseUrl + i.AssetImage
                        }).ToList()
                    }).ToList();
                    if (data.Count() > 0)
                    {
                        objUser.Message = "Success";
                        objUser.Status = true;
                    }
                    else
                    {
                        objUser.Status = false;
                        objUser.Message = "No data found.";
                    }
                    objUser.Response = data;
                }

            }
            catch (Exception ex)
            {
                objUser.Message = Common.GetString(ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, objUser);
        }



        #endregion


    }
}
