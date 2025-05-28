using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SessoesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SessoesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sessao>>> Get()
    {
        return await _context.Sessoes
            .Include(s => s.Psicologo)
            .Include(s => s.Paciente)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Sessao>> Post(Sessao sessao)
    {
        _context.Sessoes.Add(sessao);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = sessao.Id }, sessao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Sessao sessao)
    {
        if (id != sessao.Id)
            return BadRequest();

        _context.Entry(sessao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sessoes.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sessao = await _context.Sessoes.FindAsync(id);
        if (sessao == null)
            return NotFound();

        _context.Sessoes.Remove(sessao);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
