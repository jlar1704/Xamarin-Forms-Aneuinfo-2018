using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using BeerMarket.Models;

namespace BeerMarket.ViewModels
{
    public class BeerDetailsPageViewModel : ViewModelBase
    {
        private Beer beer;
       
        public Beer GetBeer
        {
            get { return beer; }
            set { SetProperty(ref beer, value); 

            }
        }

        public BeerDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Detail Page";
            beer = new Beer();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            GetBeer = (Beer)parameters["Beer"];
        }

    }
}
