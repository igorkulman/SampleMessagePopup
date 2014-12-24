using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;
using SampleMessagePopup.Services;
using SampleMessagePopup.Interfaces;

namespace SampleMessagePopup.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        private readonly IDialogHelperService _dialogHelperService;

        public string Result { get; set; }

        public MainViewModel(IDialogHelperService dialogHelperService)
        {
            _dialogHelperService = dialogHelperService;
        }

        public async void Message()
        {
            var res = await _dialogHelperService.ShowMessageDialog("Do you really want to do this?", "My Title", "Hell yeah!", "No way");
            if (res)
            {
                Result = "Hell yeah!";
            }
            else
            {
                Result = "NOOOO!";
            }
        }
    }
}
