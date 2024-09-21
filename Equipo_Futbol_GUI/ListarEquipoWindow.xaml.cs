using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Equipo_Futbol_GUI
{
    /// <summary>
    /// Lógica de interacción para ListarEquipoWindow.xaml
    /// </summary>
    public partial class ListarEquipoWindow : Window
    {
        Equipo_Futbol_Negocio.EquipoCollection equipoCollection;

        public ListarEquipoWindow()
        {
            InitializeComponent();
            CargarEquipos(); // Llama al método para cargar los equipos guardados
        }

        private void CargarEquipos()
        {
            // Asignar la lista de equipos guardados al DataGrid
            equipoCollection = new Equipo_Futbol_Negocio.EquipoCollection();
            dataGridEquipos.ItemsSource = equipoCollection.ReadAll(); // Asignar la lista actual de equipos
        }

        // Método para manejar la eliminación de un equipo
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            // Eliminar el equipo de la lista estática
            EliminarRegistroSeleccionado();
        }

        // Método para manejar la actualización de un equipo
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            var filaSeleccionada = (Equipo_Futbol_Negocio.Equipo)dataGridEquipos.SelectedItem;
            if (filaSeleccionada != null)
            {
                // Crear una nueva instancia de la ventana de actualización y mostrarla
                ActualizarEquipoWindow actualizarEquipo = new ActualizarEquipoWindow(filaSeleccionada.EquipoId);
                actualizarEquipo.ShowDialog(); // Usamos ShowDialog en lugar de NavigationService
                actualizarEquipo.Owner = this; // Establece la ventana principal como ventana padre

                CargarEquipos(); // Recargar la lista después de la actualización
            }
            else
            {
                MessageBox.Show("Selecciona un equipo para actualizar.");
            }
        }

        private void EliminarRegistroSeleccionado()
        {
            var filaSeleccionada = (Equipo_Futbol_Negocio.Equipo)dataGridEquipos.SelectedItem;
            if (filaSeleccionada != null)
            {
                int equipoId = filaSeleccionada.EquipoId;
                string title = "Eliminar Equipo";
                string message = $"¿Estás seguro de que quieres eliminar el equipo con ID {equipoId}?";

                MessageBoxButton buttons = MessageBoxButton.YesNo;
                MessageBoxResult result = MessageBox.Show(message, title, buttons);
                if (result == MessageBoxResult.Yes)
                {
                    var res = filaSeleccionada.Delete(equipoId)
                        ? MessageBox.Show($"Equipo con ID {equipoId} eliminado correctamente.")
                        : MessageBox.Show("El equipo no pudo ser eliminado.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un equipo para eliminar.");
            }
        }
    }
}