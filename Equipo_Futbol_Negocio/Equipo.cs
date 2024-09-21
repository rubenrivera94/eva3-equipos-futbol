using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;


namespace Equipo_Futbol_Negocio
{
    public class Equipo : ObservableObject, IPersistente //implementacion de la clase ObservableObject
    {
        // Propiedades
        public int EquipoId { get; set; }

        private string _nombreEquipo;
        private int _cantidadJugadores;
        private string _nombreDt;
        private string _tipoEquipo;
        private string _capitanEquipo;
        private bool _tieneSub21;

        //Validacion propiedad NombreEquipo
        [Required(ErrorMessage = "El Nombre del Equipo es obligatorio.")]
        [MinLength(8, ErrorMessage = "Minimo 8 caracteres")]
        [MaxLength(25, ErrorMessage = "Maximo 25 caracteres")]
        public string NombreEquipo
        {
            get { return _nombreEquipo; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _nombreEquipo, value);
            }
        }

        //Validacion propiedad CantidadJugadores
        [Range(16, 25, ErrorMessage = "La cantidad de jugadores debe estar entre 16 y 25.")]
        public int CantidadJugadores
        {
            get { return _cantidadJugadores; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _cantidadJugadores, value);
            }
        }

        //Validacion propiedad NombreDt
        [Required(ErrorMessage = "El Nombre del DT es obligatorio.")]
        [MinLength(5, ErrorMessage = "minimo 5 caracteres")]
        [MaxLength(30, ErrorMessage = "maximo 30 caracteres")]
        public string NombreDt
        {
            get { return _nombreDt; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _nombreDt, value);
            }
        }

        //Validacion propiedad TipoEquipo
        [Required(ErrorMessage = "El Tipo de Equipo es obligatorio, debe ser Masculino o Femenino. ")]
        public string TipoEquipo
        {
            get { return _tipoEquipo; }
            set
            {
               ValidateProperty(value);
                OnPropertyChanged(ref _tipoEquipo, value);
            }
        }

        //Validacion propiedad CapitanEquipo
        [Required(ErrorMessage = "El Nombre del Capitán es obligatorio.")]
        [MinLength(5, ErrorMessage = "minimo 5 caracteres")]
        [MaxLength(30, ErrorMessage = "maximo 30 caracteres")]
        public string CapitanEquipo
        {
            get { return _capitanEquipo; }
            set
            {
                ValidateProperty(value);
                OnPropertyChanged(ref _capitanEquipo, value);
            }
        }


        public bool TieneSub21
        {
            get { return _tieneSub21; }
            set
            {
                OnPropertyChanged(ref _tieneSub21, value);
            }
        }


        private void ValidateProperty<T>(T value, [CallerMemberName] string name = "")
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name,
            });
        }


        // Método para crear un equipo (con encriptación)
        public bool Create()
        {
            try
            {
                // Encriptar propiedades sensibles antes de guardarlas
                NombreEquipo = AES_Helper.EncryptString(NombreEquipo);
                NombreDt = AES_Helper.EncryptString(NombreDt);
                TipoEquipo = AES_Helper.EncryptString(TipoEquipo);
                CapitanEquipo = AES_Helper.EncryptString(CapitanEquipo);

                // Lógica para guardar el equipo
                CommonBC.ModeloEquipo.spEquipoSave(
                    NombreEquipo,
                    CantidadJugadores,
                    NombreDt,
                    TipoEquipo,
                    CapitanEquipo,
                    TieneSub21
                );
                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el equipo: {ex.Message}");
                return false;
            }
        }

        // Método para actualizar un equipo (con encriptación)
        public bool Update()
        {
            try
            {
                // Encriptar propiedades sensibles antes de actualizarlas
                NombreEquipo = AES_Helper.EncryptString(NombreEquipo);
                NombreDt = AES_Helper.EncryptString(NombreDt);
                TipoEquipo = AES_Helper.EncryptString(TipoEquipo);
                CapitanEquipo = AES_Helper.EncryptString(CapitanEquipo);

                // Actualizar el equipo
                CommonBC.ModeloEquipo.spEquipoUpdateById(
                    EquipoId,
                    NombreEquipo,
                    CantidadJugadores,
                    NombreDt,
                    TipoEquipo,
                    CapitanEquipo,
                    TieneSub21
                );
                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Read(int equipoId)
        {
            try
            {
                // Obtener el equipo desde la base de datos usando el equipoId
                Equipo_futbol_Data.vw_Equipos equipo = CommonBC.ModeloEquipo.vw_Equipos.First(e => e.EquipoId == equipoId);

                // Asignar propiedades desencriptadas a las propiedades de la clase
                this.EquipoId = equipo.EquipoId;
                this.NombreEquipo = AES_Helper.DecryptString(equipo.NombreEquipo); // Desencriptar
                this.CantidadJugadores = equipo.CantidadJugadores;
                this.NombreDt = AES_Helper.DecryptString(equipo.NombreDt); // Desencriptar
                this.TipoEquipo = AES_Helper.DecryptString(equipo.TipoEquipo); // Desencriptar
                this.CapitanEquipo = AES_Helper.DecryptString(equipo.CapitanEquipo); // Desencriptar
                this.TieneSub21 = equipo.TieneSub21;

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                return false;
            }
        }


        public bool Delete(int equipoId)
        {
            try
            {
                // Llama al procedimiento almacenado para eliminar el equipo por su ID
                CommonBC.ModeloEquipo.spEquipoDeleteById(equipoId);
                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return false;
            }
        }

    }

}
