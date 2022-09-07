using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private DataBaseContext _context { get; set; }
    public PersonController(DataBaseContext context)
    {
        this._context = context;
    }   

    [HttpGet]
    public ActionResult<List<Person>> GetListPerson(){
        var result = _context.Persons.Include(p => p.contracts).ToList();
        if (!result.Any()) {
            return NoContent();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Object> Post([FromBody]Person person)
    {
        try
        {
            _context.Persons.Add(person);
            _context.SaveChanges();     
        }
        catch (System.Exception)
        {
            return BadRequest();            
        }
        return Created("Criado", person);
    }

    [HttpPut("{id}")]
    public ActionResult<Object> UpdatePerson([FromRoute]int id, [FromBody] Person person){

        var result = _context.Persons.SingleOrDefault(e => e.id == id);
        if (result is null){
            return NotFound(new {
                msg = "Registro não encntrado",
                status = HttpStatusCode.BadRequest
            });
        }

        try
        {
            _context.Persons.Update(person);
            _context.SaveChanges();      
        }
        catch (System.Exception)
        {
            return BadRequest(new {
                msg = $"Erros ao enviar solicitação de atualização do {id} da chamada",
                status = HttpStatusCode.BadRequest
            });
        }
        return Ok (new{
            msg = $"Dados do id {id} atualizados",
            status = HttpStatusCode.OK
        });
    }

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id){
        var result = _context.Persons.SingleOrDefault(e => e.id == id);
        
        if (result is null){
            return BadRequest(new {
                msg = "Conteudo inexistente, solicitação inválida",
                status = HttpStatusCode.BadRequest
            });
        }

        _context.Persons.Remove(result);
        _context.SaveChanges();
        return Ok(new {
           msg = $"Foi deletado a pessoa do id {id}",
           status = HttpStatusCode.OK
        });
    }
}