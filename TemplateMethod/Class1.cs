using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace TemplateMethod
{
    public abstract class DALBase<T>
    {
        protected string _comando;

        public SqlConnection ObterConexao()
        {
            System.Console.WriteLine("Obtendo Conexao");
            return  new SqlConnection();
        }

        public List<T> ExecutarComando()
        {
            System.Console.WriteLine("Executando o comando {0}", _comando);
            return new List<T>();
        }

        public abstract void DefinirComando();
        public abstract List<T> TratarRetorno();


        public List<T> Executar()
        {
            List<T> retorno;
            var conexao = ObterConexao();
            System.Console.WriteLine("Abrindo Conexao");
            DefinirComando();
            retorno = TratarRetorno();
            System.Console.WriteLine("Fechando Conexao");
            return retorno;

        }



    }

    public abstract class DALCliente : DALBase<Cliente>
    {
        public override void DefinirComando()
        {
            _comando = "select * from cliente";
        }

        public override List<Cliente> TratarRetorno()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente{cpf = "2222222"});
            return clientes;
        }
    }

    public class Cliente
    {
        public string cpf { get; set; }
    }
}
