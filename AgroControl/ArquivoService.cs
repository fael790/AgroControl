using System.Text.Json;
using AgroControl.Classes;

namespace AgroControl.Services
{
    public static class ArquivoService
    {
        private static string caminho = "dados_agrocontrol.json";

        public static void Salvar(DadosSistema dados)
        {
            string json = JsonSerializer.Serialize(
                dados,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(caminho, json);
        }

        public static DadosSistema Carregar()
        {
            if (!File.Exists(caminho))
            {
                return new DadosSistema();
            }

            string json = File.ReadAllText(caminho);

            DadosSistema dados =
                JsonSerializer.Deserialize<DadosSistema>(json);

            return dados ?? new DadosSistema();
        }
    }
}