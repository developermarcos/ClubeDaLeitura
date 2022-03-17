using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ClassCategoriaRevista
    {
        public int ID;
        public string nome;
        public int quantidadeDiasEmprestimo;

        public ClassCategoriaRevista() { }
        public ClassCategoriaRevista(int id, string nome, int quatidade)
        {
            this.ID = id;
            this.nome = nome;
            this.quantidadeDiasEmprestimo = quatidade;
        }
        public void Print()
        {
            Console.WriteLine($"ID: {this.ID} - Categoria '{this.nome}' pode ser emprestada apenas por {this.quantidadeDiasEmprestimo} dia(s).");
        }
    }
}
