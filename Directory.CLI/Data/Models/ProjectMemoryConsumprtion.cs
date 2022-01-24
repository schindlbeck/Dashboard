namespace Directory.CLI.Data.Models;

public class ProjectMemoryConsumprtion
{
    public int Id { get; set; }
    public string Project { get; set; } = string.Empty;
    public long MinConsumption { get; set; }
    public long MaxConsumption { get; set;}
    public long MeanConsumption { get; set; }
    public long MedianConsumption { get; set; }
    public long StandardDeviation { get; set; }
}