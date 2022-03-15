using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public enum CoresCaixas
    {
        Azul = 1,
        Preto = 2,
        Branco = 3,
        Amarelo = 4
    }
    public enum Caixas
    {
        Listar = 1,
        Cadastrar = 2,
        Editar = 3,
        Excluir = 4
    }
    internal class Caixa
    {
        public CoresCaixas cor;
        public string etiqueta;
        public int numero;

        public void Listar(Caixa[] caixas)
        {

        }
        public void Cadastrar(ref Caixa[] caixas)
        {

        }
        public void Editar(Caixa[] caixas)
        {

        }
        public void Excluir(Caixa[] caixas)
        {

        }
    }
}
