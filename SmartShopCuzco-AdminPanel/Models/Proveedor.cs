using System;
using System.Collections.Generic;

namespace SmartShopCuzco_AdminPanel.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public int IdDistrito { get; set; }

    public int IdTipoDireccion { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string? Correo { get; set; }

    public ulong Estado { get; set; }

    public virtual ICollection<Hentradainsumo> Hentradainsumos { get; set; } = new List<Hentradainsumo>();

    public virtual ICollection<Hentradaproducto> Hentradaproductos { get; set; } = new List<Hentradaproducto>();

    public virtual Distrito IdDistritoNavigation { get; set; } = null!;

    public virtual Tipodireccion IdTipoDireccionNavigation { get; set; } = null!;

    public virtual Tipodocumento IdTipoDocumentoNavigation { get; set; } = null!;
}
