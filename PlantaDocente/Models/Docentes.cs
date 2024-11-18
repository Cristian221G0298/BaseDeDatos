using System;
using System.Collections.Generic;

namespace PlantaDocente.Models;

public partial class Docentes
{
    public uint Clave { get; set; }

    public string Nombre { get; set; } = null!;

    public string IdCoordinacion { get; set; } = null!;

    public virtual Coordinaciones IdCoordinacionNavigation { get; set; } = null!;
}
