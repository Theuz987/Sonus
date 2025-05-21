using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace Sonus
{
    class Usuario
    {

        public int id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string nickname { get; set; }
        public string url_imagem { get; set; }
        public DateTime criado_em { get; set; }


        Conexao conexao { get; set; }

        public Usuario()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {
            string query = $"INSERT INTO usuarios (email, nickname, senha) VALUES ( '{email}', '{nickname}', '{senha}' );";
            conexao.ExecutaComando(query);
            Console.WriteLine("Usuario cadastrado com sucesso!");
        }

        public List<Usuario> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM usuarios;");

            List<Usuario> lista = new List<Usuario>();

            foreach (DataRow linha in dt.Rows)
            {

                Usuario u = new Usuario();

                u.id = int.Parse(linha["id"].ToString());
                u.email = linha["email"].ToString();
                u.senha = linha["senha"].ToString();
                u.nickname = linha["nickname"].ToString();

                lista.Add(u);

            }

            return lista;

        }

    }
}

