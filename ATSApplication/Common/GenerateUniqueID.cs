using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATSApplication.Common
{
    public class GenerateUniqueID
    {
        public static string GetHashID()
        {
            long ticks = DateTime.Now.Ticks;
            byte[] bytes = BitConverter.GetBytes(ticks);
            string id = Convert.ToBase64String(bytes)
                                    .Replace('+', '_')
                                    .Replace('/', '-')
                                    .TrimEnd('=');
            return id;
        }
        public static string GetTimeStamps()
        {
            string Unique =  DateTime.Now.ToString("yyMMddHHmmssff");
            return Unique;
        }
    }
}