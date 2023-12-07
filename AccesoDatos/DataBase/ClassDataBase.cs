using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AccesoDatos.DataBase
{
    public class ClassDataBase
    {

        #region Variables privadas

        private MySqlConnection _objSqlConnection;
        private MySqlDataAdapter _objSqlDataAdapter;
        private MySqlCommand _objSqlCommand;
        private DataSet _dsResultados;
        private DataTable _dtParametros;
        private string _nombreTabla, _nombreSP, _mensajeErrorDB, _valorScalar, _nombreDB;
        private bool _scalar;

        #endregion


        #region Variables publicas
        public MySqlConnection ObjSqlConnection { get => _objSqlConnection; set => _objSqlConnection = value; }
        public MySqlDataAdapter ObjSqlDataAdapter { get => _objSqlDataAdapter; set => _objSqlDataAdapter = value; }
        public MySqlCommand ObjSqlCommand { get => _objSqlCommand; set => _objSqlCommand = value; }
        public DataSet DsResultados { get => _dsResultados; set => _dsResultados = value; }
        public DataTable DtParametros { get => _dtParametros; set => _dtParametros = value; }
        public string NombreTabla { get => _nombreTabla; set => _nombreTabla = value; }
        public string NombreSP { get => _nombreSP; set => _nombreSP = value; }
        public string MensajeErrorDB { get => _mensajeErrorDB; set => _mensajeErrorDB = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public string NombreDB { get => _nombreDB; set => _nombreDB = value; }
        public bool Scalar { get => _scalar; set => _scalar = value; }

        #endregion

        #region Constructores

        public ClassDataBase()
        {
            DtParametros = new DataTable("SpParametros");
            DtParametros.Columns.Add("Nombre");
            DtParametros.Columns.Add("TipoDato");
            DtParametros.Columns.Add("Valor");

            NombreDB = "bdghostapp";

        }

        #endregion

        #region Metodos privados

        private void CrearConexionBaseDatos(ref ClassDataBase ObjDataBase)
        {
            switch (ObjDataBase.NombreDB)
            {
                case "bdghostapp":

                    ObjDataBase.ObjSqlConnection = new MySqlConnection();
                    string cadcon = "datasource=127.0.0.1;port=3306;username=root;password=;database=bdghostapp";
                    ObjDataBase.ObjSqlConnection.ConnectionString = cadcon;

                    break;

                default: break;

            }
        }
        private void ValidarConexionBaseDatos(ref ClassDataBase ObjDataBase)
        {
            if(ObjDataBase.ObjSqlConnection.State == ConnectionState.Closed)
            {
                ObjDataBase.ObjSqlConnection.Open();
            }
            else
            {
                ObjDataBase.ObjSqlConnection.Close();
                ObjDataBase.ObjSqlConnection.Dispose();
            }
        }
        private void AgregarParametros(ref ClassDataBase ObjDataBase)
        {
            if (ObjDataBase.DtParametros != null)
            {
                MySqlDbType TipoDatoMySql = new MySqlDbType();

                foreach (DataRow item in ObjDataBase.DtParametros.Rows)
                {
                    switch (item[1])
                    {
                        case "1":
                            TipoDatoMySql = MySqlDbType.Int32;
                            break;

                        case "2":
                            TipoDatoMySql = MySqlDbType.VarChar;
                            break;

                        case "3":
                            TipoDatoMySql = MySqlDbType.Text;
                            break;

                        case "4":
                            TipoDatoMySql = MySqlDbType.Double;
                            break;

                        case "5":
                            TipoDatoMySql = MySqlDbType.Date;
                            break;

                        case "6":
                            TipoDatoMySql = MySqlDbType.Time;
                            break;

                        default: break;

                    }
                    if (ObjDataBase.Scalar)
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            ObjDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoMySql).Value = DBNull.Value;
                        }
                        else
                        {
                            ObjDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoMySql).Value = item[2].ToString();
                        }    
                    }
                    else
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            ObjDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoMySql).Value = DBNull.Value;
                        }
                        else
                        {
                            ObjDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoMySql).Value = item[2].ToString();
                        }
                    }
                }
            }
        }
        private void PrepararConexionBaseDatos(ref ClassDataBase ObjDataBase)
        {
            CrearConexionBaseDatos(ref ObjDataBase);
            ValidarConexionBaseDatos(ref ObjDataBase);

        }
        private void EjecutarDataAdapter(ref ClassDataBase ObjDataBase)
        {
            try
            {
                PrepararConexionBaseDatos(ref ObjDataBase);

                ObjDataBase.ObjSqlDataAdapter = new MySqlDataAdapter(ObjDataBase.NombreSP, ObjDataBase.ObjSqlConnection);
                ObjDataBase.ObjSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                AgregarParametros(ref ObjDataBase);
                ObjDataBase.DsResultados = new DataSet();
                ObjDataBase.ObjSqlDataAdapter.Fill(ObjDataBase.DsResultados, ObjDataBase.NombreTabla);

            }
            catch (Exception ex)
            {

                ObjDataBase.MensajeErrorDB = ex.Message.ToString();

            }
            finally
            {
                if (ObjDataBase.ObjSqlConnection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref ObjDataBase);
                }
            }
        }
        private void EjecutarCommand(ref ClassDataBase ObjDataBase)
        {
            try
            {
                PrepararConexionBaseDatos(ref ObjDataBase);
                ObjDataBase.ObjSqlCommand = new MySqlCommand(ObjDataBase.NombreSP, ObjDataBase.ObjSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                AgregarParametros(ref ObjDataBase);

                if (ObjDataBase.Scalar)
                {
                    ObjDataBase.ValorScalar = ObjDataBase.ObjSqlCommand.ExecuteScalar().ToString().Trim();
                }
                else
                {
                    ObjDataBase.ObjSqlCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                ObjDataBase.MensajeErrorDB = ex.Message.ToString();
            }
            finally
            {
                if (ObjDataBase.ObjSqlConnection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref ObjDataBase);
                }
            }
        }


        #endregion

        #region Metodos publicos

        public void CRUD(ref ClassDataBase ObjDataBase)
        {
            if (ObjDataBase.Scalar)
            {
                EjecutarCommand(ref  ObjDataBase);
            }
            else
            {
                EjecutarDataAdapter(ref ObjDataBase);
            }
        }

        #endregion



    }
}
