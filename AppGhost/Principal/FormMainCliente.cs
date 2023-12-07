using System.Windows.Forms;
using Entidades.Fiestas;
using Entidades.Usuarios;
using LogicaNegocio.Fiestas;
using LogicaNegocio.Usuarios;

namespace AppGhost.Principal
{
    public partial class FormMainCliente : Form
    {

        private ClassCliente ObjCliente = null;
        private ClassFiesta ObjFiesta = null;
        private readonly ClassFiestaLn ObjFiestaLn = new ClassFiestaLn();
        private readonly ClassClienteLn ObjClienteLn = new ClassClienteLn();
        private ClassCliente objClienteSesion = null;

        public FormMainCliente(ref ClassCliente objCliente)
        {
            InitializeComponent();
            CargarListaFiestas();

            objClienteSesion = objCliente;

            lblCliente.Text = objClienteSesion.Nombre;
        }

        private void CargarListaFiestas()
        {
            ObjFiesta = new ClassFiesta();
            ObjFiestaLn.Index(ref ObjFiesta);
            if (ObjFiesta.MensajeError == null)
            {
                dgvFiestas.DataSource = ObjFiesta.DtResultados;
            }
            else
            {
                MessageBox.Show(ObjCliente.MensajeError, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
