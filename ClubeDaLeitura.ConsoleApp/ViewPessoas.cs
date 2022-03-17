using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ViewPessoas
    {
        public ClassPessoa[] pessoas;
        public ViewPessoas(ref ClassPessoa[] p)
        {
            pessoas = p;
        }
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------------Amigos View----------------------------");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write($"|| (1) Listas |");
            Console.Write($"| (2) Cadastrar |");
            Console.Write($"| (3) Editar |");
            Console.Write($"| (4) Excluir ||");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            string lerTela = Console.ReadLine();
            if (lerTela == "")//Retorna ao menu principal
            {
                Console.Clear();
                return;
            }
            bool conversaoRealizada = int.TryParse(lerTela, out int opcao);
            if (conversaoRealizada == true)
            {
                switch (opcao)
                {
                    case (int)Amigos.Listar:
                        Listar();
                        break;
                    case (int)Amigos.Cadastrar:
                        Cadastrar();
                        break;
                    case (int)Amigos.Editar:
                        Editar();
                        break;
                    case (int)Amigos.Excluir:
                        Excluir();
                        break;
                    default:
                        Error.Mensagem();
                        break;
                }
            }
            else
            {
                Error.Mensagem();
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region Métodos principais
        public void Cadastrar()
        {
            Console.WriteLine("\n*Cadastrar*");
            ClassPessoa pessoaCadastro = new ClassPessoa();
            int arrayCheio = -1;
            bool sairMetodo = false;

            pessoaCadastro.ID = PositionToInsert();
            if (pessoaCadastro.ID == arrayCheio)
            {
                Console.WriteLine("Base de dados está cheia, contate o administrador do sistema");
                return;
            }
            Console.WriteLine("Pressione enter para voltar ao menu ou informe os campos para cadastro.");
            DataInput(ref pessoaCadastro, ref sairMetodo, false);
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            pessoas[pessoaCadastro.ID] = pessoaCadastro;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Listar()
        {
            Console.WriteLine("\n*Listar*");
            PrintAll();
            Console.Write("\nPressine enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Editar()
        {
            ClassPessoa pessoaEdicao = new ClassPessoa();
            bool sairMetodo = false;

            Console.WriteLine("\n*Editar*");
            Console.WriteLine("Listagem de Amigos cadastrados.");
            PrintAll();
            Console.Write("\nPressione enter para sair ou informe o ID do amigo que deseja alterar: ");
            string lerDados = Console.ReadLine();
            if (lerDados == "")
            {
                Console.Clear();
                return;
            }

            bool conversaoRealizada = int.TryParse(lerDados, out int idEdicao);
            if (conversaoRealizada == true && PosicaoNotNull(idEdicao) == true)
            {
                pessoaEdicao.ID = idEdicao;
                Console.WriteLine("\nCaso deseje manter informação anterior, mantenha o campo vazio e pressione enter.");
                Console.Write("Pessoa em Edição | ");
                pessoas[pessoaEdicao.ID].Print();
                DataInput(ref pessoaEdicao, ref sairMetodo, true);

                pessoaEdicao.nome = pessoaEdicao.nome == "" ? pessoas[pessoaEdicao.ID].nome : pessoaEdicao.nome;
                pessoaEdicao.nomeResponsavel = pessoaEdicao.nomeResponsavel == "" ? pessoas[pessoaEdicao.ID].nomeResponsavel : pessoaEdicao.nomeResponsavel;
                pessoaEdicao.telefone = pessoaEdicao.telefone == "" ? pessoas[pessoaEdicao.ID].telefone : pessoaEdicao.telefone;
                pessoaEdicao.endereco = pessoaEdicao.endereco == "" ? pessoas[pessoaEdicao.ID].endereco : pessoaEdicao.endereco;

                pessoas[pessoaEdicao.ID] = pessoaEdicao;

                Console.Clear();
                Console.WriteLine("Usuário editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Ocorreu um erro na edição, pressione enter para voltar ao menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Excluir()
        {
            Console.WriteLine("\n*Excluir*");
            Console.WriteLine("Listagem de Amigos cadastrados.");
            PrintAll();
            Console.Write("\nPressione enter para voltar ou informe o ID que deseja excluir: ");
            string lerDados = Console.ReadLine();
            bool conversaoRealizada = int.TryParse(lerDados, out int id);
            if (conversaoRealizada == true &&  PosicaoNotNull(id) == true)
            {
                pessoas[id] = null;
                Console.Clear();
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            else if (lerDados == "")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("Nenhum usuário excluído.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #endregion

        #region Métodos auxiliares
        public void PrintAll()
        {
            foreach (var pessoa in pessoas)
            {
                if (pessoa != null)
                    pessoa.Print();
            }
        }
        private void DataInput(ref ClassPessoa pessoaCadastroEdicao, ref bool sairMetodo, bool edicaoPessoa)
        {
            Console.Write("Informe o nome: ");
            pessoaCadastroEdicao.nome = Console.ReadLine();
            if (pessoaCadastroEdicao.nome == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o responsável: ");
            pessoaCadastroEdicao.nomeResponsavel = Console.ReadLine();
            if (pessoaCadastroEdicao.nomeResponsavel == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o telefone: ");
            pessoaCadastroEdicao.telefone = Console.ReadLine();
            if (pessoaCadastroEdicao.telefone == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o endereço: ");
            pessoaCadastroEdicao.endereco = Console.ReadLine();
            if (pessoaCadastroEdicao.endereco == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
        }
        private int PositionToInsert()
        {
            int posicao = -1;// -1 em caso de array cheio
            
            for (int i = 0; i < pessoas.Length; i++)
            {
                if (pessoas[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public bool PosicaoNotNull(int id)
        {
            bool notNull = false;

            if (pessoas[id] != null)
                notNull = true;

            return notNull;
        }
        public static void PopularPessoas(ref ClassPessoa[] pessoas)
        {
            ClassPessoa p1 = new ClassPessoa(0, "Marcos Lima", "Adriana", "123", "rua 1");
            ClassPessoa p2 = new ClassPessoa(1, "Patricia Carsten", "Andreia", "321", "rua 2");
            pessoas[0] = p1;
            pessoas[1] = p2;
        }
        #endregion
    }
}
