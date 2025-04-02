// <copyright file="AddNewDishCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.RecipeCommands
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    public class AddNewDishCommand : ICommand
    {
        public RecipesViewModel VM;
        public AddNewDishCommand(RecipesViewModel vm)
        {
            VM = vm;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            bool res = VM.SaveNewDish(VM.NewDish);
            if (res == true)
            {
                VM.ShowDishes();
                MessageBox.Show("Recipe Added Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                App.RightSideFrame.Navigate(App.MyRecipesWindow);
            }
        }
    }
}
