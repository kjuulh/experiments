using System;
using System.Collections.Generic;

namespace CMSPreviewFunctionality.Controllers.WebsiteData
{
    public sealed class WebsiteData : IEquatable<WebsiteData>
    {
        public Guid Id { get; }
        public Guid WebsiteId { get; }
        public string Name { get; }
        public ICollection<string> Body { get; }
        public long Timestamp { get; }

        public WebsiteData(Guid id, Guid websiteId, string name, ICollection<string> body)
        {
            Id = id;
            WebsiteId = websiteId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }


        public bool Equals(WebsiteData? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id) && Name == other.Name && Body.Equals(other.Body);
        }

        public override bool Equals(object? obj) => Equals(obj as WebsiteData);
        public override int GetHashCode() => HashCode.Combine(Id, Name, Body);
    }

    public class WebsiteDataRequest
    {
        public string Name { get; set; }
        public ICollection<string> Body { get; set; }
    }
}