using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ViewEmprestimos
    {
        ClassCaixa[] caixas;
        ClassPessoa[] pessoas;
        ClassRevista[] revistas;
        ClassEmprestimo[] emprestimos;
        public ViewEmprestimos(ref ClassCaixa[] c, ref ClassPessoa[] p, ref ClassRevista[] r, ref ClassEmprestimo[] e)
        {
            caixas = c;
            pessoas = p;
            revistas = r;
            emprestimos = e;
        }
        public void Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------------------------------Emprestimos------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.Write($"|| (1) Listar |");
            Console.Write($"| (2) Cadastrar  |");
            Console.Write($"| (3) Editar  |");
            Console.Write($"| (4) Excluir  |");
            Console.Write($"| (5) Fechar  |");
            Console.Write($"| (6) Mensal  |");
            Console.Write($"| (7) Abertos  |");
            Console.Write($"| (8) Diario ||");
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------");
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
                        Fechar();
                        break;
                    case 6:
                        Mensal();
                        break;
                    case 7:
                        Abertos();
                        break;
                    case 8:
                        Diario();
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
            Console.WriteLine("\n *Listagem*");
            PrintAll();

            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Cadastrar()
        {
            bool sairMetodo = false;
            ClassEmprestimo emprestimoCadastro = new ClassEmprestimo();

            Console.WriteLine("\n *Cadastro*");

            Console.WriteLine("\nListagem de amigos");
            ViewPessoas viewPessoa = new ViewPessoas(ref pessoas);
            viewPessoa.PrintAll();
            if ((emprestimoCadastro.ID = PositionToInsert()) == -1)
            {
                Console.WriteLine("Base de dados está cheia, contate o administrador");
                return;
            }

            DataInput(ref sairMetodo, ref emprestimoCadastro, false);

            if (sairMetodo == true)
                return;

            emprestimoCadastro.emprestimoAberto = true;
            emprestimos[emprestimoCadastro.ID] = emprestimoCadastro;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Editar()
        {
            bool sairMetodo = false;
            ClassEmprestimo emprestimoEdicao = new ClassEmprestimo();

            Console.WriteLine("\n *Edição*");
            Console.WriteLine("Listagem de Emprestimos cadastrados");
            PrintAll();

            while (true)
            {
                Console.Write("Pressione enter para voltar ao menu ou informe o ID que deseja alterar: ");
                string lerTela = Console.ReadLine();

                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && PositionNotNull(idEdicao) == true)
                {
                    emprestimoEdicao.ID = idEdicao;
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

            Console.WriteLine("\nPressione enter para manter a informação anterior ou informe o novo atributo");

            ViewPessoas viewPessoas = new ViewPessoas(ref pessoas);
            viewPessoas.PrintAll();
            DataInput(ref sairMetodo, ref emprestimoEdicao, true);

            emprestimoEdicao.emprestimoAberto = true;
            emprestimos[emprestimoEdicao.ID] = emprestimoEdicao;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Excluir()
        {
            bool sairMetodo = false;

            Console.WriteLine("\n *Exclusão*");
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
        public void Fechar()
        {
            bool sairMetodo = false;
            ClassEmprestimo emprestimoExclusao = new ClassEmprestimo();

            Console.WriteLine("\n *Encerrar empréstimo*");
            Console.WriteLine("Listagem de Emprestimos cadastrados");
            PrintAll();

            while (true)
            {
                Console.Write("Pressione enter para voltar ao menu ou informe o ID que deseja fechar o empréstimo: ");
                string lerTela = Console.ReadLine();

                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && PositionNotNull(idEdicao) == true)
                {
                    emprestimoExclusao.ID = idEdicao;
                    emprestimos[idEdicao].emprestimoAberto = false;
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
            Console.WriteLine("Empréstimo encerrado com sucesso!");
        }
        public void Diario()
        {
            Console.WriteLine("\n *Empréstimos hoje*");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (DateTime.Now.ToString("dd/MM/yyyy") == emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy"))
                        emprestimos[i].Print(pessoas[emprestimos[i].idAmigo], revistas[emprestimos[i].idRevista]);
                }
            }
            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Mensal()
        {
            Console.WriteLine("\n *Empréstimos Mensal*");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    if (DateTime.Now.ToString("MM") == emprestimos[i].dataEmprestimo.ToString("MM"))
                        emprestimos[i].Print(pessoas[emprestimos[i].idAmigo], revistas[emprestimos[i].idRevista]);
                }
            }
            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Abertos()
        {
            Console.WriteLine("\n *Empréstimos em aberto*");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].emprestimoAberto == true)
                {
                    emprestimos[i].Print(pessoas[emprestimos[i].idAmigo], revistas[emprestimos[i].idRevista]);
                }
            }
            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        #region Métodos auxiliares
        private void DataInput(ref bool sairMetodo, ref ClassEmprestimo emprestimoCadastro, bool ehEdicao)
        {
            while (true)
            {
                Console.Write("Para sair pressione enter ou informe o ID do amigo: ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = int.TryParse(lerTela, out int idCadastro);
                ViewPessoas viewPessoa = new ViewPessoas(ref pessoas);
                if (conversaoRealizada == true && viewPessoa.PosicaoNotNull(idCadastro) == true)
                {
                    emprestimoCadastro.idAmigo = idCadastro;
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
            ViewRevistas viewRevistas = new ViewRevistas(ref revistas, ref caixas);
            viewRevistas.PrintAll();
            while (true)
            {
                Console.Write("Para sair pressione enter ou informe o ID da revista: ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = int.TryParse(lerTela, out int idCadastro);
                if (conversaoRealizada == true && PositionNotNull(idCadastro))
                {
                    emprestimoCadastro.idRevista = idCadastro;
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

            while (true)//Input + validação Data emprestimo
            {
                Console.Write("Informe o data do emprestimo da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataEmprestimo);
                if ((conversaoRealizada == true && lerTela.Length == 10))
                {
                    emprestimoCadastro.dataEmprestimo = dataEmprestimo;
                    break;
                }
                else if (lerTela == "")
                {
                    emprestimoCadastro.dataEmprestimo = lerTela == "" ? emprestimos[emprestimoCadastro.ID].dataEmprestimo : dataEmprestimo;
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

            while (true)//Input + validação Data emprestimo
            {
                Console.Write("Informe o data de devolução do empréstimo da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataDelovucao);
                if ((conversaoRealizada == true && lerTela.Length == 10) && emprestimoCadastro.dataEmprestimo <= dataDelovucao)
                {
                    emprestimoCadastro.dataDevolucao = dataDelovucao;
                    break;
                }
                else if (lerTela == "")
                {
                    emprestimoCadastro.dataDevolucao = lerTela == "" ? emprestimos[emprestimoCadastro.ID].dataDevolucao : dataDelovucao;
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto ou menor que a data do empréstimo.");
            }
            if (sairMetodo == true && ehEdicao == false)
            {
                Console.Clear();
                return;
            }
        }
        public int PositionToInsert()
        {
            int idParaCadastro = -1;//Em caso de array cheio retorna -1

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null)
                {
                    idParaCadastro = i;
                    break;
                }
            }

            return idParaCadastro;
        }
        private void PrintAll()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    emprestimos[i].Print(pessoas[emprestimos[i].idAmigo], revistas[emprestimos[i].idRevista]);
                }
            }
        }
        private bool PositionNotNull(int idEdicao)
        {
            bool existe = false;

            if (emprestimos[idEdicao] != null)
                existe = true;

            return existe;
        }
        public static void PopularArray(ClassEmprestimo[] emprestimos)
        {
            //int idAmigo, int idRevista, DateTime dataEmprestimo, DateTime dataDevolucao, bool posicaoPreenchida)
            DateTime data1 = new DateTime(2022, 03, 10);
            DateTime data2 = new DateTime(2022, 03, 20);
            DateTime data3 = new DateTime(2022, 03, 16);
            ClassEmprestimo emp1 = new ClassEmprestimo(0, 0, 0, data1, data2, true);
            ClassEmprestimo emp2 = new ClassEmprestimo(1, 1, 1, data1, data2, true);
            ClassEmprestimo emp3 = new ClassEmprestimo(2, 0, 1, data3, data3, true);
            emprestimos[0] = emp1;
            emprestimos[1] = emp2;
            emprestimos[2] = emp3;

        }
        #endregion
    }
}
