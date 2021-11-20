using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATSApplication.ViewModels
{
    public class Asset_VM
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string ModelNo { get; set; }
        public string ModelName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime InsuranceDate { get; set; }
        public DateTime ServiceDueDate { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public string OtherInfo { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}