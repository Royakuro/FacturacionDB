using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionFerreteria
{
    public class Receipt
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string Total { get { return string.Format("{0}$", Precio * Cantidad); } }
    }
}
