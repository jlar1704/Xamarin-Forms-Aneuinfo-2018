using Plugins.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Plugins.ViewModels
{
	public class LocationListPageViewModel : ViewModelBase
	{
        private readonly Realm _realm;
        public IPageDialogService DialogService;
        public LocationListPageViewModel(INavigationService navigationService, Realm realm, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Saved List";
            _realm = realm;
            Locations = new ObservableCollection<UserLocation>();
            LoadLocationsFromLocalDatabase();
            DialogService = dialogService;
        }

        private void LoadLocationsFromLocalDatabase()
        {
            IsRunning = true;
            var allLocations = _realm.All<UserLocation>();
            Locations.Clear();
            foreach (var item in allLocations)
            {
                Locations.Add(item);
            }
            IsRunning = false;

        }

        public Command viewMaps { get; set; }

        private async void ExecuteViewMaps()
        {
            var action = await DialogService.DisplayActionSheetAsync("Opciones?", "Cancel", null, "Eliminar", "Ver Mapa");

            if (action=="Eliminar") {
                  var confirmacion = await DialogService.DisplayAlertAsync("Alert", "Esta Seguro que desea eliminar esta ubicacion","Yes","No");

                if (confirmacion){
                    var Eliminar = _realm.All<UserLocation>().First(b => b.Value == Location.Value);

                    using (var trans = _realm.BeginWrite())
                    {
                        _realm.Remove(Eliminar);
                        trans.Commit();
                        LoadLocationsFromLocalDatabase();
                    }
                }
            }

            if (action == "Ver Mapa")
            {
                NavigationParameters P = new NavigationParameters();
                P.Add("Localizacion", Location);
                await NavigationService.NavigateAsync("MapPage", P);
            }
        }

        private UserLocation _location;
        public UserLocation Location
        {
            get { return _location; }
            set
            {
                SetProperty(ref _location, value);

                if (value != null)
                {
                    ExecuteViewMaps();
                }

            }
        }



        private ObservableCollection<UserLocation> locations;
        public ObservableCollection<UserLocation> Locations
        {
            get { return locations; }
            set { SetProperty(ref locations, value); }
        }


    }
}
