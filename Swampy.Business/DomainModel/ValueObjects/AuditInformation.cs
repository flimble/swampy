using System;
using Swampy.Business.DomainModel.Entities;
using Swampy.Business.Infrastructure.Abstractions;

namespace Swampy.Business.DomainModel.ValueObjects
{
    public class AuditInformation : ValueObjectBase<AuditInformation>
    {

        public AuditInformation() : this(new User { UserName = "John Doe"})
        {
            
        }

        public AuditInformation(User changedBy)
        {
            this.UserName = changedBy.UserName;
            this.TimeStamp = SystemTime.Now();

            RegisterProperty(x=>x.UserName);
            RegisterProperty(x=>x.TimeStamp);
        }

        public virtual int Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual DateTime TimeStamp { get; set; }
     
    }
}
