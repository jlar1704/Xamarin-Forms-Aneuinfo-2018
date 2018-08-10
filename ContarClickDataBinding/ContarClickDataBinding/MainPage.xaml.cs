using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContarClickDataBinding.MVVM;
using Xamarin.Forms;

namespace ContarClickDataBinding
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new FieldContector();
        }
 
    }
}
