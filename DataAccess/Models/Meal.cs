using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("meal")]
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int FoodPlanId { get; set; }

        [ForeignKey(nameof(FoodPlanId))]
        public FoodPlan FoodPlan { get; set; } = null!;
        public List<DishMeal> DishMeals { get; set; } = null!;

        public override string ToString()
        {
            return $"Title: {Title}";
        }
    }
}
