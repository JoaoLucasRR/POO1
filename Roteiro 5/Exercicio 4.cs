using System;
using System.Globalization;
using System.Linq;

public class Program
{
    private static readonly CultureInfo CulturaBrasileira = CultureInfo.GetCultureInfo("pt-BR");

    public static void Main()
    {
        Console.WriteLine("Exercício 4 - Compromisso");
        string nome = LerTextoNaoVazio("Seu nome: ");
        DateTime compromisso = LerDataHora("Data e hora do compromisso (dd/MM/yyyy HH:mm): ");
        int diasRestantes = (compromisso.Date - DateTime.Today).Days;
        string diaDaSemana = compromisso.ToString("dddd", CulturaBrasileira);

        string mensagem = diasRestantes >= 0
            ? string.Format(
                CulturaBrasileira,
                "Olá, {0}!\nSeu compromisso será em {1} dias, na {2}.\nData marcada: {3:dd/MM/yyyy} às {3:HH:mm}",
                nome,
                diasRestantes,
                diaDaSemana,
                compromisso)
            : string.Format(
                CulturaBrasileira,
                "Olá, {0}!\nSeu compromisso foi há {1} dias, na {2}.\nData marcada: {3:dd/MM/yyyy} às {3:HH:mm}",
                nome,
                Math.Abs(diasRestantes),
                diaDaSemana,
                compromisso);

        Console.WriteLine();
        Console.WriteLine(mensagem);
        Console.WriteLine();

        Console.WriteLine("Exercício Integrador - Cadastro de evento");
        string nomeParticipante = LerTextoNaoVazio("Nome do participante: ");
        DateTime dataEvento = LerDataHora("Data e hora do evento (dd/MM/yyyy HH:mm): ");
        decimal valorIngresso = Math.Round(
            LerValorNaoNegativo("Valor do ingresso: "),
            2,
            MidpointRounding.AwayFromZero);
        string categoria = LerCategoria();
        bool categoriaVip = categoria.ToUpperInvariant().Contains("VIP");
        decimal desconto = categoriaVip
            ? Math.Round(valorIngresso * 0.10m, 2, MidpointRounding.AwayFromZero)
            : 0;
        decimal valorFinal = Math.Round(valorIngresso - desconto, 2, MidpointRounding.AwayFromZero);

        ExibirIngresso(nomeParticipante, dataEvento, categoriaVip ? "VIP" : "Comum", valorIngresso, desconto, valorFinal);
    }

    private static void ExibirIngresso(
        string nome,
        DateTime dataEvento,
        string categoria,
        decimal valorIngresso,
        decimal desconto,
        decimal valorFinal)
    {
        string dataFormatada = dataEvento.ToString("dd/MM/yyyy HH:mm", CulturaBrasileira);
        string[] valores = { "Ingresso", "Desconto", "Total" };
        int larguraNome = Math.Max("Participante".Length, nome.Length);
        int larguraData = Math.Max("Data do evento".Length, dataFormatada.Length);
        int larguraCategoria = Math.Max("Categoria".Length, categoria.Length);
        int larguraValor = Math.Max(
            valores.Max(valor => valor.Length),
            Math.Max(
                valorIngresso.ToString("C2", CulturaBrasileira).Length,
                Math.Max(
                    desconto.ToString("C2", CulturaBrasileira).Length,
                    valorFinal.ToString("C2", CulturaBrasileira).Length)));

        string borda = $"+-{new string('-', larguraNome)}-+-{new string('-', larguraData)}-+-{new string('-', larguraCategoria)}-+-{new string('-', larguraValor)}-+-{new string('-', larguraValor)}-+-{new string('-', larguraValor)}-+";
        string formatoCabecalho = $"| {{0,-{larguraNome}}} | {{1,-{larguraData}}} | {{2,-{larguraCategoria}}} | {{3,{larguraValor}}} | {{4,{larguraValor}}} | {{5,{larguraValor}}} |";
        string formatoValores = $"| {{0,-{larguraNome}}} | {{1,-{larguraData}}} | {{2,-{larguraCategoria}}} | {{3,{larguraValor}:C2}} | {{4,{larguraValor}:C2}} | {{5,{larguraValor}:C2}} |";

        Console.WriteLine();
        Console.WriteLine(borda);
        Console.WriteLine(string.Format(
            CulturaBrasileira,
            formatoCabecalho,
            "Participante",
            "Data do evento",
            "Categoria",
            "Ingresso",
            "Desconto",
            "Total"));
        Console.WriteLine(borda);
        Console.WriteLine(string.Format(
            CulturaBrasileira,
            formatoValores,
            nome,
            dataFormatada,
            categoria,
            valorIngresso,
            desconto,
            valorFinal));
        Console.WriteLine(borda);
    }

    private static string LerTextoNaoVazio(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string texto = Console.ReadLine()?.Trim()
                ?? throw new InvalidOperationException("A entrada foi encerrada.");

            if (texto.Length > 0)
            {
                return texto;
            }

            Console.WriteLine("O texto não pode ficar vazio.");
        }
    }

    private static DateTime LerDataHora(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            if (DateTime.TryParseExact(
                    entrada,
                    "dd/MM/yyyy HH:mm",
                    CulturaBrasileira,
                    DateTimeStyles.None,
                    out DateTime dataHora))
            {
                return dataHora;
            }

            Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy HH:mm.");
        }
    }

    private static decimal LerValorNaoNegativo(string mensagem)
    {
        const NumberStyles estilos = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;

        while (true)
        {
            Console.Write(mensagem);
            string? entrada = Console.ReadLine();

            if ((decimal.TryParse(entrada, estilos, CulturaBrasileira, out decimal valor) ||
                 decimal.TryParse(entrada, estilos, CultureInfo.InvariantCulture, out valor)) &&
                valor >= 0)
            {
                return valor;
            }

            Console.WriteLine("Valor inválido. Digite um valor não negativo.");
        }
    }

    private static string LerCategoria()
    {
        while (true)
        {
            Console.Write("Categoria do ingresso (VIP/Comum): ");
            string categoria = Console.ReadLine()?.Trim()
                ?? throw new InvalidOperationException("A entrada foi encerrada.");
            string categoriaMaiuscula = categoria.ToUpperInvariant();

            if (categoriaMaiuscula.Contains("VIP"))
            {
                return "VIP";
            }

            if (categoriaMaiuscula.Contains("COMUM"))
            {
                return "Comum";
            }

            Console.WriteLine("Categoria inválida. Informe VIP ou Comum.");
        }
    }
}
