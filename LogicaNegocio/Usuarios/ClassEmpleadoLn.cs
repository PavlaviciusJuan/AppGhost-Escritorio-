using System;
using System.Data;
using AccesoDatos.DataBase;
using Entidades.Usuarios;

namespace LogicaNegocio.Usuarios
{
    public class ClassEmpleadoLn
    {

        #region Variables privados

        private ClassDataBase objDataBase = null;

        #endregion

        public void IniciarSesion(ref ClassEmpleado objEmpleado)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "cliente",
                NombreSP = "bdghostapp.SP_Usuario_InicioSesion",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_email", "2", objEmpleado.Email);
            objDataBase.DtParametros.Rows.Add(@"p_contraseña", "2", objEmpleado.Contrasena);

            Ejecutar(ref objEmpleado);
        }
        private void Ejecutar(ref ClassEmpleado objEmpleado)
        {
            objDataBase.CRUD(ref objDataBase);

            if (objDataBase.MensajeErrorDB == null)
            {
                if (objDataBase.Scalar)
                {
                    objEmpleado.ValorScalar = objDataBase.ValorScalar;
                }
                else
                {
                    objEmpleado.DtResultados = objDataBase.DsResultados.Tables[0];

                    if (objEmpleado.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in objEmpleado.DtResultados.Rows)
                        {
                            objEmpleado.IdEmpleado = Convert.ToInt16(item["idEmpleado"].ToString());
                            objEmpleado.Nombre = item["nombre"].ToString();
                            objEmpleado.Dni = item["dni"].ToString();
                            objEmpleado.Email = item["email"].ToString();
                            objEmpleado.Contrasena = item["contraseña"].ToString();
                            objEmpleado.Rol_idRol = Convert.ToInt16(item["rol_idRol"].ToString());
                        }
                    }
                }
            }
            else
            {
                objEmpleado.MensajeError = objDataBase.MensajeErrorDB;
            }

        }

    }
}
