namespace AgroControl.Classes
{
    public class Funcionario : Pessoa
    {
        public string Funcao { get; set; }

        public Funcionario(
            string nome,
            string documento,
            string funcao)
            : base(nome, documento)
        {
            Funcao = funcao;
        }

        public override string Descricao()
        {
            return $"ID: {Id} | Funcionário: {Nome} | Função: {Funcao}";
        }
    }
}