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

        public ViewRevistas(ref ClassRevista[] r, ref ClassCaixa[] c)
        {
            revistas = r;
            caixas = c;
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
            ClassRevista revistaCadastro = new ClassRevista();

            Console.WriteLine("\n*Cadastrar*");

            revistaCadastro.revistaId = PositionToInsert();
            if (revistaCadastro.revistaId != -1)
            {
                DataInput(ref revistaCadastro);
                revistaCadastro.posicaoPreenchida = true;
                revistas[revistaCadastro.revistaId] = revistaCadastro;

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
                    revistaEdicao.revistaId = idEdicao;
                    break;
                }
            }
            //revistaId numeroEdicao=V anoRevista=V tipoColecao=V revistaCaixaId=V
            if (revistaEdicao.revistaId != -1 &&  revistaEdicao.revistaId != default)
            {
                DataInput(ref revistaEdicao);

                //Insere no array
                revistas[revistaEdicao.revistaId] = revistaEdicao;

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
        private void DataInput(ref ClassRevista revista)
        {
            Console.Write("Informe o numero de edição da revista: ");
            revista.numeroEdicao = Console.ReadLine();

            while (true)//Input + validação Data criacao
            {
                Console.Write("Informe o data de fabricação da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataCriacaoRevista);
                if (conversaoRealizada == true && lerTela.Length == 10)
                {
                    revista.anoRevista = dataCriacaoRevista;
                    break;
                }
                else if (lerTela == "")
                {
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto.");
            }

            Console.WriteLine("\nLista de caixas cadastradas");
            //Caixa.ImprimirCaixas(caixas);

            while (true)//Input + validação caixa para guardar revista
            {
                int revistaCaixaId;
                Console.Write("Informe a caixa que deseja guardar a revista: ");
                string lerTela = Console.ReadLine();
                if (lerTela == "")
                    break;
                //bool conversaoRealizada = int.TryParse(lerTela, out revistaCaixaId);
                //if (conversaoRealizada == true && Caixa.ExisteNoArray(caixas, revistaCaixaId) == true)
                //{
                //    revista.revistaCaixaId = revistaCaixaId;
                //    break;
                //}
                //else
                //{
                //    Console.WriteLine("\nCaixa informada não existe");
                //}
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
                    revista.Print(caixas[revista.revistaCaixaId]);
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
            ClassRevista rev1 = new ClassRevista(0, "444", data, "Aventura", 0);
            ClassRevista rev2 = new ClassRevista(1, "555", data, "Terror", 1);
            revistas[0] = rev1;
            revistas[1] = rev2;
        }
        #endregion
    }
}
