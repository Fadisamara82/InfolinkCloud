namespace SW.InfolinkAdapters.Handlers.Smtp;

public class InputModel
{
    public string To { set; get; }
    public string Subject { set; get; }
    public string Body { set; get; }
    public bool IsHtml { set; get; } = false;
}