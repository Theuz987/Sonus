using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Sonus
{
    public class Conexao
    {

        private MySqlConnection conexao;

        public Conexao() 
        {
            string dadosConexao = "server=localhost;user=root;database=sonus;port=3306;password=";
            conexao = new MySqlConnection(dadosConexao);
        }

        string dadosConexao = "server=localhost;user=root;database=sonus;port=3306;password=";

        public int ExecutaComando(string query)
        {
            // Cria e abre conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            // Rodar a query dentro do banco
            MySqlCommand comando = new MySqlCommand(query, conexao);
            int linhasAfetadas = comando.ExecuteNonQuery();
            conexao.Close();

            return linhasAfetadas;
        }
        

public DataTable ExecutaSelect(string query)
        {
            // Cria e abre conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open();

            // Rodar a query dentro do banco
            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataAdapter dados = new MySqlDataAdapter(query, conexao);
            DataTable dt = new DataTable();
            dados.Fill(dt);
            conexao.Close();
            return dt;
        }

    }
}