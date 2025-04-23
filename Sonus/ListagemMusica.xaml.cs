namespace Sonus;

public partial class ListagemMusica : ContentPage
{
	public ListagemMusica()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();


        Musica musica = new Musica();
        Lista.ItemsSource = null;
        Lista.ItemsSource = musica.BuscaTodos();

    }
}