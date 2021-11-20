using ATSApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ATSApplication.ViewModels;
using ATSApplication.Context;
using System.Data.SqlClient;

namespace ATSApplication.Services
{
    public class AssetService : IAssetService
    {
        ATSApplicationContext _db = null;

        public Int64 sessionUser = 0;
        public AssetService()
        {
            try
            {
                sessionUser = Int64.Parse(System.Web.HttpContext.Current.Session["User_Id"].ToString());
                _db = new ATSApplicationContext();
            }
            catch
            {

            }
        }

        public List<Asset_VM> GetAll()
        {
            try
            {
                var mode = new SqlParameter("@Mode", "GET_ALL");
                var result = _db.Database.SqlQuery<Asset_VM>("exec SP_MANAGE_ASSET @Mode", mode).ToList();
                return result;
            }
            catch (Exception ex)
            {
                List<Asset_VM> blanklist = new List<Asset_VM>();
                return blanklist;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var mode = new SqlParameter("@Mode", "DELETE");
                var ID = new SqlParameter("@ID", id);
                var result = _db.Database.SqlQuery<string>("exec SP_MANAGE_ASSET @Mode, @ID", mode, ID).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                return "An Error Occured Contact Service Administrator...!";
            }
        }

        public string AddOrUpdate(Asset_VM Asset)
        {
            throw new NotImplementedException();
        }
    }
}