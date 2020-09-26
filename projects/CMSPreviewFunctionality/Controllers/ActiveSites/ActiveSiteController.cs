using System;
using System.Linq;
using CMSPreviewFunctionality.Controllers.WebsiteData;
using Microsoft.AspNetCore.Mvc;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    /// <summary>
    /// Controls which web site is currently active.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ActiveSiteController : ControllerBase
    {
        private readonly IActiveSiteRepository _activeSiteRepository;
        private readonly IWebsiteStateRepository _websiteStateRepository;

        public ActiveSiteController(IActiveSiteRepository activeSiteRepository,
            IWebsiteStateRepository websiteStateRepository)
        {
            _activeSiteRepository = activeSiteRepository;
            _websiteStateRepository = websiteStateRepository;
        }

        /// <summary>
        /// Get the active state for an website. This will take the form of an object encapsulating the currently
        /// active website 
        /// </summary>
        /// <param name="websiteId"></param>
        /// <returns></returns>
        [HttpGet("{websiteId}")]
        public IActionResult GetState(Guid websiteId)
        {
            var site = _activeSiteRepository.Sites.FirstOrDefault(s => s.WebsiteId == websiteId);
            if (site is null)
                return NotFound(websiteId);
            return Ok(site);
        }

        public class UpdateSiteStateRequest
        {
            public Guid ActiveStateId { get; set; }
        }

        /// <summary>
        /// Updates a website to a state. This means that the website will roll either forward or backward to the state.
        /// </summary>
        /// <param name="websiteId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{websiteId}")]
        public IActionResult UpdateSiteState([FromRoute] Guid websiteId, [FromBody] UpdateSiteStateRequest request)
        {
            var site = _activeSiteRepository.UpdateSite(websiteId, request.ActiveStateId);
            return site switch
            {
                NotFoundSite _ => NotFound(websiteId),
                NotFoundWebsiteState _ => NotFound(request.ActiveStateId),
                _ => Ok(site)
            };
        }

        /// <summary>
        /// Gets the actual content for the active website will return what is in the website object
        /// </summary>
        /// <param name="websiteId"></param>
        /// <returns></returns>
        [HttpGet("{websiteId}/website")]
        public IActionResult GetActiveWebsite(Guid websiteId)
        {
            var site = _activeSiteRepository.Sites.FirstOrDefault(s => s.WebsiteId == websiteId);
            if (site is null)
                return NotFound(websiteId);

            var activatedSite =
                _websiteStateRepository.WebsiteDataList.FirstOrDefault(w =>
                    w.StateId == site.ActiveState && w.WebsiteId == site.WebsiteId);

            if (activatedSite is null)
                return NotFound(activatedSite);

            return Ok(activatedSite);
        }
    }
}