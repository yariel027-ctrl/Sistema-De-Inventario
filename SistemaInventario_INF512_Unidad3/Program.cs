namespace SistemaInventario
{
    public class Program
    {
        static void Main(string[] args)
        {
            Almacen almacen = new Almacen();
            ReporteInventario reporte = new ReporteInventario(almacen);

            CargarDatosIniciales(almacen);

            int opcion;

            do
            {
                MostrarMenu();
                opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        RegistrarProducto(almacen);
                        break;

                    case 2:
                        BuscarProducto(almacen);
                        break;

                    case 3:
                        ListarProductos(almacen);
                        break;

                    case 4:
                        ModificarProducto(almacen);
                        break;

                    case 5:
                        EliminarProducto(almacen);
                        break;

                    case 6:
                        ConsultarPorCategoria(almacen);
                        break;

                    case 7:
                        reporte.MostrarProductosAgotados();
                        break;

                    case 8:
                        ReponerProducto(almacen);
                        break;

                    case 9:
                        reporte.MostrarResumen();
                        break;

                    case 0:
                        Console.WriteLine("\nPrograma finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("       SISTEMA DE GESTIÓN DE INVENTARIO");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Buscar producto");
            Console.WriteLine("3. Listar productos");
            Console.WriteLine("4. Modificar producto");
            Console.WriteLine("5. Eliminar producto");
            Console.WriteLine("6. Consultar por categoría");
            Console.WriteLine("7. Mostrar productos agotados");
            Console.WriteLine("8. Reponer producto agotado");
            Console.WriteLine("9. Mostrar resumen del inventario");
            Console.WriteLine("0. Salir");
            Console.WriteLine("==========================================");
        }

        static void RegistrarProducto(Almacen almacen)
        {
            Console.WriteLine("\n=== REGISTRAR PRODUCTO ===");

            string codigo = LeerTexto("Código: ");

            if (almacen.BuscarProducto(codigo) != null)
            {
                Console.WriteLine("Error: ya existe un producto con ese código.");
                return;
            }

            string nombre = LeerTexto("Nombre: ");
            decimal precio = LeerDecimalNoNegativo("Precio: RD$ ");
            int cantidad = LeerEnteroNoNegativo("Cantidad: ");
            string nombreCategoria = LeerTexto("Categoría: ");

            Categoria categoria = new Categoria(nombreCategoria);
            Producto producto = new Producto(
                codigo, nombre, precio, cantidad, categoria);

            if (almacen.RegistrarProducto(producto))
                Console.WriteLine("Producto registrado correctamente.");
            else
                Console.WriteLine("No fue posible registrar el producto.");
        }

        static void BuscarProducto(Almacen almacen)
        {
            Console.WriteLine("\n=== BUSCAR PRODUCTO ===");
            string codigo = LeerTexto("Código: ");

            Producto? producto = almacen.BuscarProducto(codigo);

            if (producto == null)
            {
                Console.WriteLine("No se encontró ningún producto con ese código.");
                return;
            }

            producto.Mostrar();
        }

        static void ListarProductos(Almacen almacen)
        {
            Console.WriteLine("\n=== LISTA DE PRODUCTOS ===");
            List<Producto> productos = almacen.ObtenerProductos();

            if (productos.Count == 0)
            {
                Console.WriteLine("No hay productos registrados.");
                return;
            }

            foreach (Producto producto in productos)
                producto.Mostrar();
        }

        static void ModificarProducto(Almacen almacen)
        {
            Console.WriteLine("\n=== MODIFICAR PRODUCTO ===");
            string codigo = LeerTexto("Código del producto: ");

            Producto? producto = almacen.BuscarProducto(codigo);

            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }

            string nombre = LeerTexto("Nuevo nombre: ");
            decimal precio = LeerDecimalNoNegativo("Nuevo precio: RD$ ");
            int cantidad = LeerEnteroNoNegativo("Nueva cantidad: ");
            string categoriaNombre = LeerTexto("Nueva categoría: ");

            Categoria categoria = new Categoria(categoriaNombre);

            if (almacen.ModificarProducto(
                codigo, nombre, precio, cantidad, categoria))
            {
                Console.WriteLine("Producto modificado correctamente.");
            }
        }

        static void EliminarProducto(Almacen almacen)
        {
            Console.WriteLine("\n=== ELIMINAR PRODUCTO ===");
            string codigo = LeerTexto("Código: ");

            if (almacen.EliminarProducto(codigo))
                Console.WriteLine("Producto eliminado correctamente.");
            else
                Console.WriteLine("No se encontró el producto.");
        }

        static void ConsultarPorCategoria(Almacen almacen)
        {
            Console.WriteLine("\n=== CONSULTAR POR CATEGORÍA ===");
            string categoria = LeerTexto("Categoría: ");

            List<Producto> productos =
                almacen.BuscarPorCategoria(categoria);

            if (productos.Count == 0)
            {
                Console.WriteLine("No se encontraron productos de esa categoría.");
                return;
            }

            foreach (Producto producto in productos)
                producto.Mostrar();
        }

        static void ReponerProducto(Almacen almacen)
        {
            Console.WriteLine("\n=== REPONER PRODUCTO ===");
            string codigo = LeerTexto("Código: ");

            Producto? producto = almacen.BuscarProducto(codigo);

            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }

            Console.WriteLine($"Cantidad actual: {producto.Cantidad}");

            int cantidad = LeerEnteroPositivo(
                "Cantidad a agregar: ");

            if (almacen.ReponerProducto(codigo, cantidad))
            {
                Console.WriteLine(
                    $"Reposición realizada. Nueva cantidad: {producto.Cantidad}");
            }
            else
            {
                Console.WriteLine("No fue posible realizar la reposición.");
            }
        }

        static void CargarDatosIniciales(Almacen almacen)
        {
            Categoria electronica = new Categoria("Electrónica");
            Categoria oficina = new Categoria("Oficina");
            Categoria accesorios = new Categoria("Accesorios");

            almacen.RegistrarProducto(
                new Producto("P001", "Teclado", 1200m, 10, electronica));

            almacen.RegistrarProducto(
                new Producto("P002", "Mouse", 750m, 0, accesorios));

            almacen.RegistrarProducto(
                new Producto("P003", "Monitor", 8500m, 5, electronica));

            almacen.RegistrarProducto(
                new Producto("P004", "Cuaderno", 150m, 0, oficina));
        }

        static string LeerTexto(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada.Trim();

                Console.WriteLine("El valor no puede estar vacío.");
            }
        }

        static int LeerEntero(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);

                if (int.TryParse(Console.ReadLine(), out int valor))
                    return valor;

                Console.WriteLine("Entrada inválida. Debe introducir un número entero.");
            }
        }

        static int LeerEnteroNoNegativo(string mensaje)
        {
            while (true)
            {
                int valor = LeerEntero(mensaje);

                if (valor >= 0)
                    return valor;

                Console.WriteLine("El valor no puede ser negativo.");
            }
        }

        static int LeerEnteroPositivo(string mensaje)
        {
            while (true)
            {
                int valor = LeerEntero(mensaje);

                if (valor > 0)
                    return valor;

                Console.WriteLine("El valor debe ser mayor que cero.");
            }
        }

        static decimal LeerDecimalNoNegativo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);

                if (decimal.TryParse(Console.ReadLine(), out decimal valor)
                    && valor >= 0)
                {
                    return valor;
                }

                Console.WriteLine(
                    "Entrada inválida. Introduzca un número mayor o igual a cero.");
            }
        }
    }
}
