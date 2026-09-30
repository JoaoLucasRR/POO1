using System;

public class Fantasma
{
    public string Habilidade = string.Empty;
    public string Nick = string.Empty;
    public string Cor = string.Empty;

    public void GerarFantasma()
    {
        Console.WriteLine($"Fantasma: {Nick}");
        Console.WriteLine($"Habilidade: {Habilidade}");
        Console.WriteLine($"Cor: {Cor}");
    }

    public void Mover(string direcao)
    {
        Console.WriteLine($"{Nick} se moveu para {direcao}.");
    }
}

public class Program
{
    public static void Main()
    {
        Fantasma fantasma = new Fantasma();
        fantasma.Habilidade = "Perseguição";
        fantasma.Nick = "Blinky";
        fantasma.Cor = "Vermelho";

        fantasma.GerarFantasma();
        fantasma.Mover("direita");
    }
}