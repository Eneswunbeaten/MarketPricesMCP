using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MarketPricesMCP.Tools;

[McpServerToolType]
public static class ShopTools
{
    [McpServerTool, Description("Find the store with the best price for your desired product among the available markets in Turkey. Please enter only the product name in Turkish (e.g., 'salatalýk'). Do not include additional phrases or context (e.g., 'Türkiye'deki marketlerde salatalýk').")]
    public static async Task<string> Search(
        HttpClient client,
        [Description("Please enter the names of market products in Turkish. Only the product name should be entered, without additional phrases or context.")] string keywords)
    {

        if (string.IsNullOrWhiteSpace(keywords))
            return "Please provide a valid product name.";

        var requestData = new { keywords, pages = 0, size = 5 };
        var requestContent = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "api/v2/search")
        {
            Content = requestContent
        };
        request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:137.0) Gecko/20100101 Firefox/137.0");
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("Accept-Language", "en-US,en;q=0.9");
        request.Headers.Add("Accept-Encoding", "gzip, deflate, br, zstd");
        request.Headers.Add("WithCredentials", "true");
        request.Headers.Add("Origin", "https://marketfiyati.org.tr");
        request.Headers.Add("DNT", "1");
        request.Headers.Add("Sec-GPC", "1");
        request.Headers.Add("Connection", "keep-alive");
        request.Headers.Add("Sec-Fetch-Dest", "empty");
        request.Headers.Add("Sec-Fetch-Mode", "cors");
        request.Headers.Add("Sec-Fetch-Site", "same-site");
        request.Headers.Add("TE", "trailers");

        try
        {


            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonElement = await response.Content.ReadFromJsonAsync<JsonElement>();
            if (!jsonElement.TryGetProperty("content", out var contentElement))
                return "The response does not contain 'content' property.";

            var items = contentElement.EnumerateArray();
            if (!items.Any())
                return "No items found for the given search criteria.";

            return string.Join("\n--\n", items.Select(item =>
            {
                var productDepot = item.GetProperty("productDepotInfoList").EnumerateArray().FirstOrDefault();
                return $"""
                    Title: {item.GetProperty("title").GetString()}
                    Brand: {item.GetProperty("brand").GetString()}
                    Price: {productDepot.GetProperty("price").GetDecimal()} {productDepot.GetProperty("unitPrice").GetString()}
                    Market: {productDepot.GetProperty("marketAdi").GetString()}
                    """;
            }));
        }
        catch (Exception ex)
        {
            return $"An error occurred while searching: {ex.Message}";
        }
    }
}
