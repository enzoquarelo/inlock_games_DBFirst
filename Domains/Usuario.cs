using System;
using System.Collections.Generic;

namespace inlock_games_DBFirst_manha.Domains;

public partial class Usuario
{
    public Guid Usuario1 { get; set; }

    public Guid? IdTiposUsuario { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual TiposUsuario? IdTiposUsuarioNavigation { get; set; }
}
