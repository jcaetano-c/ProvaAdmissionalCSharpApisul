using Newtonsoft.Json;
using ProvaAdmissionalCSharpApisul.Models;
using System;
using System.IO;
using System.Reflection;

namespace ProvaAdmissionalCSharpApisul
{
    public class Program
    {
        public static void Main()
        {
            //string path = "C:\\Users\\jairo\\Projetos\\ProvaAdmissionalCSharpApisul\\ProvaAdmissionalCSharpApisul\\";
            //StreamReader input = new StreamReader(path + "input.json");

            StreamReader input = new StreamReader("..\\..\\..\\input.json");
            string jsonString = input.ReadToEnd();
            ListaDeRespostas levantamento = JsonConvert.DeserializeObject<ListaDeRespostas>(jsonString);

            if (levantamento == null)
            {
                Console.WriteLine("O arquivo está vazio.");
                return ;
            }

            var elevador = new Elevador(levantamento);

            List<int> andarMenosUtilizado = elevador.andarMenosUtilizado();
            Console.WriteLine("Andar menos acessado...");
            foreach (var item in andarMenosUtilizado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

            Console.WriteLine("Elevador mais utilizado...");
            List<char> elevadorMaisFrequentado = elevador.elevadorMaisFrequentado();
            foreach (var item in elevadorMaisFrequentado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

            Console.WriteLine("Elevador menos utilizado...");
            List<char> elevadorMenosFrequentado = elevador.elevadorMenosFrequentado();
            foreach (var item in elevadorMenosFrequentado)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

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
