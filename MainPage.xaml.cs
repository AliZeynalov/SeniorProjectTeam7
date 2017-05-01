using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Team7Senior
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PoseMatching_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new PoseMatchingPage());
        }

        private void Features_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SaveMotion());
        }
    }
}
