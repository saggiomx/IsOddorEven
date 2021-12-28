using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saggiomx.IsOddorEven.Api.Main.Servic
{
    public interface IIsOddOrEvenService
    {
        public bool HasReminder(int dividend, int divisor);
    }

    public class IsOddOrEvenService : IIsOddOrEvenService
    {
        public bool HasReminder(int dividend, int divisor = 2)
        {
            try
            {
                return dividend % divisor != 0;
            }
            catch (DivideByZeroException ex)
            {
                throw;
            }
        }

        
    }
}
