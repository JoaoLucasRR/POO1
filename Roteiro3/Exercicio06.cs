using System;

public class Aluno
{
    private string nome = string.Empty;
    private decimal nota1;
    private decimal nota2;

    public string Nome
    {
        get { return nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome não pode ficar vazio.", nameof(value));
            }

            nome = value;
        }
    }

    public decimal Nota1
    {
        get { return nota1; }
        set
        {
            ValidarNota(value, nameof(Nota1));
            nota1 = value;
        }
    }

    public decimal Nota2
    {
        get { return nota2; }
        set
        {
            ValidarNota(value, nameof(Nota2));
            nota2 = value;
        }
    }

    public decimal Media
    {
        get { return (Nota1 + Nota2) / 2m; }
    }

    private static void ValidarNota(decimal nota, string nomeNota)
    {
        if (nota < 0 || nota > 10)
        {
            throw new ArgumentOutOfRangeException(nomeNota, "A nota deve estar entre 0 e 10.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Aluno aluno = new Aluno();
        aluno.Nome = "Maria";
        aluno.Nota1 = 8;
        aluno.Nota2 = 6;

        Console.WriteLine(aluno.Media);

        aluno.Nota2 = 10;
        Console.WriteLine(aluno.Media);

        // Descomente para confirmar que a média não pode ser alterada diretamente:
        // aluno.Media = 9;
    }
}
