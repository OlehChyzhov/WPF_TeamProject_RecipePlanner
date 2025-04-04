﻿// <copyright file="UpdateAccountCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.AccountCommands
{
    using System;
    using System.Windows.Input;

    public class UpdateAccountCommand : ICommand
    {
        private AccountViewModel VM;
        public UpdateAccountCommand(AccountViewModel vm)
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
            VM.ChangeAccount();
        }
    }
}
