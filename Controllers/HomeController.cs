using Microsoft.AspNetCore.Mvc;

namespace RecipeBookWebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}
