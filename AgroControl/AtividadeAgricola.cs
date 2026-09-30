namespace AgroControl.Classes
{
    public class AtividadeAgricola
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Cultura { get; set; }
        public double Custo { get; set; }
        public DateTime Data { get; set; }

        public AtividadeAgricola(
            string descricao,
            string cultura,
            double custo)
        {
            Id = GeradorId.Gerar();
            Descricao = descricao;
            Cultura = cultura;
            Custo = custo;
            Data = DateTime.Now;
        }
    }
}