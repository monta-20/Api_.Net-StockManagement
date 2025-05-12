Pour effectuer une requête GET avec Include() en ASP.NET Core (avec Entity Framework Core), cela permet de charger les données liées (relationnelles) — par exemple : les commentaires d’un stock (Stock → Comments).

✅ Exemple concret : GET un Stock avec ses commentaires
1. 🧱 Modèle Stock
csharp

public class Stock
{
    public int Id { get; set; }
    public string Symbol { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
2. 🧱 Modèle Comment
csharp

public class Comment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; }
    public int StockId { get; set; }
    public Stock Stock { get; set; }
}
3. 🌐 Méthode GET dans le controller
csharp

[HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
{
    var stock = await _context.Stock
        .Include(s => s.Comments) // 👈 Charger les commentaires liés
        .FirstOrDefaultAsync(s => s.Id == id);

    if (stock == null)
        return NotFound();

    return Ok(stock);
}
🎯 Résultat
Tu reçois dans le JSON le stock et la liste de ses commentaires :

json

{
  "id": 1,
  "symbol": "AAPL",
  "comments": [
    {
      "id": 1,
      "title": "Bon investissement",
      "content": "Croissance stable",
      "createdOn": "2024-05-10T12:00:00"
    }
  ]
}

Install : NewtonSoft.json , Microsoft.AspNetCore.MVc.NewtonSoft.json

| Nom                                       | Utilisation                                              | Projet                |
| ----------------------------------------- | -------------------------------------------------------- | --------------------- |
| `Newtonsoft.Json`                         | Sérialisation JSON (librairie)                           | Tous types de projets |
| `Microsoft.AspNetCore.Mvc.NewtonsoftJson` | Intégration de `Newtonsoft.Json` dans ASP.NET Core (API) | Projets Web/API       |


Add program.cs :

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
