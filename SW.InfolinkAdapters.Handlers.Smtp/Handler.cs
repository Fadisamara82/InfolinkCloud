using Newtonsoft.Json;
using SW.PrimitiveTypes;
using SW.Serverless.Sdk;

namespace SW.InfolinkAdapters.Handlers.Smtp;

public class Handler : IInfolinkHandler
{
    public Handler()
    {
        Runner.Expect(CommonProperties.Port);
        Runner.Expect(CommonProperties.Host);
        Runner.Expect(CommonProperties.From);
        Runner.Expect(CommonProperties.Password);
    }

    public Task<XchangeFile> Handle(XchangeFile xchangeFile)
    {
        var emailModel = JsonConvert.DeserializeObject<InputModel>(xchangeFile.Data);


        Mailer.SendEmail(
            Runner.StartupValueOf(CommonProperties.Host),
            Convert.ToInt32(Runner.StartupValueOf(CommonProperties.Port)),
            Runner.StartupValueOf(CommonProperties.From),
            Runner.StartupValueOf(CommonProperties.Password),
            emailModel.To,
            emailModel.OtherTo,
            emailModel.Cc,
            emailModel.Bcc,
            emailModel.Subject,
            emailModel.Body,
            emailModel.IsHtml,
            emailModel.AttachmentName,
            emailModel.AttachmentBody,
            false
        );
        return Task.FromResult(new XchangeFile(string.Empty));
    }
}