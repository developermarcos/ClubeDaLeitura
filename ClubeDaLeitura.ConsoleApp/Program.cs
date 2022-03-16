using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public enum Telas
    {
        Amigos = 1,
        Revistas = 2,
        Caixas = 3,
        Emprestimos = 4,
        Sair = 0,
        Error
    }
    internal class Program
    {
        public static Pessoa[] amigos = new Pessoa[100];
        public static Caixa[] caixas = new Caixa[100];
        public static Revista[] revistas = new Revista[100];
        public static Emprestimo[] emprestimos = new Emprestimo[100];
        public static bool sairSistema = false;
        static void Main(string[] args)
        {
            Pessoa.PopularPessoas(ref amigos);
            Caixa.PopularCaixas(caixas);
            Revista.PopularArrayRevistas(revistas);
            while(sairSistema == false)
            {
                Menu();
            }
            Console.ReadKey();
        }
        public static void Menu()
        {
            string lerTela;
            int opcao;
            bool conversaoRealizada;

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(" --------------------------------------------------------------- ");
            Console.WriteLine("||                       Clube da Leitura                      ||");
            Console.WriteLine(" --------------------------------------------------------------- ");
            Console.ResetColor();

            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n--------------------------Menu Principal-------------------------");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write($"|| ({Telas.Amigos.GetHashCode()}) {Telas.Amigos} |");
            Console.Write($"| ({Telas.Revistas.GetHashCode()}) {Telas.Revistas} |");
            Console.Write($"| ({Telas.Caixas.GetHashCode()}) {Telas.Caixas} |");
            Console.Write($"| ({Telas.Emprestimos.GetHashCode()}) {Telas.Emprestimos} ||");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
            if(lerTela == "")
            {
                Console.Clear();
                return;
            }
            conversaoRealizada = int.TryParse(lerTela, out opcao);
            if(conversaoRealizada == true)
            {
                switch (opcao)
                {
                    case (int)Telas.Amigos:
                        MenuAmigo();
                        break;
                    case (int)Telas.Revistas:
                        MenuRevista();
                        break;
                    case (int)Telas.Caixas:
                        MenuCaixa();
                        break;
                    case (int)Telas.Emprestimos:
                        MenuEmprestimo();
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
        public static void MenuAmigo()
        {
            string lerTela;
            int opcao;
            bool conversaoRealizada;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------Amigos------------------------------");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write($"|| ({Amigos.Listar.GetHashCode()}) {Amigos.Listar} |");
            Console.Write($"| ({Amigos.Cadastrar.GetHashCode()}) {Amigos.Cadastrar} |");
            Console.Write($"| ({Amigos.Editar.GetHashCode()}) {Amigos.Editar} |");
            Console.Write($"| ({Amigos.Excluir.GetHashCode()}) {Amigos.Excluir} ||");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
            if (lerTela == "")
            {
                Console.Clear();
                return;
            }
            conversaoRealizada = int.TryParse(lerTela, out opcao);
            if (conversaoRealizada == true)
            {
                Pessoa Amigo = new Pessoa();
                switch (opcao)
                {
                    case (int)Amigos.Listar:
                        Amigo.Listar(amigos);
                        break;
                    case (int)Amigos.Cadastrar:
                        Amigo.Cadastrar(ref amigos);
                        break;
                    case (int)Amigos.Editar:
                        Amigo.Editar(amigos);
                        break;
                    case (int)Amigos.Excluir:
                        Amigo.Excluir(amigos);
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
        public static void MenuCaixa()
        {
            string lerTela;
            int opcao;
            bool conversaoRealizada;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("----------------------------Caixas----------------------------");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"|| ({Caixas.Listar.GetHashCode()}) {Caixas.Listar} |");
            Console.Write($"| ({Caixas.Cadastrar.GetHashCode()}) {Caixas.Cadastrar} |");
            Console.Write($"| ({Caixas.Editar.GetHashCode()}) {Caixas.Editar} |");
            Console.Write($"| ({Caixas.Excluir.GetHashCode()}) {Caixas.Excluir} ||");
            Console.WriteLine("\n--------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
            if (lerTela == "")
            {
                Console.Clear();
                return;
            }
            conversaoRealizada = int.TryParse(lerTela, out opcao);
            if (conversaoRealizada == true)
            {
                Caixa caixa = new Caixa();
                switch (opcao)
                {
                    case (int)Amigos.Listar:
                        caixa.Listar(caixas);
                        break;
                    case (int)Amigos.Cadastrar:
                        caixa.Cadastrar(ref caixas);
                        break;
                    case (int)Amigos.Editar:
                        caixa.Editar(caixas);
                        break;
                    case (int)Amigos.Excluir:
                        caixa.Excluir(caixas);
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
        public static void MenuRevista()
        {
            string lerTela;
            int opcao;
            bool conversaoRealizada;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("---------------------------Revistas---------------------------");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"|| ({Revistas.Listar.GetHashCode()}) {Revistas.Listar} |");
            Console.Write($"| ({Revistas.Cadastrar.GetHashCode()}) {Revistas.Cadastrar} |");
            Console.Write($"| ({Revistas.Editar.GetHashCode()}) {Revistas.Editar} |");
            Console.Write($"| ({Revistas.Excluir.GetHashCode()}) {Revistas.Excluir} ||");
            Console.WriteLine("\n--------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
            if (lerTela == "")
            {
                Console.Clear();
                return;
            }
            conversaoRealizada = int.TryParse(lerTela, out opcao);
            if (conversaoRealizada == true)
            {
                Revista revista = new Revista();
                switch (opcao)
                {
                    case (int)Amigos.Listar:
                        revista.Listar(revistas, caixas);
                        break;
                    case (int)Amigos.Cadastrar:
                        revista.Cadastrar(revistas, caixas);
                        break;
                    case (int)Amigos.Editar:
                        revista.Editar(ref revistas, caixas);
                        break;
                    case (int)Amigos.Excluir:
                        revista.Excluir(revistas, caixas);
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
        public static void MenuEmprestimo()
        {
            string lerTela;
            int opcao;
            bool conversaoRealizada;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("--------------------------Emprestimos-------------------------");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"|| ({Emprestimos.Listar.GetHashCode()}) {Emprestimos.Listar} |");
            Console.Write($"| ({Emprestimos.Cadastrar.GetHashCode()}) {Emprestimos.Cadastrar} |");
            Console.Write($"| ({Emprestimos.Editar.GetHashCode()}) {Emprestimos.Editar} |");
            Console.Write($"| ({Emprestimos.Excluir.GetHashCode()}) {Emprestimos.Excluir} ||");
            Console.WriteLine("\n--------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
            if (lerTela == "")
            {
                Console.Clear();
                return;
            }
            conversaoRealizada = int.TryParse(lerTela, out opcao);
            if (conversaoRealizada == true)
            {
                Emprestimo emprestimo = new Emprestimo();
                switch (opcao)
                {
                    case (int)Amigos.Listar:
                        emprestimo.Listar(emprestimos, amigos, revistas, caixas);
                        break;
                    case (int)Amigos.Cadastrar:
                        emprestimo.Cadastrar(emprestimos, amigos, revistas, caixas);
                        break;
                    case (int)Amigos.Editar:
                        emprestimo.Editar(emprestimos, amigos, revistas, caixas);
                        break;
                    case (int)Amigos.Excluir:
                        emprestimo.Excluir(emprestimos, amigos, revistas, caixas);
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
    }
    public class Error
    {
        public static void Mensagem()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("-----------------------------Erro-----------------------------");
            Console.ResetColor();
            Console.WriteLine("Página não encontrada");
        }
    }
}
