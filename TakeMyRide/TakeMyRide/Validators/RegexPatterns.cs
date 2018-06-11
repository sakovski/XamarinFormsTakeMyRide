using System;
using System.Collections.Generic;
using System.Text;

namespace TakeMyRide.Validators
{
    public static class RegexPatterns
    {
        public const string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string phoneNumberPattern = "^([0-9]{9})$";
        public const string descriptionPattern = "^.{1,100}$";
        public const string seatsPattern = "^[1-9]$";
        public const string namePattern = "^[A-ZĆŁŚŹŻ][a-ząćęłńóśźżA-ZĄĆĘŁŃÓŚŹŻ-]{2,29}$";
        public const string pricePattern = "^([0-9]{1,5})([.]{0,1})([0-9]{0,2})$";
    }
}
