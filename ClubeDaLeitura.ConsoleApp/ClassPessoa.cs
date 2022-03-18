using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ClassPessoa
    {
        public int ID;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public ClassMulta[] multas;
        public ClassPessoa() { }
        public ClassPessoa(int id, string nome, string nomeResponsavel, string telefone, string endereco, ClassMulta[] multas)
        {
            this.ID = id;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
            this.multas = multas;
        }
        public void Print()
        {
            Console.WriteLine($"ID: {this.ID} | Nome: {this.nome} | Responsável: {this.nomeResponsavel} | Telefone: {this.telefone} | Endereço: {this.endereco}");
        }
        public void PrintMultas()
        {
            foreach (var multa in multas)
            {
                if (multa != null)
                    multa.Print();
            }
        }
    }
}
