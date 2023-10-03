using MyBank.EF.Context;
using MyBank.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Actions
{
    internal class AciontAccountIn : Action
    {

        public void run()
        {
            Console.WriteLine("===========CRIAÇÂO DE CONTAS==============");
            Console.WriteLine("Você já esta cadastrado como cliente no nosso sistema?");
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÂO");
            string? s_op = Console.ReadLine();
            int op = int.Parse(s_op ?? "0");

            if (op == 2)
            {
                ActionInsert CadastraCliente = new ActionInsert();
                CadastraCliente.run();
            }

            Console.WriteLine("Digite o seu codigo de usuario para criar uma conta: ");
            string? s_cod = Console.ReadLine();
            int cod = int.Parse(s_cod ?? "0");

            if(cod == 0)
            {
                Console.WriteLine("Codigo inválido");
            }
            else
            {
                MyBankContext context = new MyBankContext();
                bool flag = false;
                foreach(var c in context.Client )
                {
                    if(c.Id == cod)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    throw new Exception("Codigo de Usuario não encontrado");
                }
                Console.WriteLine("Digite qual será o numero da sua conta: ");
                string? s_n = Console.ReadLine();
                int n = int.Parse(s_n ?? "0");

                ActionextractIn CriaExtrato = new ActionextractIn();
                CriaExtrato.run();
                int Id_Extrato = CriaExtrato.GetId();
                decimal balance_DECIMAL = 100;
                context.Account.Add(new EF.Models.Account {Balance = balance_DECIMAL, Id = n, User_Id = cod, Extract_Id = Id_Extrato});
                context.SaveChanges();
            }
        }
    }
}
