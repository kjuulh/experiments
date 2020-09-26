using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    [Route("api/website")]
    [ApiController]
    public class WebsiteStateController : ControllerBase
    {
        private readonly IWebsiteStateRepository _stateRepository;

        public WebsiteStateController(IWebsiteStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_stateRepository.WebsiteDataList.OrderByDescending(d => d.Timestamp));

        [HttpGet("{websiteId}")]
        public IActionResult Get(Guid websiteId)
        {
            var data = _stateRepository.WebsiteDataList.Where(d => d.WebsiteId == websiteId)
                .OrderByDescending(d => d.Timestamp);
            return Ok(data);
        }

        [HttpPost("{websiteId}")]
        public IActionResult Update(Guid websiteId, WebsiteStateRequest model)
        {
            if (_stateRepository.WebsiteDataList.All(wb => wb.WebsiteId != websiteId))
                return NotFound(websiteId);
            var response = _stateRepository.Add(new WebsiteState(Guid.NewGuid(), websiteId, model.Name, model.Body));

            return Ok(response);
        }
    }
}