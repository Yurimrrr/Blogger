using Blogger.Extensions.Mediator;

namespace Blogger.Application.Base;

public abstract class AppServiceBase : IAppServiceBase, IDisposable
{
    //protected readonly IMapper Mapper;
    protected readonly IMediatorHandler _mediator;

    //public AppServiceBase(IMapper mapper) =>
    //    (Mapper) = (mapper);
    public AppServiceBase()
    {

    }
    public AppServiceBase(IMediatorHandler meditor) => _mediator = meditor;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            
        }
    }
}