using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesUnitarios
{
    [TestClass]
    public class TesteSingletonConexao
    {
        [TestMethod]
        public void CriaConexao()
        {
            var conexao = SingletonConexao.Conexao.RetornarConexao();
            var conexao2 = SingletonConexao.Conexao.RetornarConexao();
        }
    }
}
