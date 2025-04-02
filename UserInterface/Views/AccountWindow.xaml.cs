using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Views
{
    public partial class AccountWindow : Page
    {
        public AccountWindow()
        {
            InitializeComponent();
        }

        private void EditCommand_Click(object sender, RoutedEventArgs e)
        {
            App.RightSideFrame.Navigate(App.MySettingsWindow);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            App.MyLoginWindow = new LoginWindow();
            App.MyLoginWindow.Show();

            App.MyMainWindow.Close();
        }
    }
}
