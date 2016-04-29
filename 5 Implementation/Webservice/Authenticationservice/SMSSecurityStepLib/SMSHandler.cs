using System;
using System.Collections.Generic;
using System.Configuration;
namespace SMSSecurityStep.Models
{
    public class SMSHandler
    {
        private static string xmlUrl = "http://xml2.aspsms.com:5061/xmlsvr.asp";


        private string orgi;
        private string userkey;
        private string password;

        public SMSHandler() : this(ConfigurationManager.AppSettings["DefaultSMSFrom"]) { }
        public SMSHandler(String sMSFrom)
        {
            this.orgi = sMSFrom;
            this.userkey = ConfigurationManager.AppSettings["SMSUserkey"];
            this.password = ConfigurationManager.AppSettings["SMSPassword"];
        }

        public bool send(string number, string text)
        {
            try
            {
                
                String message = new SMSSecurityStepLib.aspsms.ASPSMSX2().SendSimpleTextSMS(userkey, password, number, orgi, text);
                if (!message.Equals("StatusCode:1"))
                {
                    throw new NotSupportedException("SMS Failure:" + new SMSSecurityStepLib.aspsms.ASPSMSX2().GetStatusCodeDescription(message));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }

        }
        
    }
}