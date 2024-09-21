using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Futbol_Negocio
{
    public interface IPersistente
    {
        bool Create();
        bool Read(int equipoId);
        bool Update();
        bool Delete(int equipoId);
    }
}
