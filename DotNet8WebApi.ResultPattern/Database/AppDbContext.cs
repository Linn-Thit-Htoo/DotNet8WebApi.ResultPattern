using DotNet8WebApi.ResultPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.ResultPattern.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Tbl_Blog> Blogs { get; set; }
}
