using System;

namespace Swampy.Business.DomainModel.ValueObjects
{
    public class Domain : IEquatable<Domain>
    {

        public virtual int Id { get; set; }
        private readonly string _name;

        public Domain(string name)
        {
            this._name = name;
            
        }

        // the default constructor is only here for NH (private is sufficient, it doesn't need to be public)
        protected Domain() : this(string.Empty) { }

        public virtual string Name
        {
            get { return _name; }
        }

     
     

        public virtual bool Equals(Domain other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._name, _name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Domain)) return false;
            return Equals((Domain)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_name.GetHashCode() * 397);
            }
        }

        public static bool operator ==(Domain left, Domain right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Domain left, Domain right)
        {
            return !Equals(left, right);
        }
    }
}
