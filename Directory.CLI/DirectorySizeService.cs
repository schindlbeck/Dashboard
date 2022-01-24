using Directory.CLI.Data;
using Directory.CLI.Data.Models;

namespace Directory.CLI;
public class DirectorySizeService
{
    readonly DirectoryDbContext dbContext;

    public DirectorySizeService(DirectoryDbContext context)
    {
        dbContext = context;
    }

    public void Add(DirectorySize directory)
    {
        if(directory == null)
        {
            throw new ArgumentNullException(nameof(directory));
        }

        dbContext.Add(directory);
        dbContext.SaveChanges();
    }
}
