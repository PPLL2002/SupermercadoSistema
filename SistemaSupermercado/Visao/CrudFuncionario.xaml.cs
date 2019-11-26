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
    /// Lógica interna para CrudFuncionario.xaml
    /// </summary>
    public partial class CrudFuncionario : Window
    {
        public CrudFuncionario()
        {
            InitializeComponent();
        }

        Funcionario f;
        NFuncionario nF = new NFuncionario();

        private void btnInserirF(object sender, RoutedEventArgs e)
        {
            CadFuncionario CadF = new CadFuncionario();
            CadF.ShowDialog();
        }

        private void btnListarF(object sender, RoutedEventArgs e)
        {
            ListaFuncionarios.ItemsSource = null;
            ListaFuncionarios.ItemsSource = nF.Select();
        }

        private void btnDeletarF(object sender, RoutedEventArgs e)
        {
            nF.Delete(f);
            ListaFuncionarios.ItemsSource = null;
            ListaFuncionarios.ItemsSource = nF.Select();
        }

        private void btnUpdateF(object sender, RoutedEventArgs e)
        {
            nF.Update(f);
            ListaFuncionarios.ItemsSource = null;
            ListaFuncionarios.ItemsSource = nF.Select();
        }

        private void ListaFuncionarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaFuncionarios.SelectedItem != null) f = ListaFuncionarios.SelectedItem as Funcionario;
        }
    }
}
