using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DeliveySystem
{
    public class Parcel
    {
        #region private fields
        private Item _item;
        private double _volume;
        private Adress _adress;
        private Client _client;
        private static int _counter = 0;//how much parcels are created from the time that the system is created.
        private readonly int _id;//an id for every parcel , can't change this after it created.
        #endregion
        #region props
        public Item Item
        {
            get { return this._item; }
            set { if (value==null) throw new ArgumentNullException("your name for the item cnat be empty!");_item = value; }
        }//validation checks
       
        public double Volume
        {
            get { return this._volume; }
            set { if (_volume <=0) throw new FieldAccessException("the volume of the parcel cant be 0 or less"); _volume = value; }
        }//validation checks
        
        public Adress Adress
        {
            get { return this._adress; }
            set { if (value == null) throw new ArgumentNullException("your adress for the parcel cant point out to null");_adress = value; }
            //validation checks
        }
        
        public Client Client
        {
            get { return this._client; }
            set { if (value == null) throw new ArgumentNullException("your client for the parcel cant point out to null");_client = value; }
        }//validation checks
        
        public static int Counter
        {
            get { return _counter; }    
        }
       
        public int Id
        {
            get { return this._id; }
        }
        #endregion
        #region ctor
        public Parcel(Item item, double volume, Adress adress, Client client)
        {
            Item = item;
            Volume = volume;
            Adress = adress;
            Client = client;
            _counter++;//increase the counter because every time we called the ctor is one more parcel create.
            _id=_counter;//for parcel number one the id is 1 , for parcel number 2 the id is 2.....
            if(this._client is Member)
            {
                ((Member)(_client)).TheAmountOfMoneyHeHasPaidSoFar +=GetPrice();//adding the money to the total amount he paid if the client is member
            }
        }
        #endregion
        #region choose box
        public double ChooseBox()
        {
            double[] boxSizes = new double[] { 10, 25, 100 };
            foreach(var boxSize in boxSizes)
            {
                if (boxSize <= this._volume)
                {
                    return boxSize;
                }
            }
            return this._volume;//if the box size more than 100 return the volume and create a special parcel.

        }
        #endregion
        #region choose zone
        public int ChooseZone()//zone 1 is A zone 2 is B zone is C .... etc
        {
            string country = Client.Adress.Country;
           return char.ToLower(country[0]) - 96;//A in asci is 97 therefore it is zone 1 etc
        }
        #endregion
        #region get price
        public double GetPrice()
        {
            double PricePerCm = 0.1;
            double ParcelPrice = this.Item.Price;//the price for the item is the same as the price for the parcel
            double BoxSize = ChooseBox();
            ParcelPrice+=BoxSize * PricePerCm;
            if (BoxSize > 100)//if the volume of the parcel is more than 100 the price for the parcel is more 5 dollars
                ParcelPrice += 5;
            if (_client is Member)
                {
                   double discountPercentForMember=((Member)(_client)).GetDiscount();
                   ParcelPrice = ParcelPrice - (ParcelPrice*(0.01* discountPercentForMember));//do a discount if client is a member 
                }
            if(_client is VipMember)
            {
                double discountPercentForVipMember = VipMember.DiscountForVip;
                ParcelPrice = ParcelPrice - (ParcelPrice * (0.01 * discountPercentForVipMember));//do a discount if client is a vip member 
            }
            return ParcelPrice;
        }
        #endregion
        #region overides mehtodes

        //overides methods
        public override string ToString()
        {
            return $"item:{_item}\nvolume:{_volume}\nadress:{_adress}\nclient:{_client}\nid:{_id}";
        }

        public override bool Equals(object obj)
        {
            return obj is Parcel parcel &&
                   EqualityComparer<Item>.Default.Equals(_item, parcel._item) &&
                   _volume == parcel._volume &&
                   EqualityComparer<Adress>.Default.Equals(_adress, parcel._adress) &&
                   EqualityComparer<Client>.Default.Equals(_client, parcel._client) &&
                   _id == parcel._id;
        }

        public override int GetHashCode()
        {
            int hashCode = -1335616515;
            hashCode = hashCode * -1521134295 + EqualityComparer<Item>.Default.GetHashCode(_item);
            hashCode = hashCode * -1521134295 + _volume.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Adress>.Default.GetHashCode(_adress);
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(_client);
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
