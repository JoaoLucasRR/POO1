using System;

public class Retangulo
{
    private double largura;
    private double altura;

    public double Largura
    {
        get { return largura; }
        set { largura = value; }
    }

    public double Altura
    {
        get { return altura; }
        set { altura = value; }
    }

    public double Area
    {
        get { return largura * altura; }
    }
}

public class Program
{
    public static void Main()
    {
        Retangulo retangulo = new Retangulo();

        retangulo.Largura = 10;
        retangulo.Altura = 5;

        Console.WriteLine($"Area: {retangulo.Area}");

        retangulo.Largura = 20;

        Console.WriteLine($"Nova area: {retangulo.Area}");
    }
}
