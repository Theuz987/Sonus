namespace Sonus;

public partial class CadastroAlbuns : ContentPage
{
	public CadastroAlbuns()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Albuns albuns = new Albuns();
		albuns.nome = EntryAlbum.Text;
		albuns.url_imagem = EntryUrl.Text;

		string data = EntryData.Date.ToString();
		data = string.Join("-", data.Split(" ")[0].Split("/").Reverse());

		albuns.data_lancamento = data;

		albuns.Insere();
    }
}