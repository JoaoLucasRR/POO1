using System;

public class Pessoa
{
    public string Nome = string.Empty;
    public int Idade;
    public string Cargo = string.Empty;

    public void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {Nome}, tenho {Idade} anos e trabalho como {Cargo}.");
    }

    public void InformarSalario()
    {
        string salario = Cargo switch
        {
            "Gerente" => "R$ 10.000,00",
            "Desenvolvedor" => "R$ 5.000,00",
            "Estagiário" => "R$ 100,00",
            _ => "Salário não cadastrado"
        };

        Console.WriteLine($"Salário de {Cargo}: {salario}");
    }
}

public class Program
{
    public static void Main()
    {
        Pessoa p1 = new Pessoa();
        p1.Nome = "Joao";
        p1.Idade = 30;
        p1.Cargo = "Gerente";

        Pessoa p2 = new Pessoa();
        p2.Nome = "Maria";
        p2.Idade = 25;
        p2.Cargo = "Desenvolvedor";

        Pessoa p3 = new Pessoa();
        p3.Nome = "Pedro";
        p3.Idade = 20;
        p3.Cargo = "Estagiário";

        Pessoa p4 = new Pessoa();
        p4.Nome = "Ana";
        p4.Idade = 28;
        p4.Cargo = "Desenvolvedor";

        Pessoa[] pessoas = { p1, p2, p3, p4 };

        foreach (Pessoa pessoa in pessoas)
        {
            pessoa.Apresentar();
            pessoa.InformarSalario();
        }
    }
}