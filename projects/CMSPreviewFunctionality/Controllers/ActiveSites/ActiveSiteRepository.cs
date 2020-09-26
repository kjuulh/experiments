using System;
using System.Collections.Immutable;
using System.Linq;
using CMSPreviewFunctionality.Controllers.WebsiteData;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    /// <summary>
    /// The backing store of active sites, it uses a relation to websiteData to point to which website is active
    /// </summary>
    public class ActiveSiteRepository : IActiveSiteRepository
    {
        private readonly IWebsiteStateRepository _stateRepository;

        public ActiveSiteRepository(IWebsiteStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
            var firstSite = _stateRepository.WebsiteDataList[0];
            var secondSite = _stateRepository.WebsiteDataList[1];
            
            Sites = ImmutableList<Site>.Empty;
            Sites = Sites.Add(new Site(firstSite.WebsiteId, firstSite.StateId));
            Sites = Sites.Add(new Site(secondSite.WebsiteId, secondSite.StateId));
        }

        public ImmutableList<Site> Sites { get; private set; }

        /// <summary>
        /// Updates the record based on which website is specified and which state to update to.
        /// </summary>
        /// <param name="websiteId"></param>
        /// <param name="activateStateId"></param>
        /// <returns></returns>
        public ISite UpdateSite(Guid websiteId, Guid activateStateId)
        {
            var siteToBeReplaced = Sites.FirstOrDefault(s => s.WebsiteId == websiteId);
            if (siteToBeReplaced == null)
                return new NotFoundSite();
            if(_stateRepository.WebsiteDataList.All(w => w.StateId != activateStateId))
                return new NotFoundWebsiteState();
            var newSite = new Site(websiteId, activateStateId);
            Sites = Sites.Replace(siteToBeReplaced, newSite);
            return newSite;
        }
    }
}