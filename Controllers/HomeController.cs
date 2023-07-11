using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RevisionNotes.Models;
using RevisionNotes.Services;

namespace RevisionNotes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MongoService _mongoService;

    public HomeController(MongoService mongoService, ILogger<HomeController> logger)
    {
        _logger = logger;
        _mongoService = mongoService;
    }

    public async Task<IActionResult> Index()
    {
        List<Topic> topics = await _mongoService.GetAllTopicsAsync();
        return View(topics);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
