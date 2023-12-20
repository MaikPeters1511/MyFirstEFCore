namespace MyFirstEFCore.Model;

public class Dish
{
    public int Id { get; set; }

    [MaxLength(100)] public string Title { get; set; } = string.Empty;

    [MaxLength(1000)] public string? Notes { get; set; }

    public int? Stars { get; set; }

    public List<DishIngredient> Ingredients { get; set; } = new();
}