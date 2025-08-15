using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ScraperController : ControllerBase
{
    private readonly ScraperService _scraper;

    public ScraperController(ScraperService scraper)
    {
        _scraper = scraper;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string url)
    {
        if (string.IsNullOrWhiteSpace(url))
            return BadRequest("Brak URL");

        var spell = await _scraper.ScrapeAsync(url);
        if (spell == null)
            return NotFound("Nie uda�o si� pobra� zakl�cia");

        var macro = _scraper.GenerateMacro(spell);
        return Ok(macro);
    }

}
