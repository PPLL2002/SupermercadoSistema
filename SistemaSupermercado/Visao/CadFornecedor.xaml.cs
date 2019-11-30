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
    /// Lógica interna para CadFornecedor.xaml
    /// </summary>
    public partial class CadFornecedor : Window
    {
        public CadFornecedor()
        {
            InitializeComponent();
        }

        Fornecedor f;
        NFornecedor nF;

        private void InserirFornecedor(object sender, RoutedEventArgs e)
        {
            f = new Fornecedor();
            f.Nome = nomeForn.Text;
            f.Email = emailForn.Text;
            f.Categoria = categForn.Text;
            nF = new NFornecedor();
            nF.Insert(f);
            CadProdFornecedor prodF = new CadProdFornecedor(f);
            prodF.ShowDialog();
        }

        private void ListarFornecedores(object sender, RoutedEventArgs e)
        {
            nF = new NFornecedor();
            listaFornecedores.ItemsSource = null;
            listaFornecedores.ItemsSource = nF.Select();
        }

        private void RemoverFornecedor(object sender, RoutedEventArgs e)
        {
            nF = new NFornecedor();
            nF.Delete(listaFornecedores.SelectedItem as Fornecedor);
            listaFornecedores.ItemsSource = null;
            listaFornecedores.ItemsSource = nF.Select();
        }

        private void AtualizarFornecedor(object sender, RoutedEventArgs e)
        {
            f.Nome = nomeForn.Text;
            f.Email = emailForn.Text;
            f.Categoria = categForn.Text;
            nF = new NFornecedor();
            nF.Update(f);
        }

        private void ListaFornecedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listaFornecedores.SelectedItem != null)
            {
                f = listaFornecedores.SelectedItem as Fornecedor;
                nomeForn.Text = f.Nome;
                emailForn.Text = f.Email;
                categForn.Text = f.Categoria;
            }
        }

        private void ListaFornecedores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listaFornecedores.SelectedItem != null)
            {
                f = listaFornecedores.SelectedItem as Fornecedor;
                CadProdFornecedor prodF = new CadProdFornecedor(f);
                prodF.ShowDialog();
            }
        }
    }
}
