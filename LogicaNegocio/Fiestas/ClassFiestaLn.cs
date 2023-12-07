using System;
using System.Data;
using AccesoDatos.DataBase;
using Entidades.Fiestas;

namespace LogicaNegocio.Fiestas
{
    public class ClassFiestaLn
    {
        #region Variables privados

        private ClassDataBase objDataBase = null;


        #endregion

        #region Metodos

        public void Index(ref ClassFiesta objFiesta)
        {
            objDataBase = new ClassDataBase()
            {
                NombreTabla = "fiesta",
                NombreSP = "bdghostapp.SP_Fiesta_Index",
                Scalar = false,
            };

            Ejecutar(ref objFiesta);
        }

        #endregion

        #region CRUD Fiesta


        #endregion

        #region Metodos privados

        private void Ejecutar(ref ClassFiesta objFiesta)
        {
            objDataBase.CRUD(ref objDataBase);

            if (objDataBase.MensajeErrorDB == null)
            {
                if (objDataBase.Scalar)
                {
                    objFiesta.ValorScalar = objDataBase.ValorScalar;
                }
                else
                {
                    objFiesta.DtResultados = objDataBase.DsResultados.Tables[0];

                    if (objFiesta.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in objFiesta.DtResultados.Rows)
                        {
                            objFiesta.IdFiesta = Convert.ToInt32(item["idFiesta"].ToString());
                            objFiesta.Nombre = item["nombre"].ToString();
                            objFiesta.Descripcion = item["descripcion"].ToString();
                            objFiesta.Fecha = Convert.ToDateTime(item["fecha"].ToString());
                            objFiesta.HoraInicio = TimeSpan.Parse(item["horaInicio"].ToString());
                            objFiesta.HoraFin = TimeSpan.Parse((item["horaFin"].ToString()));
                            objFiesta.Img = item["img"].ToString();
                            objFiesta.Genero = item["genero"].ToString();
                            objFiesta.Invitado = item["invitado"].ToString();
                            objFiesta.Ubicacion_idUbicacion = Convert.ToInt32(item["ubicacion_idUbicacion"].ToString());
                            objFiesta.Empleado_idEmpleado = Convert.ToInt32(item["empleado_idEmpleado"].ToString());
                            objFiesta.Status = item["status"].ToString();
                        }
                    }
                }
            }
            else
            {
                objFiesta.MensajeError = objDataBase.MensajeErrorDB;
            }

        }

        #endregion


    }
}
