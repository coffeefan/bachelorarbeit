using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Web;

namespace SMSSecurityStep.Models
{
    public class MailHandler
    {

       
        public bool send(String toEmail, String toName, String subject, String plaintext, String htmlbody)
        {          

            try
            {
                // Assign a sender, recipient and subject to new mail message
                MailAddress sender = new MailAddress(ConfigurationManager.AppSettings["email"], ConfigurationManager.AppSettings["emailname"]);

                MailAddress recipient =
                    new MailAddress(toEmail, toName);

                MailMessage mailMessage = new MailMessage(sender, recipient);
                mailMessage.Subject = subject;


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
                    Timeout = 10000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials =
                        new NetworkCredential(ConfigurationManager.AppSettings["emailuser"], ConfigurationManager.AppSettings["emailpw"])
                };


                smtp.Send(mailMessage);
                return true;
            }
            catch (ArgumentException)
            {
                return false;

            }
            catch (FormatException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;

            }
            catch (SmtpFailedRecipientException)
            {
                return false;

            }
            catch (SmtpException ex)
            {
                return false;

            }


            return false;
        }
    }
}