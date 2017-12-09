namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class PrintFriendsListCommand : ICommand
    {
        // PrintFriendsList <username>
        public string Execute(string[] data)
        {
            var command = new ListFriendsCommand();
            return command.Execute(data);
        }
    }
}
