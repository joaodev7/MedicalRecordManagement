using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class TaxNumberAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {           
            return ValidationResult.Success;
        }

        string taxNumber = value.ToString();
       
        taxNumber = Regex.Replace(taxNumber, "[^0-9]", "");

        if (taxNumber.Length != 11)
        {
            return new ValidationResult("O CPF deve conter exatamente 11 dígitos numéricos.");
        }
       
        if (new string(taxNumber[0], 11) == taxNumber)
        {
            return new ValidationResult("CPF inválido.");
        }
        
        int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempTaxNumber;
        string digit;
        int sum;
        int remainder;

        tempTaxNumber = taxNumber.Substring(0, 9);
        sum = 0;

        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(tempTaxNumber[i].ToString()) * multiplier1[i];
        }

        remainder = sum % 11;

        if (remainder < 2)
        {
            remainder = 0;
        }
        else
        {
            remainder = 11 - remainder;
        }

        digit = remainder.ToString();
        tempTaxNumber += digit;

        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(tempTaxNumber[i].ToString()) * multiplier2[i];
        }

        remainder = sum % 11;

        if (remainder < 2)
        {
            remainder = 0;
        }
        else
        {
            remainder = 11 - remainder;
        }

        digit += remainder.ToString();

        if (taxNumber.EndsWith(digit) == false)
        {
            return new ValidationResult("CPF inválido.");
        }

        return ValidationResult.Success;
    }
}
