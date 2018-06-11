using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TakeMyRide.Validators
{
    public class EmailValidationBehavior : Behavior<Entry>
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
            var email = textChangedEventArgs.NewTextValue;
            var emailEntry= sender as Entry;

            if (Regex.IsMatch(email, RegexPatterns.emailPattern))
            {
                emailEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                emailEntry.BackgroundColor = Color.Red;
            }
        }
    }
}
