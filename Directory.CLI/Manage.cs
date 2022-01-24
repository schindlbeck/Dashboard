namespace Directory.CLI;

using System.IO;

internal class Manage
{
    private const string DIR = @"C:\Users\lado\source\repos\EvMobility";

    public static void Execute()
    {
        var di = new DirectoryInfo(DIR);
        var directories = di.GetDirectories();


        foreach (var d in directories)
        {
            long totalsize = 0;

            foreach (var file in d.GetFiles("*", SearchOption.AllDirectories))
            {
                totalsize += file.Length;
            }

            Console.WriteLine($"{d.Name} size: {totalsize} bytes");
        }

        Console.ReadLine();
    }

}
