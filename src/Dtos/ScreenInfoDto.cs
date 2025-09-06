using System.Text.Json.Serialization;

namespace Soenneker.Blazor.ScreenInfo.Dtos;

public record ScreenInfoDto
{
    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("devicePixelRatio")]
    public double DevicePixelRatio { get; set; }

    [JsonPropertyName("isLandscape")]
    public bool IsLandscape { get; set; }
        
    [JsonPropertyName("orientation")]
    public string? Orientation { get; set; }

    [JsonPropertyName("isTouchDevice")]
    public bool IsTouchDevice { get; set; }

    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }
}
