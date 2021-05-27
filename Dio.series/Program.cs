using System;

namespace Dio.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                       break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default: 
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigada por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries: ");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série foi encontrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "- Excluído": ""));
                                
            }
        }
        private static  void InserirSerie()
         {
             Console.WriteLine("Inserir nova série");

            //titulo
            Console.Write("Digite o titulo da série: ");
            string EntradaTitulo = Console.ReadLine();
            
            //genero
            Console.WriteLine("Digite o genêro entre as opções abaixo: ");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero),i));
            }

            int EntradaGenero = int.Parse(Console.ReadLine());

            //ano
            Console.Write("Digitie o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            //descricao
            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            //adciona
            Serie NovaSerie = new Serie (id:repositorio.ProximoId(),
                                        genero:(Genero)EntradaGenero,
                                        titulo: EntradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(NovaSerie);

         }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int IndiceSerie= int.Parse(Console.ReadLine());

            Console.Write("Digite o novo titulo da série: ");
            string EntradaTitulo = Console.ReadLine();
            
            //genero
            Console.WriteLine("Digite o novo genêro entre as opções abaixo: ");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i , Enum.GetName(typeof(Genero),i));
            }

            int EntradaGenero = int.Parse(Console.ReadLine());

            //ano
            Console.Write("Digitie o novo ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            //descricao
            Console.Write("Digite a nova descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            //Atualiza
            Serie AtualizaSerie = new Serie (id:IndiceSerie,
                                            genero:(Genero)EntradaGenero,
                                            titulo: EntradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(IndiceSerie,AtualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID dá série que deseja remover: ");
            int IndiceSerie= int.Parse(Console.ReadLine());

            //CONFIRMAÇAO
                        
            string Titulo = repositorio.TituloPorID(IndiceSerie);
            Console.WriteLine("Deseja excluir a série '{0}'? S/N",Titulo);
            string rExcluir = Console.ReadLine();

            if (rExcluir.ToUpper() == "S")
            {
                //EXCLUIR
                repositorio.Excluir(IndiceSerie);

                Console.Write("A série '{0}' foi excluida com sucesso!", Titulo);
                
            }
            else
            {
               Console.Write("Operação cancelada!");
            }

        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o Id da série que deseja vizualizar:");
            int IndiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(IndiceSerie);

            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");
            
            Console.WriteLine("1 - Listar todas as séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série por ID");
            Console.WriteLine("4 - Excluir série por ID");
            Console.WriteLine("5 - Buscar série por ID");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
                
            String opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    
    }
}
