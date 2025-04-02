// <copyright file="ResetZoomingModeCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.StatisticsCommands
{
    using System;
    using System.Windows.Input;

    public class ResetZoomingModeCommand : ICommand
    {
        private StatisticsViewModel VM;

        public ResetZoomingModeCommand(StatisticsViewModel vm)
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
            VM.ExecuteResetZoomCommand();
        }
    }
}
