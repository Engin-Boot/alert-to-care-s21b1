using Backend.Models;
using Frontend.ApiCalls;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.ViewModel
{
    public class Icudetails: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string icuId;
        string layout;
        int noOfBeds;
        int maxBeds;
        int freeBeds;

        public ObservableCollection<string> _icuIdList = new ObservableCollection<string>();
        public ObservableCollection<string> IcuIdList
        {
            get { return _icuIdList; }
            set { this._icuIdList = value; }
        }

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
        public int NoOfBeds
        {
            get { return this.noOfBeds; }
            set
            {
                if (this.noOfBeds != value)
                {
                    this.noOfBeds = value;
                    OnPropertyChanged(nameof(NoOfBeds));

                }
            }
        }
        public int MaxBeds
        {
            get { return this.maxBeds; }
            set
            {
                if (this.maxBeds != value)
                {
                    this.maxBeds = value;
                    OnPropertyChanged(nameof(MaxBeds));

                }
            }
        }
        public int FreeBeds {
            get { return this.freeBeds; }
            set
            {
                if (this.freeBeds != value)
                {
                    this.freeBeds = value;
                    OnPropertyChanged(nameof(FreeBeds));

                }
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this,new PropertyChangedEventArgs(propertyName));
            }
        }

        public void UpdateIcuDetails(PatientVitalsModels icu)
        {
            if (icu != null)
            {
                this.IcuId = icu.IcuId;
                this.Layout = icu.Layout;
                this.MaxBeds = icu.MaxBeds;
                this.NoOfBeds = icu.NoOfBeds;

                List<Backend.Models.BedModel> beds = new BedApiCalls().GetAllBedsFromAnIcu(icu.IcuId).ToList();
                this.FreeBeds = beds.FindAll(bed => bed.BedOccupancyStatus == "Free").Count;
            }   
            
        }
    }
}
