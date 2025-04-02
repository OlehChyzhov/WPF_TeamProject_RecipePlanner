// <copyright file="EditRecipeCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.RecipeCommands
{
    using System;
    using System.Windows.Input;

    public class EditRecipeCommand : ICommand
    {
        private RecipesViewModel VM;
        public EditRecipeCommand(RecipesViewModel vm)
        {
            VM = vm;
        }
        public void FireEvent()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.ExecuteEditRecipeCommand(parameter!);
        }
    }
}
