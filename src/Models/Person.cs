using System.Collections.Generic;

namespace src.Models;

public class Person
{
    public Person()
    {
        this.name = "template";
        this.idade = 0;
        this.contracts = new List<Contract>();
        this.enable = true;
    }
    public Person(string name, int idade, string? cpf)
    {
        this.name = name;
        this.idade = idade;
        this.cpf = cpf;
        this.contracts = new List<Contract>();
        this.enable = true;
    }

    public int id { get; set; }
    public string name { get; set;}
    public int idade { get; set; }
    public string? cpf { get; set; }
    public bool enable { get; set; }

    public List<Contract> contracts { get; set; }

}