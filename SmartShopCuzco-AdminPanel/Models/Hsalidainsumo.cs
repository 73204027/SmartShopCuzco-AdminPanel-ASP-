using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Hsalidainsumo
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdEmpleado { get; set; }

    public ulong Estado { get; set; }

    public virtual ICollection<Dsalidainsumo> Dsalidainsumos { get; set; } = new List<Dsalidainsumo>();

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
