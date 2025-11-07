using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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

            
            if (_nav != null)
                _nav.Content = new MainPage(_nav, nick);  // usa el Frame existente
            else
                NavigationService?.Navigate(new MainPage(nick));  // navegación directa
        }

        private void GoRegister_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null)
                _nav.Content = new RegisterPage(_nav);
            else
                NavigationService?.Navigate(new RegisterPage());
        }
    }
}
