using Allspring.OMS.Api.Entity;

namespace Allspring.OMS.Api.Service
{
    public interface IDataSource
    {
        IEnumerable<Line> GetData(SourceType sourceType);
    }
}
