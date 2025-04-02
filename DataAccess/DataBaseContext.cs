using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountInfo> AccountInformations { get; set; }
        public DbSet<StatisticEntity> StatisticEntities { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<FoodPlan> FoodPlans { get; set; }
        public DbSet<DishMeal> DishMealConnectTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=D:\Programming\UniversityTasks\Large Projects\WPF\RecipePlanner\DataAccess\Database\database.db");
        }
        // Only in many-to-many relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishMeal>().HasKey(dm => new { dm.DishId, dm.MealId });
            modelBuilder.Entity<DishMeal>().HasOne(dm => dm.Dish).WithMany(m => m.DishMeals).HasForeignKey(dm => dm.DishId);
            modelBuilder.Entity<DishMeal>().HasOne(dm => dm.Meal).WithMany(m => m.DishMeals).HasForeignKey(dm => dm.MealId);
        }
    }
}
