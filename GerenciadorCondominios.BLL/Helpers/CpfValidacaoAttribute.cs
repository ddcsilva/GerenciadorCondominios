using System.ComponentModel.DataAnnotations;

namespace GerenciadorCondominios.BLL.Helpers;

public class CpfValidacaoAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object valor, ValidationContext contextoValidacao)
    {
        if (valor == null)
        {
            return new ValidationResult("O CPF é obrigatório.");
        }

        string cpf = valor.ToString().Replace(".", "").Replace("-", "");

        if (cpf.Length != 11 || !CpfValido(cpf))
        {
            return new ValidationResult("CPF inválido.");
        }

        return ValidationResult.Success;
    }

    private bool CpfValido(string cpf)
    {
        int[] multiplicadoresPrimeiroDigito = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicadoresSegundoDigito = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        cpf = cpf.Trim().Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
        {
            return false;
        }

        for (int i = 0; i < 10; i++)
        {
            if (cpf == new string(i.ToString()[0], 11))
            {
                return false;
            }
        }

        int soma = 0;

        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * multiplicadoresPrimeiroDigito[i];
        }

        int resto = soma % 11;

        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        string digitoVerificador = resto.ToString();
        string primeiroDigito = cpf.Substring(9, 1);

        if (primeiroDigito != digitoVerificador)
        {
            return false;
        }

        soma = 0;

        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * multiplicadoresSegundoDigito[i];
        }

        resto = soma % 11;

        if (resto < 2)
        {
            resto = 0;
        }
        else
        {
            resto = 11 - resto;
        }

        digitoVerificador = digitoVerificador + resto.ToString();
        string doisDigitos = cpf.Substring(9, 2);

        return doisDigitos == digitoVerificador;
    }
}
