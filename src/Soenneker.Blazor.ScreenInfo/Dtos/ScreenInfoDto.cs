using System.Text.Json.Serialization;

namespace Soenneker.Blazor.ScreenInfo.Dtos;

/// <summary>
/// Represents a snapshot of browser viewport and device information.
/// </summary>
public sealed record ScreenInfoDto
{
    /// <summary>
    /// Gets or sets the viewport width in CSS pixels.
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the viewport height in CSS pixels.
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// Gets or sets the ratio between device pixels and CSS pixels.
    /// </summary>
    [JsonPropertyName("devicePixelRatio")]
    public double DevicePixelRatio { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the viewport is wider than it is tall.
    /// </summary>
    [JsonPropertyName("isLandscape")]
    public bool IsLandscape { get; set; }
        
    /// <summary>
    /// Gets or sets the browser-reported screen orientation, or a landscape/portrait fallback.
    /// </summary>
    [JsonPropertyName("orientation")]
    public string? Orientation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the browser reports touch support.
    /// </summary>
    [JsonPropertyName("isTouchDevice")]
    public bool IsTouchDevice { get; set; }

    /// <summary>
    /// Gets or sets the browser-provided user-agent string.
    /// </summary>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }
}
