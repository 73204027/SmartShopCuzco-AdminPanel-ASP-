using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdCategoriaProducto { get; set; }

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public ulong Estado { get; set; }

    public virtual ICollection<Dentradaproducto> Dentradaproductos { get; set; } = new List<Dentradaproducto>();

    public virtual ICollection<Dsalidaproducto> Dsalidaproductos { get; set; } = new List<Dsalidaproducto>();

    public virtual Categoriaproducto IdCategoriaProductoNavigation { get; set; } = null!;
}
