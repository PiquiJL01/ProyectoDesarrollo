using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RCVUcab.Responses
{
    public class ApplicationResponse<T> where T : class
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Exception { get; set; }

        /// <summary>
        /// Maneja los errores de las repuestas de los controladores
        /// </summary>
        /// <param name="exception">Error obtenido por el comando ejecutado</param>
        public void Error(Exception exception)
        {
            Success = false;
            Message = exception.Message;
            Exception = exception.ToString();
        }
    }
}
