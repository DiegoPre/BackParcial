using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Comidum
{
    public string IdComida { get; set; } = null!;

    public string NombreComida { get; set; } = null!;

    public string OrigenComida { get; set; } = null!;

    public double? PrecioComida { get; set; }
}
