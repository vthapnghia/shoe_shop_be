﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using shoe_shop_be.Helpers;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Services
{
    public class MailService: IMailService
    {
       
            private readonly MailSettings _mailSettings;
            public MailService(IOptions<MailSettings> mailSettingsOptions)
            {
                _mailSettings = mailSettingsOptions.Value;
            }

            public bool SendMail(MailData mailData)
            {
                try
                {
                    using (MimeMessage emailMessage = new MimeMessage())
                    {
                        MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                        emailMessage.From.Add(emailFrom);
                        MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                        emailMessage.To.Add(emailTo);
                        emailMessage.Subject = mailData.EmailSubject;
                        BodyBuilder emailBodyBuilder = new BodyBuilder();
                        emailBodyBuilder.TextBody = mailData.EmailBody;

                        emailMessage.Body = emailBodyBuilder.ToMessageBody();
                        //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                        using (SmtpClient mailClient = new SmtpClient())
                        {
                            mailClient.Connect(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                            mailClient.Authenticate(_mailSettings.SenderEmail, _mailSettings.Password);
                            mailClient.Send(emailMessage);
                            mailClient.Disconnect(true);
                        }
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    // Exception Details
                    return false;
                }
            }
        
    }
}
