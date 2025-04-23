namespace Sonus;

public partial class ListagemArtistas : ContentPage
{
	public ListagemArtistas()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();


        Artista artista = new Artista();
        Lista.ItemsSource = null;
        Lista.ItemsSource = artista.BuscaTodos();

    }

}