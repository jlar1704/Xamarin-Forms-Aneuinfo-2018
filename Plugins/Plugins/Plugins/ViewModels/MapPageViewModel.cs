using Plugins.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms.Maps;

namespace Plugins.ViewModels
{
	public class MapPageViewModel : ViewModelBase
	{
        private UserLocation currentposition;
        private float latitude;         private float longitud;         public Pin mypin;         public Position position;
        public Map MyMap { get; private set; }          public float Latitude         {             get { return latitude; }             set             {                 SetProperty(ref latitude, value);              }         }          public float Longitud         {             get { return longitud; }             set             {                 SetProperty(ref longitud, value);              }         } 
        public Position Position
        {
            get { return position; }
            set
            {
                SetProperty(ref position, value);

            }
        }

        public Pin MyPin
        {
            get { return mypin; }
            set
            {
                SetProperty(ref mypin, value);

            }
        }
    public MapPageViewModel(INavigationService navigationService) : base(navigationService)         {             Title = "Maps Location";
            MyMap = new Map();         }          public override void OnNavigatingTo(NavigationParameters parameters)         {             base.OnNavigatingTo(parameters);
            int id = 0;
            var val="";             currentposition = (UserLocation)parameters["Localizacion"];              String[] substrings = currentposition.Value.ToString().Split(',');
            foreach (var substring in substrings) {
                if (id==0){
                  val = substring.Replace("Long.: ", "");
                    Longitud = float.Parse(val, CultureInfo.InvariantCulture.NumberFormat);
                }
                else{
                    val = substring.Replace("Lat.: ", "");  
                    Latitude = float.Parse(val, CultureInfo.InvariantCulture.NumberFormat);
                }

                id++;

            }
                                 Position = new Position (Latitude, Longitud);             MyPin = new Pin             {                 Label = $"Position Latitude:{Latitude.ToString()} - Longitud:{Longitud.ToString()}",                 Position = position,                 Type = PinType.Place              };

            MyMap.MapType = MapType.Street;
            MyMap.HasZoomEnabled = true;
            MyMap.HasScrollEnabled = true;
            MyMap.Pins.Add(MyPin);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(Position, Distance.FromKilometers(1.5)));


        }
	}
}
