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
        public int idPessoa;
        public int idRevista;
        public ClassReserva() { }
        public ClassReserva(int id, DateTime dateReserva, DateTime dateExpira, int amigo, int revista)
        {
            this.ID = id;
            this.dataReserva = dateReserva;
            this.dataExpira = dateExpira;
            this.idPessoa = amigo;
            this.idRevista = revista;
        }
        public void Print(ClassPessoa pessoa, ClassRevista revista)
        {
            DateTime dataExpira = new DateTime(this.dataExpira.Year, this.dataExpira.Month, this.dataExpira.Day);
            DateTime dataAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string reservaStatus = DateTime.Compare(dataExpira, dataAtual) >= 0 ? "Reserva vigente" : "Reserva expirada";
            Console.WriteLine($"Reserva ID: {this.ID} | Amigo: {pessoa.nome} | Revista: {revista.numeroEdicao} | Data reserva: {dataReserva.ToString("dd/MM/yyyy")} | Validade: {dataExpira.ToString("dd/MM/yyyy")} | Status {reservaStatus}");
        }
    }
}
