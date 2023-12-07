namespace AppGhost.Principal
{
    partial class FormMainCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.dgvFiestas = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiestas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(64, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(13, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "..";
            // 
            // dgvFiestas
            // 
            this.dgvFiestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiestas.Location = new System.Drawing.Point(12, 121);
            this.dgvFiestas.Name = "dgvFiestas";
            this.dgvFiestas.Size = new System.Drawing.Size(776, 317);
            this.dgvFiestas.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Mis Compras";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(322, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fiestas disponibles";
            // 
            // FormMainCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvFiestas);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label1);
            this.Name = "FormMainCliente";
            this.Text = "FormMainCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiestas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.DataGridView dgvFiestas;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}