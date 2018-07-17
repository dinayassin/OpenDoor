using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Web;
using System.Web.Script.Serialization;

namespace OpenDoorAPI
{
    public class Email
    {


        public static bool sendNewPassWordEmail(string to, string subject, string FullName, string passWord)
        {
            string body = "Hi </span><span style='font-family:\"Helvetica\",sans-serif;" +
                            "    mso-fareast-font-family:\"Times New Roman\";color:#0070C0'>##UserFullName##</span><span class=GramE><span" +
                            "    style='font-family:\"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>,</span></span><span style='font-family:\"Helvetica\",sans-serif;" +
                            "    mso-fareast-font-family:\"Times New Roman\";color:#404040'><br>" +
                            "    <br>" +
                            "     Welcome to the <span class=SpellE>OpenDoor</span> family !" +
                            "    <o:p></o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>the new password is: </span><span style='font-family:\"Helvetica\",sans-serif;" +
                            "    mso-fareast-font-family:\"Times New Roman\";color:#0070C0'>##Password##</span><span" +
                            "    style='font-family:\"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'> <o:p></o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'><o:p>&nbsp;</o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>To keep your account secure, please don't forward this email" +
                            "    to anyone and delete this message.<o:p></o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'><o:p>&nbsp;</o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#00B050'>Happy <span class=SpellE>OpenDoor</span>!</span><span" +
                            "    style='font-family:\"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>";
            return sendEmail(to, subject, body.Replace("##UserFullName##", FullName).Replace("##Password##", passWord));
        }
        public static bool sendForgotPassWordEmail(string to, string subject, string FullName, string passWord)
        {
            string body = "Hi </span><span style='font-family:\"Helvetica\",sans-serif;" +
                            "    mso-fareast-font-family:\"Times New Roman\";color:#0070C0'>##UserFullName##</span><span class=GramE><span" +
                            "    style='font-family:\"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>,</span></span><span style='font-family:\"Helvetica\",sans-serif;" +
                            "    mso-fareast-font-family:\"Times New Roman\";color:#404040'><br>" +
                            "    <br>" +
                            "    Someone recently requested a password change for your <span class=SpellE>OpenDoor</span>" +
                            "    account. <o:p></o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>the new password is: </span><span style='font-family:\"Helvetica\",sans-serif;" +
                            "    mso-fareast-font-family:\"Times New Roman\";color:#0070C0'>##Password##</span><span" +
                            "    style='font-family:\"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'> <o:p></o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'><o:p>&nbsp;</o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>To keep your account secure, please don't forward this email" +
                            "    to anyone and delete this message.<o:p></o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'><o:p>&nbsp;</o:p></span></p>" +
                            "    <p class=MsoNormal style='line-height:19.5pt'><span style='font-family:" +
                            "    \"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#00B050'>Happy <span class=SpellE>OpenDoor</span>!</span><span" +
                            "    style='font-family:\"Helvetica\",sans-serif;mso-fareast-font-family:\"Times New Roman\";" +
                            "    color:#404040'>";
            //return sendEmail(to, subject, body.Replace("##UserFullName##", FullName).Replace("##Password##", passWord));
            return sendEmailAPI(to, subject, body.Replace("##UserFullName##", FullName).Replace("##Password##", passWord));

        }
        public static bool sendEmail(string to, string subject, string Body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("OpenDoorR2017@Gmail.com", "OpenDoor system");
                message.To.Add(to);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = GetBodyString(Body);

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("OpenDoorR2017", "Ruppin2017");
                smtpClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool sendEmailAPI(string to, string subject, string Body)
        {

            MailMessage message = new MailMessage();
            message.From = new MailAddress("OpenDoorR2017@Gmail.com", "OpenDoor system");
            message.To.Add(to);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = GetBodyString(Body);
            return OpenDoorEmailApi(message);
        }
        public static string GetBodyString(string Body)
        {
            string result = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Email/EmptyMail.html"));
            return result.Replace("##message##", Body);
        }
        public static bool OpenDoorEmailApi(MailMessage message)
        {
            JavaScriptSerializer seralizer = new JavaScriptSerializer();
            var toArray = "";
            foreach (var item in message.To)
            {
                if (toArray != "")
                    toArray += ";";
                toArray += item;
            }
            var data = new
            {
                To = toArray,
                FromAddress = message.From.Address,
                FromDisplay = message.From.DisplayName,
                Subject = message.Subject,
                Body = message.Body
            };
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://OpenDoorEmailAPI.nashef-90.com/api/");
            //client.BaseAddress = new Uri("http://nashef.no-ip.info/api/");
            //client.BaseAddress = new Uri("http://localhost:61842/api/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsJsonAsync("SendEmail/GmailSmtp/", data).Result;

            if (response.IsSuccessStatusCode)
            {
                bool result = seralizer.Deserialize<bool>(response.Content.ReadAsAsync<string>().Result);
                return result;
            }
            return false;
        }
    }
}