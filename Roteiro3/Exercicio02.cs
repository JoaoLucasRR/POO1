using System;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
}

public class Program
{
    public static void Main()
    {
        Pessoa pessoa = new Pessoa();

        pessoa.Nome = "Maria";
        pessoa.Idade = 20;
        pessoa.Email = "maria@email.com";

        Console.WriteLine($"Nome: {pessoa.Nome}");
        Console.WriteLine($"Idade: {pessoa.Idade}");
        Console.WriteLine($"Email: {pessoa.Email}");

        pessoa.Idade = 21;

        Console.WriteLine($"Nova idade: {pessoa.Idade}");

    }
}
