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
        public int numero, caixaId;

        public Caixa() { }
        public Caixa(int id, CoresCaixas cor, string etiqueta, int numero)
        {
            this.caixaId = id;
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
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
            string etiqueta, lerTela;
            int numero, posicaoCadastro, idInsercao;
            
            Console.WriteLine("\nCadastrar caixa");
            
            posicaoCadastro = PosicaoInserirArray(caixas);
            if(posicaoCadastro != -1)
            {
                idInsercao = posicaoCadastro;
                CoresCaixas cor;
                InputDados(out etiqueta, out lerTela, out numero, out cor);

                Caixa caixaCadastro = new Caixa(idInsercao, cor, etiqueta, numero);
                caixas[posicaoCadastro] = caixaCadastro;

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
            string etiqueta, lerTela;
            int numero, idEditar;
            CoresCaixas cor;
            bool conversaoRealizada = false;
            
            Console.WriteLine("Editar caixas");
            Console.WriteLine("\nSegue listagem de caixas cadastradas");
            ImprimirCaixas(caixas);
            Console.Write("Informe o ID da caixa que deseja editar: ");
            lerTela = Console.ReadLine();
            conversaoRealizada = int.TryParse(lerTela, out idEditar);
            if(conversaoRealizada == true && ExisteNoArray(caixas, idEditar) == true)
            {
                Console.WriteLine("\nCaso deseje manter informação anterior, mantenha o campo vazio e pressione enter.");
                Console.Write("Caixa em Edição | ");
                ImprimirCaixa(caixas, idEditar);
                InputDados(out etiqueta, out lerTela, out numero, out cor);

                cor = cor == default ? caixas[idEditar].cor : cor;
                etiqueta = etiqueta == "" ? caixas[idEditar].etiqueta : etiqueta;
                numero = numero == default ? caixas[idEditar].numero : numero;

                Caixa caixaCadastro = new Caixa(idEditar, cor, etiqueta, numero);
                caixas[idEditar] = caixaCadastro;

                Console.Clear();
                Console.WriteLine("Caixa editada com sucesso!");
            }
            else
            {
                Console.WriteLine("Id não encontrado");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Excluir(Caixa[] caixas)
        {
            string lerTela;
            int idExcluir;
            CoresCaixas cor;
            bool conversaoRealizada = false;

            Console.WriteLine("Excluir caixas");
            Console.WriteLine("\nSegue listagem de caixas cadastradas");
            ImprimirCaixas(caixas);
            Console.Write("Informe o ID da caixa que deseja editar: ");
            lerTela = Console.ReadLine();
            conversaoRealizada = int.TryParse(lerTela, out idExcluir);
            if (conversaoRealizada == true && ExisteNoArray(caixas, idExcluir) == true)
            {
                caixas[idExcluir].caixaId = default;
                caixas[idExcluir].etiqueta = "";
                caixas[idExcluir].cor = default;
                caixas[idExcluir].numero = default;
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
        private static void ImprimirCaixas(Caixa[] caixas)
        {
            foreach (var caixa in caixas)
            {
                if (caixa != null && caixa.etiqueta != "")
                    Console.WriteLine($"ID: {caixa.caixaId} | Etiqueta: {caixa.etiqueta} | Cor: {caixa.cor} | Numero: {caixa.numero}");
            }
        }
        private static void ImprimirCaixa(Caixa[] caixas, int id)
        {
            Console.WriteLine($"ID: {caixas[id].caixaId} | Etiqueta: {caixas[id].etiqueta} | Cor: {caixas[id].cor} | Numero: {caixas[id].numero}");
        }
        private static void InputDados(out string etiqueta, out string lerTela, out int numero, out CoresCaixas cor)
        {
            cor = default;
            Console.Write("Informe a etiqueta da caixa: ");
            etiqueta = Console.ReadLine();
            Console.Write("Informe 0 numero da caixa: ");
            numero = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                bool sairLoop = false, conversaoRealizada = false;
                int corInformada;
                Console.Write($"Selecione a cor da caixa");
                Console.Write($" ({CoresCaixas.Azul.GetHashCode()}) {CoresCaixas.Azul} |");
                Console.Write($" ({CoresCaixas.Preto.GetHashCode()}) {CoresCaixas.Preto} |");
                Console.Write($" ({CoresCaixas.Branco.GetHashCode()}) {CoresCaixas.Branco} |");
                Console.Write($" ({CoresCaixas.Amarelo.GetHashCode()}) {CoresCaixas.Amarelo}: ");
                lerTela = Console.ReadLine();

                conversaoRealizada = int.TryParse(lerTela, out corInformada);
                if (conversaoRealizada == true)
                {
                    switch (corInformada)
                    {
                        case (int)CoresCaixas.Azul:
                            cor = CoresCaixas.Azul;
                            sairLoop = true;
                            break;
                        case (int)CoresCaixas.Preto:
                            cor = CoresCaixas.Preto;
                            sairLoop = true;
                            break;
                        case (int)CoresCaixas.Branco:
                            cor = CoresCaixas.Branco;
                            sairLoop = true;
                            break;
                        case (int)CoresCaixas.Amarelo:
                            cor = CoresCaixas.Amarelo;
                            sairLoop = true;
                            break;
                        default:
                            Console.WriteLine("Cor não encontrada, tente novamente.");
                            break;

                    }
                }
                else
                    Console.WriteLine("Cor não encontrada, tente novamente.");

                if (sairLoop == true)
                    break;
            }
        }
        private static int PosicaoInserirArray(Caixa[] caixas)
        {
            int posicao = -1;//Em caso de array cheio retorno -1

            for (int i = 0; i < caixas.Length; i++)
            {
                if(caixas[i] == null || caixas[i].etiqueta == "")
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        private static bool ExisteNoArray(Caixa[] caixas, int id)
        {
            bool existe = false;

            if(caixas[id] != null && caixas[id].etiqueta != "")
                existe = true;

            return existe;
        }
        public static void PopularCaixas(Caixa[] caixas)
        {
            Caixa c1 = new Caixa(0, CoresCaixas.Preto, "Ação", 123);
            Caixa c2 = new Caixa(1, CoresCaixas.Amarelo, "Suspense", 123);
            caixas[0] = c1;
            caixas[1] = c2;
        }
        #endregion
    }
}
