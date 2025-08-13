using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Dentradainsumo
{
    public int Id { get; set; }

    public int IdHentradaInsumo { get; set; }

    public int IdInsumo { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public ulong Estado { get; set; }

    public virtual Hentradainsumo IdHentradaInsumoNavigation { get; set; } = null!;

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;
}
