using Newtonsoft.Json;
using ProvaAdmissionalCSharpApisul.Models;

namespace ProvaAdmissionalCSharpApisul
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Informe o caminho do arquivo input.json: ");
            string path = Console.ReadLine();
            StreamReader input = new StreamReader(path);
            //"C:\Users\jairo\Projetos\ProvaAdmissionalCSharpApisul\ProvaAdmissionalCSharpApisul\input.json";

            string jsonString = input.ReadToEnd();
            ListaDeRespostas levantamento = JsonConvert.DeserializeObject<ListaDeRespostas>(jsonString);

            if (levantamento == null)
            {
                Console.WriteLine("O ARQUIVO 'input.json' ESTÁ VAZIO.");
                Console.WriteLine("ENCERRANDO O PROGRAMA...");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

            var elevador = new Elevador(levantamento);

            List<int> andarMenosUtilizado = elevador.andarMenosUtilizado();
            Console.WriteLine("Andar menos acessado...");
            foreach (var item in andarMenosUtilizado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Elevador mais utilizado...");
            List<char> elevadorMaisFrequentado = elevador.elevadorMaisFrequentado();
            foreach (var item in elevadorMaisFrequentado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Elevador menos utilizado...");
            List<char> elevadorMenosFrequentado = elevador.elevadorMenosFrequentado();
            foreach (var item in elevadorMenosFrequentado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Periodo maior fluxo...");
            List<char> periodoMaiorFluxoElevadorMaisFrequentado = elevador.periodoMaiorFluxoElevadorMaisFrequentado();
            foreach (var item in periodoMaiorFluxoElevadorMaisFrequentado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Periodo menor fluxo...");
            List<char> periodoMenorFluxoElevadorMenosFrequentado = elevador.periodoMenorFluxoElevadorMenosFrequentado();
            foreach (var item in periodoMenorFluxoElevadorMenosFrequentado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Periodo maior utilização em conjunto...");
            List<char> periodoMaiorUtilizacaoConjuntoElevadores = elevador.periodoMaiorUtilizacaoConjuntoElevadores();
            foreach (var item in periodoMaiorUtilizacaoConjuntoElevadores)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            Console.Write("Percentual de uso do Elevador A... ");
            float percentualDeUsoElevadorA = elevador.percentualDeUsoElevadorA();
            Console.WriteLine(percentualDeUsoElevadorA + "%");

            Console.Write("Percentual de uso do Elevador B... ");
            float percentualDeUsoElevadorB = elevador.percentualDeUsoElevadorB();
            Console.WriteLine(percentualDeUsoElevadorB + "%");

            Console.Write("Percentual de uso do Elevador C... ");
            float percentualDeUsoElevadorC = elevador.percentualDeUsoElevadorC();
            Console.WriteLine(percentualDeUsoElevadorC + "%");

            Console.Write("Percentual de uso do Elevador D... ");
            float percentualDeUsoElevadorD = elevador.percentualDeUsoElevadorD();
            Console.WriteLine(percentualDeUsoElevadorD + "%");

            Console.Write("Percentual de uso do Elevador E... ");
            float percentualDeUsoElevadorE = elevador.percentualDeUsoElevadorE();
            Console.WriteLine(percentualDeUsoElevadorE + "%");
        }
    }
}
