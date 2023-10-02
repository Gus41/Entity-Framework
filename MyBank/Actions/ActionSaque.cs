using MyBank.EF.Context;
using MyBank.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Actions
{
    internal class ActionSaque : Action
    {
        public void run()
        {
            MyBankContext contexto = new MyBankContext();

            Console.Write("Digite seu Codigo de Usuario: ");
            string s_cod = Console.ReadLine();

            int cod = int.Parse(s_cod ?? "0");

            if (cod == 0)
            {
                throw new Exception("Codigo invalido");
            }
            bool flag = false;
            foreach (var c in contexto.Client)
            {
                if (c.Id == cod)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                throw new Exception("Cliente não encontrado");
            }
            Console.WriteLine("Digite sua senha de usuario");
            string s_pass = Console.ReadLine();
            flag = false;
            foreach (var c in contexto.Client)
            {
                if (c.Password.Equals(s_pass))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                throw new Exception("Senha incorreta");
            }

            Console.WriteLine("Digite o valor que deseja sacar: ");
            string s_value = Console.ReadLine();
            
            Decimal value = Decimal.Parse(s_value ?? "0");

            if(value < 0)
            {
                throw new Exception("Valor inválido");
            }
            decimal? saldo = 0;
            decimal? valor = 0;
            foreach (var a in contexto.Account)
            {
                if (a.User_Id == cod)
                {
                    valor = a.Balance - value;
                    a.Balance = valor;
                    break;
                }
            }
       

            
            Console.WriteLine(value + " Sacados!");

            contexto.SaveChanges();
            Console.WriteLine("Saldo: "  + valor);
        }
    }
}
