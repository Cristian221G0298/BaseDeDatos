using System;
using System.Collections.Generic;

namespace EjercicioBanderas.Models;

public partial class Paises
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Continente { get; set; }

    public string Region { get; set; } = null!;

    public float AreaSuperficie { get; set; }

    public short? IndepYear { get; set; }

    public int NumeroHabitantes { get; set; }

    public float? EsperanzaVida { get; set; }

    public float? Gnp { get; set; }

    public float? Gnpold { get; set; }

    public string FormaGobierno { get; set; } = null!;

    public string? Presidente { get; set; }
}
