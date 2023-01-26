using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveySystem
{
    public class VipMember:Client
    {
        #region private fields
        private const double _discountForVip = 10;
        private const double _monthlyPrice = 200;
        #endregion
        #region props
        public static double DiscountForVip
        {
            get { return _discountForVip; }
        }
        
        public static double MonthlyPrice
        {
            get { return _monthlyPrice; }
        }
        #endregion
        #region ctors
        public VipMember(string firstName, int id, string lastName, Adress adress) : base(firstName, id, lastName, adress)
        {
        }
        public VipMember(Client client) : base(client.FirstName, client.Id, client.LastName, client.Adress)
        {
        }
        #endregion
        #region override methods
        public override string ToString()
        {
            return base.ToString() + $"discount for vip member:{_discountForVip}\nmonthly price:{_monthlyPrice}";
        }

        public override bool Equals(object obj)
        {
            return obj is VipMember member &&
                   base.Equals(obj) &&
                   FirstName == member.FirstName &&
                   LastName == member.LastName &&
                   Id == member.Id &&
                   EqualityComparer<Adress>.Default.Equals(Adress, member.Adress);
        }

        public override int GetHashCode()
        {
            int hashCode = -125892671;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Adress>.Default.GetHashCode(Adress);
            return hashCode;
        }
        #endregion
    }
}
