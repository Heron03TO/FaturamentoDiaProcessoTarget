

// Ainda não tive muita familiaridade com esse tipo de código puxando dados de outros arquivos, fiz o possível. Obrigado XD

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FaturamentoDistribuidora
{
    class Program
    {
        static void Main(string[] args)
        {
           
            XDocument xml = XDocument.Load("C:/Users/VAIO/desktop/Projetos/CódigosDoProcessoSeletivoTarget/dadosTarget.xml");

           
            IEnumerable<XElement> rows = xml.Root.Elements("row");

            
            List<double> faturamentoDiario = new List<double>();

           
            foreach (XElement row in rows)
            {
                double valor = double.Parse(row.Element("valor").Value);
                faturamentoDiario.Add(valor);
            }

            
            double menorFaturamento = faturamentoDiario.Min();

           
            double maiorFaturamento = faturamentoDiario.Max();

            
            double mediaMensal = faturamentoDiario.Average();

            int diasAcimaDaMedia = faturamentoDiario.Count(f => f > mediaMensal);

            
            Console.WriteLine($"Menor faturamento diário: R${menorFaturamento}");
            Console.WriteLine($"Maior faturamento diário: R${maiorFaturamento}");
            Console.WriteLine($"Número de dias com faturamento diário acima da média mensal: {diasAcimaDaMedia}");

            Console.ReadLine();
        }
    }
}

