using NHibernate;

namespace Swampy.Business.Infrastructure.Abstractions
{
    public abstract class Command
    {
        public ISession Session { get; set; }
        public abstract void Execute();
    }

    public abstract class Command<T> : Command
    {
        public T Result { get; protected set; }
    }
}
