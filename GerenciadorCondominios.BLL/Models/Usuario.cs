using GerenciadorCondominios.BLL.Helpers;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorCondominios.BLL.Models;

public class Usuario : IdentityUser<string>
{
    [CpfValidacao(ErrorMessage = "CPF inválido.")]
    public string CPF { get; set; }
    public string Foto { get; set; }

    public bool PrimeiroAcesso { get; set; }
    public StatusConta Status { get; set; }

    public virtual ICollection<Apartamento> MoradoresApartamentos { get; set; }
    public virtual ICollection<Apartamento> ProprietariosApartamentos { get; set; }
    public virtual ICollection<Veiculo> Veiculos { get; set; }
    public virtual ICollection<Evento> Eventos { get; set; }
    public virtual ICollection<Servico> Servicos { get; set; }
    public virtual ICollection<Pagamento> Pagamentos { get; set; }

}

public enum StatusConta
{
    Analisando, Aprovado, Reprovado
}
