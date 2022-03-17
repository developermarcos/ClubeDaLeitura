using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ViewCaixas
    {
        ClassCaixa[] caixas;
        public ViewCaixas(ref ClassCaixa[] c)
        {
            caixas = c;
        }
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------Caixas----------------------------");
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
        public void Listar()
        {
            Console.WriteLine("\n*Listar*");
            PrintAll();
            Console.WriteLine("Pressione enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Cadastrar()
        {
            ClassCaixa caixaCadastro = new ClassCaixa();
            bool sairMetodo = false;
            int arrayCheio = -1;

            Console.WriteLine("\n*Cadastrar*");

            caixaCadastro.caixaId = PositionToInsert();

            if (caixaCadastro.caixaId != arrayCheio)
            {
                Console.WriteLine("Pressione enter para sair do cadastro ou informe o campo solicitado.");
                DataInput(ref caixaCadastro, ref sairMetodo, false);
                if (sairMetodo == true)
                {
                    Console.Clear();
                    return;
                }

                caixas[caixaCadastro.caixaId] = caixaCadastro;

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
            ClassCaixa caixaCadastro = new ClassCaixa();
            bool sairMetodo = false;
            int arrayCheio = -1;

            Console.WriteLine("\n*Editar*");
            Console.WriteLine("Segue listagem de caixas cadastradas");
            PrintAll();
            while (true)
            {
                Console.Write("Pressione enter para sair ou informe o ID da caixa que deseja editar: ");
                string lerTela = Console.ReadLine();

                bool conversaoRealizada = int.TryParse(lerTela, out int idEditar);
                if (conversaoRealizada == true && PositionNotNull(idEditar) == true)
                {
                    caixaCadastro.caixaId = idEditar;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Caixa não encontrada, tente novamente");
            }
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            Console.WriteLine("\nPressione enter para manter a informação ou informe a alteração.");
            Console.Write("Caixa em Edição | ");
            caixas[caixaCadastro.caixaId].Print();
            
            DataInput(ref caixaCadastro, ref sairMetodo, true);

            caixaCadastro.cor = caixaCadastro.cor == "" ? caixas[caixaCadastro.caixaId].cor : caixaCadastro.cor;
            caixaCadastro.etiqueta = caixaCadastro.etiqueta == "" ? caixas[caixaCadastro.caixaId].etiqueta : caixaCadastro.etiqueta;
            caixaCadastro.numero = caixaCadastro.numero == "" ? caixas[caixaCadastro.caixaId].numero : caixaCadastro.numero;

            caixas[caixaCadastro.caixaId] = caixaCadastro;

            Console.Clear();
            Console.WriteLine("Caixa editada com sucesso!");

        }
        public void Excluir()
        {
            Console.WriteLine("\n*Excluir*");
            Console.WriteLine("Segue listagem de caixas cadastradas");
            PrintAll();
            Console.Write("Informe o ID da caixa que deseja editar: ");
            string lerTela = Console.ReadLine();
            bool conversaoRealizada = int.TryParse(lerTela, out int idExcluir);
            if (conversaoRealizada == true && PositionNotNull(idExcluir) == true)
            {
                caixas[idExcluir] = null;
                Console.Clear();
                Console.WriteLine("Caixa excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Id não encontrado.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region Métodos auxiliares
        public void PrintAll()
        {
            foreach (var caixa in caixas)
            {
                if (caixa != null)
                    caixa.Print();
            }
        }
        private void DataInput(ref ClassCaixa caixaCadastro, ref bool sairMetodo, bool ehEdicao)
        {
            Console.Write("Informe a etiqueta da caixa: ");
            caixaCadastro.etiqueta = Console.ReadLine();
            if (caixaCadastro.etiqueta == "" && ehEdicao == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o numero da caixa: ");
            caixaCadastro.numero = Console.ReadLine();
            if (caixaCadastro.numero == "" && ehEdicao == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe a cor da caixa: ");
            caixaCadastro.cor = Console.ReadLine();
            if (caixaCadastro.cor == "" && ehEdicao == false)
            {
                sairMetodo = true;
                return;
            }
        }
        private int PositionToInsert()
        {
            int posicao = -1;//Em caso de array cheio retorno -1

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public bool PositionNotNull(int id)
        {
            bool existe = false;

            if (caixas[id] != null)
                existe = true;


            return existe;
        }
        public static void PopularCaixas(ClassCaixa[] caixas)
        {
            ClassCaixa c1 = new ClassCaixa(0, "Preta", "Edição especial", "123");
            ClassCaixa c2 = new ClassCaixa(1, "Branca", "Doação", "321");
            caixas[0] = c1;
            caixas[1] = c2;
        }
        #endregion
    }
}
