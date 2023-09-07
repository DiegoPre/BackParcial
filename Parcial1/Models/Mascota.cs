using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Mascota
{
    public string IdRaza { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string? NPatas { get; set; }
}
