using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Saggiomx.IsOddorEven.Api.Main.Model
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }
        public ErrorResponse(string errorNumber, string description, string moreInfo)
        {
            ErrorNumber = errorNumber;
            Description = description;
            MoreInfo = moreInfo;
        }

        public string ErrorNumber { get; set; }
        public string Description { get; set; }
        public string MoreInfo { get; set; }
    }
}
