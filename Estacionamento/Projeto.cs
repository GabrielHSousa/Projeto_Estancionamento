using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data; //ACESSO PARA REALIZAR CONEXÃO DO BANCO DE DADOS!
using MySql.Data.MySqlClient; //ACESSO PARA REALIZAR COMANDOS DO BANCO DE DADOS!

namespace Estacionamento
{
    class Projeto//data 
    {
        // CRIAÇÃO DE VARIAVEL
        MySqlConnection     conexao         ; 
        public string       dados           ;
        public string       resultado       ;
        public int[]        cod             ;
        public string[]     nome            ;
        public long[]       cpf             ;
        public DateTime[]   dataDeNascimento;
        public string[]     telefone        ;
        public string[]     endereco        ;
        public int          i               ;
        public string       msg             ;
        public int          contador = 0    ;
        public string[]     placa           ;
        public string[]     modelo          ;
        public string[]     cor             ;
        public string[]     fabricante      ;
        public string[]     campo           ;
        public string[]     novoDado        ;
        public string[]     funcao          ;
        public double[]     salario         ;
        public DateTime[]   entradaVeiculo  ;
        public DateTime[]   saidaVeiculo    ;
        public DateTime[]   dataDePagamento ;
        public double[]     valorMensal     ;
        public DateTime[]   horaEntrada     ;
        public DateTime[]   horaSaida       ;
        public double[]     valor           ;

        public Projeto(string nomedoBancodeDados)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + nomedoBancodeDados + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("**** SEJA BEM VINDO AO ESTACIONAMENTO DO BANCO DE DADOS!!! ****");
            }
            catch (Exception e)// Se caso der Algum erro no Banco de dados
            {
                Console.WriteLine("Algo deu Errado Como Assim!!\n\n" + e); // Erro Tecnico
                conexao.Close(); // Fechando a conexão com banco de dados 
            }//Fim da tentativa de conexão com banco de dados
        }//Fim do Contrutor

        //Criar o Método INSERIR
        public void inserir(string nome, long cpf, DateTime dataDeNascimento, string telefone, string endereco, double valor)
        {
            try
            {
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dataDeNascimento.Year + "-" + dataDeNascimento.Month + "-" + dataDeNascimento.Day;
                dados = "('','" + nome + "','" + cpf + "','" + parameter.Value + "','" + telefone + "','" + endereco + "','" + valor + "')";
                resultado = "insert into cliente(codigo,nome, cpf ,dataDeNascimento, telefone, endereco, valor) values" + dados;
                // EXECULTAR O COMANDO RESULTADO NO BANCO DE DADOS
                MySqlCommand sql = new MySqlCommand(resultado, conexao); // VAI ESTRAR NO PROGRAMA NO BANCO DE DADOS "CONEXÃO"
                resultado = "" + sql.ExecuteNonQuery();// EXECULTAR E GUARDAR O " RESULTADO ", CONTRA O ENTER DO BANCO DE DADOS.
                Console.WriteLine(resultado + " Linha(s) Afetada(s) !");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado Aqui!\n\n" + e);
            }//Fim do Catch
        }//Fim do Metodo inserir

        //inicio do preencher vetor

        public void PreencherVetor()
        {
            string query = "select * from cliente";
            cod = new int[100];
            cpf = new long[100];
            nome = new string[100];
            dataDeNascimento = new DateTime[100];
            telefone = new string[100];

            for (i = 0; i < 100; i++)
            {
                cod[i] = 0;
                cpf[i] = 0;
                nome[i] = "";
                dataDeNascimento[i] = new DateTime();
                telefone[i] = "";

            }//fim da repetição

            //criar comando

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Usar comando para ler os dados do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cod[i] = Convert.ToInt32(leitura["codigo"]);
                cpf[i] = Convert.ToInt64(leitura["cpf"]);
                nome[i] = leitura["nome"] + "";
                dataDeNascimento[i] = Convert.ToDateTime(leitura["dataDeNascimento"]);
                telefone[i] = leitura["telefone"] + "";
                i++;
                contador++;

            }//fim do while

            //fechar o dataReader
            leitura.Close();

        }//fim do preencher vetor

        public string ConsultarTudo()
        {
            //PREECHER O VETOR
            PreencherVetor();
            msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\n\ncodigo:" + cod[i] + "Nome: " + nome[i] + ",Telefone" + telefone[i] + ", Endereço:" + endereco[i];
            }//FIM DO FOR
            return msg;

        }//FIM DO CONSULTAR TUDO
        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return nome[i];
                }
            }//FIM  DO FOR
            return "codigo não encotrada!";
        }// FIM DO CONSULTARNOME
        public string ConsultarTelefone(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return telefone[i];
                }
            }//FIM  DO FOR
            return "codigo não encotrada!";
        }// FIM DO CONSULTARTELEFONE
        public string ConsultarEndereco(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return endereco[i];
                }
            }//FIM  DO FOR
            return "codigo não encotrada!";
        }
            public void inserirVeiculo(string placa, string modelo, string fabricante, string cor)
        {
            try
            {
                dados = "('" + placa + "','" + modelo + "','" + fabricante + "','" + cor + "')";
                resultado = "insert into veiculos(placa,modelo,fabricante,cor) values" + dados;
                // EXECULTAR O COMANDO RESULTADO NO BANCO DE DADOS
                MySqlCommand sql = new MySqlCommand(resultado, conexao); // VAI ESTRAR NO PROGRAMA NO BANCO DE DADOS "CONEXÃO"
                resultado = "" + sql.ExecuteNonQuery();// EXECULTAR E GUARDAR O " RESULTADO ", CONTRA O ENTER DO BANCO DE DADOS.
                Console.WriteLine(resultado + " Linha(s) Afetada(s) !");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado Aqui!\n\n" + e);



            }//Fim da classe
        }//Fim do Projeto


        // CADASTRAMENTO DE FUNCIONARIO
        public void inserirFuncionario(long cpf, string nomeFuncionario, string telefoneFuncionario, DateTime dataDeNascimento, string endereco,string funcao, double salario)
        {
            try
            {
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dataDeNascimento.Year + "-" + dataDeNascimento.Month + "-" + dataDeNascimento.Day;
                dados = "('" + cpf + "','" + nomeFuncionario + "','" + telefoneFuncionario + "','" + endereco + "','" + parameter.Value + "', '"+ funcao + "','" + salario + "')";
                resultado = "insert into funcionario(cpf,nomeFuncionario,telefoneFuncionario,endereco,dataDeNascimento,funcao,salario) values" + dados;
                // EXECULTAR O COMANDO RESULTADO NO BANCO DE DADOS
                MySqlCommand sql = new MySqlCommand(resultado, conexao); // VAI ESTRAR NO PROGRAMA NO BANCO DE DADOS "CONEXÃO"
                resultado = "" + sql.ExecuteNonQuery();// EXECULTAR E GUARDAR O " RESULTADO ", CONTRA O ENTER DO BANCO DE DADOS.
                Console.WriteLine(resultado + " Linha(s) Afetada(s) !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado Aqui!\n\n" + e);
            }
        }

        // CADASTRAMENTO De entrada de veiculo
        public void inserirEntrada(DateTime entradaVeiculo, DateTime horaEntrada)
        {
            try
            {
                dados = $"('','{entradaVeiculo.ToString("yyyy-MM-dd")}','{horaEntrada.ToString("HH:mm:ss")}')";
                resultado = "insert into entrada(codigo, dataDeEntrada, horaEntrada) values" + dados;
                // EXECULTAR O COMANDO RESULTADO NO BANCO DE DADOS
                MySqlCommand sql = new MySqlCommand(resultado, conexao); // VAI ESTRAR NO PROGRAMA NO BANCO DE DADOS "CONEXÃO"
                resultado = "" + sql.ExecuteNonQuery();// EXECULTAR E GUARDAR O " RESULTADO ", CONTRA O ENTER DO BANCO DE DADOS.
                Console.WriteLine(resultado + " Linha(s) Afetada(s) !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado Aqui!\n\n" + e);
            }
        }

        // Saida de Veiculo

        public void inserirSaida(DateTime saidaVeiculo, DateTime horaSaida)
        {
            try
            {

                dados = $"('','{saidaVeiculo.ToString("yyyy-MM-dd")}','{horaSaida.ToString("HH:mm:ss")}')";
                resultado = "insert into entrada(codigo, dataDeEntrada, horaEntrada) values" + dados;
                dados = $"('','{saidaVeiculo}','{horaSaida}')";
                resultado = "insert into Saida(codigo,dataDeSaida,horaSaida) values" + dados;
                // EXECULTAR O COMANDO RESULTADO NO BANCO DE DADOS
                MySqlCommand sql = new MySqlCommand(resultado, conexao); // VAI ESTRAR NO PROGRAMA NO BANCO DE DADOS "CONEXÃO"
                resultado = "" + sql.ExecuteNonQuery();// EXECULTAR E GUARDAR O " RESULTADO ", CONTRA O ENTER DO BANCO DE DADOS.
                Console.WriteLine(resultado + " Linha(s) Afetada(s) !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado Aqui!\n\n" + e);
            }
        }

        // CADASTRAMENTO Mensalista
        public void inserirMensalista(string nome, long cpf, string endereco, string telefone, DateTime dataDePagamento, double valorMensal)
        {
            try
            {
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = dataDePagamento.Year + "-" + dataDePagamento.Month + "-" + dataDePagamento.Day;
                dados = "('','" + nome + "','" + cpf + "','" + endereco + "', '" + telefone + "', '" + dataDePagamento + "', '" + valorMensal + "')";
                resultado = "insert into mensalista (codigo,nome,cpf,endereco,telefone,dataDePagamento,valorMensal) values" + dados;    
                // EXECULTAR O COMANDO RESULTADO NO BANCO DE DADOS
                MySqlCommand sql = new MySqlCommand(resultado, conexao); // VAI ESTRAR NO PROGRAMA NO BANCO DE DADOS "CONEXÃO"
                resultado = "" + sql.ExecuteNonQuery();// EXECULTAR E GUARDAR O " RESULTADO ", CONTRA O ENTER DO BANCO DE DADOS.
                Console.WriteLine(resultado + " Linha(s) Afetada(s) !");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado Aqui!\n\n" + e);
            }
        }

        //Atualizar
        public void Atualizar(string campo, string novoDado,int cod)
        {
            try
            {
                resultado = "update cliente set " + campo + " = '" + novoDado + "' where codigo ='" + cod + "'";
                // EXECULTAR O SCRIPT
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com Sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!" + e);
            }
        }//FIM DO ATUALIZAR
        public void Deletar(int cod)
        {
            resultado = "delete from funcionario where codigo = '" + cod + "'";
            // EXECULTAR O COMANDO
            MySqlCommand Sql = new MySqlCommand(resultado, conexao);
            resultado = "" + Sql.ExecuteNonQuery();
            //MENSAGEM
            Console.WriteLine("Dados Excluido com Sucesso!");

        }
    }
}