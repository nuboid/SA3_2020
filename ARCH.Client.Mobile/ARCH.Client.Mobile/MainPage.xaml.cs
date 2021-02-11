using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ARCH.Client.Mobile.Data;
using ARCH.Client.Mobile.Models;
using ARCH.Client.Proxies;
using LiteDB;
using Xamarin.Forms;

namespace ARCH.Client.Mobile
{
    public partial class MainPage : ContentPage
    {

        public ICommand ClickedCommand { get; set; }
        public MainPageModel Model { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ClickedCommand = new Command(Execute);
            Model = new MainPageModel();
            BindingContext = this;
        }

        private async void Execute()
        {
            //DisplayAlert("TEST", param.ToString(), "OK");
            var p = new MyProxy();
            var user = await p.GetUser(Model.ID);
            Model.UserName = user.Name;

            (App.Current as App).MainPage = New 
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var p = new MyProxy();
            var user = await p.GetUser("test");
            Model = new MainPageModel
            {
                UserName = user.Name
            };

            //DisplayAlert("TEST", "TEST222222222222222", "OK");


            //using (var db = new LiteDatabase(@"MyData.db"))
            //{
            //    // Get customer collection
            //    var col = db.GetCollection<Customer>("customers");

            //    // Create your new customer instance
            //    var customer = new Customer
            //    {
            //        Name = "John Doe",
            //        Phones = new string[] { "8000-0000", "9000-0000" },
            //        Age = 39,
            //        IsActive = true
            //    };

            //    // Create unique index in Name field
            //    col.EnsureIndex(x => x.Name, true);

            //    // Insert new customer document (Id will be auto-incremented)
            //    col.Insert(customer);

            //    // Update a document inside a collection
            //    customer.Name = "Joana Doe";

            //    col.Update(customer);

            //    // Use LINQ to query documents (with no index)
            //    var results = col.Find(x => x.Age > 20);


            //}
        }
    }
}
