using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveySystem
{
    public class DeliveryCenter
    {
        #region private fields
        private Zone[] _zones;
        private static int _size = 26;
        private int _currentIndex;
        #endregion
        #region props
        public Zone[] Zones
        {
            get { return this._zones; }
            set
            {
                foreach(var zone in value)
                {
                    if (zone == null)
                        throw new ArgumentNullException("the zone has not to be null!");
                    _zones = value;
                }
            }
        }
        
        public static int Size
        {
            get { return _size; }
        }
       
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { if (value > Size || value < 0) throw new ArgumentOutOfRangeException("the value has to be between 0 - 26");_currentIndex = value; }
        }
        #endregion
        #region ctor
        public DeliveryCenter()
        {
            _zones=new Zone[Size];
            _currentIndex = 0;
        }
        #endregion
        #region add zone
        public void AddZone(Zone zone)
        {
            if(CurrentIndex<Size)
            _zones[_currentIndex] = zone;
            CurrentIndex++;
        }
        #endregion
        #region add parcel
        public void AddParcel(Parcel parcel)
        {
            int zoneParcel = parcel.ChooseZone();
            foreach(var zone in _zones)
            {
                if (zoneParcel == zone.GetZoneNumber())
                {
                    zone.AddParcel(parcel);
                    break;//end lopp
                }
            }
        }
        #endregion
        #region overrride methods
        public override string ToString()
        {
            string zones = "";
            foreach (var zone in _zones)
            {
                zones += zone.GetTotalAmountOfParcels() + "and the price for all the parcels is: " + zone.GetTotalPriceOfParcels()+ "\n\n\n";
            }
                return $"the amount of the parcels in every zone is:{zones}";
        }

        public override bool Equals(object obj)
        {
            return obj is DeliveryCenter center &&
                   EqualityComparer<Zone[]>.Default.Equals(_zones, center._zones) &&
                   _currentIndex == center._currentIndex;
        }

        public override int GetHashCode()
        {
            int hashCode = -1921306146;
            hashCode = hashCode * -1521134295 + EqualityComparer<Zone[]>.Default.GetHashCode(_zones);
            hashCode = hashCode * -1521134295 + _currentIndex.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
