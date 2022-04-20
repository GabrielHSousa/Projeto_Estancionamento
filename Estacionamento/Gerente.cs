using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    class Gerente
    {
        Projeto projeto;
        public int opcao;
        public Gerente()
        {
            opcao = 0;
            projeto = new Projeto("Estacionamento");
        }
        //Menu
        public void MostrarMenu()
        {
            Console.WriteLine("Digite seu Login:");
            Console.ReadLine();
            Console.WriteLine("Digite Sua Senha:");
            Console.ReadLine();
            Console.WriteLine("\nLOGIN ACESSADO COM SUCESSO!\n");

            Console.WriteLine("\n\nESCOLHA UMA DAS OPÇÕES ABAIXO: \n\n" +
             "\n1. CADASTRAR CLIENTE"                                   +
             "\n2. CADASTAR VEICULO"                                    +
             "\n3. CADASTAR FUNCIONARIO"                                +
             "\n4. ENTRADA DE VEICULO"                          +
             "\n5. SAÍDA DE VEICULO" +
             "\n6. CADASTRA MENSALISTA"                                 +
             "\n7. ATUALIZAR"                                           +
             "\n8. CONSULTAR TUDO"                                      +
             "\n9. EXCLUIR"                                             +
             "\n0. SAIR");
             opcao = Convert.ToInt32(Console.ReadLine());


        }//FIM MENU

        public void Execultar()
        {
            MostrarMenu();

            switch (opcao)
            {
                //Cadastrar cliente
                case 1:
                        
                    Console.WriteLine("Informe seu Nome:");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Informe Seu CPF");
                    long cpf = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Informe sua Data de Nascimento");
                    DateTime dataDeNascimento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("\nInforme seu telefone");
                    string telefone = Console.ReadLine();
                    Console.WriteLine("\nInforme seu endereço");
                    string endereco = Console.ReadLine();
                    Console.WriteLine("Digite o valor a ser pago?");
                    double valor = Convert.ToInt32(Console.ReadLine());

                    // execultar metodo inserir

                    projeto.inserir(nome, cpf, dataDeNascimento, telefone, endereco,valor);
                    break;

                    Console.ReadLine();// Manter a Tela Aberta!

                //Cadastrar Veiculo
                case 2: 
                        

                    Console.WriteLine("Qual a Placa do Veiculo?");
                    string placa = Console.ReadLine();
                    Console.WriteLine("Qual Modelo do veiculo?");
                    string modelo = Console.ReadLine();
                    Console.WriteLine("Qual Fabricante do Veiculo?");
                    string fabricante = Console.ReadLine();
                    Console.WriteLine("Qual a Cor do Veiculo?");
                    string cor = Console.ReadLine();
                    projeto.inserirVeiculo(placa, modelo, fabricante, cor);
                    break;
                
                //Cadastrar o Funcionario
                case 3:
                    

                    Console.WriteLine("Qual é Cpf do Funcionario?");
                    cpf = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Qual Nome do Funcionario?");
                    string nomeFuncionario = Console.ReadLine();
                    Console.WriteLine("Qual Telefone do Funcionario?");
                    string telefoneFuncionario = Console.ReadLine();
                    Console.WriteLine("Qual a data de Nascimento?");
                    dataDeNascimento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Qual o Endereço do Funcionario?");
                    endereco= Console.ReadLine();
                    Console.WriteLine("Qual a Função do Funcionario?");
                    string funcao = Console.ReadLine();
                    Console.WriteLine("Qual Salario do Funcionario?");
                    double salario = Convert.ToDouble(Console.ReadLine());

                    projeto.inserirFuncionario(cpf, nomeFuncionario, telefoneFuncionario, dataDeNascimento, endereco, funcao ,salario);
                    break;

                //entrada e saida de veiculo
                case 4:
                    Console.WriteLine("Data de entrada do veiculo");
                    DateTime entradaVeiculo = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Hora da entrada do veiculo?");
                    DateTime horaEntrada = Convert.ToDateTime(Console.ReadLine());
                    projeto.inserirEntrada(entradaVeiculo, horaEntrada);
                    break;

                        // saida de veiculo
                case 5:
                    Console.WriteLine("Data da saída");
                    DateTime saidaVeiculo = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Hora da saída do veiculo?");
                    DateTime horaSaida = Convert.ToDateTime(Console.ReadLine());
                    projeto.inserirSaida(saidaVeiculo, horaSaida);
                    break;


                //Cadastrar Mensalista
                case 6:
                    Console.WriteLine("Qual o nome do Mensalista?");
                    nome = Console.ReadLine();
                    Console.WriteLine("Qual CPF do Mensalista?");
                    cpf = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Qual o endereço do Mensalista?");
                    endereco = Console.ReadLine();
                    Console.WriteLine("Qual o telefone do Mensalista?");
                    telefone = Console.ReadLine();
                    Console.WriteLine("Qual a data do pagamento do Mensalista?");
                    DateTime dataDePagamento = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Qual valor do pagamento mensal do Mensalista");
                    double valorMensal = Convert.ToInt32(Console.ReadLine());
                    projeto.inserirMensalista(nome, cpf, endereco, telefone, dataDePagamento, valorMensal);
                    break;


                //Atualizar
                case 7:
                    
                    Console.WriteLine("Qual tabela deseja atualizar?");
                    string campo = Console.ReadLine();
                    Console.WriteLine("Qual o novo dado?");
                    string novoDado = Console.ReadLine();
                    Console.WriteLine("Qual o codigo da pessoa que deseja atualizar?");
                    int cod = Convert.ToInt32(Console.ReadLine());
                    projeto.Atualizar(campo, novoDado, cod);
                    break;


                //Consultar Tudo
                case 8:
                  
                    Console.WriteLine(projeto.ConsultarTudo());
                    break;


                //DELETAR
                case 9:
                    
                    Console.WriteLine("Informe o codigo que deseja deletar");
                    cod = Convert.ToInt32(Console.ReadLine());
                    //USAR O METODO DA CLASSE DAO
                    projeto.Deletar(cod);
                    break;
                
                //saída
                case 0:
                    Console.WriteLine("Obrigado!");
                    break;
                default:
                    Console.WriteLine("Codigo digitado não válido!");
                    break;
            }// End Switch Case.
        } 


     }// fim switch case
}// Fim do método



