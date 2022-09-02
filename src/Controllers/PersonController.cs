using Microsoft.AspNetCore.Mvc;
using src.Models;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    [HttpGet]
    public Person GetPerson(){
        Person person = new Person("Henrique", 34, "12345678");
        Contract contract = new Contract("abc123", 50.0);
        person.contracts.Add(contract);
        person.contracts.Add(contract);
        person.contracts.Add(contract);
        return person;        
    }

    [HttpPost]
    public Person Post(Person person){
        
        return person;
    }

    [HttpPut("{id}")]
    public string UpdatePerson([FromRoute]int id, [FromBody] Person person){
        return "Dados do id" + id + " atualizados";
    }

    [HttpDelete("{id}")]
    public string Delete([FromRoute] int id){
        return $"Foi deletado a pessoa do id {id}";
    }

}