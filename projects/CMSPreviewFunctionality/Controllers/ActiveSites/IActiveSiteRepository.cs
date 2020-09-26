using System;
using System.Collections.Immutable;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    public interface IActiveSiteRepository
    {
        ImmutableList<Site> Sites { get; }
        ISite UpdateSite(Guid websiteId, Guid activateStateId);
    }
}