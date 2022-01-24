using Directory.CLI;
using System.CommandLine;
using System.CommandLine.Invocation;

class Program
{
    static int Main(string[] args)
    {
        Manage manager = new();
        var rootCommand = new RootCommand();
        

        //Commands
        var diskUsageCommand = new Command("du");
        rootCommand.Add(diskUsageCommand);

        //Command Options


        //CommandHandler
        diskUsageCommand.Handler = CommandHandler.Create(manager.Execute);

        //Return
        try
        {
            return rootCommand.Invoke(args);
        }
        catch
        {
            return -1;
        }
    }

}