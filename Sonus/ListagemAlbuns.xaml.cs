namespace Sonus;

public partial class ListagemAlbuns : ContentPage
{
	public ListagemAlbuns()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Albuns albuns = new Albuns();
        Lista.ItemsSource = null;
        Lista.ItemsSource = albuns.BuscaTodosComArtistas();
    }

}