﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GaiMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnProsmotrDtp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventDtpPage());
        }

        private void BtnAddDtp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDtpPage());
        }
    }
}
