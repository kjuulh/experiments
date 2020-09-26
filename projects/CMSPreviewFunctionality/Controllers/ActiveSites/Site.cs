using System;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    /// <summary>
    /// Standard site implementation
    /// </summary>
    public class Site : ISite
    {
        public Site(Guid websiteId, Guid activeState)
        {
            WebsiteId = websiteId;
            ActiveState = activeState;
        }

        public Guid WebsiteId { get; }
        public Guid ActiveState { get; }
    }
}