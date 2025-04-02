namespace DataAccess.Models
{
    public class DishMeal
    {
        public int DishId { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; } = null!;
        public Dish Dish { get; set; } = null!;
    }
}
