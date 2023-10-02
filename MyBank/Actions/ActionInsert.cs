using MyBank.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Actions
{
    internal class ActionInsert : Action
    {
        public void run()
        {
            Console.WriteLine("--------CADASTRO DE CLIENTES---------");
            Console.WriteLine("Digite seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite sua senha: ");
            string senha = Console.ReadLine();
            Console.WriteLine("Escolha qual seu será seu codigo de acesso ");
            string? id_string = Console.ReadLine();
            int cod = int.Parse(id_string ?? "0");
            Console.WriteLine("Digite seu email ");
            string? email = Console.ReadLine();

            if ( senha.Length < 1 || nome.Length < 1 )
            {
                throw new Exception("Valores inválidos");
            }

            using var contexto = new MyBankContext();
            contexto.Client.Add(new EF.Models.Client { Id = cod, Name = nome , Email = email, Password = senha});

            contexto.SaveChanges();

            Console.WriteLine("Cliente cadastrado com sucesso");
        }
    }
}
