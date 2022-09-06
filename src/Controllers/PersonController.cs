using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;
using Microsoft.EntityFrameworkCore;

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
    public List<Person> GetListPerson(){
        // Person person = new Person("Henrique", 34, "12345678");
        // Contract contract = new Contract("abc123", 50.0);
        // person.contracts.Add(contract);
        // person.contracts.Add(contract);
        // person.contracts.Add(contract);
        return _context.Persons.Include(p => p.contracts).ToList();
    }

    [HttpPost]
    public Person Post([FromBody]Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
        return person;
    }

    [HttpPut("{id}")]
    public string UpdatePerson([FromRoute]int id, [FromBody] Person person){
        _context.Persons.Update(person);
        _context.SaveChanges();
        return "Dados do id " + id + " atualizados";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id){
        var result = _context.Persons.SingleOrDefault(e => e.id == id);
        _context.Persons.Remove(result);
        _context.SaveChanges();
        return $"Foi deletado a pessoa do id {id}";
    }

}