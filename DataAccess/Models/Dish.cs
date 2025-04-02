using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("dish")]
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; } = null!;
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public string Recipe { get; set; } = null!;
        public string Ingredients { get; set; } = null!;
        public string AccountEmail { get; set; } = null!;

        [ForeignKey(nameof(AccountEmail))]
        public Account Account { get; set; } = null!;
        public List<DishMeal> DishMeals { get; set; } = null!;

        public override string ToString()
        {
            return $"Title: {Title}; Protein: {Protein}; Carbs: {Carbs}; Fat: {Fat}; Calories: {Calories}";
        }
    }
}
