using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Exercício 1 - Validação de produto");

        try
        {
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine()?.Trim() ?? string.Empty;
            ValidarNome(nome);

            Console.Write("Preço do produto: ");
            string? entradaPreco = Console.ReadLine();

            if (!decimal.TryParse(
                    entradaPreco,
                    NumberStyles.Number,
                    CultureInfo.GetCultureInfo("pt-BR"),
                    out decimal preco))
            {
                throw new ArgumentOutOfRangeException("preco", "O preço informado não é um número válido.");
            }

            ValidarPreco(preco);

            Console.WriteLine();
            Console.WriteLine($"Produto válido: {nome}");
            Console.WriteLine($"Preço: {preco:C2}");
        }
        catch (ArgumentOutOfRangeException erro)
        {
            Console.WriteLine($"Erro no preço do produto: {erro.Message}");
        }
        catch (ArgumentException erro)
        {
            Console.WriteLine($"Erro no nome do produto: {erro.Message}");
        }
    }

    private static void ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome não pode ficar em branco.");
        }
    }

    private static void ValidarPreco(decimal preco)
    {
        if (preco <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(preco), "O preço deve ser maior que zero.");
        }
    }
}
