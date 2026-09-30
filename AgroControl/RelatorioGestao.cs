using AgroControl.Classes;
using AgroControl.Interfaces;

namespace AgroControl.Services
{
    public class RelatorioGestao : IRelatorio
    {
        private DadosSistema dados;

        public RelatorioGestao(DadosSistema dados)
        {
            this.dados = dados;
        }

        public void GerarRelatorio()
        {
            double areaTotal = 0;
            double producaoTotal = 0;
            double custosTotais = 0;

            foreach (var cultura in dados.Culturas)
            {
                areaTotal += cultura.AreaHectares;
                producaoTotal += cultura.ProducaoPrevistaToneladas;
            }

            foreach (var atividade in dados.Atividades)
            {
                custosTotais += atividade.Custo;
            }

            Console.WriteLine("=================================");
            Console.WriteLine("      RELATÓRIO AGROCONTROL");
            Console.WriteLine("=================================");

            Console.WriteLine(
                $"Produtores: {dados.Produtores.Count}");

            Console.WriteLine(
                $"Funcionários: {dados.Funcionarios.Count}");

            Console.WriteLine(
                $"Culturas: {dados.Culturas.Count}");

            Console.WriteLine(
                $"Máquinas: {dados.Maquinas.Count}");

            Console.WriteLine(
                $"Insumos: {dados.Insumos.Count}");

            Console.WriteLine(
                $"Atividades: {dados.Atividades.Count}");

            Console.WriteLine(
                $"Área total: {areaTotal} hectares");

            Console.WriteLine(
                $"Produção prevista: {producaoTotal} toneladas");

            Console.WriteLine(
                $"Custos das atividades: R$ {custosTotais:F2}");

            Console.WriteLine("\n===== ALERTAS DE ESTOQUE =====");

            foreach (var insumo in dados.Insumos)
            {
                if (insumo.EstoqueBaixo())
                {
                    Console.WriteLine(
                        $"ATENÇÃO: {insumo.Nome} está abaixo do estoque mínimo.");
                }
            }
        }
    }
}