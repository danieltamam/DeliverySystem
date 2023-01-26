using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DeliveySystem
{
    public class Member:Client
    {
        #region private fields
        private double _theAmountOfMoneyHeHasPaidSoFar;
        #endregion
        #region props
        public double TheAmountOfMoneyHeHasPaidSoFar
        {
            get { return this._theAmountOfMoneyHeHasPaidSoFar; }
            set { if (value < 0) throw new FieldAccessException("there is no way to pay less the 0 , fix it");_theAmountOfMoneyHeHasPaidSoFar = value; }
        }//validation checks
        #endregion
        #region ctors
        public Member(Client client):base(client.FirstName, client.Id , client.LastName, client.Adress)//ctor that upgrade a client to a member
        {
            _theAmountOfMoneyHeHasPaidSoFar = 0;
        }
        public Member(string firstName, int id,string lastName,Adress adress) : base(firstName, id, lastName, adress)//ctor the give the option for everyone to be a member
        {
            _theAmountOfMoneyHeHasPaidSoFar = 0;
        }
        #endregion
        #region GetDiscount
        public double GetDiscount()
        {
            Dictionary<double, double> discounts = new Dictionary<double, double>(); //create a dictionary that contain what dicount should i get
            discounts.Add(1000, 2.5);
            discounts.Add(5000, 5);
            discounts.Add(20000, 8);//added the all discounts to the dictionary
            for (int i = discounts.Count-1; i >= 0; i--)
            {
                if (discounts.Keys.ElementAt(i) <= _theAmountOfMoneyHeHasPaidSoFar)
                {
                    return discounts.Values.ElementAt(i);//return the discount
                }
            }
            return 0;
        }
        #endregion
        #region override methods
        public override string ToString()
        {
            return base.ToString() + $"the amount of money he has paid so far:{_theAmountOfMoneyHeHasPaidSoFar}";
        }

        public override bool Equals(object obj)
        {
            return obj is Member member &&
                   base.Equals(obj) &&
                   FirstName == member.FirstName &&
                   LastName == member.LastName &&
                   Id == member.Id &&
                   EqualityComparer<Adress>.Default.Equals(Adress, member.Adress) &&
                   _theAmountOfMoneyHeHasPaidSoFar == member._theAmountOfMoneyHeHasPaidSoFar;
        }

        public override int GetHashCode()
        {
            int hashCode = 439357619;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Adress>.Default.GetHashCode(Adress);
            hashCode = hashCode * -1521134295 + _theAmountOfMoneyHeHasPaidSoFar.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
