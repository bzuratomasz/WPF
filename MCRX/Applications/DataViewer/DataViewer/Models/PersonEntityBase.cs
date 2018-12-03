using DataViewer.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewer.Models
{
    public class PersonEntityBase : ObservableObject
    {
        private int _id = 0;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _streettName = string.Empty;
        private int _houseNumber = 0;
        private int? _apartmentNumber = 0;
        private string _postalCode = string.Empty;
        private int _phoneNumber = 0;
        private DateTime _dayOfBirth = DateTime.MinValue;
        private int _age = 0;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChangedEvent("Id");
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChangedEvent("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChangedEvent("LastName");
            }
        }
        public string StreetName
        {
            get
            {
                return _streettName;
            }
            set
            {
                _streettName = value;
                RaisePropertyChangedEvent("StreetName");
            }
        }
        public int HouseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                _houseNumber = value;
                RaisePropertyChangedEvent("HouseNumber");
            }
        }
        public int? ApartmentNumber
        {
            get
            {
                return _apartmentNumber;
            }
            set
            {
                _apartmentNumber = value;
                RaisePropertyChangedEvent("ApartmentNumber");
            }
        }
        public string PostalCode
        {
            get
            {
                return _postalCode;
            }
            set
            {
                _postalCode = value;
                RaisePropertyChangedEvent("PostalCode");
            }
        }
        public int PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                RaisePropertyChangedEvent("PhoneNumber");
            }
        }
        public DateTime DayOfBirth
        {
            get
            {
                return _dayOfBirth;
            }
            set
            {
                _dayOfBirth = value;
                RaisePropertyChangedEvent("DayOfBirth");
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                RaisePropertyChangedEvent("Age");
            }
        }
    }
}
