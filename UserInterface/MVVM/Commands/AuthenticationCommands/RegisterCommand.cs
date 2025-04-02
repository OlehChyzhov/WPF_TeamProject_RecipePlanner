// <copyright file="RegisterCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM.Commands.AuthenticationCommands
{
    using DataAccess;
    using System.Windows.Input;

    public class RegisterCommand : ICommand
    {
        private LoginViewModel VM;
        public RegisterCommand(LoginViewModel vm)
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
            bool isValid = false;
            if (DbHelper.db.Accounts.FirstOrDefault(acc => acc.Email == VM.Email) == null)
            {
                isValid = true;
            }
            return isValid;
        }

        public void Execute(object? parameter)
        {
            VM.ExecuteRegisterCommand();
        }
    }
}
