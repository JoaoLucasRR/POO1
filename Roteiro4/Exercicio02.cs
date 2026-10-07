using System;

public class Pessoa
{
    public string Nome { get; set; } = string.Empty;
}

public class Casa
{
    public Pessoa Morador { get; set; } = new Pessoa();

    public void ExibirMorador()
    {
        Console.WriteLine($"Morador da casa: {Morador.Nome}");
    }
}

public class Program
{
    public static void Main()
    {
        Pessoa pessoa = new Pessoa
        {
            Nome = "Maria"
        };

        Casa casa = new Casa
        {
            Morador = pessoa
        };

        casa.ExibirMorador();
    }
}
