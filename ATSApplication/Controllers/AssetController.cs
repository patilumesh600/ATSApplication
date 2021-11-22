using ATSApplication.Authorised;
using ATSApplication.Common;
using ATSApplication.Interfaces;
using ATSApplication.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATSApplication.Controllers
{
    [SessionAuthorize]
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }
        // GET: Asset
        public ActionResult Index()
        {
            //ViewBag.list =  _assetService.Delete(1);
            //ViewBag.list = _assetService.GetAll();
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
     
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult CreateAssetOrUpdateAsset()
        {
            var inputAsset_VM = JObject.Parse(Request["AssetDetails"]);

            Asset_VM asset_VM = new Asset_VM();
            asset_VM = inputAsset_VM.ToObject<Asset_VM>();
            string fileNameWithPath = null;
            // JObject uploadResult = UploadProductImage(Request);
            if (Request.Files.Count > 0)
            {
                byte[] fileData = null;
                string fileName = "";
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fileName = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fileName = file.FileName;
                    }
                    using (var binaryReader = new System.IO.BinaryReader(file.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(file.ContentLength);
                    }
                    //  Get the complete folder path and store the file inside it.
                    fileName = GenerateUniqueID.GetTimeStamps() + "_" + fileName;
                    fileNameWithPath = System.IO.Path.Combine(Server.MapPath("~/Content/DeviceImages/"), fileName);
                    file.SaveAs(fileNameWithPath);
                }

                String strBase64Image = Convert.ToBase64String(fileData);
                System.IO.File.WriteAllBytes(fileNameWithPath, fileData);
                asset_VM.ImagePath = fileNameWithPath;
                asset_VM.IsActive = true;
            }

            var result = _assetService.AddOrUpdate(asset_VM);
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult GetAssetDetails()
        {
            Int64 AssetId = Convert.ToInt64(Request["AssetId"]);
            var result = _assetService.GetAssetDetails(AssetId);
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult AssetList(string dd)
        {
            var result = _assetService.GetAll();
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult EnabledAsset()
        {
            Int64 AssetId = Convert.ToInt64(Request["AssetId"]);
            var result = _assetService.EnabledAsset(AssetId);
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult DisabledAsset()
        {
            Int64 AssetId = Convert.ToInt64(Request["AssetId"]);
            var result = _assetService.DisabledAsset(AssetId);
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }       
    }
}