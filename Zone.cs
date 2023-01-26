using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveySystem
{
    public class Zone
    {
        #region private fields
        private Parcel[] _parcels;
        private static int _size=10000;
        private static int _currentIndex;
        #endregion
        #region props
        public static int Size { get { return _size; } }
        
        public static int CurrentIndex
        {
            get { return _currentIndex; }
            set { if (value > _size || value < 0) throw new ArgumentOutOfRangeException("the index has to be between 0-9999"); _currentIndex = value; }
        }
        
        public Parcel[] Parcels
        {
            get { return this._parcels; }
            set
            {
                foreach (Parcel parcel in value)
                {
                    if (parcel == null)
                        throw new ArgumentNullException("all the parcels must not has to be null");
                }
                if (value.Length > Size) throw new ArgumentOutOfRangeException("the amount of the parcels has to be between 0-9999");
                _parcels = value;
            }
        }
        #endregion
        #region ctor
        public Zone()
        {
            _parcels = new Parcel[Size];
            _currentIndex = 0;
        }
        #endregion
        #region GetZoneNumber
        public int GetZoneNumber()
        {
          return  _parcels[CurrentIndex].ChooseZone();
        }
        #endregion
        #region add parcel
        public void AddParcel(Parcel parcel)
        {
            _parcels[CurrentIndex] = parcel;
            CurrentIndex++;
        }
        #endregion
        #region GetTotalPriceOfParcels
        public double GetTotalPriceOfParcels()
        {
            double totalPrice = 0;
            foreach(var parcel in _parcels)
            {
                totalPrice += parcel.GetPrice();
            }
            return totalPrice;
        }
        #endregion
        #region GetTotalAmountOfParcels
        public int GetTotalAmountOfParcels()
        {
            int totalAmount = 0;
            foreach (var parcel in _parcels)
            {
                totalAmount ++;
            }
            return totalAmount;
        }
        #endregion
        #region override methods
        public override string ToString()
        {
            string parcels = "";
            foreach(var parcel in _parcels)
            {
                parcels += parcel;
            }
            return $"parcels:{parcels}";
        }

        public override bool Equals(object obj)
        {
            return obj is Zone zone &&
                   EqualityComparer<Parcel[]>.Default.Equals(_parcels, zone._parcels);
        }

        public override int GetHashCode()
        {
            return 890118764 + EqualityComparer<Parcel[]>.Default.GetHashCode(_parcels);
        }
        #endregion
    }
}
