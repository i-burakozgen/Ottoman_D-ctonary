using Backend_dict.Interfaces;
using Backend_dict.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend_dict.Controllers;
[Route("api/[controller]")]
[ApiController]
public class persianTransliterationController :Controller
{
    private readonly IPersianTransliterationRepository _persianTransliterationRepository;

    public persianTransliterationController(IPersianTransliterationRepository persianTransliterationRepository)
    {
        _persianTransliterationRepository = persianTransliterationRepository;
    }

    [HttpGet("bypersian/{name}/")]
    [ProducesResponseType(statusCode: 200, Type = typeof(PersianTransliteration))]
    [ProducesResponseType(statusCode: 400)]
    public IActionResult getPersiantransliterationName (string name)
    {
        var persian = _persianTransliterationRepository.getPersiantransliterationName(name);
        if (persian == null)
        {
            return NotFound();
        }
        return Ok(persian);
    }
}