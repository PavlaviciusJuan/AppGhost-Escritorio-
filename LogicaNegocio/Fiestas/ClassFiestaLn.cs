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

            //Ejecutar(ref objFiesta);
        }

        #endregion

        #region CRUD Fiesta
        

        #endregion

        


    }
}
