using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modelo;
using Negocio;

namespace Visao
{
    /// <summary>
    /// Lógica interna para Estoque.xaml
    /// </summary>
    public partial class WindowEstoque : Window
    {
        public WindowEstoque()
        {
            InitializeComponent();
            ne = new NEstoque();
            ListaProdutos.ItemsSource = null;
            ListaProdutos.ItemsSource = ne.Select();
        }

        Produto p;
        NEstoque ne;

        private void ListaProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaProdutos.SelectedItem != null) p = ListaProdutos.SelectedItem as Produto;
        }

        private void btnDelete(object sender, RoutedEventArgs e)
        {
            ne = new NEstoque();
            ne.Delete(p);
            ListaProdutos.ItemsSource = null;
            ListaProdutos.ItemsSource = ne.Select();
        }

        private void btnVencidos(object sender, RoutedEventArgs e)
        {
            ne = new NEstoque();
            ListaProdutos.ItemsSource = null;
            ListaProdutos.ItemsSource = ne.VerificarValidade();
        }

        private void btnSearch(object sender, RoutedEventArgs e)
        {
            ne = new NEstoque();
            ListaProdutos.ItemsSource = null;
            ListaProdutos.ItemsSource = ne.Search(DateTime.Parse(validadeProduto.Text));
        }

        private void btnPreco(object sender, RoutedEventArgs e)
        {
            ne = new NEstoque();
            ne.AlterarPreco(p, decimal.Parse(novoPreco.Text));
            ListaProdutos.ItemsSource = null;
            ListaProdutos.ItemsSource = ne.Select();
        }

        private void ListaProdutos_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("teste");
        }
    }
}
