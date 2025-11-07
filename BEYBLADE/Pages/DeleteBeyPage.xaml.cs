// Pages/DeleteBeyPage.xaml.cs
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BEYBLADE.Data;
using BEYBLADE.Models;

namespace BEYBLADE.Pages
{
    public partial class DeleteBeyPage : Page
    {
        private readonly Frame _nav;

        public DeleteBeyPage(Frame nav)
        {
            InitializeComponent();
            _nav = nav;
            CargarLista("");
        }

        // ctor sin parámetros
        public DeleteBeyPage() : this(null) { }

        private void CargarLista(string filtro)
        {
            var q = (filtro ?? "").ToLower();
            var data = string.IsNullOrEmpty(q)
                ? BeyRepo.Items
                : BeyRepo.Items.Where(b => (b.Name ?? "").ToLower().Contains(q)).ToList();

            lstResultados.ItemsSource = data;
        }

        private void Filtro_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarLista(txtFiltro.Text);
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            var sel = lstResultados.SelectedItem as Beyblade;
            if (sel == null)
            {
                MessageBox.Show("Selecciona una peonza de la lista.");
                return;
            }

            if (MessageBox.Show($"¿Seguro que deseas borrar \"{sel.Name}\"?",
                                "Confirmar borrado", MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (BeyRepo.Remove(sel.Name))
                {
                    // refrescar lista y limpiar selección
                    CargarLista(txtFiltro.Text);
                    lstResultados.SelectedIndex = -1;
                    lstResultados.Items.Refresh();
                }
            }
        }


        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new MainPage(_nav);
            else NavigationService?.Navigate(new MainPage());
        }
    }
}
