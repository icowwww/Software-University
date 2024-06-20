namespace MailClient;

public class Mail
{
    public Mail(string sender, string receiver, string body)
    {
        Sender = sender;
        Receiver = receiver;
        Body = body;
    }

    public string Sender { get; }
    public string Receiver { get; }
    public string Body { get; }

    public override string ToString() => $"From: {Sender} / To: {Receiver}{Environment.NewLine}Message: {Body}";
}