﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EntrySwell
{
    public partial class EntrySwellPage : ContentPage
    {
        public EntrySwellPage()
        {
            // Ensure Toolkit library is loaded.
            new Xamarin.FormsBook.Toolkit.ScaleAction();

            InitializeComponent();
        }
    }
}
