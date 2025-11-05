using System.Windows;

namespace BEYBLADE
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RootFrame.Content = new Pages.LoginPage(RootFrame);
        }
    }
}
