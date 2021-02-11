using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ARCH.Client.Mobile.Models;
using ARCH.Client.Proxies;
using Xamarin.Forms;


namespace ARCH.Client.Mobile.ViewModels
{
    public class MainViewModel
    {
        public MainPageModel Model { get; set; }

        public ICommand ClickedCommand { get; set; }

        public MainViewModel()
        {
            ClickedCommand = new Command(Execute);

            
        }

        private async void Execute()
        {
            //DisplayAlert("TEST", param.ToString(), "OK");
            var p = new MyProxy();
            var user = await p.GetUser(Model.ID);
            Model.UserName = user.Name;

        }
    }
}
