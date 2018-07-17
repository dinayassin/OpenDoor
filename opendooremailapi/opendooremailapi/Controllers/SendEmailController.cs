using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace OpenDoorEmailApi.Controllers
{
    public class SendEmailController : ApiController
    {
        // GET: api/SendEmail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SendEmail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SendEmail
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SendEmail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SendEmail/5
        public void Delete(int id)
        {
        }

        [AllowAnonymous]
        [Route("api/SendEmail/GmailSmtp")]
        public bool GmailSmtp([FromBody]EmailRequest data)
        {

            MailMessage msg = new MailMessage();
            var To = data.To.Split(';');
            foreach (var item in To)
            {
                msg.To.Add(item);
            }
            msg.From = new MailAddress(data.FromAddress, data.FromDisplay);
            msg.IsBodyHtml = true;
            msg.Body = data.Body;
            msg.Subject = data.Subject;
            try
            {
                msg.Bcc.Add("nashef.systems@gmail.com");
                msg.Bcc.Add("OpenDoorR2017@gmail.com");

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("OpenDoorR2017", "Ruppin2017");
                smtpClient.Send(msg);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
