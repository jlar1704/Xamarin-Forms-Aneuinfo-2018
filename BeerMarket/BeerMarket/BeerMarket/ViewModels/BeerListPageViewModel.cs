using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using BeerMarket.Services;
using System.Collections.ObjectModel;
using BeerMarket.Models;
using Xamarin.Forms;

namespace BeerMarket.ViewModels
{
    public class BeerListPageViewModel : ViewModelBase
    {
        private readonly IBeerServices _BeerService;
        private ObservableCollection<Beer> beerList;

        public BeerListPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Beer Lists";
            _BeerService = new BeerServices();
            beer = new Beer();
            BeerList = new ObservableCollection<Beer>();
            viewDetails = new Command(ExecuteViewDetails);
            GetBeersFromAPI();
        }

        public ObservableCollection<Beer> BeerList
        {
            get { return beerList; }
            set { SetProperty(ref beerList, value); }
        }

        private Beer beer;
        public Beer GetBeer
        {
            get { return beer; }
            set { 
                SetProperty(ref beer, value);

                if (value != null) {
                    ExecuteViewDetails();
                }

            }
        }


        public Command viewDetails { get; set; }

        private void ExecuteViewDetails()
        {
            NavigationParameters P = new NavigationParameters();
            P.Add("Beer", GetBeer);
            NavigationService.NavigateAsync("BeerDetailsPage", P);
        }

        async void GetBeersFromAPI()
        {
            IsRunning = true;
            var result = await _BeerService.GetAllBeersAsync();
            IsRunning = false;
            foreach (var item in result)
            {
                BeerList.Add(item);
            }
        }
    }
}
