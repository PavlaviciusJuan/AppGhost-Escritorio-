using System.Data;

namespace Entidades.Usuarios
{
    public class ClassEmpleado
    {
        #region Atributos privados

        private int _idEmpleado, _rol_idRol;
        private string _nombre, _dni, _email, _contrasena, _status;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        #endregion

        #region Atributos publicos

        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Dni { get => _dni; set => _dni = value; }
        public string Email { get => _email; set => _email = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public string Status { get => _status; set => _status = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
        public int Rol_idRol { get => _rol_idRol; set => _rol_idRol = value; }

        #endregion



    }
}
