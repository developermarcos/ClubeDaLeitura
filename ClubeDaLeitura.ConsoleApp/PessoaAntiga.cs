using System;

namespace ClubeDaLeitura.ConsoleApp
{
    public enum Amigos
    {
        Listar = 1,
        Cadastrar = 2,
        Editar = 3,
        Excluir = 4
    }
    internal class PessoaAntiga
    {
        public int ID;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public PessoaAntiga(){}
        public PessoaAntiga(int id, string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.ID = id;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        #region Métodos principais
        public void Cadastrar(ref PessoaAntiga[] pessoas)
        {
            Console.WriteLine("\n*Cadastrar*");
            PessoaAntiga pessoaCadastro = new PessoaAntiga();
            int arrayCheio = -1;
            bool sairMetodo = false;

            pessoaCadastro.ID = PosicaoInsercaoNoArray(pessoas);
            if (pessoaCadastro.ID == arrayCheio)
            {
                Console.WriteLine("Base de dados está cheia, contate o administrador do sistema");
                return;
            }
            Console.WriteLine("Pressione enter para voltar ao menu ou informe os campos para cadastro.");
            InputDados(ref pessoaCadastro, ref sairMetodo, false);
            if (sairMetodo == true)
            {
                Console.Clear();
                return;
            }

            pessoas[pessoaCadastro.ID] = pessoaCadastro;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Listar(PessoaAntiga[] pessoas)
        {
            Console.WriteLine("\n*Listar*");
            ImprimirPessoas(pessoas);
            Console.Write("\nPressine enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Editar(PessoaAntiga[] pessoas)
        {
            PessoaAntiga pessoaEdicao = new PessoaAntiga();
            bool sairMetodo = false;

            Console.WriteLine("\n*Editar*");
            Console.WriteLine("Listagem de Amigos cadastrados.");
            ImprimirPessoas(pessoas);
            Console.Write("\nPressione enter para sair ou informe o ID do amigo que deseja alterar: ");
            string lerDados = Console.ReadLine();
            if (lerDados == "")
            {
                Console.Clear();
                return;
            }

            bool conversaoRealizada = int.TryParse(lerDados, out int idEdicao);
            if (conversaoRealizada == true && (ExisteNoArray(pessoas, idEdicao) == true))
            {
                pessoaEdicao.ID = idEdicao;
                Console.WriteLine("\nCaso deseje manter informação anterior, mantenha o campo vazio e pressione enter.");
                Console.Write("Pessoa em Edição | ");
                ImprimirPessoa(pessoas, pessoaEdicao.ID);
                InputDados(ref pessoaEdicao, ref sairMetodo, true);

                pessoaEdicao.nome = pessoaEdicao.nome == "" ? pessoas[pessoaEdicao.ID].nome : pessoaEdicao.nome;
                pessoaEdicao.nomeResponsavel = pessoaEdicao.nomeResponsavel == "" ? pessoas[pessoaEdicao.ID].nomeResponsavel : pessoaEdicao.nomeResponsavel;
                pessoaEdicao.telefone = pessoaEdicao.telefone == "" ? pessoas[pessoaEdicao.ID].telefone : pessoaEdicao.telefone;
                pessoaEdicao.endereco = pessoaEdicao.endereco == "" ? pessoas[pessoaEdicao.ID].endereco : pessoaEdicao.endereco;

                pessoas[pessoaEdicao.ID] = pessoaEdicao;

                Console.Clear();
                Console.WriteLine("Usuário editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Ocorreu um erro na edição, pressione enter para voltar ao menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Excluir(PessoaAntiga[] pessoas)
        {
            Console.WriteLine("\n*Excluir*");
            Console.WriteLine("Listagem de Amigos cadastrados.");
            ImprimirPessoas(pessoas);
            Console.Write("\nPressione enter para voltar ou informe o ID que deseja excluir: ");
            string lerDados = Console.ReadLine();
            bool conversaoRealizada = int.TryParse(lerDados, out int id);
            if (conversaoRealizada == true && ExisteNoArray(pessoas, id) == true)
            {
                pessoas[id] = null;
                Console.Clear();
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            else if (lerDados == "")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.WriteLine("Nenhum usuário excluído.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #endregion

        #region Métodos auxiliares
        public static void ImprimirPessoas(PessoaAntiga[] pessoas)
        {
            foreach (var p in pessoas)
            {
                if (p != null)
                    Console.WriteLine($"ID: {p.ID} | Nome: {p.nome} | Responsável: {p.nomeResponsavel} | Telefone: {p.telefone} | Endereço: {p.endereco}");
            }
        }
        private void ImprimirPessoa(PessoaAntiga[] pessoas, int id)
        {
            Console.WriteLine($"ID: {pessoas[id].ID} | Nome: {pessoas[id].nome} | Responsável: {pessoas[id].nomeResponsavel} | Telefone: {pessoas[id].telefone} | Endereço: {pessoas[id].endereco}");
        }
        private static void InputDados(ref PessoaAntiga pessoaCadastroEdicao, ref bool sairMetodo, bool edicaoPessoa)
        {
            Console.Write("Informe o nome: ");
            pessoaCadastroEdicao.nome = Console.ReadLine();
            if (pessoaCadastroEdicao.nome == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o responsável: ");
            pessoaCadastroEdicao.nomeResponsavel = Console.ReadLine();
            if (pessoaCadastroEdicao.nomeResponsavel == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o telefone: ");
            pessoaCadastroEdicao.telefone = Console.ReadLine();
            if (pessoaCadastroEdicao.telefone == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
            Console.Write("Informe o endereço: ");
            pessoaCadastroEdicao.endereco = Console.ReadLine();
            if (pessoaCadastroEdicao.endereco == "" && edicaoPessoa == false)
            {
                sairMetodo = true;
                return;
            }
        }
        private int PosicaoInsercaoNoArray(PessoaAntiga[] pessoas)
        {
            int posicao = -1;// -1 em caso de array cheio

            for (int i = 0; i < pessoas.Length; i++)
            {
                if (pessoas[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static bool ExisteNoArray(PessoaAntiga[] pessoas, int id)
        {
            bool existeNoArray = false;

            if (pessoas[id] != null)
                existeNoArray = true;

            return existeNoArray;
        }
        public static void PopularPessoas(ref PessoaAntiga[] pessoas)
        {
            PessoaAntiga p1 = new PessoaAntiga(0, "Marcos", "Adriana", "123", "rua 1");
            PessoaAntiga p2 = new PessoaAntiga(1, "Patricia", "Andreia", "321", "rua 2");
            pessoas[0] = p1;
            pessoas[1] = p2;
        }
        #endregion
    }
}
