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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateAsset()
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
                //product_VM.ProductImage = strBase64Image;
                //product_VM.ProductImageName = fileName;

                var result = _assetService.AddOrUpdate(asset_VM);
                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                //return jsonResult;
            }
            return View();
        }

        public JsonResult List()
        {
            var result = _assetService.GetAll();
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}