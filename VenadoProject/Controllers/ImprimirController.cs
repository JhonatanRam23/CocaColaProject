using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using MessagingToolkit.QRCode.Codec;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenadoProject.Models;
using VenadoProject.Models.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace VenadoProject.Controllers
{
    public class ImprimirController : Controller
    {
        // GET: Imprimir
        public ActionResult Index()
        {
            rinconEntities db = new rinconEntities();
            ViewBag.factura = new SelectList(db.enc_factura, "no_factura", "no_factura");
            return View();            
        }


        public ActionResult Prueba(int factura)
        {
            ListFactura fact = new ListFactura();

            Models.rinconEntities db = new Models.rinconEntities();
            var oFactura = (from d in db.vfacturas
                         where d.no_factura==factura
                         select d).FirstOrDefault();
            if (oFactura == null)
            {
                ViewBag.Error = "Factura no Existte";
                return View();
            }
            else
            {                
                fact.nofactura = oFactura.no_factura;
                fact.fecha = oFactura.fecha.Value;
                fact.cliente = oFactura.cliente.ToString();
                fact.total = oFactura.total.Value;
                fact.usuario = oFactura.usuario.ToString();
                fact.ListaArticulos = (from d in db.vdetalles
                                       where d.factura==factura
                                       select new ListArticulos
                                       {
                                           cantidad = d.cantidad,
                                           producto = d.producto,
                                           precio = d.precio,
                                           total = d.total.Value
                                       }).ToList();                
            }



            var ofertas = new List<String>();
            ofertas.Add("Descuento de producto");
            ofertas.Add("Producto Gratuito");
            ofertas.Add("Vale de regalo");
            ofertas.Add("Segundo producto a mitad de precio");
            ofertas.Add("Compra por mayoreo");
            ofertas.Add("Puntos por producto");



            Random r = new Random();
          

            Document doc = new Document(PageSize.LETTER);
            PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\HP14AC112LA\Downloads\Factura.pdf", FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            title.Add("LAS CASAS DEL ESCUINTLECO ");
            doc.Add(title);            
            doc.AddCreator(fact.usuario);

            doc.Add(new Paragraph("Factura No: "+fact.nofactura));
            doc.Add(new Paragraph("Cliente: "+fact.cliente));
            doc.Add(new Paragraph("Fecha: "+fact.fecha));

            doc.Add(Chunk.NEWLINE);

            PdfPTable table = new PdfPTable(4);
            // Esta es la primera fila
            table.AddCell("Cantidad");
            table.AddCell("Producto");
            table.AddCell("Precio Unitario");
            table.AddCell("Precio Total");

            double total = 0;

            foreach(var elemento in fact.ListaArticulos)
            {
                table.AddCell(elemento.cantidad.ToString());
                table.AddCell(elemento.producto);
                table.AddCell(elemento.precio.ToString());
                table.AddCell(elemento.total.ToString());
                total = total + elemento.total;
            }
            doc.Add(table);

            doc.Add(new Paragraph("Valor total: " + total));

            doc.Close();

            return View(fact);
        }

    }
}