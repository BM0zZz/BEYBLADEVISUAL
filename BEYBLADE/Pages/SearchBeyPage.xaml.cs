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

    
        public SearchBeyPage(Frame nav = null)
        {
            InitializeComponent();
            _nav = nav;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refrescar("");
        }

        private void Refrescar(string filtro)
        {
            var q = (filtro ?? "").ToLower();
            var data = string.IsNullOrEmpty(q)
                ? BeyRepo.Items
                : BeyRepo.Items.Where(b => (b.Name ?? "").ToLower().Contains(q)).ToList();

            lstResultados.ItemsSource = data;
            lblCount.Text = data.Count + " resultado(s)";
        }

        private void Filtro_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refrescar(txtFiltro.Text);
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new MainPage(_nav);
            else NavigationService?.Navigate(new MainPage());
        }
    }
}
