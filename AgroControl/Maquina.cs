namespace AgroControl.Classes
{
    public class Maquina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public double HorasUso { get; set; }

        public Maquina(string nome, string tipo)
        {
            Id = GeradorId.Gerar();
            Nome = nome;
            Tipo = tipo;
            HorasUso = 0;
        }

        public void RegistrarUso(double horas)
        {
            if (horas <= 0)
            {
                throw new Exception("As horas devem ser maiores que zero.");
            }

            HorasUso += horas;
        }
    }
}