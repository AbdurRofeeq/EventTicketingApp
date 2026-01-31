using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;
using EventTicketingApp.Models;
using EventTicketingApp.Core.Application.Interfaces.Services;
using MailKit.Security;
using EventTicketingApp.Models.AttendeeModel;

public class EmailSender : IMailServices
{
    private readonly string _smtpHost;
    private readonly int _smtpPort;
    private readonly string _smtpUser;
    private readonly string _smtpPass;
    private readonly string _fromEmail;
    private readonly string _fromName;
    private readonly bool _enableSsl;

    public EmailSender(IConfiguration configuration)
    {
        _smtpHost = configuration["Smtp:Host"]
            ?? throw new InvalidOperationException("SMTP Host is not configured.");

        _smtpPort = configuration.GetValue<int>("Smtp:Port", 587);
        _smtpUser = configuration["Smtp:Username"]
            ?? throw new InvalidOperationException("SMTP Username is not configured.");

        _smtpPass = configuration["Smtp:Password"]
            ?? throw new InvalidOperationException("SMTP Password is not configured.");

        _fromEmail = configuration["Smtp:FromEmail"]
            ?? throw new InvalidOperationException("FromEmail is not configured.");

        _fromName = configuration["Smtp:FromName"] ?? "EventTicket";
        _enableSsl = configuration.GetValue<bool>("Smtp:EnableSsl", true);
    }

    public void SendEMail(EmailDto mailRequest)
    {
        MimeMessage message = new MimeMessage();
        message.From.Add(new MailboxAddress("EventTicket", _fromEmail));
        message.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        message.Subject = mailRequest.Subject;

        var body = new TextPart("html")
        {
            Text = mailRequest.HtmlContent,
        };
        message.Body = body;

        SmtpClient client = new SmtpClient();
        try
        {
            client.Connect(_smtpHost, _smtpPort, true);
            client.Authenticate(_smtpUser, _smtpPass);
            client.Send(message);
        }
        catch(Exception ex)
        {
            throw new InvalidOperationException("Failed to send email.", ex);
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    }

    public void QRCodeEMail(EmailDto mailRequest, string qrCodeImagePath)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("EventTicket", _fromEmail));
        message.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        message.Subject = mailRequest.Subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = mailRequest.HtmlContent;

        var attachment = builder.Attachments.Add(qrCodeImagePath);
        attachment.ContentId = "qrcode";

        message.Body = builder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect(_smtpHost, _smtpPort, true);
            client.Authenticate(_smtpUser, _smtpPass);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}