using Authenticationservice.Models;
using Authenticationservice.Models.Helper;
using Newtonsoft.Json.Linq;
using SecurityStepContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace Authenticationservice.Controllers
{
    public class SecurityStepSurveyController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private int survey_participant = 0;
        private List<string> ages = new List<string>(new string[] {
            "16-20 Jahre","20-30 Jahre", "30-40 Jahre", "40-65 Jahre"});
        private List<string> interActivityTyps  = new List<string>(new string[] {
            "poll", "casting", "poortrustwin", "richtrustwin", "poorunkownwin", "richunkownwin" });

        private List<string> interActivityTypText = new List<string>(new string[] {
            "poll", "Casting", "Low-Win Trust Company", "High-Win Trust Company", "Low-Win Unkown Company", "High-Win Unkown Company" });

        private List<string> securitystepShortNames = new List<string>(new string[] {
            "captcha", "email", "sms", "phone", "address", "passport" });

        public SecurityStepSurveyController()
        {
            survey_participant = db.Database.SqlQuery<int>("Select count(*) as anzahl from survey").FirstOrDefault();
        }

        [Route("api/SecurityStepSurvey/TotalStep")]
        public IHttpActionResult GetSecurityStepSurvey(string securitystepshortname)
        {
            string sucess_anwser = "1";
            int[,] data = new int[1,interActivityTyps.Count];

            if (securitystepShortNames.Contains(securitystepshortname))
            {
                int counter = 0;
                foreach (string interActivityTyp in interActivityTyps)
                {
                    int anzahl = db.Database.SqlQuery<int>(
                        @"Select count(*) as anzahl 
                        from survey where "+ interActivityTyp + securitystepshortname +" like {0}", sucess_anwser).FirstOrDefault();
                    float percent= (anzahl * 100 / survey_participant );
                    data[0,counter] = (int)percent;
                    counter++;
                }
            }
           
            return Ok(
                
                new
                {
                    labels = interActivityTypText,
                    series = new String[] { "Total" },
                    data = data 
                    ,
                }
            );          
            
        }

        [Route("api/SecurityStepSurvey/AgeStep")]
        public IHttpActionResult GetSecurityStepSurveyAge(string securitystepshortname)
        {
            string sucess_anwser = "1";

            int[,] data = new int[interActivityTyps.Count, ages.Count];
            if (securitystepShortNames.Contains(securitystepshortname))
            {
                int counter = 0;

                

                foreach (string ageitem in ages)
                {
                    
                    string sqltxt = "Select count(*) as total ";
                    foreach (string interActivityTyp in interActivityTyps)
                    {
                        sqltxt += @",
                            (Select count(*) as anzahl from survey where " + interActivityTyp + securitystepshortname
                                + " like '" + sucess_anwser + "' and age like '" + ageitem + "') as " + interActivityTyp; 
                        
                    }
                    sqltxt += " from survey where age like '" + ageitem + "'";
                    ResultPerActivityTyp anzahl = db.Database.SqlQuery<ResultPerActivityTyp>(sqltxt).FirstOrDefault();
                    int[]anzahlArray = anzahl.convertToPercentArray();
                    for (int i = 0; i < anzahlArray.Length; i++)
                    {
                        data[i, counter] = anzahlArray[i];
                    }
                    counter++;
                }
            }



            return Ok(
                new
                {
                    series  = interActivityTypText,
                    labels =  ages,
                    data = data
                    
                }
            );

        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public class ResultPerActivityTyp
        {
            public int Total { get; set; }
            public int Poll { get; set; }
            public int Casting { get; set; }
            public int PoorTrustWin { get; set; }
            public int RichTrustWin{ get; set; }
            public int PoorUnkownWin { get; set; }
            public int RichUnkownWin { get; set; }

            public int[] convertToPercentArray()
            {
                float percentPoll = (Poll * 100 / Total);
                float percentCasting = (Casting * 100 / Total);
                float percentPoorTrustWin = (PoorTrustWin * 100 / Total);
                float percentRichTrustWin = (RichTrustWin * 100 / Total);
                float percentPoorUnkownWin = (PoorUnkownWin * 100 / Total);
                float percentRichUnkownWin = (RichUnkownWin * 100 / Total);
                int[] ar = new int[] {(int)percentPoll, (int)percentCasting,
                    (int)percentPoorTrustWin, (int)percentRichTrustWin, (int)percentPoorUnkownWin,
                    (int)percentRichUnkownWin };
                return ar;
            }
        }
    }
}
