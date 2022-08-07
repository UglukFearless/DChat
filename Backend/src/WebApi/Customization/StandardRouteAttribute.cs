using Microsoft.AspNetCore.Mvc.Routing;

namespace WebApi.Customization;

/// <summary>
/// Attribute for forming the standart url of the controller
/// </summary>
internal class StandardRouteAttribute : Attribute, IRouteTemplateProvider
{
    public string Template => $"api/d-chat/{Version ?? "v1"}/{Controller ?? "[controller]"}";
    public int? Order => 1;
    public string? Name { get; set; }
    public string? Version { get; set; }
    public string? Controller { get; set; }
}
