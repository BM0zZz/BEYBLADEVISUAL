using System.Windows;
using System.Windows.Controls;

namespace BEYBLADE.Pages
{
    public partial class RegisterPage : Page
    {
        private readonly Frame _nav;

        public RegisterPage(Frame nav)
        {
            InitializeComponent();
            _nav = nav;
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var nick = txtNick.Text.Trim();
            var mail = txtMail.Text.Trim();
            var pass = txtPass.Password;
            var confirm = txtConfirm.Password;

            if (string.IsNullOrWhiteSpace(nick))
            {
                MessageBox.Show("Introduce tu nick de entrenador.");
                txtNick.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(mail) || !mail.Contains("@"))
            {
                MessageBox.Show("Introduce un correo válido (debe contener @).");
                txtMail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Introduce una contraseña.");
                txtPass.Focus();
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                txtConfirm.Focus();
                return;
            }

            if (chkTerms.IsChecked != true)
            {
                MessageBox.Show("Debes aceptar los términos y condiciones.");
                chkTerms.Focus();
                return;
            }

            // TODO: Guardar el usuario (lista/BD/archivo). De momento solo avisamos:
            MessageBox.Show($"¡Cuenta creada para {nick}! 💥");

            // Volver al login tras crear
            _nav.Content = new LoginPage(_nav);
        }

        private void GoLogin_Click(object sender, RoutedEventArgs e)
        {
            _nav.Content = new LoginPage(_nav);
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            txtNick.Text = string.Empty;
            txtMail.Text = string.Empty;
            txtPass.Password = string.Empty;
            txtConfirm.Password = string.Empty;
            chkTerms.IsChecked = false;
            txtNick.Focus();
        }
    }
}
