using System;

public class Produto
{
    private string nome = string.Empty;
    private string codigo = string.Empty;
    private decimal preco;

    public string Nome
    {
        get { return nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O nome é obrigatório.", nameof(value));
            }

            nome = value;
        }
    }

    public string Codigo
    {
        get { return codigo; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("O código é obrigatório.", nameof(value));
            }

            codigo = value;
        }
    }

    public decimal Preco
    {
        get { return preco; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "O preço não pode ser negativo.");
            }

            preco = value;
        }
    }

    public int QuantidadeEstoque { get; private set; }

    public bool EstoqueBaixo
    {
        get { return QuantidadeEstoque <= 5; }
    }

    public Produto(string nome, string codigo, decimal preco)
    {
        Nome = nome;
        Codigo = codigo;
        Preco = preco;
        QuantidadeEstoque = 0;
    }

    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade adicionada deve ser maior que zero.");
        }

        QuantidadeEstoque += quantidade;
    }

    public void RemoverEstoque(int quantidade)
    {
        if (quantidade <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade removida deve ser maior que zero.");
        }

        if (quantidade > QuantidadeEstoque)
        {
            throw new InvalidOperationException("Não há estoque suficiente para essa remoção.");
        }

        QuantidadeEstoque -= quantidade;
    }
}

public class Program
{
    public static void Main()
    {
        Produto produto = new Produto("Caderno", "CAD-001", 12.50m);

        produto.AdicionarEstoque(20);
        Console.WriteLine(produto.QuantidadeEstoque);

        produto.RemoverEstoque(10);
        Console.WriteLine(produto.QuantidadeEstoque);
        Console.WriteLine(produto.EstoqueBaixo);

        // Descomente para confirmar que a quantidade não pode ser alterada diretamente:
        // produto.QuantidadeEstoque = 500;
    }
}
