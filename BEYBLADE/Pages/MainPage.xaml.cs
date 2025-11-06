using System.Windows;
using System.Windows.Controls;
using BEYBLADE.Data;
using BEYBLADE.Models;

namespace BEYBLADE.Pages
{
    public partial class MainPage : Page
    {
        private readonly Frame _nav;

        public MainPage(Frame nav)
        {
            InitializeComponent();
            _nav = nav;
            MostrarPanel(panelAdd); // Por defecto: Añadir
        }

        /* ===== Navegación de paneles + descripción ===== */
        private void MostrarPanel(StackPanel panel)
        {
            panelAdd.Visibility = panel == panelAdd ? Visibility.Visible : Visibility.Collapsed;
            panelSearch.Visibility = panel == panelSearch ? Visibility.Visible : Visibility.Collapsed;
            panelDelete.Visibility = panel == panelDelete ? Visibility.Visible : Visibility.Collapsed;

            // tarjetas de tipos: visibles solo en "Añadir"
            infoTipos.Visibility = panel == panelAdd ? Visibility.Visible : Visibility.Collapsed;

            txtSearchResultado.Text = "";

            if (panel == panelAdd)
                txtHint.Text = "Añade una peonza con su nombre y tipo. En Beyblade hay peonzas de Ataque (golpes potentes, menor aguante), Resistencia (giran más tiempo) y Equilibrio (mezcla de ambas).";
            else if (panel == panelSearch)
                txtHint.Text = "Busca una peonza por su nombre exacto para comprobar si está registrada.";
            else
                txtHint.Text = "Elimina una peonza escribiendo su nombre exacto. Úsalo con cuidado.";
        }

        private void ShowAdd_Click(object sender, RoutedEventArgs e) => MostrarPanel(panelAdd);
        private void ShowSearch_Click(object sender, RoutedEventArgs e) => MostrarPanel(panelSearch);
        private void ShowDelete_Click(object sender, RoutedEventArgs e) => MostrarPanel(panelDelete);

        /* ===== Añadir ===== */
        private void AddGuardar_Click(object sender, RoutedEventArgs e)
        {
            var nombre = txtAddNombre.Text.Trim();
            var tipo = (cbAddTipo.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";

            try
            {
                PeonzaRepo.Add(new Peonza { Nombre = nombre, Tipo = tipo });
                MessageBox.Show("Peonza guardada.");
                txtAddNombre.Text = "";
                cbAddTipo.SelectedIndex = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /* ===== Buscar ===== */
        private void SearchBuscar_Click(object sender, RoutedEventArgs e)
        {
            var nombre = txtSearchNombre.Text.Trim();
            var p = PeonzaRepo.Find(nombre);
            txtSearchResultado.Text = p == null ? "No encontrada." : $"Encontrada: {p}";
        }

        /* ===== Borrar ===== */
        private void DeleteBorrar_Click(object sender, RoutedEventArgs e)
        {
            var nombre = txtDeleteNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Escribe un nombre.");
                return;
            }

            if (PeonzaRepo.Delete(nombre))
            {
                MessageBox.Show("Peonza borrada.");
                txtDeleteNombre.Text = "";
            }
            else
            {
                MessageBox.Show("No existe esa peonza.");
            }
        }

        /* ===== Salir al Login ===== */
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            _nav.Content = new LoginPage(_nav);
        }
    }
}
