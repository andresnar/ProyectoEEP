using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEnergia
{
    class CensoDTO
    {
        public int idCenso;
        public string fecha;
        public string hora;
        public int cedula;

        public CensoDTO()
        {
        }

        public int MyProperty { get; set; }
    }
}
