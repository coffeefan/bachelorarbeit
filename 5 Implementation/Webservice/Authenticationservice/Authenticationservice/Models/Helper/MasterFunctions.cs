using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Authenticationservice.Models.Helper
{
    internal class MasterFunctions
    {
        public static string ConfigurationWebUrl = ConfigurationManager.AppSettings["ConfigurationWebUrl"];


        internal static string Timestamp = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ");


        internal static string TimeAsRFC5545String(DateTime time)
        {
            return time.ToString("yyyyMMddTHHmmss");
        }

        internal static int NoteTo100(float note)
        {
            return (int) Math.Round(((note-2 / 6-2) * 100),0);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string makeMD5(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }


        internal static System.DateTime GetWestEuropeDate()
        {
            var myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
            return currentDateTime;
        }
    }
}