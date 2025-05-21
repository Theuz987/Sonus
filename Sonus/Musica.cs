using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonus
{
    internal class Musica
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string img { get; set; }
        public TimeSpan tempo { get; set; }
        public int id_album { get; set; }
        public int id_artista { get; set; }

        Conexao conexao { get; set; }

        public Musica()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {

            string query = $"INSERT INTO musica (nome, tempo, img, id_album, id_artista) VALUES ('{nome}', '{img}' '{tempo}', '{id_album}', '{id_artista}' );";
            conexao.ExecutaComando(query);
            Console.WriteLine("Musica cadastrada com sucesso!");

        }

        public List<Musica> BuscaTodos()
        {
            DataTable dt = conexao.ExecutaSelect("SELECT * FROM musica;");

            List<Musica> lista = new List<Musica>();

            foreach (DataRow linha in dt.Rows)
            {
                Musica p = new Musica();

                p.id = int.Parse(linha["id"].ToString());
                p.nome = linha["nome"].ToString();
                p.tempo = TimeSpan.Parse(linha["tempo"].ToString());
                p.id_album = int.Parse(linha["id_album"].ToString());
                p.id_artista= int.Parse(linha["id_artista"].ToString());

                lista.Add(p);
            }

            return lista;

        }


    }
}

