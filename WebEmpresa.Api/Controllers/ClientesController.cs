using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEmpresa.Api.Data;
using WebEmpresa.Api.Models;

namespace WebEmpresa.Api.Controllers;

// Ruta resultante: api/Clientes (la que usa Cliente.razor)
[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _db;

    public ClientesController(AppDbContext db) => _db = db;

    // GET api/Clientes
    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> Get() =>
        await _db.Clientes.AsNoTracking().OrderBy(c => c.Id).ToListAsync();

    // GET api/Clientes/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Cliente>> Get(int id)
    {
        var cliente = await _db.Clientes.FindAsync(id);
        return cliente is null ? NotFound() : cliente;
    }

    // POST api/Clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> Post(Cliente cliente)
    {
        cliente.Id = 0;
        _db.Clientes.Add(cliente);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }

    // PUT api/Clientes/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, Cliente cliente)
    {
        if (id != cliente.Id) return BadRequest("El id de la URL no coincide con el del cliente.");

        var existente = await _db.Clientes.FindAsync(id);
        if (existente is null) return NotFound();

        existente.CUI = cliente.CUI;
        existente.NIT = cliente.NIT;
        existente.Nombres = cliente.Nombres;
        existente.Apellidos = cliente.Apellidos;
        existente.Direccion = cliente.Direccion;
        existente.Telefono = cliente.Telefono;
        existente.FechaNacimiento = cliente.FechaNacimiento;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE api/Clientes/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _db.Clientes.FindAsync(id);
        if (cliente is null) return NotFound();

        _db.Clientes.Remove(cliente);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
