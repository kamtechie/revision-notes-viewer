using RevisionNotes.Models;
using Microsoft.AspNetCore.Mvc;
using RevisionNotes.Services;

namespace RevisionNotes.Controllers;
public class NoteController : Controller
{
    private readonly MongoService _mongoService;

    public NoteController(MongoService mongoService)
    {
        _mongoService = mongoService;
    }

    public async Task<IActionResult> View(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var note = await _mongoService.GetNoteByIdAsync(id);

        if (note == null)
        {
            return NotFound();
        }
        return View(note);
    }
}