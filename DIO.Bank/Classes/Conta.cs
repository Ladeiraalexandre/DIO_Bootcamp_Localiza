using System;

namespace DIO.Bank
{
    public class Conta
    {
        
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        
        
        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;

            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}.");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}.");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return "Tipo Conta " + this.TipoConta + " | "
                 + "Nome " + this.Nome + " | "
                 + "Saldo " + this.Saldo + " | "
                 + "Crédito " + this.Credito;
        }                

    }
}