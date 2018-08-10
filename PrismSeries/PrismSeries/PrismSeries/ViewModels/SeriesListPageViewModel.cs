using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSeries.Models;
using PrismSeries.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace PrismSeries.ViewModels
{
    public class SeriesListPageViewModel : ViewModelBase
    {
        private readonly ISeriesService _seriesService;
        private INavigationService _NavigationSeries { get; set; }
        private Serie _SerieSelected;

        public SeriesListPageViewModel(INavigationService navigationService, ISeriesService seriesService) :
            base(navigationService)
        {
            _seriesService = seriesService;
            Title = "Prism Series";
            SeriesList = new ObservableCollection<Serie>();
            GetSeriesFromAPI();
            GoDetails = new DelegateCommand(GoDetail);
        }
        private ObservableCollection<Serie> seriesList;
        public ObservableCollection<Serie> SeriesList
        {
            get { return seriesList; }
            set { SetProperty(ref seriesList, value); }
        }

        async void GetSeriesFromAPI()
        {
            IsRunning = true;
            var result = await _seriesService.GetAllSeriesAsync();
            IsRunning = false;
            foreach (var item in result)
            {
                SeriesList.Add(item);
            }

        }

        public Serie SerieSelected{
            get { return _SerieSelected; }
            set { SetProperty(ref _SerieSelected, value); }
        }

        public DelegateCommand GoDetails{ get; private set; }

        async void GoDetail()
        {
                var np = new NavigationParameters();
                np.Add("Serie", SerieSelected);
                await _NavigationSeries.NavigateAsync("DetailsPage", np);
        }

    }
}
