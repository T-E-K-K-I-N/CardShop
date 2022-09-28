using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.Domain.Enum
{
    public enum StatusCode
    {
        GraphicsCardNotFound = 0,
        OK = 200,
        NotFound = 404,
        InternalServerError = 500
    }
}
