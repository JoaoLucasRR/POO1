using System;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Exercício 2 - Conversão de temperatura");

        float temperatura = LerTemperatura();

        Console.WriteLine($"Temperatura em Celsius: {temperatura.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"))} °C");
    }

    private static float ConverterParaCelsius(string entrada)
    {
        CultureInfo culturaBrasileira = CultureInfo.GetCultureInfo("pt-BR");

        if (!float.TryParse(entrada, NumberStyles.Float, culturaBrasileira, out float temperatura) &&
            !float.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out temperatura))
        {
            throw new FormatException("Digite apenas um número válido para a temperatura.");
        }

        return temperatura;
    }

    private static float LerTemperatura()
    {
        while (true)
        {
            Console.Write("Informe a temperatura em Celsius: ");
            string entrada = Console.ReadLine()?.Trim() ?? string.Empty;

            try
            {
                return ConverterParaCelsius(entrada);
            }
            catch (FormatException erro)
            {
                Console.WriteLine($"Entrada inválida: {erro.Message}");
            }
        }
    }
}
