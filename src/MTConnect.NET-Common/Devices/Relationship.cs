// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System.Text.Json.Serialization;

namespace MTConnect.Devices
{
    /// <summary>
    /// Relationship is an XML element that describes the association between two pieces of equipment that function independently but together perform a manufacturing operation. 
    /// Relationship may also be used to define the association between two components within a piece of equipment.
    /// </summary>
    public class Relationship : IRelationship
    {
        /// <summary>
        /// The unique identifier for this Relationship.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// A descriptive name associated with this Relationship.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A reference to the related DataItem id.
        /// </summary>
        [JsonPropertyName("criticality")]
        public Criticality Criticality { get; set; }

        /// <summary>
        /// A reference to the associated component element.
        /// </summary>
        [JsonPropertyName("idRef")]
        public string IdRef { get; set; }
    }
}