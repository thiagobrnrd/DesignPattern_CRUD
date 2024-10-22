using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia_da_Tarefa
{
    public abstract class TemplateMethod
    {
        public void run(string op) 
        {
            limparTela(); 
            executarAcao(op);
        }
        private void limparTela()
        {
            Console.Clear();
        }
        protected abstract string executarAcao(string x);
    }
}
