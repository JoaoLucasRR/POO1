using System;

public class Elevador
{
    private int _andarAtual;
    private int _totalAndares;

    public Elevador(int totalAndares)
    {
        if (totalAndares < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(totalAndares), "O total de andares não pode ser negativo.");
        }

        _totalAndares = totalAndares;
        _andarAtual = 0;
    }

    public int ObterAndarAtual()
    {
        return _andarAtual;
    }

    public int ObterTotalAndares()
    {
        return _totalAndares;
    }

    public void Subir()
    {
        if (_andarAtual >= _totalAndares)
        {
            Console.WriteLine("O elevador já está no último andar.");
            return;
        }

        _andarAtual++;
    }

    public void Descer()
    {
        if (_andarAtual <= 0)
        {
            Console.WriteLine("O elevador já está no andar térreo.");
            return;
        }

        _andarAtual--;
    }

    public void ExibirAndar()
    {
        Console.WriteLine($"Andar atual: {_andarAtual}");
    }
}

public class Program
{
    public static void Main()
    {
        Elevador elevador = new Elevador(3);

        elevador.ExibirAndar();
        elevador.Descer();
        elevador.ExibirAndar();

        elevador.Subir();
        elevador.Subir();
        elevador.Subir();
        elevador.Subir();
        elevador.ExibirAndar();

        elevador.Descer();
        elevador.Descer();
        elevador.Descer();
        elevador.Descer();
        elevador.ExibirAndar();
    }
}