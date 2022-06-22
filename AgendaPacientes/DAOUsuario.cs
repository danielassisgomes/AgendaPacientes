using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgendaPacientes
{
    class DAOUsuario
    {//metodos login. cadastrar, atualizar, excluir, consultar, logar
        public MySqlConnection conexaoUsuario;
        public int codigoUsuario;
        public string nome;
        public string usuario;
        public string senha;
        public string dados;
        public string comando;
        public string resultado;
        //variaveis de operações logicas
        public int a;
        public int contador;
        //declarando os vetores
        public int[] codigoUsuarioVet;
        public string[] nomeVet;
        public string[] usuarioVet;
        public string[] senhaVet;



        public DAOUsuario()
        {
            conexaoUsuario = new MySqlConnection("" +
             "server=localhost;DataBase=agenda;Uid=root;password=");
            try
            {
                conexaoUsuario.Open();//tentando conectar com o banco de dados
                Console.WriteLine("Conecctado com sucesso.");
                Console.ReadLine();//manter o prompt aberto
            }
            catch(Exception erro)
            {
                Console.WriteLine("Algo deu errado\n\n " + erro);//mostra o erro em tela
                conexaoUsuario.Close();//fecha a conexão com o banco de dados
                Console.ReadLine();
            }
        }//fim do método construtor

        //desenvolver metodos gets e sets
        public void Inserir(string nome, string usuario, string senha)
        {
            try
            {
                //preparar os dados para inserir no banco
                dados = "('','" + nome + "','" + usuario + "','" + senha + "')";
                comando = "Insert into agenda(codigoUsuario, nome, usuario, senha) values " + dados;

                //Executar o comando na base de dados
                MySqlCommand sql = new MySqlCommand(comando, conexaoUsuario);
                resultado = "" + sql.ExecuteNonQuery();
                if (resultado == "1")
                {
                    MessageBox.Show("Cadastrado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Não cadastrado.");
                }//fim do if/else
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado\n\n " + erro);
            }
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from agenda";//comando para coletar todos os dados do banco

            //instanciando os vetores
            codigoUsuarioVet = new int[100];
            nomeVet = new string[100];
            usuarioVet = new string[100];
            senhaVet = new string[100];

            //preencher os vetores previamente criados, ou seja dar valor incial à eles
            for (a = 0; a < 100; a++)
            {
                codigoUsuarioVet[a] = 0;
                nomeVet[a]          = "";
                usuarioVet[a]       = "";
                senhaVet[a]         = "";
            }//fim do for

            //realizar os comandos de consulta ao banco de dados
            MySqlCommand coletar = new MySqlCommand(query, conexaoUsuario);
            //ler os dados de acordo com o que está no banco
            MySqlDataReader leitura = coletar.ExecuteReader();//variável leitura faz uma consulta ao banco

            a = 0;//declaração do contador 0 para while
            contador = 0;//declaração do contador 0 para while
            contarCodigo = 0;//instanciando o contador para o codigo
                             //preencher vetores com dados do banco de dados
            while(leitura.Read())//enquanto leitura for verdadeiro executa while
            {
                codigoUsuarioVet[a] = Convert.ToInt32(leitura["codigoUsuario"]);
                nomeVet[a] = leitura["nome"] + "";//concateno com aspas para converter para string
                usuarioVet[a] = leitura["usuario"] + "";
                senhaVet[a] = leitura["senha"] + "";
                contarCodigo = contador;//armazenando a ultima posição do contador
                a++;//contador sai da posicao 0 e vai se incrementando
                contador++;//contar os loops do while
            }//fim do while

            leitura.Close();//fechar conexao e leitura do banco de dados
        }//fim do preencher vetor


    }//fim da classe
}//fim do projeto
