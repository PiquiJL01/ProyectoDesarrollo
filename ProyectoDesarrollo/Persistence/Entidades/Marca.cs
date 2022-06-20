﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProyectoDesarrollo.Models
{
    public class Marca
    {
        [Key]
        public string Name { get; set; }
        public ICollection<Proveedor> Proovedores { get; set; }
    }
}