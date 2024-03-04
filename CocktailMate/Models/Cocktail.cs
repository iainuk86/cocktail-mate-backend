namespace CocktailMate.Models;

public class Cocktail
{
    public Guid CocktailId { get; set; }
    public string Name { get; set; }
    public string Flavour { get; set; }
    public string Ingredients { get; set; }
    public string Method { get; set; }
    public string Glass { get; set; }
    public string Ice { get; set; }
    public string Garnish { get; set; }
    public string Spirit { get; set; }
}