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

        var topic = await _mongoService.GetTopicByIdAsync(id);
        var note = await _mongoService.GetNoteByTopicIdAsync(id);

        if (note == null || topic == null)
        {
            return NotFound();
        }

        ViewData["TopicName"] = topic.name;
        ViewData["TopicBoard"] = topic.board;
        ViewData["TopicLevel"] = topic.level;
        ViewData["TopicSubject"] = topic.subject;
        return View(note);
    }
}