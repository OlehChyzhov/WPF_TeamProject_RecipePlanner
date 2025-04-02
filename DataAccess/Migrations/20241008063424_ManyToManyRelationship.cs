using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMeal_dish_DishesId",
                table: "DishMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMeal_meal_MealsId",
                table: "DishMeal");

            migrationBuilder.RenameColumn(
                name: "MealsId",
                table: "DishMeal",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "DishesId",
                table: "DishMeal",
                newName: "DishId");

            migrationBuilder.RenameIndex(
                name: "IX_DishMeal_MealsId",
                table: "DishMeal",
                newName: "IX_DishMeal_MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishMeal_dish_DishId",
                table: "DishMeal",
                column: "DishId",
                principalTable: "dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishMeal_meal_MealId",
                table: "DishMeal",
                column: "MealId",
                principalTable: "meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMeal_dish_DishId",
                table: "DishMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMeal_meal_MealId",
                table: "DishMeal");

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "DishMeal",
                newName: "MealsId");

            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "DishMeal",
                newName: "DishesId");

            migrationBuilder.RenameIndex(
                name: "IX_DishMeal_MealId",
                table: "DishMeal",
                newName: "IX_DishMeal_MealsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishMeal_dish_DishesId",
                table: "DishMeal",
                column: "DishesId",
                principalTable: "dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishMeal_meal_MealsId",
                table: "DishMeal",
                column: "MealsId",
                principalTable: "meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
