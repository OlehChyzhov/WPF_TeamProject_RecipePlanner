// <copyright file="RemoveIngredient.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.RecipeCommands
{
    using System;
    using System.Windows.Input;

    public class RemoveIngredient : ICommand
    {
        private RecipesViewModel VM;
        public RemoveIngredient(RecipesViewModel vm)
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
            VM.IngredientsOfDishToEditOrDelete.Remove(VM.NewIngredient);
        }
    }
}
