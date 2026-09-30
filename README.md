# Sistema de Gestión de Inventario - INF-512 Unidad 3


## Integrantes
Ewris Yariel Calderon Diaz,
Rey Sebastian Matos

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

## UML
El diagrama UML debe representar exactamente las clases y relaciones de la versión entregada.


##title Sistema de Gestión de Inventario - INF-512

class Producto {
    +Codigo : string
    +Nombre : string
    +Precio : decimal
    +Cantidad : int
    +Categoria : Categoria
    +Producto(codigo, nombre, precio, cantidad, categoria)
    +Mostrar() : void
}

class Categoria {
    +Nombre : string
    +Categoria(nombre)
    +ToString() : string
}

class Almacen {
    -productos : List<Producto>
    +Almacen()
    +RegistrarProducto(producto) : bool
    +BuscarProducto(codigo) : Producto?
    +BuscarPorNombre(nombre) : List<Producto>
    +BuscarPorCategoria(nombreCategoria) : List<Producto>
    +EliminarProducto(codigo) : bool
    +ModificarProducto(codigo, nombre, precio, cantidad, categoria) : bool
    +ReponerProducto(codigo, cantidad) : bool
    +ObtenerProductos() : List<Producto>
    +ObtenerAgotados() : List<Producto>
}

class ReporteInventario {
    -almacen : Almacen
    +ReporteInventario(almacen)
    +MostrarProductosAgotados() : void
    +MostrarResumen() : void
}

class Program {
    +Main(args) : void
}

Almacen "1" o-- "0..*" Producto : administra
Producto "*" --> "1" Categoria : pertenece a
ReporteInventario "1" --> "1" Almacen : consulta
Program ..> Almacen : utiliza
Program ..> ReporteInventario : utiliza

@enduml
g UML.puml…]()


