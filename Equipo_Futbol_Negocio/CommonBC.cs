using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Futbol_Negocio
{
    public class CommonBC
    {
        private static Equipo_futbol_Data.PCEEntities1 _modeloEquipo;

        public static Equipo_futbol_Data.PCEEntities1 ModeloEquipo
        {
            get
            {
                if(_modeloEquipo == null )
                {
                    _modeloEquipo = new Equipo_futbol_Data.PCEEntities1();
                }
                return _modeloEquipo ;
            }
        }
    }
}
