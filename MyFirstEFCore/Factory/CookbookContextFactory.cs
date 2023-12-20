namespace MyFirstEFCore.Factory;

public class CookbookContextFactory : IDesignTimeDbContextFactory<CookbookContext>
{
    public CookbookContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        var optionsBuilder = new DbContextOptionsBuilder<CookbookContext>();
        
        optionsBuilder
            // print SQL statements on the console
            // .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            .UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        
        return new CookbookContext(optionsBuilder.Options);
    }
}