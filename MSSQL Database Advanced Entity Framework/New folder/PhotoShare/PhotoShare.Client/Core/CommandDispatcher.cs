namespace PhotoShare.Client.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Commands;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            var commandName = commandParameters[0] + "Command";
            var args = commandParameters.Skip(1).ToArray();

            var executingCommand = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .SingleOrDefault(t => t.Name == commandName
                 && t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (executingCommand == null)
            {
                throw new InvalidOperationException($"Command {commandParameters[0]} not valid!");
            }

            var command = (ICommand)Activator.CreateInstance(executingCommand);
            var result = command.Execute(args);
            return result;
        }
    }
}
