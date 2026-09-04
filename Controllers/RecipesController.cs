using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBookWebApp.Data;
using RecipeBookWebApp.Models;

namespace RecipeBookWebApp.Controllers;

public class RecipesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RecipesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? searchString)
    {
        IQueryable<Recipe> recipes = _context.Recipes;

        var search = searchString?.Trim().ToLower();

        if (!string.IsNullOrWhiteSpace(search))
        {
            recipes = recipes.Where(r =>
                r.Title.ToLower().Contains(search) ||
                (r.Category != null && r.Category.ToLower().Contains(search)) ||
                r.Ingredients.ToLower().Contains(search));
        }

        ViewData["CurrentFilter"] = searchString;

        return View(await recipes
            .OrderBy(r => r.Title)
            .ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id is null)
            return NotFound();

        var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

        return recipe is null ? NotFound() : View(recipe);
    }

    public IActionResult Create()
    {
        return View(new Recipe());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Title,Category,Servings,PrepTimeMinutes,CookTimeMinutes,Ingredients,Instructions,Notes,Source")] Recipe recipe)
    {
        if (!ModelState.IsValid)
            return View(recipe);

        recipe.CreatedAt = DateTime.Now;

        _context.Add(recipe);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null)
            return NotFound();

        var recipe = await _context.Recipes.FindAsync(id);

        return recipe is null ? NotFound() : View(recipe);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,Title,Category,Servings,PrepTimeMinutes,CookTimeMinutes,Ingredients,Instructions,Notes,Source,CreatedAt")] Recipe recipe)
    {
        if (id != recipe.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(recipe);

        try
        {
            _context.Update(recipe);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Recipes.Any(r => r.Id == recipe.Id))
                return NotFound();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null)
            return NotFound();

        var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);

        return recipe is null ? NotFound() : View(recipe);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe is not null)
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
