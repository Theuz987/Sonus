using Org.BouncyCastle.Asn1.Tsp;

namespace Sonus;

public partial class CadastroUsuarios : ContentPage
{
    public CadastroUsuarios()
    {
        InitializeComponent();
    }

    private void Salvar_Clicked(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();
        usuario.email = EntryEmail.Text;
        usuario.senha = EntrySenha.Text;
        usuario.nickname = EntryNickname.Text;
        usuario.Insere();
    }
}