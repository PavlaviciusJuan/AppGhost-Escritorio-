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
    public partial class FormLoginCliente : Form
    {
        private ClassCliente ObjCliente = null;
        private readonly ClassClienteLn ObjClienteLn = new ClassClienteLn();

        public FormLoginCliente()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            ObjCliente = new ClassCliente()
            {
                Email = TxtEmail.Text,
                Contrasena = TxtContrasena.Text
            };

            ObjClienteLn.IniciarSesion(ref ObjCliente);

            if (ObjCliente.MensajeError == null)
            {
                if (ObjCliente.Nombre != null) 
                {
                    MessageBox.Show("El usuario " + ObjCliente.Nombre.ToString() + " fue ingresado");
                    FormMainCliente form = new FormMainCliente(ref ObjCliente);
                    //form.MdiParent = this;
                    this.Hide();
                    form.FormClosed += (s, args) => this.Close();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("El usuario no existe");
                }
                
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
