using AgroControl.Classes;
using AgroControl.Services;

namespace AgroControl
{
    class Program
    {
        static DadosSistema dados = new DadosSistema();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.Clear();

                Console.WriteLine("=================================");
                Console.WriteLine("       AGROCONTROL");
                Console.WriteLine(" Sistema de Gestão Agrícola");
                Console.WriteLine("=================================");
                Console.WriteLine("1 - Cadastrar produtor");
                Console.WriteLine("2 - Cadastrar cultura");
                Console.WriteLine("3 - Cadastrar funcionário");
                Console.WriteLine("4 - Cadastrar máquina");
                Console.WriteLine("5 - Cadastrar insumo");
                Console.WriteLine("6 - Registrar atividade agrícola");
                Console.WriteLine("7 - Consultar dados");
                Console.WriteLine("8 - Gerar relatório");
                Console.WriteLine("9 - Salvar dados");
                Console.WriteLine("10 - Carregar dados");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            CadastrarProdutor();
                            break;

                        case "2":
                            CadastrarCultura();
                            break;

                        case "3":
                            CadastrarFuncionario();
                            break;

                        case "4":
                            CadastrarMaquina();
                            break;

                        case "5":
                            CadastrarInsumo();
                            break;

                        case "6":
                            RegistrarAtividade();
                            break;

                        case "7":
                            ConsultarDados();
                            break;

                        case "8":
                            Console.Clear();
                            RelatorioGestao relatorio = new RelatorioGestao(dados);
                            relatorio.GerarRelatorio();
                            Console.ReadKey();
                            break;

                        case "9":
                            ArquivoService.Salvar(dados);
                            Console.WriteLine("Dados salvos com sucesso!");
                            Console.ReadKey();
                            break;

                        case "10":
                            dados = ArquivoService.Carregar();
                            Console.WriteLine("Dados carregados com sucesso!");
                            Console.ReadKey();
                            break;

                        case "0":
                            executando = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Sistema encerrado.");
        }

        static void CadastrarProdutor()
        {
            Console.Clear();

            Console.Write("Nome do produtor: ");
            string nome = Console.ReadLine();

            Console.Write("Documento: ");
            string documento = Console.ReadLine();

            Produtor produtor = new Produtor(nome, documento);

            dados.Produtores.Add(produtor);

            Console.WriteLine("Produtor cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void CadastrarCultura()
        {
            Console.Clear();

            Console.Write("Nome da cultura: ");
            string nome = Console.ReadLine();

            Console.Write("Área em hectares: ");
            double area = double.Parse(Console.ReadLine());

            Console.Write("Produção prevista em toneladas: ");
            double producao = double.Parse(Console.ReadLine());

            Cultura cultura = new Cultura(nome, area, producao);

            dados.Culturas.Add(cultura);

            Console.WriteLine("Cultura cadastrada com sucesso!");
            Console.ReadKey();
        }

        static void CadastrarFuncionario()
        {
            Console.Clear();

            Console.Write("Nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Documento: ");
            string documento = Console.ReadLine();

            Console.Write("Função: ");
            string funcao = Console.ReadLine();

            Funcionario funcionario =
                new Funcionario(nome, documento, funcao);

            dados.Funcionarios.Add(funcionario);

            Console.WriteLine("Funcionário cadastrado com sucesso!");
            Console.ReadKey();
        }

        static void CadastrarMaquina()
        {
            Console.Clear();

            Console.Write("Nome da máquina: ");
            string nome = Console.ReadLine();

            Console.Write("Tipo: ");
            string tipo = Console.ReadLine();

            Maquina maquina = new Maquina(nome, tipo);

            dados.Maquinas.Add(maquina);

            Console.WriteLine("Máquina cadastrada com sucesso!");
            Console.ReadKey();
        }

        static void CadastrarInsumo()
        {
            Console.Clear();

            Console.Write("Nome do insumo: ");
            string nome = Console.ReadLine();

            Console.Write("Categoria: ");
            string categoria = Console.ReadLine();

            Console.Write("Quantidade: ");
            double quantidade = double.Parse(Console.ReadLine());

            Console.Write("Estoque mínimo: ");
            double estoqueMinimo = double.Parse(Console.ReadLine());

            Insumo insumo =
                new Insumo(nome, categoria, quantidade, estoqueMinimo);

            dados.Insumos.Add(insumo);

            Console.WriteLine("Insumo cadastrado com sucesso!");

            if (insumo.EstoqueBaixo())
            {
                Console.WriteLine("ALERTA: estoque abaixo do mínimo!");
            }

            Console.ReadKey();
        }

        static void RegistrarAtividade()
        {
            Console.Clear();

            Console.Write("Descrição da atividade: ");
            string descricao = Console.ReadLine();

            Console.Write("Cultura: ");
            string cultura = Console.ReadLine();

            Console.Write("Custo: ");
            double custo = double.Parse(Console.ReadLine());

            AtividadeAgricola atividade =
                new AtividadeAgricola(
                    descricao,
                    cultura,
                    custo
                );

            dados.Atividades.Add(atividade);

            Console.WriteLine("Atividade registrada com sucesso!");
            Console.ReadKey();
        }

        static void ConsultarDados()
        {
            Console.Clear();

            Console.WriteLine("===== PRODUTORES =====");

            foreach (var produtor in dados.Produtores)
            {
                Console.WriteLine(produtor.Descricao());
            }

            Console.WriteLine("\n===== CULTURAS =====");

            foreach (var cultura in dados.Culturas)
            {
                Console.WriteLine(
                    $"ID: {cultura.Id} | {cultura.Nome} | Área: {cultura.AreaHectares} ha"
                );
            }

            Console.WriteLine("\n===== FUNCIONÁRIOS =====");

            foreach (var funcionario in dados.Funcionarios)
            {
                Console.WriteLine(funcionario.Descricao());
            }

            Console.WriteLine("\n===== MÁQUINAS =====");

            foreach (var maquina in dados.Maquinas)
            {
                Console.WriteLine(
                    $"ID: {maquina.Id} | {maquina.Nome} | Tipo: {maquina.Tipo}"
                );
            }

            Console.WriteLine("\n===== INSUMOS =====");

            foreach (var insumo in dados.Insumos)
            {
                Console.WriteLine(
                    $"ID: {insumo.Id} | {insumo.Nome} | Quantidade: {insumo.Quantidade}"
                );
            }

            Console.ReadKey();
        }
    }
}