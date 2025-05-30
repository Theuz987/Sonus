﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonus
{
  
        internal class Albuns
        {
            public int id { get; set; }
            public int id_artista { get; set; }
            public string nome { get; set; }
            public string url_imagem { get; set; }
            public string descricao{ get; set; }


        Conexao conexao { get; set; }

            public Albuns()
            {
               conexao = new Conexao();
            }
            public void Insere()
            {
                string query = $"INSERT INTO albuns (nome, url_imagem, descricao, id_artista) " +
                $"VALUES ('{nome}', '{url_imagem}', '{descricao}', '{id_artista}');";

                conexao.ExecutaComando(query);
                Console.WriteLine("Álbum inserido com sucesso!");
            }

            public List<Albuns> BuscaTodosComArtistas()
            {
                DataTable dt = conexao.ExecutaSelect("SELECT * FROM albuns;");

                List<Albuns> lista = new List<Albuns>();

                foreach (DataRow linha in dt.Rows)
                {
                    Albuns a = new Albuns();

                    a.id = Convert.ToInt32(linha["id"]);
                    a.nome = linha["nome"].ToString();
                    a.id_artista = Convert.ToInt32(linha["id_artista"]);
                    a.url_imagem = linha["url_imagem"].ToString();
                    a.descricao = linha["descricao"].ToString();

                    lista.Add(a);
                }

                return lista;

            }
        }
    }


