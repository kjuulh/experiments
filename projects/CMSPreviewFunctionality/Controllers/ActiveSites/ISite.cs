using System;

namespace CMSPreviewFunctionality.Controllers.ActiveSites
{
    public interface ISite
    {
        public Guid WebsiteId { get; }
        public Guid ActiveState { get; }
    }
}