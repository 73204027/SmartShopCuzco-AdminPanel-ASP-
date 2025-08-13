using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPa { get; set; } = null!;

    public string ApellidoMa { get; set; } = null!;

    public int IdTipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public int IdCargo { get; set; }

    public string? Celular { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int IdSexo { get; set; }

    public string Usuario { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public ulong Estado { get; set; }

    public virtual ICollection<Hentradainsumo> Hentradainsumos { get; set; } = new List<Hentradainsumo>();

    public virtual ICollection<Hentradaproducto> Hentradaproductos { get; set; } = new List<Hentradaproducto>();

    public virtual ICollection<Hsalidainsumo> Hsalidainsumos { get; set; } = new List<Hsalidainsumo>();

    public virtual ICollection<Hsalidaproducto> Hsalidaproductos { get; set; } = new List<Hsalidaproducto>();

    public virtual Cargo IdCargoNavigation { get; set; } = null!;

    public virtual Sexo IdSexoNavigation { get; set; } = null!;

    public virtual Tipodocumento IdTipoDocumentoNavigation { get; set; } = null!;
}
