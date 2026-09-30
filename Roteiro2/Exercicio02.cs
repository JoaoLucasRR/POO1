using System;

public class Carro
{
    private string _modelo;
    private int _velocidadeAtual;

    public Carro(string modelo)
    {
        if (string.IsNullOrWhiteSpace(modelo))
        {
            throw new ArgumentException("O modelo do carro não pode ficar vazio.", nameof(modelo));
        }

        _modelo = modelo;
        _velocidadeAtual = 0;
    }

    public string ObterModelo()
    {
        return _modelo;
    }

    public int ObterVelocidadeAtual()
    {
        return _velocidadeAtual;
    }

    public void Acelerar(int valor)
    {
        if (valor < 0)
        {
            Console.WriteLine("O valor da aceleração não pode ser negativo.");
            return;
        }

        if (valor > int.MaxValue - _velocidadeAtual)
        {
            Console.WriteLine("A velocidade máxima foi atingida.");
            return;
        }

        _velocidadeAtual += valor;
    }

    public void Frear(int valor)
    {
        if (valor < 0)
        {
            Console.WriteLine("O valor da frenagem não pode ser negativo.");
            return;
        }

        _velocidadeAtual = Math.Max(0, _velocidadeAtual - valor);
    }

    public void ExibirVelocidade()
    {
        Console.WriteLine($"{_modelo}: velocidade atual de {_velocidadeAtual} km/h.");
    }
}

public class Program
{
    public static void Main()
    {
        Carro carro = new Carro("Civic");
        carro.ExibirVelocidade();

        carro.Acelerar(60);
        carro.ExibirVelocidade();

        carro.Frear(25);
        carro.ExibirVelocidade();

        carro.Frear(50);
        carro.ExibirVelocidade();
    }
}