 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VenadoProject.Models.ViewModels
{
    public class ListCliente
    {
        public string nit { get; set; }

        [Required]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

    }
}