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
        Excluir = 4,
        Fechar = 5,
        Mensal = 6,
        Abertos = 7,
        Diario = 8
    }
    internal class Emprestimo
    {
        int ID;
        int idAmigo;
        int idRevista;
        DateTime dataEmprestimo;
        DateTime dataDevolucao;
        bool emprestimoAberto;
        bool posicaoPreenchida;
        public Emprestimo() { }
        public Emprestimo(int id, int idAmigo, int idRevista, DateTime dataEmprestimo, DateTime dataDevolucao, bool emprestimoAberto, bool posicaoPreenchida)
        {
            this.ID = id;
            this.idAmigo = idAmigo;
            this.idRevista = idRevista;
            this.dataEmprestimo = dataEmprestimo;
            this.dataDevolucao = dataDevolucao;
            this.emprestimoAberto = emprestimoAberto;
            this.posicaoPreenchida = posicaoPreenchida;
        }
        public void Listar(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            Console.WriteLine("\n *Listagem*");
            ImprimeEmprestimos(emprestimos, amigos, revistas);

            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Cadastrar(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            bool sairMetodo = false;
            Emprestimo emprestimoCadastro = new Emprestimo();

            Console.WriteLine("\n *Cadastro*");

            Console.WriteLine("\nListagem de amigos");
            Pessoa.ImprimirPessoas(amigos);
            if ((emprestimoCadastro.ID = PosicaoParaCadastro(emprestimos)) == -1)
            {
                Console.WriteLine("Base de dados está cheia, contate o administrador");
                return;
            }

            inputDados(ref sairMetodo, ref emprestimoCadastro, ref emprestimos, ref revistas, ref amigos, ref caixas, false);
            
            if (sairMetodo == true)
                return;

            emprestimoCadastro.emprestimoAberto = true;
            emprestimoCadastro.posicaoPreenchida = true;
            emprestimos[emprestimoCadastro.ID] = emprestimoCadastro;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Editar(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            bool sairMetodo = false;
            Emprestimo emprestimoEdicao = new Emprestimo();

            Console.WriteLine("\n *Edição*");
            Console.WriteLine("Listagem de Emprestimos cadastrados");
            ImprimeEmprestimos(emprestimos, amigos, revistas);

            while (true)
            {
                Console.Write("Pressione enter para voltar ao menu ou informe o ID que deseja alterar: ");
                string lerTela = Console.ReadLine();
                
                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && ExisteNoArray(emprestimos, idEdicao) == true)
                {
                    emprestimoEdicao.ID = idEdicao;
                    break;
                }
                else if (lerTela == "")
                {
                    Console.Clear();
                    sairMetodo = true;
                    return;
                }
                else
                    Console.WriteLine("ID não encontrado, informe novamente.");
            }
            if (sairMetodo == true)
                return;

            Console.WriteLine("\nPressione enter para manter a informação anterior ou informe o novo atributo");
            
            Pessoa.ImprimirPessoas(amigos);
            inputDados(ref sairMetodo, ref emprestimoEdicao, ref emprestimos, ref revistas, ref amigos, ref caixas, true);

            emprestimoEdicao.posicaoPreenchida = true;
            emprestimoEdicao.emprestimoAberto = true;
            emprestimos[emprestimoEdicao.ID] = emprestimoEdicao;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Excluir(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            bool sairMetodo = false;
            Emprestimo emprestimoExclusao = new Emprestimo();

            Console.WriteLine("\n *Exclusão*");
            Console.WriteLine("Listagem de Emprestimos cadastrados");
            ImprimeEmprestimos(emprestimos, amigos, revistas);

            while (true)
            {
                Console.Write("Pressione enter para voltar ao menu ou informe o ID que deseja alterar: ");
                string lerTela = Console.ReadLine();

                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && ExisteNoArray(emprestimos, idEdicao) == true)
                {
                    emprestimoExclusao.ID = idEdicao;
                    break;
                }
                else if (lerTela == "")
                {
                    Console.Clear();
                    sairMetodo = true;
                    return;
                }
                else
                    Console.WriteLine("ID não encontrado, informe novamente.");
            }
            if (sairMetodo == true)
                return;

            
            emprestimoExclusao.idAmigo = default;
            emprestimoExclusao.idRevista = default;
            emprestimoExclusao.dataEmprestimo = default;
            emprestimoExclusao.dataDevolucao = default;
            emprestimoExclusao.emprestimoAberto = false;
            emprestimoExclusao.posicaoPreenchida = false;
            emprestimos[emprestimoExclusao.ID] = emprestimoExclusao;

            Console.Clear();
            Console.WriteLine("Empréstimo excluído com sucesso!");
        }
        public void Fechar(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            bool sairMetodo = false;
            Emprestimo emprestimoExclusao = new Emprestimo();

            Console.WriteLine("\n *Encerrar empréstimo*");
            Console.WriteLine("Listagem de Emprestimos cadastrados");
            ImprimeEmprestimos(emprestimos, amigos, revistas);

            while (true)
            {
                Console.Write("Pressione enter para voltar ao menu ou informe o ID que deseja finalizar o empréstimo: ");
                string lerTela = Console.ReadLine();

                bool conversaoRealizada = int.TryParse(lerTela, out int idEdicao);
                if (conversaoRealizada == true && ExisteNoArray(emprestimos, idEdicao) == true)
                {
                    emprestimoExclusao.ID = idEdicao;
                    break;
                }
                else if (lerTela == "")
                {
                    Console.Clear();
                    sairMetodo = true;
                    return;
                }
                else
                    Console.WriteLine("ID não encontrado, informe novamente.");
            }
            if (sairMetodo == true)
                return;


            emprestimos[emprestimoExclusao.ID].emprestimoAberto = false; ;

            Console.Clear();
            Console.WriteLine("Empréstimo encerrado com sucesso!");
        }
        public void Diario(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            Console.WriteLine("\n *Empréstimos hoje*");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].posicaoPreenchida == true)
                {
                    if(DateTime.Now.ToString("dd/MM/yyyy") == emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy"))
                        Console.WriteLine($"-ID: {emprestimos[i].ID} | Amigo: {amigos[emprestimos[i].idAmigo].nome} | Revista edição: {revistas[emprestimos[i].idRevista].numeroEdicao} | Data emprestimo: {emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy")} | Data devolução: {emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy")} ");
                }
            }
            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Mensal(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            Console.WriteLine("\n *Empréstimos Mensal*");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].posicaoPreenchida == true)
                {
                    if (DateTime.Now.ToString("MM") == emprestimos[i].dataEmprestimo.ToString("MM"))
                        Console.WriteLine($"-ID: {emprestimos[i].ID} | Amigo: {amigos[emprestimos[i].idAmigo].nome} | Revista edição: {revistas[emprestimos[i].idRevista].numeroEdicao} | Data emprestimo: {emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy")} | Data devolução: {emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy")} ");
                }
            }
            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Abertos(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas, Caixa[] caixas)
        {
            Console.WriteLine("\n *Empréstimos em aberto*");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].posicaoPreenchida == true && emprestimos[i].emprestimoAberto == true)
                {
                    Console.WriteLine($"-ID: {emprestimos[i].ID} | Amigo: {amigos[emprestimos[i].idAmigo].nome} | Revista edição: {revistas[emprestimos[i].idRevista].numeroEdicao} | Data emprestimo: {emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy")} | Data devolução: {emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy")} ");
                }
            }
            Console.WriteLine("Tecle enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        
        #region Métodos auxiliares
        private void inputDados(ref bool sairMetodo, ref Emprestimo emprestimoCadastro, ref Emprestimo[] emprestimos, ref Revista[] revistas, ref Pessoa[] amigos, ref Caixa[] caixas, bool ehEdicao)
        {
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
            if (sairMetodo == true && ehEdicao == false)
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
            if (sairMetodo == true && ehEdicao == false)
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
                    emprestimoCadastro.dataEmprestimo = lerTela == "" ? emprestimos[emprestimoCadastro.ID].dataEmprestimo : dataEmprestimo;
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto.");
            }
            if (sairMetodo == true && ehEdicao == false)
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
                    emprestimoCadastro.dataDevolucao = lerTela == "" ? emprestimos[emprestimoCadastro.ID].dataDevolucao : dataDelovucao;
                    sairMetodo = true;
                    break;
                }
                else
                    Console.WriteLine("Data informada com formato incorreto ou menor que a data do empréstimo.");
            }
            if (sairMetodo == true && ehEdicao == false)
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
        private static void ImprimeEmprestimos(Emprestimo[] emprestimos, Pessoa[] amigos, Revista[] revistas)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null && emprestimos[i].posicaoPreenchida == true)
                {
                    Console.WriteLine($"-ID: {emprestimos[i].ID} | Amigo: {amigos[emprestimos[i].idAmigo].nome} | Revista edição: {revistas[emprestimos[i].idRevista].numeroEdicao} | Data emprestimo: {emprestimos[i].dataEmprestimo.ToString("dd/MM/yyyy")} | Data devolução: {emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy")} ");
                }
            }
        }
        private static bool ExisteNoArray(Emprestimo[] emprestimos, int idEdicao)
        {
            bool existe = false;

            if (emprestimos[idEdicao] != null && emprestimos[idEdicao].posicaoPreenchida == true)
                existe = true;

            return existe;
        }
        public static void PopularArray(Emprestimo[] emprestimos)
        {
            //int idAmigo, int idRevista, DateTime dataEmprestimo, DateTime dataDevolucao, bool posicaoPreenchida)
            DateTime data1 = new DateTime(2022, 03, 10);
            DateTime data2 = new DateTime(2022, 03, 20);
            DateTime data3 = new DateTime(2022, 03, 16);
            Emprestimo emp1 = new Emprestimo(0, 0, 0, data1, data2, true, true);
            Emprestimo emp2 = new Emprestimo(1, 1, 1, data1, data2, true, true);
            Emprestimo emp3 = new Emprestimo(2, 0, 1, data3, data3, true, true);
            emprestimos[0] = emp1;
            emprestimos[1] = emp2;
            emprestimos[2] = emp3;

        }
        #endregion
    }
}
