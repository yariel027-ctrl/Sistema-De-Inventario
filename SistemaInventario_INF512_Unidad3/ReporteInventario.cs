namespace SistemaInventario
{
    public class ReporteInventario
    {
        private readonly Almacen almacen;

        public ReporteInventario(Almacen almacen)
        {
            this.almacen = almacen;
        }

        public void MostrarProductosAgotados()
        {
            List<Producto> agotados = almacen.ObtenerAgotados();

            Console.WriteLine("\n=== PRODUCTOS AGOTADOS ===");

            if (agotados.Count == 0)
            {
                Console.WriteLine("No hay productos agotados.");
                return;
            }

            foreach (Producto producto in agotados)
            {
                producto.Mostrar();
            }
        }

        public void MostrarResumen()
        {
            List<Producto> productos = almacen.ObtenerProductos();

            int cantidadProductos = productos.Count;
            int unidadesTotales = productos.Sum(p => p.Cantidad);
            int agotados = productos.Count(p => p.Cantidad == 0);
            decimal valorInventario = productos.Sum(p => p.Precio * p.Cantidad);

            Console.WriteLine("\n=== RESUMEN DEL INVENTARIO ===");
            Console.WriteLine($"Productos registrados: {cantidadProductos}");
            Console.WriteLine($"Unidades disponibles: {unidadesTotales}");
            Console.WriteLine($"Productos agotados: {agotados}");
            Console.WriteLine($"Valor total del inventario: RD$ {valorInventario:N2}");
        }
    }
}
