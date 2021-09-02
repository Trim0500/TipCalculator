using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TipCalculator.Models
{
    //Model class for the data inoutted and calculated
    public class TipCost
    {
        [Required(ErrorMessage = "You must enter a value for the cost of the meal")] //Use the tag helpers from the view imports to declare a required field with a custom message
        [Range(0, 1000000, ErrorMessage = "You must enter a value in between 0 & 1,000,000")] //Use the tag helpers from the view imports to declare a range for the field with a custom message
        public double? mealCost { get; set; }
        public double? tip15 { get; set; }
        public double? tip20 { get; set; }
        public double? tip25 { get; set; }

        //Declare a method to calculate the 15% tip total
        public double? CalcTip15(double? mealCost)
        {
            double? total;

            total = mealCost * .15;

            tip15 = total;

            return tip15;
        }

        //Declare a method to calculate the 20% tip total
        public double? CalcTip20(double? mealCost)
        {
            double? total;

            total = mealCost * .20;

            tip20 = total;

            return tip20;
        }

        //Declare a method to calculate the 25% tip total
        public double? CalcTip25(double? mealCost)
        {
            double? total;

            total = mealCost * .25;

            tip25 = total;

            return tip25;
        }
    }
}
