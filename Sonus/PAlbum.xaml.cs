using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sonus
{
    public partial class PAlbum : ContentPage
    {
        public PAlbum()
        {
            InitializeComponent(); // Conecta com o XAML visual

            var albuns = new Albuns();
            var listaAlbuns = albuns.BuscaTodosComArtistas();

            albunsListView.ItemsSource = listaAlbuns;
        }
    }
}
