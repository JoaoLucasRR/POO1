using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Parte A - Arredondamentos");

        for (int i = 1; i <= 5; i++)
        {
            double numero = LerDouble($"Digite o {i}º número decimal: ");

            Console.WriteLine($"Número original: {numero}");
            Console.WriteLine($"Arredondamento padrão: {Math.Round(numero)}");
            Console.WriteLine($"Arredondamento para baixo: {Math.Floor(numero)}");
            Console.WriteLine($"Arredondamento para cima: {Math.Ceiling(numero)}");
            Console.WriteLine($"Truncamento: {Math.Truncate(numero)}");
            Console.WriteLine();
        }

        Console.WriteLine("Parte B - Calculadora de investimento");

        double capitalInicial = LerDouble("Informe o capital inicial: ");
        double taxaMensal = LerDouble("Informe a taxa de juros mensal (em porcentagem): ");
        int numeroDeMeses = LerInt("Informe o número de meses: ");
        double metaDeLucro = LerDouble("Informe a meta de lucro: ");

        double montanteFinal = capitalInicial * Math.Pow(1 + taxaMensal / 100, numeroDeMeses);
        double lucro = montanteFinal - capitalInicial;

        Console.WriteLine($"Montante final: {montanteFinal}");
        Console.WriteLine($"Lucro arredondado: {Math.Round(lucro)}");
        Console.WriteLine(lucro > metaDeLucro
            ? "O lucro supera a meta definida."
            : "O lucro não supera a meta definida.");
    }

    private static double LerDouble(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            if (double.TryParse(entrada, NumberStyles.Float, CultureInfo.CurrentCulture, out double valor) ||
                double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out valor))
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Digite um número decimal.");
        }
    }

    private static int LerInt(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int valor))
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Digite um número inteiro.");
        }
    }
}
