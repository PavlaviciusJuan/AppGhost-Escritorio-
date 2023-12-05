using System;
using System.Data;

using AccesoDatos.DataBase;
using Entidades.Usuarios;

namespace LogicaNegocio.Usuarios
{
    public class ClassClienteLn
    {

        #region Variables privados

        private ClassDataBase objDataBase = null;


        #endregion

        #region Metodo Index

        public void Index(ref ClassCliente objUsuario)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "cliente",
                NombreSP = "bdghostapp.SP_Clientes_Index",
                Scalar = false,

            };

            Ejecutar(ref objUsuario);
        }

        #endregion

        #region CRUD Usuario
        public void Create(ref ClassCliente objUsuario)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "cliente",
                NombreSP = "bdghostapp.SP_Clientes_Create",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_nombre", "2", objUsuario.Nombre);
            objDataBase.DtParametros.Rows.Add(@"p_dni", "2", objUsuario.Dni);
            objDataBase.DtParametros.Rows.Add(@"p_email", "2", objUsuario.Email);
            objDataBase.DtParametros.Rows.Add(@"p_contraseña", "2", objUsuario.Contrasena);
            objDataBase.DtParametros.Rows.Add(@"p_status", "2", objUsuario.Status);

            Ejecutar(ref objUsuario);
        }
        public void Read(ref ClassCliente objUsuario)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "cliente",
                NombreSP = "bdghostapp.SP_Clientes_Read",
                Scalar = false

            };

            objDataBase.DtParametros.Rows.Add(@"p_idCliente", "1", objUsuario.IdCliente);

            Ejecutar(ref objUsuario);
        }
        public void Update(ref ClassCliente objUsuario)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "cliente",
                NombreSP = "bdghostapp.SP_Clientes_Update",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_idCliente", "1", objUsuario.IdCliente);
            objDataBase.DtParametros.Rows.Add(@"p_nombre", "2", objUsuario.Nombre);
            objDataBase.DtParametros.Rows.Add(@"p_dni", "2", objUsuario.Dni);
            objDataBase.DtParametros.Rows.Add(@"p_email", "2", objUsuario.Email);
            objDataBase.DtParametros.Rows.Add(@"p_contraseña", "2", objUsuario.Contrasena);
            objDataBase.DtParametros.Rows.Add(@"p_status", "2", objUsuario.Status);


            Ejecutar(ref objUsuario);
        }
        public void Delete(ref ClassCliente objUsuario)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "cliente",
                NombreSP = "bdghostapp.SP_Clientes_Delete",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_idCliente", "1", objUsuario.IdCliente);

            Ejecutar(ref objUsuario);
        }

        #endregion

        #region Metodos privados

        private void Ejecutar (ref ClassCliente objCliente)
        {
            objDataBase.CRUD(ref objDataBase);

            if (objDataBase.MensajeErrorDB == null)
            {
                if (objDataBase.Scalar)
                {
                    objCliente.ValorScalar = objDataBase.ValorScalar;
                }
                else
                {
                    objCliente.DtResultados = objDataBase.DsResultados.Tables[0];

                    if (objCliente.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in objCliente.DtResultados.Rows)
                        {
                            objCliente.IdCliente = Convert.ToInt32(item["idCliente"].ToString());
                            objCliente.Nombre = item["nombre"].ToString();
                            objCliente.Dni = item["dni"].ToString();
                            objCliente.Email = item["email"].ToString();
                            objCliente.Contrasena = item["contraseña"].ToString();
                            objCliente.Status = item["status"].ToString();
                        }
                    }
                }
            }
            else
            {
                objCliente.MensajeError = objDataBase.MensajeErrorDB;
            }

        }

        #endregion


    }
}
