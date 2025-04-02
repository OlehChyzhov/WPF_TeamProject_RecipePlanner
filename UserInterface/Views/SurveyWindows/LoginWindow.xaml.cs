using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UserInterface.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            App.SurviesFrame = SurviesFrame;
            App.SurviesFrame.Navigate(App.SurveyWindow_1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BeginStoryboard((Storyboard)this.Resources["NewHereStoryBoard"]);
            BeginStoryboard((Storyboard)this.Resources["MainTextStoryboard"]);
        }
    }
}
