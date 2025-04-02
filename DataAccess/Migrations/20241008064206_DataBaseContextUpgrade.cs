using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseContextUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMeal_dish_DishId",
                table: "DishMeal");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMeal_meal_MealId",
                table: "DishMeal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishMeal",
                table: "DishMeal");

            migrationBuilder.RenameTable(
                name: "DishMeal",
                newName: "DishMealConnectTable");

            migrationBuilder.RenameIndex(
                name: "IX_DishMeal_MealId",
                table: "DishMealConnectTable",
                newName: "IX_DishMealConnectTable_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishMealConnectTable",
                table: "DishMealConnectTable",
                columns: new[] { "DishId", "MealId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishMealConnectTable_dish_DishId",
                table: "DishMealConnectTable",
                column: "DishId",
                principalTable: "dish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishMealConnectTable_meal_MealId",
                table: "DishMealConnectTable",
                column: "MealId",
                principalTable: "meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMealConnectTable_dish_DishId",
                table: "DishMealConnectTable");

            migrationBuilder.DropForeignKey(
                name: "FK_DishMealConnectTable_meal_MealId",
                table: "DishMealConnectTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishMealConnectTable",
                table: "DishMealConnectTable");

            migrationBuilder.RenameTable(
                name: "DishMealConnectTable",
                newName: "DishMeal");

            migrationBuilder.RenameIndex(
                name: "IX_DishMealConnectTable_MealId",
                table: "DishMeal",
                newName: "IX_DishMeal_MealId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishMeal",
                table: "DishMeal",
                columns: new[] { "DishId", "MealId" });

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
    }
}
