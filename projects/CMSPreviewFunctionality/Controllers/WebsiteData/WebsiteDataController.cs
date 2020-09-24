using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    [Route("api/website-data")]
    [ApiController]
    public class WebsiteDataController : ControllerBase
    {
        private readonly IWebsiteDataRepository _dataRepository;

        public WebsiteDataController(IWebsiteDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_dataRepository.WebsiteDataList.OrderByDescending(d => d.Timestamp));

        [HttpGet("{websiteDataId}")]
        public IActionResult Get(Guid websiteDataId)
        {
            var data = _dataRepository.WebsiteDataList.Where(d => d.WebsiteId == websiteDataId)
                .OrderByDescending(d => d.Timestamp);
            return Ok(data);
        }

        [HttpPost("{websiteDataId}")]
        public IActionResult Update(Guid websiteDataId, WebsiteDataRequest model)
        {
            if (_dataRepository.WebsiteDataList.All(wb => wb.WebsiteId != websiteDataId))
                return NotFound(websiteDataId);
            var response = _dataRepository.Add(new WebsiteData(Guid.NewGuid(), websiteDataId, model.Name, model.Body));

            return Ok(response);
        }
    }
}