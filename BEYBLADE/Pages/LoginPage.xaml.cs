// Pages/LoginPage.xaml.cs
using System.Windows;
using System.Windows.Controls;

namespace BEYBLADE.Pages
{
    public partial class LoginPage : Page
    {
        private readonly Frame _nav;

        public LoginPage(Frame nav)
        {
            InitializeComponent();
            _nav = nav;
        }

        // ctor sin parámetros
        public LoginPage() : this(null) { }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var nick = txtNick.Text.Trim();
            var pass = txtPass.Password;

            if (string.IsNullOrWhiteSpace(nick))
            {
                MessageBox.Show("Introduce tu nick.");
                txtNick.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Introduce tu contraseña.");
                txtPass.Focus();
                return;
            }

            if (_nav != null) _nav.Content = new MainPage(_nav);
            else NavigationService?.Navigate(new MainPage());
        }

        private void GoRegister_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new RegisterPage(_nav);
            else NavigationService?.Navigate(new RegisterPage());
        }
    }
}
