using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Windows.Forms;

namespace ProyectoEnergia
{
    class Repository
    {
        public static ArrayList listarCiudades()
        {
            ArrayList ciudades = consultar("SELECT ciudad.nombre FROM ciudad");
            if (ciudades != null)
            {
                return ciudades;
            }
            else
            {
                MessageBox.Show("No se encontraron ciudades");
                return null;
            }
                
        }

        public static ArrayList listarDeptos()
        {
            ArrayList deptos = consultar("SELECT departamento.nombre FROM departamento");
            if (deptos != null)
            {
                return deptos;
            }
            else {
                MessageBox.Show("No se encontraron ciudades");
                return null;
            }
                
        }

        public static int buscarCiudad(String ciudad)
        {
            ciudad = ciudad.ToUpper();
            string consulta = ($"SELECT ciudad.idciudad FROM ciudad WHERE ciudad.nombre = '{ciudad}'");
            string idCiudad = consultardato(consulta);
            return Convert.ToInt32(idCiudad);
        }

        public static int buscarDepto(String depto)
        {
            depto = depto.ToUpper();
            string consulta = ($"SELECT departamento.iddepto FROM departamento WHERE departamento.nombre = '{depto}'");
            string idDepto = consultardato(consulta);
            return Convert.ToInt32(idDepto);
        }



        public static bool guardar(UsuarioDTO usuarioDTO, CensoDTO censoDTO)
        {
            // Crea la sentencia SQL para agregar usuario
            string consu = "insert into usuario (cedula,nombre,apellido,direccion,barrio,estrato,telefono,celular,email,observacion,propietario,idciudad,iddepto) VALUES (";
            int cedula = usuarioDTO.cedula;
            consu = consu + Convert.ToString(cedula);
            string nombre = usuarioDTO.nombre;
            consu = consu + ",'" + nombre + "'";
            string apellidos = usuarioDTO.apellidos;
            consu = consu + ",'" + apellidos + "'";
            string direccion = usuarioDTO.direccion;
            consu = consu + ",'" + direccion + "'";
            string barrio = usuarioDTO.barrio;
            consu = consu + ",'" + barrio + "'";
            int estrato = usuarioDTO.estrato;
            consu = consu + "," + Convert.ToString(estrato);
            string telefono = usuarioDTO.telefono;
            consu = consu + ",'" + telefono + "'";
            string celular = usuarioDTO.celular;
            consu = consu + ",'" + celular + "'";
            string email = usuarioDTO.email;
            consu = consu + ",'" + email + "'";
            string observaciones = usuarioDTO.observaciones;
            consu = consu + ",'" + observaciones + "'";
            bool propietario = usuarioDTO.propietario;
            consu = consu + "," + propietario;
            int ciudad = usuarioDTO.ciudad;
            consu = consu + "," + ciudad;
            int departamento = usuarioDTO.departamento;
            consu = consu + "," + departamento + ");";
            bool exito = insertar(consu);

            //Crea sentencia SQL para agregar censo
            consu = "insert into censo (fecha,hora,cedula) VALUES ('";
            string fecha = censoDTO.fecha;
            consu = consu + fecha;
            string hora = censoDTO.hora;
            consu = consu + "','" + hora + "'," + cedula + ");";
            exito = insertar(consu);
            return exito;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        public static bool insertar(string consu)
        {
            bool test = true;
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=proyecto;port=3306;password=");
            MySqlCommand comm = new MySqlCommand(consu, conn);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                test = false;
            }
            conn.Close();
            return test;
        }

        // para consultas que devuelven varios valores
        public static ArrayList consultar(string consu)
        {
            ArrayList filas = new ArrayList();
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=proyecto;port=3306;password=");
            MySqlCommand comm = new MySqlCommand(consu, conn);
            try
            {
                conn.Open();
                MySqlDataReader read = comm.ExecuteReader();
                while (read.Read())
                {
                    int columnas = read.FieldCount;
                    if (columnas == 1)
                    {
                        string datos = read.GetString(0);
                        filas.Add(datos);
                    }
                    else {
                        string[] datos = new string[columnas];
                        for (int i = 0; i < columnas; i++)
                        {
                            datos[i] = (read.GetString(i));
                        }
                        filas.Add(datos);
                    }
                }
                read.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            if (filas.Count >= 1)
            {
                return filas;
            }
            else
                return null;
        }

        //para consultas que devuelven un unico valor
        public static string consultardato(string consu)
        {
            string dato = "";
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=proyecto;port=3306;password=");
            MySqlCommand comm = new MySqlCommand(consu, conn);
            try
            {
                conn.Open();
                object read = comm.ExecuteScalar();
                dato = Convert.ToString(read);
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return dato;
        }
    }
}
