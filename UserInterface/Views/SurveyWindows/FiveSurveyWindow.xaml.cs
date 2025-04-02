using BusinessLogic;
using DataAccess;
using DataAccess.Models;
using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Views
{
    /// <summary>
    /// Interaction logic for FiveSurveyWindow.xaml
    /// </summary>
    public partial class FiveSurveyWindow : Page
    {
        public FiveSurveyWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DietCreator.Height = int.Parse(HeightTextBox.Text);
                DietCreator.CurrentWeight = int.Parse(CurrentWeightTextBox.Text);
                DietCreator.DesiredWeight = int.Parse(DesiredWeightTextBox.Text);

                int calories = (int)DietCreator.CalculateCalories();
                App.SurviesFrame.Navigate(App.SurveyWindow_6);
                App.SurveyWindow_6.CaloriesTextBlock.Text = calories.ToString();


                AccountInfo info = new AccountInfo()
                {
                    AccountEmail = AccountManager.LoginedAccount.Email,
                    Age = DietCreator.Age,
                    DailyCalories = calories,
                    DesiredWeight = DietCreator.DesiredWeight,
                    Goal = DietCreator.WeightGoal,
                    Height = DietCreator.Height,
                    Sex = DietCreator.Gender,
                    Weight = DietCreator.CurrentWeight,
                };
                DbHelper.db.AccountInformations.Add(info);
                DbHelper.db.SaveChanges();
            }
            catch { MessageBox.Show("Enter valid values", "Errors", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
