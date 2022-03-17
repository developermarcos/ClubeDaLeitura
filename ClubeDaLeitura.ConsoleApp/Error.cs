using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Error
    {
        public static void Mensagem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("||{0,-30} {1,0} {2,-30}||", " ", "Error", " ");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine("     --Opção não encontrada, pressione enter para voltar ao menu--");
        }   
    }
}
