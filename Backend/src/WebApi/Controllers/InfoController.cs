using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Customization;

namespace WebApi.Controllers;

/// <summary>
/// Controller to provide basic information about the application.
/// </summary>
[StandardRoute]
[ApiController]
[AllowAnonymous]
[EnableCors("AllowAny")]
public class InfoController : ControllerBase
{
    private readonly IMapper _mapper;

    /// <summary>
    /// Returns the information about the application in the headers. The response body is empty.
    /// </summary>
    /// <remarks>
    /// This is a recommended way to get this information in an automated way.
    /// </remarks>
    /// <response code="204">Information about the service is retrieved in headers.</response>
    [HttpHead]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult HeadInfo()
    {
        //var appInfo = _applicationInfoService.GetInfo();

        //var info = _mapper.Map<WebApplicationInfoDto>(appInfo);

        Response.Headers.Add("X-Aurigma-Version", "0.0.0");
        Response.Headers.Add("X-Aurigma-Build-Date", "1971.01.01");
        Response.Headers.Add("X-Aurigma-Configuration", "");
        Response.Headers.Add("X-Aurigma-App-Name", "D-Chat");

        return NoContent();
    }
}
