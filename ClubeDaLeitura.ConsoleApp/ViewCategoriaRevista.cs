using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ViewCategoriaRevista
    {
        ClassCategoriaRevista[] categoriaRevistas;
        public ViewCategoriaRevista(ref ClassCategoriaRevista[] cat)
        {
            categoriaRevistas = cat;
        }
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------------Categorias Revistas---------------------------");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"|| (1) Listar |");
            Console.Write($"| (2) Cadastrar |");
            Console.Write($"| (3) Editar |");
            Console.Write($"| (4) Excluir ||");
            Console.WriteLine("\n--------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            string lerTela = Console.ReadLine();
            if (lerTela == "")
            {
                Console.Clear();
                return;
            }
            bool conversaoRealizada = int.TryParse(lerTela, out int opcao);
            if (conversaoRealizada == true)
            {
                switch (opcao)
                {
                    case 1:
                        Listar();
                        break;
                    case 2:
                        Cadastrar();
                        break;
                    case 3:
                        Editar();
                        break;
                    case 4:
                        Excluir();
                        break;
                    default:
                        Error.Mensagem();
                        Console.ReadKey();
                        Console.Clear();
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
            ClassCategoriaRevista categoriaCadastro = new ClassCategoriaRevista();
            int arrayCheio = -1;
            bool sairMetodo = false;

            categoriaCadastro.ID = PositionToInsert();
            if (categoriaCadastro.ID == arrayCheio)
            {
                Console.WriteLine("Base de dados está cheia, contate o administrador do sistema");
                return;
            }
            Console.WriteLine("Pressione enter para voltar ao menu ou informe os campos para cadastro.");
            DataInput(ref categoriaCadastro, ref sairMetodo, false);
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            categoriaRevistas[categoriaCadastro.ID] = categoriaCadastro;

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
            ClassCategoriaRevista categoriaEdicao = new ClassCategoriaRevista();
            
            bool sairMetodo = false;

            Console.WriteLine("\n*Editar*");
            Console.WriteLine("Listagem de categorias cadastradas.");
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
                categoriaEdicao.ID = idEdicao;
                
                DataInput(ref categoriaEdicao, ref sairMetodo, true);
                
                categoriaEdicao.nome = categoriaEdicao.nome == "" ? categoriaRevistas[categoriaEdicao.ID].nome : categoriaEdicao.nome;
                categoriaEdicao.quantidadeDiasEmprestimo = categoriaEdicao.quantidadeDiasEmprestimo == default ? categoriaRevistas[categoriaEdicao.ID].quantidadeDiasEmprestimo : categoriaEdicao.quantidadeDiasEmprestimo;


                categoriaRevistas[categoriaEdicao.ID] = categoriaEdicao;

                Console.Clear();
                Console.WriteLine("Categoria editada com sucesso!");
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
            Console.WriteLine("Listagem de categorias cadastrados.");
            PrintAll();
            Console.Write("\nPressione enter para voltar ou informe o ID que deseja excluir: ");
            string lerDados = Console.ReadLine();
            bool conversaoRealizada = int.TryParse(lerDados, out int id);
            if (conversaoRealizada == true &&  PosicaoNotNull(id) == true)
            {
                categoriaRevistas[id] = null;
                Console.Clear();
                Console.WriteLine("Categoria excluída com sucesso!");
            }
            else if (lerDados == "")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("Nenhuma categoria excluída.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #endregion

        #region Métodos auxiliares
        public void PrintAll()
        {
            foreach (var cat in categoriaRevistas)
            {
                if (cat != null)
                    cat.Print();
            }
        }
        private void DataInput(ref ClassCategoriaRevista categoriaCadastroEdicao, ref bool sairMetodo, bool edicaoCategoria)
        {
            Console.Write("Informe o nome: ");
            categoriaCadastroEdicao.nome = Console.ReadLine();
            if (categoriaCadastroEdicao.nome == "" && edicaoCategoria == false)
            {
                sairMetodo = true;
                return;
            }
            while (true)
            {
                Console.Write("Informe a quantidade de dias máximo para empréstimo de revistas desta categorias: ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = int.TryParse(lerTela, out int numero);
                if (conversaoRealizada == true && edicaoCategoria == true)
                {
                    categoriaCadastroEdicao.quantidadeDiasEmprestimo = numero;
                    sairMetodo = true;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo= true;
                    break;
                }
                else
                {
                    Console.WriteLine("Parâmetro inválido");
                }
            }
        }
        private int PositionToInsert()
        {
            int posicao = -1;// -1 em caso de array cheio

            for (int i = 0; i < categoriaRevistas.Length; i++)
            {
                if (categoriaRevistas[i] == null)
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

            if (categoriaRevistas[id] != null)
                notNull = true;

            return notNull;
        }
        public static void PopularCategoriasRevistas(ref ClassCategoriaRevista[] categorias)
        {
            ClassCategoriaRevista cat1 = new ClassCategoriaRevista(0, "Serie especial", 5);
            ClassCategoriaRevista cat2 = new ClassCategoriaRevista(1, "Novidade", 3);
            categorias[0] = cat1;
            categorias[1] = cat2;
        }
        #endregion
    }
}
