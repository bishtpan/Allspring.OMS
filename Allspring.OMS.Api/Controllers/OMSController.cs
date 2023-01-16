using Allspring.OMS.Api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Allspring.OMS.Api.Controllers
{
    [ApiController]
    [Route("api/OMS")]
    public class OMSController : ControllerBase
    {
        private readonly IDataSource _dataSource;
        private readonly ILogger<OMSController> _logger;
        private readonly IOMSRespository _omsRepository;
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public OMSController(IDataSource dataSource, 
            ILogger<OMSController> logger , 
            IOMSRespository omsRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _omsRepository = omsRepository ?? throw new ArgumentNullException(nameof(omsRepository));

            _dataSource = dataSource;
        }

        [HttpGet("AAA")]
        public async Task<ActionResult<IEnumerable<OrderMgmtSystemAAA>>> GetAAA()
        {
            var ds = await _omsRepository.GetAAAData();
            if (null == ds)
                return NoContent();
                        
            return Ok(ds);
        }

        [HttpGet("BBB")]
        public async Task<ActionResult<IEnumerable<OrderMgmtSystemAAA>>> GetBBB()
        {
            var ds = await _omsRepository.GetBBBData();
            if (null == ds)
                return NoContent();
            return Ok(ds);
        }

        [HttpGet("CCC")]
        public async Task<ActionResult<IEnumerable<OrderMgmtSystemAAA>>> GetCCC()
        {
            var ds = await _omsRepository.GetCCCData();
            if (null == ds)
                return NoContent();
            return Ok(ds);
        }
    }
}
