using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.VectorData;

namespace DotnetAiSearch
{
    public class Hotel
    {
        [VectorStoreKey]
        public ulong HotelId { get; set; }

        [VectorStoreData(IsIndexed = true)]
        public required string HotelName { get; set; }

        [VectorStoreData(IsFullTextIndexed = true)]
        public required string Description { get; set; }

        [VectorStoreVector(dimensions: 1536, DistanceFunction = DistanceFunction.CosineSimilarity, IndexKind = IndexKind.Hnsw)]
        public ReadOnlyMemory<float>? DescriptionEmbedding { get; set; }

        [VectorStoreData(IsIndexed = true)]
        public required string[] Tags { get; set; }
    }
}
