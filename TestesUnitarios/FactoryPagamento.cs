using System;
using FactoryPagamento;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesUnitarios
{
    [TestClass]
    public class FactoryPagamento
    {
        [TestMethod]
        public void ValidaFactory()
        {
            Pagamento pagamento = new Pagamento();
            pagamento.AdicionarItem("1","Produto 1",10,10);
            pagamento.AdicionarItem("1", "Produto 2", 10, 12);
            pagamento.ProcessarPagamento();

        }
    }
}
