
namespace Sonus
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();  // Inicializa os componentes do XAML

            // Carrega os dados do artista após inicialização
            CarregaArtista();
            CarregaAlbuns();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarregaArtista();  // Carrega novamente ao aparecer, se necessário
        }

        private void OnVerAlbunsClicked(object sender, EventArgs e)
        {
            CarregaAlbuns(); // Carregar os álbuns ao clicar no botão
        }

        private void OnCounterClicked(object sender, EventArgs e) { }

        private void CarregaAlbuns()
        {
            var albuns = new Albuns();
            var listaAlbuns = albuns.BuscaTodosComArtistas();

            if (listaAlbuns != null && listaAlbuns.Count > 0)
            {
                albunsListView.ItemsSource = listaAlbuns; // Atribui a lista de álbuns como ItemsSource
            }
            else
            {
                Console.WriteLine("Nenhum álbum encontrado.");
            }
        }


        private void CarregaArtista()
        {
            Artista artistamodel = new Artista();
            List<Artista> artistas = artistamodel.BuscaTodos();

            // Verificando se a lista de artistas não está vazia
            if (artistas != null && artistas.Count > 0)
            {
                pickerArtistas.ItemsSource = artistas; // Atribui a lista de artistas como ItemsSource
            }
            else
            {
                Console.WriteLine("Nenhum artista encontrado.");
            }
        }



        private void pickerArtistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var artistaSelecionado = (Artista)pickerArtistas.SelectedItem;
            if (artistaSelecionado != null)
            {
                Console.WriteLine($"ID: {artistaSelecionado.id} - Nome: {artistaSelecionado.nome}");
            }
        }
    }
}
