using Microsoft.EntityFrameworkCore;

public class LexiconStorageAPIContext(DbContextOptions<LexiconStorageAPIContext> options) : DbContext(options)
{
    public DbSet<LexiconStorageAPI.Models.Product> Product { get; set; } = default!;
}
