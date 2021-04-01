using System;
using System.Collections.Generic;

namespace ProjetoBanco
{
    class Program
    {
        
    static List<Conta> listasContas = new List<Conta>();
        static void Main(string[] args)
        {
           
            string escolha  = opUsuario();
            while( escolha != "X")
            {
                    switch (escolha)

                    {
                     case "1":


                     // Criar Conta
                      Console.WriteLine();
                      Console.WriteLine("Opção escolhida *1*");

                           NovaConta();
                
                        break;

                    case "2":
                      Console.WriteLine();
                      Console.WriteLine("Opção escolhida *2*");

                      if (listasContas.Count != 0)
                      {
                      NovoDeposito();
                      } else Console.WriteLine("Não existe conta cadastrada para realizar um deposito");
                       break;

                    case "3":
                        Console.WriteLine();
                        Console.WriteLine("Opção escolhida *3*");
                        
                        if (listasContas.Count !=0)
                        {
                        NovoSaque();
                        }else Console.WriteLine("Não existe conta cadastrada para realizar um saque");
                      
                        break;

                    case "4":
                       Console.WriteLine();
                       Console.WriteLine("Opção escolhida *4*");
                       if (listasContas.Count >= 2)
                       {
                        NovaTransferencia();
                       }else Console.WriteLine("Não existem contas suficientes para realizar uma transferência");

                        break;
                    case "5":
                        //Listar Contas
                        Console.WriteLine();
                        Console.WriteLine("Opção escolhida *5*");
                        if(listasContas.Count != 0)
                        {
                            ListarContas();
                        }else Console.WriteLine("Não existe contas para serem exibidas");

                      
                    break;
                    
                    default :
                       
                        Console.WriteLine("Opção escolhida não existe");
                      
                        Console.WriteLine("");
                       
                        
                        break;
               
            }
                 Console.WriteLine();
                 Console.WriteLine ("**********************************");
                 Console.WriteLine ("Informe novamante a opção desejada");
                 escolha = opUsuario();
                     

            }

               Console.WriteLine("Obrigado por utilizar nossos serviços");


        }

     

        private static string opUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Bem vindo ao Banco da DIO");
            Console.WriteLine("");
            Console.WriteLine("Digite 1 para criar uma Conta");
            Console.WriteLine("Digite 2 para Depósito");
            Console.WriteLine("Digite 3 para Saque ");
            Console.WriteLine("Digite 4 para Transferência");
            Console.WriteLine("Digite 5 para listar as contas");
            
            Console.WriteLine("Digite X para sair");
            Console.WriteLine();
            string opcao = Console.ReadLine().ToUpper();
            return opcao;
        }

        // Opção 1 - INSERIR CONTA --------------------------------
        private static void NovaConta()
        {
       

                     
           Console.WriteLine("");
           Console.WriteLine("Informe o tipo de conta : ");
           Console.WriteLine("*****************************");
           Console.WriteLine("Digite 1 para Pessoa Fisica");
           Console.WriteLine("Digite 2 para Pessoa Juridica");
           Console.WriteLine("");
           
          int entradaTipoConta = 0;
          int indice = 0;
           
           while(indice == 0)
           {
           try
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    
                    entradaTipoConta = Valida(result);
                    indice = 1;
                    
                } else 
                   {
                     Console.WriteLine("Você informou um nome por extenso");
                     Console.WriteLine("Digite 1 para Pessoa Fisica");
                     Console.WriteLine("Digite 2 para Pessoa Juridica");
                     indice = 0;
                   }


            } catch (Exception )
               {
                   throw new InvalidOperationException("Incorreto, escolha a opção entres as opções informadas anteriormente");
               }

           }

            // nome do titular   
            Console.WriteLine("");
            Console.WriteLine("Informe o Nome do titular da conta");
            string entradaNome = Console.ReadLine();
            Console.WriteLine();

            // valor do saldo
            double entradaSaldo = 0;
            bool condicao = false;
           
            do{
            Console.WriteLine("");
            Console.WriteLine("Informe o valor do saldo inicial");
            
            
            if(double.TryParse(Console.ReadLine(), out double rS))
                {
                   entradaSaldo = rS;
                   condicao = true;
                } else 

                  {
                      Console.WriteLine("Valor informado para Saldo não corresponde a um double");
                      condicao = false;
                  }
             }while (condicao == false);
            
        // valor do Crédito

            condicao = false;  
            double entradaCredito = 0;  

            
            do{
            Console.WriteLine("Informe o valor do crédito");
            
              if(double.TryParse(Console.ReadLine(), out double rC))
                  {
                    entradaCredito = rC;
                    condicao = true;
                  } else 
                  {
                       Console.WriteLine("Valor informado não é double"); 
                  }
                   
               } while(condicao == false);

            // contrutor da Conta   
            Conta tipoConta = new Conta(tipoConta:(TipoConta)entradaTipoConta,
                                         nome: entradaNome, 
                                         saldo: entradaSaldo,
                                         credito:entradaCredito);


            listasContas.Add(tipoConta);

           

        }
        // Opção 2 - NOVO DEPOSITO -------------------------------
        private static void NovoDeposito()
        {
           Console.WriteLine("Informe o numero da conta");
           var indiceconta = int.Parse(Console.ReadLine());
           Console.WriteLine("");
           Console.WriteLine("Informe o valor para deposito");
           var entradaDeposito = double.Parse(Console.ReadLine());

           listasContas[indiceconta].Depositar(entradaDeposito);

        }


         // Opção 3 - NOVO SAQUE --------------------------------
        private static void NovoSaque()
        {
            Console.WriteLine("Informe o numero da conta");
            var indiceconta = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor do saque");
            var valorDoSaque = double.Parse(Console.ReadLine());

            listasContas[indiceconta].Sacar(valorDoSaque);

        }


        // Opção 4 - NOVA TRANSFERENCIA ----------------------------------

         private static void NovaTransferencia()
        {
            Console.WriteLine("Informe o numero da conta de origem ");
            var indiceOrigem = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Informe o numero da conta destino ");
            var indiceDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor da transferência");
            var valorTransf = double.Parse(Console.ReadLine());

            // sacando valor da conta origem
            listasContas[indiceOrigem].Sacar(valorTransf);
            listasContas[indiceDestino].Depositar(valorTransf);
            Console.WriteLine("Transferência realizada com sucesso");
            Console.WriteLine("------------------------------------");
                         
        }


        // Opção 5 -  LISTAR CONTAS ----------------------------------
        private static void ListarContas()
        {
            Console.WriteLine(" Listar contas ");
            Console.WriteLine();

            if (listasContas.Count == 0) 
                {
                    Console.WriteLine("Não existe conta cadastrada");

                } else 
                  {
                    for ( int i = 0 ; i < listasContas.Count ; i++)  
                     {
                        Conta conta = listasContas[i];
                        Console.Write($" Numero da conta - {i} | ");
                        Console.WriteLine(conta);
                      
                     }
                  }
        }
        


        private static int Valida (int op)

        {
            
            if ( op == 1 || op == 2)
              return op;
              else 
              {
              throw new InvalidOperationException("Opção Informada está incorreta");
              }
        }

        
        

    
    }
}
