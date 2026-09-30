using System;
using System.Globalization;

public class ContaBancaria
{
    public string Titular = string.Empty;
    public string NumeroConta = string.Empty;
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo.");
            return;
        }

        Saldo += valor;
        Console.WriteLine($"Depósito de R$ {valor.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"))} realizado.");
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo.");
            return;
        }

        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque.");
            return;
        }

        Saldo -= valor;
        Console.WriteLine($"Saque de R$ {valor.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"))} realizado.");
    }

    public void ExibirSaldo()
    {
        string saldoFormatado = Saldo.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"));
        Console.WriteLine($"Conta {NumeroConta} - {Titular}: R$ {saldoFormatado}");
    }
}

public class Program
{
    public static void Main()
    {
        ContaBancaria conta1 = new ContaBancaria();
        conta1.Titular = "Joao";
        conta1.NumeroConta = "001";
        conta1.Depositar(1000m);
        conta1.Sacar(300m);

        ContaBancaria conta2 = new ContaBancaria();
        conta2.Titular = "Maria";
        conta2.NumeroConta = "002";
        conta2.Depositar(200m);
        conta2.Sacar(250m);

        conta1.ExibirSaldo();
        conta2.ExibirSaldo();
    }
}