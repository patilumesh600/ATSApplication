using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATSApplication.Models
{
    public class ApplicationUser
    {
        [Key]
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string EmailID { get; set; }
        public string PhoneNo { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public string OtherInfo { get; set; }
        public string OtherInfo1 { get; set; }
        public string OtherInfo2 { get; set; }
        public string OtherInfo3 { get; set; }
        public string OtherInfo4 { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}