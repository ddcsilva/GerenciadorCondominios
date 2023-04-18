using System.ComponentModel.DataAnnotations;

namespace GerenciadorCondominios.BLL.Helpers;

public class IntervaloAnoAttribute : RangeAttribute
{
    public IntervaloAnoAttribute(int anoMinimo, int anoMaximo)
        : base(anoMinimo, DateTime.Now.Year + anoMaximo)
    {
    }
}


