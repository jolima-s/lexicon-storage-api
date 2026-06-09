using Microsoft.EntityFrameworkCore;

public class LexiconStorageAPIContext(DbContextOptions<LexiconStorageAPIContext> options) : DbContext(options)
{
    public DbSet<LexiconStorageAPI.Entities.Product> Products { get; set; } = default!;
}
