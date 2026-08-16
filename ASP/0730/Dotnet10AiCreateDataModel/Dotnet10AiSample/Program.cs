using CommunityToolkit.VectorData.Qdrant;
using Dotnet10AiCreateDataModel;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using OpenAI;
using OpenAI.Embeddings;
using OpenAI.VectorStores;
using Qdrant.Client;

namespace Dotnet10AiSample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2Nlc3MiOiJtIiwic3ViamVjdCI6ImFwaS1rZXk6MmYxYzkxZWUtMDFjZS00ZjEzLTg4YTQtMDNkM2JjZTk0M2E2In0.qSC19JDqB3Q4IZZzAjvn8oPB_oNupBu27O3q-QKrEf4";
            string host = "61159f6c-4dc1-4d31-8870-7f519a03cbfb.eu-west-1-0.aws.cloud.qdrant.io";

            // 用來與qdrantClient資料庫連線的客戶端
            QdrantClient qdrantClient = new QdrantClient(

                host: host,
                port: 6334,
                https: true,
                apiKey: apiKey);

            // 透過資料庫連線的客戶端取得向量資料 collection 集合
            // ownsClient — A value indicating whether qdrantClient is disposed after the vector store is disposed.
            // 表示當向量儲存庫（vector store）被處置（disposed）時，是否一併處置 qdrantClient
            QdrantVectorStore vectorStore = new QdrantVectorStore(
                qdrantClient,
                ownsClient: true);

            // 透過 vectorStore 取得向量資料 collection
            VectorStoreCollection<ulong, Hotel> collection
                = vectorStore.GetCollection<ulong, Hotel>("hotels");

            // 確保資料庫已經建立
            // if not exist then create
            await collection.EnsureCollectionExistsAsync();

            // 建立一個能把 Hotel Description 轉換成向量的服務
            var openAiApikey = "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";
            var openAiModel = "text-embedding-3-small";

            // OpenAIClient
            OpenAIClient openAiClient = new OpenAIClient(openAiApikey);
            // EmbeddingClient
            EmbeddingClient embeddingClient = openAiClient.GetEmbeddingClient(model: openAiModel);

            // IEmbeddingGenerator 專門將 string 轉成 embedding 的服務

            // Embedding<float>: Represents an embedding composed of a vector of float values.

            IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator =
                embeddingClient.AsIEmbeddingGenerator();

            // 將 HotelList 逐筆將 Hotel Description 轉成向量
            var hotels = SeedHotelData.HotelList;

            foreach (Hotel hotel in hotels)
            {
                // 將字串 hotel.Description 透過 embeddingGenerator 轉成 embedding(vector)
                Embedding<float> embedding =
                    await embeddingGenerator.GenerateAsync(hotel.Description);

                hotel.DescriptionEmbedding = embedding.Vector;

                // Upsert，即「更新 (Update)」或「新增 (Insert)」
                // 若飯店已存在則進行更新
                // 若飯店不存在則進行新增
                await collection.UpsertAsync(hotel);
                Console.WriteLine($"{hotel.HotelId}, {hotel.HotelName} Upsert Successfully");
            }
        }
    }
}
