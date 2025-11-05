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

            MessageBox.Show($"Login OK: {nick}");
            // Siguiente: _nav.Navigate(new HomePage(_nav, repo, nick));
        }

        private void GoRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Abriremos la pantalla de registro en el siguiente paso.");
            // Siguiente: _nav.Navigate(new RegisterPage(_nav, repo));
        }
    }
}
