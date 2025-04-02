using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("accounts")]
    public class Account
    {
        [Key]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public AccountInfo AccountInfo { get; set; } = null!;
        public List<StatisticEntity>? StatisticEntities { get; set; }
        public List<Dish>? Dishes { get; set; }
        public List<FoodPlan>? FoodPlans { get; set; }

        public override string ToString()
        {
            return $"Email: {Email}; Password: {Password}";
        }
    }
}
