using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    
    internal class ClassRevista
    {
        public int revistaId, revistaCaixaId;
        public string numeroEdicao;
        public DateTime anoRevista;
        public string tipoColecao;
        public bool posicaoPreenchida;
        public ClassRevista() { }
        public ClassRevista(int revistaId, string numeroEdicao, DateTime anoRevista, string tipoColecao, int revistaCaixaId)
        {
            this.revistaId = revistaId;
            this.numeroEdicao = numeroEdicao;
            this.anoRevista = anoRevista;
            this.tipoColecao = tipoColecao;
            this.revistaCaixaId = revistaCaixaId;
        }
        public void Print(ClassCaixa caixa)
        {
            Console.WriteLine($"ID: {this.revistaId} | Edição: {this.numeroEdicao} | Ano: {this.anoRevista.ToString("dd/MM/yyyy")} | Tipo coleção: {this.tipoColecao} | Caixa: {caixa.etiqueta} - {caixa.cor}");
        }
    }
}
