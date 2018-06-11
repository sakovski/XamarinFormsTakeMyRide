using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Validators
{
    public static class DatesValidators
    {
        public static bool IsDateOfBirthValid(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (dateOfBirth > today.AddYears(-age)) age--;
            return age >= 18;
        }

        public static bool IsDateOfRideValid(DateTime dateOfRide)
        {
            return dateOfRide > DateTime.Now; 
        }
    }
}
