namespace Directory.CLI;

using System;
using System.IO;

internal class Manage
{
    private const string DIR = @"C:\Users\lado\source\repos\EvMobility";

    public static void Execute()
    {
        //TODO : one more folder level
        var di = new DirectoryInfo(DIR);
        ManageDirectories(di);
        ManageFiles(di);

        Console.ReadLine();
    }

    private static void ManageFiles(DirectoryInfo di)
    {
        var files = di.GetFiles();

        Console.WriteLine("Files:");

        foreach (var file in files)
        {
            Console.WriteLine($"{file.Name} size: {file.Length} bytes");
        }

        Console.WriteLine(Environment.NewLine);
    }

    private static void ManageDirectories(DirectoryInfo di)
    {
        var directories = di.GetDirectories();
        Console.WriteLine("Directories:");
        foreach (var d in directories)
        {
            long totalsize = 0;

            foreach (var file in d.GetFiles("*", SearchOption.AllDirectories))
            {
                totalsize += file.Length;
            }

            Console.WriteLine($"{d.Name} size: {totalsize} bytes");
        }

        Console.WriteLine(Environment.NewLine);

    }
}
