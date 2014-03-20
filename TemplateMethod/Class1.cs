﻿using System;
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
        protected SqlConnection ObterConexao()
        {
            System.Console.WriteLine("Obtendo Conexao");
            return  new SqlConnection();
        }
        protected List<T> ExecutarComando()
        {
            System.Console.WriteLine("Executando o comando {0}", _comando);
            return new List<T>();
        }
        protected abstract void DefinirComando();
        protected abstract List<T> TratarRetorno();

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

    public class DALCliente : DALBase<Cliente>
    {
        protected override void DefinirComando()
        {
            _comando = "select * from cliente";
        }

        protected override List<Cliente> TratarRetorno()
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
