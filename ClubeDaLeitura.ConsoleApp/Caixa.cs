using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public enum Caixas
    {
        Listar = 1,
        Cadastrar = 2,
        Editar = 3,
        Excluir = 4
    }
    internal class Caixa
    {
        public string etiqueta, numero, cor;
        public int caixaId;
        bool posicaoPreenchida;

        public Caixa() { }
        public Caixa(int id, string cor, string etiqueta, string numero, bool posicaoPreenchida)
        {
            this.caixaId = id;
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
            this.posicaoPreenchida = posicaoPreenchida;
        }
        public void Listar(Caixa[] caixas)
        {
            Console.WriteLine("\nListar caixas");
            ImprimirCaixas(caixas);
            Console.WriteLine("Pressione enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Cadastrar(ref Caixa[] caixas)
        {
            Caixa caixaCadastro = new Caixa();
            bool sairMetodo = false;
            int arrayCheio = -1;

            Console.WriteLine("\nCadastrar caixa");

            caixaCadastro.caixaId = PosicaoInserirArray(caixas);

            if(caixaCadastro.caixaId != arrayCheio)
            {
                Console.WriteLine("Pressione enter para sair do cadastro ou informe o campo solicitado.");
                InputDadosMelhorado(ref caixaCadastro, ref caixas, ref sairMetodo, false);
                if (sairMetodo == true)
                {
                    Console.Clear();
                    return;
                }
                    
                caixaCadastro.posicaoPreenchida = true;
                caixas[caixaCadastro.caixaId] = caixaCadastro;

                Console.Clear();
                Console.WriteLine("Caixa cadastrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar a caixa, contate o administrador do sistema.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Editar(Caixa[] caixas)
        {
            Caixa caixaCadastro = new Caixa();
            bool sairMetodo = false;
            int arrayCheio = -1;

            Console.WriteLine("Editar caixas");
            Console.WriteLine("\nSegue listagem de caixas cadastradas");
            ImprimirCaixas(caixas);
            while (true)
            {
                Console.Write("Pressione enter para sair ou informe o ID da caixa que deseja editar: ");
                string lerTela = Console.ReadLine();

                bool conversaoRealizada = int.TryParse(lerTela, out int idEditar);
                if (conversaoRealizada == true && ExisteNoArray(caixas, idEditar) == true)
                {
                    caixaCadastro.caixaId = idEditar;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Caixa não encontrada, tente novamente");
            }
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            Console.WriteLine("\nPressione enter para manter a informação ou informe a alteração.");
            Console.Write("Caixa em Edição | ");
            ImprimirCaixa(caixas, caixaCadastro.caixaId);
            
            InputDadosMelhorado(ref caixaCadastro, ref caixas, ref sairMetodo, true);

            caixaCadastro.cor = caixaCadastro.cor == "" ? caixas[caixaCadastro.caixaId].cor : caixaCadastro.cor;
            caixaCadastro.etiqueta = caixaCadastro.etiqueta == "" ? caixas[caixaCadastro.caixaId].etiqueta : caixaCadastro.etiqueta;
            caixaCadastro.numero = caixaCadastro.numero == "" ? caixas[caixaCadastro.caixaId].numero : caixaCadastro.numero;
            caixaCadastro.posicaoPreenchida = true;

            caixas[caixaCadastro.caixaId] = caixaCadastro;

            Console.Clear();
            Console.WriteLine("Caixa editada com sucesso!");
            
        }
        public void Excluir(Caixa[] caixas)
        {
            Console.WriteLine("Excluir caixas");
            Console.WriteLine("\nSegue listagem de caixas cadastradas");
            ImprimirCaixas(caixas);
            Console.Write("Informe o ID da caixa que deseja editar: ");
            string lerTela = Console.ReadLine();
            bool conversaoRealizada = int.TryParse(lerTela, out int idExcluir);
            if (conversaoRealizada == true && ExisteNoArray(caixas, idExcluir) == true)
            {
                caixas[idExcluir].caixaId = default;
                caixas[idExcluir].etiqueta = "";
                caixas[idExcluir].cor = default;
                caixas[idExcluir].numero = default;
                caixas[idExcluir].posicaoPreenchida = false;
                Console.Clear();
                Console.WriteLine("Caixa excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Id não encontrado.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region Métodos auxiliares
        public static void ImprimirCaixas(Caixa[] caixas)
        {
            foreach (var caixa in caixas)
            {
                if (caixa != null && caixa.posicaoPreenchida == true)
                    Console.WriteLine($"ID: {caixa.caixaId} | Etiqueta: {caixa.etiqueta} | Cor: {caixa.cor} | Numero: {caixa.numero}");
            }
        }
        private static void ImprimirCaixa(Caixa[] caixas, int id)
        {
            Console.WriteLine($"ID: {caixas[id].caixaId} | Etiqueta: {caixas[id].etiqueta} | Cor: {caixas[id].cor} | Numero: {caixas[id].numero}");
        }
        private static void InputDadosMelhorado(ref Caixa caixaCadastro, ref Caixa[] caixas, ref bool sairMetodo, bool ehEdicao)
        {
            Console.Write("Informe a etiqueta da caixa: ");
            caixaCadastro.etiqueta = Console.ReadLine();
            if (caixaCadastro.etiqueta == "" && ehEdicao == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o numero da caixa: ");
            caixaCadastro.numero = Console.ReadLine();
            if (caixaCadastro.numero == "" && ehEdicao == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe a cor da caixa: ");
            caixaCadastro.cor = Console.ReadLine();
            if (caixaCadastro.cor == "" && ehEdicao == false)
            {
                sairMetodo = true;
                return;
            }
        }
        private static int PosicaoInserirArray(Caixa[] caixas)
        {
            int posicao = -1;//Em caso de array cheio retorno -1

            for (int i = 0; i < caixas.Length; i++)
            {
                if(caixas[i] == null || caixas[i].posicaoPreenchida == false)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static bool ExisteNoArray(Caixa[] caixas, int id)
        {
            bool existe = false;

            if (caixas[id] != null && caixas[id].posicaoPreenchida == true)
                existe = true;
            

            return existe;
        }
        public static void PopularCaixas(Caixa[] caixas)
        {
            Caixa c1 = new Caixa(0, "Preta", "Edição especial", "123", true);
            Caixa c2 = new Caixa(1, "Branca", "Doação", "321", true);
            caixas[0] = c1;
            caixas[1] = c2;
        }
        #endregion

        #region métodos auxiliares classes externas
        public void ImprimeCaixaEmRevista()
        {
            if (this != null && this.etiqueta != "")
                Console.WriteLine($"ID: {this.caixaId} | Etiqueta: {this.etiqueta} | Cor: {this.cor} | Numero: {this.numero}");
        }
        #endregion
    }
}
