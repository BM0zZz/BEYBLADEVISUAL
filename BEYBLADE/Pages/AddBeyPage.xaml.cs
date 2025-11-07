// Pages/AddBeyPage.xaml.cs
using System.Windows;
using System.Windows.Controls;
using BEYBLADE.Data;
using BEYBLADE.Models;

namespace BEYBLADE.Pages
{
    public partial class AddBeyPage : Page
    {
        private readonly Frame _nav;

        public AddBeyPage(Frame nav)
        {
            InitializeComponent();
            _nav = nav;
        }

        // ctor sin parámetros (para NavigationService)
        public AddBeyPage() : this(null) { }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string name = txtNombre.Text.Trim();
            string type = (cmbTipo.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Escribe un nombre.");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Elige un tipo.");
                cmbTipo.Focus();
                return;
            }

            if (BeyRepo.Find(name) != null)
            {
                MessageBox.Show("Ya existe una peonza con ese nombre.");
                return;
            }

            BeyRepo.Add(new Beyblade { Name = name, Type = type });
            MessageBox.Show("Peonza guardada correctamente.");

            txtNombre.Text = "";
            cmbTipo.SelectedIndex = -1;
            txtNombre.Focus();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new MainPage(_nav);
            else NavigationService?.Navigate(new MainPage());
        }
    }
}
