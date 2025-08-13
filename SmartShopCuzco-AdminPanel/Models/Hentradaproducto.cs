using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Hentradaproducto
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdProveedor { get; set; }

    public int IdEmpleado { get; set; }

    public ulong Estado { get; set; }

    public virtual ICollection<Dentradaproducto> Dentradaproductos { get; set; } = new List<Dentradaproducto>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
