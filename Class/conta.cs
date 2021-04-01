using System;

namespace ProjetoBanco
{
    public class Conta
    {
   

        // atributos

        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }






        // metodo construtor 
             public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }
  
        //metodo sacar 

         public bool Sacar (double valorSaque) 
         {
             if( Saldo - valorSaque < this.Credito *-1)
             {
                Console.WriteLine("Valor insuficiente na conta para realizar esta operação");
                return false;
             }
                else 
                    this.Saldo = this.Saldo - valorSaque ;
                     Console.WriteLine("Valor de Saldo é  {0}", this.Saldo );

                    return true;
         }

         public void Depositar (double valorDeposito)
         {
            this.Saldo = this.Saldo + valorDeposito ;
            Console.WriteLine("Valor de Saldo é  {0}", this.Saldo );

         }

         public void Transferir (double valorTransf , Conta contaDestino)
         {
           if(this.Sacar(valorTransf))
                {
                    contaDestino.Depositar(valorTransf);
                }


         }

        public override string ToString()
        {
            string retorno =" ";

            retorno += "TipoConta : " + this.TipoConta + " | " ; 
            retorno += "Nome : " + this.Nome + " | " ; 
            retorno += "Saldo : " + this.Saldo  + " | " ; 
            retorno += "Credito : " + this.Credito ; 
            return retorno;
            

        }



    }
}