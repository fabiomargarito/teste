using System;
using DecoratorFormatandoTextos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesUnitarios
{
    [TestClass]
    public class TesteDecorator
    {
        [TestMethod]
        public void TesteEditorDeTexto()
        {
            TextoHTML texto = new TextoHTML();
            texto.texto = "Texto de teste";

            TipoFormatacao bold = new Bold(texto);
            TipoFormatacao center = new Center(bold);
            Console.WriteLine(center.Formatar());
        }
    }
}



