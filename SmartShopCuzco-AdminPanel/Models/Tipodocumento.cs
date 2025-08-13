using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Tipodocumento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public ulong Estado { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Proveedor> Proveedors { get; set; } = new List<Proveedor>();
}
