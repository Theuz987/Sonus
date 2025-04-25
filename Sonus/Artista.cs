using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexaoBD;

namespace Sonus
{
    internal class Artista
    {
        public int id {  get; set; }
        public string nome { get; set; }
        public string url_imagem { get; set; }
        Conexao conexao { get; set; }

        public Artista()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {
            string query = $"INSERT INTO artistas (nome, url_imagem) VALUES ( '{nome}', '{url_imagem}' );";
            conexao.ExecutaComando(query);
            Console.WriteLine("Artista inserido com sucesso!");
        }

        public List<Artista> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM artistas;");

            List<Artista> lista = new List<Artista>();

            foreach (DataRow linha in dt.Rows)
            {
                Artista p = new Artista();

                p.id = int.Parse(linha["id"].ToString());
                p.nome = linha["nome"].ToString();
                p.url_imagem =linha["url_imagem"].ToString();

                lista.Add(p);
            }

            return lista;

        }

    }
}
