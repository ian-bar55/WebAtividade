using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Validators
{
    public class CPFValido : ValidationAttribute
    {
        protected string CPF { get; set; }
        protected string GetErrorMessage() =>
            $"Digite um CPF válido";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            CPF = value.ToString();
            return ValidarCPF(CPF) ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
        }

        /// <summary>
        /// Valida o  CPF
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        private bool ValidarCPF(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            CPF = CPF.Trim().Replace(".", "").Replace("-", "");
            if (CPF.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == CPF)
                    return false;

            string tempCPF = CPF.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCPF[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCPF = tempCPF + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCPF[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return CPF.EndsWith(digito);
        }
    }
}