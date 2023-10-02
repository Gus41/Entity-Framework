using MyBank.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Actions
{
    internal class ActionextractIn : Action
    {

        protected int id;
        public void run()
        {
            int cont = 1;
            
            MyBankContext context = new MyBankContext();

            cont = context.Extract.Count() + 1;
            
            this.id = cont;
            float value = 100;
            context.Extract.Add(new EF.Models.Extract { Id = cont, Historic = value});
            context.SaveChanges();
        }
        public int GetId()
        {
            return this.id;
        }
    }
}
