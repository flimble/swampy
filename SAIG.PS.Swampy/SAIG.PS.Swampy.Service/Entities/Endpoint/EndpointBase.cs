using System;

namespace SAIG.PS.Swampy.Service.Entities.Endpoint
{
    public abstract class EndpointBase : EntityBase, IEndpointValidator
    {
        private string _key;

        public virtual string Key
        {
            get { return _key; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException("Endpoint Key cannot be null or empty");
                _key = value;
            }
        }

        public virtual string Value { get; set; }

        #region Implementation of IEndpointValidator

        public abstract bool IsValid(string endpoint);

        public abstract string TypeName { get; }

        #endregion
    }
}
