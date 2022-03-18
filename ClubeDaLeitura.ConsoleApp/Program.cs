using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        public static ClassPessoa[] pessoas = new ClassPessoa[100];
        public static ClassCaixa[] caixas = new ClassCaixa[100];
        public static ClassRevista[] revistas = new ClassRevista[100];
        public static ClassEmprestimo[] emprestimos = new ClassEmprestimo[100];
        public static ClassCategoriaRevista[] categoriaRevistas = new ClassCategoriaRevista[100];
        public static ClassReserva[] reservas = new ClassReserva[100];
        public static bool sairSistema = false;
        static void Main(string[] args)
        {
            ViewCaixas.PopularCaixas(caixas);
            ViewRevistas.PopularArrayRevistas(revistas);
            ViewEmprestimos.PopularArray(emprestimos);
            ViewPessoas.PopularPessoas(ref pessoas);
            ViewCategoriaRevista.PopularCategoriasRevistas(ref categoriaRevistas);
            ViewReservas.PopularArray(ref reservas);
            while (sairSistema == false)
            {
                Menu();
            }
            Console.ReadKey();
        }
        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(" --------------------------------------------------------------- ");
            Console.WriteLine("||                       Clube da Leitura                      ||");
            Console.WriteLine(" --------------------------------------------------------------- ");
            Console.ResetColor();

            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n--------------------------Menu Principal--------------------------");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("|| {0,-5} || {1,-5} || {2,-5} || {3,-5} || {4,-5} ||", "(1) Amigos", "(2) Caixas", "(3) Revistas", "(4) Empréstimos", "(5) Reservas");
            Console.WriteLine("------------------------------------------------------------------");
            Console.Write("Informe a opção desejada: ");
            string lerTela = Console.ReadLine();
            if(lerTela == "")
            {
                Console.Clear();
                return;
            }
            bool conversaoRealizada = int.TryParse(lerTela, out int opcao);
            if(conversaoRealizada == true)
            {
                switch (opcao)
                {
                    case 1:
                        ViewPessoas viewPessoa = new ViewPessoas(ref pessoas);
                        viewPessoa.Menu();
                        break;
                    case 2:
                        ViewCaixas viewCaixa = new ViewCaixas(ref caixas);
                        viewCaixa.Menu();
                        break;
                    case 3:
                        ViewRevistas viewRevista = new ViewRevistas(ref revistas, ref caixas, ref categoriaRevistas);
                        viewRevista.Menu();
                        break;
                    case 4:
                        ViewEmprestimos viewEmprestimos = new ViewEmprestimos(ref caixas, ref pessoas, ref revistas, ref emprestimos, ref categoriaRevistas);
                        viewEmprestimos.Menu();
                        break;
                    case 5:
                        ViewReservas viewReservas = new ViewReservas(ref caixas, ref categoriaRevistas, ref pessoas, ref revistas, ref reservas, ref emprestimos);
                        viewReservas.Menu();
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
}
