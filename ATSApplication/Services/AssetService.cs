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
            try
            {
                var mode = new SqlParameter("@Mode", "INSERT");
                var ID = new SqlParameter("@ID", Asset.ID == null ? 0 : Asset.ID);
                var Type= new SqlParameter("@Type", Asset.Type == null ? "" : Asset.Type);
                var Name= new SqlParameter("@Name", Asset.Name == null ? "" : Asset.Name);
                var SerialNo= new SqlParameter("@SerialNo", Asset.SerialNo == null ? "" : Asset.SerialNo);
                var ModelNo= new SqlParameter("@ModelNo", Asset.ModelNo == null ? "" : Asset.ModelNo);
                var ModelName= new SqlParameter("@ModelName", Asset.ModelName == null ? "" : Asset.ModelName);
                var PurchaseDate= new SqlParameter("@PurchaseDate", Asset.PurchaseDate == null ? DateTime.Now : Asset.PurchaseDate);
                var ExpiryDate= new SqlParameter("@ExpiryDate", Asset.ExpiryDate == null ? DateTime.Now : Asset.ExpiryDate);
                var InsuranceDate= new SqlParameter("@InsuranceDate", Asset.InsuranceDate == null ? DateTime.Now : Asset.InsuranceDate);
                var ServiceDueDate= new SqlParameter("@ServiceDueDate", Asset.ServiceDueDate == null ? DateTime.Now : Asset.ServiceDueDate);
                var CompanyName= new SqlParameter("@CompanyName", Asset.CompanyName == null ? "" : Asset.CompanyName);
                var ImagePath= new SqlParameter("@ImagePath", Asset.ImagePath == null ? "" : Asset.ImagePath);
                var IsActive= new SqlParameter("@IsActive", Asset.IsActive);
                var OtherInfo= new SqlParameter("@OtherInfo", Asset.OtherInfo == null ? "" : Asset.OtherInfo);
                var CreatedBy= new SqlParameter("@CreatedBy", sessionUser == null ? 0 : sessionUser);
                var CreatedDate= new SqlParameter("@CreatedDate", DateTime.Now);
                var ModifiedBy = new SqlParameter("@ModifiedBy", sessionUser == null ? 0 : sessionUser);
                var ModifiedDate= new SqlParameter("@ModifiedDate", DateTime.Now);


                var result = _db.Database.SqlQuery<string>("exec SP_MANAGE_ASSET @Mode,@ID,@Type,@Name,@SerialNo,@ModelNo,@ModelName,@PurchaseDate,@ExpiryDate,@InsuranceDate,@ServiceDueDate,@CompanyName,@ImagePath,@IsActive,@OtherInfo,@CreatedBy,@CreatedDate,@ModifiedBy,@ModifiedDate", mode, ID, Type, Name, SerialNo, ModelNo, ModelName, PurchaseDate, ExpiryDate, InsuranceDate, ServiceDueDate, CompanyName, ImagePath, IsActive, OtherInfo, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                return "An Error Occured Contact Service Administrator...!";
            }
        }
    }
}