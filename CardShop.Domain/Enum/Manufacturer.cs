using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardShop.Domain.Enum
{
    public enum Manufacturer : int
    {
        [Display(Name = "Nvidia")]
        Nvidia = 0,

        [Display(Name = "Advanced Micro Devices")]
        AMD = 1
    }
}
