using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var endpoint = "https://api.openai.com/v1/images/generations";
            var model = "gpt-image-2";
            var apiKey = "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";

            //新增一個向OPEN AI API發出請求的客戶端
            var client = new HttpClient();

            // 請求標頭加入授權的Bearer API KEY
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", apiKey);

            //請求主體的return Body
            var request = new ImageGenerationRequest()
            {
                Model = model,
                Prompt = "A cute baby sea otter",
                NumberOfImages = 1,
                Size = "1024x1024",
                Quality = "low"
            };

            //送出請求API Response
            var response = await client.PostAsJsonAsync(
                endpoint, request);

            //解析response.Content的ImageGenerationResponse物件
            // 1.反序列化的選項
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            // 2.反序列化的結果型別
            ImageGenerationResponse result = await response.Content.ReadFromJsonAsync<ImageGenerationResponse>(options)
            ?? throw new JsonException("無法反序列化 ImageGenerationResponse");

            if (result is null ||result.Data is null|| result.Data.FirstOrDefault() is null)
            {
                throw new JsonException("找不到生成的圖檔");
            }

            string base64Image = result.Data!.FirstOrDefault().Base64Json ?? throw new JsonException("找不到生成的圖檔 base64 json 字串");

            //[寫在本地端的話]
            //把圖檔的base64Image字串讀到記憶體中
            byte[] imageBytes = Convert.FromBase64String(base64Image);

            //預設名稱
            string outputPath = $"{Guid.NewGuid()}.png";

            //透過WriteAllBytesAsync將資料庫寫到特定位置
            //await File.WriteAllBytesAsync(outputPath, imageBytes);

            //[遠端的作法]
            //Create Account Instance
            var cloudinaryCloudName = "mipw273o";
            var cloudinaryApiKey = "642629742248738";
            var cloudinaryApiSecret = "VkXtPsnq4dnfVsIbp7FkjMe6pCc";

            var account = new Account(cloudinaryCloudName, cloudinaryApiKey, cloudinaryApiSecret);

            //透過Account Instance建立Cloudinary Instance
            var cloudinary = new Cloudinary(account);

            // https://github.com/cloudinary/CloudinaryDotNet/blob/master/samples/PhotoAlbum/Pages/Upload.cshtml.cs
            // 想辦法把圖檔從 byte[] 轉成 Stream 才能呼叫 UploadAsync
            using var imageStream = new MemoryStream(imageBytes);

            // 將圖檔透過 Stream 上傳到 Cloudinary
            ImageUploadResult uploadResult = await cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(outputPath, imageStream),
                Folder = "OpenAiImageApi"
            });

            Console.WriteLine(uploadResult.SecureUrl);
        }
    }

    public class ImageGenerationRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-image-2";
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        [JsonPropertyName("n")]
        public int NumberOfImages { get; set; } = 1;
        [JsonPropertyName("size")]
        public string Size { get; set; } = "1024x1024";
        [JsonPropertyName("quality")]
        public string Quality { get; set; } = "low";

    }

    public class ImageGenerationResponse
    {
        [JsonPropertyName("created")]
        public int Created { get; set; }
        [JsonPropertyName("background")]
        public string Background { get; set; }
        [JsonPropertyName("data")]
        public List<GeneratedImageData> Data { get; set; }
        [JsonPropertyName("output_format")]
        public string? OutputFormat { get; set; }
        [JsonPropertyName("qultity")]
        public string Quality { get; set; }

    }

    public class GeneratedImageData
    {
        [JsonPropertyName("b64_json")]
        public string? Base64Json { get; set; }
    }
}
