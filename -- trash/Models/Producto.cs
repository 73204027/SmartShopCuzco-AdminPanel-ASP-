public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public int IdCategoriaProducto { get; set; }
    //public CategoriaProducto Categoria { get; set; } = null!;
    public bool Estado { get; set; } = true;
}

