﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BehaviorEntryValidation
{
    public partial class BehaviorEntryValidationPage : ContentPage
    {
        public BehaviorEntryValidationPage()
        {
            // Ensure link to Toolkit library.
            new Xamarin.FormsBook.Toolkit.NumericValidationBehavior();

            InitializeComponent();
        }
    }
}
