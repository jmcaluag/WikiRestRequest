using System.Text.Json.Serialization;

class WikiTextRequest
{
 public Parse parse { get; set; }
}

class Parse
{
    public string title { get; set; }
    public int pageid { get; set; }
    public WikiText wikitext { get; set; }
}

class WikiText
{
 [JsonPropertyName("*")]
 public string content { get; set; }
}