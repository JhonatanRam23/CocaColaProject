using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenadoProject.Models.ViewModels
{
    public class ListFactura
    {

        public int nofactura { get; set; }
        public string cliente { get; set; }
        public DateTime fecha { get; set; }
        public double total { get; set; }
        public string usuario { get; set; }
        public List<ListArticulos> ListaArticulos { get; set; }

    }
}