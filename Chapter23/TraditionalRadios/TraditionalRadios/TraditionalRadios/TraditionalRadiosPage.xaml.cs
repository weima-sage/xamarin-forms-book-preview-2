﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TraditionalRadios
{
    public partial class TraditionalRadiosPage : ContentPage
    {
        public TraditionalRadiosPage()
        {
            // Ensure link to Toolkit library.
            new Xamarin.FormsBook.Toolkit.RadioBehavior();

            InitializeComponent();
        }
    }
}
