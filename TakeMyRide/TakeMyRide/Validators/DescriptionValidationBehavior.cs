using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TakeMyRide.Validators
{
    public class DescriptionValidationBehavior : Behavior<Entry>
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
            var description = textChangedEventArgs.NewTextValue;
            var descriptionEntry = sender as Entry;

            if (Regex.IsMatch(description, RegexPatterns.descriptionPattern))
            {
                descriptionEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                descriptionEntry.BackgroundColor = Color.Red;
            }
        }
    }
}
