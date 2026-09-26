namespace SistemaInventario
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public Categoria Categoria { get; set; }

        public Producto(string codigo, string nombre, decimal precio, int cantidad, Categoria categoria)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Categoria = categoria;
        }

        public void Mostrar()
        {
            Console.WriteLine($"Código: {Codigo}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Precio: RD$ {Precio:N2}");
            Console.WriteLine($"Cantidad: {Cantidad}");
            Console.WriteLine($"Categoría: {Categoria.Nombre}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
