#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ProyectoDesarrollo.Persistence.Entidades
{
    public class Dueno
    {
        [Key] 
        public string CedulaRif { get; set; }
        [Required] 
        public string PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        [Required] 
        public string PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Direccion { get; set; }

        public ICollection<Poliza> Polizas { get; set; }

        /*public Dueno(string cedulaRif, string primerNombre, string? segundoNombre, string primerApellido, string? segundoApellido, 
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
