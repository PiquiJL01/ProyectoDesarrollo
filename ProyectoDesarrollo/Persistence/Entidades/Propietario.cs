#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Propietario
    {

        public Propietario()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public string CedulaRif { get; set; } = null!;
        [Required]
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        [Required]
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Direccion { get; set; } = null!;
        public string Id_Poliza { get; set; } = null!;


        public Poliza Poliza { get; set; } = null!;

        public ICollection<Vehiculo> Vehiculo { get; set; }



        /*public Propietario (string cedulaRif, string primerNombre, string? segundoNombre, string primerApellido, string? segundoApellido, 
            DateTime fechaNacimiento, string direccion, ICollection<Poliza> polizas)
        {
            CedulaRif = cedulaRif;
            PrimerNombre = primerNombre;
            SegundoNombre = segundoNombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Polizas = polizas;
        }*/
    }
}
