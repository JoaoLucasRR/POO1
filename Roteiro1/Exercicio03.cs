using System;
using System.Globalization;

public class Produto
{
    public string Nome = string.Empty;
    public decimal Preco;
    public int Quantidade;

    public void ExibirDados()
    {
        Console.WriteLine($"Produto: {Nome}");
        Console.WriteLine($"Preço unitário: R$ {Preco.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"))}");
        Console.WriteLine($"Quantidade: {Quantidade}");
    }

    public decimal CalcularValorTotal()
    {
        return Preco * Quantidade;
    }
}

public class Program
{
    public static void Main()
    {
        Produto produto1 = new Produto();
        produto1.Nome = "Caderno";
        produto1.Preco = 15.50m;
        produto1.Quantidade = 3;

        Produto produto2 = new Produto();
        produto2.Nome = "Caneta";
        produto2.Preco = 2.75m;
        produto2.Quantidade = 10;

        Produto produto3 = new Produto();
        produto3.Nome = "Mochila";
        produto3.Preco = 89.90m;
        produto3.Quantidade = 2;

        Produto[] produtos = { produto1, produto2, produto3 };

        foreach (Produto produto in produtos)
        {
            produto.ExibirDados();
            Console.WriteLine($"Valor total: R$ {produto.CalcularValorTotal().ToString("F2", CultureInfo.GetCultureInfo("pt-BR"))}");
            Console.WriteLine();
        }
    }
}