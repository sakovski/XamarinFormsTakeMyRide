using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TakeMyRide.Validators
{
    public class SeatsValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var seats = textChangedEventArgs.NewTextValue;
            var seatsEntry = sender as Entry;

            if (Regex.IsMatch(seats, RegexPatterns.seatsPattern))
            {
                seatsEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                seatsEntry.BackgroundColor = Color.Red;
            }
        }
    }
}
