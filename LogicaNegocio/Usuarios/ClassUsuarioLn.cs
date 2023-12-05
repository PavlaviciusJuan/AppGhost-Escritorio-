using System;
using System.Data;
using AccesoDatos.DataBase;
using Entidades.Usuarios;

namespace LogicaNegocio.Usuarios
{
    public class ClassUsuarioLn
    {

        #region Variables privados

        private ClassDataBase objDataBase = null;

        #endregion

        public void IniciarSesion(ref ClassUsuario objUsuario)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "cliente",
                NombreSP = "bdghostapp.SP_Usuario_InicioSesion",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_email", "2", objUsuario.Email);
            objDataBase.DtParametros.Rows.Add(@"p_contraseña", "2", objUsuario.Contrasena);

            Ejecutar(ref objUsuario);
        }
        private void Ejecutar(ref ClassUsuario objUsuario)
        {
            objDataBase.CRUD(ref objDataBase);

            if (objDataBase.MensajeErrorDB == null)
            {
                if (objDataBase.Scalar)
                {
                    objUsuario.ValorScalar = objDataBase.ValorScalar;
                }
                else
                {
                    objUsuario.DtResultados = objDataBase.DsResultados.Tables[0];

                    if (objUsuario.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in objUsuario.DtResultados.Rows)
                        {
                            objUsuario.IdUsuario = Convert.ToInt16(item["idCliente"].ToString());
                            objUsuario.Nombre = item["nombre"].ToString();
                            objUsuario.Dni = item["dni"].ToString();
                            objUsuario.Email = item["email"].ToString();
                            objUsuario.Contrasena = item["contraseña"].ToString();

                        }
                    }
                }
            }
            else
            {
                objUsuario.MensajeError = objDataBase.MensajeErrorDB;
            }

        }


    }


}

