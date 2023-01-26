using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveySystem
{
    public class RegularDelivery:Delivery
    {
        #region private fields
        private const double _priceInChina=2;
        private const double _priceOutChina = 5;
        private const int _estimateTimeInChina = 5;
        private const int _estimateTimeOutChina = 10;
        #endregion
        #region props
        public static double PriceInChina { get { return _priceInChina; } }
        
        public static double PriceOutChina { get { return _priceOutChina; } }
        
        public static int EstimateTimeInChina { get { return _estimateTimeInChina; } }

        public static double EstimeateTimeOutChina { get { return _estimateTimeOutChina; } }
        #endregion
        #region ctor
        public RegularDelivery(Parcel parcel) : base(parcel)
        {
        }
        #endregion
        #region override methods
        public override int GetEstimateDays()
        {
            if (Parcel.Client.Adress.Country.ToLower() == "china")
            {
                return _estimateTimeInChina;
            }
            else
                return _estimateTimeOutChina;
        }
        public override double GetPrice()
        {
            if (Parcel.Client.Adress.Country.ToLower() == "china")
            {
                return _priceInChina;
            }
            else
                return _priceOutChina;
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
