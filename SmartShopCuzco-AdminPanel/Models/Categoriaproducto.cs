using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Categoriaproducto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public ulong Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
