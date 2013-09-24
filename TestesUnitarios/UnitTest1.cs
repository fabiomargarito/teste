using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverChegadaDeArquivo;

namespace TestesUnitarios
{
    [TestClass]
    public class TesteFileWatcher
    {
        [TestMethod]
        public void TesteObserverFileWatcher()
        {
           Arquivo arquivo = new Arquivo();

          IInteressado interessado = new interesado();
           

            arquivo.cadastrarInteressado(interessado);

            arquivo.monitorar();

            Console.ReadKey();
        }
    }
}
