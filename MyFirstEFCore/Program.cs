var factory = new CookbookContextFactory();
using var context = factory.CreateDbContext(args);

Console.WriteLine("Add Porridge for breakfast");

// Create Dish
var porridge = new Dish { Title = "Breakfast Porridge", Notes = "This is so good", Stars = 4};
context.Dishes.Add(porridge);
await context.SaveChangesAsync();

Console.WriteLine($"Added Porridge (id = {porridge.Id}) successfully");

//Update Dish
Console.WriteLine("Change Porridge stars to 2");
porridge.Stars = 2;
await context.SaveChangesAsync();
Console.WriteLine("Change stars");

// Read Dish
Console.WriteLine("Checking stars for Porridge");
var dishes = await context.Dishes
    .Where(d => d.Title.Contains("Porridge"))
    .ToListAsync(); // LINQ -> SQL

if (dishes.Count != 1) Console.Error.WriteLine("Something really bad happened. Porridge disappeared :-(");
Console.WriteLine($"Porridge has {dishes[0].Stars} stars");

// Delete Dish
Console.WriteLine("Removing Porridge from database");
context.Dishes.Remove(porridge);
await context.SaveChangesAsync();

Console.WriteLine($"Porridge (id = {porridge.Id}) removed from database");



var dishes_include = context.Dishes.Include(d => d.Ingredients).ToList();
foreach (var dish in dishes_include)
{
    Console.WriteLine(dish.Title);
    foreach (var ingredient in dish.Ingredients)
    {
        Console.WriteLine($"{ingredient.Description} {ingredient.Amount}");
    }
}

//Linq Query
Console.WriteLine("Linq Query");
var dishe = await context.Dishes.Where(d => d.Stars > 3).ToListAsync();
Console.WriteLine("Dishes with more than 3 stars");
foreach (var items in dishe)
{
    Console.WriteLine(items.Title);
    Console.WriteLine(items.Notes);
    Console.WriteLine(items.Stars);
}

var dishestest = context.Dishes
    .Where(d => d.Ingredients.Any(i => i.Description == "Milk"))
    .ToList();

Console.WriteLine("Dishes with Milk");
Console.WriteLine(dishestest[0].Ingredients[0].Description);


Console.ReadKey();
