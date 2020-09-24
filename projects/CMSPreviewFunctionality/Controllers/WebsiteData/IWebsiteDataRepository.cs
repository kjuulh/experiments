using System.Collections.Immutable;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    public interface IWebsiteDataRepository
    {
        IImmutableList<WebsiteData> WebsiteDataList { get; }
        WebsiteData Add(WebsiteData data);
    }
}