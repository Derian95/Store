using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Store.Models;

public partial class Rol
{
    public int IdRol { get; set; }
   
    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
