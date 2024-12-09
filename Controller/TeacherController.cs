using FluentAPI.Data;
using FluentAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FluentApi.Controller;

[ApiController]
public class TeacherController : ControllerBase
{
    private readonly AppDataContext _context;
    private readonly ILogger<TeacherController> _logger;

    public TeacherController(AppDataContext context, ILogger<TeacherController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("v1/teachers")]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            var teachers = await _context.Teachers.ToListAsync();
            return Ok(teachers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting all teachers.");
            return StatusCode(500, "Internal Server Error. Please try again later.");
        }
    }

    [HttpGet("v1/teachers/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id)
    {
        try
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound("Teacher not found.");
            }

            return Ok(teacher);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while getting teacher with ID: {id}.");
            return StatusCode(500, "Internal Server Error. Please try again later.");
        }
    }

    [HttpPost("v1/teachers")]
    public async Task<IActionResult> PostAsync(
        [FromBody] Teacher teacher)
    {
        if (teacher == null)
            return BadRequest("Teacher data is null.");

        try
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return Created($"v1/teachers/{teacher.TeacherId} - {teacher.Name}", teacher);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating a new teacher.");
            return StatusCode(500, "Internal Server Error. Please try again later.");
        }
    }

    [HttpPut("v1/teachers/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] Teacher teacherUpdate)
    {
        if (teacherUpdate == null)
            return BadRequest("Teacher data is null.");

        try
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound("Teacher not found.");

            teacher.Name = teacherUpdate.Name;

            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating teacher with ID: {id}.");
            return StatusCode(500, "Internal Server Error. Please try again later.");
        }
    }

    [HttpDelete("v1/teachers/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id)
    {
        try
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound("Teacher not found.");

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return Ok($"Removed Teacher: {teacher.Name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting teacher with ID: {id}.");
            return StatusCode(500, "Internal Server Error. Please try again later.");
        }
    }
}