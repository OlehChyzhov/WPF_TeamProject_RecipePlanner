using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("statistic_entity")]
    public class StatisticEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Weight { get; set; }
        public string AccountEmail { get; set; } = null!;
        [ForeignKey(nameof(AccountEmail))]
        public Account Account { get; set; } = null!;

        public override string ToString()
        {
            return $"Date: {Date}; Weight: {Weight}";
        }
    }
}
