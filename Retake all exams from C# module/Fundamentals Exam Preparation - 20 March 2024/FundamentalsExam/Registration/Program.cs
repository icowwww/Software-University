using System.Text;

namespace Registration;

internal class Program
{
    private static void Main(string[] args)
    {
        var username = Console.ReadLine();
        var currInput = Console.ReadLine();
        var sb = new StringBuilder();
        while (currInput != "Registration")
        {
            var inputArgs = currInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var command = inputArgs[0];

            switch (command)
            {
                case "Letters":
                    var type = inputArgs[1];
                    username = type == "Lower" ? username.ToLower() : username.ToUpper();
                    sb.AppendLine(username);
                    break;
                case "Reverse":
                    var startIndex = int.Parse(inputArgs[1]);
                    var endIndex = int.Parse(inputArgs[2]);
                    if (startIndex < 0 || endIndex < 0 || startIndex >= username.Length ||
                        endIndex >= username.Length || startIndex > endIndex)
                        break;
                    var substrVal = username.Substring(startIndex, endIndex - startIndex + 1);
                    sb.AppendLine(string.Concat(substrVal.Reverse()));
                    break;
                case "Substring":
                    var valToRemove = inputArgs[1];
                    if (!username.Contains(valToRemove))
                    {
                        sb.AppendLine($"The username {username} doesn't contain {valToRemove}.");
                        break;
                    }

                    username = username.Replace(valToRemove, "");
                    sb.AppendLine(username);
                    break;
                case "Replace":
                    var charToRepl = inputArgs[1][0];
                    username = username.Replace(charToRepl, '-');
                    sb.AppendLine(username);
                    break;
                case "IsValid":
                    var charToExist = inputArgs[1][0];
                    if (username.Contains(charToExist))
                        sb.AppendLine("Valid username.");
                    else
                        sb.AppendLine($"{charToExist} must be contained in your username.");
                    break;
            }

            currInput = Console.ReadLine();
        }
        Console.WriteLine(sb.ToString());
    }
}