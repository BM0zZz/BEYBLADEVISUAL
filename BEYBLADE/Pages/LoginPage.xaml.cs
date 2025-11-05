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
            // TODO: aquí navegarás a la página principal cuando la tengamos
            // _nav.Content = new HomePage(_nav, nick);
        }

        private void GoRegister_Click(object sender, RoutedEventArgs e)
        {
            // Navegación real al registro (manteniendo el mismo Frame)
            _nav.Content = new RegisterPage(_nav);
        }
    }
}
