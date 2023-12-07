using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Usuarios;
using LogicaNegocio.Usuarios;

namespace AppGhost.Principal
{
    public partial class FormLoginEmpleado : Form
    {
        private ClassEmpleado ObjEmpleado = null;
        private readonly ClassEmpleadoLn ObjEmpleadoLn = new ClassEmpleadoLn();

        public FormLoginEmpleado()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            ObjEmpleado = new ClassEmpleado()
            {
                Email = TxtEmail.Text,
                Contrasena = TxtContrasena.Text
            };

            ObjEmpleadoLn.IniciarSesion(ref ObjEmpleado);
            if (ObjEmpleado.MensajeError == null)
            {
                if (ObjEmpleado.Nombre != null)
                {




                    MessageBox.Show("El usuario " + ObjEmpleado.Nombre.ToString() + " fue ingresado");
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }

            }
            else
            {
                MessageBox.Show(ObjEmpleado.MensajeError, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
