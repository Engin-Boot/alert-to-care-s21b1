using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Frontend.ViewModel
{
    public class PatientDetails:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string bedId;
        string icuId;
        string name;
        int age;
        string address;
        string patientId;
        string gender, contact;
        ObservableCollection<string> _icuIdList = new ObservableCollection<string>();
        ObservableCollection<string> _bedIdList = new ObservableCollection<string>();
        public ObservableCollection<string> IcuIdList
        {
            get { return this._icuIdList; }
            set { this._icuIdList = value; }

        }
        public ObservableCollection<string> BedIdList
        {
            get { return this._bedIdList; }
            set { this._bedIdList = value; }
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string PatientId
        {
            get { return this.patientId; }
            set
            {
                if (this.patientId != value)
                {
                    this.patientId = value;
                    OnPropertyChanged(nameof(PatientId));
                }
            }
        }
        public string BedId
        {
            get { return this.bedId; }
            set
            {
                if (this.bedId != value)
                {
                    this.bedId = value;
                    OnPropertyChanged(nameof(BedId));
                }
            }
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
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public string Address
        {
            get { return this.address; }
            set
            {
                if (this.address != value)
                {
                    this.address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }
        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (this.gender != value)
                {
                    this.gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }
        public string Contact
        {
            get { return this.contact; }
            set
            {
                if (this.contact != value)
                {
                    this.contact = value;
                    OnPropertyChanged(nameof(Contact));
                }
            }
        }

    }
}
