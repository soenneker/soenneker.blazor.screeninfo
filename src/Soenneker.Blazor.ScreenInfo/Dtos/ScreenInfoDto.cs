using System.Text.Json.Serialization;

namespace Soenneker.Blazor.ScreenInfo.Dtos;

/// <summary>
/// Represents the screen info dto record.
/// </summary>
public sealed record ScreenInfoDto
{
    /// <summary>
    /// Gets or sets width.
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets height.
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// Gets or sets device pixel ratio.
    /// </summary>
    [JsonPropertyName("devicePixelRatio")]
    public double DevicePixelRatio { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the instance is landscape.
    /// </summary>
    [JsonPropertyName("isLandscape")]
    public bool IsLandscape { get; set; }
        
    /// <summary>
    /// Gets or sets orientation.
    /// </summary>
    [JsonPropertyName("orientation")]
    public string? Orientation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the instance is touch device.
    /// </summary>
    [JsonPropertyName("isTouchDevice")]
    public bool IsTouchDevice { get; set; }

    /// <summary>
    /// Gets or sets user agent.
    /// </summary>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }
}
