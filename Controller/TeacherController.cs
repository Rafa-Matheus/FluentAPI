using FluentAPI.Data;
using FluentAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentApi.Controller;

[ApiController]
public class TeacherController : ControllerBase
{
    [HttpGet("v1/teachers")]
    public async Task<IActionResult> GetAsync(
        [FromServices] AppDataContext context)
    {
        try
        {
            var teachers = await context.Teachers.ToListAsync();
            return Ok(teachers);
        }
        catch (Exception e)
        {
            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }

    [HttpGet("v1/teachers/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] AppDataContext context)
    {
        try
        {
            var teacher = await context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);

            if (teacher == null)
                return NotFound();
            
            return Ok(teacher);
        }
        catch (Exception e)
        {
            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }

    [HttpPost("v1/teachers")]
    public async Task<IActionResult> PostAsync(
        [FromServices] AppDataContext context,
        [FromBody] Teacher teacher)
    {
        if (teacher == null)
            return BadRequest("Teacher data is null.");
        
        try
        {
            await context.Teachers.AddAsync(teacher);
            await context.SaveChangesAsync();

            return Created($"v1/teachers/{teacher.TeacherId} - {teacher.Name}", teacher);
        }
        catch (Exception e)
        {
            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }

    [HttpPut("v1/teachers/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] Teacher teacherUpdate,
        [FromServices] AppDataContext context)
    {
        if (teacherUpdate == null)
            BadRequest("Teacher data is null.");

        try
        {
            var teacher = context.Teachers.FirstOrDefault(x => x.TeacherId == id);

            if (teacher == null)
                return NotFound();
                
            teacher.Name = teacherUpdate.Name;
            
            context.Teachers.Update(teacher);
            await context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }

    [HttpDelete("v1/teachers/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id,
        [FromServices] AppDataContext context)
    {
        try
        {
            var teacher = await context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);

            if (teacher == null)
                return NotFound();
            
            context.Teachers.Remove(teacher);
            await context.SaveChangesAsync();

            return Ok($"Removed Teacher: {teacher.Name}");
        }
        catch (Exception e)
        {
            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }
}