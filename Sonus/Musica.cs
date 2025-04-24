using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexaoBD;

namespace Sonus
{
    internal class Musica
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string tempo { get; set; }

        Conexao conexao { get; set; }

        public Musica()
        {
            conexao = new Conexao();
        }

        public void Insere()
        {

            string query = $"INSERT INTO musica (nome, tempo) VALUES ('{nome}', '{tempo}');";
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
                p.tempo = linha["tempo"].ToString();

                lista.Add(p);
            }

            return lista;

        }


    }
}

