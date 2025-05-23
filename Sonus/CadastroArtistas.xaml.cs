using Org.BouncyCastle.Asn1.Tsp;

namespace Sonus;

public partial class CadastroArtistas : ContentPage
{
	public CadastroArtistas()
	{
		InitializeComponent();
	}

    private void Salvar_Clicked(object sender, EventArgs e)
    {
		Artista artista = new Artista();
		artista.nome = EntryNome.Text;
		artista.url_imagem = EntryUrl.Text;
		artista.Insere();

        DisplayAlert("Agora foi ! ;)", "Novu artista cadastrado com sucessxo ", "OK");
    }
}