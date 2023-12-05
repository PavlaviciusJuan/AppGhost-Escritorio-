using System;
using System.Windows.Forms;
using Entidades.Usuarios;
using LogicaNegocio.Usuarios;

namespace AppGhost.Principal
{
    public partial class FormClientes : Form
    {
        private ClassCliente ObjCliente = null;
        private readonly ClassClienteLn ObjClienteLn = new ClassClienteLn();

        public FormClientes()
        {
            InitializeComponent();
            CargarListaClientes();
        }


        private void CargarListaClientes()
        {
            ObjCliente = new ClassCliente();
            ObjClienteLn.Index(ref ObjCliente);
            if (ObjCliente.MensajeError == null)
            {
                dgvClientes.DataSource = ObjCliente.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ObjCliente = new ClassCliente()
            {
                Nombre = TxtNombre.Text,
                Dni = TxtDni.Text,
                Email = TxtEmail.Text,
                Contrasena = TxtContrasena.Text,
                Status = "Activa"
            };

            ObjClienteLn.Create(ref ObjCliente);

            if (ObjCliente.MensajeError == null)
            {
                MessageBox.Show("El ID: " + ObjCliente.ValorScalar + ", fue agregado correctamente");
                
                CargarListaClientes();
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            ObjCliente = new ClassCliente()
            {
                IdCliente = Convert.ToInt16(LblIdCliente.Text),
                Nombre = TxtNombre.Text,
                Dni = TxtDni.Text,
                Email = TxtEmail.Text,
                Contrasena = TxtContrasena.Text,
                Status = "Activa"
            };

            ObjClienteLn.Update(ref ObjCliente);
            if (ObjCliente.MensajeError == null)
            {
                MessageBox.Show("El usuario fue cambiado correctamente");

                CargarListaClientes();
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvClientes.Columns[e.ColumnIndex].Name == "Editar")
                {
                    ObjCliente = new ClassCliente()
                    {
                        IdCliente = Convert.ToInt16(dgvClientes.Rows[e.RowIndex].Cells["idCliente"].Value.ToString())
                    };
                    LblIdCliente.Text = ObjCliente.IdCliente.ToString();

                    ObjClienteLn.Read(ref ObjCliente);
                    TxtNombre.Text = ObjCliente.Nombre;
                    TxtDni.Text = ObjCliente.Dni;
                    TxtEmail.Text = ObjCliente.Email;
                    TxtContrasena.Text = ObjCliente.Contrasena;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ObjCliente = new ClassCliente()
            {
                IdCliente = Convert.ToInt16(LblIdCliente.Text)
            };

            ObjClienteLn.Delete(ref  ObjCliente);
            CargarListaClientes();
        }
    }
}
