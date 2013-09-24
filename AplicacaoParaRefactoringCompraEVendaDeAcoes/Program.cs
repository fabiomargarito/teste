using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Security.Claims;

namespace AplicacaoParaRefactoringCompraEVendaDeAcoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            cliente.CPF = "123.133.132-23";
            cliente.nmCli = "Cliente de teste";

            //gravando operacao de compra na carteira
            Acao acao = new Acao();
            acao.cdAcao = "PETR4";
            acao.PrAcao = 10;
            acao.qtAcoes = 12;
            acao.RegistrarCompraAcao(acao,cliente);


            //gravando operacao de compra na carteira
            Acao acao2 = new Acao();
            acao2.cdAcao = "PETR3";
            acao2.PrAcao = 10;
            acao2.qtAcoes = 12;
            acao2.RegistrarVendaAcao(acao2,cliente);

            //Mostrando a Carteira
            DalCarteira carteira = new DalCarteira();
            foreach (var cart in carteira.RetornCarteiras(cliente))
            {
                Console.WriteLine("ACAO:{0}          VAlor:{1}      Quantidade:{2}    ValorTotal:{3}    ",cart.Acao.cdAcao,cart.Acao.PrAcao,cart.Acao.qtAcoes,cart.Acao.CustoOperacao);
            }
            Console.ReadKey();

        }
    }


    public class Cliente
    {
        public string CPF;
        public string nmCli;


        public void Gravar()
        {
            (new DalCli()).gravar(this);
        }  
    }


    public class DalCli
    {
        public void gravar(Cliente cli)
        {
            Console.WriteLine("Cliente Gravado");
        }
    }


    public class Acao
    {
        public string cdAcao;
        public int qtAcoes;
        public double vlAcao;
        public double CustoOperacao;

        
        //Preco Da Acao
        public double PrAcao;

        public void RegistrarCompraAcao(Acao acao, Cliente cliente)
        {
            CustoOperacao = acao.PrAcao*acao.qtAcoes;
            CustoOperacao += 10;
            CustoOperacao += CustoOperacao*0.003;
            CustoOperacao += CustoOperacao * 0.000325;

            GravarAcaoNaCarteira(acao.cdAcao, acao.vlAcao, acao.qtAcoes, acao.CustoOperacao, cliente, 1);
        }


        public void RegistrarVendaAcao(Acao acao, Cliente cliente)
        {
            CustoOperacao = acao.PrAcao*acao.qtAcoes;
            CustoOperacao += 10;
            CustoOperacao += CustoOperacao*0.003;
            CustoOperacao += CustoOperacao * 0.000325;

            GravarAcaoNaCarteira(acao.cdAcao,acao.vlAcao,acao.qtAcoes,acao.CustoOperacao, cliente,2);

        }

        private Acao RetornarCotacao(string cdAcao)
        {
            //simulando acesso ao banco
            return new Acao{cdAcao = cdAcao,vlAcao = 10};
        }

        public void GravarAcaoNaCarteira(string CodigoAcao,double valorAcao, int quantidade, double ValorTotal, Cliente cliente,int tpOperacao)
        {
         Carteira carteira = new Carteira();
         
            carteira.Acao = new Acao{cdAcao = CodigoAcao,CustoOperacao = ValorTotal,qtAcoes = quantidade,PrAcao = valorAcao,vlAcao = valorAcao };
            carteira.Cliente = cliente;
            carteira.TipoOperacao = tpOperacao;
            (new DalCarteira()).gravar(carteira);


        }

    }
   

    public class Carteira
    {
        public Acao Acao;
        public double vlRentabilidade;
        public Cliente Cliente;
        public int TipoOperacao;

    }

    public class DalCarteira
    {        
        public void gravar(Carteira carteira)
        {
            
            

            DataSet dataSet = new DataSet();

            
            DataTable dataTable;
            if (!File.Exists("carteira.xml"))
            {
                dataTable = new DataTable("carteira");

                dataTable.Columns.Add("Acao");
                dataTable.Columns.Add("Valor");
                dataTable.Columns.Add("Quantidade");
                dataTable.Columns.Add("ValorTotal");

                dataTable.Rows.Add(carteira.Acao.cdAcao, carteira.Acao.PrAcao, carteira.Acao.qtAcoes,
                carteira.Acao.CustoOperacao);

                dataSet.Tables.Add(dataTable);
            }
            else
            {
                dataSet.ReadXml("carteira.xml");
                dataTable = dataSet.Tables["carteira"];
                dataTable.Rows.Add(carteira.Acao.cdAcao, carteira.Acao.PrAcao, carteira.Acao.qtAcoes,
                carteira.Acao.CustoOperacao);
            }

            
            
            
            dataSet.WriteXml("carteira.xml");

        }

        public List<Carteira> RetornCarteiras(Cliente cliente)
        {
            var operacoes = new List<Carteira>();
            DataSet dataset = new DataSet();

            

            dataset.ReadXml("carteira.xml");

            foreach (DataRow row in dataset.Tables[0].Rows)
            {
               operacoes.Add( new Carteira
                {
                    Acao = new Acao {cdAcao = row[0].ToString(), PrAcao = Convert.ToDouble(row[1]), qtAcoes = Convert.ToInt16(row[2]), CustoOperacao = Convert.ToDouble(row[3])}

                });
            }
            return operacoes;
        }

    }
}
