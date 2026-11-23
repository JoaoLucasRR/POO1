using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Parte A - Manipulação de frases");

        string frase = LerTexto("Digite uma frase com palavras separadas por vírgulas: ");
        string fraseLimpa = frase.Trim();
        string[] partes = fraseLimpa.Split(',');

        Console.WriteLine("Partes da frase:");
        foreach (string parte in partes)
        {
            Console.WriteLine(parte.Trim());
        }

        string palavraOriginal = LerTextoNaoVazio("Digite a palavra que deseja substituir: ");
        string palavraNova = LerTextoNaoVazio("Digite a nova palavra: ");
        string fraseModificada = fraseLimpa.Replace(palavraOriginal, palavraNova);
        Console.WriteLine($"Frase após a substituição: {fraseModificada}");

        string inicio = LerTextoNaoVazio("Digite a palavra para verificar o início da frase: ");
        Console.WriteLine(fraseLimpa.StartsWith(inicio, StringComparison.Ordinal)
            ? "A frase começa com essa palavra."
            : "A frase não começa com essa palavra.");

        string fim = LerTextoNaoVazio("Digite a palavra para verificar o final da frase: ");
        Console.WriteLine(fraseLimpa.EndsWith(fim, StringComparison.Ordinal)
            ? "A frase termina com essa palavra."
            : "A frase não termina com essa palavra.");

        Console.WriteLine();
        Console.WriteLine("Parte B - Verificação e formatação de CPF");

        string cpf = LerTexto("Digite um CPF: ")
            .Trim()
            .Replace(" ", string.Empty)
            .Replace(".", string.Empty)
            .Replace("-", string.Empty);

        bool temOnzeDigitos = cpf.Length == 11;
        bool possuiSomenteDigitos = true;

        foreach (char caractere in cpf)
        {
            if (caractere < '0' || caractere > '9')
            {
                possuiSomenteDigitos = false;
                break;
            }
        }

        bool comecaComDigitoValido = false;
        foreach (char digito in "0123456789")
        {
            if (cpf.StartsWith(digito.ToString(), StringComparison.Ordinal))
            {
                comecaComDigitoValido = true;
                break;
            }
        }

        Console.WriteLine($"Possui exatamente 11 dígitos: {(temOnzeDigitos && possuiSomenteDigitos ? "Sim" : "Não")}");
        Console.WriteLine($"Começa com um dígito válido: {(comecaComDigitoValido ? "Sim" : "Não")}");

        if (temOnzeDigitos && possuiSomenteDigitos && comecaComDigitoValido)
        {
            string cpfFormatado = cpf.Substring(0, 3) + "." +
                                  cpf.Substring(3, 3) + "." +
                                  cpf.Substring(6, 3) + "-" +
                                  cpf.Substring(9, 2);

            Console.WriteLine($"CPF formatado: {cpfFormatado}");
        }
        else
        {
            Console.WriteLine("CPF inválido. Informe exatamente 11 dígitos.");
        }
    }

    private static string LerTexto(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine() ?? throw new InvalidOperationException("A entrada foi encerrada.");
    }

    private static string LerTextoNaoVazio(string mensagem)
    {
        while (true)
        {
            string texto = LerTexto(mensagem).Trim();

            if (!string.IsNullOrEmpty(texto))
            {
                return texto;
            }

            Console.WriteLine("O texto não pode ficar vazio.");
        }
    }
}
