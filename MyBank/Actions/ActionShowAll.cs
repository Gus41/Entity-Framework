using MyBank.EF.Context;
using System;
using System.Linq;

namespace MyBank.Actions
{
    internal class ActionShowAll : Action
    {
        public void run()
        {
            using (var contexto = new MyBankContext())
            {
                Console.WriteLine("--------------CLIENTES----------");
                foreach (var c in contexto.Client)
                {
                    Console.WriteLine("====================================");
                    Console.WriteLine("Nome: " + c.Name);
                    Console.WriteLine("Identificador: " + c.Id);
                    Console.WriteLine("Email: " + c.Email);
                    Console.WriteLine("Senha: " + c.Password);
                    Console.WriteLine("--------------------Contas do Cliente");
                    showAccounts(c.Id);
                    
                }
            }
        }
        public void showAccounts(int id_user)
        {
            using (var context = new MyBankContext())
            {
                bool hasAccount = false;
                foreach (var a in context.Account.Where(x => x.User_Id == id_user))
                {
                    Console.WriteLine("ID: " + a.Id);
                    Console.WriteLine("Saldo: " + a.Balance);
                    Console.WriteLine("ID do usuário: " + a.User_Id);
                    hasAccount = true;  
                }
                if (!hasAccount)
                {
                    Console.WriteLine("Cliente não possui contas no nosso sistema");
                }
            }
        }
    }
}
