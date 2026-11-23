using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Digite um número inteiro: ");
        string entrada = Console.ReadLine() ?? string.Empty;

        try
        {
            int numero = int.Parse(entrada);
            Console.WriteLine($"Valor digitado: {numero}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Valor inválido. Por favor, digite um número inteiro.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Valor inválido. Por favor, digite um número inteiro.");
        }
    }
}
