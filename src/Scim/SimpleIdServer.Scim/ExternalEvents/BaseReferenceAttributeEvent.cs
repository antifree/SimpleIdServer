﻿using Newtonsoft.Json.Linq;
using SimpleIdServer.Common.ExternalEvents;
using System.Collections.Generic;

namespace SimpleIdServer.Scim.ExternalEvents
{
    public class BaseReferenceAttributeEvent : IntegrationEvent
    {
        public BaseReferenceAttributeEvent(string id, int version, string resourceType, string representationAggregateId, string schemaAttributeId, string attributeFullPath, JObject representation) : base(id, version, resourceType)
        {
            RepresentationAggregateId = representationAggregateId;
            SchemaAttributeId = schemaAttributeId;
            AttributeFullPath = attributeFullPath;
            Values = new List<string>();
            Representation = representation;
        }

        public string RepresentationAggregateId { get; set; }
        public string SchemaAttributeId { get; set; }
        public string AttributeFullPath { get; set; }
        public ICollection<string> Values { get; set; }
        public JObject Representation { get; set; }
    }
}