using ProvaAdmissionalCSharpApisul.Models;

namespace ProvaAdmissionalCSharpApisul
{
    public class Elevador : IElevadorService
    {
        ListaDeRespostas Respostas { get; }
        public int MediaAndares { get; }
        public int MediaElevadores { get; }
        public int MediaPeriodos { get; }
        public int QuantidadeDeRespostas { get; }

        private char[] elevadores = { 'A', 'B', 'C', 'D', 'E' };
        private char[] periodos = { 'M', 'V', 'N' };
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
            return obterFrequencia(true);
        }

        public List<char> elevadorMenosFrequentado()
        {
            return obterFrequencia(false);
        }

        private List<char> obterFrequencia(bool maisUtilizado)
        {
            List<char> frequencia = new List<char>();

            for (int i = 0; i < 5; i++)
            {
                int count = Respostas.Respostas.Count(n => n.Elevador == elevadores[i]);
                if (!maisUtilizado && count < MediaElevadores)
                    frequencia.Add(elevadores[i]);
                if (maisUtilizado && count >= MediaElevadores)
                    frequencia.Add(elevadores[i]);
            }
            return frequencia;
        }

        public float percentualDeUsoElevadorA()
        {
            return obterPercentual('A');
        }

        public float percentualDeUsoElevadorB()
        {
            return obterPercentual('B');
        }

        public float percentualDeUsoElevadorC()
        {
            return obterPercentual('C');
        }

        public float percentualDeUsoElevadorD()
        {
            return obterPercentual('D');
        }

        public float percentualDeUsoElevadorE()
        {
            return obterPercentual('E');
        }

        private float obterPercentual(char elevador)
        {
            if (Array.IndexOf(elevadores, elevador) < 0)
            {
                throw new Exception("Elevador inválido.");
                return 0;
            }
            float count = Respostas.Respostas.Count(n => n.Elevador == elevador);
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
