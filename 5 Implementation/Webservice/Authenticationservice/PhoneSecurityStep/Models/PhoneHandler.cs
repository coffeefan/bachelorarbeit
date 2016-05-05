using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PhoneSecurityStep.Models
{
    public class PhoneHandler
    {

        private string apiurl;
        private string apikey;
        private string apisecret;


        public PhoneHandler()
        {
            apiurl = ConfigurationManager.AppSettings["PhoneAPIUrl"];
            apikey = ConfigurationManager.AppSettings["PhoneAPIKey"];
            apisecret = ConfigurationManager.AppSettings["PhoneAPISecret"];
        }

        public bool phoneCall(string number, string normaltext,string spelltext,string salutation,int repeat)
        {
            if (number== "+41520000000")
            {
                return true;
            }

            number=number.Replace("+41", "41");

            string text = "<break time=\"1s\"/>";
            if (!string.IsNullOrEmpty(normaltext))
            {
                text += normaltext + "<break time = \"1s\" />";
            }
            if (!string.IsNullOrEmpty(spelltext))
            {
                string spelltextTemp=spelltext.Aggregate(string.Empty, (c, i) => c + i + ", ");
                text += "<prosody rate = \"- 40%25\">" + spelltextTemp + "</prosody><break time = \"3s\" />";
            }
            text +=salutation;

            string address= apiurl +
                "?api_key="+ apikey + 
                "&api_secret="+apisecret+
                "&to=" + number + 
                "&text=" + text + 
                "&lg=de-de"+
                "&repeat=" + repeat;
            String result=GetExternalResponse(address).ToString();
            return true;

        }


        private async Task<string> GetExternalResponse(string address)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(address);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

    }
}