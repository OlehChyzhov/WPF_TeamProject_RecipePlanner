// <copyright file="ChangeImageCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.AccountCommands
{
    using System;
    using System.Windows.Input;

    public class ChangeImageCommand : ICommand
    {
        private AccountViewModel VM;
        public ChangeImageCommand(AccountViewModel vm)
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
            VM.ChangeImage();
        }
    }
}
