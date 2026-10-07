using System;

public class Conta
{
    public decimal Saldo { get; private set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(valor), "O depósito deve ser maior que zero.");
        }

        Saldo += valor;
    }
}

public class Program
{
    public static void Main()
    {
        Conta conta = new Conta();
        conta.Depositar(1000m);
        Console.WriteLine(conta.Saldo);

        // Descomente para confirmar que o saldo não pode ser alterado externamente:
        // conta.Saldo = -999999m;
    }
}

/*
Respostas da análise:
1. Pode ser quebrada a regra de que o saldo não deve ser alterado arbitrariamente,
   por exemplo, deixando a conta com saldo negativo.
2. Usando get; private set;, o saldo pode ser consultado externamente, mas só
   alterado dentro da classe.
3. Depositar() pertence à classe Conta e, por isso, pode alterar a propriedade
   com private set.
4. Sim. Um get; set; público pode ser aceitável em objetos simples de transporte
   de dados (DTOs), quando não há regras ou invariantes a proteger.
*/
