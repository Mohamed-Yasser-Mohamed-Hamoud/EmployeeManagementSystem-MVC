using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TestCoreApp.Models
{
    public class clsEmailConfirm : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fMail = "Mohamed.Yasser.Mohamed.Hamoud@gmail.com"; // إيميلك هنا
            var fPassword = "zowd kelb hkth jbkz"; // الـ 16 حرف بتوع الـ App Password هنا

            using (var theMsg = new MailMessage())
            {
                theMsg.From = new MailAddress(fMail, "اسم موقعك");
                theMsg.Subject = subject;
                theMsg.To.Add(email);
                theMsg.Body = htmlMessage; // الـ htmlMessage اللي مبعوتة جاهزة كـ HTML
                theMsg.IsBodyHtml = true;

                // استخدم smtp.gmail.com لو شغال جوجل
                // استخدم smtp-mail.outlook.com لو شغال أوتلوك
                using (var smtpClint = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClint.Port = 587;
                    smtpClint.EnableSsl = true;
                    smtpClint.Credentials = new NetworkCredential(fMail, fPassword);

                    // أهم تعديل: استخدم SendMailAsync مع await
                    await smtpClint.SendMailAsync(theMsg);
                }
            }
        }
    }
}