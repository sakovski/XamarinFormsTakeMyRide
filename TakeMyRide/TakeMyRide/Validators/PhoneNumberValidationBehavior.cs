using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TakeMyRide.Validators
{
    public class PhoneNumberValidationBehavior : Behavior<Entry>
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
            var phone = textChangedEventArgs.NewTextValue;
            var phoneEntry = sender as Entry;

            if (Regex.IsMatch(phone, RegexPatterns.phoneNumberPattern))
            {
                phoneEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                phoneEntry.BackgroundColor = Color.Red;
            }
        }
    }
}
