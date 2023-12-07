using System;
using System.Data;

namespace Entidades.Fiestas
{
    public class ClassFiesta
    {

        #region Atributos privados

        private int _idFiesta, _ubicacion_idUbicacion, _empleado_idEmpleado;
        private string _nombre, _descripcion, _img, _genero, _invitado, _status;
        private DateTime _fecha;
        private TimeSpan _horaInicio, _horaFin;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        #endregion

        #region Atributos publicos

        public int IdFiesta { get => _idFiesta; set => _idFiesta = value; }
        public int Ubicacion_idUbicacion { get => _ubicacion_idUbicacion; set => _ubicacion_idUbicacion = value; }
        public int Empleado_idEmpleado { get => _empleado_idEmpleado; set => _empleado_idEmpleado = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string Img { get => _img; set => _img = value; }
        public string Genero { get => _genero; set => _genero = value; }
        public string Invitado { get => _invitado; set => _invitado = value; }
        public string Status { get => _status; set => _status = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public TimeSpan HoraInicio { get => _horaInicio; set => _horaInicio = value; }
        public TimeSpan HoraFin { get => _horaFin; set => _horaFin = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }

        #endregion


    }
}
