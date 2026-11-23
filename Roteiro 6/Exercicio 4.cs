using System;

public class IdadeInvalidaException : Exception
{
    public IdadeInvalidaException(string mensagem)
        : base(mensagem)
    {
    }
}

public class Program
{
    public static void Main()
    {
        Console.Write("Digite a idade: ");
        string entrada = Console.ReadLine() ?? string.Empty;

        try
        {
            int idade = int.Parse(entrada);
            VerificarIdade(idade);
        }
        catch (IdadeInvalidaException erro)
        {
            Console.WriteLine($"Erro: {erro.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Digite uma idade válida.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Erro: Digite uma idade válida.");
        }
    }

    private static void VerificarIdade(int idade)
    {
        if (idade < 18)
        {
            throw new IdadeInvalidaException("Idade mínima para acesso é 18 anos.");
        }

        Console.WriteLine("Acesso permitido.");
    }
}
