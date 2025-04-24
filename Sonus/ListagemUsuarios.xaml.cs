namespace Sonus;

public partial class ListagemUsuarios : ContentPage
{
    public ListagemUsuarios()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();


        Usuario usuario = new Usuario();
        Lista.ItemsSource = null;
        Lista.ItemsSource = usuario.BuscaTodos();

    }
}