using System;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models
{

    public enum RolName
    {
        Administrador,
        U_Taller,
        U_Proveedor,
        Perito,
        Asegurado
    }

	public class Usuario
	{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime BirthDate { get; set; }
        public RolName Rol { get; set; }


        //public HashSet<Movie> MovieActors { get; set; }
    }
}
