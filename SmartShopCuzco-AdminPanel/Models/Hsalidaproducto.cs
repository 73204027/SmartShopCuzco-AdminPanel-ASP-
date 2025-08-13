using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Hsalidaproducto
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdEmpleado { get; set; }

    public ulong Estado { get; set; }

    public virtual ICollection<Dsalidaproducto> Dsalidaproductos { get; set; } = new List<Dsalidaproducto>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
