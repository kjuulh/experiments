using System.Collections.Generic;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    public class WebsiteStateRequest
    {
        public string Name { get; set; }
        public ICollection<string> Body { get; set; }
    }
}