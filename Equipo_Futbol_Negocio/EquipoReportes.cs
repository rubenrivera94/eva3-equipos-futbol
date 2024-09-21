using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Futbol_Negocio
{
    public class EquipoReportes
    {
        // Método para obtener la cantidad de equipos femeninos
        public int ReporteCantidadEquiposFemeninos()
        {
            // Convierte el resultado del procedimiento almacenado a un entero
            return Convert.ToInt32(CommonBC.ModeloEquipo.spObtenerCantidadEquiposFemeninos().First().Value);
        }

        // Método para obtener la cantidad de equipos masculinos
        public int ReporteCantidadEquiposMasculinos()
        {
            // Convierte el resultado del procedimiento almacenado a un entero
            return Convert.ToInt32(CommonBC.ModeloEquipo.spObtenerCantidadEquiposMasculinos().First().Value);
        }
    }
}