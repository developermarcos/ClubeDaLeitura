using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ClassEmprestimo
    {
        public int ID;
        public int idAmigo;
        public int idRevista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public bool emprestimoAberto;
        public ClassEmprestimo() { }
        public ClassEmprestimo(int id, int idAmigo, int idRevista, DateTime dataEmprestimo, DateTime dataDevolucao, bool emprestimoAberto)
        {
            this.ID = id;
            this.idAmigo = idAmigo;
            this.idRevista = idRevista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.emprestimoAberto = emprestimoAberto;
        }
        public void Print(ClassPessoa amigo, ClassRevista revista)
        {
            Console.WriteLine($"-ID: {this.ID} | Amigo: {amigo.nome} | Revista edição: {revista.numeroEdicao} | Data emprestimo: {this.dataEmprestimo.ToString("dd/MM/yyyy")} | Data devolução: {this.dataDevolucao.ToString("dd/MM/yyyy")} ");
        }
        
    }
}
