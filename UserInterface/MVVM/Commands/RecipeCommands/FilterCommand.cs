// <copyright file="FilterCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.RecipeCommands
{
    using System;
    using System.Windows.Input;

    public class FilterCommand : ICommand
    {
        RecipesViewModel VM;
        public FilterCommand(RecipesViewModel vm)
        {
            VM = vm;
        }
        public event EventHandler? CanExecuteChanged;

        public void FireEvent()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.ExecuteFilterCommand();
        }
    }
}
