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

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("------------------------------Menus------------------------------");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write($"|| {Telas.Amigos} ({Telas.Amigos.GetHashCode()}) |");
            Console.Write($"| {Telas.Revistas} ({Telas.Revistas.GetHashCode()}) |");
            Console.Write($"| {Telas.Caixas} ({Telas.Caixas.GetHashCode()}) |");
            Console.Write($"| {Telas.Emprestimos} ({Telas.Emprestimos.GetHashCode()}) ||");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
            conversaoRealizada = int.TryParse(lerTela, out opcao);
            if(conversaoRealizada == true)
            {
                switch (opcao)
                {
                    case (int)Telas.Amigos:
                        MenuAmigos();
                        break;
                    case (int)Telas.Revistas:
                        MenuRevistas();
                        break;
                    case (int)Telas.Caixas:
                        MenuCaixas();
                        Console.ReadKey();
                        break;
                    case (int)Telas.Emprestimos:
                        Console.WriteLine("Tela amigos");
                        Console.ReadKey();
                        break;
                    default:
                        Error.Mensagem();
                        Console.ReadKey();
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
        public static void MenuAmigos()
        {
            string lerTela;
            int opcao;
            bool conversaoRealizada;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------Amigos------------------------------");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write($"|| {Amigos.Listar} ({Amigos.Listar.GetHashCode()}) |");
            Console.Write($"| {Amigos.Cadastrar} ({Amigos.Cadastrar.GetHashCode()}) |");
            Console.Write($"| {Amigos.Editar} ({Amigos.Editar.GetHashCode()}) |");
            Console.Write($"| {Amigos.Excluir} ({Amigos.Excluir.GetHashCode()}) ||");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
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
        public static void MenuCaixas()
        {
            string lerTela;
            int opcao;
            bool conversaoRealizada;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------Amigos------------------------------");
            Console.ResetColor();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write($"|| {Caixas.Listar} ({Caixas.Listar.GetHashCode()}) |");
            Console.Write($"| {Caixas.Cadastrar} ({Caixas.Cadastrar.GetHashCode()}) |");
            Console.Write($"| {Caixas.Editar} ({Caixas.Editar.GetHashCode()}) |");
            Console.Write($"| {Caixas.Excluir} ({Caixas.Excluir.GetHashCode()}) ||");
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            lerTela = Console.ReadLine();
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
        public static void MenuRevistas()
        {

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
