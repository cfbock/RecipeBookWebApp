using Microsoft.EntityFrameworkCore;
using RecipeBookWebApp.Models;

namespace RecipeBookWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes => Set<Recipe>();
}
