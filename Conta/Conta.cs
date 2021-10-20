using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saque efetuado no valor de: R${0}", valorSaque);
            Console.WriteLine("Saldo atual da conta de: {0} é: R${1}.", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Deposito efetuado no valor de: R${0}", valorDeposito);
            Console.WriteLine("Saldo atual da conta de: {0} é: R${1}.", this.Nome, this.Saldo);
        }

        public void Trasferir(double valorTrasferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTrasferencia))
            {
                contaDestino.Depositar(valorTrasferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "|Tipo Conta: " + this.TipoConta + "|";
            retorno += "Nome: " + this.Nome + "|";
            retorno += "Saldo: R$" + this.Saldo + "|";
            retorno += "Credito: R$" + this.Credito + "|";
            return retorno;
        }
    }
}