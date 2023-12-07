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

        #region Metodos

        public void Index(ref ClassEmpleado objEmpleado)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "empleado",
                NombreSP = "bdghostapp.SP_Empleado_Index",
                Scalar = false,

            };

            Ejecutar(ref objEmpleado);
        }

        public void IniciarSesion(ref ClassEmpleado objEmpleado)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "empleado",
                NombreSP = "bdghostapp.SP_Empleado_InicioSesion",
                Scalar = false

            };

            objDataBase.DtParametros.Rows.Add(@"p_email", "2", objEmpleado.Email);
            objDataBase.DtParametros.Rows.Add(@"p_contraseña", "2", objEmpleado.Contrasena);

            Ejecutar(ref objEmpleado);
        }

        #endregion

        #region CRUD Usuario
        public void Create(ref ClassEmpleado objEmpleado)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "empleado",
                NombreSP = "bdghostapp.SP_Empleado_Create",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_nombre", "2", objEmpleado.Nombre);
            objDataBase.DtParametros.Rows.Add(@"p_dni", "2", objEmpleado.Dni);
            objDataBase.DtParametros.Rows.Add(@"p_email", "2", objEmpleado.Email);
            objDataBase.DtParametros.Rows.Add(@"p_contraseña", "2", objEmpleado.Contrasena);
            objDataBase.DtParametros.Rows.Add(@"p_status", "2", objEmpleado.Status);

            Ejecutar(ref objEmpleado);
        }
        public void Read(ref ClassEmpleado objEmpleado)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "empleado",
                NombreSP = "bdghostapp.SP_Empleado_Read",
                Scalar = false

            };

            objDataBase.DtParametros.Rows.Add(@"p_idEmpleado", "1", objEmpleado.IdEmpleado);

            Ejecutar(ref objEmpleado);
        }
        public void Update(ref ClassEmpleado objEmpleado)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "empleado",
                NombreSP = "bdghostapp.SP_Empleado_Update",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_idEmpleado", "1", objEmpleado.IdEmpleado);
            objDataBase.DtParametros.Rows.Add(@"p_nombre", "2", objEmpleado.Nombre);
            objDataBase.DtParametros.Rows.Add(@"p_dni", "2", objEmpleado.Dni);
            objDataBase.DtParametros.Rows.Add(@"p_email", "2", objEmpleado.Email);
            objDataBase.DtParametros.Rows.Add(@"p_contraseña", "2", objEmpleado.Contrasena);
            objDataBase.DtParametros.Rows.Add(@"p_status", "2", objEmpleado.Status);


            Ejecutar(ref objEmpleado);
        }
        public void Delete(ref ClassEmpleado objEmpleado)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "empleado",
                NombreSP = "bdghostapp.SP_Empleado_Delete",
                Scalar = true

            };

            objDataBase.DtParametros.Rows.Add(@"p_idEmpleado", "1", objEmpleado.IdEmpleado);

            Ejecutar(ref objEmpleado);
        }

        #endregion

        #region Metodos privados

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
                            objEmpleado.IdEmpleado = Convert.ToInt32(item["idEmpleado"].ToString());
                            objEmpleado.Nombre = item["nombre"].ToString();
                            objEmpleado.Dni = item["dni"].ToString();
                            objEmpleado.Email = item["email"].ToString();
                            objEmpleado.Contrasena = item["contraseña"].ToString();
                            objEmpleado.Status = item["status"].ToString();
                            objEmpleado.Rol_idRol = Convert.ToInt32(item["rol_idRol"].ToString());
                        }
                    }
                }
            }
            else
            {
                objEmpleado.MensajeError = objDataBase.MensajeErrorDB;
            }

        }

        #endregion

    }

}

