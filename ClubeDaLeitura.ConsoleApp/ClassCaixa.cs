using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class ClassCaixa
    {
        public string etiqueta, numero, cor;
        public int caixaId;
        
        public ClassCaixa() { }
        public ClassCaixa(int id, string cor, string etiqueta, string numero)
        {
            this.caixaId = id;
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
        }
        public void Print()
        {
            Console.WriteLine($"ID: {this.caixaId} | Etiqueta: {this.etiqueta} | Cor: {this.cor} | Numero: {this.numero}");
        }
    }
}
