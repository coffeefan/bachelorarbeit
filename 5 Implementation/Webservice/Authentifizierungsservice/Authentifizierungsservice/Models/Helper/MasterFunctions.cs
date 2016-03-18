using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Authentifizierungsservice.Models.Helper
{
    internal class MasterFunctions
    {
        public static string ConfigurationWebUrl = ConfigurationManager.AppSettings["ConfigurationWebUrl"];


        internal static string Timestamp = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ");


        internal static string TimeAsRFC5545String(DateTime time)
        {
            return time.ToString("yyyyMMddTHHmmss");
        }


        internal static System.DateTime GetWestEuropeDate()
        {
            var myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
            return currentDateTime;
        }
    }
}