namespace AgroControl.Classes
{
    public class Produtor : Pessoa
    {
        public Produtor(string nome, string documento)
            : base(nome, documento)
        {
        }

        public override string Descricao()
        {
            return $"ID: {Id} | Produtor: {Nome} | Documento: {Documento}";
        }
    }
}