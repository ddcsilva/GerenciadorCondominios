﻿using System.ComponentModel.DataAnnotations;

namespace GerenciadorCondominios.BLL.Models;

public class Evento
{
    public int EventoId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Nome { get; set; }


    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime Data { get; set; }

    public string UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }
}
