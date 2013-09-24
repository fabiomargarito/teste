using System;
using CommandTV;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesUnitarios
{
    [TestClass]
    public class TesteCommandTV
    {
        [TestMethod]
        public void CommandTVTeste()
        {
            DispositoEletronico minhaTV = new Televisao();

            Comando ligaTv = new LigarTV(minhaTV);
            Comando desligarTv = new DesligarTV(minhaTV);
            Comando trocarCanalTv = new TrocarCanalTV(minhaTV,1);
        

            ControleRemoto controleRemoto = new ControleRemoto();

            controleRemoto.Pressionar(ligaTv);
            controleRemoto.Pressionar(desligarTv);
            controleRemoto.Pressionar(trocarCanalTv);



        }
    }
}
