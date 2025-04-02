// <copyright file="AccountViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UserInterface.MVVM
{
    using System.IO;
    using System.Windows;
    using System.Windows.Media;
    using BusinessLogic;
    using DataAccess;
    using DataAccess.Models;
    using LiveCharts;
    using LiveCharts.Defaults;
    using LiveCharts.Wpf;
    using Microsoft.Win32;
    using UserInterface.MVVM.Commands.AccountCommands;

    /// <summary>
    /// Used in Account page and Setting page as a binding source.
    /// </summary>
    public class AccountViewModel : BaseViewModel
    {
        private LogWriter logWriter = new LogWriter("../../../Logs/account.log");

        private SeriesCollection series = new SeriesCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountViewModel"/> class.
        /// </summary>
        public AccountViewModel()
        {
            this.UpdateAccountCommand = new UpdateAccountCommand(this);
            this.UpdateAccountInfoCommand = new UpdateAccountInfoCommand(this);
            this.ChangeImageCommand = new ChangeImageCommand(this);

            this.XFormatter = (val) =>
            {
                try
                {
                    DateTime dateTime = new DateTime((long)val);
                    return DateOnly.FromDateTime(dateTime).ToString();
                }
                catch
                {
                    return "None";
                }
            };
            this.YFormatter = (val) =>
            {
                try
                {
                    return $"{val} kg";
                }
                catch
                {
                    return "None";
                }
            };

            this.DisplayStatistics();
        }

        /// <summary>
        /// Gets or sets dates as X-axis values.
        /// </summary>
        public Func<double, string> XFormatter { get; set; }

        /// <summary>
        /// Gets or sets kilograms as Y-axis values.
        /// </summary>
        public Func<double, string> YFormatter { get; set; }

        /// <summary>
        /// Gets or sets user email. Provides binding ability.
        /// </summary>
        public string Email
        {
            get => AccountManager.LoginedAccount.Email;
            set
            {
                AccountManager.LoginedAccount.Email = value;
                this.OnPropertyChanged(nameof(this.Email));
            }
        }

        /// <summary>
        /// Gets or sets user password. Provides binding ability.
        /// </summary>
        public string Password
        {
            get => AccountManager.LoginedAccount.Password;
            set
            {
                AccountManager.LoginedAccount.Password = value;
                this.OnPropertyChanged(nameof(this.Password));
            }
        }

        /// <summary>
        /// Gets or sets user age. Provides binding ability.
        /// </summary>
        public int Age
        {
            get => AccountManager.LoginedAccount.AccountInfo.Age;
            set
            {
                AccountManager.LoginedAccount.AccountInfo.Age = value;
                this.OnPropertyChanged(nameof(this.Age));
            }
        }

        /// <summary>
        /// Gets or sets user gender. Provides binding ability.
        /// </summary>
        public Sex Gender
        {
            get => AccountManager.LoginedAccount.AccountInfo.Sex;
            set
            {
                AccountManager.LoginedAccount.AccountInfo.Sex = value;
                this.OnPropertyChanged(nameof(this.Gender));
            }
        }

        /// <summary>
        /// Gets or sets user weight goal. Provides binding ability.
        /// </summary>
        public WeightGoal Goal
        {
            get => AccountManager.LoginedAccount.AccountInfo.Goal;
            set
            {
                AccountManager.LoginedAccount.AccountInfo.Goal = value;
                this.OnPropertyChanged(nameof(this.Goal));
            }
        }

        /// <summary>
        /// Gets or sets user desired weight. Provides binding ability.
        /// </summary>
        public int DesiredWeight
        {
            get => AccountManager.LoginedAccount.AccountInfo.DesiredWeight;
            set
            {
                AccountManager.LoginedAccount.AccountInfo.DesiredWeight = value;
                this.OnPropertyChanged(nameof(this.DesiredWeight));
            }
        }

        /// <summary>
        /// Gets or sets user current weight. Provides binding ability.
        /// </summary>
        public int CurrentWeight
        {
            get => AccountManager.LoginedAccount.AccountInfo.Weight;
            set
            {
                AccountManager.LoginedAccount.AccountInfo.Weight = value;
                this.OnPropertyChanged(nameof(this.CurrentWeight));
            }
        }

        /// <summary>
        /// Gets or sets user height. Provides binding ability.
        /// </summary>
        public int Height
        {
            get => AccountManager.LoginedAccount.AccountInfo.Height;
            set
            {
                AccountManager.LoginedAccount.AccountInfo.Height = value;
                this.OnPropertyChanged(nameof(this.Height));
            }
        }

        /// <summary>
        /// Gets or sets path to the image displayed. Provides binding ability.
        /// </summary>
        public string ImagePath
        {
            get
            {
                if (AccountManager.LoginedAccount.AccountInfo.ImageUrl != null)
                {
                    return AccountManager.LoginedAccount.AccountInfo.ImageUrl;
                }

                return "pack://application:,,,/Images/Accounts/MainPictures/Test.png";
            }

            set
            {
                AccountManager.LoginedAccount.AccountInfo.ImageUrl = value;
                this.OnPropertyChanged(nameof(this.ImagePath));
            }
        }

        /// <summary>
        /// Gets or sets series. Provides binding ability.
        /// </summary>
        public SeriesCollection Series
        {
            get => this.series;
            set
            {
                this.series = value;
                this.OnPropertyChanged(nameof(this.Series));
            }
        }

        /// <summary>
        /// Gets to the database and updates changed properties of the account.
        /// </summary>
        public UpdateAccountCommand UpdateAccountCommand { get; }

        /// <summary>
        /// Gets to the database and updates changed properties of the account information.
        /// </summary>
        public UpdateAccountInfoCommand UpdateAccountInfoCommand { get; }

        /// <summary>
        /// Gets new image and sets account information image path in order to display that later.
        /// </summary>
        public ChangeImageCommand ChangeImageCommand { get; }

        /// <summary>
        /// It shows statistics of all statistic entities of the user.
        /// If 'Series' isn't empty, then clears it.
        /// </summary>
        public void DisplayStatistics()
        {
            ChartValues<DateTimePoint> values = new ChartValues<DateTimePoint>();
            foreach (StatisticEntity entity in AccountManager.LoginedAccount.StatisticEntities!.OrderBy(ent => ent.Date))
            {
                values.Add(new DateTimePoint(entity.Date, entity.Weight));
            }

            LinearGradientBrush brush = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1),
            };
            brush.GradientStops.Add(new GradientStop(Colors.Blue, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            this.Series.Clear();
            try
            {
                this.Series.Add(new LineSeries()
                {
                    Title = "Weights",
                    Values = values,
                    Fill = brush,
                });
                this.logWriter.Write("DisplayStatistics: Series add error");
            }
            catch
            {
            }
        }

        /// <summary>
        /// Updates account if any changes were done.
        /// </summary>
        public void ChangeAccount()
        {
            DbHelper.db.Accounts.Update(AccountManager.LoginedAccount);
            DbHelper.db.SaveChanges();
            MessageBox.Show("Account Updated Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Updates account information if any changes were done.
        /// </summary>
        public void ChangeAccountInfo()
        {
            DbHelper.db.AccountInformations.Update(AccountManager.LoginedAccount.AccountInfo);
            DbHelper.db.SaveChanges();
            MessageBox.Show("Account Updated Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Updates account information image.
        /// </summary>
        public void ChangeImage()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                string destination = $"../../../Images/Accounts/MainPictures/{AccountManager.LoginedAccount.Email}.png";
                File.Copy(openDialog.FileName, destination, true);
                this.ImagePath = $"pack://application:,,,/Images/Accounts/MainPictures/{AccountManager.LoginedAccount.Email}.png";
                this.ChangeAccountInfo();
            }
        }
    }
}
