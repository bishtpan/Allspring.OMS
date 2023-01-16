namespace Allspring.OMS.Api.Infrastructure;

public interface IPersister
{
    Task<bool> Persist(FileMetadata fileMetadata, IEnumerable<string> dataToWrite);
}
