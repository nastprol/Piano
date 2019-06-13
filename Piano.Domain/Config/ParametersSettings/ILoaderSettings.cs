using Domain.Infrastructure;

namespace Domain
{
    public interface ILoaderSettings
    {
        IMelodyLoader GetLoader();
    }
}
