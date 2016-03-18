using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Web;
using RazorEngine;
using RazorEngine.Templating;
using Authentifizierungsservice.Resource;

namespace Authentifizierungsservice.Models.Helper
{
    public class EmailTemplateService
    { 
        public static String ParseHTMLContent(string TemplateName, object viewBag)
        { 
            string templateContent = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Views/EmailTemplates/") + TemplateName + ".cshtml"); 
            var result = Engine.Razor.RunCompile(templateContent, TemplateName, null, viewBag); 
            return result; 
        } 
    } 
     
    public class MailHandler
    { 
        public MailHandler(String culturInfo)
        { 
            //Set Culture 
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culturInfo); 
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture; 


        } 


        public Result sendWithTemplate(String toEmail, String toName, String TemplateKey, String SubjectKey, object ViewBag = null, Attachment attachment = null)
        { 
            String htmlbody = EmailTemplateService.ParseHTMLContent(TemplateKey, ViewBag); 


            //String plaintextbody = getHTMLContent(TemplateKey+"_PlainText", ViewBag)); 
            return send(toEmail, toName, Email.ResourceManager.GetString(SubjectKey), "Es handelt sich um ein HTML-Mail", htmlbody, attachment); 
        } 


        public String getItemText(String Item)
        { 
            return Engine.Razor.Run("@DB_Legal.Resources.Email.Email." + Item); 
        } 


        public Result send(String toEmail, String toName, String subject, String plaintext, String htmlbody, Attachment attachment = null)
        { 


            //toEmail = "contact@inaffect.net"; 
            Result result = new Result(); 


            try 
            { 
                // Assign a sender, recipient and subject to new mail message 
                MailAddress sender = new MailAddress(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["emaildisplay"]); 


                MailAddress recipient =
                    new MailAddress(toEmail, toName); 


                MailMessage mailMessage = new MailMessage(sender, recipient); 
                mailMessage.Subject = subject; 


                if (attachment != null) 
                { 
                    mailMessage.Attachments.Add(attachment); 
                } 
                 
                // Alternative Message 
                string plainTextBody = plaintext; 


                AlternateView plainTextView =
                    AlternateView.CreateAlternateViewFromString( 
                        plainTextBody, null, MediaTypeNames.Text.Plain); 
                mailMessage.AlternateViews.Add(plainTextView); 


                // HTML Body 
                string htmlBody = htmlbody; 


                AlternateView htmlView =
                    AlternateView.CreateAlternateViewFromString( 
                        htmlBody, null, MediaTypeNames.Text.Html); 


                mailMessage.AlternateViews.Add(htmlView); 


                //Smtp Client 
                SmtpClient smtp = new SmtpClient
                { 
                    Host = ConfigurationManager.AppSettings["emailhost"], 
                    Port = 25, 
                    EnableSsl = false, 
                    Timeout = 100000, 
                    DeliveryMethod = SmtpDeliveryMethod.Network, 
                    UseDefaultCredentials = false, 
                    Credentials = 
                         new NetworkCredential(ConfigurationManager.AppSettings["emailuser"], ConfigurationManager.AppSettings["emailpw"])
                 }; 
 

 

                 smtp.Send(mailMessage); 
                 result.Success = true; 
             } 
             catch (ArgumentException ex) 
             { 
                 result.ErrorMessage = "Undefined sender and/or recipient."; 
             } 
             catch (FormatException ex) 
             { 
                 result.ErrorMessage = "Invalid sender and/or recipient."; 
             } 
             catch (InvalidOperationException ex) 
             { 
                 result.ErrorMessage = "Undefined SMTP server"; 
 

             } 
             catch (SmtpFailedRecipientException ex) 
             { 
                 result.ErrorMessage = "The mail server says that there is no mailbox for recipien"; 
 

             } 
             catch (SmtpException ex) 
             { 
                 result.InnerException = ex.GetBaseException(); 
                 result.ErrorMessage = "Could not send message: " + ex.Message; 
 

             } 
 

 

             return result; 
         } 
     } 

}