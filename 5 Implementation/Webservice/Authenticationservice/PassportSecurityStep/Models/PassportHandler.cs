using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace PassportSecurityStep.Models
{
    public class PassportHandler
    {

        


        public PassportHandler()
        {
            
        }

        public bool checkPassport(string passportNumber,string birthday, string expiryDate,char endCheckcode)
        {
            bool checkpassPortNumber = checkTextWithCheckCode(passportNumber);
            bool checkpassBirthday = checkTextWithCheckCode(birthday);
            bool checkpassExpiryDate = checkTextWithCheckCode(expiryDate);
            if (checkpassPortNumber &&
                checkpassBirthday&&
                checkpassExpiryDate)
            {
                string mastertext = passportNumber + birthday + expiryDate;
                return checkCheckCode(mastertext, endCheckcode);
            }
            return false;
        }

        public string characterToNumber(char c)
        {
            if (c == '<')
            {
                return "0";
            }
            int index = char.ToUpper(c) - 65;


            return index.ToString(); ;
        }

        public string stringCodeToNumber(string passportNumber)
        {
            string numberCode = "";
            foreach(char c in passportNumber)
            {
                if (char.IsNumber(c))
                {
                    numberCode += c;
                }
                else
                {
                    numberCode += characterToNumber(c);
                    
                }
                
            }
            return numberCode;
        }

        public bool checkTextWithCheckCode(string text)
        {
            string temptext = text.Substring(0, text.Length - 1);
            char checkcode = text[text.Length - 1];
            return (checkCheckCode(temptext, checkcode));
        }

        public bool checkCheckCode(string text, char checkcode)
        {
            return (makeCheckCode(text) == checkcode);
            

        }

        public char makeCheckCode(string text)
        {
            text = stringCodeToNumber(text);
            int i = 0;
            int sum = 0;
            foreach (char c in text)
            {
                if (i == 0)
                {
                    sum = sum + ((int.Parse(c.ToString())) * 7);
                }
                if (i == 1)
                {
                    sum = sum + ((int.Parse(c.ToString())) * 3);
                }
                if (i == 2)
                {
                    sum = sum + ((int.Parse(c.ToString())) * 1);
                    i = -1;
                }
                i++;
            }
            int checkcode=sum % 10;
            return checkcode.ToString()[0];
        }

    }
}