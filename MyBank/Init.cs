using MyBank.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank
{
    internal class Init
    {
        public Init() 
        {
            int n = -1;
            while (n != 0)
            {
                n = Menu();

                if (n == 1)
                {
                    ActionInsert InsereCliente = new ActionInsert();
                    InsereCliente.run();
                }
                else if (n == 2)
                {
                   AciontAccountIn CadastraConta = new AciontAccountIn();
                    CadastraConta.run();
                }
                else if (n == 3)
                {
                    ActionSaque Sacque = new ActionSaque();
                    Sacque.run();
                }
                else if (n == 4)
                {

                }
                else if (n == 5)
                {
                    ActionShowAll MostrarTodos = new ActionShowAll();
                    MostrarTodos.run();
                }
                else if (n == 0)
                {
                    Console.WriteLine("Obrigado por utilizar o sistema");
                }
            }

        }
        private int Menu()
        {
            string n;
            //Cadastrar um cliente, cadastrar contas para esse cliente e, por fim, fazer pequenas movimentações em cada uma dessas contas.
            Console.WriteLine("==========BEM VINDO AO MYBANK==========");
            Console.WriteLine("1 - CADASTRAR CLIENTE");
            Console.WriteLine("2 - CADASTRAR CONTA");
            Console.WriteLine("3 - SACAR VALOR DE UMA CONTA");
            Console.WriteLine("4 - DEPOSITAR VALOR EM UMA CONTA");
            Console.WriteLine("5 - LISTAR TODAS AS CONTAS E CLIENTES");
            Console.WriteLine("0 - SAIR");
            Console.WriteLine("=========================================");
            n = Console.ReadLine();
            int a = Int16.Parse(n);
            return a;
        }
    }
}
