# Sistema de Gestión de Inventario - INF-512 Unidad 3

## Descripción
Aplicación de consola desarrollada en C# para administrar productos, categorías e inventario de una empresa.

## Funcionalidades
- Registrar productos.
- Evitar códigos duplicados.
- Buscar productos por código.
- Listar productos.
- Modificar productos.
- Eliminar productos.
- Consultar productos por categoría.
- Mostrar productos agotados.
- Reponer productos agotados.
- Mostrar un resumen del inventario.
- Validar entradas incorrectas.

## Clases principales
- `Producto`: representa un producto y sus datos.
- `Categoria`: representa la categoría de un producto.
- `Almacen`: administra la colección de productos y las operaciones del inventario.
- `ReporteInventario`: genera consultas y resúmenes.
- `Program`: controla el menú y la interacción con el usuario.

## Contenedor utilizado
Se utiliza `List<Producto>` porque el inventario puede crecer y disminuir dinámicamente. Facilita las operaciones de agregar, eliminar y consultar objetos.

## Requisitos
- .NET 8 SDK o superior.
- Visual Studio, Visual Studio Code u otro IDE compatible con C#.

## Ejecución
Desde la carpeta del proyecto:

```bash
dotnet restore
dotnet run
```

## Integrantes
Ewris Yariel Calderon Diaz
Rey Sebastian Matos

## Distribución del trabajo
Completar con las responsabilidades reales de cada integrante y sus commits.

## UML
El diagrama UML debe representar exactamente las clases y relaciones de la versión entregada.

