using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Propietario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Estrato { get; set; }

    public string Sexo { get; set; } = null!;
}
