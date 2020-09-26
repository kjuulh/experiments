using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    public class WebsiteStateRepository : IWebsiteStateRepository
    {
        public WebsiteStateRepository()
        {
            WebsiteDataList = ImmutableList<WebsiteState>.Empty;
            WebsiteDataList =
                WebsiteDataList.Add(new WebsiteState(Guid.NewGuid(), Guid.NewGuid(), "some-name",
                    new List<string> {"some-body"}));
            WebsiteDataList =
                WebsiteDataList.Add(new WebsiteState(Guid.NewGuid(), Guid.NewGuid(), "some-other-name",
                    new List<string> {"some-other-body"}));
        }

        public IImmutableList<WebsiteState> WebsiteDataList { get; private set; }

        public WebsiteState Add(WebsiteState state)
        {
            WebsiteDataList = WebsiteDataList.Add(state);
            return state;
        }
    }
}