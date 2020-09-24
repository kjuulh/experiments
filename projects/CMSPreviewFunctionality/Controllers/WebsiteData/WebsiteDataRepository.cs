using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    public class WebsiteDataRepository : IWebsiteDataRepository
    {
        public WebsiteDataRepository()
        {
            WebsiteDataList = ImmutableList<WebsiteData>.Empty;
            WebsiteDataList =
                WebsiteDataList.Add(new WebsiteData(Guid.NewGuid(), Guid.NewGuid(), "some-name",
                    new List<string> {"some-body"}));
            WebsiteDataList =
                WebsiteDataList.Add(new WebsiteData(Guid.NewGuid(), Guid.NewGuid(), "some-other-name",
                    new List<string> {"some-other-body"}));
        }

        public IImmutableList<WebsiteData> WebsiteDataList { get; private set; }

        public WebsiteData Add(WebsiteData data)
        {
            WebsiteDataList = WebsiteDataList.Add(data);
            return data;
        }
    }
}