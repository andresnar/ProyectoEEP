using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEnergia
{
    class Usuario
    {
        public int cedula;
        public string nombre;
        public string apellidos;
        public string direccion;
        public string barrio;
        public int estrato;
        public string telefono;
        public string celular;
        public string email;
        public string observaciones;
        public bool propietario;
        public int ciudad;
        public int departamento;

        public Usuario()
        {
        }

        public int MyProperty { get; set; }
    }
}
