using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP03.Models;

namespace TP03.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }   
    [HttpGet]
    public IActionResult GenerarSugerencia(SugeridorReceta datos)
    {
        ViewBag.Nombre = datos.NombreCocinero;
        ViewBag.Edad = datos.CalcularEdad();
        ViewBag.Plato = datos.DeterminarPlato();
        ViewBag.Tiempo = datos.CalcularTiempo();
        ViewBag.Dificultad = datos.DeterminarDificultad();
        @ViewBag.CantidadPersonas = datos.CantidadPersonas;
        return View("Resultado");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
