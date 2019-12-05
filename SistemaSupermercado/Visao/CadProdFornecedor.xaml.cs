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
    /// Lógica interna para CadProdFornecedor.xaml
    /// </summary>
    public partial class CadProdFornecedor : Window
    {
        Fornecedor forn;
        Produto p;
        NProduto nP;
        public CadProdFornecedor(Fornecedor f)
        {
            InitializeComponent();
            forn = f;
            nP = new NProduto();
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Select(forn.Id);
        }

        private void InserirProduto(object sender, RoutedEventArgs e)
        {
            p = new Produto();
            p.Nome = nomeProduto.Text;
            p.Descricao = descProduto.Text;
            p.Qtd = int.Parse(qntdProduto.Text);
            p.Validade = DateTime.Parse(validadeProduto.Text);
            p.Preco = decimal.Parse(precoProduto.Text);
            p.IdFornecedor = forn.Id;
            nP = new NProduto();
            nP.Insert(p);
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Select(forn.Id);
        }

        private void ListaProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listaProdutos.SelectedItem != null)
            {
                p = (listaProdutos.SelectedItem as Produto);
                nomeProduto.Text = p.Nome;
                descProduto.Text = p.Descricao;
                qntdProduto.Text = p.Qtd.ToString();
                validadeProduto.Text = p.Validade.ToString();;
                precoProduto.Text = p.Preco.ToString();
            }
        }

        private void AtualizarProduto(object sender, RoutedEventArgs e)
        {
            p.Nome = nomeProduto.Text;
            p.Descricao = descProduto.Text;
            p.Qtd = int.Parse(qntdProduto.Text);
            p.Validade = DateTime.Parse(validadeProduto.Text);
            p.Preco = decimal.Parse(precoProduto.Text);
            p.IdFornecedor = forn.Id;
            nP = new NProduto();
            nP.Update(p);
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Select(forn.Id);
        }

        private void DeleteProduto(object sender, RoutedEventArgs e)
        {
            nP = new NProduto();
            nP.Delete(p);
            listaProdutos.ItemsSource = null;
            listaProdutos.ItemsSource = nP.Select(forn.Id);
        }

        private void Fechar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
