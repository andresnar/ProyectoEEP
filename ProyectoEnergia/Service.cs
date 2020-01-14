using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEnergia
{
    class Service
    {
        public static ArrayList listarCiudades()
        {
            ArrayList ciudades = Repository.listarCiudades();
            return ciudades;
        }

        public static ArrayList listarDeptos()
        {
            ArrayList deptos = Repository.listarDeptos();
            return deptos;
        }

        public static int buscarCiudad(String ciudad)
        {
            int idCiudad = Repository.buscarCiudad(ciudad);
            return idCiudad;
        }

        public static int buscarDepto(String depto)
        {
            int idDepto = Repository.buscarDepto(depto);
            return idDepto;
        }

        public static bool guardar(Usuario usuario, Censo censo)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();
            usuarioDTO.cedula = usuario.cedula;
            usuarioDTO.nombre = usuario.nombre;
            usuarioDTO.apellidos = usuario.apellidos;
            usuarioDTO.direccion = usuario.direccion;
            usuarioDTO.barrio = usuario.barrio;
            usuarioDTO.estrato = usuario.estrato;
            usuarioDTO.telefono = usuario.telefono;
            usuarioDTO.celular = usuario.celular;
            usuarioDTO.email = usuario.email;
            usuarioDTO.observaciones = usuario.observaciones;
            usuarioDTO.propietario = usuario.propietario;
            usuarioDTO.telefono = usuario.telefono;
            usuarioDTO.ciudad = usuario.ciudad;
            usuarioDTO.departamento = usuario.departamento;

            CensoDTO censoDTO = new CensoDTO();
            censoDTO.fecha = censo.fecha;
            censoDTO.hora = censo.hora;
            censoDTO.cedula = censo.cedula;

            bool exitoso = Repository.guardar(usuarioDTO, censoDTO);
            return exitoso;
        }
    }
}
