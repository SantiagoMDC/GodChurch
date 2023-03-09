using System;
using System.Collections.Generic;
using System.Linq;
using Logica;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using God_Church.Models;
using Datos;

namespace God_Church.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MiembroController : ControllerBase
{
    private readonly MiembroService _miembroService;
    public IConfiguration Configuration { get; }
    public MiembroController(IConfiguration configuration)
    {
        Configuration = configuration;
        string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        _miembroService = new MiembroService(connectionString);
    }
    // GET: api/Persona
    [HttpGet]
    public IEnumerable<MiembroViewModel> Gets()
    {
        var miembros = _miembroService.ConsultarTodos().Select(p => new MiembroViewModel(p));
        return miembros;
    }

    // GET: api/Persona/5
    [HttpGet("{identificacion}")]
    public ActionResult<MiembroViewModel> Get(string identificacion)
    {
        var miembro = _miembroService.BuscarxIdentificacion(identificacion);
        if (miembro == null) return NotFound();
        var miembroViewModel = new MiembroViewModel(miembro);
        return miembroViewModel;
    }
    // POST: api/Persona
    [HttpPost]
    public ActionResult<MiembroViewModel> Post(MiembroInputModel miembroInput)
    {
        Miembro miembro = MapearMiembro(miembroInput);
        var response = _miembroService.Guardar(miembro);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Miembro);
    }
    // DELETE: api/Persona/5
    [HttpDelete("{identificacion}")]
    public ActionResult<string> Delete(string identificacion)
    {
        string mensaje = _miembroService.Eliminar(identificacion);
        return Ok(mensaje);
    }
    private Miembro MapearMiembro(MiembroInputModel miembroInput)
    {
        var miembro = new Miembro
        {
            Identificacion = miembroInput.Identificacion,
            Nombre = miembroInput.Nombre,
            FechaNacimiento = miembroInput.FechaNacimiento,
            Sexo = miembroInput.Sexo,
            Direccion = miembroInput.Direccion,
            Telefono = miembroInput.Telefono
        };
        return miembro;
    }
    // PUT: api/Persona/5
    [HttpPut("{identificacion}")]
    public ActionResult<string> Put(string identificacion, Miembro miembro)
    {
        throw new NotImplementedException();
    }
}