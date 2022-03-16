using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp
{
    public enum Emprestimos
    {
        Listar =1,
        Cadastrar = 2,
        Editar = 3,
        Excluir = 4
    }
    internal class Emprestimo
    {
        int ID;
        int idAmigo;
        int idRevista;
        DateTime dataEmprestimo;
        DateTime dataDevolucao;
        bool posicaoPreenchida;

        public void Listar(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            Console.WriteLine("\n *Listagem*");

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if(emprestimos[i] != null || emprestimos[i].posicaoPreenchida == false)
                {
                    Console.WriteLine($"-ID: {emprestimos[i].ID} | Amigo: {amigos[emprestimos[i].idAmigo].nome} | Revista edição: {revistas[emprestimos[i].idRevista].numeroEdicao} | Data emprestimo: {emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy")} | Data devolução: {emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy")} ");
                }
            }

            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
        }
        public void Cadastrar(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            bool sairMetodo = false;
            Emprestimo emprestimoCadastro = new Emprestimo();

            Console.WriteLine("\n *Cadastro*");

            inputDados(ref sairMetodo, ref emprestimoCadastro, ref emprestimos, ref revistas, ref amigos, ref caixas);
            
            if (sairMetodo == true)
                return;

            emprestimoCadastro.posicaoPreenchida = true;
            emprestimos[emprestimoCadastro.ID] = emprestimoCadastro;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Editar(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {

        }
        public void Excluir(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {

        }
        public void EmprestimosRealizadosMesAtual()
        {

        }
        public void EmprestimosRealizadosHoje()
        {

        }
        public bool ExisteEmprestimoParaEsseAmigo()
        {
            bool existe = false;

            return existe;
        }

        #region Métodos auxiliares
        private void inputDados(ref bool sairMetodo, ref Emprestimo emprestimoCadastro, ref Emprestimo[] emprestimos, ref Revista[] revistas, ref Pessoa[] amigos, ref Caixa[] caixas)
        {
            Console.WriteLine("\nListagem de amigos");
            Pessoa.ImprimirPessoas(amigos);
            if ((emprestimoCadastro.ID = PosicaoParaCadastro(emprestimos)) == -1)
            {
                Console.WriteLine("Base de dados está cheia, contate o administrador");
                return;
            }
            while (true)
            {
                Console.Write("Para sair pressione enter ou informe o ID do amigo: ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = int.TryParse(lerTela, out int idCadastro);
                if (conversaoRealizada == true && Pessoa.ExisteNoArray(amigos, idCadastro))
                {
                    emprestimoCadastro.idAmigo = idCadastro;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.Write("id do amigo informado não encontrado.\n");
            }
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            Console.WriteLine("\nListagem de revistas");
            Revista.ImpimirRevistas(revistas, caixas);
            while (true)
            {
                Console.Write("Para sair pressione enter ou informe o ID da revista: ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = int.TryParse(lerTela, out int idCadastro);
                if (conversaoRealizada == true && Revista.ExisteNoArray(revistas, idCadastro))
                {
                    emprestimoCadastro.idRevista = idCadastro;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.Write("ID da revista informado não encontrado.\n");
            }
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            while (true)//Input + validação Data emprestimo
            {
                Console.Write("Informe o data do emprestimo da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataEmprestimo);
                if ((conversaoRealizada == true && lerTela.Length == 10))
                {
                    emprestimoCadastro.dataEmprestimo = dataEmprestimo;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto.");
            }
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            while (true)//Input + validação Data emprestimo
            {
                Console.Write("Informe o data de devolução do empréstimo da revista (00/00/0000): ");
                string lerTela = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(lerTela, out DateTime dataDelovucao);
                if ((conversaoRealizada == true && lerTela.Length == 10) && emprestimoCadastro.dataEmprestimo <= dataDelovucao)
                {
                    emprestimoCadastro.dataDevolucao = dataDelovucao;
                    break;
                }
                else if (lerTela == "")
                {
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto ou menor que a data do empréstimo.");
            }
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }
        }
        public static int PosicaoParaCadastro(Emprestimo[] emprestimos)
        {
            int idParaCadastro = -1;//Em caso de array cheio retorna -1

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if(emprestimos[i] == null || emprestimos[i].posicaoPreenchida == false)
                {
                    idParaCadastro = i;
                    break;
                }
            }

            return idParaCadastro;
        }
        #endregion
    }
}
