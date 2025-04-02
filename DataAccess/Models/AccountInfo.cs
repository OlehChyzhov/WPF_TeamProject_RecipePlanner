using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("account_informations")]
    public class AccountInfo
    {
        [Key]
        public int Id { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int DesiredWeight { get; set; }
        public WeightGoal Goal { get; set; }
        public int DailyCalories { get; set; }
        public string? ImageUrl { get; set; }
        public string AccountEmail { get; set; } = null!;

        [ForeignKey(nameof(AccountEmail))]
        public Account Account { get; set; } = null!;

        public override string ToString()
        {
            return $"Age: {Age}; Weight: {Weight}; Height: {Height}; Sex: {Sex}\n" +
                   $"Goal: {Goal}; Desired weight: {DesiredWeight}; DailyCalories: {DailyCalories}";
        }
    }
}
