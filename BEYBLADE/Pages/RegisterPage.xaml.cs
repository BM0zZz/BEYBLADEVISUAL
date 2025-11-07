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

        // Botón: Crear cuenta
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var nick = (txtNick.Text ?? "").Trim();
            var email = (txtMail.Text ?? "").Trim();
            var pass = txtPass.Password;
            var passConf = txtConfirm.Password;

            if (string.IsNullOrWhiteSpace(nick))
            {
                MessageBox.Show("Introduce un nick válido.");
                txtNick.Focus();
                return;
            }

            // Validación simple de email
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || email.StartsWith("@") || email.EndsWith("@"))
            {
                MessageBox.Show("Introduce un correo válido (debe contener @).");
                txtMail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(pass) || pass.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.");
                txtPass.Focus();
                return;
            }

            if (pass != passConf)
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

            // ---- REGISTRO OK ----
            MessageBox.Show($"Te has registrado correctamente, {nick}! 🎉");

            // IR DIRECTO AL LOGIN
            _nav.Content = new LoginPage(_nav);
        }

        // Botón: Iniciar sesión (volver al login)
        private void GoLogin_Click(object sender, RoutedEventArgs e)
        {
            _nav.Content = new LoginPage(_nav);
        }

        // Botón: Limpiar campos
        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            txtNick.Text = "";
            txtMail.Text = "";
            txtPass.Password = "";
            txtConfirm.Password = "";
            chkTerms.IsChecked = false;
            txtNick.Focus();
        }
    }
}
