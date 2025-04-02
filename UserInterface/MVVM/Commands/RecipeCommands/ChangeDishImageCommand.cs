// <copyright file="ChangeDishImageCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.RecipeCommands
{
    using System.Windows.Input;

    /// <summary>
    /// Changes image of a dish.
    /// </summary>
    public class ChangeDishImageCommand : ICommand
    {
        private RecipesViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDishImageCommand"/> class.
        /// </summary>
        /// <param name="vm">Recipe view model.</param>
        public ChangeDishImageCommand(RecipesViewModel vm)
        {
            this.viewModel = vm;
        }

        /// <summary>
        /// Just an event.
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Checks whether you can execute the command.
        /// </summary>
        /// <param name="parameter">A parameter.</param>
        /// <returns>Returns bool.</returns>
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Optional parameter.</param>
        public void Execute(object? parameter)
        {
            this.viewModel.ExecuteChangeDishImageCommand();
        }
    }
}
