using System.Text;

namespace MailClient;

public class MailBox
{
    public MailBox(int capacity)
    {
        Capacity = capacity;
        Inbox = new List<Mail>();
        Archive = new List<Mail>();
    }

    public int Capacity { get; }
    public List<Mail> Inbox { get; set; }
    public List<Mail> Archive { get; }

    public void IncomingMail(Mail mail)
    {
        if (Inbox.Count >= Capacity) return;
        Inbox.Add(mail);
    }

    public bool DeleteMail(string sender)
    {
        return Inbox.Remove(Inbox.FirstOrDefault(m => m.Sender == sender));
    }

    public int ArchiveInboxMessages()
    {
        var count = Inbox.Count;
        Archive.AddRange(Inbox);
        Inbox = new List<Mail>();

        return count;
    }

    public string GetLongestMessage()
    {
        return Inbox.OrderByDescending(m => m.Body.Length).FirstOrDefault().ToString();
    }

    public string InboxView()
    {
        StringBuilder sb = new();
        sb.AppendLine("Inbox:");
        Inbox.ForEach(x => sb.AppendLine(x.ToString().TrimEnd()));

        return sb.ToString().TrimEnd();
    }
}