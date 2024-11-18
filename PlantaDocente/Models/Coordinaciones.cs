using System;
using System.Collections.Generic;

namespace PlantaDocente.Models;

public partial class Coordinaciones
{
    public string Clave { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Docentes> Docentes { get; set; } = new List<Docentes>();
}
