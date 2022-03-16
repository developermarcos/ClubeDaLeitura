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
    internal class Pessoa
    {
        public int ID;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public bool posicaoPreenchida;
        public Pessoa(){}
        public Pessoa(int id, string nome, string nomeResponsavel, string telefone, string endereco, bool posicaoPreenchida)
        {
            this.ID = id;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
            this.posicaoPreenchida = posicaoPreenchida;
        }

        #region Métodos principais
        public void Cadastrar(ref Pessoa[] pessoas)
        {
            Pessoa pessoaCadastro = new Pessoa();
            int arrayCheio = -1;
            bool sairMetodo = false;

            pessoaCadastro.ID = PosicaoInsercaoNoArray(pessoas);
            if(pessoaCadastro.ID == arrayCheio)
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

            pessoaCadastro.posicaoPreenchida = true;
            pessoas[pessoaCadastro.ID] = pessoaCadastro;

            Console.Clear();
            Console.WriteLine("Cadastro realizado com sucesso!");
        }
        public void Listar(Pessoa[] pessoas)
        {
            ImprimirPessoas(pessoas);
            Console.Write("\nPressine enter para voltar ao menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void Editar(Pessoa[] pessoas)
        {
            Pessoa pessoaEdicao = new Pessoa();
            int arrayCheio = -1;
            bool sairMetodo = false;

            Console.WriteLine("\nListagem de Amigos cadastrados.");
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
        public void Excluir(Pessoa[] pessoas)
        {
            Console.WriteLine("\nListagem de Amigos cadastrados.");
            ImprimirPessoas(pessoas);
            Console.Write("\nInforme o ID que deseja excluir: ");
            string lerDados = Console.ReadLine();
            bool conversaoRealizada = int.TryParse(lerDados, out int id);
            if (conversaoRealizada == true && ExisteNoArray(pessoas, id) == true)
            {
                Pessoa pessoaExcluir = new Pessoa(default, "", "", "", "", false);
                pessoas[id] = pessoaExcluir;
                Console.Clear();
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Nenhum usuário excluído!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #endregion

        #region Métodos auxiliares
        public static void ImprimirPessoas(Pessoa[] pessoas)
        {
            foreach (var p in pessoas)
            {
                if (p != null && p.nome != "")
                    Console.WriteLine($"ID: {p.ID} | Nome: {p.nome} | Responsável: {p.nomeResponsavel} | Telefone: {p.telefone} | Endereço: {p.endereco}");
            }
        }
        private void ImprimirPessoa(Pessoa[] pessoas, int id)
        {
            Console.WriteLine($"ID: {pessoas[id].ID} | Nome: {pessoas[id].nome} | Responsável: {pessoas[id].nomeResponsavel} | Telefone: {pessoas[id].telefone} | Endereço: {pessoas[id].endereco}");
        }
        private static void InputDados(ref Pessoa pessoaCadastroEdicao, ref bool sairMetodo, bool edicaoPessoa)
        {
            Console.Write("Informe o nome: ");
            pessoaCadastroEdicao.nome = Console.ReadLine();
            if(pessoaCadastroEdicao.nome == "" && edicaoPessoa == false)
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
        private int PosicaoInsercaoNoArray(Pessoa[] pessoas)
        {
            int posicao = -1;// -1 em caso de array cheio

            for (int i = 0; i < pessoas.Length; i++)
            {
                if (pessoas[i] == null || pessoas[i].posicaoPreenchida == false)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        public static bool ExisteNoArray(Pessoa[] pessoas, int id)
        {
            bool existeNoArray = false;

            if (pessoas[id] != null && pessoas[id].posicaoPreenchida == true)
                existeNoArray = true;
            
            return existeNoArray;
        }
        public static void PopularPessoas(ref Pessoa[] pessoas)
        {
            Pessoa p1 = new Pessoa(0, "Marcos", "Adriana", "123", "rua 1", true);
            Pessoa p2 = new Pessoa(1, "Patricia", "Andreia", "321", "rua 2", true);
            pessoas[0] = p1;
            pessoas[1] = p2;
        }
        #endregion
    }
}
