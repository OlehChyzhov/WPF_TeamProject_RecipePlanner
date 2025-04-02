// <copyright file="LoginViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM
{
    using System.Windows;
    using BusinessLogic;
    using DataAccess;
    using DataAccess.Models;
    using UserInterface.MVVM.Commands.AuthenticationCommands;

    /// <summary>
    /// ViewModel of the login page.
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        private LogWriter logWriter = new LogWriter("../../../Logs/login.log");

        private string email = "oleh.chyzhov@gmail.com";
        private string password = "Oleg2005";
        private string errorMessage = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            this.LoginCommand = new LoginCommand(this);
            this.RegisterCommand = new RegisterCommand(this);
        }

        /// <summary>
        /// Gets or sets email inserted by user. Provides binding ability.
        /// </summary>
        public string Email
        {
            get => this.email;
            set
            {
                this.email = value;
                this.OnPropertyChanged(nameof(this.Email));

                this.LoginCommand.FireEvent();
                this.RegisterCommand.FireEvent();
            }
        }

        /// <summary>
        /// Gets or sets password inserted by user. Provides binding ability.
        /// </summary>
        public string Password
        {
            get => this.password;
            set
            {
                this.password = value;
                this.OnPropertyChanged(nameof(this.Password));

                this.LoginCommand.FireEvent();
                this.RegisterCommand.FireEvent();
            }
        }

        /// <summary>
        /// Gets or sets error message. Provides binding ability.
        /// </summary>
        public string ErrorMessage
        {
            get => this.errorMessage;
            set
            {
                this.errorMessage = value;
                this.OnPropertyChanged(nameof(this.ErrorMessage));
            }
        }

        /// <summary>
        /// Gets login method when binding.
        /// </summary>
        public LoginCommand LoginCommand { get; }

        /// <summary>
        /// Gets register method when binding.
        /// </summary>
        public RegisterCommand RegisterCommand { get; }

        /// <summary>
        /// Populates 'LoginedAccount' in 'AccountManager'. Shows main window.
        /// </summary>
        public void ExecuteLoginCommand()
        {
            AccountManager.LoginedAccount = AccountManager.UpdateLoginedAccount(this.Email);
            try
            {
                App.MyMainWindow = new MainWindow();
                App.MyMainWindow.Show();
                App.MyLoginWindow.Close();
            }
            catch
            {
                this.logWriter.Write("Login Failure: Navigation failed");
            }
        }

        /// <summary>
        /// Registers new user.
        /// </summary>
        public void ExecuteRegisterCommand()
        {
            if (!this.Email.Contains("@gmail."))
            {
                MessageBox.Show("Invalid Email", "Register Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                this.logWriter.Write("Registration Failure: Invalid email");
                return;
            }

            Account registeredAccount = new Account()
            {
                Email = this.Email,
                Password = this.Password,
            };
            try
            {
                DbHelper.db.Accounts.Add(registeredAccount);
                DbHelper.db.SaveChanges();
                AccountManager.LoginedAccount = AccountManager.UpdateLoginedAccount(registeredAccount.Email);

                try
                {
                    App.MyLoginWindow.LoginBorder.Visibility = Visibility.Hidden;
                    App.MyLoginWindow.SurviesBorder.Visibility = Visibility.Visible;
                    App.MyLoginWindow.SurviesFrame.Navigate(App.SurveyWindow_1);
                }
                catch
                {
                    this.logWriter.Write("Registration Failure: Navigation failed");
                }
            }
            catch
            {
                MessageBox.Show("Account already exists", "Register Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                this.logWriter.Write("Registration Failure: Account already exists");
                return;
            }
        }
    }
}
