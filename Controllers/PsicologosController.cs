using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PsicologosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PsicologosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Psicologo>>> Get()
    {
        return await _context.Psicologos.Include(p => p.Sessoes).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Psicologo>> Post(Psicologo psicologo)
    {
        _context.Psicologos.Add(psicologo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = psicologo.Id }, psicologo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Psicologo psicologo)
    {
        if (id != psicologo.Id)
            return BadRequest();

        _context.Entry(psicologo).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Psicologos.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var psicologo = await _context.Psicologos.FindAsync(id);
        if (psicologo == null)
            return NotFound();

        _context.Psicologos.Remove(psicologo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
