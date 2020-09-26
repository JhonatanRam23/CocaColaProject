using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenadoProject.Models.ViewModels
{
    public class ListArticulos
    {
        public int cantidad { get; set; }        
        public string producto { get; set; }        
        public double precio { get; set; }
        public double total { get; set; }
    }
}