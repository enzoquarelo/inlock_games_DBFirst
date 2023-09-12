using System;
using System.Collections.Generic;

namespace inlock_games_DBFirst_manha.Domains;

public partial class Jogo
{
    public Guid IdJogos { get; set; }

    public Guid? IdEstudio { get; set; }

    public string Nome { get; set; } = null!;

    public string Descrição { get; set; } = null!;

    public DateTime DataLançamento { get; set; }

    public decimal Valor { get; set; }

    public virtual Estudio? IdEstudioNavigation { get; set; }
}
