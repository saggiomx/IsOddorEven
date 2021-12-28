using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Saggiomx.IsOddorEven.Api.Main.Validator
{
    public interface INumberValidator
    {
        public bool IsValid(string Numberr);
    }

    public class NumberValidator: INumberValidator
    {
        public bool IsValid(string number)
        { 
            if (!IsNumber(number))
                return false;

            if (!IsPositive(Convert.ToInt32(number)))
                return false;

            return true;
        }

        private bool IsPositive(int number) => number > 0;

        private bool IsNumber(string number) => int.TryParse(number, out var n);

    }
}