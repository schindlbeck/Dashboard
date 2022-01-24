namespace Directory.CLI.Data.Models;
public class DirectorySize
{
    public int Id { get; set; }

    public long Size { get; set; }

    public string Project { get; set; } = string.Empty;

    public string Year { get; set; } = string.Empty;
}