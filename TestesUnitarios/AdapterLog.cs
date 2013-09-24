using System;
using AdapterLog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesUnitarios
{
    [TestClass]
    public class AdapterLog
    {
        [TestMethod]
        public void TestaAdpatadorLog()
        {
            ILog log = new Log();
            log.RegistrarLog("teste",TipoLog.Erro);

            log = new LOG4NETAdaptado();
            log.RegistrarLog("outro teste de log", TipoLog.Aviso);
        }
    }
}
