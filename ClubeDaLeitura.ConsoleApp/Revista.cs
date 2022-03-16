using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public enum Revistas
    {
        Listar = 1,
        Cadastrar = 2,
        Editar = 3,
        Excluir = 4
    }
    
    internal class Revista
    {
        public int revistaId, revistaCaixaId;
        public string numeroEdicao;
        public DateTime anoRevista;
        public string tipoColecao;
        public bool posicaoPreenchida;
        public Revista() { }
        public Revista(int revistaId, string numeroEdicao, DateTime anoRevista, string tipoColecao, int revistaCaixaId, bool posicaoPreenchida)
        {
            this.revistaId = revistaId;
            this.numeroEdicao = numeroEdicao;
            this.anoRevista = anoRevista;
            this.tipoColecao = tipoColecao;
            this.revistaCaixaId = revistaCaixaId;
            this.posicaoPreenchida = posicaoPreenchida;
        }

        #region Métodos principais
        public void Listar(Revista[] revistas, Caixa[] caixas)
        {
            Console.WriteLine("\nListas revistas");
            ImpimirRevistas(revistas, caixas);
            Console.Write("\nPressione enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Cadastrar(Revista[] revistas, Caixa[] caixas)
        {
            Revista revistaCadastro = new Revista();
            
            Console.WriteLine("\nCadastrar revistas");

            revistaCadastro.revistaId = PosicaoInserirArray(revistas);
            if (revistaCadastro.revistaId != -1)
            {
                InputDados(caixas, ref revistaCadastro);
                revistaCadastro.posicaoPreenchida = true;
                revistas[revistaCadastro.revistaId] = revistaCadastro;

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
        public void Editar(ref Revista[] revistas, Caixa[] caixas)
        {
            Revista revistaEdicao = new Revista();

            Console.WriteLine("\nCadastrar revistas");

            ImpimirRevistas(revistas, caixas);
            while (true)
            {
                Console.Write("\nPressione enter para voltar ou informe o ID da revista que deseja alterar:");
                string lerTela = Console.ReadLine();
                if (lerTela == "")
                {
                    Console.Clear();
                    return;
                }
                   
                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && Revista.ExisteNoArray(revistas, idEdicao) == true)
                {
                    revistaEdicao.revistaId = idEdicao;
                    break;
                }
            }
            //revistaId numeroEdicao=V anoRevista=V tipoColecao=V revistaCaixaId=V
            if (revistaEdicao.revistaId != -1 &&  revistaEdicao.revistaId != default)
            {
                InputDados(caixas, ref revistaEdicao);
                
                //Insere no array
                revistas[revistaEdicao.revistaId] = revistaEdicao;

                Console.Clear();
                Console.WriteLine("Caixa editada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar a caixa, contate o administrador do sistema.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Excluir(Revista[] revistas, Caixa[] caixas)
        {
            ImpimirRevistas(revistas, caixas);
            while (true)
            {
                int idExclusao;
                Console.Write("\nPressione enter para voltar ou informe o ID da revista que deseja alterar:");
                string lerTela = Console.ReadLine();
                if (lerTela == "")
                {
                    Console.Clear();
                    return;
                }
                bool conversaoRealizada = int.TryParse(lerTela, out idExclusao);
                if (conversaoRealizada == true && Revista.ExisteNoArray(revistas, idExclusao) == true)
                {
                    DateTime nullDate;
                    revistas[idExclusao].revistaId = default;
                    revistas[idExclusao].numeroEdicao = "";
                    revistas[idExclusao].anoRevista = default;
                    revistas[idExclusao].tipoColecao = default;
                    revistas[idExclusao].revistaCaixaId = default;
                    revistas[idExclusao].posicaoPreenchida = false;

                    Console.Clear();
                    Console.WriteLine("Revista excluída com sucesso!");
                    break;
                }
            }
        }
        #endregion

        #region Métodos auxiliares
        private void InputDados(Caixa[] caixas, ref Revista revista)
        {
            Console.Write("Informe o numero de edição da revista: ");
            revista.numeroEdicao = Console.ReadLine();
            
            while (true)//Input + validação Data criacao
            {
                Console.Write("Informe o data de fabricação da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataCriacaoRevista);
                if (conversaoRealizada == true && lerTela.Length == 10)
                {
                    revista.anoRevista = dataCriacaoRevista;
                    break;
                }
                else if(lerTela == "")
                {
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto.");
            }
            
            Console.WriteLine("\nLista de caixas cadastradas");
            Caixa.ImprimirCaixas(caixas);

            while (true)//Input + validação caixa para guardar revista
            {
                int revistaCaixaId;
                Console.Write("Informe a caixa que deseja guardar a revista: ");
                string lerTela = Console.ReadLine();
                if (lerTela == "")
                    break;
                bool conversaoRealizada = int.TryParse(lerTela, out revistaCaixaId);
                if (conversaoRealizada == true && Caixa.ExisteNoArray(caixas, revistaCaixaId) == true)
                {
                    revista.revistaCaixaId = revistaCaixaId;
                    break;
                }
                else
                {
                    Console.WriteLine("\nCaixa informada não existe");
                }
            }
        }
        private int PosicaoInserirArray(Revista[] revistas)
        {
            int posicao = -1;//Em caso de array lotado, retorno -1

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null || revistas[i].posicaoPreenchida == false)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static void ImpimirRevistas(Revista[] revistas, Caixa[] caixas)
        {
            foreach (var revista in revistas)
            {
                if (revista != null && revista.posicaoPreenchida == true)
                {
                    Console.WriteLine($"ID: {revista.revistaId} | Edição: {revista.numeroEdicao} | Ano: {revista.anoRevista.ToString("dd/MM/yyyy")} | Tipo coleção: {revista.tipoColecao} | Caixa: {caixas[revista.revistaCaixaId].etiqueta} - {caixas[revista.revistaCaixaId].cor}");
                }
            }
        }
        public static bool ExisteNoArray(Revista[] revistas, int id)
        {
            bool existe = false;

            if (revistas[id] != null && revistas[id].posicaoPreenchida == true)
                existe = true;

            return existe;
        }
        public static void PopularArrayRevistas(Revista[] revistas)
        {
            DateTime data = new DateTime(2020, 11,21);
            Revista rev1 = new Revista(0, "444", data, "Aventura", 0, true);
            Revista rev2 = new Revista(1, "555", data, "Terror", 1, true);
            revistas[0] = rev1;
            revistas[1] = rev2;
        }
        #endregion
    }
}
