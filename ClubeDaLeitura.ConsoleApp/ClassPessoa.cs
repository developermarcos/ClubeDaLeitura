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
        public ClassPessoa() { }
        public ClassPessoa(int id, string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.ID = id;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        public void Print()
        {
            Console.WriteLine($"ID: {this.ID} | Nome: {this.nome} | Responsável: {this.nomeResponsavel} | Telefone: {this.telefone} | Endereço: {this.endereco}");
        }
    }
}
