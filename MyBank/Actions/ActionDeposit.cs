using MyBank.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Actions
{
    internal class ActionDeposit : Action
    {
        public void run()
        {
            Console.WriteLine("======DEPOSITO=====");
            Console.WriteLine("Digite seu codigo de usuario: ");


            string s_cod = Console.ReadLine();

            int cod = int.Parse(s_cod ?? "0");

            if (cod == 0)
            {
                throw new Exception("Codigo invalido");
            }
            bool flag = false;
            MyBankContext contexto = new MyBankContext();

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

            Console.WriteLine("Digite o valor que deseja depositar");
            string s_value = Console.ReadLine();

            float value = float.Parse(s_value ?? "0");

            if (value < 0)
            {
                throw new Exception("Valor inválido");
            }
            float saldo = 0;

            float valorAtualizado = contexto.Account.Find(cod).Balance + value;
            contexto.Account.Find(cod).Balance = valorAtualizado;

        }
    }
}
