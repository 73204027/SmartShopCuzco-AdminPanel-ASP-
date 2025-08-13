using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Dsalidaproducto
{
    public int Id { get; set; }

    public int IdHsalidaProducto { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public ulong Estado { get; set; }

    public virtual Hsalidaproducto IdHsalidaProductoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
