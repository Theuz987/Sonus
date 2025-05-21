namespace Sonus;

public partial class CadastroAlbuns : ContentPage
{
    private int artistaSelecionadoId = -1;
    public CadastroAlbuns()
    {

        InitializeComponent();
        CarregaArtistas();
    }

    private void CarregaArtistas()
    {
        Artista artista = new Artista();
        List<Artista> listaArtistas = artista.BuscaTodos();

        PickerArtistas.ItemsSource = listaArtistas;
    }

    private void PickerArtistas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (PickerArtistas.SelectedIndex != -1)
        {
            Artista selecionado = (Artista)PickerArtistas.SelectedItem;
            artistaSelecionadoId = selecionado.id;
            Console.WriteLine($"Artista selecionado: {selecionado.nome}, ID: {selecionado.id}");
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Albuns albuns = new Albuns();
        albuns.nome = EntryAlbum.Text;
        albuns.url_imagem = EntryUrl.Text;
        albuns.descricao = EntryDescricao.Text;

        albuns.Insere();

        string nome = EntryAlbum.Text;
        string urlImagem = EntryUrl.Text;
        string descricao = EntryDescricao.Text;

        if (artistaSelecionadoId == -1)
        {
            DisplayAlert("Erro", "Por favor selecione um artista.", "OK");
            return;
        }

        // Aqui você pode salvar o álbum
        Console.WriteLine($"Álbum: {nome}\nImagem: {urlImagem}\nDescrição: {descricao}\nArtista ID: {artistaSelecionadoId}");
    }
}