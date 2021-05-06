using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GlassFillingRobot.Enums
{
    enum OrientationEnum
    {
        [Display(Name = "N")]
        North = 1,
        [Display(Name = "W")]
        West = 2,
        [Display(Name = "S")]
        South = 3,
        [Display(Name = "E")]
        East = 4
    }
}
