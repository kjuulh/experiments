using System;
using System.Collections.Generic;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    /// <summary>
    /// Includes a mock of what could be all the content for a website, in this case just a name and a body
    /// </summary>
    public sealed class WebsiteState 
    {
        public Guid StateId { get; }
        public Guid WebsiteId { get; }
        public string Name { get; }
        public ICollection<string> Body { get; }
        public long Timestamp { get; }

        public WebsiteState(Guid stateId, Guid websiteId, string name, ICollection<string> body)
        {
            StateId = stateId;
            WebsiteId = websiteId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}