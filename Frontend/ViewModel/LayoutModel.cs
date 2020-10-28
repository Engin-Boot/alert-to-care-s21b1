using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Frontend.ViewModel
{
    public class LayoutModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string icuId;
        int maxBeds;
        string layout;
        public string IcuId
        {
            get { return this.icuId; }
            set
            {
                if (this.icuId != value)
                {
                    this.icuId = value;
                    OnPropertyChanged(nameof(IcuId));
                }
            }

        }
        public string Layout
        {
            get { return this.layout; }
            set
            {
                if (this.layout != value)
                {
                    this.layout = value;
                    OnPropertyChanged(nameof(Layout));
                }
            }
        }
        public int MaxBeds
        {
            get { return this.maxBeds; }
            set
            {
                if (this.maxBeds!= value)
                {
                    this.maxBeds = value;
                    OnPropertyChanged(nameof(MaxBeds));
                }
            }
        }
        public ObservableCollection<string> Layoutlist = new ObservableCollection<string>()
        {
            "L-Layout",
            "U-Layout",
            "H-Layout"
        };


        public ObservableCollection<string> LayoutList
        {
            get { return this.Layoutlist; }
            set { this.Layoutlist = value; }
        }
       
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

             

    }
}
