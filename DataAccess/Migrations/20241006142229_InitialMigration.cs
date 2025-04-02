using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "account_informations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    DesiredWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    Goal = table.Column<string>(type: "TEXT", nullable: true),
                    DailyCalories = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    AccountEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_informations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_account_informations_accounts_AccountEmail",
                        column: x => x.AccountEmail,
                        principalTable: "accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Calories = table.Column<int>(type: "INTEGER", nullable: false),
                    Protein = table.Column<int>(type: "INTEGER", nullable: false),
                    Carbs = table.Column<int>(type: "INTEGER", nullable: false),
                    Fat = table.Column<int>(type: "INTEGER", nullable: false),
                    Recipe = table.Column<string>(type: "TEXT", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: false),
                    AccountEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dish_accounts_AccountEmail",
                        column: x => x.AccountEmail,
                        principalTable: "accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "food_plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Calories = table.Column<int>(type: "INTEGER", nullable: false),
                    Protein = table.Column<int>(type: "INTEGER", nullable: false),
                    Carbs = table.Column<int>(type: "INTEGER", nullable: false),
                    Fat = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_food_plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_food_plan_accounts_AccountEmail",
                        column: x => x.AccountEmail,
                        principalTable: "accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statistic_entity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Weight = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statistic_entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_statistic_entity_accounts_AccountEmail",
                        column: x => x.AccountEmail,
                        principalTable: "accounts",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Calories = table.Column<int>(type: "INTEGER", nullable: false),
                    Protein = table.Column<int>(type: "INTEGER", nullable: false),
                    Carbs = table.Column<int>(type: "INTEGER", nullable: false),
                    Fat = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodPlanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_meal_food_plan_FoodPlanId",
                        column: x => x.FoodPlanId,
                        principalTable: "food_plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishMeal",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "INTEGER", nullable: false),
                    MealsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishMeal", x => new { x.DishesId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_DishMeal_dish_DishesId",
                        column: x => x.DishesId,
                        principalTable: "dish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishMeal_meal_MealsId",
                        column: x => x.MealsId,
                        principalTable: "meal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_informations_AccountEmail",
                table: "account_informations",
                column: "AccountEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dish_AccountEmail",
                table: "dish",
                column: "AccountEmail");

            migrationBuilder.CreateIndex(
                name: "IX_DishMeal_MealsId",
                table: "DishMeal",
                column: "MealsId");

            migrationBuilder.CreateIndex(
                name: "IX_food_plan_AccountEmail",
                table: "food_plan",
                column: "AccountEmail");

            migrationBuilder.CreateIndex(
                name: "IX_meal_FoodPlanId",
                table: "meal",
                column: "FoodPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_statistic_entity_AccountEmail",
                table: "statistic_entity",
                column: "AccountEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account_informations");

            migrationBuilder.DropTable(
                name: "DishMeal");

            migrationBuilder.DropTable(
                name: "statistic_entity");

            migrationBuilder.DropTable(
                name: "dish");

            migrationBuilder.DropTable(
                name: "meal");

            migrationBuilder.DropTable(
                name: "food_plan");

            migrationBuilder.DropTable(
                name: "accounts");
        }
    }
}
