using System;

public class Produto
{
    private decimal preco;
    private string nome;

    public decimal Preco
    {
        get { return preco; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("O preço não pode ser negativo.");
            }

            preco = value;
        }
    }

    public string Nome
    {
        get { return nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome não pode ficar vazio.");
            }

            nome = value;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Produto produto = new Produto();

        try
        {
            produto.Preco = 100;
            Console.WriteLine($"Preço: {produto.Preco}");

            produto.Preco = 250;
            Console.WriteLine($"Preço: {produto.Preco}");

            produto.Preco = -50;
            Console.WriteLine($"Preço: {produto.Preco}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        try
        {
            produto.Nome = "Notebook";
            Console.WriteLine($"Nome: {produto.Nome}");

            produto.Nome = "";
            Console.WriteLine($"Nome: {produto.Nome}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
