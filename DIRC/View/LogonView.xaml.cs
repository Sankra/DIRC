﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DIRC.View {
	public partial class LogonView : ContentPage {
		public LogonView() {
			InitializeComponent();
			BindingContext = new LogonViewModel(Navigation);
			NavigationPage.SetHasNavigationBar(this, false);
			NavigationPage.SetHasBackButton(this, false);
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (Device.OS == TargetPlatform.Android)
            {
                return;
            }

            Navigation.RemovePage(this);
        }
	}
}

