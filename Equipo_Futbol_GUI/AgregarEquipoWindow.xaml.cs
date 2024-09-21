using Equipo_Futbol_Negocio;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Equipo_Futbol_GUI
{
    public partial class AgregarEquipoWindow : Window
    {
        public Equipo_Futbol_Negocio.Equipo Equipo { get; set; }

        public AgregarEquipoWindow()
        {
            InitializeComponent();

            // Inicializamos el objeto Equipo y lo asignamos como DataContext
            Equipo = new Equipo_Futbol_Negocio.Equipo();
            this.DataContext = Equipo;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Llamar al método Create para agregar el equipo
                bool response = Equipo.Create();

                if (response)
                {
                    MessageBox.Show("El equipo se agregó correctamente.");
                    AgregarOtroEquipo();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al agregar el equipo.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AgregarOtroEquipo()
        {
            // Preguntar si se desea agregar otro equipo
            string title = "Agregar Nuevo Equipo";
            string message = "¿Deseas agregar otro equipo?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, buttons);

            if (result == MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void LimpiarCampos()
        {
            txtNombreEquipo.Text = string.Empty;
            txtCantidadJugadores.Text = string.Empty;
            txtNombreDt.Text = string.Empty;
            txtTipoEquipo.Text = string.Empty;
            txtCapitanEquipo.Text = string.Empty;
            chkTieneSub21.IsChecked = false;
        }

        private void AbrirListarEquipoWindow()
        {
            // Cerrar la ventana actual y abrir la ventana de listar equipos
            this.Close();
            ListarEquipoWindow listarEquipoWindow = new ListarEquipoWindow();
            listarEquipoWindow.Show();
        }

        private void txtCantidadJugadores_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Convertir el texto del TextBox a un entero
            if (int.TryParse(txtCantidadJugadores.Text, out int cantidad))
            {
                Equipo.CantidadJugadores = cantidad;
            }
            else
            {
                // Si la conversión falla, se puede manejar el error aquí si es necesario
                Equipo.CantidadJugadores = 0; // O establecer un valor predeterminado
            }
        }
    }
}
