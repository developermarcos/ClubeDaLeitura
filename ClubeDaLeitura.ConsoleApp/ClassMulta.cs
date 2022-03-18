using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ClassMulta
    {
        public int ID;
        public decimal valor;
        public string descricao;
        public bool aberta;

        public ClassMulta(int id, string descricao, decimal valor, bool aberta)
        {
            this.ID = id;
            this.valor = valor;
            this.descricao = descricao;
            this.aberta = aberta;
        }
        public void Print()
        {
            string status = this.aberta == true ? "Aberta" : "Fechada";
            Console.WriteLine($"ID: {this.ID} | {this.descricao} | Valor: {this.valor} | Status {status}");
        }
    }
}
