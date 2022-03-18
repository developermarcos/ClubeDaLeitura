using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ViewReservas
    {
        ClassReserva[] reservas;
        ClassCaixa[] caixas;
        ClassCategoriaRevista[] categorias; 
        ClassPessoa[] pessoas; 
        ClassRevista[] revistas;
        ClassEmprestimo[] emprestimos;
        public ViewReservas(ref ClassCaixa[] c, ref ClassCategoriaRevista[] cat, ref ClassPessoa[] p, ref ClassRevista[] r, ref ClassReserva[] reservas, ref ClassEmprestimo[] emprestimos)
        {
            this.caixas = c;
            this.categorias = cat;
            this.pessoas = p;
            this.revistas = r;
            this.reservas = reservas;
            this.emprestimos = emprestimos;
        }
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------------Reservas---------------------------");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"|| (1) Listarr |");
            Console.Write($"| (2) Cadastrar |");
            Console.Write($"| (3) Excluir |");
            Console.Write($"| (4) Empréstimos ||");
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
                        Excluir();
                        break;
                    case 4:
                        ViewEmprestimos viewEmprestimos = new ViewEmprestimos(ref caixas, ref pessoas, ref revistas, ref emprestimos, ref categorias);
                        viewEmprestimos.Menu();
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
            Console.WriteLine("\n *Cadastro*");
            PrintAll();
            Console.WriteLine("Pressione enter para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }
        public void Cadastrar()
        {
            bool sairMetodo = false;
            ClassReserva reservaCadastro = new ClassReserva();

            Console.WriteLine("\n *Cadastro*");

            Console.WriteLine("\nListagem de amigos");
            ViewPessoas viewPessoa = new ViewPessoas(ref pessoas);
            viewPessoa.PrintAll();
            if ((reservaCadastro.ID = PositionToInsert()) == -1)
            {
                Console.WriteLine("Base de dados está cheia, contate o administrador");
                return;
            }

            DataInput(ref sairMetodo, ref reservaCadastro, false);
            if (sairMetodo == true)
                return;

            reservas[reservaCadastro.ID] = reservaCadastro;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Excluir()
        {
            bool sairMetodo = false;

            Console.WriteLine("\n *Exclusao*");
            Console.WriteLine("Listagem de Emprestimos cadastrados");
            PrintAll();

            while (true)
            {
                Console.Write("Pressione enter para voltar ao menu ou informe o ID que deseja excluir: ");
                string lerTela = Console.ReadLine();

                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && PositionNotNull(idEdicao) == true)
                {
                    emprestimos[idEdicao] = null;
                    break;
                }
                else if (lerTela == "")
                {
                    Console.Clear();
                    sairMetodo = true;
                    return;
                }
                else
                    Console.WriteLine("ID não encontrado, informe novamente.");
            }
            if (sairMetodo == true)
                return;

            Console.Clear();
            Console.WriteLine("Empréstimo excluído com sucesso!");
        }

        #region métodos auxiliares
        public int PositionToInsert()
        {
            int posicao = -1;//Retorna -1 em caso de array cheio
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public void DataInput(ref bool sairMetodo, ref ClassReserva reservaCadastroEdicao, bool ehEdicao)
        {
            while (true)
            {
                Console.Write("Para sair pressione enter ou informe o ID do amigo: ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = int.TryParse(lerTela, out int idCadastro);
                ViewPessoas viewPessoa = new ViewPessoas(ref pessoas);
                if (conversaoRealizada == true && viewPessoa.PosicaoNotNull(idCadastro) == true)
                {
                    reservaCadastroEdicao.idPessoa = idCadastro;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.Write("id do amigo informado não encontrado.\n");
            }
            if (sairMetodo == true && ehEdicao == false)
            {
                Console.Clear();
                return;
            }

            Console.WriteLine("\nListagem de revistas");
            ViewRevistas viewRevistas = new ViewRevistas(ref revistas, ref caixas, ref categorias);
            viewRevistas.PrintAll();
            while (true)
            {
                Console.Write("Para sair pressione enter ou informe o ID da revista: ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = int.TryParse(lerTela, out int idCadastro);
                if (conversaoRealizada == true && viewRevistas.PositionNotNull(idCadastro))
                {
                    reservaCadastroEdicao.idRevista = idCadastro;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.Write("ID da revista informado não encontrado.\n");
            }
            if (sairMetodo == true && ehEdicao == false)
            {
                Console.Clear();
                return;
            }

            while (true)//Input + validação Data reserva
            {
                Console.Write("Informe o data do emprestimo da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataEmprestimo);
                if ((conversaoRealizada == true && lerTela.Length == 10))
                {
                    reservaCadastroEdicao.dataReserva = dataEmprestimo;
                    reservaCadastroEdicao.dataExpira = dataEmprestimo.AddDays(2);
                    break;
                }
                else if (lerTela == "")
                {
                    reservaCadastroEdicao.dataReserva = reservas[reservaCadastroEdicao.ID].dataReserva;
                    reservaCadastroEdicao.dataExpira = reservas[reservaCadastroEdicao.ID].dataExpira;
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto.");
            }
            if (sairMetodo == true && ehEdicao == false)
            {
                Console.Clear();
                return;
            }

            if (sairMetodo == true && ehEdicao == false)
            {
                Console.Clear();
                return;
            }
        }
        private void PrintAll()
        {
            foreach (var reserva in reservas)
            {
                if (reserva != null)
                    reserva.Print(pessoas[reserva.idPessoa], revistas[reserva.idRevista]);
            }
        }
        private bool PositionNotNull(int id)
        {
            bool existe = false;
            
            if (reservas[id] != null)
                existe = true;
            

            return existe;
        }
        public static void PopularArray(ref ClassReserva[] reservas)
        {
            DateTime res1data1 = new DateTime(2022, 03, 18);
            DateTime res1data2 = new DateTime(2022, 03, 20);

            DateTime res2data1 = new DateTime(2022, 03, 15);
            DateTime res2data2 = new DateTime(2022, 03, 17);

            DateTime res3data1 = new DateTime(2022, 03, 16);
            DateTime res3data2 = new DateTime(2022, 03, 18);

            ClassReserva res1 = new ClassReserva(0, res1data1, res1data2, 0, 0);
            ClassReserva res2 = new ClassReserva(1, res2data1, res2data2, 1, 1);
            ClassReserva res3 = new ClassReserva(2, res3data1, res3data2, 1, 0);
            reservas[0] = res1;
            reservas[1] = res2;
            reservas[2] = res3;
        }
        #endregion

    }
}
