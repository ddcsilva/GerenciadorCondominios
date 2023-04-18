using System.ComponentModel.DataAnnotations;

namespace GerenciadorCondominios.BLL.Models;

public class Veiculo
{
    public int VeiculoId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Marca { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
    public string Cor { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Placa { get; set; }

    public string UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}
