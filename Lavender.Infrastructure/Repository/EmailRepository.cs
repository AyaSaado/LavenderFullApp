using Lavender.Core.Helper;
using Lavender.Core.Interfaces.Repository;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Lavender.Infrastructure.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailSettings emailSettings;
        public EmailRepository(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }
        public async Task<bool> SendEmailAsync(Mailrequest mailrequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
            email.Subject = mailrequest.Subject;
            var builder = new BodyBuilder();


            //  byte[] fileBytes;
            //if (File.Exists("Attachment/dummy.pdf"))
            //{
            //    FileStream file = new FileStream("Attachment/dummy.pdf", FileMode.Open, FileAccess.Read);
            //    using (var ms = new MemoryStream())
            //    {
            //        file.CopyTo(ms);
            //        fileBytes = ms.ToArray();
            //    }
            //    builder.Attachments.Add("attachment.pdf", fileBytes, ContentType.Parse("application/octet-stream"));
            //    builder.Attachments.Add("attachment2.pdf", fileBytes, ContentType.Parse("application/octet-stream"));
            //}

            builder.HtmlBody = $@"
                               <table  style='background: linear-gradient(to right,#7089F1, #7C4088);border-radius: 10px;  margin-left: auto; margin-right: auto; width: 30%;'>
                                   <tr>
                                       <td align='center'>
                                           <div style='width: 100%; max-width: 600px; margin: 0 auto; color: white;'>
                                               <h1>{mailrequest.Body}</h1>
                                           </div>
                                       </td>
                                   </tr>
                               </table>";
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
         
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            return true;
            
            
        }
    }
}

