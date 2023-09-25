using System;
using System.Collections.Generic;
using System.Text;

namespace TRAVEL01
{
    public static class DatosVentas
    {
        public static List<Compra> compras { get; } = new List<Compra>();
        
    }

    public class Compra
    {
        public int CantidadAdultos { get; set; }
        public int CantidadNinos { get; set; }
        public string Fecha { get; set; }

    }
}
