using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    
    internal class ClassRevista
    {
        public int ID;
        public int CaixaID;
        public int categoriaID;
        public string numeroEdicao;
        public DateTime anoRevista;
        public string tipoColecao;
        public ClassRevista() { }
        public ClassRevista(int revistaId, string numeroEdicao, DateTime anoRevista, string tipoColecao, int revistaCaixaId, int categoriaRevista)
        {
            this.ID = revistaId;
            this.numeroEdicao = numeroEdicao;
            this.anoRevista = anoRevista;
            this.tipoColecao = tipoColecao;
            this.CaixaID = revistaCaixaId;
            this.categoriaID = categoriaRevista;
        }
        public void Print(ClassCaixa caixa, ClassCategoriaRevista categoria)
        {
            Console.WriteLine($"ID: {this.ID} | Edição: {this.numeroEdicao} | Categoria: {categoria.nome} | Ano: {this.anoRevista.ToString("dd/MM/yyyy")} | Tipo coleção: {this.tipoColecao} | Caixa: {caixa.etiqueta} - {caixa.cor}");
        }
    }
}
