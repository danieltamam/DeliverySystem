using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveySystem
{
    public abstract class Delivery
    {
        #region private fields
        private Parcel _parcel;
        private string _realseDate;
        private int _state;
        #endregion
        #region props
        public Parcel Parcel
        {
            get { return this._parcel; }
            set { if (value == null) throw new ArgumentNullException("cant point out of a null memory"); _parcel = value; }
        }
        
        public string RealseDate
        {
            get { return this._realseDate; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("if you wanna set the realse date you have to do it in a valid way"); _realseDate = value; }
        }
        
        public int State//1-waiting for sending ,  2 -in the way , 3 - arrived to the client
        {
            get { return this._state; }
            set { if (value > 4 && value < 0) throw new ArgumentOutOfRangeException("the state of the shiping has to be between 1-3"); _state = value; }
            // the setter it is like a function to update the state
        }
        #endregion
        #region Send
        public void Send()
        {
            _realseDate = DateTime.Now.ToString();
            State = 2;// state 2 it means the shiping is on the way
        }
        #endregion
        #region abstract methods - GetPrice , GetEstimateDays
        public abstract double GetPrice();
        public abstract int GetEstimateDays();
        #endregion
        #region ctor
        protected Delivery(Parcel parcel)
        {
            Parcel = parcel;
            _realseDate = "";
            State = 1;
        }
        #endregion
        #region override methods
        public override string ToString()
        {
            return $"parcel:{_parcel}\nrealse date :{_realseDate}\nstate:{_state}";
        }

        public override bool Equals(object obj)
        {
            return obj is Delivery delivery &&
                   EqualityComparer<Parcel>.Default.Equals(_parcel, delivery._parcel) &&
                   _realseDate == delivery._realseDate &&
                   _state == delivery._state;
        }

        public override int GetHashCode()
        {
            int hashCode = 272399308;
            hashCode = hashCode * -1521134295 + EqualityComparer<Parcel>.Default.GetHashCode(_parcel);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_realseDate);
            hashCode = hashCode * -1521134295 + _state.GetHashCode();
            return hashCode;
        }
        #endregion


    }
}
