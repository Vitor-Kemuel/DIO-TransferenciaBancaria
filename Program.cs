using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirContas();
                        break;
                    case "3":
                        Trasferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void Trasferir()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta de origem:");
            int numContaOrigem = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta de destino:");
            int numContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o valor a ser transferido:");
            double valorTrasferencia = double.Parse(Console.ReadLine());

            listContas[numContaOrigem].Trasferir(valorTrasferencia, listContas[numContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta:");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o valor a ser depositado:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[numConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o numero da conta:");
            int numConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[numConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine();
            Console.WriteLine("Listar Contas:");
            Console.WriteLine();

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0}", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirContas()
        {
            Console.WriteLine();
            Console.WriteLine("Inserir nova conta:");
            Console.WriteLine();
            Console.WriteLine("Digite 1 para conta fisica ou 2 para jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Digite o nome do cliente:");
            string entradaNome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Digite o credito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                tipoConta: (TipoConta)entradaTipoConta,
                saldo: entradaSaldo ,
                credito: entradaCredito,
                nome: entradaNome
            );

            listContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO bank a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas;");
            Console.WriteLine("2 - Inserir nova conta;");
            Console.WriteLine("3 - Transferir;");
            Console.WriteLine("4 - Sacar;");
            Console.WriteLine("5 - Depositar;");
            Console.WriteLine("C - Limpar a tela;");
            Console.WriteLine("X - Sair;");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
