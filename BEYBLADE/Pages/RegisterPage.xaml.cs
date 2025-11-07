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

        // ✅ Constructor vacío para permitir: new RegisterPage()
        public RegisterPage() : this(null) { }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            var nick = (txtNick.Text ?? "").Trim();
            var email = (txtMail.Text ?? "").Trim();
            var pass = txtPass.Password;
            var passConf = txtConfirm.Password;

            if (string.IsNullOrWhiteSpace(nick))
            { MessageBox.Show("Introduce un nick válido."); txtNick.Focus(); return; }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || email.StartsWith("@") || email.EndsWith("@"))
            { MessageBox.Show("Introduce un correo válido (debe contener @)."); txtMail.Focus(); return; }

            if (string.IsNullOrWhiteSpace(pass) || pass.Length < 4)
            { MessageBox.Show("La contraseña debe tener al menos 4 caracteres."); txtPass.Focus(); return; }

            if (pass != passConf)
            { MessageBox.Show("Las contraseñas no coinciden."); txtConfirm.Focus(); return; }

            if (chkTerms.IsChecked != true)
            { MessageBox.Show("Debes aceptar los términos y condiciones."); chkTerms.Focus(); return; }

            MessageBox.Show($"Te has registrado correctamente, {nick}! 🎉");

            // Volver al login
            if (_nav != null) _nav.Content = new LoginPage(_nav);
            else NavigationService?.Navigate(new LoginPage());
        }

        private void GoLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new LoginPage(_nav);
            else NavigationService?.Navigate(new LoginPage());
        }

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
