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
    /// Lógica interna para CadastrarVendas.xaml
    /// </summary>
    public partial class CadastrarVendas : Window
    {
        public CadastrarVendas()
        {
            InitializeComponent();
        }
        Venda v;
        NVenda nV;
        NItemVenda nIV;
        List<ItemVenda> carrinho = new List<ItemVenda>();
        NEstoque NE;
        private void btnIniciarVenda(object sender, RoutedEventArgs e)
        {
            v = new Venda();
            v.Data = DateTime.Now;
            nV = new NVenda();
            nV.Insert(v);

            Inicar.Visibility = Visibility.Hidden;
            Cancelar.Visibility = Visibility.Visible;
            Finalizar.Visibility = Visibility.Visible;
            CancelarItem.Visibility = Visibility.Visible;
        }
        private void btnCancelarVenda(object sender, RoutedEventArgs e)
        {
            nV = new NVenda();
            nV.Delete(v);

            Carrinho.ItemsSource = null;

            Inicar.Visibility = Visibility.Visible;
            Cancelar.Visibility = Visibility.Hidden;
            Finalizar.Visibility = Visibility.Hidden;
            CancelarItem.Visibility = Visibility.Hidden;
        }

        private void ListarProdutos(object sender, RoutedEventArgs e)
        {
            NE = new NEstoque();
            ListaPEstoque.ItemsSource = null;
            ListaPEstoque.ItemsSource = NE.Select();
        }

        private void ProcurarNome(object sender, RoutedEventArgs e)
        {
            NE = new NEstoque();
            ListaPEstoque.ItemsSource = null;
            ListaPEstoque.ItemsSource = NE.SearchNome(txtPesqNome.Text);
        }

        private void ProcurarID(object sender, RoutedEventArgs e)
        {
            NE = new NEstoque();
            ListaPEstoque.ItemsSource = null;
            ListaPEstoque.ItemsSource = NE.SearchID(int.Parse(txtPesqID.Text));
        }

        private void SelecionarItemParaAddCarrinho(object sender, MouseButtonEventArgs e)
        {
            ItemVenda iv = new ItemVenda();
            iv.IdProduto = p.Id;
            iv.IdVenda = v.Id;
            iv.Preco = p.Id;
            iv.Qtd = int.Parse(qtd.Text);
            NItemVenda nIV = new NItemVenda();
            nIV.Insert(iv);

            carrinho.Add(iv);

            Carrinho.ItemsSource = null;
            Carrinho.ItemsSource = carrinho;
        }
        Produto p;
        private void ItemSelecionado(object sender, SelectionChangedEventArgs e)
        {
            if (ListaPEstoque.SelectedItem != null) p = ListaPEstoque.SelectedItem as Produto;
        }
        ItemVenda itenV;
        private void ItemCarrinhoSelecionado(object sender, SelectionChangedEventArgs e)
        {
            if (Carrinho.SelectedItem != null) itenV = Carrinho.SelectedItem as ItemVenda;
        }

        private void CancelarItem_Click(object sender, RoutedEventArgs e)
        {
            carrinho.Remove(itenV);

            nIV = new NItemVenda();
            nIV.Delete(itenV);

            Carrinho.ItemsSource = null;
            Carrinho.ItemsSource = carrinho;
        }

        private void FinacalizarCompra_Click(object sender, RoutedEventArgs e)
        {
            carrinho.Clear();

            Inicar.Visibility = Visibility.Visible;
            Cancelar.Visibility = Visibility.Hidden;
            Finalizar.Visibility = Visibility.Hidden;
            CancelarItem.Visibility = Visibility.Hidden;

            Carrinho.ItemsSource = null;
        }
    }
}
