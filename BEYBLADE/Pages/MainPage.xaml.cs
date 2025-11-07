
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using BEYBLADE.Data;
using BEYBLADE.Models;

namespace BEYBLADE.Pages
{
    public partial class MainPage : Page
    {
        private readonly Frame _nav;
        private readonly string _trainer;

       
        public MainPage(Frame nav, string trainer = null)
        {
            InitializeComponent();
            _nav = nav;
            _trainer = trainer;
            SetTitleOnLoaded();
        }

        
        public MainPage(string trainer)
        {
            InitializeComponent();
            _trainer = trainer;
            SetTitleOnLoaded();
        }

      
        public MainPage() : this((string)null) { }

        private void SetTitleOnLoaded()
        {
           
            Loaded += (s, e) =>
            {
                var nombre = string.IsNullOrWhiteSpace(_trainer) ? "Entrenador" : _trainer;
                if (lblTitulo != null)
                    lblTitulo.Text = $"Centro de Entrenamiento de {nombre}";
            };
        }

        // --- Navegación a páginas dedicadas ---
        private void ShowAdd_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new AddBeyPage(_nav);
            else NavigationService?.Navigate(new AddBeyPage());
        }

        private void ShowSearch_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new SearchBeyPage(_nav);
            else NavigationService?.Navigate(new SearchBeyPage());
        }

        private void ShowDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new DeleteBeyPage(_nav);
            else NavigationService?.Navigate(new DeleteBeyPage());
        }

        // --- Botón salir (parte inferior) ---
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (_nav != null) _nav.Content = new LoginPage(_nav);
            else NavigationService?.Navigate(new LoginPage());
        }

      

        // Guardar desde el mini-formulario oculto
        private void Add_Save_Click(object sender, RoutedEventArgs e)
        {
            var name = (txtAddName?.Text ?? "").Trim();
            var type = (cmbAddType?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Escribe un nombre.");
                txtAddName?.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Elige un tipo.");
                cmbAddType?.Focus();
                return;
            }
            if (BeyRepo.Find(name) != null)
            {
                MessageBox.Show("Ya existe una peonza con ese nombre.");
                return;
            }

            BeyRepo.Add(new Beyblade { Name = name, Type = type });
            MessageBox.Show("Peonza guardada correctamente.");
        }

        // Limpiar del mini-formulario
        private void Add_Clear_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddName != null) txtAddName.Text = "";
            if (cmbAddType != null) cmbAddType.SelectedIndex = -1;
            txtAddName?.Focus();
        }

        // Buscar desde el panel oculto
        private void DoSearch_Click(object sender, RoutedEventArgs e)
        {
            var q = (txtSearchQuery?.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(q))
            {
                if (txtSearchResultado != null) txtSearchResultado.Text = "Escribe un nombre para buscar.";
                return;
            }

            var b = BeyRepo.Find(q);
            if (txtSearchResultado != null)
            {
                txtSearchResultado.Text = b == null
                    ? "No se encontró ninguna peonza con ese nombre."
                    : $"Encontrada:\n• Nombre: {b.Name}\n• Tipo: {b.Type}";
            }
        }

        // Borrar desde el panel oculto
        private void DoDelete_Click(object sender, RoutedEventArgs e)
        {
            var q = (txtDeleteName?.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(q))
            {
                MessageBox.Show("Escribe el nombre a borrar.");
                txtDeleteName?.Focus();
                return;
            }

            if (BeyRepo.Find(q) == null)
            {
                MessageBox.Show("No existe una peonza con ese nombre.");
                return;
            }

            if (MessageBox.Show($"¿Seguro que deseas borrar \"{q}\"?",
                                "Confirmar borrado",
                                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                BeyRepo.Remove(q);
                MessageBox.Show("Borrado correcto.");
            }
        }
    }
}
