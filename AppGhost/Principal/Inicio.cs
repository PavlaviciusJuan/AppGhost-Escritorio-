using System;
using System.Windows.Forms;

namespace AppGhost.Principal
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnLoginCliente_Click(object sender, EventArgs e)
        {
            FormLoginCliente form = new FormLoginCliente();
            //form.MdiParent = this;
            this.Hide();
            form.FormClosed += (s, args) => this.Close();
            form.Show();
        }

        private void btnLoginEmpleado_Click(object sender, EventArgs e)
        {
            FormLoginEmpleado form = new FormLoginEmpleado();
            //form.MdiParent = this;
            this.Hide();
            form.FormClosed += (s, args) => this.Close();
            form.Show();
        }
    }
}
