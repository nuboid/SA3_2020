using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ARCH.Client.Mobile.Annotations;

namespace ARCH.Client.Mobile.Models
{
    public class MainPageModel : INotifyPropertyChanged
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public ObservableCollection<String> MijnLijst { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
