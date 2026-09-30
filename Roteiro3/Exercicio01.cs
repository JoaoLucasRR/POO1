using System;

public class ContaBancaria
{
    private decimal saldo;

    public ContaBancaria(decimal saldoInicial)
    {
        if (saldoInicial < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(saldoInicial), "O saldo inicial não pode ser negativo.");
        }

        saldo = saldoInicial;
    }

    public decimal Saldo
    {
        get
        {
            return saldo;
        }
    }

}

public class Program
{
    public static void Main()
    {
        ContaBancaria conta = new ContaBancaria(1500m);

        Console.WriteLine(conta.Saldo);

        // conta.Saldo = 1000; // ERRO: propriedade somente leitura.
    }
}
