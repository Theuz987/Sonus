using System.Diagnostics;

namespace Sonus;

public partial class CadastroMusica : ContentPage
{
    
	public CadastroMusica()
	{
		InitializeComponent();
        CarregarPickers();
    }

    private void CarregarPickers()
    {

        Albuns albuns = new Albuns();
        Artista artistas = new Artista();

        // Carrega dados das tabelas
        List<Albuns> listaAlbuns = albuns.BuscaTodosComArtistas();

        // Atribui aos Pickers
        PickerAlbum.ItemsSource = listaAlbuns;

        try
        {
            Albuns album = new Albuns();
            Artista artista = new Artista();

            listaAlbuns = albuns.BuscaTodosComArtistas();

            PickerAlbum.ItemsSource = listaAlbuns;  
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", "Erro ao carregar dados: " + ex.Message, "OK");
        }
    }


    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Musica m = new Musica();
       
        string nomeMusica = EntryNome.Text;
        string tempoMusica = EntryTempo.Text;

        // Verifica se itens foram selecionados
        if (PickerAlbum.SelectedIndex == -1 )
        {
            DisplayAlert("Erro", "Selecione um álbum e um artista.", "OK");
            return;
        }

        Albuns albumSelecionado = (Albuns)PickerAlbum.SelectedItem;
        int idAlbum = albumSelecionado.id;
      
        m.nome = EntryNome.Text;
        m.tempo = EntryTempo.Text;
        m.id_album = idAlbum;
        m.Insere();

        DisplayAlert("Sucesso", "Música cadastrada!", "OK");

    }
}