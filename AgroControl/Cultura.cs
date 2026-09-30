namespace AgroControl.Classes
{
    public class Cultura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double AreaHectares { get; set; }
        public double ProducaoPrevistaToneladas { get; set; }

        public Cultura(
            string nome,
            double areaHectares,
            double producaoPrevistaToneladas)
        {
            Id = GeradorId.Gerar();
            Nome = nome;
            AreaHectares = areaHectares;
            ProducaoPrevistaToneladas = producaoPrevistaToneladas;
        }
    }
}