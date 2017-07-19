using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using UtilitySignupService.Models;

namespace UtilitySignupService.Services
{
    public class EmailService : IEmailService
    {
        public const string templateRoot = @"/Assets/Templates/";

        public EmailService(IOptions<EmailSettings> emailSettings, IHostingEnvironment hostingEnvironment)
        {
            this.EmailSettings = emailSettings.Value;

        }

        public EmailSettings EmailSettings { get; set; }
        public IHostingEnvironment Server {get;set;}
        public async Task Send(NotifyType notifyType, Enrollment enrollment)
        {
            var from = "Utility Signup Service <postmaster@sandbox9db43b359648414c8fb2ab0f36c4b5c8.mailgun.org>";
            var to = string.Empty;
            var subject = string.Empty;
            var html = string.Empty;
            var basePath = this.Server.ContentRootPath;
        
            using (var client = new HttpClient { BaseAddress = new Uri("https://api.mailgun.net/v3/") })
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                  Convert.ToBase64String(Encoding.ASCII.GetBytes("api:key-ec9d37cef635d2b64deac5bd7513eb13")));
                
                switch (notifyType)
                {
                    case NotifyType.External:
                        to = $"{enrollment.Resident.FirstName} {enrollment.Resident.LastName} <{enrollment.Resident.Email}>";
                        subject = "Your Service Request is Being Processed";
                        html = System.IO.File.ReadAllText($"{basePath}{templateRoot}{this.EmailSettings.ExternalTemplate}");
                        break;
                    case NotifyType.Internal:
                        to = $"{this.EmailSettings.InternalContact} <{this.EmailSettings.InternalEmail}>";
                        subject = "New Service Sign up";
                        html = System.IO.File.ReadAllText($"{basePath}{templateRoot}{this.EmailSettings.InternalTemplate}");
                        break;
                    case NotifyType.Property:
                        to = $"{enrollment.CreatedBy.Name} <{enrollment.CreatedBy.Email}>";
                        subject = "Resident Service Sign Up";
                        html =  System.IO.File.ReadAllText($"{basePath}{templateRoot}{this.EmailSettings.PropertyTemplate}");
                        break;
                    default:
                        break;
                }

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("from", from),
                    new KeyValuePair<string, string>("to", to),
                    new KeyValuePair<string, string>("subject", subject),
                    new KeyValuePair<string, string>("html", html)
                });

                await client.PostAsync("sandbox9db43b359648414c8fb2ab0f36c4b5c8.mailgun.org/messages", content).ConfigureAwait(false);
            }
        }
    }
}