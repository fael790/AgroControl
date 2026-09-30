namespace AgroControl.Classes
{
    public class Insumo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Quantidade { get; set; }
        public double EstoqueMinimo { get; set; }

        public Insumo(
            string nome,
            string categoria,
            double quantidade,
            double estoqueMinimo)
        {
            Id = GeradorId.Gerar();
            Nome = nome;
            Categoria = categoria;
            Quantidade = quantidade;
            EstoqueMinimo = estoqueMinimo;
        }

        public bool EstoqueBaixo()
        {
            return Quantidade <= EstoqueMinimo;
        }
    }
}