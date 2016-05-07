using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
//using System.Web.Mail;
using System.Web.Mvc;


namespace WebSite
{
    public class ContactController : BaseController
    {
        //
        // GET: /Contact/
        
        public ActionResult Index()
        {
            return View();


        }


        public ActionResult Confirmation()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Index(Message m)
        {
            //m.OKMsg = true;
            //return View(model: m);
            if (ModelState.IsValid)
            {
                try
                {
                    //const string SERVER = "relay-hosting.secureserver.net";
                    //System.Web.Mail.MailMessage oMail = new System.Web.Mail.MailMessage();
                    //oMail.From = new MailAddress("noyaschleien@noyaschleien.com").Address;
                    //oMail.To = "noyaschleien@gmail.com";
                    //oMail.Subject = "noyaschleien.com";
                    //oMail.BodyFormat = MailFormat.Text;	// enumeration
                    //oMail.BodyEncoding = System.Text.Encoding.UTF8;
                    //oMail.Priority = System.Web.Mail.MailPriority.High;	// enumeration
                    //string senderName = m.SenderName;
                    //string senderEmail = m.Email;
                    //string senderMessage = m.Content;

                    //oMail.Body = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", senderName, senderEmail, senderMessage, Request.Browser, Request.UserAgent, Request.UserHostAddress, Request.UserHostName);
                    //SmtpMail.SmtpServer = SERVER;
                    //SmtpMail.Send(oMail);
                    //oMail = null;	// free up resources  
                    //return RedirectToAction("Index");

                    MailAddress mailfrom = new MailAddress("noyaschleien@noyaschleien.com");
                    MailAddress mailto = new MailAddress("liorgish@gmail.com");
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);
                    string senderName = m.SenderName;
                    string senderEmail = m.Email;
                    string senderMessage = m.Content;
                    newmsg.Subject = "noyaschleien@noyaschleien.com";
                    newmsg.Body = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", senderName, senderEmail, senderMessage, Request.Browser, Request.UserAgent, Request.UserHostAddress, Request.UserHostName);

                    SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
                    smtp.Send(newmsg);

                    return RedirectToAction("Confirmation");
                }
                catch (Exception)
                {


                }
            }




            // If we got this far, something failed, redisplay form

            return View();
        }
    }
}