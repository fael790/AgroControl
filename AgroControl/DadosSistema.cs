namespace AgroControl.Classes
{
    public class DadosSistema
    {
        public List<Produtor> Produtores { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Cultura> Culturas { get; set; }
        public List<Maquina> Maquinas { get; set; }
        public List<Insumo> Insumos { get; set; }
        public List<AtividadeAgricola> Atividades { get; set; }

        public DadosSistema()
        {
            Produtores = new List<Produtor>();
            Funcionarios = new List<Funcionario>();
            Culturas = new List<Cultura>();
            Maquinas = new List<Maquina>();
            Insumos = new List<Insumo>();
            Atividades = new List<AtividadeAgricola>();
        }
    }
}