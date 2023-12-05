namespace AppGhost.Principal
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoginEmpleado = new System.Windows.Forms.Button();
            this.btnLoginCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoginEmpleado
            // 
            this.btnLoginEmpleado.Location = new System.Drawing.Point(235, 272);
            this.btnLoginEmpleado.Name = "btnLoginEmpleado";
            this.btnLoginEmpleado.Size = new System.Drawing.Size(328, 68);
            this.btnLoginEmpleado.TabIndex = 0;
            this.btnLoginEmpleado.Text = "Login Empleado";
            this.btnLoginEmpleado.UseVisualStyleBackColor = true;
            this.btnLoginEmpleado.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoginCliente
            // 
            this.btnLoginCliente.Location = new System.Drawing.Point(235, 110);
            this.btnLoginCliente.Name = "btnLoginCliente";
            this.btnLoginCliente.Size = new System.Drawing.Size(328, 68);
            this.btnLoginCliente.TabIndex = 0;
            this.btnLoginCliente.Text = "Login Cliente";
            this.btnLoginCliente.UseVisualStyleBackColor = true;
            this.btnLoginCliente.Click += new System.EventHandler(this.button2_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoginCliente);
            this.Controls.Add(this.btnLoginEmpleado);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoginEmpleado;
        private System.Windows.Forms.Button btnLoginCliente;
    }
}