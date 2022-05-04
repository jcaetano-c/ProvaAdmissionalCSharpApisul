namespace ProvaAdmissionalCSharpApisul.Models
{
    public partial class ListaDeRespostas
    {
        public List<Resposta> Respostas { get; set; }
    }

    public partial class Resposta
    {
        public short Andar { get; set; }
        public char Elevador { get; set; }
        public char Periodo { get; set; }
    }
}
