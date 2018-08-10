﻿using Prism;
using Prism.Ioc;
using PrismSeries.ViewModels;
using PrismSeries.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using PrismSeries.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismSeries
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SeriesListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<SeriesListPage>();
            containerRegistry.RegisterForNavigation<DetailsPage>();
            containerRegistry.Register<ISeriesService, SeriesService>();
        }
        
    }
}
