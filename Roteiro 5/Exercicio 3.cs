using System;
using System.Globalization;
using System.Linq;

public class Program
{
    public static void Main()
    {
        const int quantidadeDeProdutos = 3;
        string[] nomes = new string[quantidadeDeProdutos];
        decimal[] precos = new decimal[quantidadeDeProdutos];
        int[] quantidades = new int[quantidadeDeProdutos];
        decimal subtotal = 0;

        for (int i = 0; i < quantidadeDeProdutos; i++)
        {
            Console.WriteLine($"Produto {i + 1}:");
            nomes[i] = LerTextoNaoVazio("Nome: ");
            precos[i] = LerDecimalNaoNegativo("Preço: ");
            quantidades[i] = LerIntNaoNegativo("Quantidade: ");
            subtotal += precos[i] * quantidades[i];
            Console.WriteLine();
        }

        string[] totaisPorItem = new string[quantidadeDeProdutos];
        for (int i = 0; i < quantidadeDeProdutos; i++)
        {
            totaisPorItem[i] = (precos[i] * quantidades[i]).ToString("F2");
        }

        int larguraProduto = Math.Max("Produto".Length, nomes.Max(nome => nome.Length));
        int larguraPreco = Math.Max("Preço unitário".Length, precos.Max(preco => preco.ToString("C").Length));
        int larguraQuantidade = Math.Max("Quantidade".Length, quantidades.Max(quantidade => quantidade.ToString("N0").Length));
        int larguraTotal = Math.Max("Total do item".Length, totaisPorItem.Max(total => total.Length));

        string linha = $"+-{new string('-', larguraProduto)}-+-{new string('-', larguraPreco)}-+-{new string('-', larguraQuantidade)}-+-{new string('-', larguraTotal)}-+";
        Console.WriteLine(linha);
        Console.WriteLine($"| {"Produto".PadRight(larguraProduto)} | {"Preço unitário".PadLeft(larguraPreco)} | {"Quantidade".PadLeft(larguraQuantidade)} | {"Total do item".PadLeft(larguraTotal)} |");
        Console.WriteLine(linha);

        for (int i = 0; i < quantidadeDeProdutos; i++)
        {
            Console.WriteLine($"| {nomes[i].PadRight(larguraProduto)} | {precos[i].ToString("C").PadLeft(larguraPreco)} | {quantidades[i].ToString("N0").PadLeft(larguraQuantidade)} | {totaisPorItem[i].PadLeft(larguraTotal)} |");
        }

        Console.WriteLine(linha);

        decimal desconto = subtotal * 0.10m;
        decimal totalFinal = subtotal - desconto;

        Console.WriteLine($"Subtotal: {subtotal:N}");
        Console.WriteLine($"Desconto ({0.10m:P}): {desconto:C}");
        Console.WriteLine($"Total final: {totalFinal:C}");
    }

    private static string LerTextoNaoVazio(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string texto = Console.ReadLine()?.Trim()
                ?? throw new InvalidOperationException("A entrada foi encerrada.");

            if (texto.Length > 0)
            {
                return texto;
            }

            Console.WriteLine("O nome não pode ficar vazio.");
        }
    }

    private static decimal LerDecimalNaoNegativo(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            const NumberStyles estilos = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
            if ((decimal.TryParse(entrada, estilos, CultureInfo.CurrentCulture, out decimal valor) ||
                 decimal.TryParse(entrada, estilos, CultureInfo.InvariantCulture, out valor) ||
                 decimal.TryParse(entrada, estilos, CultureInfo.GetCultureInfo("pt-BR"), out valor)) &&
                valor >= 0)
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Digite um preço não negativo.");
        }
    }

    private static int LerIntNaoNegativo(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int valor) && valor >= 0)
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Digite uma quantidade inteira não negativa.");
        }
    }
}
