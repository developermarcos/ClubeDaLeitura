using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ClassReserva
    {
        public int ID;
        public DateTime dataReserva;
        public DateTime dataExpira;
        public ClassPessoa pessoa;
        public ClassRevista revista;
        public ClassReserva(DateTime date, ClassPessoa pessoa, ClassRevista revista)
        {
            this.dataReserva = date;
            this.pessoa = pessoa;
            this.revista = revista;
        }
        public void Print()
        {
            Console.WriteLine($"Reserva ID: {this.ID} | Amigo: {this.pessoa.nome} | Revista: {revista.numeroEdicao} | Data reserva: {dataReserva.ToString("dd/MM/aaaa")} | Validade: {dataExpira.ToString("dd/MM/aaaa")}");
        }
    }
}
