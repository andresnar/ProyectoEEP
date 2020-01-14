using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEnergia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ArrayList listaCiudades = Service.listarCiudades();
            ArrayList listaDeptos = Service.listarDeptos();
            foreach (object a in listaCiudades)
            {
                cciudad.Items.Add(a);
            }
            foreach (object a in listaDeptos)
            {
                cdepto.Items.Add(a);
            }
            cciudad.SelectedIndex = 0;
            cdepto.SelectedIndex = 0;
        }

        private void bagregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.cedula = Convert.ToInt32(tcedula.Text);
            usuario.nombre = tnombre.Text;
            usuario.apellidos = tapellido.Text;
            usuario.direccion = tdireccion.Text;
            usuario.barrio = tbarrio.Text;
            usuario.estrato = Convert.ToInt32(testrato.Text);
            usuario.telefono = ttelefono.Text;
            usuario.celular = tcelular.Text;
            usuario.email = temail.Text;
            usuario.observaciones = tobservacion.Text;
            usuario.propietario = checpropietario.Checked;
            string nciudad = cciudad.Items[cciudad.SelectedIndex].ToString();
            int idCiudad = Convert.ToInt32(Service.buscarCiudad(nciudad));
            usuario.ciudad = idCiudad;
            string ndepto = cdepto.Items[cdepto.SelectedIndex].ToString();
            int idDdepto = Convert.ToInt32(Service.buscarDepto(ndepto));
            usuario.departamento = idDdepto;

            Censo censo = new Censo();
            censo.fecha = cfecha.Value.ToString("dd/MM/yyyy");
            censo.hora = DateTime.Now.ToString("h:mm:ss");
            censo.cedula = usuario.cedula;

            bool exitoso = Service.guardar(usuario, censo);

        }
    }
}
