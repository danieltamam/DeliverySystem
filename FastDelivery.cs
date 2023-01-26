using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveySystem
{
    public class FastDelivery:RegularDelivery
    {
        #region private fields
        private const int _estimateDays = 1;//24 hours
        #endregion
        #region props
        public static int EstimateDays
        {
            get { return _estimateDays; }
        }
        #endregion
        #region ctor
        public FastDelivery(Parcel parcel) : base(parcel)
        {
        }
        #endregion
        #region override methods

        public override double GetPrice()
        {
            return 0.1*Parcel.GetPrice();
        }
        public override int GetEstimateDays()
        {
            return _estimateDays;
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
