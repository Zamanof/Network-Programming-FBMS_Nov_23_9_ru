using System.Text.Json.Serialization;
namespace NP_05._HttpClient_API_example;

internal class Post
{
    
    [JsonPropertyName("userId")]
    public int UserId {  get; set; }
    
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("body")]
    public string? Text { get; set; }

    public override string ToString()
    {
        return @$"Post Id: {Id}
Sender:{UserId}
                {Title}
{Text}";
    }
}
