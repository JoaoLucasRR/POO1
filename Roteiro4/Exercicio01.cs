using System;

public class Veiculo
{
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int NumeroDeRodas { get; set; }

    public void ExibirDados()
    {
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Modelo: {Modelo}");
        Console.WriteLine($"Número de rodas: {NumeroDeRodas}");
    }
}

public class Carro : Veiculo
{
    public int NumeroDePortas { get; set; }
}

public class Moto : Veiculo
{
    public bool PossuiBagageiro { get; set; }
}

public class Program
{
    public static void Main()
    {
        Carro carro = new Carro
        {
            Marca = "Toyota",
            Modelo = "Corolla",
            NumeroDeRodas = 4,
            NumeroDePortas = 4
        };

        Console.WriteLine("Dados do carro:");
        carro.ExibirDados();
        Console.WriteLine($"Número de portas: {carro.NumeroDePortas}");

        Console.WriteLine();

        Moto moto = new Moto
        {
            Marca = "Honda",
            Modelo = "CB 500",
            NumeroDeRodas = 2,
            PossuiBagageiro = true
        };

        Console.WriteLine("Dados da moto:");
        moto.ExibirDados();
        Console.WriteLine($"Possui bagageiro: {(moto.PossuiBagageiro ? "Sim" : "Não")}");
    }
}
