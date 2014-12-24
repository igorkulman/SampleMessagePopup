using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227
using Caliburn.Micro;
using SampleMessagePopup.Services;
using SampleMessagePopup.ViewModels;
using SampleMessagePopup.Views;

namespace SampleMessagePopup
{
    public sealed partial class App
    {
        private WinRTContainer container;

        public bool IsBackNavigation { get; private set; }

        public App()
        {
            //LogManager.GetLog = type => new DebugLog(type);
            InitializeComponent();

        }

        protected override void Configure()
        {
            MessageBinder.SpecialValues.Add("$clickeditem", c => ((ItemClickEventArgs)c.EventArgs).ClickedItem);

            container = new WinRTContainer();

            container.RegisterWinRTServices();

            container.PerRequest<MainViewModel>();

            container.Singleton<DialogHelperService>();
        }

        protected override void PrepareViewFirst(Frame rootFrame)
        {
            container.RegisterNavigationService(rootFrame);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {

            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootView<MainView>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

    
    }
}