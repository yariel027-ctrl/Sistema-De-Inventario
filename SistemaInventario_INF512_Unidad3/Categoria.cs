namespace SistemaInventario
{
    public class Categoria
    {
        public string Nombre { get; set; }

        public Categoria(string nombre)
        {
            Nombre = nombre;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
