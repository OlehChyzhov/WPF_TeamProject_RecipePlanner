// <copyright file="RecipesViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Windows;
    using BusinessLogic;
    using DataAccess;
    using DataAccess.Models;
    using LiveCharts;
    using Microsoft.Win32;
    using UserInterface.MVVM.Commands.RecipeCommands;

    /// <summary>
    /// ViewModel for 'Recipes' page.
    /// </summary>
    public class RecipesViewModel : BaseViewModel
    {
        private LogWriter logWriter = new LogWriter("../../../Logs/recipes.log");

        private string searchFilter = string.Empty;
        private string orderFilter = string.Empty;
        private Dish dishToEditOrDelete = new Dish();
        private Dish newDish = new Dish();
        private string newIngredient = "New Ingredient";

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipesViewModel"/> class.
        /// </summary>
        public RecipesViewModel()
        {
            this.FilterCommand = new FilterCommand(this);
            this.SeeRecipeCommand = new SeeRecipeCommand(this);
            this.AddRecipeCommand = new AddRecipeCommand(this);
            this.EditRecipeCommand = new EditRecipeCommand(this);
            this.RemoveRecipeCommand = new RemoveRecipeCommand(this);
            this.UpdateDishCommand = new SaveNewDishCommand(this);
            this.AddIngredientCommand = new AddIngredientCommand(this);
            this.RemoveIngedientCommand = new RemoveIngredient(this);
            this.AddNewDishCommand = new AddNewDishCommand(this);
            this.ChangeImageCommand = new ChangeDishImageCommand(this);

            this.ChartProtein = new ChartValues<int>();
            this.ChartCarbs = new ChartValues<int>();
            this.ChartFat = new ChartValues<int>();

            this.Dishes = new ObservableCollection<Dish>();
            this.IngredientsOfDishToEditOrDelete = new ObservableCollection<string>();
            this.ShowDishes();
        }

        /// <summary>
        /// Gets or sets values for protein of the dish.
        /// </summary>
        public ChartValues<int> ChartProtein { get; set; }

        /// <summary>
        /// Gets or sets values for carbs of the dish.
        /// </summary>
        public ChartValues<int> ChartCarbs { get; set; }

        /// <summary>
        /// Gets or sets values for fat of the dish.
        /// </summary>
        public ChartValues<int> ChartFat { get; set; }

        /// <summary>
        /// Gets or sets dishes to be displayed in the main page.
        /// </summary>
        public ObservableCollection<Dish> Dishes { get; set; }

        /// <summary>
        /// Gets or sets ingredients of the dish to be edited or deleted.
        /// Also used when adding new dish.
        /// </summary>
        public ObservableCollection<string> IngredientsOfDishToEditOrDelete { get; set; }

        /// <summary>
        /// Gets or sets dish to be created.
        /// </summary>
        public Dish NewDish
        {
            get => this.newDish;
            set
            {
                this.newDish = value;
                this.OnPropertyChanged(nameof(this.NewDish));
            }
        }

        /// <summary>
        /// Gets or sets dish to edit or delete.
        /// </summary>
        public Dish DishToEditOrDelete
        {
            get => this.dishToEditOrDelete;
            set
            {
                this.dishToEditOrDelete = value;
                this.OnPropertyChanged(nameof(this.DishToEditOrDelete));
            }
        }

        /// <summary>
        /// Gets or sets serch query to display dishes.
        /// </summary>
        public string SearchFilter
        {
            get => this.searchFilter;
            set
            {
                this.searchFilter = value;
                this.OnPropertyChanged(nameof(this.SearchFilter));
                this.FilterCommand.FireEvent();
            }
        }

        /// <summary>
        /// Gets or sets filter to order displayed dishes.
        /// </summary>
        public string OrderFilter
        {
            get => this.orderFilter;
            set
            {
                this.orderFilter = value.Replace(" ", string.Empty).Split(":")[1];
                this.OnPropertyChanged(nameof(this.OrderFilter));
                this.ExecuteOrderCommand();
            }
        }

        /// <summary>
        /// Gets or sets ingredient to be added to 'IngredientsOfDishToEditOrDelete'.
        /// </summary>
        public string NewIngredient
        {
            get => this.newIngredient;
            set
            {
                this.newIngredient = value;
                this.OnPropertyChanged(nameof(this.NewIngredient));
            }
        }

        /// <summary>
        /// Gets filter method to be binded.
        /// </summary>
        public FilterCommand FilterCommand { get; }

        /// <summary>
        /// Gets displays dishes.
        /// </summary>
        public SeeRecipeCommand SeeRecipeCommand { get; }

        /// <summary>
        /// Gets new dish and passes it to add dish page.
        /// </summary>
        public AddRecipeCommand AddRecipeCommand { get; }

        /// <summary>
        /// Gets existing dish and passes it to edit dish page.
        /// </summary>
        public EditRecipeCommand EditRecipeCommand { get; }

        /// <summary>
        /// Gets existing dish and removes it.
        /// </summary>
        public RemoveRecipeCommand RemoveRecipeCommand { get; }

        /// <summary>
        /// Gets passed dish and updates it.
        /// </summary>
        public SaveNewDishCommand UpdateDishCommand { get; }

        /// <summary>
        /// Gets ingredient entered by user and adds it.
        /// </summary>
        public AddIngredientCommand AddIngredientCommand { get; }

        /// <summary>
        /// Gets selected ingredient and removes it.
        /// </summary>
        public RemoveIngredient RemoveIngedientCommand { get; }

        /// <summary>
        /// Gets new dish and adds it to database.
        /// </summary>
        public AddNewDishCommand AddNewDishCommand { get; }

        /// <summary>
        /// Gets image and sets it to the dish.
        /// </summary>
        public ChangeDishImageCommand ChangeImageCommand { get; }

        /// <summary>
        /// Gets and formats text of chart that shows dish protein, carbs and fat.
        /// </summary>
        public Func<ChartPoint, string> LabelFormatter
        {
            get
            {
                return this.FormatLabel;
            }
        }

        /// <summary>
        /// Gets filter query and if it is a text, searchs for dishes starting with the text.
        /// If it is a value, searchs for dishes whose calories are in close range.
        /// </summary>
        public void ExecuteFilterCommand()
        {
            bool isValue = true;
            foreach (char letter in this.SearchFilter)
            {
                if (char.IsLetter(letter))
                {
                    isValue = false;
                }
            }

            if (string.IsNullOrEmpty(this.SearchFilter) == false && isValue)
            {
                this.ShowDishes((dish) =>
                {
                    int givenCaloriesCount = int.Parse(this.SearchFilter);
                    int topBound = givenCaloriesCount + 250;
                    int bottomBound = givenCaloriesCount - 250;
                    return dish.Calories > bottomBound && dish.Calories < topBound;
                });
            }
            else if (string.IsNullOrEmpty(this.SearchFilter) == false)
            {
                this.ShowDishes(dish => dish.Title.StartsWith(this.SearchFilter));
            }
            else
            {
                this.ShowDishes();
            }
        }

        /// <summary>
        /// Displays dishes in a certain order.
        /// </summary>
        public void ExecuteOrderCommand()
        {
            List<Dish> dishesCopy = this.Dishes.ToList();

            switch (this.OrderFilter)
            {
                case "Protein":
                    dishesCopy = this.Dishes.OrderBy(dish => dish.Protein).ToList();
                    break;
                case "Carbs":
                    dishesCopy = this.Dishes.OrderBy(dish => dish.Carbs).ToList();
                    break;
                case "Fat":
                    dishesCopy = this.Dishes.OrderBy(dish => dish.Fat).ToList();
                    break;
            }

            this.RefillDishes(dishesCopy);
        }

        /// <summary>
        /// Displays dishes depending on a given filter.
        /// </summary>
        /// <param name="filter">Filter to use when displaying dishes.</param>
        public void ShowDishes(Func<Dish, bool>? filter = null)
        {
            List<Dish> dishes;

            if (filter != null)
            {
                dishes = AccountManager.LoginedAccount.Dishes!.Where(filter).ToList();
            }
            else
            {
                dishes = AccountManager.LoginedAccount.Dishes!.ToList();
            }

            this.RefillDishes(dishes);
        }

        /// <summary>
        /// Adds new dish to the database.
        /// </summary>
        /// <param name="dish">Dish to add.</param>
        /// <returns>True if added successfully. False if error occured.</returns>
        public bool SaveNewDish(Dish dish)
        {
            try
            {
                Dish dishToSave = dish;
                if (dishToSave.ImageUrl == null)
                {
                    dishToSave.ImageUrl = $"pack://application:,,,/Images/Accounts/MainPictures/test.png";
                }

                // Saving Ingredients
                dishToSave.Ingredients = this.BuildIngredientsString();

                // Saving the dish
                Dish? dishFromDb = DbHelper.db.Dishes.FirstOrDefault(d => d.Id == dishToSave.Id);
                if (dishFromDb == null)
                {
                    dishToSave.AccountEmail = AccountManager.LoginedAccount.Email;
                    DbHelper.db.Dishes.Add(dishToSave);
                }
                else
                {
                    DbHelper.db.Dishes.Update(dishToSave);
                }

                DbHelper.db.SaveChanges();
                return true;
            }
            catch
            {
                MessageBox.Show("Input valid values", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.logWriter.Write("SaveNewDish: Invalid values");
                return false;
            }
        }

        /// <summary>
        /// Builds string of ingredients to add to database.
        /// </summary>
        /// <returns>String of ingredients.</returns>
        public string BuildIngredientsString()
        {
            string modifiedIngredients = string.Empty;
            for (int i = 0; i < this.IngredientsOfDishToEditOrDelete.Count - 1; i++)
            {
                modifiedIngredients += $"{this.IngredientsOfDishToEditOrDelete[i]},";
            }

            modifiedIngredients += this.IngredientsOfDishToEditOrDelete.Last();
            return modifiedIngredients;
        }

        /// <summary>
        /// Shows 'SeeRecipe' page.
        /// </summary>
        /// <param name="dish">Dish to see.</param>
        public void ExecuteSeeRecipeCommand(object dish)
        {
            App.RightSideFrame.Navigate(App.MySeeRecipeWindow);
            App.MySeeRecipeWindow.DataContext = this;
            this.DishToEditOrDelete = (Dish)dish;

            this.RefillCharts(this.DishToEditOrDelete);
            List<string> newIngredients = this.DishToEditOrDelete.Ingredients.Split(",").ToList();
            this.RefillIngredientsOfDishToEditOrDelete(newIngredients);
        }

        /// <summary>
        /// Shows 'AddRecipe' page.
        /// </summary>
        public void ExecuteAddRecipeCommand()
        {
            App.MyAddRecipeWindow.DataContext = this;
            this.NewDish = new Dish();
            this.IngredientsOfDishToEditOrDelete.Clear();
            App.RightSideFrame.Navigate(App.MyAddRecipeWindow);
        }

        /// <summary>
        /// Shows 'EditRecipe' page.
        /// </summary>
        /// <param name="dish">Dish to edit.</param>
        public void ExecuteEditRecipeCommand(object dish)
        {
            App.RightSideFrame.Navigate(App.MyEditRecipeWindow);
            App.MyEditRecipeWindow.DataContext = this;
            this.DishToEditOrDelete = (Dish)dish;

            List<string> newIngredients = this.DishToEditOrDelete.Ingredients.Split(",").ToList();
            this.RefillIngredientsOfDishToEditOrDelete(newIngredients);
        }

        /// <summary>
        /// Removes dish.
        /// </summary>
        /// <param name="dish">Dish to remove.</param>
        public void ExecuteRemoveRecipeCommand(object dish)
        {
            this.Dishes.Remove((Dish)dish);
            DbHelper.db.Dishes.Remove((Dish)dish);
            DbHelper.db.SaveChanges();
            try
            {
                File.Delete(((Dish)dish).ImageUrl!);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Changes image of the dish.
        /// </summary>
        public void ExecuteChangeDishImageCommand()
        {
            string fileName = $"{AccountManager.LoginedAccount.Email.Substring(0, 5)}.{this.DishToEditOrDelete.Title.Replace(" ", string.Empty)}";
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                string destination = $"../../../Images/Dishes/MainPictures/{fileName}.png";
                File.Copy(openDialog.FileName, destination, true);
                this.DishToEditOrDelete.ImageUrl = $"pack://application:,,,/Images/Dishes/MainPictures/{fileName}.png";
                this.NewDish.ImageUrl = $"pack://application:,,,/Images/Dishes/MainPictures/{fileName}.png";
            }
        }

        private string FormatLabel(ChartPoint chartPoint)
        {
            double value = chartPoint.Y; // The numeric value of this slice
            double percentage = chartPoint.Participation * 100;

            return $"{value}g ({percentage:F1}%)";
        }

        /// <summary>
        /// When a new dish is added, this method repopulates dishes to be displayed.
        /// </summary>
        /// <param name="dishes">Dishes to show.</param>
        private void RefillDishes(List<Dish> dishes)
        {
            this.Dishes.Clear();
            foreach (Dish dish in dishes)
            {
                this.Dishes.Add(dish);
            }
        }

        /// <summary>
        /// Refills ingredients of the dish to edit.
        /// </summary>
        /// <param name="ingredients">New ingredients.</param>
        private void RefillIngredientsOfDishToEditOrDelete(List<string> ingredients)
        {
            this.IngredientsOfDishToEditOrDelete.Clear();
            foreach (string ingredient in ingredients)
            {
                this.IngredientsOfDishToEditOrDelete.Add(ingredient);
            }
        }

        private void RefillCharts(Dish dish)
        {
            this.ChartProtein.Clear();
            this.ChartCarbs.Clear();
            this.ChartFat.Clear();
            this.ChartProtein.Add(dish.Protein);
            this.ChartCarbs.Add(dish.Carbs);
            this.ChartFat.Add(dish.Fat);
        }
    }
}
