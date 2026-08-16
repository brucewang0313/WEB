using CommunityToolkit.VectorData.Qdrant;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using OpenAI;
using OpenAI.Embeddings;
using OpenAI.VectorStores;
using Qdrant.Client;

namespace DotnetAiSearch
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

            // Step04: 根據者輸入的自然語言，將其向量化，取得資料庫中語意相近的結果
            //// 根據使用者輸入的自然語言，將其向量化，取得資料庫中語意相近的結果
            //string query = "海上渡假村，有水上活動";

            //// query透過embeddingGenerator轉換成embedding(vector)
            //Embedding<float> queryEmbedding = await embeddingGenerator.GenerateAsync(query);

            //// 在 hotel collection 中找尋語意最相近的飯店
            //IAsyncEnumerable<VectorSearchResult<Hotel>> searchResults
            //    = collection.SearchAsync(queryEmbedding, top: 10);

            //// 透過 await foreach 取得 IAsyncEnumerable 的搜尋結果
            //await foreach (VectorSearchResult<Hotel> result in searchResults)
            //{
            //    Console.WriteLine($"{result.Score} {result.Record.HotelId}, {result.Record.HotelName}, {result.Record.Description}");
            //}

            // Step05: 混合搜尋
            string query = """
                       海邊，水上活動的飯店
                       """;
            // 將 query 透過 embeddingGenerator 轉成 embedding(vector)
            var searchEmbedding = await embeddingGenerator.GenerateAsync(query);
            // 將 VectorStoreCollection 轉為 IKeywordHybridSearchable<Hotel>
            var hybridCollection = (IKeywordHybridSearchable<Hotel>)collection;

            // 在 hotel collection 中找尋語意最相近，且關鍵字符合的飯店

            IAsyncEnumerable<VectorSearchResult<Hotel>> searchResults = hybridCollection.HybridSearchAsync(
                searchEmbedding.Vector,
                ["淡水", "老街", "親子"],
                top: 3);
            await foreach (VectorSearchResult<Hotel> result in searchResults)
            {
                Console.WriteLine($"{result.Score} {result.Record.HotelId}, {result.Record.HotelName}, {result.Record.Description}");
            }
        }
    }
}
