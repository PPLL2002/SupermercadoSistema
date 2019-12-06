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
    /// Lógica interna para CadastrarCompras.xaml
    /// </summary>
    public partial class CadastrarCompras : Window
    {
        public CadastrarCompras()
        {
            InitializeComponent();
        }

        NFornecedor nF;
        NProduto nP;
        Fornecedor f;
        Produto pC = new Produto();
        List<ItemCompra> carrinho = new List<ItemCompra>();
        ItemCompra itemC;
        Compra c;

        private void ListarFornecedores(object sender, RoutedEventArgs e)
        {
            nF = new NFornecedor();
            listFornecedores.ItemsSource = null;
            listFornecedores.ItemsSource = nF.Select();
        }

        private void PesquisarFornecedor(object sender, RoutedEventArgs e)
        {
            nF = new NFornecedor();
            listFornecedores.ItemsSource = null;
            listFornecedores.ItemsSource = nF.Search(pesqForn.Text);
        }

        private void ListFornecedores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(listFornecedores.SelectedItem != null)
            {
                f = listFornecedores.SelectedItem as Fornecedor;
                nP = new NProduto();
                listaProdutos.ItemsSource = null;
                listaProdutos.ItemsSource = nP.Select(f.Id);
            }
        }

        private void PesquisarProduto_Click(object sender, RoutedEventArgs e)
        {
            nP = new NProduto();
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Search(pesqProduto.Text, f.Id);
        }
        

        private void SelecionarProdutosParaComprar(object sender, SelectionChangedEventArgs e)
        {
            if (listaProdutos.SelectedItem != null) pC = listaProdutos.SelectedItem as Produto;
        }
       
        private void btnIniciarCompra(object sender, RoutedEventArgs e)
        {
            c = new Compra();
            c.IdFornecedor = f.Id;
            c.Data = DateTime.Now;

            NCompra nC = new NCompra();
            nC.Insert(c);

            IniciarCompra.Visibility = Visibility.Hidden;
            CancelarCompra.Visibility = Visibility.Visible;
         
        }

        private void btnCancelarCompra(object sender, RoutedEventArgs e)
        {
            NCompra nC = new NCompra();
            nC.Delete(c);

            carrinho.Clear();
            Carrinho.ItemsSource = null;

            IniciarCompra.Visibility = Visibility.Visible;
            CancelarCompra.Visibility = Visibility.Hidden;

            nP = new NProduto();
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Select(f.Id);
        }

        private void btnComprar(object sender, RoutedEventArgs e)
        {
            List<Produto> p = new List<Produto>();
            NEstoque nE = new NEstoque();
            IniciarCompra.Visibility = Visibility.Visible;
            CancelarCompra.Visibility = Visibility.Hidden;

            nE.UpdateEstoque(carrinho);
            carrinho.Clear();
            Carrinho.ItemsSource = null;

        }

        private void btnRemoverItem(object sender, RoutedEventArgs e)
        {
            carrinho.Remove(itemC);
            NItemCompra nIC = new NItemCompra();
            nIC.Delete(itemC);

            Carrinho.ItemsSource = null;
            Carrinho.ItemsSource = carrinho;

            nP = new NProduto();
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Select(f.Id);
        }

        private void SelecionarItemCompra(object sender, SelectionChangedEventArgs e)
        {
            if (Carrinho.SelectedItem != null) itemC = Carrinho.SelectedItem as ItemCompra;
        }

        private void ListaProdutos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ItemCompra iC = new ItemCompra();
            iC.Preco = pC.Preco;
            iC.Qtd = int.Parse(qtdCompra.Text);
            iC.IdProduto = pC.Id;
            iC.IdCompra = c.Id;
            NItemCompra nIC = new NItemCompra();
            nIC.Insert(iC);
            carrinho.Add(iC);


            Carrinho.ItemsSource = null;
            Carrinho.ItemsSource = carrinho;


            nP = new NProduto();
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Select(f.Id);
        }
    }
}
