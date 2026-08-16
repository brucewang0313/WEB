using System.Security.Cryptography;
using System.Text;

// LINE Webhook 簽章驗證示範
// 驗證邏輯（與官方文件一致）：
// 1) 取出 HTTP Request Body 的原始位元組內容（不可變更、不可重排、不可多/少空白）。
// 2) 以 Channel Secret 作為 HMAC 的金鑰（Key）。
// 3) 使用 HMAC-SHA256 對「原始 Request Body」計算雜湊值。
// 4) 將雜湊值做 Base64 編碼，得到字串。
// 5) 與 Header 的 x-line-signature 完整比對（完全一致才通過）。

// 範例 Channel Secret（實務上請改以設定或 Secret 管理）
string channelSecret = "c132ae7ca5e5e14f74676562c866ba29";
string body =
    """
    {"destination":"U1ec26a238b635b8c5bdb6dae856e0738","events":[{"type":"message","message":{"type":"text","id":"595151585396129878","quoteToken":"jjglWMtk-xGmTQEgWwgTEok77CnlLgh3lDVNIms3q1h_Qa_G349RhlZnVNpJunSaPmchVIhAn80vuX0kezoTNDeNn9EYe1JUy-5VALMlPkmlPUgRgahkg5bPGQSWZJs5rd7I1M5L68rfjfADQEA-Og","markAsReadToken":"c6FQ6zUg93GTbCaFog69X7E4_ZHM2PSegjPFSKUSjaq93WcX_LNdYn-opIVr8kSlS5lyCi9mvsM_gdIooq5HC5VwPu1eh-p6n2Y9_omumrxJABJlBx6nGX6rK71XzODsdzeAnFERf3oJUcCQPpPIjMMM6kyu5Lm49xdhcHugdzDslhCdM7DyuUfxCFMhpuFRgq1bGPgFad3OBVOvrcQjBg","text":"我想找去爬山的行程請推薦給我"},"webhookEventId":"01KE5NDZESW57F209H9NTE8FZ8","deliveryContext":{"isRedelivery":false},"timestamp":1767569292359,"source":{"type":"user","userId":"Ufe1c385ab3f80e44e01fdc0233dcf642"},"replyToken":"835dfb819c7f4d29b54749c0a07d8cd0","mode":"active"}]}
    """;
// 由 LINE 傳入的 Request Header: x-line-signature（這裡用範例值）
string signatureFromHeader = "r+0IJ2HybQKM8tUWUMFUUWB3vdjri/p1TntOn+FZxEc=";

VerifySignatureWithLogs(body, channelSecret, signatureFromHeader);

// 依照上述 5 個步驟進行驗證，並印出中間結果以便除錯觀察
static bool VerifySignatureWithLogs(string body, string channelSecret, string signature)
{
    // Step 1: 準備位元組資料
    // - keyBytes 來自 Channel Secret（UTF-8）
    // - bodyBytes 必須是「HTTP Request Body 的原始內容」的位元組（本範例以字串模擬）
    byte[] keyBytes = Encoding.UTF8.GetBytes(channelSecret);
    byte[] bodyBytes = Encoding.UTF8.GetBytes(body);

    Console.WriteLine("--- Debug Info ---");
    Console.WriteLine($"Channel Secret (Key): {channelSecret}");
    Console.WriteLine($"Key Hex: {BitConverter.ToString(keyBytes).Replace("-", "")}");
    Console.WriteLine();

    using (var hmac = new HMACSHA256(keyBytes))
    {
        // Step 2 & 3: 以 Channel Secret 作為 Key，使用 HMAC-SHA256 計算雜湊
        byte[] hashBytes = hmac.ComputeHash(bodyBytes);
        Console.WriteLine($"Raw Hash (Hex): {BitConverter.ToString(hashBytes).Replace("-", "")}");

        // Step 4: 將雜湊結果做 Base64 編碼
        string hashBase64 = Convert.ToBase64String(hashBytes);
        Console.WriteLine($"Base64 Encoded (Generated): {hashBase64}");
        Console.WriteLine($"Signature from Header:       {signature}");
        Console.WriteLine("------------------");

        // Step 5: 與 Header 的 x-line-signature 做「完全相等」比對
        bool isValid = hashBase64 == signature;
        Console.WriteLine($"Match: {isValid}");

        return isValid;
    }
}