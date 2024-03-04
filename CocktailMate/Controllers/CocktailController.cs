using CocktailMate.Data;
using Microsoft.AspNetCore.Mvc;

namespace CocktailMate.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CocktailController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public CocktailController(AppDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Returns either all cocktails or filters the cocktails by the provided request parameter
    /// </summary>
    /// <param name="spirit">The spirit by which to filter the cocktails</param>
    /// <returns>The </returns>
    [HttpGet]
    public IActionResult GetCocktails(string spirit)
    {
        try
        {
            return string.IsNullOrEmpty(spirit) 
                ? Ok(_context.Cocktails) 
                : Ok(_context.Cocktails.Where(c => c.Spirit == spirit));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Retrieve a cocktail by using its cocktail ID.
    /// </summary>
    /// <param name="id">Cocktail ID in GUID format.</param>
    /// <returns>The corresponding cocktail if found, null otherwise</returns>
    [HttpGet("{id}")]
    public IActionResult GetCocktailByCocktailId(string id)
    {
        try
        {
            return Ok(_context.Cocktails.Find(Guid.Parse(id)));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
