namespace Sonus;

public partial class CadastroMusica : ContentPage
{
	public CadastroMusica()
	{
		InitializeComponent();
        

    }

    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Musica m = new Musica();
        m.nome = EntryNome.Text;
        m.tempo = EntryTempo.Text;
        m.Insere();

        
    }
}