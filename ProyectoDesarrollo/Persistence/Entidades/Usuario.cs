#nullable enable
using System;

namespace ProyectoDesarrollo.Persistence.Entidades
{

    public enum RolName
    {
        Administrador,
        U_Taller,
        U_Proveedor,
        Perito
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
        public Proveedor? Proveedor { get; set; }
        public Taller? Taller { get; set; }

        /*public Usuario(int id, string nombre, string apellido, string telefono, string email, string direccion, 
            DateTime birthDate, RolName rol, Proveedor? proveedor, Taller? taller)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            BirthDate = birthDate;
            Rol = rol;
            Proveedor = proveedor;
            Taller = taller;
        }*/
    }
}
