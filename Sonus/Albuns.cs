using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexaoBD;

namespace Sonus
{
  
        internal class Albuns
        {
            public int id { get; set; }
            public int id_artista { get; set; }
            public string nome { get; set; }

            public string url_imagem { get; set; }
            public string data_lancamento { get; set; }


            Conexao conexao { get; set; }

            public Albuns()
            {
                conexao = new Conexao();
            }

            public void Insere()
            {
                string query = $"INSERT INTO albuns (nome, url_imagem, data_lancamento) VALUES ( '{nome}', '{url_imagem}', '{data_lancamento}' );";
                conexao.ExecutaComando(query);
                Console.WriteLine("Albuns inserido com sucesso!");
            }

            public List<Albuns> BuscaTodos()
            {
                DataTable dt = conexao.ExecutaSelect("SELECT * FROM albuns;");

                List<Albuns> lista = new List<Albuns>();

                foreach (DataRow linha in dt.Rows)
                {

                    Albuns a = new Albuns();

                    a.id = int.Parse(linha["id"].ToString());
                    a.id_artista = int.Parse(linha["id_artista"].ToString());
                    a.nome = linha["nome"].ToString();
                    a.url_imagem = linha["url_imagem"].ToString();
                    a.data_lancamento = linha["data_lancamento"].ToString();

                lista.Add(a);

                }

                return lista;

            }
        }
    }


