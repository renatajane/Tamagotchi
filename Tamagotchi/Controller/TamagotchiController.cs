using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tamagotchi.Model;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        public string nome { get; set; }
        View.Menu menu = new View.Menu();

        View.MenuOpcoesMascote opcoes = new View.MenuOpcoesMascote();
        View.MenuDetalhesMascote opcoesDetalhes = new View.MenuDetalhesMascote();
        Model.Mascote mascoteInteracao = new Model.Mascote();

        public ListarNomesDetalhes mascotesEscolhidos { get; set; } = new ListarNomesDetalhes();

        public void Iniciar()
        {
            if (nome == null)
            {
                this.nome = menu.BoasVindas();
            }

            try
            {
                //menu.BoasVindas();
                var opcao = menu.MenuInicial();

                Console.Clear();
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("----ADOTAR UM MASCOTE----");
                        Console.WriteLine("\n");
                        AdotarMascotes();
                        break;
                    case "2":
                        Console.WriteLine("----DETALHES DOS MASCOTES ADOTADOS----");
                        Console.WriteLine("\n");
                        VerMascotes();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Opcao não implementada.");
                        break;
                }
            }
            catch (Exception excecao)
            {
                Console.WriteLine("Erro, não foi possível concluir a operação." + excecao.Message);
            }
        }

        public void AdotarMascotes()
        {
            var devolverLista = ObterLista("https://pokeapi.co/api/v2/pokemon/");
            ExibirResultados(devolverLista);
        }

        public void VerMascotes()
        {
            RestResponse response = null;

            try
            {
                var cliente = new RestClient(mascotesEscolhidos.url);
                RestRequest request = new RestRequest();
                response = cliente.Execute(request);
            }
            catch (Exception e)
            {
                throw new Exception($"Não foi possível acessar a API ({mascotesEscolhidos.url}). Mensagem: {e.Message} ");
            }

            var mascote = JsonSerializer.Deserialize<Mascote>(response.Content);

            var opcaoEscolhida = opcoes.EscolherAcao(mascote, this.nome);

            switch (opcaoEscolhida)
            {
                case "1":
                    opcoesDetalhes.DetalharMascote(mascote);
                    break;
                case "2":
                    mascoteInteracao.Alimentar();
                    break;
                case "3":
                    mascoteInteracao.Brincar();
                    break;
                case "4":
                    mascoteInteracao.Dormir();
                    break;
                case "5":
                    menu.MenuInicial();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
            if (opcaoEscolhida != "5")
            {
                VerMascotes();
            }
        }

        public void ExibirResultados(ListarNomes lista)
        {
            for (int i = 0; i < lista.results.Count; i++)
            {
                Console.WriteLine(i + "- " + lista.results[i].name);
            }

            Console.WriteLine("\n");
            Console.WriteLine("Menu inicial, digite (m)");
            Console.WriteLine("--------------------------");

            if (lista.previous != null)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Página anterior, digite (a)");
                Console.WriteLine("--------------------------");
            }


            if (lista.next != null)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Próxima página, digite (p)");
                Console.WriteLine("--------------------------");
            }


            Console.WriteLine("\n");
            Console.WriteLine("Escolher mascote, digite (e)");
            Console.WriteLine("--------------------------");

            string resposta = Console.ReadLine();

            switch (resposta)
            {
                case "a":
                    Console.Clear();
                    var previous = ObterLista(lista.previous);
                    ExibirResultados(previous);
                    break;
                case "p":
                    Console.Clear();
                    var next = ObterLista(lista.next);
                    ExibirResultados(next);
                    break;
                case "m":
                    Console.Clear();
                    Iniciar();
                    break;
                case "e":
                    int mascoteEscolhido = 0;
                    Console.WriteLine("\n");
                    Console.WriteLine("Digite o número do mascote desejado: ");

                    try
                    {
                        mascoteEscolhido = int.Parse(Console.ReadLine());
                        Console.Clear();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Apenas números são válidos." + e.Message);
                    }

                    if (mascoteEscolhido < lista.results.Count)
                    {
                        Console.WriteLine("\n Você escolheu o mascote " + mascoteEscolhido + " - " + lista.results[mascoteEscolhido].name + "\n");
                        mascotesEscolhidos = lista.results[mascoteEscolhido];
                    }
                    else
                    {
                        Console.WriteLine($"O número escolhido deve esta entre 0 e {lista.results.Count}");
                    }
                    Iniciar();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                    ExibirResultados(lista);
                    break;
            }
        }

        public Model.ListarNomes ObterLista(string url)
        {
            try
            {
                var client = new RestClient(url);
                RestRequest request = new RestRequest();
                var response = client.Execute(request);

                var lista = JsonSerializer.Deserialize<ListarNomes>(response.Content);
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception($"Não foi possível acessar a API ({url}). Mensagem: {e.Message} ");
            }
        }
    }
}
