using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TipCalculator.Models
{
    public class TipCost
    {
        [Required(ErrorMessage = "You must enter a value for the cost of the meal")]
        [Range(0, 1000000, ErrorMessage = "You must enter a value in between 0 & 1,000,000")]
        public double? mealCost { get; set; }
        public double? tip15 { get; set; }
        public double? tip20 { get; set; }
        public double? tip25 { get; set; }

        public double? CalcTip15(double? mealCost)
        {
            double? total;

            total = mealCost * .15;

            tip15 = total;

            return tip15;
        }

        public double? CalcTip20(double? mealCost)
        {
            double? total;

            total = mealCost * .20;

            tip20 = total;

            return tip20;
        }

        public double? CalcTip25(double? mealCost)
        {
            double? total;

            total = mealCost * .25;

            tip25 = total;

            return tip25;
        }
    }
}
