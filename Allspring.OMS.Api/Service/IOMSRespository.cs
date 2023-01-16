namespace Allspring.OMS.Api.Service
{
    public interface IOMSRespository
    {
       Task<IEnumerable<OrderMgmtSystemAAA>> GetAAAData();
        Task<IEnumerable<OrderMgmtSystemBBB>> GetBBBData();
        Task<IEnumerable<OrderMgmtSystemCCC>> GetCCCData();
    }
}
