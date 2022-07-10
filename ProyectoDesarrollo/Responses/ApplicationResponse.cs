using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ProyectoDesarrollo.Exceptions;

namespace ProyectoDesarrollo.Responses
{
    public class ApplicationResponse<T> where T : class
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Exception { get; set; }

        public void Error(Exception ex)
        {
            Success = false;
            Message = ex.Message;
            Exception = ex.ToString();
        }
    }
}
