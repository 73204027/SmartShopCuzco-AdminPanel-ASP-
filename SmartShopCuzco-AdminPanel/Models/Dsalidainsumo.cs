using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Dsalidainsumo
{
    public int Id { get; set; }

    public int IdHsalidaInsumo { get; set; }

    public int IdInsumo { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public ulong Estado { get; set; }

    public virtual Hsalidainsumo IdHsalidaInsumoNavigation { get; set; } = null!;

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;
}
