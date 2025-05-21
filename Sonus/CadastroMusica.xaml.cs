namespace Sonus;

public partial class CadastroMusica : ContentPage
{
    private List<Albuns> listaAlbuns;
    private List<Artista> listaArtista;
	public CadastroMusica()
	{
		InitializeComponent();
        CarregarPickers();
    }

    private void CarregarPickers()
    {
        Albuns albuns = new Albuns();
        Artista artistas = new Artista();

        // Carrega os dados das tabelas
        listaAlbuns = albuns.BuscaTodosComArtistas();
        listaArtista = artistas.BuscaTodos();

        // Atribui aos Pickers
        PickerAlbum.ItemsSource = listaAlbuns;
        PickerArtista.ItemsSource = listaArtista;


        try
        {
            Albuns album = new Albuns();
            Artista artista = new Artista();

            listaAlbuns = albuns.BuscaTodosComArtistas();
            listaArtista = artistas.BuscaTodos();

            System.Diagnostics.Debug.WriteLine("Álbuns: " + listaAlbuns.Count);


            PickerAlbum.ItemsSource = listaAlbuns;
            PickerArtista.ItemsSource = listaArtista;
            
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", "Erro ao carregar dados: " + ex.Message, "OK");
        }
    }


    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Musica m = new Musica();
        m.nome = EntryNome.Text;
        m.tempo = TimeSpan.Parse(EntryTempo.Text);
        m.Insere();


        string nomeMusica = EntryNome.Text;
        string tempoMusica = EntryTempo.Text;

        // Verifica se os itens foram selecionados
        if (PickerAlbum.SelectedIndex == -1 || PickerArtista.SelectedIndex == -1)
        {
            DisplayAlert("Erro", "Selecione um álbum e um artista.", "OK");
            return;
        }

        Albuns albumSelecionado = (Albuns)PickerAlbum.SelectedItem;
        Artista artistaSelecionado = (Artista)PickerArtista.SelectedItem;

        int idAlbum = albumSelecionado.id;
        int idArtista = artistaSelecionado.id;

        // Aqui você pode continuar salvando a música no banco de dados.
        Console.WriteLine($"Música: {nomeMusica}, Tempo: {tempoMusica}, Álbum ID: {idAlbum}, Artista ID: {idArtista}");

        DisplayAlert("Sucesso", "Música cadastrada!", "OK");

    }
}