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
        public int pessoaID;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;
        public Pessoa(){}
        public Pessoa(int id, string nome, string nomeResponsavel, string telefone, string endereco)
        {
            this.pessoaID = id;
            this.nome = nome;
            this.nomeResponsavel = nomeResponsavel;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        #region Métodos principais
        public void Cadastrar(ref Pessoa[] pessoas)
        {
            string nome, nomeResponsavel, telefone, endereco;
            int posicao = PosicaoInsercaoNoArray(pessoas);
            InputDados(out nome, out nomeResponsavel, out telefone, out endereco);

            Pessoa pessoaCadastro = new Pessoa(posicao, nome, nomeResponsavel, telefone, endereco);
            pessoas[posicao] = pessoaCadastro;

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
            string lerDados, nome, nomeResponsavel, telefone, endereco;
            int id;
            bool conversaoRealizada = false;

            Console.WriteLine("\nListagem de Amigos cadastrados.");
            ImprimirPessoas(pessoas);
            Console.Write("\nInforme o ID do amigo que deseja alterar: ");
            lerDados = Console.ReadLine();
            conversaoRealizada = int.TryParse(lerDados, out id);
            if (conversaoRealizada == true && ExisteNoArray(pessoas, id) == true)
            {
                Console.WriteLine("\nCaso deseje manter informação anterior, mantenha o campo vazio.");
                Console.Write("Pessoa em Edição | ");
                ImprimirPessoa(pessoas, id);
                InputDados(out nome, out nomeResponsavel, out telefone, out endereco);
                nome = nome == "" ? pessoas[id].nome : nome;
                nomeResponsavel = nomeResponsavel == "" ? pessoas[id].nomeResponsavel : nomeResponsavel;
                telefone = telefone == "" ? pessoas[id].telefone : telefone;
                endereco = endereco == "" ? pessoas[id].endereco : endereco;

                Pessoa pessoaEditar = new Pessoa(id, nome, nomeResponsavel, telefone, endereco);
                pessoas[id] = pessoaEditar;
                Console.Clear();
                Console.WriteLine("Usuário editado com sucesso!");
            }
            else
            {
                Console.WriteLine("Ocrreu um erro na edição, pressione enter para voltar ao menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Excluir(Pessoa[] pessoas)
        {
            string lerDados;
            int id;
            bool conversaoRealizada = false;

            Console.WriteLine("\nListagem de Amigos cadastrados.");
            ImprimirPessoas(pessoas);
            Console.Write("\nInforme o ID que deseja alterar: ");
            lerDados = Console.ReadLine();
            conversaoRealizada = int.TryParse(lerDados, out id);
            if (conversaoRealizada == true && ExisteNoArray(pessoas, id) == true)
            {
                Pessoa pessoaExcluir = new Pessoa(default, "", "", "", "");
                pessoas[id] = pessoaExcluir;
                Console.Clear();
                Console.WriteLine("Usuário excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário excluído com sucesso!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        #endregion

        #region Métodos auxiliares
        private void ImprimirPessoas(Pessoa[] pessoas)
        {
            foreach (var p in pessoas)
            {
                if (p != null && p.nome != "")
                    Console.WriteLine($"ID: {p.pessoaID} | Nome: {p.nome} | Responsável: {p.nomeResponsavel} | Telefone: {p.telefone} | Endereço: {p.endereco}");
            }
        }
        private void ImprimirPessoa(Pessoa[] pessoas, int id)
        {
            Console.WriteLine($"ID: {pessoas[id].pessoaID} | Nome: {pessoas[id].nome} | Responsável: {pessoas[id].nomeResponsavel} | Telefone: {pessoas[id].telefone} | Endereço: {pessoas[id].endereco}");
        }
        private static void InputDados(out string nome, out string nomeResponsavel, out string telefone, out string endereco)
        {
            Console.Write("Informe o nome do amigo: ");
            nome = Console.ReadLine();
            Console.Write("Informe o responsável do amigo: ");
            nomeResponsavel = Console.ReadLine();
            Console.Write("Informe o telefone do amigo: ");
            telefone = Console.ReadLine();
            Console.Write("Informe o endereço do amigo: ");
            endereco = Console.ReadLine();
        }
        private int PosicaoInsercaoNoArray(Pessoa[] pessoas)
        {
            int posicao = -1;

            for (int i = 0; i < pessoas.Length; i++)
            {
                if (pessoas[i] == null || pessoas[i].nome == "")
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
        private bool ExisteNoArray(Pessoa[] pessoas, int id)
        {
            bool existeNoArray = false;

            foreach (var pessoa in pessoas)
            {
                if(pessoa.pessoaID == id)
                {
                    existeNoArray = true;
                    break;
                }
            }
            return existeNoArray;
        }
        public static void PopularPessoas(ref Pessoa[] pessoas)
        {
            Pessoa p1 = new Pessoa(0, "Marcos", "Adriana", "123", "rua 1");
            Pessoa p2 = new Pessoa(1, "Patricia", "Andreia", "321", "rua 2");
            pessoas[0] = p1;
            pessoas[1] = p2;
        }
        #endregion
    }
}
