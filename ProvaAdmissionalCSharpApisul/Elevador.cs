using ProvaAdmissionalCSharpApisul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAdmissionalCSharpApisul
{
    public class Elevador : IElevadorService
    {
        ListaDeRespostas Respostas { get; set; }
        public int MediaAndares { get; set; }
        public int MediaElevadores { get; set; }
        public int MediaPeriodos { get; set; }
        public int QuantidadeDeRespostas { get; set; }
        public Elevador(ListaDeRespostas respostas)
        {
            Respostas = respostas;
            QuantidadeDeRespostas = Respostas.Respostas.Count;
            MediaAndares = QuantidadeDeRespostas / 16;
            MediaElevadores = QuantidadeDeRespostas / 5;
            MediaPeriodos = QuantidadeDeRespostas / 3;
        }
        public List<int> andarMenosUtilizado()
        {
            List<int> andarMenosUtilizado = new List<int>();

            for (int i = 0; i <= 15; i++)
            {
                int count = Respostas.Respostas.Count(n => n.Andar == i);
                if (count < MediaAndares)
                    andarMenosUtilizado.Add(i);
            }

            return andarMenosUtilizado;
        }

        public List<char> elevadorMaisFrequentado()
        {
            List<char> elevadorMaisFrequentado = new List<char>();
            char[] elevadores = { 'A', 'B', 'C', 'D', 'E' };

            for (int i = 0; i < 5; i++)
            {
                int count = Respostas.Respostas.Count(n => n.Elevador == elevadores[i]);
                if (count >= MediaElevadores)
                    elevadorMaisFrequentado.Add(elevadores[i]);
                //Console.WriteLine($"Elevador: {elevadores[i]} é usado em média {count} vezes.");
            }

            return elevadorMaisFrequentado;
        }

        public List<char> elevadorMenosFrequentado()
        {
            List<char> elevadorMenosFrequentado = new List<char>();
            char[] elevadores = { 'A', 'B', 'C', 'D', 'E' };

            for (int i = 0; i < 5; i++)
            {
                int count = Respostas.Respostas.Count(n => n.Elevador == elevadores[i]);
                if (count < MediaElevadores)
                    elevadorMenosFrequentado.Add(elevadores[i]);
                //Console.WriteLine($"Elevador: {elevadores[i]} é usado em média {count} vezes.");
            }

            return elevadorMenosFrequentado;
        }

        public float percentualDeUsoElevadorA()
        {
            int count = Respostas.Respostas.Count(n => n.Elevador == 'A');
            float porcentagem = (count * 100) / QuantidadeDeRespostas;
            return porcentagem;
        }

        public float percentualDeUsoElevadorB()
        {
            int count = Respostas.Respostas.Count(n => n.Elevador == 'B');
            float porcentagem = (count * 100) / QuantidadeDeRespostas;
            return porcentagem;
        }

        public float percentualDeUsoElevadorC()
        {
            int count = Respostas.Respostas.Count(n => n.Elevador == 'C');
            float porcentagem = (count * 100) / QuantidadeDeRespostas;
            return porcentagem;
        }

        public float percentualDeUsoElevadorD()
        {
            int count = Respostas.Respostas.Count(n => n.Elevador == 'D');
            float porcentagem = (count * 100) / QuantidadeDeRespostas;
            return porcentagem;
        }

        public float percentualDeUsoElevadorE()
        {
            int count = Respostas.Respostas.Count(n => n.Elevador == 'E');
            float porcentagem = (count * 100) / QuantidadeDeRespostas;
            return porcentagem;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> periodoMaiorFluxoElevadorMaisFrequentado = new List<char>();
            List<char> elevador = elevadorMaisFrequentado();

            foreach (var item in elevador)
            {
                int matutino = Respostas.Respostas.Count(n => n.Elevador == item && n.Periodo == 'M');
                int vespertino = Respostas.Respostas.Count(n => n.Elevador == item && n.Periodo == 'V');
                int noturno = Respostas.Respostas.Count(n => n.Elevador == item && n.Periodo == 'N');

                if (matutino > vespertino && matutino > noturno)
                    periodoMaiorFluxoElevadorMaisFrequentado.Add('M');
                else if (vespertino > matutino && vespertino > noturno)
                    periodoMaiorFluxoElevadorMaisFrequentado.Add('V');
                else
                    periodoMaiorFluxoElevadorMaisFrequentado.Add('N');
            }

            return periodoMaiorFluxoElevadorMaisFrequentado;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            List<char> periodoMaiorUtilizacaoConjuntoElevadores = new List<char>();
            char[] periodos = { 'M', 'V', 'N' };

            for (int i = 0; i < 3; i++)
            {
                int count = Respostas.Respostas.Count(n => n.Periodo == periodos[i]);
                if (count >= MediaPeriodos)
                    periodoMaiorUtilizacaoConjuntoElevadores.Add(periodos[i]);
            }

            return periodoMaiorUtilizacaoConjuntoElevadores;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> periodoMenorFluxoElevadorMenosFrequentado = new List<char>();
            List<char> elevador = elevadorMenosFrequentado();

            foreach (var item in elevador)
            {
                int matutino = Respostas.Respostas.Count(n => n.Elevador == item && n.Periodo == 'M');
                int vespertino = Respostas.Respostas.Count(n => n.Elevador == item && n.Periodo == 'V');
                int noturno = Respostas.Respostas.Count(n => n.Elevador == item && n.Periodo == 'N');

                if (matutino < vespertino && matutino < noturno)
                    periodoMenorFluxoElevadorMenosFrequentado.Add('M');
                else if (vespertino < matutino && vespertino < noturno)
                    periodoMenorFluxoElevadorMenosFrequentado.Add('V');
                else
                    periodoMenorFluxoElevadorMenosFrequentado.Add('N');
            }

            return periodoMenorFluxoElevadorMenosFrequentado;
        }
    }
}
