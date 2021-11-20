using ATSApplication.Authorised;
using ATSApplication.Interfaces;
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
           ViewBag.list =  _assetService.Delete(1);
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
    }
}