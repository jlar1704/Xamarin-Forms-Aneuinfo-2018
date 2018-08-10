using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using PrismSeries.Models;

namespace PrismSeries.ViewModels
{
    public class DetailsPageViewModel : ViewModelBase
    {
        private Serie serie { get; set; }
        public DetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Details Page";
            serie = new Serie();
        }

        public override void OnNavigatingTo(NavigationParameters parameters){
            serie = (Serie)parameters["Serie"];  
        }


    }
}
