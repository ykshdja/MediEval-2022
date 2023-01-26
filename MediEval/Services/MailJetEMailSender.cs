using Mailjet.Client;
using Mailjet.Client.Resources;
using Mailjet.Client.TransactionalEmails;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;

namespace MediEval.Services
{
    public class MailJetEMailSender : IEmailSender
    {

        private readonly IConfiguration _configuration;
        public MailJetOptions _mailJetOptions;

        public MailJetEMailSender(IConfiguration configuration, MailJetOptions mailJetOptions)
        {
            _configuration = configuration;
            _mailJetOptions = mailJetOptions;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //MailJet

            MailjetClient client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey)
            {
                //Version = ApiVersion.V3_1,
            };

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource
            };

            var emailData = new TransactionalEmailBuilder()
                .WithFrom(new SendContact("slf.ysh31@gmail.com"))
                .WithSubject("Greetings from Mailjet")
                .WithTextPart("My first Mailjet email")
                .WithTo(new SendContact("slf.ysh31@gmail.com"))
                .Build();

            var response = await client.SendTransactionalEmailAsync(emailData);
                 
     //       MailjetRequest request = new MailjetRequest
     //       {
     //           Resource = Send.Resource,
     //       }
     //        .Property(Send.Messages, new JArray {
     //new JObject {
     // {
     //  "From",
     //  new JObject {
     //   {"Email", "slf.ysh31@gmail.com"},
     //   {"Name", "Yash"}
     //  }
     // }, {
     //  "To",
     //  new JArray {
     //   new JObject {
     //    {
     //     "Email",
     //     "slf.ysh31@gmail.com"
     //    }, {
     //     "Name",
     //     "Yash"
     //    }
     //   }
     //  }
     // }, {
     //  "Subject",
     //  "Greetings from Mailjet."
     // }, {
     //  "TextPart",
     //  "My first Mailjet email"
     // }, {
     //  "HTMLPart",
     //  "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
     // }, {
     //  "CustomID",
     //  "AppGettingStartedTest"
     // }
     //}
     //        });
     //       MailjetResponse response = await client.PostAsync(request);
            if (response.Messages.Any() == true)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.Messages.Count(),1));
                //Console.WriteLine(response.GetData());
            }
            else
            {
                //Console.WriteLine(string.Format("StatusCode: {0}\n", response.));
                //Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                //Console.WriteLine(response.GetData());
                //Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }
        //MailJet
    }

}
    

