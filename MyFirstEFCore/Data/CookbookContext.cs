namespace MyFirstEFCore.Data;

public class CookbookContext : DbContext
{
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DishIngredient> Ingredients { get; set; }
    
    public CookbookContext(DbContextOptions<CookbookContext> contextOptions): base(contextOptions)
    {
        
    }
    
}