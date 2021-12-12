using System;

namespace DIO.Musicas
{
    class Program
    {
        static MusicasRepositorio repositorio = new MusicasRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
           while(opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                    case "1":
                        ListarMusicas();
                      break;
                    case "2":
                        InserirMusicas();
                        break;
                    case "3":
                        AtualizarMusicas();
                        break;
                    case "4":
                        ExcluirMusicas();
                        break;
                    case "5":
                        VizualizarMusicas();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();                       
               }
           }
        }
        
        private static void ListarMusicas()
        {
            Console.WriteLine("Listar Músicas");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma música cadastrada.");
                return;
            }
            foreach (var musicas in lista)
            {
                var excluido = musicas.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", musicas.retornaId(), musicas.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }
        private static void InserirMusicas()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Musicas novaMusicas = new Musicas(id: repositorio.ProximoId(),
				genero: (Genero)entradaGenero,
				titulo: entradaTitulo,
				ano: entradaAno,
				descricao: entradaDescricao);

			repositorio.Insere(novaMusicas);
		}         
        
        private static void AtualizarMusicas()
		{
			Console.Write("Digite o id da série: ");
			int indiceMusicas = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Musicas atualizaMusicas= new Musicas(id: indiceMusicas,
			    	genero: (Genero)entradaGenero,
				    titulo: entradaTitulo,
					ano: entradaAno,
					descricao: entradaDescricao);

			repositorio.Atualiza(indiceMusicas, atualizaMusicas);
		}
        private static void ExcluirMusicas()
		{
			Console.Write("Digite o id da Música: ");
			int indiceMusicas = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusicas);
		}
        private static void VizualizarMusicas()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusicas = int.Parse(Console.ReadLine());

			var musicas = repositorio.RetornaPorId(indiceMusicas);

			Console.WriteLine(musicas);
		}
         private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
