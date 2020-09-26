using System;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    /// <summary>
    /// Return type for a Null object site
    /// </summary>
    class NotFoundSite : ISite
    {
        public Guid WebsiteId => Guid.Empty;
        public Guid ActiveState => Guid.Empty;
    }
}