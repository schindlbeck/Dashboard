namespace Directory.CLI;

using Directory.CLI.Data;
using Directory.CLI.Data.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

internal class Manage
{
    private readonly string dir;
    private readonly DirectorySizeService service;

    public Manage()
    {
        var configuration = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json")
       .Build();

        DirectoryDbContextFactory factory = new();
        service = new(factory.CreateDbContext(Array.Empty<string>()));
        //dir = configuration["Path"];
        dir = configuration["PathTest"];
    }

    public void Execute()
    {
        //TODO : one more folder level
        var di = new DirectoryInfo(dir);
        ManageDirectories(di, "2022");
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

    private void ManageDirectories(DirectoryInfo di, string year)
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

            AddToDb(d, totalsize, year);
            Console.WriteLine($"{d.Name} size: {totalsize} bytes");
        }

        Console.WriteLine(Environment.NewLine);
    }

    private void AddToDb(DirectoryInfo dir, long size, string year)
    {
        DirectorySize directory = new()
        {
            Size = size,
            Project = dir.Name,
            Year = year
        };

        service.Add(directory);
    }
}
