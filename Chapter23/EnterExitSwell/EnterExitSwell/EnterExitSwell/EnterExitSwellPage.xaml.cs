﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EnterExitSwell
{
    public partial class EnterExitSwellPage : ContentPage
    {
        public EnterExitSwellPage()
        {
            // Ensure Toolkit is loaded.
            new Xamarin.FormsBook.Toolkit.ScaleAction();

            InitializeComponent();
        }
    }
}
