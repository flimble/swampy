using Environment = Swampy.Domain.Entities.Environment;

namespace Swampy.Domain
{
    public interface IRepository
    {
        void AddNewEnvironment(Environment environment);

    }
}
