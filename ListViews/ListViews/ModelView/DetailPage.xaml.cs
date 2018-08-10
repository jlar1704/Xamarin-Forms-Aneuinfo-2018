using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ListViews.ModelView
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Empleados emp)
        {
            InitializeComponent();
            BindingContext = emp;
            NavigationPage.SetBackButtonTitle(this, "Empleados");
        }
    }
}
