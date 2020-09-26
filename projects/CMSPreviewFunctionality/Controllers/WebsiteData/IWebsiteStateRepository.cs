using System.Collections.Immutable;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    public interface IWebsiteStateRepository
    {
        IImmutableList<WebsiteState> WebsiteDataList { get; }
        WebsiteState Add(WebsiteState state);
    }
}