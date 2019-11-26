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

        private void btnInserirF(object sender, RoutedEventArgs e)
        {

        }

        private void btnListarF(object sender, RoutedEventArgs e)
        {
            ListaFuncionarios.ItemsSource = null;
            ListaFuncionarios.Items = f.Select();
        }

        private void btnDeletarF(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateF(object sender, RoutedEventArgs e)
        {

        }
    }
}
