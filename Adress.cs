using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DeliveySystem
{
    public class Adress
    {
        #region private fields
        private string _country;
        private string _city;
        private int _houseNumber;
        private int _floor;
        private int _apartment;
        private bool _isTheHosuePrivate;
        #endregion
        #region props 
        public string Country
        {
            get { return this._country; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("country cant be empty,you must write a country");else  _country = value; }
        }
        
        public string City
        {
            get { return _city; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("city cant be empty,tou must write a city"); _city = value; }
        }
        
        public int HouseNumber
        {
            get { return _houseNumber; }
            set { if (value < 0) throw new FieldAccessException("house number has to be positive!");_houseNumber = value; }
        }
        
        public int Floor
        {
            get { return this._floor; }
            set { if (value <= 0) throw new FieldAccessException("floor has to be positive!"); _floor = value; }
        }
       
        public int Apartment
        {
            get { return this._apartment; }
            set { if (value <= 0) throw new FieldAccessException("apartment number has to be positive!");_apartment = value; }
        }
       
        public bool IsTheHousePrivate
        {
            get { return this._isTheHosuePrivate; }
            set
            {
                if (value == true)//set the value if is 0
                {
                    if (_apartment != 0 && _floor != 0) throw new FieldAccessException("the floor and apratment are more than 0 , there is now way it is a private house");
                    _isTheHosuePrivate = value;
                }
                else//set the value if is not 0
                    if(_apartment == 0 && _floor == 0) throw new FieldAccessException("the floor and apratment are  0 , there is now way it is a public house");
                _isTheHosuePrivate = value;
            }
        }
        #endregion
        #region ctor
        public Adress(string country, string city, int houseNumber, int floor, int apartment)
        {
            Country = country;
            City = city;
            HouseNumber = houseNumber;
            Floor = floor;
            Apartment = apartment;
            if (floor > 0 && apartment > 0)//set the value if the house private respectively
                _isTheHosuePrivate = false;
            else
                _isTheHosuePrivate = true;
        }
        #endregion
        #region override methodes
        public override string ToString()
        {
            return $"country:{_country}\ncity:{_city}\nhouse number:{_houseNumber}\nfloor:{_floor}\napartment:{_apartment}\nis the house private?:{_isTheHosuePrivate}";
        }

        public override bool Equals(object obj)
        {
            return obj is Adress adress &&
                   _country == adress._country &&
                   _city == adress._city &&
                   _houseNumber == adress._houseNumber &&
                   _floor == adress._floor &&
                   _apartment == adress._apartment &&
                   Apartment == adress.Apartment &&
                   _isTheHosuePrivate == adress._isTheHosuePrivate &&
                   IsTheHousePrivate == adress.IsTheHousePrivate;
        }

        public override int GetHashCode()
        {
            int hashCode = -1286584842;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_city);
            hashCode = hashCode * -1521134295 + _houseNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + _floor.GetHashCode();
            hashCode = hashCode * -1521134295 + _apartment.GetHashCode();
            hashCode = hashCode * -1521134295 + Apartment.GetHashCode();
            hashCode = hashCode * -1521134295 + _isTheHosuePrivate.GetHashCode();
            hashCode = hashCode * -1521134295 + IsTheHousePrivate.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
