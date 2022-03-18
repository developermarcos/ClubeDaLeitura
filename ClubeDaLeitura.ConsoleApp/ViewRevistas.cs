using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ViewRevistas
    {
        ClassRevista[] revistas;
        ClassCaixa[] caixas;
        ClassCategoriaRevista[] categorias;

        public ViewRevistas(ref ClassRevista[] r, ref ClassCaixa[] c)
        {
            revistas = r;
            caixas = c;
        }
        public ViewRevistas(ref ClassRevista[] r, ref ClassCaixa[] c, ref ClassCategoriaRevista[] cat)
        {
            revistas = r;
            caixas = c;
            categorias = cat;
        }
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------------Revistas---------------------------");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"|| (1) Listar |");
            Console.Write($"| (2) Cadastrar |");
            Console.Write($"| (3) Editar |");
            Console.Write($"| (4) Excluir ||");
            Console.Write($"| (5) Categorias ||");
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
                    case 5:
                        ViewCategoriaRevista categoriaRevista = new ViewCategoriaRevista(ref categorias);
                        categoriaRevista.Menu();
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
        public void Listar()
        {
            Console.WriteLine("\n*Listar*");
            PrintAll();
            Console.Write("\nPressione enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Cadastrar()
        {
            bool sairMetodo = false;
            ClassRevista revistaCadastro = new ClassRevista();

            Console.WriteLine("\n*Cadastrar*");

            revistaCadastro.ID = PositionToInsert();
            if (revistaCadastro.ID != -1)
            {
                Console.WriteLine("Pressione enter para voltar ao menu ou informe o parametros para seguir no cadastro.");
                DataInput(ref revistaCadastro, ref sairMetodo, false);
                if (sairMetodo == true)
                    return;
                
                revistas[revistaCadastro.ID] = revistaCadastro;

                Console.Clear();
                Console.WriteLine("Caixa cadastrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar a caixa, contate o administrador do sistema.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Editar()
        {
            bool sairMetodo = false;
            ClassRevista revistaEdicao = new ClassRevista();

            Console.WriteLine("\n*Editar*");

            PrintAll();
            while (true)
            {
                Console.Write("Pressione enter para voltar ou informe o ID da revista que deseja alterar:");
                string lerTela = Console.ReadLine();
                if (lerTela == "")
                {
                    Console.Clear();
                    return;
                }

                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && PositionNotNull(idEdicao) == true)
                {
                    revistaEdicao.ID = idEdicao;
                    break;
                }
            }
            //revistaId numeroEdicao=V anoRevista=V tipoColecao=V revistaCaixaId=V
            if (revistaEdicao.ID != -1 &&  revistaEdicao != null)
            {
                Console.WriteLine("\nPressione enter para manter a informação anterior ou informe o parametros anterar o cadastro.");
                DataInput(ref revistaEdicao, ref sairMetodo, true);

                //Insere no array
                revistaEdicao.ID = revistaEdicao.ID == default? revistas[revistaEdicao.ID].ID : revistaEdicao.ID ;
                revistaEdicao.CaixaID = revistaEdicao.CaixaID  == default ? revistas[revistaEdicao.ID].CaixaID : revistaEdicao.CaixaID ;
                revistaEdicao.categoriaID = revistaEdicao.categoriaID  == default ? revistas[revistaEdicao.ID].categoriaID : revistaEdicao.categoriaID ;
                revistaEdicao.numeroEdicao = revistaEdicao.numeroEdicao  == null ? revistas[revistaEdicao.ID].numeroEdicao : revistaEdicao.numeroEdicao ;
                revistaEdicao.anoRevista = revistaEdicao.anoRevista  == default ? revistas[revistaEdicao.ID].anoRevista : revistaEdicao.anoRevista ;
                revistaEdicao.tipoColecao = revistaEdicao.tipoColecao  == null ? revistas[revistaEdicao.ID].tipoColecao : revistaEdicao.tipoColecao ;

                revistas[revistaEdicao.ID] = revistaEdicao;

                Console.Clear();
                Console.WriteLine("Caixa editada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar a caixa, contate o administrador do sistema.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Excluir()
        {
            Console.WriteLine("\n*Excluir*");
            PrintAll();
            while (true)
            {
                int idExclusao;
                Console.Write("Pressione enter para voltar ou informe o ID da revista que deseja alterar:");
                string lerTela = Console.ReadLine();
                if (lerTela == "")
                {
                    Console.Clear();
                    return;
                }
                bool conversaoRealizada = int.TryParse(lerTela, out idExclusao);
                if (conversaoRealizada == true && PositionNotNull(idExclusao) == true)
                {
                    revistas[idExclusao] = null;

                    Console.Clear();
                    Console.WriteLine("Revista excluída com sucesso!");
                    break;
                }
            }
        }
        #endregion

        #region Métodos auxiliares
        private void DataInput(ref ClassRevista revista, ref bool sairMetodo, bool ehEdicao)
        {
            while (true)
            {
                Console.Write("Informe o numero de edição: ");
                string lerTela = Console.ReadLine();
                if (lerTela == "" && ehEdicao == false)
                {
                    sairMetodo = true;
                    break;
                }
                else if (lerTela == "" && ehEdicao == true)
                    break;

                if (lerTela != "")
                {
                    revista.numeroEdicao = lerTela;
                    break;
                }
              
            }
            if (sairMetodo == true)
                return;
            while (true)
            {
                Console.Write("Informe o tipo da coleção : ");
                string lerTela = Console.ReadLine();

                if (lerTela == "" && ehEdicao == false)
                {
                    sairMetodo = true;
                    break;
                }
                else if (lerTela == "" && ehEdicao == true)
                    break;

                if (lerTela != "")
                {
                    revista.tipoColecao = lerTela;
                    break;
                }
            }
            if (sairMetodo == true)
                return;


            while (true)//Input + validação Data criacao
            {
                Console.Write("Informe o data de fabricação da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataCriacaoRevista);
                
                if (lerTela == "" && ehEdicao == false)
                {
                    sairMetodo = true;
                    break;
                }
                else if (lerTela == "" && ehEdicao == true)
                    break;
                

                if (conversaoRealizada == true && lerTela.Length == 10)
                {
                    revista.anoRevista = dataCriacaoRevista;
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto.");
            }
            if (sairMetodo == true)
                return;

            Console.WriteLine("\nLista de caixas cadastradas");
            ViewCaixas caixa = new ViewCaixas(ref caixas);
            caixa.PrintAll();

            while (true)//Input + validação caixa para guardar revista
            {
                int revistaCaixaId;
                Console.Write("Informe a caixa que deseja guardar a revista: ");
                string lerTela = Console.ReadLine();
                if (lerTela == "" &&  ehEdicao == false)
                {
                    sairMetodo = true;
                    break;
                }
                else if(lerTela == "" &&  ehEdicao == true)
                    break;
                    
                bool conversaoRealizada = int.TryParse(lerTela, out revistaCaixaId);
                if (conversaoRealizada == true && caixa.PositionNotNull(revistaCaixaId) == true)
                {
                    revista.CaixaID = revistaCaixaId;
                    break;
                }
                else
                    Console.WriteLine("\nCaixa informada não existe");
            }
            if (sairMetodo == true)
                return;

            Console.WriteLine("\nLista de categorias cadastradas");
            ViewCategoriaRevista categoria = new ViewCategoriaRevista(ref categorias);
            categoria.PrintAll();

            while (true)//Input + validação caixa para guardar revista
            {
                int revistaCategoriaId;
                Console.Write("Informe a categoria que deseja guardar a revista: ");
                string lerTela = Console.ReadLine();
                if (lerTela == "" && ehEdicao == false)
                {
                    sairMetodo = true;
                    break;
                }
                else if (lerTela == "" &&  ehEdicao == true)
                    break;

                bool conversaoRealizada = int.TryParse(lerTela, out revistaCategoriaId);
                if (conversaoRealizada == true && categoria.PosicaoNotNull(revistaCategoriaId) == true)
                {
                    revista.categoriaID = revistaCategoriaId;
                    break;
                }
                else
                {
                    Console.WriteLine("\nCategoria informada não existe");
                }
            }
        }
        private int PositionToInsert()
        {
            int posicao = -1;//Em caso de array lotado, retorno -1

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public void PrintAll()
        {
            foreach (var revista in revistas)
            {
                if (revista != null)
                {
                    revista.Print(caixas[revista.CaixaID], categorias[revista.categoriaID]);
                }
            }
        }
        public bool PositionNotNull(int id)
        {
            bool existe = false;

            if (revistas[id] != null)
                existe = true;

            return existe;
        }
        public static void PopularArrayRevistas(ClassRevista[] revistas)
        {
            DateTime data = new DateTime(2020, 11, 21);
            ClassRevista rev1 = new ClassRevista(0, "444", data, "Aventura", 0, 1);
            ClassRevista rev2 = new ClassRevista(1, "555", data, "Terror", 1, 0);
            revistas[0] = rev1;
            revistas[1] = rev2;
        }
        #endregion
    }
}
