using System;
namespace ProyectoDesarrollo.Exceptions
{
    public class ProyectoException : Exception
    {
            public string Mensaje { get; set; }

            public Exception Excepcion { get; set; }

            public string CodigoError { get; set; }

            public string MensajeSoporte { get; set; }


            public ProyectoException(string _mensaje, Exception _excepcion, string _mensajesoporte, string _codigoError)
            {
                Mensaje = _mensaje;
                Excepcion = _excepcion;
                CodigoError = _codigoError;
                MensajeSoporte = _mensajesoporte;
            }


            public ProyectoException(string _mensaje, string _mensajeSoporte, Exception _excepcion)
            {
                Mensaje = _mensaje;
                Excepcion = _excepcion;
                MensajeSoporte = _mensajeSoporte;
            }

            /// <summary>
            /// Constructor del la excepción LotoAnimalitosException.
            /// </summary>
            /// <param name="mensaje">Mensaje de la excepción.</param>
            /// <param name="excepcion">Excepción original.</param>
            public ProyectoException(string _mensaje, Exception _excepcion)
            {
                Mensaje = _mensaje;
                Excepcion = _excepcion;
            }

            /// <summary>
            /// Constructor del la excepción LotoAnimalitosException.
            /// </summary>
            /// <param name="mensaje">Mensaje de la excepción.</param>
            public ProyectoException(string _mensaje)
            {
                Mensaje = _mensaje;
            }
    }
}

