using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Insumo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    public ulong Estado { get; set; }

    public virtual ICollection<Dentradainsumo> Dentradainsumos { get; set; } = new List<Dentradainsumo>();

    public virtual ICollection<Dsalidainsumo> Dsalidainsumos { get; set; } = new List<Dsalidainsumo>();
}
