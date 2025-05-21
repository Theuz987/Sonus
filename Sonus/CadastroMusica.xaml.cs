namespace Sonus;

public partial class CadastroMusica : ContentPage
{
	public CadastroMusica()
	{
		InitializeComponent();
        CarregarDados();
    }

    private List<Albuns> albuns;
    private List<Artista> artistas;

    private void CarregarDados()
    {
        // Aqui pode carregar os dados de álbuns e artistas a partir do banco de dados ou API.
        // Exemplo: Buscar dados de álbuns e artistas em um banco de dados ou API.

        // Para fins de exemplo, vamos usar dados fictícios:
        albuns = new List<Albuns>
            {
                new Albuns { id = 1, nome = "Album 1" },
                new Albuns { id = 2, nome = "Album 2" }
            };

        artistas = new List<Artista>
            {
                new Artista { id = 1, nome = "Artista 1" },
                new Artista { id = 2, nome = "Artista 2" }
            };

        // Preenche os Pickers com os dados
        PickerAlbum.ItemsSource = albuns;
        PickerArtista.ItemsSource = artistas;
    }

    private void PickerAlbum_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerAlbum.SelectedIndex != -1)
        {
            var albumSelecionado = (Albuns)PickerAlbum.SelectedItem;
            var albumId = albumSelecionado.id; // Obter ID do álbum
                                               // Aquipode armazenar ou usar o ID se necessário
        }
    }

    private void PickerArtista_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerArtista.SelectedIndex != -1)
        {
            var artistaSelecionado = (Artista)PickerArtista.SelectedItem;
            var artistaId = artistaSelecionado.id; // Obter o ID do artista
                                                   // Aqui pode armazenar ou usar o ID se necessário
        }
    }

    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Musica m = new Musica();
        m.nome = EntryNome.Text;
        m.tempo =  TimeSpan.Parse(EntryTempo.Text);
        m.Insere();

        string nomeMusica = EntryNome.Text;
        string tempoMusica = EntryTempo.Text;
        // Obtenha os IDs selecionados dos Pickers
        var albumId = ((Albuns)PickerAlbum.SelectedItem)?.id;
        var artistaId = ((Artista)PickerArtista.SelectedItem)?.id;
    }
}