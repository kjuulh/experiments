using System;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    /// <summary>
    /// Null object not found websitestate
    /// </summary>
    class NotFoundWebsiteState : ISite
    {
        public Guid WebsiteId => Guid.Empty;
        public Guid ActiveState => Guid.Empty;
    }
}