using System;
using System.Globalization;

public class Produto
{
    private string _nome;
    private decimal _preco;

    public Produto(string nome, decimal preco)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do produto não pode ficar vazio.", nameof(nome));
        }

        if (preco < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(preco), "O preço não pode ser negativo.");
        }

        _nome = nome;
        _preco = preco;
    }

    public string ObterNome()
    {
        return _nome;
    }

    public decimal ObterPreco()
    {
        return _preco;
    }

    public void AlterarNome(string novoNome)
    {
        if (string.IsNullOrWhiteSpace(novoNome))
        {
            Console.WriteLine("Erro: o nome do produto não pode ficar vazio.");
            return;
        }

        _nome = novoNome;
    }

    public void ExibirDetalhes()
    {
        string precoFormatado = _preco.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"));
        Console.WriteLine($"Produto: {_nome}");
        Console.WriteLine($"Preço: R$ {precoFormatado}");
    }

    public void AlterarPreco(decimal novoPreco)
    {
        if (novoPreco < 0)
        {
            Console.WriteLine("Erro: o preço não pode ser negativo.");
            return;
        }

        _preco = novoPreco;
        Console.WriteLine("Preço alterado com sucesso.");
    }
}

public class Program
{
    public static void Main()
    {
        Produto produto = new Produto("Notebook", 3500m);
        produto.ExibirDetalhes();

        produto.AlterarPreco(3200m);
        produto.ExibirDetalhes();

        produto.AlterarPreco(-200m);
        Console.WriteLine($"Nome consultado pelo método público: {produto.ObterNome()}");
        Console.WriteLine($"Preço consultado pelo método público: {produto.ObterPreco()}");
    }
}