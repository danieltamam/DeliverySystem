using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveySystem
{
    public class Item
    {
        #region private fields
        private string _name;
        private string _company;
        private double _price;
        #endregion
        #region props
        public string Name
        {
            get { return this._name; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("name cant be empty");_name=value; } 
        }
        
        public string Company
        {
            get { return this._company; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("name company can be empty.");_company = value; }
        }
        
        public double Price
        {
            get { return this._price;}
            set { if (value <= 0) throw new FieldAccessException("there is no way that your price for this item is 0 or less");_price = value; }
        }
        #endregion
        #region ctor
        public Item(string name, string company, double price)
        {
            Name = name;
            Company = company;
            Price = price;
        }
        #endregion
        #region override methodes
        public override string ToString()
        {
            return $"name:{_name}\ncompany:{_company}\nprice:{_price}";
        }

        public override bool Equals(object obj)
        {
            return obj is Item item &&
                   _name == item._name &&
                   _company == item._company &&
                   _price == item._price;
        }

        public override int GetHashCode()
        {
            int hashCode = 111134809;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_company);
            hashCode = hashCode * -1521134295 + _price.GetHashCode();
            return hashCode;
        }
        #endregion
    }
}
