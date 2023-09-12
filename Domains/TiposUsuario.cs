using System;
using System.Collections.Generic;

namespace inlock_games_DBFirst_manha.Domains;

public partial class TiposUsuario
{
    public Guid IdTiposUsuario { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
