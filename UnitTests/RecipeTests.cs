// <copyright file="RecipeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTests
{
    using BusinessLogic;
    using DataAccess;
    using DataAccess.Models;
    using UserInterface.MVVM;

    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void SearchTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            RecipesViewModel vm = new RecipesViewModel();
            vm.SearchFilter = "Sushi";
            vm.ExecuteFilterCommand();

            Dish? dish = vm.Dishes.FirstOrDefault();
            if (dish != null)
            {
                Assert.AreEqual(dish.Title, "Sushi Nigiri");
            }
            else
            {
                Assert.AreEqual(dish, null);
            }
        }

        [TestMethod]
        public void ShowDishesTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            RecipesViewModel vm = new RecipesViewModel();
            vm.ShowDishes(dish => dish.AccountEmail == "oleh.chyzhov@gmail.com");
            Assert.IsNotNull(vm.Dishes);
        }

        [TestMethod]
        public void SaveNewDishTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            RecipesViewModel vm = new RecipesViewModel();
            vm.IngredientsOfDishToEditOrDelete.Add("Ingredient 1");
            vm.IngredientsOfDishToEditOrDelete.Add("Ingredient 2");
            Dish saveDish = new Dish
            {
                Title = "Title",
                Recipe = "Recipe",
                Id = 43552,
            };
            vm.SaveNewDish(saveDish);
            Dish dishFromDb = DbHelper.db.Dishes.First(d => d.Title == "Title");

            Assert.AreEqual(dishFromDb.Id, saveDish.Id);

            Dish? d = DbHelper.db.Dishes.FirstOrDefault(d => d.Id == 43552);
            DbHelper.db.Dishes.Remove(d);
            DbHelper.db.SaveChanges();
        }

        [TestMethod]
        public void BuildIngredientsStringTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            RecipesViewModel vm = new RecipesViewModel();
            vm.IngredientsOfDishToEditOrDelete.Add("I1");
            vm.IngredientsOfDishToEditOrDelete.Add("I2");
            vm.IngredientsOfDishToEditOrDelete.Add("I3");
            Assert.AreEqual(vm.BuildIngredientsString(), "I1,I2,I3");
        }
    }
}
