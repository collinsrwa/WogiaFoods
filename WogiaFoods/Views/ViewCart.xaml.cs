﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WogiaFoods.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCart : ContentPage
    {
        public ViewCart()
        {
            InitializeComponent();
            LabelName.Text = "Welcome " + Preferences.Get("UserName", "Guest") + ",";
        }
        async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}