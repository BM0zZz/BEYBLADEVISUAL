using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BEYBLADE.Data;
using BEYBLADE.Models;

namespace BEYBLADE.Pages
{
    public partial class SearchBeyPage : Page
    {
        private readonly Frame _nav;

        public SearchBeyPage(Frame nav)
        {
            InitializeComponent();
            _nav = nav;
            CargarLista("");
        }

        public SearchBeyPage() : this(null) { }

        private void CargarLista(string filtro)
        {
            var q = (filtro ?? "").ToLower();
            var data = string.IsNullOrWhiteSpace(q)
                ? BeyRepo.Items
                : BeyRepo.Items.Where(b => (b.Name ?? "").ToLower().Contains(q)).ToList();

            lstResultados.ItemsSource = data;
            lblCount.Text = data.Count == 1 ? "1 resultado" : $"{data.Count} resultados";

            // auto seleccionar si exact match
            var exact = data.FirstOrDefault(b => (b.Name ?? "").ToLower() == q);
            if (exact != null)
            {
                lstResultados.SelectedItem = exact;
                lstResultados.ScrollIntoView(exact);
            }
        }

        private void Filtro_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarLista(txtFiltro.Text);
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new MainPage(_nav);
            else NavigationService?.Navigate(new MainPage());
        }
    }
}
