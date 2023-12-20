namespace MyFirstEFCore.Model;

public class DishIngredient
{
    public int Id { get; set; }

    [MaxLength(500)] public string Description { get; set; } = string.Empty;

    [MaxLength(50)] public string UnitOfMeasure { get; set; } = string.Empty;

    [Column(TypeName = "decimal(5,2)")] public decimal Amount { get; set; }

    public Dish? Dish { get; set; } //  NavigationProperty

    public int DishId { get; set; } //  Foreign Keys Value
}