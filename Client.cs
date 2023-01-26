using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DeliveySystem
{
    public class Client
    {
        #region private fields
        private string _firstName;
        private string _lastName;
        private readonly int _id;
        private Adress _adress;
        #endregion
        #region props 
        public string FirstName
        {
            get { return _firstName; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("name cant be empty");   _firstName = value; }
        }
        
        public string LastName
        {
            get { return _lastName; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("name cant be empty"); _lastName = value; }
        }
        
        public int Id
        {
            get { return this._id; }
        }
        
        public Adress Adress
        {
            get { return this._adress; }
            set { if (value == null) throw new ArgumentNullException("adress cant be point on null");_adress = value; }
        }
        #endregion
        #region ctor
        public Client(string firstName,int id, string lastName, Adress adress)
        {
            FirstName = firstName;
            LastName = lastName;
            if (id > 0)//set a condition and mane his prop as a readonly
                _id = id;
            Adress = adress;
        }
        #endregion
        #region override methods
        public override string ToString()
        {
            return $"first name:{_firstName}\nlast name:{_lastName}\nid:{_id}\nadress:{_adress}";
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   _firstName == client._firstName &&
                   _lastName == client._lastName &&
                   _id == client._id &&
                   EqualityComparer<Adress>.Default.Equals(_adress, client._adress);
        }

        public override int GetHashCode()
        {
            int hashCode = 31790283;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_firstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_lastName);
            hashCode = hashCode * -1521134295 + _id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Adress>.Default.GetHashCode(_adress);
            return hashCode;
        }
        #endregion
    }
}
