using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models;

public partial class Categorium
{
    public int IdCatgoria { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
