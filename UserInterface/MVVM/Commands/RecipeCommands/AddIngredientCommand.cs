// <copyright file="AddIngredientCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.RecipeCommands
{
    using System;
    using System.Windows.Input;

    public class AddIngredientCommand : ICommand
    {
        private RecipesViewModel VM;
        public AddIngredientCommand(RecipesViewModel vm)
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
            VM.IngredientsOfDishToEditOrDelete.Add(VM.NewIngredient);
        }
    }
}
