namespace SistemaInventario
{
    public class Almacen
    {
        private readonly List<Producto> productos;

        public Almacen()
        {
            productos = new List<Producto>();
        }

        public bool RegistrarProducto(Producto producto)
        {
            if (BuscarProducto(producto.Codigo) != null)
                return false;

            productos.Add(producto);
            return true;
        }

        public Producto? BuscarProducto(string codigo)
        {
            return productos.FirstOrDefault(
                p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        public List<Producto> BuscarPorNombre(string nombre)
        {
            return productos
                .Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Producto> BuscarPorCategoria(string nombreCategoria)
        {
            return productos
                .Where(p => p.Categoria.Nombre.Equals(
                    nombreCategoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool EliminarProducto(string codigo)
        {
            Producto? producto = BuscarProducto(codigo);

            if (producto == null)
                return false;

            productos.Remove(producto);
            return true;
        }

        public bool ModificarProducto(
            string codigo,
            string nuevoNombre,
            decimal nuevoPrecio,
            int nuevaCantidad,
            Categoria nuevaCategoria)
        {
            Producto? producto = BuscarProducto(codigo);

            if (producto == null)
                return false;

            producto.Nombre = nuevoNombre;
            producto.Precio = nuevoPrecio;
            producto.Cantidad = nuevaCantidad;
            producto.Categoria = nuevaCategoria;

            return true;
        }

        public bool ReponerProducto(string codigo, int cantidad)
        {
            Producto? producto = BuscarProducto(codigo);

            if (producto == null || cantidad <= 0)
                return false;

            producto.Cantidad += cantidad;
            return true;
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }

        public List<Producto> ObtenerAgotados()
        {
            return productos.Where(p => p.Cantidad == 0).ToList();
        }
    }
}
