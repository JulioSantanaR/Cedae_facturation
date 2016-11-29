using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RODHE.Tools
{
    public static class ServiceMail
    {
        public static bool SendMail(Email email)
        {
            bool Result = false;
            try
            {
                MailMessage objmail = new MailMessage();
                SmtpClient client = new SmtpClient();
                string[] emailarray = email.To.Split(',');
                client.Port = email.Port;
                client.Host = email.Host;
                client.EnableSsl = email.EnableSsl;
                client.Timeout = email.TimeOut;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(email.User, email.Password);
                objmail.BodyEncoding = System.Text.Encoding.UTF8;
                objmail.IsBodyHtml = true;
                objmail.From = new MailAddress(email.From);
                for (int i = 0; i < emailarray.Length; i++)
                {
                    objmail.To.Add(emailarray[i]);
                }
                objmail.Subject = email.Subject;
                objmail.Body = email.Html;
                client.Send(objmail);
                Result = true;

            }
            catch (Exception ex)
            {
                Result = false;

            }

            return Result;
        }
    }

}
