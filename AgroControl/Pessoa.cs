namespace AgroControl.Classes
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }

        public Pessoa(string nome, string documento)
        {
            Id = GeradorId.Gerar();
            Nome = nome;
            Documento = documento;
        }

        public abstract string Descricao();
    }

    public static class GeradorId
    {
        private static int contador = 1;

        public static int Gerar()
        {
            return contador++;
        }
    }
}