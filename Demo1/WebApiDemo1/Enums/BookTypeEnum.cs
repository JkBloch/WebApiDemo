using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JkBook.Enums
{
    public enum BookTypeEnum
    {
        [Display(Name ="Programming")]
        Programming=1,

        [Display(Name = "Scripting")]
        Scripting =2,
        [Display(Name = "Database")]
        Database =3,
        [Display(Name = "Framework")]
        Framwork =4,
        [Display(Name = "User Interface Tools")]
        UITools =5
    }

}
