using System;

public class ContaBancaria
{
    public string Titular { get; }

    public decimal Saldo { get; private set; }

    public ContaBancaria(string titular)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("O titular não pode ficar vazio.", nameof(titular));
        }

        Titular = titular;
        Saldo = 0m;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O depósito deve ser maior que zero.");
        }

        Saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O saque deve ser maior que zero.");
        }

        if (valor > Saldo)
        {
            throw new InvalidOperationException("Saldo insuficiente.");
        }

        Saldo -= valor;
    }
}

public class Program
{
    public static void Main()
    {
        ContaBancaria conta = new ContaBancaria("Carlos");
        conta.Depositar(1000m);
        conta.Sacar(250m);

        Console.WriteLine(conta.Saldo);

        // Descomente para confirmar o erro de compilação:
        // conta.Saldo = -5000m;
    }
}
