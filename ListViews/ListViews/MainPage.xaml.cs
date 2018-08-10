using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ListViews.ModelView;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ListViews
{
    public partial class MainPage : ContentPage
    {
        BusinessLogic bl = new BusinessLogic();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = bl;
            MyListView.ItemsSource = bl.GetEmpleados();
            NavigationPage.SetBackButtonTitle(this, "Empleados");
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
         {
             if (MyListView.SelectedItem != null)
             {
                 var detailPage = new DetailPage(e.SelectedItem as Empleados);
                 MyListView.SelectedItem = null;
                await Navigation.PushAsync(detailPage, true);
          }
        }
    }
}
