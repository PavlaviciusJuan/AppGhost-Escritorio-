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
        private readonly ClassEmpleadoLn ObjUsuarioLn = new ClassEmpleadoLn();

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

            ObjUsuarioLn.IniciarSesion(ref ObjEmpleado);
            if (ObjEmpleado.MensajeError == null)
            {
                if (ObjEmpleado.ValorScalar == null)
                {
                    MessageBox.Show("El usuario no existe");
                }
                else
                {
                    MessageBox.Show("El usuario" + ObjEmpleado.ValorScalar + " fue ingresado");
                }

            }
            else
            {
                MessageBox.Show(ObjEmpleado.MensajeError, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
