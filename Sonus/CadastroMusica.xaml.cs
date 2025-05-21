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
            DisplayAlert("Erro", "Selecione um �lbum e um artista.", "OK");
            return;
        }

        Albuns albumSelecionado = (Albuns)PickerAlbum.SelectedItem;
        Artista artistaSelecionado = (Artista)PickerArtista.SelectedItem;

        int idAlbum = albumSelecionado.id;
        int idArtista = artistaSelecionado.id;

        // Aqui voc� pode continuar salvando a m�sica no banco de dados.
        Console.WriteLine($"M�sica: {nomeMusica}, Tempo: {tempoMusica}, �lbum ID: {idAlbum}, Artista ID: {idArtista}");

        DisplayAlert("Sucesso", "M�sica cadastrada!", "OK");

    }
}